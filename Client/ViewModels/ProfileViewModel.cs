using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using BlazingChat.Shared.Models;

namespace BlazingChat.ViewModels{
    public class ProfileViewModel:IProfileViewModel
    {
        public long UserId {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string EmailAddress {get;set;}
        public string Message {get;set;}
        public HttpClient _httpClient { get; }

        public ProfileViewModel()
    {
    
    }
    public ProfileViewModel(HttpClient httpClient)
    {
            _httpClient = httpClient;
        }
    public async Task updateProfile(){
        User user =this; 
       await _httpClient.PutAsJsonAsync("user/updateprofile/10",user);
        this.Message="Profile updated successfully";
    }
    public async Task getProfile(){
        User user = await _httpClient.GetFromJsonAsync<User>("user/getprofile/10");
       loadCurrentObject(user); 
        this.Message="Profile loaded successfully";
    
    }
    private void loadCurrentObject(ProfileViewModel profileViewModel){
        this.FirstName = profileViewModel.FirstName;
        this.LastName= profileViewModel.LastName;
        this.EmailAddress=profileViewModel.EmailAddress;
    }
        public static implicit operator ProfileViewModel(User user){
            return new ProfileViewModel{
                FirstName = user.FirstName,
                LastName = user.LastName,
                EmailAddress = user.EmailAddress,
                UserId = user.UserId,
            };
        }
        public static implicit operator User(ProfileViewModel profileViewModel){
            return new User{
                FirstName = profileViewModel.FirstName,
                LastName = profileViewModel.LastName,
                EmailAddress = profileViewModel.EmailAddress,
                UserId = profileViewModel.UserId,
            };
        }
    }
}