// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.ContainerServiceFleet
{
    internal partial class ContainerServiceFleetArmOperation
    {
        /// <summary></summary>
        /// <param name="clientDiagnostics"> The instance of <see cref="ClientDiagnostics"/>. </param>
        /// <param name="pipeline"> The instance of <see cref="HttpPipeline"/>. </param>
        /// <param name="request"> The operation request. </param>
        /// <param name="response"> The operation response. </param>
        /// <param name="finalStateVia"> The finalStateVia of the operation. </param>
        /// <param name="skipApiVersionOverride"> If should skip Api version override. </param>
        /// <param name="apiVersionOverrideValue"> The Api version override value. </param>
        internal ContainerServiceFleetArmOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response, OperationFinalStateVia finalStateVia, bool skipApiVersionOverride = true, string apiVersionOverrideValue = null)
        {
            IOperation nextLinkOperation = NextLinkOperationImplementation.Create(pipeline, request.Method, request.Uri.ToUri(), response, finalStateVia, skipApiVersionOverride, apiVersionOverrideValue);
            if (nextLinkOperation is NextLinkOperationImplementation nextLinkOperationImplementation)
            {
                _nextLinkOperation = nextLinkOperationImplementation;
                _operationId = _nextLinkOperation.OperationId;
            }
            else
            {
                _completeRehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(request.Method, request.Uri.ToUri(), response, finalStateVia);
                _operationId = GetOperationId(_completeRehydrationToken);
            }
            _operation = new OperationInternal(
                nextLinkOperation,
                clientDiagnostics,
                response,
                "ContainerServiceFleetArmOperation",
                null,
                new SequentialDelayStrategy());
        }
    }
}
