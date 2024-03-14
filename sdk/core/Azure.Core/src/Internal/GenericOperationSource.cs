﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class GenericOperationSource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : IOperationSource<T> where T : notnull
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private T CreateResult(Response response)
            => (T)ModelReaderWriter.Read(response.Content, typeof(T))!;
    }
}
