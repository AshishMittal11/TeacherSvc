using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeacherSvc.Api.Database;
using TeacherSvc.Api.Models;

namespace TeacherSvc.Api.CQRS.Command.CommandHandler
{
    public class TeacherRegisterCommandHandler : IRequestHandler<TeacherRegisterCommand, bool>
    {
        private readonly ILogger<TeacherRegisterCommandHandler> _logger;
        private readonly TeacherContext _context;

        public TeacherRegisterCommandHandler(ILogger<TeacherRegisterCommandHandler> logger, TeacherContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<bool> Handle(TeacherRegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dbTeacher = request.Teacher.Adapt<Teacher>();
                await _context.TeacherSet.AddAsync(dbTeacher).ConfigureAwait(false);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message, request);
                throw; 
            } 
        }
    }
}
