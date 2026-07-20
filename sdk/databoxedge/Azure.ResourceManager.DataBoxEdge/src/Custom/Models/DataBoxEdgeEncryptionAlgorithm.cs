// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generator strips underscores from @@clientName targets. This member needs underscore in name to match baseline API.
// [CodeGenMember] renames the generated member (RsaesPkcs1V15 → RsaesPkcs1V1_5) to avoid a duplicate API member.

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public readonly partial struct DataBoxEdgeEncryptionAlgorithm
    {
#pragma warning disable CA1707
        /// <summary> RSAES_PKCS1_v_1_5. </summary>
        [CodeGenMember("RsaesPkcs1V15")]
        public static DataBoxEdgeEncryptionAlgorithm RsaesPkcs1V1_5 { get; } = new DataBoxEdgeEncryptionAlgorithm("RSAES_PKCS1_v_1_5");
#pragma warning restore CA1707
    }
}
