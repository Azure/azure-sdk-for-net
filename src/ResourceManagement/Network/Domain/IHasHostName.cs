// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to reference a host name.
    /// </summary>
    public interface IHasHostName 
    {
        /// <summary>
        /// Gets the associated host name.
        /// </summary>
        string HostName { get; }
    }
}