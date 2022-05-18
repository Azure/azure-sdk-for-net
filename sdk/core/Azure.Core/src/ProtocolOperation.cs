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
        private readonly IOperation _nextLinkOperation;

        internal ProtocolOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, string scopeName)
        {
            _nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia);
            _operation = new OperationInternal(clientDiagnostics, this, response, scopeName);
        }

        /// <summary>
        /// For Mocking.
        /// </summary>
        protected ProtocolOperation()
        {
            // What does mocking mean for this type?
            // _nextLinkOperation = ?
            // _operation = ?
        }

        /// <summary>
        /// </summary>
        public override string Id => /* If following pattern, this will be in response.  If not, we'll throw NotSupportedException */

        /// <summary>
        /// </summary>
        public override bool HasCompleted => throw new NotImplementedException();

        /// <summary>
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Response GetRawResponse()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

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
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
