// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    /// <summary>
    /// An interface representing a model's ability to require server name indication.
    /// </summary>
    public interface IHasServerNameIndication 
    {
        /// <summary>
        /// Gets true if server name indication (SNI) is required, else false.
        /// </summary>
        bool RequiresServerNameIndication { get; }
    }
}