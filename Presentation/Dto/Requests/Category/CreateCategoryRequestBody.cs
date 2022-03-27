using System.ComponentModel.DataAnnotations;

namespace wms.Dto.Requests.Category;

public class CreateCategoryRequestBody
{
    [Required] public string Id { get; set; }

    [Required] public string Name { get; set; }
}