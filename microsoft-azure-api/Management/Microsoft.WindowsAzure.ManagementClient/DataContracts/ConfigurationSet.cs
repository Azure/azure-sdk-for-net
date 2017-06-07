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
    //Configuration set has multiple sub classes. 
    /// <summary>
    /// The abstrace base class for all ConfigurationSet types.
    /// </summary>
    [DataContract(Name = "ConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    [KnownType(typeof(NetworkConfigurationSet))]
    [KnownType(typeof(ProvisioningConfigurationSet))]
    [KnownType(typeof(WindowsProvisioningConfigurationSet))]
    [KnownType(typeof(LinuxProvisioningConfigurationSet))]
    public abstract class ConfigurationSet : AzureDataContractBase
    {
        protected ConfigurationSet() { }

        //called when the subclass is used to serialize info to the server
        //to set the type
        protected ConfigurationSet(ConfigurationSetType configurationSetType)
        {
            this.ConfigurationSetType = configurationSetType;
        }

        /// <summary>
        /// The name of the type of the configuration set.
        /// </summary>
        [DataMember(Order = 0)]
        public ConfigurationSetType ConfigurationSetType { get; private set; }
    }

    //the two provisioning configuration sets derive from this. It only
    //exists to distinguish them from the network configuration set.
    /// <summary>
    /// The abstract base class for all provisioning configuration sets.
    /// </summary>
    [DataContract(Name = "ProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public abstract class ProvisioningConfigurationSet : ConfigurationSet
    {
        protected ProvisioningConfigurationSet() { }

         //called when the subclass is used to serialize info to the server
        //to set the type
        protected ProvisioningConfigurationSet(ConfigurationSetType configurationSetType)
            : base(configurationSetType)
        {
        }
    }

    

    /// <summary>
    /// Represents the Linux provisioning configuration set.
    /// </summary>
    [DataContract(Name = "LinuxProvisioningConfigurationSet", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class LinuxProvisioningConfigurationSet : ProvisioningConfigurationSet
    {
        private LinuxProvisioningConfigurationSet() { }
    }
}
