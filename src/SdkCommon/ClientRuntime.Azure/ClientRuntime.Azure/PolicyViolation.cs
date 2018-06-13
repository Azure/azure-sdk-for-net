// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// Policy violation error
    /// </summary>
    public class PolicyViolation : TypedErrorInfo
    {
        /// <summary>
        /// Policy violation error details
        /// </summary>
        public new PolicyViolationErrorInfo Info { get; set; }
    }
}