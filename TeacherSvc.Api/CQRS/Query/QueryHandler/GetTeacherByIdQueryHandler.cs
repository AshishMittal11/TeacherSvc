using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TeacherSvc.Api.Database;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query.QueryHandler
{
    public class GetTeacherByIdQueryHandler : IRequestHandler<GetTeacherByIdQuery, TeacherDto>
    {
        private readonly ILogger<GetTeacherByIdQueryHandler> _logger;
        private readonly TeacherContext _context;

        public GetTeacherByIdQueryHandler(ILogger<GetTeacherByIdQueryHandler> logger, TeacherContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<TeacherDto> Handle(GetTeacherByIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dbTeacher = await this._context.TeacherSet.FirstOrDefaultAsync(x=>x.Id == request.TeacherId).ConfigureAwait(false);
                return dbTeacher == null ? new TeacherDto() : dbTeacher.Adapt<TeacherDto>();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, request);
                throw;
            }
        }
    }
}
