1. Overview
A web-based task management system built with ASP.NET Core Razor Pages and MySQL, designed to streamline task assignment and tracking within organizations.
Key Features:
-Task Creation & Editing: Admins can create and update detailed tasks.
-Multi-User Assignment: Tasks can be assigned to multiple users.
-Status Management: Users update task status (e.g., Not Started, In Progress, Completed).
-User-wise Task View: Admins can view task status per user.
-Secure Authentication: Login via email and password.
-Role-Based Access Control:
-Admin: Full access to manage tasks and users.
-User: Limited to their own tasks.


2. Explanation of DB Design
The application uses three main entities to manage users and tasks effectively:
-users
 Purpose: Stores user info and roles.
 Key Fields: user_id, email, password, type (Admin/User).
 Role: Handles secure login and role-based access.

-tasks
 Purpose: Master record of each task.
 Key Fields: task_id, title, description, due_date, status, assigned_user_ids.
 Role: Centralized task info; supports multiple assignees and progress tracking.

-assignedtasks
 Purpose: Links users and tasks (many-to-many).
 Key Fields: user_id, task_id, status, remarks.
 Role: Tracks task progress per user


2.1 Entity Relationship Diagram
![image](https://github.com/user-attachments/assets/3e00d781-873d-45b0-a422-b9f656b70845)
ER diagram image is provided in attached document.
This ER (Entity-Relationship) diagram represents a Task Management System
with entities and relationships among user, admin, task, and assignedtask. Here's
a breakdown of its components:
Entities and Attributes:
1. User
user_id (Primary Key), first_name, last_name, email, password, type
(admin or user)
2. Admin
Represent administrative users who manage tasks.
3. Task
task_id (Primary Key), title, description, due_date, status, created_by_id
(Foreign Key referencing user), remarks, assigned_user_id
4. AssignedTask
id (Primary Key), user_id (Foreign Key referencing user), task_id
(Foreign Key referencing task), title, due_date, status
6.relationships:
1. User <– creates –> Admin
o 1-to-1 relationship: Each admin is also a user, and each admin has a
user record.An admin can also create multiple users.
2. Admin – adds/updates –> Task
o One admin can add or update many tasks.
3. User – is assigned –> Task
o Many-to-Many (M:N) relationship:
▪ Each user can be assigned multiple tasks.
▪ Each task can be assigned to multiple users.
4. AssignedTask
o Acts as a bridge table to manage task assignments and track
individual user-task relations including status and due date.


2.2 Data Dictionary
![image](https://github.com/user-attachments/assets/3361c567-7de6-4637-b8ab-893ace305d17)
![image](https://github.com/user-attachments/assets/8152f166-11c4-4e29-89fb-e16e69405d60)
![image](https://github.com/user-attachments/assets/8ef840e9-440c-4c38-a75e-86e39e139ecb)


2.3 Whether Code first or DB First approach has been used and why?
In this project, we have used the Database First approach. This means that we
started by creating the database first through a script. After the database was
created, we generated the corresponding C# classes based on the existing tables.
This approach is typically used when there is an existing database or when
schema design is finalized beforehand. It provides a quicker and more accurate
way to align the application code with an established database.


3. Structure of the application
The app follows a 3-tier architecture for clean separation and scalability:
-Core Layer
 Contains model classes: User, Task, AssignedTask.
 Includes enums like TaskStatus.
 Maps directly to database tables.

-Data Layer (Repositories)
 Handles all DB operations (CRUD).
 Repositories: UserRepository, TaskRepository, AssignedTaskRepository.

-Service Layer (Business Logic)
 Coordinates between UI and data layer.
 Manages logic like assigning tasks, filtering by status, validating due dates, etc.

Benefits:
-Clean code structure
-Easier maintenance & testing
-Scalable & reusable logic
-Clear separation between UI, logic, and data


4. Frontend Structure
Frontend Technologies Used-
• HTML
Used to build the basic structure and layout of all the web pages. It defines
elements like headings, buttons, forms, and tables.
• CSS
Used to style the application and make it look visually appealing. It also
helps with responsive design, so the app works well on all screen sizes
(mobile, tablet, desktop).
• JavaScript
Adds interactivity and dynamic behavior to the pages — such as form
validations, modal popups, and real-time updates without refreshing the
page.
• Bootstrap
A frontend framework that helps design clean and responsive web pages
faster. It comes with pre-built components like buttons, forms, tables, and
modals, and it ensures the UI looks good on all devices. Bootstrap also
saves time by reducing the need to write custom CSS from scratch.


5. For running the provided code in your system:-
Step 1: Install Required Tools
• Install Visual Studio
o Make sure to select the .NET Desktop Development workload
during installation.
• Install MySQL Workbench
o Set up MySQL Server and use MySQL Workbench to manage the
database.

Step 2: Open the Project
• Download the ZIP folder containing the project files.
• Extract all files.
• Open the solution in Visual Studio.

Step 3: Set Up MySQL Database
• Create the database and tables in MySQL Workbench.
• Execute the provided SQL scripts to insert an admin user.

Insert user (as admin) query(type =0 for admin and type = 1 for user) :-
INSERT INTO `users` (
`first_name`, `last_name`, `email`, `password`, `type`, `created_on`,
`created_by`)
VALUES ('John', 'Doe', 'john.doe@example.com', '123456', '0', NOW(),
'System');
(All scripts are available in the Scripts folder inside the DataLayer project.)

Step 4: Configure the Connection String
• Open app.config.
• Update the connection string to match your MySQL server credentials.

Step 5: Install Dependencies
Use NuGet Package Manager to install the following packages:
• EnterpriseLibrary.Data.NetCore – for data access functionality.
• MySql.Data – for connecting to the MySQL database.

Step 6: Build and Run
• Build the project in Visual Studio.
• Run the application.
You should now be able to log in using the admin credentials added in the
database setup step.


Below is the link for full demo video of this web application:-
https://drive.google.com/drive/folders/1uxzGz4l5VW7WTRtnHBwqMa4rQs9_
mmkZ
