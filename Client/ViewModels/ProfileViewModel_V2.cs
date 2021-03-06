using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels{
    public class ProfileViewModel_V2:IProfileViewModel
    {
       
        public long UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string EmailAddress {get;set;}
        public string Message {get;set;}

    public void updateProfile(){
    //    User user = _profileViewModel;
    //   await HttpClient.PutAsJsonAsync("user/updateprofile/10",user);
        this.Message=this.FirstName + "'s Profile updated successfully --faster";
    }
    public void getProfile(){
        //User user = await HttpClient.GetFromJsonAsync<User>("user/getprofile/10");
        //_profileViewModel = user;
       this.FirstName="NewDriver"; 
        this.Message=this.FirstName + "'s Profile loaded successfully --faster";
    }

        Task IProfileViewModel.updateProfile()
        {
            throw new System.NotImplementedException();
        }

        Task IProfileViewModel.getProfile()
        {
            throw new System.NotImplementedException();
        }

        public static implicit operator  ProfileViewModel_V2(User user){
            return new ProfileViewModel_V2{
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
            };
        }
        public static implicit operator User(ProfileViewModel_V2 profileViewModel){
            return new User{
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId,
            };
        }
    }
}