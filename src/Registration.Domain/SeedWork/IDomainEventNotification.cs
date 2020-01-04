using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.SeedWork
{
    public interface IDomainEventNotification<out TEventType>
    {
        TEventType DomainEvent { get; }
    }
}
