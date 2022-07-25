using S3Bucket.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Bucket.Console
{
    internal class S3BucketOperations
    {
        private readonly IS3BucketClient _s3BucketClient;
        private readonly string _bucketName;
        private readonly string _fileName;

        public S3BucketOperations(IS3BucketClient s3BucketClient, string bucketName, string fileName)
        {
            _s3BucketClient = s3BucketClient;
            _bucketName = bucketName;
            _fileName = fileName;
        }
        public async Task<string> DeleteAsync()
        {
            var response = await _s3BucketClient.DeleteFileAsync(_bucketName, _fileName);
            return response.HttpStatusCode.ToString();
        }
        public async Task<string> DownloadAsync(string destPath)
        {
            var response = await _s3BucketClient.DownloadFileAsync(_bucketName, _fileName);
            await response.WriteResponseStreamToFileAsync(destPath, true, CancellationToken.None);
            return response.HttpStatusCode.ToString();
        }
        public async Task<string> UploadAsync(string filePath)
        {
            var response = await _s3BucketClient.UploadFileAsync(_bucketName, _fileName, filePath);
            return response.HttpStatusCode.ToString();
        }
    }
}
