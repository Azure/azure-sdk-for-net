// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence
{
    internal class TrainingOperation : Operation<BinaryData>
    {
        private readonly Operation<BinaryData> _internalOperation;

        private readonly Lazy<string> _operationId;

        internal TrainingOperation(Operation<BinaryData> internalOperation)
        {
            _internalOperation = internalOperation;
            _operationId = new Lazy<string>(GetOperationId);
        }

        public override BinaryData Value => _internalOperation.Value;

        public override bool HasValue => _internalOperation.HasValue;

        public override string Id => _operationId.Value;

        public override bool HasCompleted => _internalOperation.HasCompleted;

        public override Response GetRawResponse()
        {
            return _internalOperation.GetRawResponse();
        }

        public override Response UpdateStatus(CancellationToken cancellationToken = default)
        {
            return _internalOperation.UpdateStatus(cancellationToken);
        }

        public override async ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default)
        {
            return await _internalOperation.UpdateStatusAsync(cancellationToken).ConfigureAwait(false);
        }

        private string GetOperationId()
        {
            const string OperationIdNotFoundErrorMessage = "The operation ID was not present in the service response.";
            var response = GetRawResponse();

            // If the "operation-location" header is present, it means the latest response came from a POST request,
            // so the operation ID can be extracted from the header.
            // Otherwise, the latest response came from a GET request, so the operation ID can be obtained directly
            // from the response's content.

            if (response.Headers.TryGetValue("operation-location", out string operationLocation))
            {
                // "operation-location" header pattern:
                // https://<endpoint>/documentintelligence/operations/<operationId>?api-version=<version>
                var match = Regex.Match(operationLocation, @"[^:]+://[^/]+/documentintelligence/operations/([^?]+)");

                if (!match.Success)
                {
                    throw new InvalidOperationException(OperationIdNotFoundErrorMessage);
                }

                return match.Groups[1].Value;
            }
            else
            {
                using var document = JsonDocument.Parse(response.Content);

                if (!document.RootElement.TryGetProperty("operationId", out JsonElement operationIdProperty))
                {
                    throw new InvalidOperationException(OperationIdNotFoundErrorMessage);
                }

                return operationIdProperty.GetRawText().Trim('"');
            }
        }
    }
}
