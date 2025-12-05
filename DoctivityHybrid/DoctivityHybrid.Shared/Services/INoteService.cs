using DoctivityHybrid.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace DoctivityHybrid.Shared.Services
{
    public interface INoteService
    {
        Task<MethodResult<NoteModel>> CreateNoteAsync(NoteModel note, int userId);
        Task<List<NoteModel>> GetNotesAsync();

    }
}
