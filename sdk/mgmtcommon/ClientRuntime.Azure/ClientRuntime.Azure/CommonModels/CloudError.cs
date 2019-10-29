// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    using Microsoft.Rest.ClientRuntime.Azure.CommonModels;
    using Newtonsoft.Json;
    using System.Collections.Generic;

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
            AdditionalInfo = new List<AdditionalErrorInfo>();
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
        public IList<CloudError> Details { get; internal set; }

        /// <summary>
        /// Gets or sets additional error info.
        /// </summary>
        public IList<AdditionalErrorInfo> AdditionalInfo { get; internal set; }
    }
}
