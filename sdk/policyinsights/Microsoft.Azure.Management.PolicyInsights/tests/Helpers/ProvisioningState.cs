// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Immutable;

namespace PolicyInsights.Tests.Helpers
{
    /// <summary>
    /// The provisioning state of a resource.
    /// </summary>
    public static class ProvisioningState
    {
        /// <summary>
        /// The accepted provisioning state.
        /// </summary>
        public const string Accepted = "Accepted";

        /// <summary>
        /// The Succeeded provisioning state.
        /// </summary>
        public const string Succeeded = "Succeeded";

        /// <summary>
        /// The Canceled provisioning state.
        /// </summary>
        public const string Canceled = "Canceled";

        /// <summary>
        /// The Failed provisioning state.
        /// </summary>
        public const string Failed = "Failed";

        /// <summary>
        /// The terminal provisioning states that indicate a resource operation is complete.
        /// </summary>
        public static readonly ImmutableHashSet<string> TerminalStates = new[] { ProvisioningState.Succeeded, ProvisioningState.Canceled, ProvisioningState.Failed }.ToImmutableHashSet(StringComparer.OrdinalIgnoreCase);

        /// <summary>
        /// Get a value indicating whether a given provisioning state is terminal.
        /// </summary>
        /// <param name="provisioningState">The provisioning state value to check.</param>
        public static bool IsTerminal(string provisioningState)
        {
            return ProvisioningState.TerminalStates.Contains(provisioningState);
        }
    }
}
