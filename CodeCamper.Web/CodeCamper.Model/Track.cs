using System.ComponentModel.DataAnnotations;

namespace CodeCamper.Model
{
    public class Track
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
