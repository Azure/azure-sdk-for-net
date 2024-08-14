// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.DocumentIntelligence
{
    internal class TrainingOperation : Operation<BinaryData>
    {
        private const string OperationIdNotFoundErrorMessage = "The operation ID was not present in the service response.";

        // Location header pattern:
        // https://<endpoint>/documentintelligence/<api>/<operationId>?api-version=<version>
        private static readonly Regex s_locationHeaderRegex = new(@"[^:]+://[^/]+/documentintelligence/.+/([^?/]+)", RegexOptions.Compiled);

        private readonly Operation<BinaryData> _internalOperation;

        private readonly string _operationId;

        internal TrainingOperation(Operation<BinaryData> internalOperation)
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

            if (response.Headers.TryGetValue("operation-location", out string operationLocation))
            {
                var match = s_locationHeaderRegex.Match(operationLocation);

                if (!match.Success || !match.Groups[1].Success)
                {
                    return null;
                }

                return match.Groups[1].Value;
            }

            return null;
        }
    }
}
