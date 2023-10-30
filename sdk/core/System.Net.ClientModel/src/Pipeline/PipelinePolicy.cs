// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

public abstract class PipelinePolicy
{
    public abstract void Process(ClientMessage message, PipelineEnumerator pipeline);

    public abstract ValueTask ProcessAsync(ClientMessage message, PipelineEnumerator pipeline);
}
