//-----------------------------------------------------------------------
// <copyright file="ChangeDeploymentConfigurationInfo.cs" company="Microsoft">
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
//    Contains code for the ChangeDeploymentConfigurationInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "ChangeConfiguration", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class ChangeDeploymentConfigurationInfo : AzureDataContractBase
    {
        private ChangeDeploymentConfigurationInfo()
        {
        }

        internal static ChangeDeploymentConfigurationInfo Create(string configFilePath, bool treatWarningsAsError, UpgradeType mode, IDictionary<string, string> extendedProperties)
        {
            Validation.ValidateStringArg(configFilePath, "configuration");
            Validation.ValidateExtendedProperties(extendedProperties);
            if (!File.Exists(configFilePath)) throw new FileNotFoundException(string.Format(Resources.ConfigFileNotFound, configFilePath), configFilePath);

            string configText = File.ReadAllText(configFilePath);

            ExtendedPropertyCollection collection = null;
            if (extendedProperties != null)
            {
                collection = new ExtendedPropertyCollection(extendedProperties);
            }

            return new ChangeDeploymentConfigurationInfo
            {
                Configuration = configText.EncodeBase64(),
                TreatWarningsAsError = treatWarningsAsError,
                Mode = mode,
                ExtendedProperties = collection
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        internal string Configuration { get; private set; }

        [DataMember(Order = 1, Name = "TreatWarningAsError", IsRequired = false, EmitDefaultValue = false)]
        internal bool TreatWarningsAsError { get; private set; }

        [DataMember(Order = 2, Name = "Mode", IsRequired = false, EmitDefaultValue = false)]
        internal UpgradeType Mode { get; private set; }

        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        internal ExtendedPropertyCollection ExtendedProperties { get; private set; }

    }

}
