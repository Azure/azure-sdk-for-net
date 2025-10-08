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
            // This call will never be invoked with a collection of models, so we can safely disable the warning
#pragma warning disable AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
#pragma warning disable IL3050 // This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.
#pragma warning disable IL2026 // This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.
            => ModelReaderWriter.Read<T>(response.Content)!;
#pragma warning restore AZC0150 // Use ModelReaderWriter overloads with ModelReaderWriterContext
#pragma warning restore IL3050 // This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.
#pragma warning restore IL2026 // This class uses reflection.  Pass in a generated ModelReaderWriterContext to be AOT compatible.
    }
}
