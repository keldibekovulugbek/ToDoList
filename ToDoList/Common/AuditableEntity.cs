﻿namespace FileBaseContext.Abstractions.Common;

public abstract class AuditableEntity : Entity, IAuditableEntity
{
    public DateTimeOffset CreatedDate { get; set; }
    
    public DateTimeOffset? ModifiedDate { get; set; }
}
