//-----------------------------------------------------------------------
// <copyright file="VipSwapInfo.cs" company="Microsoft">
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
//    Contains code for the VipSwapInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "Swap", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class VipSwapInfo : AzureDataContractBase
    {
        private VipSwapInfo() { }

        internal static VipSwapInfo Create(string productionName, string stagingName)
        {
            //production allowed to be null...
            Validation.ValidateStringArg(stagingName, "stagingName");

            return new VipSwapInfo
            {
                Production = productionName,
                Staging = stagingName
            };
        }

        [DataMember(Order = 0, IsRequired = false, EmitDefaultValue = false)]
        internal string Production { get; private set; }

        [DataMember(Name = "SourceDeployment", Order = 1)]
        internal string Staging { get; private set; }
    }

}
