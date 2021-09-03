// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Invalid request.
    /// </summary>
    public class InvalidRequest : ServiceRequest
    {
        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; }

        /// <summary>
        /// Name of the request.
        /// </summary>
        public override string Name => nameof(InvalidRequest);

        internal InvalidRequest(string error)
            : base(null)
        {
            ErrorMessage = error;
        }
    }
}
