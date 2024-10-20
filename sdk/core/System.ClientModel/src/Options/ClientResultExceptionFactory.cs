// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;

namespace System.ClientModel.Primitives;

//#pragma warning disable CS1591 // public XML comments
//internal class ClientResultExceptionFactory
//{
//    public static ClientResultExceptionFactory Default { get; } = new();

//    public virtual ClientResultException Create(PipelineResponse response)
//    {
//        response.BufferContent();

//        if (TryGetMessage(response, out string? message))
//        {
//            return new ClientResultException(message!, response);
//        }

//        return new ClientResultException(response);
//    }

//    public virtual async Task<ClientResultException> CreateAsync(PipelineResponse response)
//    {
//        await response.BufferContentAsync().ConfigureAwait(false);

//        if (TryGetMessage(response, out string? message))
//        {
//            return new ClientResultException(message!, response);
//        }

//        return new ClientResultException(response);
//    }

//    public virtual bool TryGetMessage(PipelineResponse response, out string? message)
//    {
//        message = null;
//        return false;
//    }
//}
//#pragma warning restore CS1591 // public XML comments
