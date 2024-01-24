// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Internal;

namespace System.ClientModel.Primitives
{
    internal class ResponseStatusClassifier : ErrorResponseClassifier
    {
        private BitVector640 _successCodes;

        /// <summary>
        /// Creates a new instance of <see cref="ResponseStatusClassifier"/>.
        /// </summary>
        /// <param name="successStatusCodes">The status codes that this classifier
        /// will consider not to be errors.</param>
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
            message.AssertResponse();

            return !_successCodes[message.Response!.Status];
        }

        private void AddClassifier(int statusCode, bool isError)
        {
            Argument.AssertInRange(statusCode, 0, 639, nameof(statusCode));

            _successCodes[statusCode] = !isError;
        }
    }
}