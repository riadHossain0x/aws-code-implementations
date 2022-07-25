
using Amazon.S3.Model;

namespace S3Bucket.Library
{
    public interface IS3BucketClient
    {
        Task<DeleteObjectResponse> DeleteFileAsync(string bucketName, string fileName);
        Task<GetObjectResponse> DownloadFileAsync(string bucketName, string fileName);
        Task<PutObjectResponse> UploadFileAsync(string bucketName, string fileName, string filePath);
    }
}