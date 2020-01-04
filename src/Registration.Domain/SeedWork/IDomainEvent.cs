using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace Registration.Domain.SeedWork
{
    public interface IDomainEvent: INotification
    {
        DateTime OccurredOn { get; }
    }
}
