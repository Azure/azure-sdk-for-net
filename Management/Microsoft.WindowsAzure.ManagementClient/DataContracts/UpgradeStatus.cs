//-----------------------------------------------------------------------
// <copyright file="UpgradeStatus.cs" company="Microsoft">
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
//    Contains code for the UpgradeStatus class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents the upgrade status for a deployment.
    /// </summary>
    [DataContract(Name = "UpgradeStatus", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class UpgradeStatus : AzureDataContractBase
    {
        private UpgradeStatus() { }

        /// <summary>
        /// The <see cref="UpgradeType">type</see> of the upgrade.
        /// </summary>
        [DataMember(Name = "UpgradeType", Order = 0)]
        public UpgradeType Type { get; private set; }

        /// <summary>
        /// The <see cref="UpgradeDomainState"/> of the upgrade.
        /// </summary>
        [DataMember(Order = 1)]
        public UpgradeDomainState CurrentUpgradeDomainState { get; private set; }

        /// <summary>
        /// The current upgrade domain of the upgrade.
        /// </summary>
        [DataMember(Order = 2)]
        public int CurrentUpgradeDomain { get; private set; }
    }

}
