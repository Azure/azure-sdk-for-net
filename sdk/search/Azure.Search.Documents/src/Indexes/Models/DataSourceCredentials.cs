// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Search.Documents.Indexes.Models
{
    internal partial class DataSourceCredentials
    {
        /// <summary>
        /// Sentinel value that indicates to the server not to update the stored credentials.
        /// </summary>
        /// <remarks>
        /// Currently undocumented, but required to avoid clearing stored credentials.
        /// See https://github.com/Azure/azure-rest-api-specs/issues/9877 for details.
        /// </remarks>
        internal const string UnchangedValue = "<unchanged>";
    }
}
