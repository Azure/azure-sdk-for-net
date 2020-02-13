// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized
{
    internal static class EncryptionConstants
    {
        public const string EncryptionProtocolV1 = "1.0";

        public const string AgentMetadataKey = "EncryptionLibrary";

        public const string AesCbcPkcs5Padding = "AES/CBC/PKCS5Padding";

        public const string AesCbcNoPadding = "AES/CBC/NoPadding";

        public const string Aes = "AES";

        public const string EncryptionDataKey = "encryptiondata";

        public const string EncryptionMode = "FullBlob";

        public const int EncryptionBlockSize = 16;

        public const int EncryptionKeySizeBits = 256;

        public const int DefaultRollingBufferSize = 10 * Constants.MB;

        public const string XMsRange = "x-ms-range";
    }
}
