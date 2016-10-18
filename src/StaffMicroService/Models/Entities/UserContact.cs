using FSLib.Factory;
using System;
using System.ComponentModel.DataAnnotations;

namespace StaffMicroService.Models.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public class UserContact : IFSModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int userid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int contactid { get; set; }

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

        }
    }
}
