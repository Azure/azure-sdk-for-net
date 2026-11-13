// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.AI.Discovery
{
    public readonly partial struct StorageMountProtocol
    {
        /// <summary> NFS protocol. Version of NFS used may vary based on storage type. </summary>
        [CodeGenMember("NFS")]
        public static StorageMountProtocol Nfs { get; } = new StorageMountProtocol(NFSValue);
    }
}
