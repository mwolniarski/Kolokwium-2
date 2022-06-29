using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kolokwium_2.Models
{
    public class File
    {
        public int FileId { get; set; }
        public int TeamId { get; set; }
        public string FileName { get; set; }
        public string FileExtension { get; set; }
        public int FileSize { get; set; }
        public virtual Team Team { get; set; }
    }
}
