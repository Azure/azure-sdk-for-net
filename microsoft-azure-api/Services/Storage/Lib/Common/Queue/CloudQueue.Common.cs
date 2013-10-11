// -----------------------------------------------------------------------------------------
// <copyright file="CloudQueue.Common.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Auth;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// This class represents a queue in the Windows Azure Queue service.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1711:IdentifiersShouldNotHaveIncorrectSuffix", Justification = "Reviewed.")]
    public sealed partial class CloudQueue
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="queueAddress">The absolute URI to the queue.</param>
        public CloudQueue(Uri queueAddress)
            : this(queueAddress, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="queueAddress">The absolute URI to the queue.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudQueue(Uri queueAddress, StorageCredentials credentials)
        {
            this.ParseQueryAndVerify(queueAddress, credentials);
            this.Metadata = new Dictionary<string, string>();
            this.EncodeMessage = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="queueName">The queue name.</param>
        /// <param name="serviceClient">A client object that specifies the endpoint for the queue service.</param>
        internal CloudQueue(string queueName, CloudQueueClient serviceClient)
        {
            this.Uri = NavigationHelper.AppendPathToUri(serviceClient.BaseUri, queueName);
            this.ServiceClient = serviceClient;
            this.Name = queueName;
            this.Metadata = new Dictionary<string, string>();
            this.EncodeMessage = true;
        }

        /// <summary>
        /// Gets the service client for the queue.
        /// </summary>
        /// <value>A client object that specifies the endpoint for the queue service.</value>
        public CloudQueueClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the queue's URI.
        /// </summary>
        /// <value>The absolute URI to the queue.</value>
        public Uri Uri { get; private set; }

        /// <summary>
        /// Gets the name of the queue.
        /// </summary>
        /// <value>The queue's name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the approximate message count for the queue.
        /// </summary>
        /// <value>The approximate message count.</value>
        public int? ApproximateMessageCount { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply base64 encoding when adding or retrieving messages.
        /// </summary>
        /// <value><c>True</c> to encode messages; otherwise, <c>false</c>. The default value is <c>true</c>.</value>
        public bool EncodeMessage { get; set; }

        /// <summary>
        /// Gets the queue's metadata.
        /// </summary>
        /// <value>The queue's metadata.</value>
        public IDictionary<string, string> Metadata { get; private set; }

        /// <summary>
        /// Uri for the messages.
        /// </summary>
        private Uri messageRequestAddress;

        /// <summary>
        /// Gets the Uri for general message operations.
        /// </summary>
        internal Uri GetMessageRequestAddress()
        {
            if (this.messageRequestAddress == null)
            {
                this.messageRequestAddress = NavigationHelper.AppendPathToUri(this.Uri, Constants.Messages);
            }

            return this.messageRequestAddress;
        }

        /// <summary>
        /// Gets the individual message address.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <returns>The URI of the message.</returns>
        internal Uri GetIndividualMessageAddress(string messageId)
        {
            Uri individualMessageUri = NavigationHelper.AppendPathToUri(this.GetMessageRequestAddress(), messageId);

            return individualMessageUri;
        }

        /// <summary>
        /// Parse URI for SAS (Shared Access Signature) information.
        /// </summary>
        /// <param name="address">The complete Uri.</param>
        /// <param name="credentials">The credentials to use.</param>
        private void ParseQueryAndVerify(Uri address, StorageCredentials credentials)
        {
            StorageCredentials parsedCredentials;
            this.Uri = NavigationHelper.ParseQueueTableQueryAndVerify(address, out parsedCredentials);

            if ((parsedCredentials != null) && (credentials != null) && !parsedCredentials.Equals(credentials))
            {
                string error = string.Format(CultureInfo.CurrentCulture, SR.MultipleCredentialsProvided);
                throw new ArgumentException(error);
            }

            this.ServiceClient = new CloudQueueClient(NavigationHelper.GetServiceClientBaseAddress(this.Uri, null), credentials ?? parsedCredentials);
            this.Name = NavigationHelper.GetQueueNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Returns the canonical name for shared access.
        /// </summary>
        /// <returns>The canonical name.</returns>
        private string GetCanonicalName()
        {
            if (this.ServiceClient.UsePathStyleUris)
            {
                return this.Uri.AbsolutePath;
            }
            else
            {
                return NavigationHelper.GetCanonicalPathFromCreds(this.ServiceClient.Credentials, this.Uri.AbsolutePath);
            }
        }

        /// <summary>
        /// Selects the get message response.
        /// </summary>
        /// <param name="protocolMessage">The protocol message.</param>
        /// <returns>The parsed message.</returns>
        private CloudQueueMessage SelectGetMessageResponse(QueueMessage protocolMessage)
        {
            CloudQueueMessage message = this.SelectPeekMessageResponse(protocolMessage);
            message.PopReceipt = protocolMessage.PopReceipt;

            if (protocolMessage.NextVisibleTime.HasValue)
            {
                message.NextVisibleTime = protocolMessage.NextVisibleTime.Value;
            }

            return message;
        }

        /// <summary>
        /// Selects the peek message response.
        /// </summary>
        /// <param name="protocolMessage">The protocol message.</param>
        /// <returns>The parsed message.</returns>
        private CloudQueueMessage SelectPeekMessageResponse(QueueMessage protocolMessage)
        {
            CloudQueueMessage message = null;
            if (this.EncodeMessage)
            {
                // if EncodeMessage is true, we assume the string returned from server is Base64 encoding of original message;
                // if this is not true, exception will likely be thrown.
                // it is user's responsibility to make sure EncodeMessage setting matches the queue that is being read.
                message = new CloudQueueMessage(protocolMessage.Text, true);
            }
            else
            {
                message = new CloudQueueMessage(protocolMessage.Text);
            }

            message.Id = protocolMessage.Id;
            message.InsertionTime = protocolMessage.InsertionTime;
            message.ExpirationTime = protocolMessage.ExpirationTime;
            message.DequeueCount = protocolMessage.DequeueCount;

            // PopReceipt and TimeNextVisible are not returned during peek
            return message;
        }

        /// <summary>
        /// Returns a shared access signature for the queue.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="accessPolicyIdentifier">A queue-level access policy.</param>
        /// <returns>A shared access signature, as a URI query string.</returns>
        /// <remarks>The query string returned includes the leading question mark.</remarks>
        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.IsSharedKey)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetCanonicalName();
            StorageAccountKey accountKey = this.ServiceClient.Credentials.Key;

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(
                policy,
                accessPolicyIdentifier,
                resourceName,
                accountKey.KeyValue);

            string accountKeyName = accountKey.KeyName;

            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(
                 policy,
                accessPolicyIdentifier,
                signature,
                accountKeyName);

            return builder.ToString();
        }
    }
}
