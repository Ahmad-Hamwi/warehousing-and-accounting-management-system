using Application.Commands.Manufacturers;
using Application.Common.Mappings;

namespace wms.Dto.Manufacturers;

public class CreateManufacturerRequest : IMapFrom<CreateManufacturerCommand>
{
    public string Name { get; set; }
    
    public string? Code { get; set; }
}