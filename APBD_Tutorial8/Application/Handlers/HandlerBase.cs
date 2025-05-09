using APBD_Tutorial8.Domain.Interfaces;
using AutoMapper;

namespace APBD_Tutorial8.Application.Handlers;

public abstract class HandlerBase
{
    protected readonly IClientRepository _clientRepository;
    protected readonly ITripRepository _tripRepository;
    protected readonly ICountryRepository _countryRepository;

    public HandlerBase(
        IClientRepository clientRepository,
        ITripRepository tripRepository,
        ICountryRepository countryRepository)
    {
        _clientRepository = clientRepository;
        _tripRepository = tripRepository;
        _countryRepository = countryRepository;
    }
}