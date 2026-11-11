// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Files.DataLake.Models
{
    /// <summary>
    /// Optional parameters for setting the HTTP headers of a file or directory.
    /// </summary>
    public class DataLakePathSetHttpHeadersOptions
    {
        /// <summary>
        /// Optional. The standard HTTP header system properties to set.  If not specified, existing values will be cleared.
        /// </summary>
        public PathHttpHeaders HttpHeaders { get; set; }

        /// <summary>
        /// Optional <see cref="DataLakeRequestConditions"/> to add conditions on
        /// setting the path's HTTP headers.
        /// </summary>
        public DataLakeRequestConditions Conditions { get; set; }

        /// <summary>
        /// Optional. Sets the priority of this request, from 0 through 7.
        /// If not set, or if the value is outside that range, the service uses 3.
        /// </summary>
        public int? RequestPriority { get; set; }
    }
}
