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
//    Contains code for the ConfigurationSet class and subclasses.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //Configuration set has multiple sub classes. 
    /// <summary>
    /// The abstrace base class for all ConfigurationSet types.
    /// </summary>
    [DataContract(Name = "ConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    [KnownType(typeof(NetworkConfigurationSet))]
    [KnownType(typeof(ProvisioningConfigurationSet))]
    [KnownType(typeof(WindowsProvisioningConfigurationSet))]
    [KnownType(typeof(LinuxProvisioningConfigurationSet))]
    [KnownType(typeof(GenericProvisioningConfigurationSet))]
    public abstract class ConfigurationSet : AzureDataContractBase
    {
        /// <summary>
        /// The name of the type of the configuration set.
        /// </summary>
        [DataMember(Order = 0)]
        public string ConfigurationSetType { get; private set; }
    }

    /// <summary>
    /// Represents a network configuration set for a role in a deployment.
    /// </summary>
    [DataContract(Name = "NetworkConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class NetworkConfigurationSet : ConfigurationSet
    {
        private NetworkConfigurationSet()
        {
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

    //there are other configuration set types, which I'm not going to fill in right now.
    //they need to exist as known types if serialization is going to work, if they show up...
    //TODO: Fill these in
    /// <summary>
    /// The abstract base class for all provisioning configuration sets.
    /// </summary>
    [DataContract(Name = "ProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public abstract class ProvisioningConfigurationSet : ConfigurationSet
    {
    }

    /// <summary>
    /// Represents the Windows provisioning configuration set.
    /// </summary>
    [DataContract(Name = "WindowsProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class WindowsProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private WindowsProvisioningConfigurationSet() { }
    }

    /// <summary>
    /// Represents the Linux provisioning configuration set.
    /// </summary>
    [DataContract(Name = "LinuxProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class LinuxProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private LinuxProvisioningConfigurationSet() { }
    }

    /// <summary>
    /// Represents a generic provisioning configuration set.
    /// </summary>
    [DataContract(Name = "GenericProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class GenericProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private GenericProvisioningConfigurationSet() { }
    }
}
