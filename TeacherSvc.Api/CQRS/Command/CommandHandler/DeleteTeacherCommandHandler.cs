using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeacherSvc.Api.Database;
using Microsoft.EntityFrameworkCore;

namespace TeacherSvc.Api.CQRS.Command.CommandHandler
{
    public class DeleteTeacherCommandHandler : IRequestHandler<DeleteTeacherCommand, bool>
    {
        private readonly ILogger<DeleteTeacherCommandHandler> _logger;
        private readonly TeacherContext _context;

        public DeleteTeacherCommandHandler(ILogger<DeleteTeacherCommandHandler> logger, TeacherContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<bool> Handle(DeleteTeacherCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dbTeacher = await _context.TeacherSet.FirstOrDefaultAsync(x => x.Id == request.Id).ConfigureAwait(false);  
                if(dbTeacher != null)
                {
                    _context.TeacherSet.Remove(dbTeacher);
                    await _context.SaveChangesAsync().ConfigureAwait(false);
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message, request);
                throw;
            } 
        }
    }
}
