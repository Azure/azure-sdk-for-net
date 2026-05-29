// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HorizonDB.Models
{
    [CodeGenType("HorizonDBReplicaForPatchUpdate")]
    public partial class HorizonDBReplicaPatch
    {
        /// <summary> Role of the replica. </summary>
        [CodeGenMember("HorizonDBReplicaPropertiesForPatchUpdateRole")]
        public HorizonDBReplicaRole? Role
        {
            get
            {
                return Properties is null ? default : Properties.Role;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new HorizonDBReplicaPropertiesForPatchUpdate();
                }
                Properties.Role = value;
            }
        }
    }
}
