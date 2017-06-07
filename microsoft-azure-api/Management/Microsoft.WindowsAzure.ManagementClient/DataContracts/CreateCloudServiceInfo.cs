//-----------------------------------------------------------------------
// <copyright file="CreateCloudServiceInfo.cs" company="Microsoft">
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
//    Contains code for the CreateCloudServiceInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "CreateHostedService", Namespace = AzureConstants.AzureSchemaNamespace)]
    class CreateCloudServiceInfo : AzureDataContractBase
    {
        //private constructor, use Create factory method to create, q.v.
        private CreateCloudServiceInfo()
        {
        }

        internal static CreateCloudServiceInfo Create(
            string name, string label, string description,
            string location, string affinityGroup, IDictionary<string,string> extendedProperties)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.ValidateLabel(label);
            Validation.ValidateDescription(description);
            Validation.ValidateLocationOrAffinityGroup(location, affinityGroup);
            Validation.ValidateExtendedProperties(extendedProperties);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateCloudServiceInfo
            {
                Name = name,
                Label = label.EncodeBase64(),
                Description = description,
                Location = location,
                AffinityGroup = affinityGroup,
                ExtendedProperties = collection
            };
        }

        [DataMember(Name="ServiceName", Order = 0, IsRequired = true)]
        internal string Name { get; private set; }

        [DataMember(Order = 1, IsRequired=true)]
        internal string Label { get; private set; }

        [DataMember(Order = 2, IsRequired=false, EmitDefaultValue=false)]
        internal string Description { get; private set; }

        [DataMember(Order = 3, IsRequired=false, EmitDefaultValue=false)]
        internal string Location { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue=false)]
        internal string AffinityGroup { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
