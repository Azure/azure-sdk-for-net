// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

#pragma warning disable CS1591 // public XML comments
public class ClientResultExceptionFactory
{
    public static ClientResultExceptionFactory Default { get; } = new();

    public virtual ClientResultException FromResponse(PipelineResponse response)
        => new ClientResultException(response);

    public virtual Task<ClientResultException> FromResponseAsync(PipelineResponse response)
        => ClientResultException.CreateAsync(response);
}
#pragma warning restore CS1591 // public XML comments
