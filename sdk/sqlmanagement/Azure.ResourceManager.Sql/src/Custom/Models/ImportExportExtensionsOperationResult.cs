// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

#pragma warning disable CS1591
namespace Azure.ResourceManager.Sql.Models
{
    public partial class ImportExportExtensionsOperationResult
    {
        public ImportExportExtensionsOperationResult()
        {
        }

        public Guid? RequestId { get; set; }
        public string RequestType { get; set; }
        public string LastModifiedTime { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string Status { get; set; }
        public string ErrorMessage { get; set; }
        public string QueuedTime { get; set; }
        public Uri BlobUri { get; set; }
        public IReadOnlyList<PrivateEndpointConnectionRequestStatus> PrivateEndpointConnections { get; set; }
    }
}
