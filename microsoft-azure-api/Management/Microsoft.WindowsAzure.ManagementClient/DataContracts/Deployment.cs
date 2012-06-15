//-----------------------------------------------------------------------
// <copyright file="Deployment.cs" company="Microsoft">
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
//    Contains code for the Deployment class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a deployment in a Windows Azure cloud service.
    /// </summary>
    [DataContract(Name = "Deployment", Namespace = AzureConstants.AzureSchemaNamespace)]
    public sealed class Deployment : AzureDataContractBase
    {
        private Deployment() { }

        /// <summary>
        /// Gets the name of the deployment.
        /// </summary>
        [DataMember(Order = 0)]
        public string Name { get; private set; }

        /// <summary>
        /// Gets the <see cref="DeploymentSlot">slot</see> of the deployment.
        /// </summary>
        [DataMember(Order = 1)]
        public DeploymentSlot DeploymentSlot { get; private set; }

        /// <summary>
        /// Gets the unique identifier generated internally 
        /// by Windows Azure for this deployment.
        /// </summary>
        [DataMember(Order = 2)]
        public string PrivateID { get; private set; }

        /// <summary>
        /// Gets the current <see cref="DeploymentStatus">status</see>
        /// of the deployment.
        /// </summary>
        [DataMember(Order = 3)]
        public DeploymentStatus Status { get; private set; }

        /// <summary>
        /// Gets the user supplied label of the deployment.
        /// </summary>
        public string Label { get { return _label.DecodeBase64(); } }

        [DataMember(Name = "Label", Order = 4)]
        private string _label;

        /// <summary>
        /// The Url used to access this deployment.
        /// </summary>
        [DataMember(Order = 5)]
        public Uri Url { get; private set; }

        /// <summary>
        /// The configuration file currently applied to this deployment.
        /// </summary>
        public string Configuration
        {
            get
            {
                if (_decodedConfig == null)
                {
                    _decodedConfig = _config.DecodeBase64();
                }
                return _decodedConfig;
            }
        }

        [DataMember(Name = "Configuration", Order = 6)]
        private string _config;

        private string _decodedConfig;

        /// <summary>
        /// The list of <see cref="RoleInstance">RoleInstances</see> in this deployment.
        /// </summary>
        [DataMember(Name = "RoleInstanceList", Order = 7)]
        public List<RoleInstance> RoleInstances { get; private set; }

        /// <summary>
        /// If the deployment is in the midst of an upgrade, contains the 
        /// current <see cref="UpgradeStatus"/>. Otherwise null.
        /// </summary>
        [DataMember(Order = 8, EmitDefaultValue = false, IsRequired = false)]
        public UpgradeStatus UpgradeStatus { get; private set; }

        /// <summary>
        /// The number of upgrade domains in this deployment.
        /// </summary>
        [DataMember(Order = 9)]
        public int UpgradeDomainCount { get; private set; }

        /// <summary>
        /// The list of the <see cref="Role">Roles</see> in this deployment.
        /// </summary>
        [DataMember(Name = "RoleList", Order = 10)]
        public List<Role> Roles { get; private set; }

        /// <summary>
        /// The version of the Windows Azure SDK used to create this deployment.
        /// </summary>
        [DataMember(Order = 11)]
        public string SdkVersion { get; private set; }

        /// <summary>
        /// Indicates whether new write operations on the deployment are allowed at this time. 
        /// If true, initiating a new write operation on this Deployment is not allowed at this 
        /// time because an existing operation is updating Deployment state; otherwise false.
        /// </summary>
        [DataMember(Order = 13)]
        public bool Locked { get; private set; }

        /// <summary>
        /// Indicates whether the Rollback Update Or Upgrade Operation 
        /// is allowed at this time. If true the operation is allowed; otherwise false.
        /// </summary>
        [DataMember(Order = 14)]
        public bool RollbackAllowed { get; private set; }

        /// <summary>
        /// Gets the name of the virtual network to which this deployment belongs.
        /// </summary>
        [DataMember(Order = 15, IsRequired = false, EmitDefaultValue = false)]
        public string VirtualNetworkName { get; private set; }

        /// <summary>
        /// Gets the date and time this deployment was created.
        /// </summary>
        [DataMember(Order = 16)]
        public DateTime CreatedTime { get; private set; }

        /// <summary>
        /// Gets the date and time this deployment was last modified.
        /// </summary>
        [DataMember(Order = 17)]
        public DateTime LastModifiedTime { get; private set; }

        /// <summary>
        /// Gets a collection of extended properties associated with 
        /// the deployment.
        /// </summary>
        [DataMember(Order = 18)]
        public ExtendedPropertyCollection ExtendedProperties { get; private set; }
    }
}
