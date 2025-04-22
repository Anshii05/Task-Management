using DataLayer;
using Task = Core.BusinessObject.Task;

namespace ServiceLayer
{
    public class TaskService
    {
        /// <summary>
        /// Method to get all the tasks
        /// </summary>
        /// <returns></returns>
        public List<Task> GetAll()
        {
            return TaskRepository.GetAll();
        }
        /// <summary>
        /// Method to get task by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task GetById(int id)
        {
            return TaskRepository.GetById(id);
        }
        /// <summary>
        /// Method to add task
        /// </summary>
        /// <param name="task"></param>
        public void Add(Task task)
        {
            if (task != null)
                TaskRepository.Add(task);
        }
        /// <summary>
        /// Method to update task
        /// </summary>
        /// <param name="task"></param>
        public void Update(Task task)
        {
            if (task != null)
                TaskRepository.Update(task);
        }
        /// <summary>
        /// Method to delete task
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {
            if (id != default(int))
                TaskRepository.Delete(id);
        }
    }
}
