// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence
{
    internal class OperationWithId : Operation<BinaryData>
    {
        private const string OperationIdNotFoundErrorMessage = "The operation ID was not present in the service response.";

        // Location header pattern:
        // https://<endpoint>/documentintelligence/<api>/<operationId>?api-version=<version>
        private static readonly Regex s_locationHeaderRegex = new(@"[^:]+://[^/]+/documentintelligence/.+/([^?/]+)", RegexOptions.Compiled);

        private readonly Operation<BinaryData> _internalOperation;

        private readonly string _operationId;

        internal OperationWithId(Operation<BinaryData> internalOperation)
        {
            _internalOperation = internalOperation;
            _operationId = GetOperationId();
        }

        public override BinaryData Value => _internalOperation.Value;

        public override bool HasValue => _internalOperation.HasValue;

        public override string Id => _operationId ?? throw new InvalidOperationException(OperationIdNotFoundErrorMessage);

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
            var response = GetRawResponse();

            // The "operation-location" header may or may not be present depending on the type of
            // request that was sent to the service. It depends on whether it was a GET or a POST
            // request, as well as whether this is an analysis or a training operation. In case the
            // header is missing, the operation ID must be extracted from the response body. We're
            // contemplating both scenarios in the code below.

            if (response.Headers.TryGetValue("operation-location", out string operationLocation))
            {
                var match = s_locationHeaderRegex.Match(operationLocation);

                if (match.Success && match.Groups[1].Success)
                {
                    return match.Groups[1].Value;
                }
            }
            else if (response.Content is not null)
            {
                try
                {
                    using var document = JsonDocument.Parse(response.Content);

                    if (document.RootElement.TryGetProperty("operationId", out JsonElement operationIdProperty))
                    {
                        return operationIdProperty.GetString();
                    }
                }
                catch (JsonException)
                {
                    // Ignore the exception. Failing to extract the ID should not prevent users from
                    // using most of this class' functionality.
                }
            }

            return null;
        }
    }
}
