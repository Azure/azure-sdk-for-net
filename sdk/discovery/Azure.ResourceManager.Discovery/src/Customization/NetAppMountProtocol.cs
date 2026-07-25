// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Discovery.Models
{
    /// <summary> The protocol used to mount the NetApp Files storage. </summary>
    public readonly partial struct NetAppMountProtocol
    {
        /// <summary> NFS protocol. Version of NFS used may vary based on storage type. </summary>
        [CodeGenMember("NFS")]
        public static NetAppMountProtocol Nfs { get; } = new NetAppMountProtocol(NFSValue);
    }
}
