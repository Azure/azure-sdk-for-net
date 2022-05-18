// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core.Pipeline;

namespace Azure.Core
{
    /// <summary>
    /// </summary>
    public class ProtocolOperation : Operation
    {
        private readonly OperationInternal _operation;
        //private readonly IOperation _nextLinkOperation;

        //internal ProtocolOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        //{
        //    throw new NotImplementedException();
        //    //_nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
        //    //_operation = new OperationInternal(clientDiagnostics, this, response, scopeName);
        //}

        /// <summary>
        /// Rehydration constructor.
        /// </summary>
        /// <param name="statusUpdateEndpoint"></param>
        /// <param name="apiVersion"></param>
        /// <param name="pipeline"></param>
        /// <param name="options"></param>
        /// <param name="context"></param>
        public ProtocolOperation(Uri statusUpdateEndpoint, string apiVersion, HttpPipeline pipeline, ClientOptions options, RequestContext context)
        {
            throw new NotImplementedException();
            //_nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, RequestMethod.Get, statusUpdateEndpoint + apiVersion, response, finalStateVia);
        }

        /// <summary>
        /// </summary>
        /// <param name="continuationToken"></param>
        /// <param name="apiVersion"></param>
        /// <param name="pipeline"></param>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <exception cref="NotImplementedException"></exception>
        public ProtocolOperation(string continuationToken, string apiVersion, HttpPipeline pipeline, ClientOptions options, RequestContext context)
        {
            throw new NotImplementedException();
            //_nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, RequestMethod.Get, statusUpdateEndpoint + apiVersion, response, finalStateVia);
        }

        /// <summary>
        /// For Mocking.
        /// </summary>
        protected ProtocolOperation()
        {
            throw new NotImplementedException();
            // What does mocking mean for this type?
            // _nextLinkOperation = ?
            // _operation = ?
        }

        /// <summary>
        /// </summary>
#pragma warning disable CA1065 // Do not raise exceptions in unexpected locations
        public override string Id => /* If following pattern, this will be in response.  If not, we'll throw NotSupportedException */ throw new NotImplementedException();
#pragma warning restore CA1065 // Do not raise exceptions in unexpected locations

        /// <summary>
        /// </summary>
        public override bool HasCompleted => _operation.HasCompleted;

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Response GetRawResponse() => _operation.RawResponse;

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Response UpdateStatus(RequestContext context)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Response UpdateStatusAsync(RequestContext context)
        {
            throw new NotImplementedException();
        }
    }
}
