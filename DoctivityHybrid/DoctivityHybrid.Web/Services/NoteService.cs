using DoctivityHybrid.Shared.Dtos;
using DoctivityHybrid.Shared.Services;

namespace DoctivityHybrid.Web.Services
{
    public class NoteService : INoteService
    {
        public async Task<MethodResult<NoteModel>> CreateNoteAsync(NoteModel note, int userId)
        {
            var createdNote = new NoteModel
            {
                Id = 1,
                Title = note.Title,
                Content = note.Content,
                UpdatedAt = DateTime.UtcNow
            };
            return MethodResult<NoteModel>.Success(createdNote);
        }

        public async Task<List<NoteModel>> GetNotesAsync()
        {
            var notes = new List<NoteModel>
            {
                new NoteModel { Id = 1, Title = "Note 1", Content = "Content 1", UpdatedAt = DateTime.UtcNow },
                new NoteModel { Id = 2, Title = "Note 2", Content = "Content 2", UpdatedAt = DateTime.UtcNow }
            };
            return notes;
        }
    }
}
