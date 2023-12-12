// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives
{
    internal class ResponseStatusClassifier : PipelineMessageClassifier
    {
        // We need 10 ulongs to represent status codes 100 - 599.
        private BitVector640 _successCodes;

        /// <summary>
        /// Creates a new instance of <see cref="ResponseStatusClassifier"/>.
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier will consider
        /// not to be errors.</param>
        public ResponseStatusClassifier(ReadOnlySpan<ushort> successStatusCodes)
        {
            _successCodes = new();

            foreach (int statusCode in successStatusCodes)
            {
                AddClassifier(statusCode, isError: false);
            }
        }

        public sealed override bool IsErrorResponse(PipelineMessage message)
        {
            if (message.Response is null)
            {
                throw new InvalidOperationException("Response is not set on message.");
            }

            return !_successCodes[message.Response.Status];
        }

        private void AddClassifier(int statusCode, bool isError)
        {
            ClientUtilities.AssertInRange(statusCode, 0, 639, nameof(statusCode));

            _successCodes[statusCode] = isError;
        }
    }
}
