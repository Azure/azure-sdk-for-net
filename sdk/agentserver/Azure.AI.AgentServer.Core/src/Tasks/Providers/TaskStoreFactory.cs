// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.AI.AgentServer.Core.Tasks.Providers;

internal sealed class TaskStoreFactory
{
    private readonly Func<(ITaskStore Store, bool Owned)> _factory;

    public TaskStoreFactory(Func<(ITaskStore Store, bool Owned)> factory)
    {
        _factory = factory;
    }

    public ITaskStore Create(out bool owned)
    {
        (ITaskStore Store, bool Owned) created = _factory();
        owned = created.Owned;
        return created.Store;
    }
}
