using DoctivityHybrid.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

namespace DoctivityHybrid.Web.Data.Entities
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public string Email { get; set; }

    }
    public class DbNoteModel
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public virtual LoggedInUser User { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
