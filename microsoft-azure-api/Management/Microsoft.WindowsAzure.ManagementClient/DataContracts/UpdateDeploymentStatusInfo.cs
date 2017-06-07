//-----------------------------------------------------------------------
// <copyright file="UpdateDeploymentStatusInfo.cs" company="Microsoft">
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
//    Contains code for the UpdateDeploymentStatusInfo class.
// </summary>
//-----------------------------------------------------------------------

using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "UpdateDeploymentStatus", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class UpdateDeploymentStatusInfo : AzureDataContractBase
    {
        private UpdateDeploymentStatusInfo()
        {
        }

        internal static UpdateDeploymentStatusInfo Create(bool startDeployment)
        {
            return new UpdateDeploymentStatusInfo
            {
                Status = startDeployment ? DeploymentStatus.Running : DeploymentStatus.Suspended
            };
        }

        [DataMember]
        internal DeploymentStatus Status { get; private set; }
    }

}
