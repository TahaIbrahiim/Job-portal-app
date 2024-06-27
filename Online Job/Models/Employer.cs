using System.Text.Json.Serialization;

namespace Online_Job.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public byte[]? image { get; set; }

        public virtual List<Post>? posts { get; set; } = new List<Post>();
       
    }
}
