// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify the port number.
    /// </summary>
    public interface IWithPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        ReturnT WithPort(int portNumber);
    }
}