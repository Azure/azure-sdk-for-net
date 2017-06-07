//-----------------------------------------------------------------------
// <copyright file="CreateDeploymentInfo.cs" company="Microsoft">
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
//    Contains code for the CreateDeploymentInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //Class used to post to CreateDeployment
    //it is not exposed to callers, so marked internal
    [DataContract(Name = "CreateDeployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    class CreateDeploymentInfo : AzureDataContractBase
    {
        private const int LabelMax = 100;

        //private constructor, use Create factory method to create, q.v.
        private CreateDeploymentInfo()
        {
        }

        internal static CreateDeploymentInfo Create(
            string name, Uri packageUrl, string label,
            string configPath, bool startDeployment = false,
            bool treatWarningsAsError = false,
            IDictionary<string, string> extendedProperties = null)
        {
            Validation.ValidateStringArg(name, "name");
            Validation.NotNull(packageUrl, "packageUrl");
            Validation.ValidateLabel(label);
            Validation.ValidateStringArg(configPath, "configPath");
            Validation.ValidateExtendedProperties(extendedProperties);
            if (!File.Exists(configPath)) throw new FileNotFoundException(string.Format(Resources.ConfigFileNotFound, configPath), configPath);

            string configText = File.ReadAllText(configPath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new CreateDeploymentInfo
            {
                Name = name,
                PackageUrl = packageUrl,
                Label = label.EncodeBase64(),
                Configuration = configText.EncodeBase64(),
                StartDeployment = startDeployment,
                TreatWarningsAsError = treatWarningsAsError,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        internal string Name { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        internal Uri PackageUrl { get; private set; }

        //NOTE: this must be base64 encoded, see Create factory method
        [DataMember(Order = 2, IsRequired = true)]
        internal string Label { get; private set; }

        //NOTE: this must be base64 encoded, see Create factory method
        [DataMember(Order = 3, IsRequired = true)]
        internal string Configuration { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal bool StartDeployment { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal bool TreatWarningsAsError { get; private set; }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
