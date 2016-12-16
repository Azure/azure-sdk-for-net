// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Collections.Generic;

    /// <summary>
    /// An interface representing a backend's ability to reference a list of associated network interfaces.
    /// </summary>
    public interface IHasBackendNics 
    {
        /// <summary>
        /// Gets a map of names of the IP configurations of network interfaces assigned to this backend,
        /// indexed by their NIC's resource id.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> BackendNicIpConfigurationNames { get; }
    }
}