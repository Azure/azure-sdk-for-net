// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core
{
    /// <summary>
    /// Marks methods that call methods on other client and don't need their diagnostics verified.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    internal class ForwardsClientCallsAttribute : Attribute
    {
        /// <summary>
        /// Creates a new instance of <see cref="ForwardsClientCallsAttribute"/>.
        /// </summary>
        public ForwardsClientCallsAttribute()
            : this(false)
        {
        }

        /// <summary>
        /// Creates a new instance of <see cref="ForwardsClientCallsAttribute"/>.
        /// </summary>
        /// <param name="skipChecks"> Sets whether or not diagnostic scope validation should happen. </param>
        public ForwardsClientCallsAttribute(bool skipChecks)
        {
            SkipChecks = skipChecks;
        }

        /// <summary>
        /// Gets whether or not we should validate DiagnosticScope for this API.
        /// In the case where there is an internal API that makes the Azure API call and a public API that uses it we need ForwardsClientCalls.
        /// If the public API will cache the results then the diagnostic scope will not always be created because an Azure API is not always called.
        /// In this case we need to turn off this validation for this API only.
        /// </summary>
        public bool SkipChecks { get; }
    }
}
