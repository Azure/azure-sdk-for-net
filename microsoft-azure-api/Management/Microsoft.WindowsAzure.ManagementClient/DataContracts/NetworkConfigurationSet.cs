//-----------------------------------------------------------------------
// <copyright file="ConfigurationSet.cs" company="Microsoft">
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
//    Contains code for the ConfigurationSet and ProvisioningConfigurationSet.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a network configuration set for a role in a deployment.
    /// </summary>
    [DataContract(Name = "NetworkConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class NetworkConfigurationSet : ConfigurationSet
    {
        private NetworkConfigurationSet()
        {
        }

        public NetworkConfigurationSet(params InputEndpoint[] inputEndpoints)
            : this(null, inputEndpoints)
        {
        }

        public NetworkConfigurationSet(List<string> subnetNames, params InputEndpoint[] inputEndpoints)
        {
            this.SubnetNames = subnetNames;
            this.InputEndpoints = new List<InputEndpoint>(inputEndpoints);
        }

        /// <summary>
        /// The list of InputEndpoints for the role.
        /// </summary>
        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        public List<InputEndpoint> InputEndpoints { get; private set; }

        /// <summary>
        /// The list of subnet names for the role.
        /// </summary>
        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public List<string> SubnetNames { get; private set; }
    }
}
