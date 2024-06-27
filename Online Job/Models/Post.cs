using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Online_Job.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string? PostDescription { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? PostTime { get; set; }



        [ForeignKey("Employer")]
        public int? Employer_ID { get; set; }

        [JsonIgnore]
        public virtual Employer? Employer { get; set; }

    }
}
