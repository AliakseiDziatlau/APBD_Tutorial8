using APBD_Tutorial8.Infrastructure.DTOs;
using MediatR;

namespace APBD_Tutorial8.Application.Queries.ClientQueries;

public class GetClientsTripsByIdQuery : IRequest<IEnumerable<ClientsTripDto>>
{
    public int ClientId { get; set; }
}