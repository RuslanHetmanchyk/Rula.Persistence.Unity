using System;
using Rula.Persistence.Abstractions;

public sealed class UnityClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}