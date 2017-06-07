//-----------------------------------------------------------------------
// <copyright file="UpgradeDeploymentInfo.cs" company="Microsoft">
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
//    Contains code for the UpgradeDeploymentInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "UpdateDeployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class UpgradeDeploymentInfo : AzureDataContractBase
    {
        private UpgradeDeploymentInfo()
        {
        }

        internal static UpgradeDeploymentInfo Create(UpgradeType mode, Uri packageUrl, string configFilePath, string label, string roleToUpgrade, bool treatWarningsAsError, bool force, IDictionary<string, string> extendedProperties)
        {
            Validation.NotNull(packageUrl, "packageUrl");
            Validation.ValidateLabel(label);
            Validation.ValidateStringArg(configFilePath, "configPath");
            Validation.ValidateExtendedProperties(extendedProperties);
            if (!File.Exists(configFilePath)) throw new FileNotFoundException(string.Format(Resources.ConfigFileNotFound, configFilePath), configFilePath);

            string configText = File.ReadAllText(configFilePath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new UpgradeDeploymentInfo
            {
                Mode = mode,
                PackageUrl = packageUrl,
                Configuration = configText.EncodeBase64(),
                Label = label.EncodeBase64(),
                RoleToUpgrade = roleToUpgrade,
                TreatWarningsAsError = treatWarningsAsError,
                Force = force,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        internal UpgradeType Mode { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        internal Uri PackageUrl { get; private set; }

        [DataMember(Order = 2, IsRequired = true)]
        internal string Configuration { get; private set; }

        [DataMember(Order = 3, IsRequired = true)]
        internal string Label { get; private set; }

        [DataMember(Order = 4, IsRequired = false, EmitDefaultValue = false)]
        internal string RoleToUpgrade { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal bool TreatWarningsAsError { get; private set; }

        [DataMember(Order = 5, IsRequired = false, EmitDefaultValue = false)]
        internal bool Force { get; private set; }

        [DataMember(Order = 6, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
