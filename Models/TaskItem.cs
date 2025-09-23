using System.ComponentModel.DataAnnotations;

namespace LearnKing.Api.Models;

public class TaskItem
{
    public int Id { get; set; }

    [Required, StringLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public TaskStatus Status { get; set; } = TaskStatus.Todo;

    public DateTime? DueDate { get; set; }

    public DateTime CreatedAt { get; set; }
}

public enum TaskStatus
{
    Todo = 0,
    InProgress = 1,
    Done = 2
}