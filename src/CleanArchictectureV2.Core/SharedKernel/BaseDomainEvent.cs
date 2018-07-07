using System;

namespace CleanArchitectureV2.Core.SharedKernel
{
    public abstract class BaseDomainEvent
    {
        public DateTime DateOccurred { get; protected set; } = DateTime.Now;
    }
}
