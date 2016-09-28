// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.V2.Network.HasFloatingIp.Update
{


    /// <summary>
    /// The stage of a definition allowing to control floating IP support.
    /// @param <ReturnT> the next stage of the definition
    /// </summary>
    public interface IWithFloatingIp<ReturnT> 
    {
        /// <summary>
        /// Enables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithFloatingIpEnabled ();

        /// <summary>
        /// Disables floating IP support.
        /// </summary>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithFloatingIpDisabled ();

        /// <summary>
        /// Sets the floating IP enablement.
        /// </summary>
        /// <param name="enabled">enabled true if floating IP should be enabled</param>
        /// <returns>the next stage of the definition</returns>
        ReturnT WithFloatingIp (bool enabled);

    }
}