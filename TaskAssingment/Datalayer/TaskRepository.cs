using Task = Core.BusinessObject.Task;
using Datalayer;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace DataLayer
{
    public class TaskRepository
    {
        /// <summary>
        /// Method to get list of all tasks
        /// </summary>
        /// <returns></returns>
        public static List<Task> GetAll()
        {
            List<Task> taskList = new List<Task>();
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"SELECT task_id, title, description, due_date, status, remarks, 
                                                     created_on, created_by_id, created_by_name, 
                                                     updated_on, updated_by_id, updated_by_name,
                                                     assigned_user_ids FROM tasks");

            using (var reader = db.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    taskList.Add(new Task
                    {
                        TaskId = Convert.ToInt32(reader["task_id"]),
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
                        AssignedUserIds = reader["assigned_user_ids"] == DBNull.Value ? null : Convert.ToString(reader["assigned_user_ids"])
                    });
                }
            }
            return taskList;
        }
        /// <summary>
        /// Method to get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Task GetById(int id)
        {
            Task task = null;
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"SELECT task_id, title, description, due_date, status, remarks, 
                                                     created_on, created_by_id, created_by_name, 
                                                     updated_on, updated_by_id, updated_by_name,
                                                     assigned_user_ids FROM tasks WHERE task_id = @taskId");

            db.AddInParameter(cmd, "taskId", DbType.Int32, id);

            using (var reader = db.ExecuteReader(cmd))
            {
                if (reader.Read())
                {
                    task = new Task
                    {
                        TaskId = Convert.ToInt32(reader["task_id"]),
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
                        AssignedUserIds = reader["assigned_user_ids"] == DBNull.Value ? null : Convert.ToString(reader["assigned_user_ids"])
                    };
                }
            }
            return task;
        }
        /// <summary>
        /// Method to add new task
        /// </summary>
        /// <param name="task"></param>
        public static void Add(Task task)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"INSERT INTO tasks 
                (title, description, due_date, status, remarks, created_on, created_by_id, created_by_name, updated_on, updated_by_id, updated_by_name, assigned_user_ids) 
                VALUES 
                (@title, @description, @dueDate, @status, @remarks, @createdOn, @createdById, @createdByName, @updatedOn, @updatedById, @updatedByName, @assignedUserIds)");

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
            db.AddInParameter(cmd, "assignedUserIds", DbType.String, task.AssignedUserIds);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Method to update task
        /// </summary>
        /// <param name="task"></param>
        public static void Update(Task task)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand(@"UPDATE tasks SET 
                title = @title,
                description = @description,
                due_date = @dueDate,
                status = @status,
                remarks = @remarks,
                updated_on = @updatedOn,
                updated_by_id = @updatedById,
                updated_by_name = @updatedByName,
                assigned_user_ids = @assignedUserIds
                WHERE task_id = @taskId");

            db.AddInParameter(cmd, "taskId", DbType.Int32, task.TaskId);
            db.AddInParameter(cmd, "title", DbType.String, task.Title);
            db.AddInParameter(cmd, "description", DbType.String, task.Description);
            db.AddInParameter(cmd, "dueDate", DbType.DateTime, task.DueDate);
            db.AddInParameter(cmd, "status", DbType.Int32, task.Status);
            db.AddInParameter(cmd, "remarks", DbType.String, task.Remarks);
            db.AddInParameter(cmd, "updatedOn", DbType.DateTime, task.UpdatedOn);
            db.AddInParameter(cmd, "updatedById", DbType.Int32, task.UpdatedById);
            db.AddInParameter(cmd, "updatedByName", DbType.String, task.UpdatedByName);
            db.AddInParameter(cmd, "assignedUserIds", DbType.String, task.AssignedUserIds);

            db.ExecuteNonQuery(cmd);
        }
        /// <summary>
        /// Method to delete task
        /// </summary>
        /// <param name="id"></param>
        public static void Delete(int id)
        {
            Database db = ConnectionFactory.CreateDataBase();
            DbCommand cmd = db.GetSqlStringCommand("DELETE FROM tasks WHERE task_id = @id");
            db.AddInParameter(cmd, "id", DbType.Int32, id);
            db.ExecuteNonQuery(cmd);
        }
    }
}
