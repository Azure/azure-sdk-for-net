// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ServiceModel.Rest.Core;

// TODO: can we make it a class? ... but it means all existing polices need to inherit from it.
public interface IPipelinePolicy<TMessage>
{
    void Process(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline);

    ValueTask ProcessAsync(TMessage message, ReadOnlyMemory<IPipelinePolicy<TMessage>> pipeline);
}
