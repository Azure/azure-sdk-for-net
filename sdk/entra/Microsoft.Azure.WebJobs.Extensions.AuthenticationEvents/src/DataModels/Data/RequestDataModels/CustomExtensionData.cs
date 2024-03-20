// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.WebJobs.Extensions.AuthenticationEvents
{
    /// <summary>
    /// Represents the Custom Extension Data.
    /// </summary>
    public abstract class CustomExtensionData
    {
        /// <summary>
        /// Gets or sets the OData type representing the type of the object.
        /// </summary>
        public string ODataType { get; set; }
    }
}
