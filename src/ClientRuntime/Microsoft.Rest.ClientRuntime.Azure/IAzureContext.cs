// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Microsoft.Rest.Azure
{
    /// Interface capturing the current Http state needed to communicate with Azure
    public interface IAzureContext: IClientContext
    {
        /// <summary>
        /// The Azure subscription to target. The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        string SubscriptionId { get; set; }

        /// <summary>
        /// The Azure tenant id to target.  The value should be in the form of a globally-unique identifier (GUID).
        /// </summary>
        string TenantId { get; set; }

        /// <summary>
        /// The maximum time to spend in retrying transient HTTP errors.
        /// </summary>
        int? LongRunningOperationRetryTimeout { get; set; }

        /// <summary>
        /// Determines whether clients should automatically generate a client request id.  This id can be used to 
        /// retrieve logs for operations.
        /// </summary>
        bool? GenerateClientRequestId { get; set; }

    }
}
