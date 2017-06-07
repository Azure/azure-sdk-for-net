//-----------------------------------------------------------------------
// <copyright file="AffinityGroupInfo.cs" company="Microsoft">
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
//    Contains code for the AffinityGroup and AffinityGroupCollection classes.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of AffinityGroups
    /// </summary>
    [CollectionDataContract(Name = "AffinityGroups", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class AffinityGroupCollection : List<AffinityGroup>
    {
        private AffinityGroupCollection() { }

        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    /// <summary>
    /// Represents a Windows Azure affinity group.
    /// </summary>
    [DataContract(Name = "AffinityGroup", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class AffinityGroup : AzureDataContractBase
    {
        private AffinityGroup() { }

        /// <summary>
        /// Gets the name of the affinity group.
        /// </summary>
        [DataMember(Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the user supplied label for the affinity group.
        /// </summary>
        public string Label
        {
            get
            {
                return _label.DecodeBase64();
            }
        }

        [DataMember(Name="Label", Order=1)]
        private string _label;

        /// <summary>
        /// Gets the user supplied description of the affinity group
        /// </summary>
        [DataMember(Order=2)]
        public string Description { get; private set; }

        /// <summary>
        /// Gets the location data center of the affinity group. Valid values 
        /// are returned from <see cref="AzureHttpClient.ListLocationsAsync"/>.
        /// </summary>
        [DataMember(Order=3)]
        public string Location { get; private set; }

        /// <summary>
        /// Gets a collection of cloud services that reference this 
        /// affinity group.
        /// </summary>
        [DataMember(Name="HostedServices", Order = 4, IsRequired = false, EmitDefaultValue = false)]
        public CloudServiceCollection CloudServices { get; set; }

        /// <summary>
        /// Gets a collection of storage accounts that reference this 
        /// affinity group.
        /// </summary>
        [DataMember(Name = "StorageServices", Order = 5, IsRequired = false, EmitDefaultValue = false)]
        public StorageAccountPropertiesCollection StorageAccounts { get; set; }

        /// <summary>
        /// Gets a list of capabilities of this affinity group. 
        /// Currently the only possible capability is "PersistentVMRole"
        /// </summary>
        [DataMember(Order=6, IsRequired=false, EmitDefaultValue=false)]
        public List<string> Capabilities { get; set; }

    }
}
