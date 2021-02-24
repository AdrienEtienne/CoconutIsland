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
            this._addDomainEventDelegate = notification => this._domainEvents.Add(notification);
            this._removeDomainEventDelegate =
                notification => this._domainEvents.Remove(notification);
            this._clearDomainEventsDelegate = () => this._domainEvents.Clear();
        }


        public IReadOnlyCollection<INotification> DomainEvents => this._domainEvents.AsReadOnly();


        public T Build<T>(Builder<T> builder) where T : Product
        {
            var product = builder.GetProduct();

            product.AddDomainEventDelegate = this._addDomainEventDelegate;
            product.RemoveDomainEventDelegate = this._removeDomainEventDelegate;
            product.ClearDomainEventsDelegate = this._clearDomainEventsDelegate;

            return product;
        }


        internal delegate void AddDomainEventDelegate(INotification notification);

        internal delegate void RemoveDomainEventDelegate(INotification notification);

        internal delegate void ClearDomainEventsDelegate();
    }
}