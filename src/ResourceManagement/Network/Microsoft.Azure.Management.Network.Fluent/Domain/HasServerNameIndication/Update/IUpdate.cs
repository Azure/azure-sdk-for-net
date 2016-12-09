// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasServerNameIndication.Update
{
    /// <summary>
    /// The stage of an update allowing to require server name indication (SNI).
    /// </summary>
    public interface IWithServerNameIndication<ReturnT> 
    {
        /// <summary>
        /// Requires server name indication (SNI).
        /// </summary>
        ReturnT WithServerNameIndication();

        /// <summary>
        /// Ensures server name indication (SNI) is not required.
        /// </summary>
        ReturnT WithoutServerNameIndication();
    }
}