using MediatR;

namespace APBD_Tutorial8.Application.Commands.ClientCommands;

public class CreateClientCommand : IRequest<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Pesel { get; set; }
}