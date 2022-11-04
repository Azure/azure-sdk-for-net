// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Developer.LoadTesting
{
    /// <summary>
    /// enum to hold Test Run Status
    /// </summary>
    public enum TestRunStatus
    {
        /// <summary>
        /// enum to denote Test Run Accepted
        /// </summary>
        Accepted,

        /// <summary>
        /// enum to denote Test Run Not Started
        /// </summary>
        NotStarted,

        /// <summary>
        /// enum to denote Test Run Provisioning
        /// </summary>
        Provisioning,

        /// <summary>
        /// enum to denote Test Run Provisioned
        /// </summary>
        Provisioned,

        /// <summary>
        /// enum to denote Test Run Configuring
        /// </summary>
        Configuring,

        /// <summary>
        /// enum to denote Test Run Configured
        /// </summary>
        Configured,

        /// <summary>
        /// enum to denote Test Run Executing
        /// </summary>
        Executing,

        /// <summary>
        /// enum to denote Test Run Executed
        /// </summary>
        Executed,

        /// <summary>
        /// enum to denote Test Run Deprovising
        /// </summary>
        Deprovisioning,

        /// <summary>
        /// enum to denote Test Run Deprovisioned
        /// </summary>
        Deprovisioned,

        /// <summary>
        /// enum to denote Test Run Done
        /// </summary>
        Done,

        /// <summary>
        /// enum to denote Test Run Cancelling
        /// </summary>
        Cancelling,

        /// <summary>
        /// enum to denote Test Run Cancelled
        /// </summary>
        Cancelled,

        /// <summary>
        /// enum to denote Test Run Failed
        /// </summary>
        Failed,

        /// <summary>
        /// enum to denote Test Run Validation Success
        /// </summary>
        ValidationSuccess,

        /// <summary>
        /// enum to denote Test Run Validation Failed
        /// </summary>
        ValidationFailed,

        /// <summary>
        /// enum to denote Test Run Check Timeout
        /// </summary>
        CheckTimeout
    }
}
