using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TeacherSvc.Api.Database;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query.QueryHandler
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, List<TeacherDto>>
    {
        private readonly ILogger<GetAllTeachersQueryHandler> _logger;
        private readonly TeacherContext _context;

        public GetAllTeachersQueryHandler(ILogger<GetAllTeachersQueryHandler> logger, TeacherContext context)
        {
            this._logger = logger;
            this._context = context;
        }

        public async Task<List<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dbTeachers = await _context.TeacherSet.ToListAsync().ConfigureAwait(false);
                return dbTeachers?.Adapt<List<TeacherDto>>() ?? new List<TeacherDto>();
            }
            catch(Exception ex)
            {
                this._logger.LogError(ex.Message, request);
                throw;
            } 
        }
    }
}
