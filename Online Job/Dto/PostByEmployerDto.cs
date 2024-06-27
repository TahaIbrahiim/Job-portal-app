using System.ComponentModel.DataAnnotations;

namespace Online_Job.Dto
{
    public class PostByEmployerDto
    { 
        public string EmployerName { get; set; }
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime? PostTime { get; set; }


    }
}
