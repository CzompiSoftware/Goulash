using System.ComponentModel.DataAnnotations;

namespace Goulash.Azure
{
    public class AzureTableOptions
    {
        [Required]
        public string ConnectionString { get; set; }
    }
}
