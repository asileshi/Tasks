using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

enum TaskCategory
{
    Personal,
    Work,
    Errands
}

class TaskItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
}

class TaskManager
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private const string filePath = "tasks.csv";

    public async Task LoadTasksAsync()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        string[] taskFields = line.Split(',');
                       
                        TaskItem newTaskItem = new TaskItem
                        {
                            Name = taskFields[0],
                            Description = taskFields[1],
                            Category = (TaskCategory)Enum.Parse(typeof(TaskCategory), taskFields[2]),
                            IsCompleted = bool.Parse(taskFields[3])
                        };

                        tasks.Add(newTaskItem);
                        
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error loading tasks: {e.Message}");
        }
    }

    public async Task SaveTasksAsync()
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (TaskItem task in tasks)
                {
                    await writer.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving tasks: {e.Message}");
        }
    }

    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

    public void ViewTasks(TaskCategory category)
    {
        var filteredtasks = tasks.Where(task => task.Category == category);
        foreach (var task in filteredtasks)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Category: {task.Category}");
            Console.WriteLine($"Completed: {task.IsCompleted}");
        }
    }
}

class Program
{
    static async Task Main(string[] args)
    {
        TaskManager taskManager = new TaskManager();

        try
        {
            await taskManager.LoadTasksAsync();

            // Example: Adding a task using object initializers
            taskManager.AddTask(new TaskItem
            {
                Name = "Eat Lunch",
                Description = "Enjoing lunch",
                Category = TaskCategory.Personal,
                IsCompleted = false
            });

            // View tasks by category (using lambda expression)
            TaskCategory selectedCategory = TaskCategory.Personal;
            taskManager.ViewTasks(selectedCategory);

            // Save tasks to file
            await taskManager.SaveTasksAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred: {e.Message}");
        }
    }
}
