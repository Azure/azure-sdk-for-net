// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography
{
    internal static class EncryptionConstants
    {
        public const ClientSideEncryptionVersion CurrentVersion = ClientSideEncryptionVersion.V1_0;

        public const string AgentMetadataKey = "EncryptionLibrary";

        public const string AesCbcPkcs5Padding = "AES/CBC/PKCS5Padding";

        public const string AesCbcNoPadding = "AES/CBC/NoPadding";

        public const string Aes = "AES";

        public const string EncryptionDataKey = "encryptiondata";

        public const string EncryptionMode = "FullBlob";

        public const int EncryptionBlockSize = 16;

        public const int EncryptionKeySizeBits = 256;

        public const string XMsRange = "x-ms-range";
    }
}
