using System.Threading.Tasks;
using Core.BusinessObject;
using TaskManagerWebApp.DataLayer;

namespace ServiceLayer
{
    public class AssignedTaskService
    {
        /// <summary>
        /// Method to get all the assigned tasks
        /// </summary>
        /// <returns></returns>
        public List<AssignedTask> GetAll()
        {
            return AssignedTaskRepository.GetAll();
        }
        /// <summary>
        /// method to get tasklist by taskid
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public List<AssignedTask> GetByTaskId(int taskId)
        {
            return AssignedTaskRepository.GetByTaskId(taskId);
        }
        /// <summary>
        /// method to get tasklist by userid
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<AssignedTask> GetByUserId(int userId)
        {
            return AssignedTaskRepository.GetByUserId(userId);
        }
        /// <summary>
        /// Method to add assigned task
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="ArgumentException"></exception>
        public void Add(AssignedTask task)
        {
            if (task != null)
                AssignedTaskRepository.Add(task);
        }
        /// <summary>
        /// Method to update assigned task status
        /// </summary>
        /// <param name="task"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Update(AssignedTask task)
        {
            if (task != null)
                AssignedTaskRepository.Update(task);
        }
        /// <summary>
        /// method to delete task by taskid
        /// </summary>
        /// <param name="taskId"></param>
        public void DeleteByTaskId(int taskId)
        {
            if (taskId != default(int))
                AssignedTaskRepository.DeleteByTaskId(taskId);
        }
        /// <summary>
        /// method to delete task by taskid and userid
        /// </summary>
        /// <param name="taskid"></param>
        /// <param name="userid"></param>
        public void DeleteByTaskIdAndUserId(int taskid,int userid)
        {
            if (taskid != default(int) && userid != default(int))
                AssignedTaskRepository.DeleteByTaskIdAndUserId(taskid,userid);
        }
    }
}
