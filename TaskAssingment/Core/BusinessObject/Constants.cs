namespace Core.BusinessObject
{
    public class Constants
    {
        /// <summary>
        /// Constants for status of assigned tasks
        /// </summary>
        public enum TaskStatus
        {
            NotStarted = 0,
            InProgress = 1,
            Completed = 2
        }
        /// <summary>
        /// Constants for user type
        /// </summary>
        public enum Type
        {
            admin = 0,
            user = 1
        }
        
    }    
}

