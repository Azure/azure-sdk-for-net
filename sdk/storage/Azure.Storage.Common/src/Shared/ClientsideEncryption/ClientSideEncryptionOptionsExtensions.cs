// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Storage.Cryptography
{
    internal static class ClientSideEncryptionOptionsExtensions
    {
        /// <summary>
        /// Extension method to clone an instance of <see cref="ClientSideEncryptionOptions"/>.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public static ClientSideEncryptionOptions Clone(this ClientSideEncryptionOptions options)
        {
            var newOptions = new ClientSideEncryptionOptions(options.EncryptionVersion);
            CopyOptions(options, newOptions);
            return newOptions;
        }

        /// <summary>
        /// Copies all properties from one instance to another. It cannot copy
        /// <see cref="ClientSideEncryptionOptions.EncryptionVersion"/>;
        /// that is the responsibility of the caller who made the instance.
        /// </summary>
        /// <param name="source">Object to copy from.</param>
        /// <param name="destination">Object to copy to.</param>
        /// <remarks>
        /// This functionality has been pulled out to be accessible by other
        /// clone methods available on subclasses. They need the ability to
        /// instantiate the subclass destination first before copying over the
        /// properties.
        /// </remarks>
        internal static void CopyOptions(ClientSideEncryptionOptions source, ClientSideEncryptionOptions destination)
        {
            destination.KeyEncryptionKey = source.KeyEncryptionKey;
            destination.KeyResolver = source.KeyResolver;
            destination.KeyWrapAlgorithm = source.KeyWrapAlgorithm;
        }

        public static IClientSideEncryptor GetClientSideEncryptor(this ClientSideEncryptionOptions options)
        {
            return options.EncryptionVersion switch
            {
#pragma warning disable CS0618 // obsolete
                ClientSideEncryptionVersion.V1_0 => new ClientSideEncryptorV1_0(options),
#pragma warning disable CS0618 // obsolete
                ClientSideEncryptionVersion.V2_0 => new ClientSideEncryptorV2_0(options),
                _ => throw Errors.ClientSideEncryption.ClientSideEncryptionVersionNotSupported()
            };
        }
    }
}
