using MediatR;

namespace TeacherSvc.Api.CQRS.Command
{
    public class DeleteTeacherCommand : IRequest<bool>
    {
        public int Id { get; set; } 
    }
}
