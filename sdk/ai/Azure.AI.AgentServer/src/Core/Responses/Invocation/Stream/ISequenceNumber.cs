using System.Diagnostics.CodeAnalysis;

namespace Azure.AI.AgentServer.Responses.Invocation.Stream;

public interface ISequenceNumber
{
    public static sealed ISequenceNumber Atomic => new AtomicSequenceNumber();

    public static sealed ISequenceNumber Default => new DefaultSequenceNumber();

    int Current();

    int Next();
}

public class DefaultSequenceNumber : ISequenceNumber
{
    private volatile int _sequenceNumber = 0;

    public int Current() => _sequenceNumber;

    [SuppressMessage("ReSharper", "NonAtomicCompoundOperator")]
    public int Next() => _sequenceNumber++;
}

public class AtomicSequenceNumber : ISequenceNumber
{
    private volatile int _sequenceNumber = 0;

    public int Current() => _sequenceNumber;

    public int Next() => Interlocked.Increment(ref _sequenceNumber) - 1;
}
