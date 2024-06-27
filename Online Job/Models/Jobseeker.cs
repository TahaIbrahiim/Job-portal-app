using System.ComponentModel.DataAnnotations;

namespace Online_Job.Models
{
    public class Jobseeker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Bio { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:mm-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BirthOfDate { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public byte[]? image { get; set; }


    }
}
