﻿using Application.Common.Mappings;
using Domain.Entities;
using wms.Dto.Common;

namespace wms.Dto.StoragePlaces;

public class StoragePlaceViewModel : IViewModel, IMapFrom<StoragePlace>
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public Warehouse? Warehouse { get; set; }

    public StoragePlace? Container { get; set; }
    
    public bool HasContainer { get; set; }
}