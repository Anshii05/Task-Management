using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using Core.BusinessObject;
using Datalayer;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace TaskManagerWebApp.DataLayer
{
    public class AssignedTaskRepository
    {
        /// <summary>
        /// Method to get all the assigned tasks
        /// </summary>
        /// <returns></returns>
        public static List<AssignedTask> GetAll()
        {
            List<AssignedTask> assigneTaskList = new List<AssignedTask>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"SELECT id,task_id,user_id,user_name, title, description, due_date, status, remarks, 
                                                     created_on, created_by_id, created_by_name, 
                                                     updated_on, updated_by_id, updated_by_name
                                                     FROM assignedtasks");

            using (var reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    assigneTaskList.Add(new AssignedTask
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TaskId = Convert.ToInt32(reader["task_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        UserName = Convert.ToString(reader["user_name"]),
                        Title = Convert.ToString(reader["title"]),
                        Description = Convert.ToString(reader["description"]),
                        DueDate = Convert.ToDateTime(reader["due_date"]),
                        Status = Convert.ToInt32(reader["status"]),
                        Remarks = Convert.ToString(reader["remarks"]),
                        CreatedOn = Convert.ToDateTime(reader["created_on"]),
                        CreatedById = reader["created_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["created_by_id"]),
                        CreatedByName = reader["created_by_name"] == DBNull.Value ? null : Convert.ToString(reader["created_by_name"]),
                        UpdatedOn = Convert.ToDateTime(reader["updated_on"]),
                        UpdatedById = reader["updated_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["updated_by_id"]),
                        UpdatedByName = reader["updated_by_name"] == DBNull.Value ? null : Convert.ToString(reader["updated_by_name"]),
                    });
                }
            }
            return assigneTaskList;
        }
        /// <summary>
        /// Method to get task by task id
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public static List<AssignedTask> GetByTaskId(int taskId)
        {
            List<AssignedTask> assignedTasks = new List<AssignedTask>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"
        SELECT id, task_id, user_id,user_name, title, description, due_date, status, remarks, 
               created_on, created_by_id, created_by_name, 
               updated_on, updated_by_id, updated_by_name
        FROM assignedtasks 
        WHERE task_id = @taskId");

            db.AddInParameter(cmd, "taskId", DbType.Int32, taskId);

            using (var reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    AssignedTask assignedTask = new AssignedTask
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TaskId = Convert.ToInt32(reader["task_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        UserName = Convert.ToString(reader["user_name"]),
                        Title = Convert.ToString(reader["title"]),
                        Description = Convert.ToString(reader["description"]),
                        DueDate = Convert.ToDateTime(reader["due_date"]),
                        Status = Convert.ToInt32(reader["status"]),
                        Remarks = Convert.ToString(reader["remarks"]),
                        CreatedOn = Convert.ToDateTime(reader["created_on"]),
                        CreatedById = reader["created_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["created_by_id"]),
                        CreatedByName = reader["created_by_name"] == DBNull.Value ? null : Convert.ToString(reader["created_by_name"]),
                        UpdatedOn = Convert.ToDateTime(reader["updated_on"]),
                        UpdatedById = reader["updated_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["updated_by_id"]),
                        UpdatedByName = reader["updated_by_name"] == DBNull.Value ? null : Convert.ToString(reader["updated_by_name"]),
                    };

                    assignedTasks.Add(assignedTask);
                }
            }

            return assignedTasks;
        }
        /// <summary>
        /// Method to get task by user id
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static List<AssignedTask> GetByUserId(int userId)
        {
            List<AssignedTask> assignedTasks = new List<AssignedTask>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"
        SELECT id, task_id, user_id,user_name, title, description, due_date, status, remarks, 
               created_on, created_by_id, created_by_name, 
               updated_on, updated_by_id, updated_by_name
        FROM assignedtasks 
        WHERE user_id = @userId");

            db.AddInParameter(cmd, "userId", DbType.Int32, userId);

            using (var reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    AssignedTask assignedTask = new AssignedTask
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TaskId = Convert.ToInt32(reader["task_id"]),
                        UserId = Convert.ToInt32(reader["user_id"]),
                        UserName = Convert.ToString(reader["user_name"]),
                        Title = Convert.ToString(reader["title"]),
                        Description = Convert.ToString(reader["description"]),
                        DueDate = Convert.ToDateTime(reader["due_date"]),
                        Status = Convert.ToInt32(reader["status"]),
                        Remarks = Convert.ToString(reader["remarks"]),
                        CreatedOn = Convert.ToDateTime(reader["created_on"]),
                        CreatedById = reader["created_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["created_by_id"]),
                        CreatedByName = reader["created_by_name"] == DBNull.Value ? null : Convert.ToString(reader["created_by_name"]),
                        UpdatedOn = Convert.ToDateTime(reader["updated_on"]),
                        UpdatedById = reader["updated_by_id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["updated_by_id"]),
                        UpdatedByName = reader["updated_by_name"] == DBNull.Value ? null : Convert.ToString(reader["updated_by_name"]),
                    };

                    assignedTasks.Add(assignedTask);
                }
            }

            return assignedTasks;
        }

        /// <summary>
        /// Method to add the assigned tasks
        /// </summary>
        /// <param name="task"></param>
        public static void Add(AssignedTask task)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"INSERT INTO assignedtasks 
                (task_id,user_id,user_name,title, description, due_date, status, remarks, created_on, created_by_id, created_by_name, updated_on, updated_by_id, updated_by_name) 
                VALUES 
                (@taskid,@userid,@username,@title, @description, @dueDate, @status, @remarks, @createdOn, @createdById, @createdByName, @updatedOn, @updatedById, @updatedByName)");
            db.AddInParameter(cmd, "taskid", DbType.Int32, task.TaskId);
            db.AddInParameter(cmd, "userid", DbType.Int32, task.UserId);
            db.AddInParameter(cmd, "username", DbType.String, task.UserName);
            db.AddInParameter(cmd, "title", DbType.String, task.Title);
            db.AddInParameter(cmd, "description", DbType.String, task.Description);
            db.AddInParameter(cmd, "dueDate", DbType.DateTime, task.DueDate);
            db.AddInParameter(cmd, "status", DbType.Int32, task.Status);
            db.AddInParameter(cmd, "remarks", DbType.String, task.Remarks);
            db.AddInParameter(cmd, "createdOn", DbType.DateTime, task.CreatedOn);
            db.AddInParameter(cmd, "createdById", DbType.Int32, task.CreatedById);
            db.AddInParameter(cmd, "createdByName", DbType.String, task.CreatedByName);
            db.AddInParameter(cmd, "updatedOn", DbType.DateTime, task.UpdatedOn);
            db.AddInParameter(cmd, "updatedById", DbType.Int32, task.UpdatedById);
            db.AddInParameter(cmd, "updatedByName", DbType.String, task.UpdatedByName);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Method to update the assigned tasks
        /// </summary>
        /// <param name="task"></param>
        public static void Update(AssignedTask task)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"UPDATE assignedtasks SET 
                task_id = @taskid,
                user_id = @userid,
                user_name=@username,
                title = @title,
                description = @description,
                due_date = @dueDate,
                status = @status,
                remarks = @remarks,
                updated_on = @updatedOn,
                updated_by_id = @updatedById,
                updated_by_name = @updatedByName
                WHERE user_id = @userid");

            db.AddInParameter(cmd, "taskId", DbType.Int32, task.TaskId);
            db.AddInParameter(cmd, "userid", DbType.Int32, task.UserId);
            db.AddInParameter(cmd, "username", DbType.String, task.UserName);
            db.AddInParameter(cmd, "title", DbType.String, task.Title);
            db.AddInParameter(cmd, "description", DbType.String, task.Description);
            db.AddInParameter(cmd, "dueDate", DbType.DateTime, task.DueDate);
            db.AddInParameter(cmd, "status", DbType.Int32, task.Status);
            db.AddInParameter(cmd, "remarks", DbType.String, task.Remarks);
            db.AddInParameter(cmd, "updatedOn", DbType.DateTime, task.UpdatedOn);
            db.AddInParameter(cmd, "updatedById", DbType.Int32, task.UpdatedById);
            db.AddInParameter(cmd, "updatedByName", DbType.String, task.UpdatedByName);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// method to delete task by task id
        /// </summary>
        /// <param name="taskId"></param>
        public static void DeleteByTaskId(int taskId)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM assignedtasks WHERE task_id = @taskId");
            db.AddInParameter(cmd, "taskId", DbType.Int32, taskId);
            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// method to delete task by taskid and userid
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="userId"></param>
        public static void DeleteByTaskIdAndUserId(int taskId, int userId)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM assignedtasks WHERE task_id = @taskId AND user_id = @userId");
            db.AddInParameter(cmd, "taskId", DbType.Int32, taskId);
            db.AddInParameter(cmd, "userId", DbType.Int32, userId);
            db.ExecuteNonQuery(cmd);
        }


    }
}
