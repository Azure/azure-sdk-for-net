//-----------------------------------------------------------------------
// <copyright file="ExtendedPropertyCollection.cs" company="Microsoft">
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
//    Contains code for the ExtendedPropertyCollection class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of Name-Value pairs representing 
    /// extended properties on certain entities in Windows Azure,
    /// such as a <see cref="CloudService"/>, 
    /// <see cref="StorageAccountProperties"/>, or <see cref="Deployment"/>.
    /// </summary>
    [CollectionDataContract(Name = "ExtendedProperties", ItemName = "ExtendedProperty", KeyName = "Name", ValueName = "Value", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ExtendedPropertyCollection : Dictionary<string, string>
    {
        private ExtendedPropertyCollection()
        {
        }

        internal ExtendedPropertyCollection(IDictionary<string, string> collection)
            : base(collection)
        {
        }

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
}
