// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFloatingIp.Definition
{
    /// <summary>
    /// The stage of a definition allowing to control floating IP support.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithFloatingIp<ReturnT> 
    {
        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIpDisabled();

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIpEnabled();

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIp(bool enabled);
    }
}