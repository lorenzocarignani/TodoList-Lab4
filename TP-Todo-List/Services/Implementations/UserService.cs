using TP_Todo_List.ContextDB;
using TP_Todo_List.Data.Entities;
using TP_Todo_List.Data.Models;
using TP_Todo_List.Services.Interfaces;

namespace TP_Todo_List.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly ContextTodo _context;
        public UserService(ContextTodo context) 
        {
            _context = context;
        }

        public int CreateUser(User user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return user.UserId;

        }

        public void DeleteUser(int userId)
        {
            var res = _context.Users.SingleOrDefault(u => u.UserId == userId);
            _context.Remove(res);
            _context.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetOne(int id)
        {
            return _context.Users.SingleOrDefault(i => i.UserId == id);
        }

        public int UpdateUser(int userId, UserDto userDto)
        {
            var existingUser = _context.Users.SingleOrDefault(u => u.UserId == userId);
            if (existingUser == null)
            {
                return 0;
            }

            existingUser.Name = userDto.Name;
            existingUser.Email = userDto.Email;
            existingUser.Address = userDto.Address;

            _context.Update(existingUser);
            _context.SaveChanges();

            return existingUser.UserId;
        }
    }
}
