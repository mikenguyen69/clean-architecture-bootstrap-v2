using CleanArchitectureV2.Core.SharedKernel;

namespace CleanArchitectureV2.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}
