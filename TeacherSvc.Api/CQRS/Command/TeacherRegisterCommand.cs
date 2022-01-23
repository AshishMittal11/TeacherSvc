using MediatR;
using TeacherSvc.Api.DTO;

namespace TeacherSvc.Api.CQRS.Command
{
    public class TeacherRegisterCommand : IRequest<bool>
    {
        public TeacherDto Teacher { get; set; }
    }
}
