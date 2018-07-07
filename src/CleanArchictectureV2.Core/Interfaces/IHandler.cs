using CleanArchitectureV2.Core.SharedKernel;

namespace CleanArchitectureV2.Core.Interfaces
{
    public interface IHandler<T> where T: BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}
