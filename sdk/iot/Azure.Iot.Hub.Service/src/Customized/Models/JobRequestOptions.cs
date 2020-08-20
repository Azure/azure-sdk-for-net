// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Iot.Hub.Service.Models
{
    /// <summary>
    /// Optional properties for import and export jobs.
    /// </summary>
    public class JobRequestOptions
    {
        /// <summary>
        /// Specifies authentication type being used for connecting to storage account. If not provided by the user, it will default to KeyBased type.
        /// </summary>
        public JobPropertiesStorageAuthenticationType AuthenticationType { get; set; }
    }
}
