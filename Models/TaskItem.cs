using System;
using System.ComponentModel.DataAnnotations;

namespace LearnKing.Api.Models
{
    public enum TaskStatus
    {
        Pending = 0,
        Completed = 1
    }

    public class TaskItem
    {
        public int Id { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        public string? Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DueDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // ✅ bool cho dễ dùng
        public bool IsCompleted { get; set; } = false;

        // ✅ Enum để quản lý trạng thái
        public TaskStatus Status { get; set; } = TaskStatus.Pending;
    }
}
