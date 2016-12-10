// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasHostName.Update
{
    /// <summary>
    /// The stage of an update allowing to specify a host name.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    public interface IWithHostName<ReturnT> 
    {
        /// <summary>
        /// Specifies the host name.
        /// </summary>
        /// <param name="hostName">An existing host name.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithHostName(string hostName);
    }
}