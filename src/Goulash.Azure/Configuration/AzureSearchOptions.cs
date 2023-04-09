using System.ComponentModel.DataAnnotations;

namespace Goulash.Azure
{
    public class AzureSearchOptions
    {
        [Required]
        public string AccountName { get; set; }

        [Required]
        public string ApiKey { get; set; }
    }
}
