using MediatR;

namespace CoconutIsland.Structure.Builder
{
    public abstract class Product
    {
        internal Director.AddDomainEventDelegate? AddDomainEventDelegate { get; set; }
        internal Director.RemoveDomainEventDelegate? RemoveDomainEventDelegate { get; set; }
        internal Director.ClearDomainEventsDelegate? ClearDomainEventsDelegate { get; set; }


        protected void AddDomainEvent(INotification notification)
        {
            this.AddDomainEventDelegate?.Invoke(notification);
        }


        protected void RemoveDomainEvent(INotification notification)
        {
            this.RemoveDomainEventDelegate?.Invoke(notification);
        }


        protected void ClearDomainEvents()
        {
            this.ClearDomainEventsDelegate?.Invoke();
        }
    }
}