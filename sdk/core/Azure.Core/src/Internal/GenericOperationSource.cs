// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.Core
{
    internal class GenericOperationSource<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors | DynamicallyAccessedMemberTypes.NonPublicConstructors)] T> : IOperationSource<T> where T : IPersistableModel<T>
    {
        T IOperationSource<T>.CreateResult(Response response, CancellationToken cancellationToken)
            => CreateResult(response);

        ValueTask<T> IOperationSource<T>.CreateResultAsync(Response response, CancellationToken cancellationToken)
            => new ValueTask<T>(CreateResult(response));

        private T CreateResult(Response response)
#pragma warning disable AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
            // use this will never be a collection so with the annotation this is safe
            // in the future we can consider how to pull in the right context for perf improvement
            => ModelReaderWriter.Read<T>(response.Content)!;
#pragma warning restore AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
    }
}
