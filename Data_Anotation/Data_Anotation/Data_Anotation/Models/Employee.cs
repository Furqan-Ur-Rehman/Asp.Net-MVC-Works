using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Data_Anotation.Models
{
    public class Employee
    {
        //Auto Implemented Property
        [DisplayName("ID")]
        [Required(ErrorMessage = "ID is mandatory")] /*Custom Error Message*/
        public int EmployeeId { get; set; }


        [DisplayName("Employee Name")]
        [Required] /*Default Error Message*/
        [StringLength(20,MinimumLength = 5)]
        public string EmployeeName { get; set; }


        [Required(ErrorMessage ="Age is must to fill!!")]
        [Range(20,60)] /*You can put Custom Error message with , after 60 */
        public int? EmployeeAge { get; set; }


        [Required(ErrorMessage ="Gender is must to fill!!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please Enter Valid Gender i.e. Male or Female Only!")]
        public string EmployeeGender { get; set; }


        [Required(ErrorMessage ="Email is required!!")]
        [RegularExpression("^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$",ErrorMessage ="You Entered Invalid Email!")]
        public string EmployeeEmail { get; set; }


        [Required]
        [DataType(DataType.Password)]
        public string EmpPassword { get; set; }


        [Required(ErrorMessage = "This field is also mandatory for confirmation of password!")]
        [Compare("EmpPassword")]
        public string EmpConfirmPassword { get; set; }



        [ReadOnly(true)]
        public string EmpOrganizationName { get; set; }
        


        [Required(ErrorMessage = "This Address Field is required to fill as well!")]
        [DisplayName("Employee Address:")]
        [DataType(DataType.MultilineText)]
        [StringLength(40, MinimumLength = 10)]
        public string EmpAddress { get; set; }


        [Required(ErrorMessage = "This field is mandatory!!")]
        [DisplayName("Employee Joinning Date:")]
        [DataType(DataType.Date)]
        public string EmpJoinningDate { get; set; }



        [Required(ErrorMessage = "This field is mandatory!!")]
        [DisplayName("Employee Joinning Time:")]
        [DataType(DataType.Time)]
        public  string EmpJoinningTime { get; set; }
    }
}