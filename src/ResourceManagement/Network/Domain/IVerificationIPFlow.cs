// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Microsoft.Azure.Management.Network.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;

    /// <summary>
    /// A client-side reperesentation allowing to verify IP packet flow from specific vm
    /// based on direction, protocol, local IP, remote IP, local port and remote port.
    /// </summary>
    public interface IVerificationIPFlow  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.IExecutable<Microsoft.Azure.Management.Network.Fluent.IVerificationIPFlow>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasParent<Microsoft.Azure.Management.Network.Fluent.INetworkWatcher>
    {
        /// <summary>
        /// Gets the access value. Indicates whether the traffic is allowed or denied. Possible values
        /// include: 'Allow', 'Deny'.
        /// </summary>
        /// <summary>
        /// Gets the access value.
        /// </summary>
        Models.Access Access { get; }

        /// <summary>
        /// Gets the ruleName value. If input is not matched against any security rule, it
        /// is not displayed.
        /// </summary>
        /// <summary>
        /// Gets the ruleName value.
        /// </summary>
        string RuleName { get; }
    }
}