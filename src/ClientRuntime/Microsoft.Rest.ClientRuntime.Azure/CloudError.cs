// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Provides additional information about an http error response
    /// </summary>
    public class CloudError
    {
        /// <summary>
        /// Initializes a new instance of CloudError.
        /// </summary>
        public CloudError()
        {
            Details = new List<CloudError>();
        }

        /// <summary>
        /// The error code parsed from the body of the http error response
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The error message parsed from the body of the http error response
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the target of the error.
        /// </summary>
        public string Target { get; set; }

        /// <summary>
        /// Gets or sets details for the error.
        /// </summary>
        public IList<CloudError> Details { get; private set; }
    }
}
