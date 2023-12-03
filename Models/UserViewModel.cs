using System.ComponentModel.DataAnnotations;

namespace TigerPadG4.ViewModel
{
    public record User(int userID, [property: Display(Name = "UserUserName")] string userName, [property: Display(Name = "UserEmail")] string userEmail, [property: Display(Name = "UserPassword")][property: DataType(DataType.Password)] string userPassword);
}
