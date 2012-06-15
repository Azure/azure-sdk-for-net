//-----------------------------------------------------------------------
// <copyright file="InputEndpoint.cs" company="Microsoft">
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
//    Contains code for the InputEndpoint class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents an input endpoint for a deployment.
    /// </summary>
    [DataContract(Name = "InputEndpoint", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class InputEndpoint : AzureDataContractBase
    {
        private InputEndpoint()
        {
        }

        /// <summary>
        /// The port for this input endpoint.
        /// </summary>
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public int Port { get; private set; }

 
        /// <summary>
        ///The protocol (http, https) for this endpoint. 
        /// </summary>
        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string Protocol { get; private set; }

        /// <summary>
        /// The virtual IP address for this endpoint.
        /// </summary>
        [DataMember(Order = 2, Name = "Vip", IsRequired = false, EmitDefaultValue = false)]
        public string VirtualIPAddress { get; private set; }
    }
}
