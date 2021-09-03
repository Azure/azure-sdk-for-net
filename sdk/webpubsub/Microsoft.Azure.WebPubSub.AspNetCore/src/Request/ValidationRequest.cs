// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;

namespace Microsoft.Azure.WebPubSub.AspNetCore
{
    /// <summary>
    /// Validation request for abuse protection.
    /// </summary>
    public sealed class ValidationRequest : ServiceRequest
    {
        /// <summary>
        /// Flag to indicate whether a valid request.
        /// </summary>
        public bool Valid { get; }

        /// <summary>
        /// Request hosts from headers.
        /// </summary>
        internal List<string> RequestHosts { get; }

        /// <summary>
        /// Name of the request type.
        /// </summary>
        public override string Name => nameof(ValidationRequest);

        internal ValidationRequest(bool valid, List<string> requestHosts)
            :base(null)
        {
            Valid = valid;
            RequestHosts = requestHosts;
        }
    }
}
