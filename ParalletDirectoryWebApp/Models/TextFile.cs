using System.ComponentModel.DataAnnotations;

namespace ParalletDirectoryWebApp.Models
{
    public class TextFile
    {
        [Key]
        public int TextFileid { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}