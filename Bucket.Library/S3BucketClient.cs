using Amazon.S3;
using Amazon.S3.Model;

namespace S3Bucket.Library
{
    public class S3BucketClient : IS3BucketClient
    {
        private readonly AmazonS3Client _client;
        public S3BucketClient()
        {
            _client = new AmazonS3Client();
        }
        public async Task<PutObjectResponse> UploadFileAsync(string bucketName, string fileName, string filePath)
        {
            var putrequest = new PutObjectRequest()
            {
                BucketName = bucketName,
                Key = fileName,
                FilePath = filePath,
                ContentType = "text/plain"
            };
            putrequest.Metadata.Add("meta-title", "newUpload");
            PutObjectResponse response = await _client.PutObjectAsync(putrequest);

            return response;
        }
        public async Task<DeleteObjectResponse> DeleteFileAsync(string bucketName, string fileName)
        {
            var deleteObject = new DeleteObjectRequest()
            {
                BucketName = bucketName,
                Key = fileName
            };

            DeleteObjectResponse response = await _client.DeleteObjectAsync(deleteObject);
            return response;
        }
        public async Task<GetObjectResponse> DownloadFileAsync(string bucketName, string fileName)
        {
            GetObjectRequest request = new GetObjectRequest()
            {
                BucketName = bucketName,
                Key = fileName
            };


            GetObjectResponse response = await _client.GetObjectAsync(request);
            return response;
        }
    }
}