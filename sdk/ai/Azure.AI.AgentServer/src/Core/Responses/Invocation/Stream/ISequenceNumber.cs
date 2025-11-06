using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

/// <summary>
/// Defines a sequence number generator for tracking event order.
/// </summary>
public interface ISequenceNumber
{
    /// <summary>
    /// Gets an atomic sequence number generator that uses thread-safe operations.
    /// </summary>
    public static sealed ISequenceNumber Atomic => new AtomicSequenceNumber();

    /// <summary>
    /// Gets a default sequence number generator.
    /// </summary>
    public static sealed ISequenceNumber Default => new DefaultSequenceNumber();

    /// <summary>
    /// Gets the current sequence number without incrementing.
    /// </summary>
    /// <returns>The current sequence number.</returns>
    int Current();

    /// <summary>
    /// Gets the current sequence number and increments it.
    /// </summary>
    /// <returns>The current sequence number before increment.</returns>
    int Next();
}

/// <summary>
/// Default implementation of sequence number generator.
/// </summary>
public class DefaultSequenceNumber : ISequenceNumber
{
    private volatile int _sequenceNumber = 0;

    /// <summary>
    /// Gets the current sequence number without incrementing.
    /// </summary>
    /// <returns>The current sequence number.</returns>
    public int Current() => _sequenceNumber;

    /// <summary>
    /// Gets the current sequence number and increments it.
    /// </summary>
    /// <returns>The current sequence number before increment.</returns>
    [SuppressMessage("ReSharper", "NonAtomicCompoundOperator")]
    public int Next() => _sequenceNumber++;
}

/// <summary>
/// Thread-safe atomic implementation of sequence number generator.
/// </summary>
public class AtomicSequenceNumber : ISequenceNumber
{
    private volatile int _sequenceNumber = 0;

    /// <summary>
    /// Gets the current sequence number without incrementing.
    /// </summary>
    /// <returns>The current sequence number.</returns>
    public int Current() => _sequenceNumber;

    /// <summary>
    /// Gets the current sequence number and increments it atomically.
    /// </summary>
    /// <returns>The current sequence number before increment.</returns>
    public int Next() => Interlocked.Increment(ref _sequenceNumber) - 1;
}
