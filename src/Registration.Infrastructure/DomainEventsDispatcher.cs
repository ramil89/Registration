using Autofac;
using Autofac.Core;
using MediatR;
using Newtonsoft.Json;
using Registration.Domain.SeedWork;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Infrastructure
{
    public class DomainEventsDispatcher : IDomainEventsDispatcher
    {
        private readonly IMediator _mediator;
        private readonly CustomerContext _customerContext;
        private readonly ILogger _logger;

        public DomainEventsDispatcher(IMediator mediator, ILogger logger, CustomerContext customerContext)
        {
            this._mediator = mediator;
            this._customerContext = customerContext;
            this._logger = logger;
        }

        public async Task DispatchEventsAsync()
        {
            var domainEntities = this._customerContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    _logger.Information("Domain event {@data}", domainEvent);

                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }
}
