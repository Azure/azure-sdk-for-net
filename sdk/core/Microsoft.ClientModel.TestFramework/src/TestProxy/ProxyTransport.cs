// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Threading.Tasks;

/// <summary>
/// TODO.
/// </summary>
public class ProxyTransport : PipelineTransport
{
    /// <inheritdoc/>
    protected override PipelineMessage CreateMessageCore()
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    protected override void ProcessCore(PipelineMessage message)
    {
        throw new System.NotImplementedException();
    }

    /// <inheritdoc/>
    protected override ValueTask ProcessCoreAsync(PipelineMessage message)
    {
        throw new System.NotImplementedException();
    }
}