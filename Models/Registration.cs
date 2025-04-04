using System.ComponentModel.DataAnnotations;

namespace NET_9_Business_App_MinimalAPI_Register.Models
{
    public class Registration
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email address.")]//REGEX for email validation
        public string? EmployeeEmailAddress { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one capital letter and one number.")]//REGEX for password validation
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(100, MinimumLength=6, ErrorMessage = "Password must be at least 6 characters long...")]
        public string? EmployeePassword { get; set; }
        [Required(ErrorMessage = "Confirm password is required...")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one letter and one number.")]//REGEX for password confirmation
        [Display(Name = "Confirm Password")]
        [Compare("EmployeePassword", ErrorMessage = "Passwords do not match...")]
        public string? EmployeeConfirmPassword { get; set; }

        public static ValueTask<Registration?> BindAsync(HttpContext context)
        {
            var password = context.Request.Query["pwd1"];
            var confirmPassword = context.Request.Query["pwd2"];
            var email = context.Request.Query["email"];

            return new ValueTask<Registration?>(new Registration
            {
                EmployeeEmailAddress = email,
                EmployeePassword = password,
                EmployeeConfirmPassword = confirmPassword
            });
        }
    }//End of Register class
}//End namespace
