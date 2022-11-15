// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

[assembly:CodeGenSuppressType("ContainerServiceArmOperation")]
namespace Azure.ResourceManager.ContainerService
{
#pragma warning disable SA1649 // File name should match first type name
    internal class ContainerServiceArmOperation : ArmOperation
#pragma warning restore SA1649 // File name should match first type name
    {
        private readonly OperationInternal _operation;

        /// <summary> Initializes a new instance of ContainerServiceArmOperation for mocking. </summary>
        protected ContainerServiceArmOperation()
        {
        }

        internal ContainerServiceArmOperation(Response response)
        {
            _operation = OperationInternal.Succeeded(response);
        }

        internal ContainerServiceArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string interimApiVersion = null)
        {
            var nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia, interimApiVersion);
            _operation = new OperationInternal(clientDiagnostics, nextLinkOperation, response, "ContainerServiceArmOperation", fallbackStrategy: new ExponentialDelayStrategy());
        }

        internal ContainerServiceArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string id, string interimApiVersion = null)
        {
            _operation = OperationInternal.Create(id, clientDiagnostics, pipeline, "ContainerServiceArmOperation", fallbackStrategy: new ExponentialDelayStrategy(), interimApiVersion: interimApiVersion);
        }

        /// <inheritdoc />
        public override string Id => _operation.GetOperationId();

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponse(cancellationToken);

        /// <inheritdoc />
        public override Response WaitForCompletionResponse(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponse(pollingInterval, cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponseAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> WaitForCompletionResponseAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionResponseAsync(pollingInterval, cancellationToken);

        // TODO: use this class as a temporary workaround before https://github.com/Azure/autorest.csharp/issues/2231 is resolved so that we can deserialize to the original HttpWebResponseImplementation in LRO helper classes.
        // No all methods and properties are implemented/populated as it's just for prototype.
        internal class ContainerServiceResponse: Response
        {
            public ContainerServiceResponse()
            {
            }

            internal ContainerServiceResponse(int status, string reasonPhase, Stream contentStream, string clientRequestId)
            {
                Status = status;
                ReasonPhrase = reasonPhase;
                ContentStream = contentStream;
                ClientRequestId = clientRequestId;
            }

            public override int Status { get; }

            public override string ReasonPhrase { get; }

            public override Stream ContentStream
            {
                get;
                set;
            }
            public override string ClientRequestId { get; set; }

            public override void Dispose()
            {
                throw new NotImplementedException();
            }

            protected override bool ContainsHeader(string name)
            {
                throw new NotImplementedException();
            }

            protected override IEnumerable<HttpHeader> EnumerateHeaders()
            {
                throw new NotImplementedException();
            }

            protected override bool TryGetHeader(string name, out string value)
            {
                throw new NotImplementedException();
            }

            protected override bool TryGetHeaderValues(string name, out IEnumerable<string> values)
            {
                throw new NotImplementedException();
            }
        }
    }
}
