using System.ComponentModel.DataAnnotations;

namespace PersonalApp.Dto
{
    public record CreatePerson([Required(ErrorMessage = "FirstName is Requried")]  string firstName , string lastName,
        [Required(ErrorMessage = "mobileNumber is Requried")] string mobileNumber, string phoneNumber, string description);



    public record UpdatePerson(int Id,[Required(ErrorMessage = "FirstName is Requried")] string firstName, string lastName,
        [Required(ErrorMessage = "mobileNumber is Requried")] string mobileNumber, string phoneNumber, string description);

    public record GetPerson(int Id,string firstName,string lastName,
         string mobileNumber, string phoneNumber, string description);
}
