using System;
using System.Collections.Generic;
using System.Text;

namespace Registration.Domain.SeedWork
{
    public class DomainEventBase: IDomainEvent
    {
        public DomainEventBase()
        {
            OccurredOn = DateTime.Now;
        }

        public DateTime OccurredOn { get; }
    }
}
