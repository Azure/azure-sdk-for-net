//-----------------------------------------------------------------------
// <copyright file="InstanceEndpoint.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the InstanceEndpoint class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents an endpoint for a role instance.
    /// </summary>
    [DataContract(Name = "InstanceEndpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class InstanceEndpoint : AzureDataContractBase
    {
        private InstanceEndpoint() { }

        /// <summary>
        /// Gets the name of the endpoint.
        /// </summary>
        [DataMember(Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Virtual IP address of the endpoint.
        /// </summary>
        [DataMember(Name = "Vip", Order = 1)]
        public string VirtualIPAddress { get; private set; }

        /// <summary>
        /// Gets the public port for this endpoint.
        /// </summary>
        [DataMember(Order = 2)]
        public int PublicPort { get; private set; }

        /// <summary>
        /// Gets the local port for this endpoint.
        /// </summary>
        [DataMember(Order = 3)]
        public int LocalPort { get; private set; }

        /// <summary>
        /// Gets the protocol (http, https) for this endpoint.
        /// </summary>
        [DataMember(Order = 4)]
        public string Protocol { get; private set; }
    }
}
