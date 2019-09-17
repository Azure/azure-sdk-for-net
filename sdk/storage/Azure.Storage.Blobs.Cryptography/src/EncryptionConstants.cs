using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Storage.Blobs.Specialized.Cryptography
{
    internal class EncryptionConstants
    {
        public const string ENCRYPTION_PROTOCOL_V1 = "1.0";

        public const string AGENT_METADATA_KEY = "EncryptionLibrary";

        public const string AES_CBC_PKCS5PADDING = "AES/CBC/PKCS5Padding";

        public const string AES_CBC_NO_PADDING = "AES/CBC/NoPadding";

        public const string AES = "AES";

        public const string AGENT_METADATA_VALUE = "JavaTrack2" + ServiceConfiguration.BlobConfiguration.VERSION;

        public const string ENCRYPTION_DATA_KEY = "encryptiondata";

        public const string ENCRYPTION_MODE = "FullBlob";

        public const int ENCRYPTION_BLOCK_SIZE = 16;
    }
}
