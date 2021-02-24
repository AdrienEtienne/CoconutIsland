using System.Collections.Generic;
using MediatR;

namespace CoconutIsland.Structure.Builder
{
    public class Director
    {
        private readonly AddDomainEventDelegate _addDomainEventDelegate;

        private readonly ClearDomainEventsDelegate _clearDomainEventsDelegate;

        private readonly List<INotification> _domainEvents = new();

        private readonly RemoveDomainEventDelegate _removeDomainEventDelegate;

        public Director()
        {
            _addDomainEventDelegate = notification => _domainEvents.Add(notification);
            _removeDomainEventDelegate = notification => _domainEvents.Remove(notification);
            _clearDomainEventsDelegate = () => _domainEvents.Clear();
        }

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public T Build<T>(Builder<T> builder) where T : Product
        {
            var product = builder.GetProduct();

            product.AddDomainEventDelegate = _addDomainEventDelegate;
            product.RemoveDomainEventDelegate = _removeDomainEventDelegate;
            product.ClearDomainEventsDelegate = _clearDomainEventsDelegate;

            return product;
        }

        internal delegate void AddDomainEventDelegate(INotification notification);

        internal delegate void RemoveDomainEventDelegate(INotification notification);

        internal delegate void ClearDomainEventsDelegate();
    }
}