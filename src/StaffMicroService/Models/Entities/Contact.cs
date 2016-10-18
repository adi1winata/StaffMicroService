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
    public class Contact : IFSModel
    {
        /// <summary>
        /// 
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int contactid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int personalidentitytypeid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        [StringLength(80, ErrorMessage = "Max length 60 characters.")]
        public string personalidentityno { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        [DefaultValue(false)]
        public bool namestyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(5, ErrorMessage = "Max length 5 characters.")]
        public string title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(80, ErrorMessage = "Max length 80 characters.")]
        public string firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(80, ErrorMessage = "Max length 80 characters.")]
        public string middlename { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [StringLength(80, ErrorMessage = "Max length 80 characters.")]
        public string lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(80, ErrorMessage = "Max length 80 characters.")]
        public string alias { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        public int gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        public int maritalstatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [StringLength(25, ErrorMessage = "Max length 25 characters.")]
        public string birthplace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Required field.")]
        public DateTime birthdate { get; set; }

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
            contactid = 0;
        }
    }
}
