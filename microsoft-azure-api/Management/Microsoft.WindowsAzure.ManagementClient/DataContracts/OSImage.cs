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
    [CollectionDataContract(Name = "Images", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class OSImageCollection : List<OSImage>
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

    [DataContract(Name = "OSImage", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class OSImage : AzureDataContractBase
    {
        [DataMember(Order=6, IsRequired=true)]
        public string Name { get; private set; }

        [DataMember(Name = "OS", Order = 7, IsRequired = true)]
        public OperatingSystemType OSType { get; private set; }
    }
}
