using System.Collections.Generic;
using MediatR;

namespace CoconutIsland.Structure.Builder
{
    public class Director
    {
        private AddDomainEventDelegate _addDomainEventDelegate;

        internal delegate void AddDomainEventDelegate(INotification notification);

        private RemoveDomainEventDelegate _removeDomainEventDelegate;

        internal delegate void RemoveDomainEventDelegate(INotification notification);

        private ClearDomainEventsDelegate _clearDomainEventsDelegate;

        internal delegate void ClearDomainEventsDelegate();

        private List<INotification> _domainEvents = new List<INotification>();

        public IReadOnlyCollection<INotification> DomainEvents => _domainEvents.AsReadOnly();

        public Director()
        {
            _addDomainEventDelegate = notification => _domainEvents.Add(notification);
            _removeDomainEventDelegate = notification => _domainEvents.Remove(notification);
            _clearDomainEventsDelegate = () => _domainEvents.Clear();
        }

        public T Build<T>(Builder<T> builder) where T : Product
        {
            var product = builder.GetProduct();

            product.AddDomainEventDelegate = _addDomainEventDelegate;
            product.RemoveDomainEventDelegate = _removeDomainEventDelegate;
            product.ClearDomainEventsDelegate = _clearDomainEventsDelegate;

            return product;
        }
    }
}