using System.ComponentModel.DataAnnotations;

namespace NET_9_Business_App_MinimalAPI_Register.Models
{
    public class Register
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]//REGEX for email validation
        public string? EmployeeEmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number.")]//REGEX for password validation
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string? EmployeePassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required...")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number.")]//REGEX for password confirmation
        [Display(Name = "Confirm Password")]
        [Compare("EmployeePassword", ErrorMessage = "Passwords do not match...")]
        public string? EmployeeConfirmPassword { get; set; }

        public static ValueTask<Register?> BindAsync(HttpContext context)
        {
            var password = context.Request.Query["pwd1"];
            var confirmPassword = context.Request.Query["pwd2"];
            var email = context.Request.Query["email"];

            return new ValueTask<Register?>(new Register 
            { EmployeePassword = password, 
                EmployeeConfirmPassword = confirmPassword, 
                EmployeeEmailAddress = email });

        }
    }//End of Register class
}//End namespace
