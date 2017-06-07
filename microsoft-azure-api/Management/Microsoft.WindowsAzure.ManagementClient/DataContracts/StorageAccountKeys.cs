//-----------------------------------------------------------------------
// <copyright file="StorageAccountKeys.cs" company="Microsoft">
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
//    Contains code for the StorageAccountKeys class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents the set of access keys for a storage account.
    /// </summary>
    [DataContract(Name = "StorageService", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class StorageAccountKeys : AzureDataContractBase
    {
        /// <summary>
        /// The Service Management API request URI used to perform 
        /// requests against the storage account. 
        /// </summary>
        [DataMember(Order = 0)]
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the primary key for the storage account.
        /// </summary>
        public byte[] Primary { get { return Convert.FromBase64String(_keys.Primary); } }

        /// <summary>
        /// Gets the secondary key for the storage account.
        /// </summary>
        public byte[] Secondary { get { return Convert.FromBase64String(_keys.Secondary); } }

        [DataMember(Name = "StorageServiceKeys", Order = 1, IsRequired = false, EmitDefaultValue = false)]
        private StorageAccountKeysInternal _keys;

        [DataContract(Name = "StorageServiceKeys", Namespace = AzureConstants.AzureSchemaNamespace)]
        private class StorageAccountKeysInternal : AzureDataContractBase
        {
            [DataMember(Order = 0)]
            internal string Primary { get; private set; }

            [DataMember(Order = 1)]
            internal string Secondary { get; private set; }
        }
    }
}
