// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{


    /// <summary>
    /// An interface representing a model's ability to have floating IP support.
    /// </summary>
    public interface IHasFloatingIp 
    {
        /// <returns>the state of the floating IP enablement</returns>
        bool FloatingIpEnabled { get; }

    }
}