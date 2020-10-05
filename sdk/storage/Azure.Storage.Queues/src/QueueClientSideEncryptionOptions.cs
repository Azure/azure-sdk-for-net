// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Cryptography;

#pragma warning disable SA1402  // File may only contain a single type

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Contains Queues-specific options for client-side encryption.
    /// </summary>
    public class QueueClientSideEncryptionOptions : ClientSideEncryptionOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClientSideEncryptionOptions"/> class.
        /// </summary>
        /// <param name="version">The version of clientside encryption to use.</param>
        public QueueClientSideEncryptionOptions(ClientSideEncryptionVersion version) : base(version)
        {
        }

        /// <summary>
        /// Event when failure to decrypt a message occurs.
        /// </summary>
        public event EventHandler<ClientSideDecryptionFailureEventArgs> DecryptionFailed;

        internal bool UsingDecryptionFailureHandler => DecryptionFailed.GetInvocationList().Length > 0;

        internal void OnDecryptionFailed(object message, Exception e)
        {
            DecryptionFailed?.Invoke(message, new ClientSideDecryptionFailureEventArgs(e));
        }

        /// <summary>
        /// Clones the given <see cref="ClientSideEncryptionOptions"/> as an instance of
        /// <see cref="QueueClientSideEncryptionOptions"/>. If the given instance is also a
        /// <see cref="QueueClientSideEncryptionOptions"/>, this clones it's specialty data as well.
        /// </summary>
        /// <returns></returns>
        internal static QueueClientSideEncryptionOptions CloneFrom(ClientSideEncryptionOptions options)
        {
            if (options == default)
            {
                return default;
            }
            var newOptions = new QueueClientSideEncryptionOptions(options.EncryptionVersion);
            ClientSideEncryptionOptionsExtensions.CopyOptions(options, newOptions);
            if (options is QueueClientSideEncryptionOptions queueOptions)
            {
                newOptions.DecryptionFailed = queueOptions.DecryptionFailed;
            }
            return newOptions;
        }
    }

    /// <summary>
    /// Event args for when a queue message decryption fails.
    /// </summary>
    public class ClientSideDecryptionFailureEventArgs
    {
        /// <summary>
        /// The exception thrown.
        /// </summary>
        public Exception Exception { get; }

        internal ClientSideDecryptionFailureEventArgs(Exception exception)
        {
            Exception = exception;
        }
    }
}
