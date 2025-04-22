using Core.BusinessObject;
using TaskManagerWebApp.DataLayer;

namespace ServiceLayer
{
    public class UserService
    {
        /// <summary>
        /// Method to get all users
        /// </summary>
        /// <returns></returns>
        public List<User> GetAll()
        {
            return UserRepository.GetAll();
        }
        /// <summary>
        /// Method to get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            return UserRepository.GetById(id);
        }
        /// <summary>
        /// Method to add user
        /// </summary>
        /// <param name="user"></param>
        public void Add(User user)
        {
            if (user != null)
            {
                UserRepository.Add(user);
            }
        }
        /// <summary>
        /// Method to delete user
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (id != default(int))
            {
                UserRepository.Delete(id);
            }
        }
        /// <summary>
        /// Method to update user
        /// </summary>
        /// <param name="user"></param>
        public void Update(User user)
        {
            if (user!=null)
            {
                UserRepository.Update(user);
            }
        }
        /// <summary>
        /// Method to validate user by email and password
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateUser(string email, string password)
        {
            if(!string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(password))
            {
                return UserRepository.ValidateUser(email, password);

            }
            return null;
        }

    }    
}


