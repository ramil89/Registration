using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Registration.Domain.SeedWork;

namespace Registration.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CustomerContext _customerContext; 
        private readonly IDomainEventsDispatcher _domainEventsDispatcher;

        public UnitOfWork(
            CustomerContext customerContext,
            IDomainEventsDispatcher domainEventsDispatcher)
        {
            this._customerContext = customerContext;
            this._domainEventsDispatcher = domainEventsDispatcher;
        }

        public async Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            await this._domainEventsDispatcher.DispatchEventsAsync();
            return await this._customerContext.SaveChangesAsync(cancellationToken);
        }
    }
}
