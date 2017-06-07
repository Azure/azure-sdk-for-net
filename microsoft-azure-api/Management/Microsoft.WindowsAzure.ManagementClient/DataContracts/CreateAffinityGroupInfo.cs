//-----------------------------------------------------------------------
// <copyright file="CreateAffinityGroupInfo.cs" company="Microsoft">
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
//    Contains code for the CreateAffinityGroupInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "CreateAffinityGroup", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class CreateAffinityGroupInfo
    {
        private CreateAffinityGroupInfo() { }

        internal static CreateAffinityGroupInfo Create(string name, string label, string description, string location)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.ValidateLabel(label);
            Validation.ValidateDescription(description);
            Validation.ValidateStringArg(location, "location");

            return new CreateAffinityGroupInfo
            {
                Name = name,
                Label = label.EncodeBase64(),
                Description = description,
                Location = location
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        public string Name { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        public string Label { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public string Description { get; private set; }

        [DataMember(Order = 3, IsRequired = true)]
        public string Location { get; private set; }
    }
}
