// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    internal class EncryptionConstants
    {
        public const string ENCRYPTION_PROTOCOL_V1 = "1.0";

        public const string AGENT_METADATA_KEY = "EncryptionLibrary";

        public const string AES_CBC_PKCS5PADDING = "AES/CBC/PKCS5Padding";

        public const string AES_CBC_NO_PADDING = "AES/CBC/NoPadding";

        public const string AES = "AES";

        public const string AGENT_METADATA_VALUE = ".NETTrack22019-02-02"; // TODO determine proper value

        public const string ENCRYPTION_DATA_KEY = "encryptiondata";

        public const string ENCRYPTION_MODE = "FullBlob";

        public const int ENCRYPTION_BLOCK_SIZE = 16;

        public const int ENCRYPTION_KEY_SIZE = 256;
    }
}
