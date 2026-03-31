// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Generator strips underscores from @@clientName targets. This member needs underscore in name to match baseline API.

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    public readonly partial struct DataBoxEdgeEncryptionAlgorithm
    {
#pragma warning disable CA1707
        /// <summary> RSAES_PKCS1_v_1_5. </summary>
        public static DataBoxEdgeEncryptionAlgorithm RsaesPkcs1V1_5 { get; } = new DataBoxEdgeEncryptionAlgorithm("RSAES_PKCS1_v_1_5");
#pragma warning restore CA1707
    }
}
