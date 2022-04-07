using Application.Commands.Manufacturers.CreateManufacturer;
using Application.Queries.Manufacturers;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using wms.Dto.Common;
using wms.Dto.Common.Responses;
using wms.Dto.Manufacturers;

namespace wms.Controllers.Api;

public class ManufacturersController : ApiControllerBase
{
    public ManufacturersController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
    {
    }

    [HttpPost]
    public async Task<ActionResult<BaseResponse<ManufacturerViewModel>>> CreateManufacturer(CreateManufacturerRequest request)
    {
        var result = await Mediator.Send(Mapper.Map<CreateManufacturerCommand>(request));

        var manufacturer = await Mediator.Send(new GetManufacturerQuery
        {
            Id = result
        });

        return Ok(manufacturer.ToViewModel<ManufacturerViewModel>(Mapper));
    }

    [HttpGet]
    public async Task<ActionResult<BaseResponse<IEnumerable<ManufacturerViewModel>>>> GetManufacturers()
    {
        var manufacturers = await Mediator.Send(new GetAllManufacturersQuery());

        return Ok(manufacturers.ToViewModels<ManufacturerViewModel>(Mapper));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<BaseResponse<ManufacturerViewModel>>> GetManufacturer(int id)
    {
        var manufacturers = await Mediator.Send(new GetManufacturerQuery
        {
            Id = id
        });

        return Ok(manufacturers.ToViewModel<ManufacturerViewModel>(Mapper));
    }
}