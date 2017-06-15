// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to support cookie based affinity.
    /// </summary>
    public interface IHasCookieBasedAffinity 
    {
        /// <summary>
        /// Gets the backend port number the network traffic is sent to.
        /// </summary>
        bool CookieBasedAffinity { get; }
    }
}