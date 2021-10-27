// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.ConfidentialLedger
{
    /// <summary> Client options for ConfidentialLedgerClient. </summary>
    public partial class ConfidentialLedgerClientOptions
    {
        /// <summary>
        /// The default polling interval for client methods that return an <see cref="Operation"/> when waitForCompletion is <c>true</c>.
        /// </summary>
        public TimeSpan OperationPollingInterval { get; set; } = OperationHelpers.DefaultPollingInterval;
    }
}
