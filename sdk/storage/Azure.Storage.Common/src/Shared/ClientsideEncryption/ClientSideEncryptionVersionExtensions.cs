// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.Cryptography.Models
{
    internal static class ClientSideEncryptionVersionExtensions
    {
        public static class ClientSideEncryptionVersionString
        {
            public const string V1_0 = "1.0";
            public const string V2_0 = "2.0";
            public const string V2_1 = "2.1";
        }

        public static string Serialize(this ClientSideEncryptionVersionInternal version)
        {
            switch (version)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V1_0:
                    return ClientSideEncryptionVersionString.V1_0;
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionInternal.V2_0:
                    return ClientSideEncryptionVersionString.V2_0;
                case ClientSideEncryptionVersionInternal.V2_1:
                    return ClientSideEncryptionVersionString.V2_1;
                default:
                    // sanity check; serialize is in this file to make it easy to add the serialization cases
                    throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported();
            }
        }

        public static ClientSideEncryptionVersionInternal ToClientSideEncryptionVersion(this string versionString)
        {
            switch (versionString)
            {
#pragma warning disable CS0618 // obsolete
                case ClientSideEncryptionVersionString.V1_0:
                    return ClientSideEncryptionVersionInternal.V1_0;
#pragma warning restore CS0618 // obsolete
                case ClientSideEncryptionVersionString.V2_0:
                    return ClientSideEncryptionVersionInternal.V2_0;
                case ClientSideEncryptionVersionString.V2_1:
                    return ClientSideEncryptionVersionInternal.V2_1;
                default:
                    // This library doesn't support the stated encryption version
                    throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported(versionString);
            }
        }
    }

    internal enum ClientSideEncryptionVersionInternal
    {
        /// <summary>
        /// 1.0.
        /// </summary>
        V1_0 = 1,

        /// <summary>
        /// 2.0.
        /// </summary>
        V2_0 = 2,

        /// <summary>
        /// 2.1.
        /// </summary>
        V2_1 = 21
    }
}
