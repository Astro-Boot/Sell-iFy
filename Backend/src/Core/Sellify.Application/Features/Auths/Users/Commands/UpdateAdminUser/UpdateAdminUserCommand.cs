using MediatR;
using Sellify.Domain;

namespace Sellify.Application.Features.Auths.Users.Commands.UpdateAdminUser;

public class UpdateAdminUserCommand : IRequest<Usuario>
{

    public string? Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? Telefono { get; set; }

    public string? Role { get; set; }
}