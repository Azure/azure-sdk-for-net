//-----------------------------------------------------------------------
// <copyright file="UpdateStorageAccountInfo.cs" company="Microsoft">
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
//    Contains code for the UpdateStorageAccountInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name="UpdateStorageServiceInput", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class UpdateStorageAccountInfo
    {
        private UpdateStorageAccountInfo() { }

        internal static UpdateStorageAccountInfo Create(string label, string description, bool geoReplicationEnabled, IDictionary<string, string> extendedProperties)
        {
            Validation.ValidateAllNotNull(label, description, extendedProperties);
            Validation.ValidateDescription(description);
            Validation.ValidateLabel(label, true);
            Validation.ValidateExtendedProperties(extendedProperties);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new UpdateStorageAccountInfo
            {
                Label = string.IsNullOrEmpty(label) ? null : label.EncodeBase64(),
                Description = description,
                GeoReplicationEnabled = geoReplicationEnabled,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        internal string Description { get; private set; }

        [DataMember(Order=1, IsRequired = false, EmitDefaultValue = false)]
        internal string Label { get; private set; }

        [DataMember(Order=2)]
        internal bool GeoReplicationEnabled { get; private set; }

        [DataMember(Order=3, IsRequired=false, EmitDefaultValue=false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
