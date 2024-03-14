// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.ResourceManager
{
#pragma warning disable SA1649 // File name should match first type name
    internal class RehydrationOperation<T> : Operation<T> where T : notnull
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal<T> _operation;
        private readonly NextLinkOperationImplementation _nextLinkOperation;

        public RehydrationOperation(ArmClient client, RehydrationToken? rehydrationToken, ClientOptions options = null)
        {
            if (client is null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            if (rehydrationToken is null)
            {
                throw new ArgumentNullException(nameof(rehydrationToken));
            }

            var isResource = typeof(T).GetConstructor(
                BindingFlags.NonPublic | BindingFlags.Instance,
                null,
                CallingConventions.Any,
                new Type[] { typeof(ArmClient), typeof(ResourceIdentifier) },
                null) is not null;
            var obj = Activator.CreateInstance(typeof(T), BindingFlags.NonPublic | BindingFlags.Instance, null, null, null);
            if (!isResource && obj is not IJsonModel<object>)
            {
                throw new InvalidOperationException($"Type {typeof(T)} should be Resource or Model");
            }

            IOperationSource<T> source = new GenericOperationSource<T>(client, isResource);
            _nextLinkOperation = (NextLinkOperationImplementation)NextLinkOperationImplementation.Create(client.Pipeline, rehydrationToken);
            var operation = NextLinkOperationImplementation.Create(source, _nextLinkOperation);
            var clientDiagnostics = new ClientDiagnostics(options ?? ClientOptions.Default);
            _operation = new OperationInternal<T>(operation, clientDiagnostics, null);
        }

        public override T Value => _operation.Value;

        public override bool HasValue => _operation.HasValue;

        public override string Id => _nextLinkOperation.OperationId ?? null;

        public override bool HasCompleted => _operation.HasCompleted;

        public override Response GetRawResponse() => _operation.RawResponse;

        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
    }
}
