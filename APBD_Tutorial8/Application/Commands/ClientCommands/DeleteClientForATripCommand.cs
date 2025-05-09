using MediatR;

namespace APBD_Tutorial8.Application.Commands.ClientCommands;

public class DeleteClientForATripCommand : IRequest<(bool Success, string Message)>
{
    public int ClientId { get; set; }
    public int TripId { get; set; }
}