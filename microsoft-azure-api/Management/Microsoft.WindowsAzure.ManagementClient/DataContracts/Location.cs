//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="Microsoft">
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
//    Contains code for the Location and LocationCollection classes.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of <see cref="Location">Locations.</see>
    /// </summary>
    [CollectionDataContract(Name = "Locations", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class LocationCollection : List<Location>
    {
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
    /// Represents a Windows Azure data center location.
    /// </summary>
    [DataContract(Name = "Location", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class Location : AzureDataContractBase
    {
        /// <summary>
        /// The name of the data center.
        /// </summary>
        [DataMember(Order=0)]
        public string Name { get; private set; }

        /// <summary>
        /// The localized name of the data center.
        /// </summary>
        [DataMember(Order=1)]
        public string DisplayName { get; private set; }

        /// <summary>
        /// The list of available services in this data center.
        /// </summary>
        [DataMember(Order=2)]
        public AvailableServiceCollection AvailableServices { get; private set; }
    }
}
