//-----------------------------------------------------------------------
// <copyright file="RoleInstance.cs" company="Microsoft">
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
//    Contains code for RoleInstance class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a role instance in a deployment.
    /// </summary>
    [DataContract(Name = "RoleInstance", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class RoleInstance : AzureDataContractBase
    {
        private RoleInstance()
        {
        }

        /// <summary>
        /// Gets the name of the role for this instnace.
        /// </summary>
        [DataMember(Order = 0)]
        public string RoleName { get; private set; }

        /// <summary>
        /// Gets the name of this role instance.
        /// </summary>
        [DataMember(Name = "InstanceName", Order = 1)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the current <see cref="InstanceStatus"/> of this role instance.
        /// </summary>
        [DataMember(Name = "InstanceStatus", Order = 2)]
        public InstanceStatus Status { get; private set; }

        /// <summary>
        /// Gets the upgrade domain that this role instance belongs to. During an Upgrade Deployment, 
        /// all roles in the same Upgrade Domain are upgraded at the same time.
        /// </summary>
        [DataMember(Name = "InstanceUpgradeDomain", Order = 3)]
        public int UpgradeDomain { get; private set; }

        /// <summary>
        /// Gets the fault domain that this role instance belongs to. Role instances that are part 
        /// of the same fault domain may all be vulnerable to the failure 
        /// of the same piece of shared hardware.
        /// </summary>
        [DataMember(Name = "InstanceFaultDomain", Order = 4)]
        public int FaultDomain { get; private set; }

        /// <summary>
        /// Gets the size of the role instance.
        /// </summary>
        [DataMember(Name = "InstanceSize", Order = 5)]
        public InstanceSize Size { get; private set; } 

        /// <summary>
        /// Gets the instance status as set by the guest agent.
        /// </summary>
        [DataMember(Name = "InstanceStateDetails", Order = 6, IsRequired = false, EmitDefaultValue = false)]
        public string StateDetails { get; private set; }

        /// <summary>
        /// Gets the error code fo the most recent role instance of VM execution, if any.
        /// </summary>
        [DataMember(Name = "InstanceErrorCode", Order = 7, IsRequired = false, EmitDefaultValue = false)]
        public string ErrorCode { get; private set; }

        /// <summary>
        /// Gets the IP address of the role instance.
        /// </summary>
        [DataMember(Name = "IpAddress", Order = 8, IsRequired = false, EmitDefaultValue = false)]
        public string IPAddress { get; private set; }

        /// <summary>
        /// Gets the list of <see cref="InstanceEndpoint">Instance Endpoints</see> of the role instance.
        /// </summary>
        [DataMember(Order = 9, IsRequired = false, EmitDefaultValue = false)]
        public List<InstanceEndpoint> InstanceEndpoints { get; private set; }

        /// <summary>
        /// Gets the current <see cref="PowerState"/> of the role instance.
        /// </summary>
        [DataMember(Order = 10, IsRequired = false, EmitDefaultValue = false)]
        public PowerState PowerState { get; private set; }

        //TODO: is this used?
        /// <summary>
        /// Gets the host name of the current role instance.
        /// </summary>
        [DataMember(Order = 11, IsRequired = false, EmitDefaultValue = false)]
        public string HostName { get; private set; }

    }
}
