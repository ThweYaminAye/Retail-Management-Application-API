using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using BAL.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MODEL;
using MODEL.Entities;
using MODEL.CommonConfig;
using REPOSITORY.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BAL.Service
{
    public class FilesService : IFilesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        private readonly DataContext _dataContext;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string _containerName;

        public FilesService(IUnitOfWork unitOfWork, AppSettings appSettings, DataContext dataContext, BlobServiceClient blobServiceClient, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings;
            _dataContext = dataContext;
            _blobServiceClient = blobServiceClient;
            //_containerName = "trainingdev";
            _containerName = configuration["AzureBlobStorage:AzureContainer"];
        }

        public async Task<string> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("No file uploaded.");
            }
            var containerClient = _blobServiceClient.GetBlobContainerClient(_containerName);
            await containerClient.CreateIfNotExistsAsync();


            var blobClient = containerClient.GetBlobClient(file.FileName);
            using (var stream = file.OpenReadStream())
            {
                await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });
            }

            var fileRecord = new Files
            {
                Id = new Guid(),
                FileName = file.FileName,
                FileUrl = blobClient.Uri.AbsoluteUri
            };

            await _unitOfWork.Files.Add(fileRecord);
            await _unitOfWork.SaveChangesAsync();

            return blobClient.Uri.ToString();
        }

       
    }
}
