
using System.ComponentModel.DataAnnotations;

namespace DoctivityHybrid.Shared.Dtos
{
    public record MethodResult(bool IsSuccess, string? Message)
    {
        public static MethodResult Success() => new(true, null);
        public static MethodResult Failure(string message) => new(false, message);
    }


    public record MethodResult<TData>(bool IsSuccess, TData data, string? Message)
    {
        public static MethodResult<TData> Success(TData data) => new(true, data, null);
        public static MethodResult<TData> Failure(string message) => new(false, default, message);
    }


    public record LoggedInUser(int UserId, string Username);

    public class NoteModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
