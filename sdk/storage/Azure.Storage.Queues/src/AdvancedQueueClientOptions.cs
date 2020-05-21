// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Storage.Queues.Models;

namespace Azure.Storage.Queues.Specialized
{
    /// <summary>
    /// Provides advanced client configuration options for connecting to Azure Queue
    /// Storage.
    /// </summary>
#pragma warning disable AZC0008 // ClientOptions should have a nested enum called ServiceVersion; This is an extension of existing public options that obey this.
    public class AdvancedQueueClientOptions : QueueClientOptions
#pragma warning restore AZC0008 // ClientOptions should have a nested enum called ServiceVersion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueueClientOptions"/>
        /// class.
        /// </summary>
        /// <param name="version">
        /// The <see cref="QueueClientOptions.ServiceVersion"/> of the service API used when
        /// making requests.
        /// </param>
        public AdvancedQueueClientOptions(ServiceVersion version = LatestVersion) : base(version)
        {
        }

        /// <summary>
        /// Settings for data encryption within the SDK. Client-side encryption adds metadata to your queue
        /// messages which is necessary to maintain for decryption.
        ///
        /// For more information, see <a href="https://docs.microsoft.com/en-us/azure/storage/common/storage-client-side-encryption"/>.
        /// </summary>
        public ClientSideEncryptionOptions ClientSideEncryption
        {
            get => _clientSideEncryptionOptions;
            set => _clientSideEncryptionOptions = value;
        }

        /// <summary>
        /// Behavior when receiving a queue message that cannot be decrypted due to lack of key access.
        /// Messages in the list of results that cannot be decrypted will be filtered out of the list and
        /// sent to this listener. Default behavior, when no listener is provided, is for the overall message
        /// fetch to throw.
        /// </summary>
        public IClientSideDecryptionFailureListener OnClientSideDecryptionFailure
        {
            get => _onClientSideDecryptionFailure;
            set => _onClientSideDecryptionFailure = value;
        }
    }

    /// <summary>
    /// Describes a listener to handle queue messages who's client-side encryption keys cannot be resolved.
    /// </summary>
    public interface IClientSideDecryptionFailureListener
    {
        /// <summary>
        /// Handle a decryption failure in a <see cref="QueueClient.ReceiveMessages()"/> call.
        /// </summary>
        /// <param name="message">Message that couldn't be decrypted.</param>
        /// <param name="exception">Exception of the failure.</param>
        void OnFailure(QueueMessage message, Exception exception);

        /// <summary>
        /// Handle a decryption failure in a <see cref="QueueClient.ReceiveMessagesAsync()"/> call.
        /// </summary>
        /// <param name="message">Message that couldn't be decrypted.</param>
        /// <param name="exception">Exception of the failure.</param>
        Task OnFailureAsync(QueueMessage message, Exception exception);

        /// <summary>
        /// Handle a decryption failure in a <see cref="QueueClient.PeekMessages(int?, System.Threading.CancellationToken)"/> call.
        /// </summary>
        /// <param name="message">Message that couldn't be decrypted.</param>
        /// <param name="exception">Exception of the failure.</param>
        void OnFailure(PeekedMessage message, Exception exception);

        /// <summary>
        /// Handle a decryption failure in a <see cref="QueueClient.PeekMessagesAsync(int?, System.Threading.CancellationToken)"/> call.
        /// </summary>
        /// <param name="message">Message that couldn't be decrypted.</param>
        /// <param name="exception">Exception of the failure.</param>
        Task OnFailureAsync(PeekedMessage message, Exception exception);
    }
}
