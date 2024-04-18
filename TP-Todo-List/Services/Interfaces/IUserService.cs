using TP_Todo_List.Data.Entities;
using TP_Todo_List.Data.Models;

namespace TP_Todo_List.Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetAll();
        public int CreateUser (User user);
        int UpdateUser(int userId, UserDto userDto);
        public void DeleteUser(int userId);
        public User GetOne (int id);
    }
}
