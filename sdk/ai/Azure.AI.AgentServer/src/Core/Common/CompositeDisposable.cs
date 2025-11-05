using System;
using System.Linq;

namespace Azure.AI.AgentServer.Core.Common;

public class CompositeDisposable : IDisposable
{
    private readonly IDisposable[] _disposables;

    public CompositeDisposable(params IDisposable?[] disposables)
    {
        _disposables = disposables.Where(d => d != null).ToArray()!;
    }

    public void Dispose()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
