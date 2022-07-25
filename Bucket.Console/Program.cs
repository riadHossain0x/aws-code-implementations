using S3Bucket.Library;

namespace S3Bucket.Console
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var bucketName = "riad-bucket";
            var filePath = @"C:\Users\Riad\Desktop\file\devskill-aspnet-b6\Assignment-7\Bucket.Console\newfile.txt";

            var s3Bucket = new S3BucketOperations(new S3BucketClient(), 
                bucketName, "newfile.txt");

            // Upload operation
            var uploadResponse = await s3Bucket.UploadAsync(filePath);
            System.Console.WriteLine(uploadResponse);

            // Download operation
            //var downloadResponse = await s3Bucket.DownloadAsync(filePath);
            //System.Console.WriteLine(downloadResponse);

            // Delete operation
            //var deleteResponse = await s3Bucket.DeleteAsync();
            //System.Console.WriteLine(deleteResponse);

        }
    }
}