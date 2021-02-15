using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels{
    public class ProfileViewModel
    {
        public long UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string EmailAddress {get;set;}
        public string Message {get;set;}

        public static implicit operator ProfileViewModel(User user){
            return new ProfileViewModel{
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
            };
        }
    }
}