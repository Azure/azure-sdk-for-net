// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasFloatingIP.Update
{
    /// <summary>
    /// The stage of an update allowing to control floating IP support.
    /// </summary>
    /// <typeparam name="ReturnT">The next stage of the definition.</typeparam>
    public interface IWithFloatingIP<ReturnT> 
    {
        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIPDisabled();

        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIPEnabled();

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">True if floating IP should be enabled.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithFloatingIP(bool enabled);
    }
}