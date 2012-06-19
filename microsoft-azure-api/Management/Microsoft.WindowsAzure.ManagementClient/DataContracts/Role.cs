//-----------------------------------------------------------------------
// <copyright file="Role.cs" company="Microsoft">
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
//    Contains code for Role class.
// </summary>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a role in a Windows Azure deployment.
    /// </summary>
    [DataContract(Name = "Role", Namespace = AzureConstants.AzureSchemaNamespace)]
    [KnownType(typeof(PersistentVMRole))]
    public class Role : AzureDataContractBase
    {
        /// <summary>
        /// Protected default constructor for Role
        /// </summary>
        protected Role() { }

        /// <summary>
        /// The name of the role.
        /// </summary>
        [DataMember(Name = "RoleName", Order = 0, IsRequired = true)]
        public string Name { get; private set; }

        /// <summary>
        /// The version of the Windows Azure Guest Operating System 
        /// on which this role's instances are running.
        /// </summary>
        [DataMember(Order = 1, IsRequired = false, EmitDefaultValue = false)]
        public string OsVersion { get; private set; }

        /// <summary>
        /// The type of the role.
        /// </summary>
        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = false)]
        public string RoleType { get; private set; } //TODO: Enum?

        /// <summary>
        /// The list of <see cref="ConfigurationSet">ConfigurationSets</see> in this role.
        /// </summary>
        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public List<ConfigurationSet> ConfigurationSets { get; private set; }
    }

}
