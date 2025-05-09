using APBD_Tutorial8.Infrastructure.DTOs;
using MediatR;

namespace APBD_Tutorial8.Application.Queries.TripQueries;

public class GetTripsQuery : IRequest<IEnumerable<TripDto>> { }