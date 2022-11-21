using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

public class StudentModel
{
    public int ID { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "First Name Required")]
    public string FirstName { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Surname Required")]
    public string Surname { get; set; }

    [DataType(DataType.Text)]
    // international mobile phone number regex
    [RegularExpression(@"^\+[1-9]{1}[0-9]{3,14}$", ErrorMessage = "Not a valid Telephone Number")]
    [Required(ErrorMessage = "Telephone No. Required")]
    public string TelephoneNo { get; set; }

    [DataType(DataType.Text)]
    // default email regex built into HTML5
    [RegularExpression(@".+\@.+\..+", ErrorMessage = "Not a valid Email")]
    [Required(ErrorMessage = "Email Required")]
    public string email { get; set; }

    [DataType(DataType.Text)]
    [Required(ErrorMessage = "Country of Origin Required")]
    public string countryOfOrigin { get; set; }
}
