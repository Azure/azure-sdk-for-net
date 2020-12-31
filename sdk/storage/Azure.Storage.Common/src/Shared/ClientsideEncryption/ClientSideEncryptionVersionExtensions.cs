// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography.Models
{
    internal static class ClientSideEncryptionVersionExtensions
    {
        public static class ClientSideEncryptionVersionString
        {
            public const string V1_0 = "1.0";
        }

        public static string Serialize(this ClientSideEncryptionVersion version)
        {
            switch (version)
            {
                case ClientSideEncryptionVersion.V1_0:
                    return ClientSideEncryptionVersionString.V1_0;
                default:
                    // sanity check; serialize is in this file to make it easy to add the serialization cases
                    throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported();
            }
        }

        public static ClientSideEncryptionVersion ToClientSideEncryptionVersion(this string versionString)
        {
            switch (versionString)
            {
                case ClientSideEncryptionVersionString.V1_0:
                    return ClientSideEncryptionVersion.V1_0;
                default:
                    // This library doesn't support the stated encryption version
                    throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported(versionString);
            }
        }
    }
}
