//-----------------------------------------------------------------------
// <copyright file="RegenerateStorageAccountKeysInfo.cs" company="Microsoft">
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
//    Contains code for the RegenerateStorageAccountKeysInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name="RegenerateKeys", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class RegenerateStorageAccountKeysInfo
    {
        private RegenerateStorageAccountKeysInfo() { }

        internal static RegenerateStorageAccountKeysInfo Create(StorageAccountKeyType keyType)
        {
            return new RegenerateStorageAccountKeysInfo
            {
                KeyType = keyType
            };
        }

        [DataMember]
        internal StorageAccountKeyType KeyType { get; private set; }
    }
}
