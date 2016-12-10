// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasPort.Update
{
    /// <summary>
    /// The stage of a definition allowing to specify a port number.
    /// </summary>
    /// <typeparam name="Return">The next stage of the update.</typeparam>
    public interface IWithPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the update.</return>
        ReturnT WithPort(int portNumber);
    }
}