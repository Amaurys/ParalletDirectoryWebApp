using System.ComponentModel.DataAnnotations;

namespace ParalletDirectoryWebApp.Models
{
    public class Folder
    {
        [Key]
        public int Folderid { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}