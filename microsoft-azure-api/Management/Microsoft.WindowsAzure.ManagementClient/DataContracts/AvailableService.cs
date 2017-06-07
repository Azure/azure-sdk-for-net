//-----------------------------------------------------------------------
// <copyright file="AvailableService.cs" company="Microsoft">
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
//    Contains code for the AvailableService enum and the AvailableServiceCollection.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;
using System;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //class is only used during serialization, hence internal
    /// <summary>
    /// Represents a collection of AffinityGroups
    /// </summary>
    [CollectionDataContract(Name = "AvailableServices", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class AvailableServiceCollection : List<AvailableServices>
    {
        private AvailableServiceCollection() { }

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
    /// Represents the available services in a particular data center location.
    /// </summary>
    [DataContract(Name="AvailableService")]
    [Flags]
    public enum AvailableServices
    {
        /// <summary>
        /// No service available, included for completeness
        /// </summary>
        None = 0,

        /// <summary>
        /// Compute service is available.
        /// </summary>
        [EnumMember]
        Compute = 1,

        /// <summary>
        /// Storage service is available.
        /// </summary>
        [EnumMember]
        Storage = 2,

        /// <summary>
        /// PersistentVMRole service is available
        /// </summary>
        [EnumMember]
        PersistentVMRole = 4
    }
}
