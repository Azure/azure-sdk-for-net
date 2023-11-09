// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.Net.ClientModel.Core;

public abstract class PipelinePolicy
{
    public abstract void Process(PipelineMessage message, PipelineProcessor pipeline);

    public abstract ValueTask ProcessAsync(PipelineMessage message, PipelineProcessor pipeline);
}
