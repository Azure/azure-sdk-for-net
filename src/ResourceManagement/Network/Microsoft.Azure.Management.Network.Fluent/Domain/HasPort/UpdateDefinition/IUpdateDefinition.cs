// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent.HasPort.UpdateDefinition
{
    /// <summary>
    /// The stage of a definition allowing to specify the port number.
    /// </summary>
    /// <typeparam name="Return">The next stage of the definition.</typeparam>
    public interface IWithPort<ReturnT> 
    {
        /// <summary>
        /// Specifies the port number.
        /// </summary>
        /// <param name="portNumber">A port number.</param>
        /// <return>The next stage of the definition.</return>
        ReturnT WithPort(int portNumber);
    }
}