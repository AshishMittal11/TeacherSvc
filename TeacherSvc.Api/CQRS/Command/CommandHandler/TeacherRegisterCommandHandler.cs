using Mapster;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            using (var trans = _context.Database.BeginTransaction())
            {
                try
                {
                    var dbTeacher = request.Teacher.Adapt<Teacher>();
                    await _context.TeacherSet.AddAsync(dbTeacher).ConfigureAwait(false);
                    await _context.SaveChangesAsync().ConfigureAwait(false);

                    // saving the qualifications of a teacher.....
                    List<Qualification> qualifications = new List<Qualification>();
                    foreach (var qualification in request.Teacher.Qualifications)
                    {
                        var dbQualification = qualification.Adapt<Qualification>();
                        dbQualification.TeacherId = dbTeacher.Id;
                        qualifications.Add(dbQualification);
                    }

                    if (qualifications.Count > 0)
                    {
                        await _context.QualificationSet.AddRangeAsync(qualifications).ConfigureAwait(false);
                        await _context.SaveChangesAsync().ConfigureAwait(false);
                    }

                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    this._logger.LogError(ex.Message, request);
                    throw;
                }
            }
        }
    }
}
