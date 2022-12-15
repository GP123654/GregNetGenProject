


//Package
namespace GregNetGenProject.Models
{
    //Class
    public class AuditingModel
    {
        /// <summary>
        /// This stores the id of the user when auditing // I think I should have made this a string
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// This stores the email address of the user when auditing
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// This stores the date and time of the the audit
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// This stores the description of the audit
        /// </summary>
        public string Description { get; set; }
    }
}
//-------------------------------ooo000 END OF FILE 000ooo-------------------------------//