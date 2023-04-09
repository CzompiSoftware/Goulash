using System.ComponentModel.DataAnnotations;
using Goulash.Core;

namespace Goulash.Gcp
{
    public class GoogleCloudStorageOptions : StorageOptions
    {
        [Required]
        public string BucketName { get; set; }
    }
}
