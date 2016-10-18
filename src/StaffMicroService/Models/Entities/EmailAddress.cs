using FSLib.Factory;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StaffMicroService.Models.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailAddress : IFSModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int emailaddressid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int memberemailaddresstypeid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(80, ErrorMessage = "Max length 80 characters.")]
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        [DefaultValue(false)]
        public bool isprimary { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        [StringLength(25, ErrorMessage = "Max length 25 characters.")]
        public string createdby { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public DateTime createddate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        [StringLength(25, ErrorMessage = "Max length 25 characters.")]
        public string createdfrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(60, ErrorMessage = "Max length 60 characters.")]
        public string modifiedby { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? modifieddate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(25, ErrorMessage = "Max length 25 characters.")]
        public string modifiedfrom { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void Init()
        {
            emailaddressid = 0;
        }
    }
}
