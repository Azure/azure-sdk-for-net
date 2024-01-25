// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

#nullable enable

namespace Azure.Core
{
    /// <summary>
    /// Decorates an operation or all operations for a client whose invocation should potentially be audited
    /// by Azure service implementations.  Auditing could be recommended
    /// because the operation changes critical service state, creates delegated
    /// access to a resource, affects data retention, etc.  It's a best guess
    /// from the service team that the operation should be audited to mitigate
    /// any potential future issues.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    internal class CallerShouldAuditAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="CallerShouldAuditAttribute"/>.
        /// </summary>
        /// <param name="reason"> Sets a description or link to the rationale for potentially auditing this operation. </param>
        public CallerShouldAuditAttribute(string reason)
        {
            Reason = reason;
        }

        /// <summary>
        /// Gets or sets a description or link to the rationale for potentially
        /// auditing this operation.
        /// </summary>
        public string Reason { get; set; }
    }
}
