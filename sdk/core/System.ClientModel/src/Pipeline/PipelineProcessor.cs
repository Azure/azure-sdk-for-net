// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

// TODO: perf tradeoff between a struct you only ever call methods on through
// the interface it implements vs. an abstract class you have to allocate every time?
public abstract class PipelineProcessor
{
    public abstract bool ProcessNext();

    public abstract ValueTask<bool> ProcessNextAsync();
}
