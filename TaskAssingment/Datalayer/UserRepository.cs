using System.Data;
using Datalayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Core.BusinessObject;

namespace TaskManagerWebApp.DataLayer
{
    public class UserRepository
    {
        /// <summary>
        /// Method to get all the users
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAll()
        {
            List<User> users = new List<User>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("SELECT user_id, first_name, last_name, email, password, type, created_on, created_by, updated_on, updated_by FROM users");

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    users.Add(new User
                    {
                        UserId = reader["user_id"] != DBNull.Value ? Convert.ToInt32(reader["user_id"]) : 0,
                        FirstName = reader["first_name"]?.ToString(),
                        LastName = reader["last_name"]?.ToString(),
                        Email = reader["email"]?.ToString(),
                        Type = reader["type"] != DBNull.Value ? Convert.ToInt32(reader["type"]) : 0,
                        CreatedOn = reader["created_on"] != DBNull.Value ? Convert.ToDateTime(reader["created_on"]) : DateTime.MinValue,
                        CreatedBy = reader["created_by"]?.ToString(),
                        UpdatedOn = reader["updated_on"] != DBNull.Value ? Convert.ToDateTime(reader["updated_on"]) : DateTime.MinValue,
                        UpdatedBy = reader["updated_by"]?.ToString()
                    });
                }
            }

            return users;
        }

        /// <summary>
        /// Method to get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static User GetById(int id)
        {
            User user = null;

            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("SELECT user_id, first_name, last_name, email, password, type, created_on, created_by, updated_on, updated_by FROM users WHERE user_id = @UserId");

            db.AddInParameter(cmd, "UserId", DbType.Int32, id);

            using (var reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    user = new User
                    {
                        UserId = reader["user_id"] != DBNull.Value ? Convert.ToInt32(reader["user_id"]) : 0,
                        FirstName = reader["first_name"]?.ToString(),
                        LastName = reader["last_name"]?.ToString(),
                        Email = reader["email"]?.ToString(),
                        Password = reader["password"]?.ToString(),
                        Type = reader["type"] != DBNull.Value ? Convert.ToInt32(reader["type"]) : 0,
                        CreatedOn = Convert.ToDateTime(reader["created_on"]),
                        CreatedBy = reader["created_by"].ToString(),
                        UpdatedOn = Convert.ToDateTime(reader["updated_on"]),
                        UpdatedBy = reader["updated_by"].ToString()

                    };
                }
            }

            return user;
        }
        /// <summary>
        /// Method to update user
        /// </summary>
        /// <param name="user"></param>
        public static void Update(User user)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(
                "UPDATE users SET first_name = @FirstName, last_name = @LastName, email = @Email, password = @Password, type=@Type, created_on = @CreatedOn, created_by = @CreatedBy,updated_on=@UpdatedOn,updated_by=@UpdatedBy WHERE user_id = @UserId");
            db.AddInParameter(cmd, "UserId", DbType.Int32, user.UserId);
            db.AddInParameter(cmd, "FirstName", DbType.String, user.FirstName);
            db.AddInParameter(cmd, "LastName", DbType.String, user.LastName);
            db.AddInParameter(cmd, "Email", DbType.String, user.Email);
            db.AddInParameter(cmd, "Password", DbType.String, user.Password);
            db.AddInParameter(cmd, "Type", DbType.Int32, user.Type);
            db.AddInParameter(cmd, "UpdatedOn", DbType.DateTime, user.UpdatedOn);
            db.AddInParameter(cmd, "UpdatedBy", DbType.String, user.UpdatedBy);
            db.AddInParameter(cmd, "CreatedOn", DbType.DateTime, user.CreatedOn);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, user.CreatedBy);
            db.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Method to add user
        /// </summary>
        /// <param name="user"></param>
        public static void Add(User user)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("INSERT INTO users (first_name, last_name, email, password, type, created_on, created_by) VALUES (@FirstName, @LastName, @Email, @Password, @Type, @CreatedOn, @CreatedBy)");
            db.AddInParameter(cmd, "FirstName", DbType.String, user.FirstName);
            db.AddInParameter(cmd, "LastName", DbType.String, user.LastName);
            db.AddInParameter(cmd, "Email", DbType.String, user.Email);
            db.AddInParameter(cmd, "Password", DbType.String, user.Password);
            db.AddInParameter(cmd, "Type", DbType.Int32, user.Type);
            db.AddInParameter(cmd, "CreatedOn", DbType.DateTime, user.CreatedOn);
            db.AddInParameter(cmd, "CreatedBy", DbType.String, user.CreatedBy);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Method to delete user
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM users WHERE user_id = @id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Method to Get User By Username And Password
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User GetUserByUsernameAndPassword(string firstName, string password)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM users WHERE first_name = @FirstName AND password = @Password");
            db.AddInParameter(cmd, "FirstName", DbType.String, firstName);
            db.AddInParameter(cmd, "Password", DbType.String, password);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["user_id"]),
                        FirstName = reader["first_name"].ToString(),
                        LastName = reader["last_name"].ToString(),
                        Password = reader["password"].ToString(),
                        Type = Convert.ToInt32(reader["type"])
                    };
                }
            }
            return null;
        }
        /// <summary>
        /// Method to validate user
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static User ValidateUser(string email, string password)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("SELECT * FROM users WHERE email = @Email AND password = @Password");
            db.AddInParameter(cmd, "Email", DbType.String, email);
            db.AddInParameter(cmd, "Password", DbType.String, password);

            using (IDataReader reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    return new User
                    {
                        UserId = Convert.ToInt32(reader["user_id"]),
                        Email = reader["email"].ToString()
                    };
                }
            }
            return null;
        }

    }
}

