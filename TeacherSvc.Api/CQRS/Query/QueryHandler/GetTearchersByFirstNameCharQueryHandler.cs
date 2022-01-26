using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TeacherSvc.Api.Database;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Query.QueryHandler
{
    public class GetTearchersByFirstNameCharQueryHandler : IRequestHandler<GetTearchersByFirstNameCharQuery, List<TeacherDto>>
    {
        private readonly ILogger<GetTeacherByIdQueryHandler> _logger;
        private readonly TeacherContext _context;

        public GetTearchersByFirstNameCharQueryHandler(
            ILogger<GetTeacherByIdQueryHandler> logger,
            TeacherContext context)
        {
            this._logger = logger;
            this._context = context;
        }


        public async Task<List<TeacherDto>> Handle(GetTearchersByFirstNameCharQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var dbTeachers = await this._context.TeacherSet.Where(x => x.FirstName.StartsWith(request.FirstNameChar, StringComparison.OrdinalIgnoreCase)).ToListAsync();
                return dbTeachers?.Adapt<List<TeacherDto>>() ?? new List<TeacherDto>();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex.Message, request);
                throw;
            }
        }
    }
}
