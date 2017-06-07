//-----------------------------------------------------------------------
// <copyright file="CreateStorageAccountInfo.cs" company="Microsoft">
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
//    Contains code for the CreateStorageAccountInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "CreateStorageServiceInput", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class CreateStorageAccountInfo : AzureDataContractBase
    {
        private CreateStorageAccountInfo() { }

        internal static CreateStorageAccountInfo Create(string storageAccountName, string description, string label,
                                                        string affinityGroup, string location, bool geoReplicationEnabled, IDictionary<string, string> extendedProperties)
        {
            Validation.ValidateStorageAccountName(storageAccountName);
            Validation.ValidateDescription(description);
            Validation.ValidateLabel(label);
            Validation.ValidateLocationOrAffinityGroup(location, affinityGroup);
            Validation.ValidateExtendedProperties(extendedProperties);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateStorageAccountInfo
            {
                Name = storageAccountName,
                Description = description,
                Label = label.EncodeBase64(),
                AffinityGroup = affinityGroup,
                Location = location,
                GeoReplicationEnabled = geoReplicationEnabled,
                ExtendedProperties = collection
            };
        }

        [DataMember(Name = "ServiceName", Order = 0, IsRequired = true)]
        internal string Name { get; private set; }

        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        internal string Description { get; private set; }

        [DataMember(Order = 2, IsRequired = true)]
        internal string Label { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal string AffinityGroup { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal string Location { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal bool GeoReplicationEnabled { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
