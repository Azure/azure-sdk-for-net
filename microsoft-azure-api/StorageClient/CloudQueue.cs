//-----------------------------------------------------------------------
// <copyright file="CloudQueue.cs" company="Microsoft">
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
// <summary>
//    Contains code for the CloudQueue class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using Protocol;
    using Tasks;
    using TaskSequence = System.Collections.Generic.IEnumerable<Microsoft.WindowsAzure.StorageClient.Tasks.ITask>;

    /// <summary>
    /// Represents a Windows Azure queue.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage(
        "Microsoft.Naming",
        "CA1711:IdentifiersShouldNotHaveIncorrectSuffix",
        Justification = "This is a queue")]
    public class CloudQueue
    {
        /// <summary>
        /// Stores the queue attributes.
        /// </summary>
        private readonly QueueAttributes attributes;

        /// <summary>
        /// Uri for the messages.
        /// </summary>
        private Uri messageRequestAddress;

        /// <summary>
        /// Stores the queue's transformed address.
        /// </summary>
        private Uri transformedAddress;

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="address">The absolute URI to the queue.</param>
        /// <param name="credentials">The account credentials.</param>
        public CloudQueue(string address, StorageCredentials credentials)
            : this(null, address, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="address">The relative address.</param>
        /// <param name="credentials">The storage account credentials.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c>, use path style Uris.</param>
        internal CloudQueue(string address, StorageCredentials credentials, bool usePathStyleUris)
            : this(usePathStyleUris, address, credentials)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="address">The address.</param>
        /// <param name="credentials">The credentials.</param>
        internal CloudQueue(bool? usePathStyleUris, string address, StorageCredentials credentials)
        {
            CommonUtils.AssertNotNullOrEmpty("address", address);
            CommonUtils.AssertNotNull("credentials", credentials);

            this.EncodeMessage = true;
            this.attributes = new QueueAttributes() { Uri = new Uri(address) };

            string baseAddress = NavigationHelper.GetServiceClientBaseAddress(this.Uri, usePathStyleUris);

            this.ServiceClient = new CloudQueueClient(baseAddress, credentials);
            this.Name = NavigationHelper.GetQueueNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="queueAddress">The queue address.</param>
        /// <param name="client">The client.</param>
        internal CloudQueue(Uri queueAddress, CloudQueueClient client)
        {
            CommonUtils.AssertNotNull("queueAddress", queueAddress);
            CommonUtils.AssertNotNull("client", client);

            this.EncodeMessage = true;
            this.attributes = new QueueAttributes() { Uri = queueAddress };
            this.ServiceClient = client;

            this.Name = NavigationHelper.GetQueueNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CloudQueue"/> class.
        /// </summary>
        /// <param name="attributes">The attributes of the queue.</param>
        /// <param name="client">The client.</param>
        internal CloudQueue(QueueAttributes attributes, CloudQueueClient client)
        {
            CommonUtils.AssertNotNull("attributes", attributes);
            CommonUtils.AssertNotNull("client", client);

            this.EncodeMessage = true;
            this.attributes = attributes;
            this.ServiceClient = client;

            this.Name = NavigationHelper.GetQueueNameFromUri(this.Uri, this.ServiceClient.UsePathStyleUris);
        }

        /// <summary>
        /// Gets the <see cref="CloudQueueClient"/> object that represents the Queue service.
        /// </summary>
        /// <value>A client object that specifies the Queue service endpoint.</value>
        public CloudQueueClient ServiceClient { get; private set; }

        /// <summary>
        /// Gets the queue name.
        /// </summary>
        /// <value>The queue name.</value>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the URI that identifies the queue.
        /// </summary>
        /// <value>The address of the queue.</value>
        public Uri Uri
        {
            get
            {
                return this.attributes.Uri;
            }
        }

        /// <summary>
        /// Gets the queue's attributes.
        /// </summary>
        /// <value>The queue's attributes.</value>
        public QueueAttributes Attributes
        {
            get
            {
                return this.attributes;
            }
        }

        /// <summary>
        /// Gets the queue's user-defined metadata.
        /// </summary>
        /// <value>The queue's user-defined metadata.</value>
        public NameValueCollection Metadata
        {
            get
            {
                return this.attributes.Metadata;
            }

            internal set
            {
                this.attributes.Metadata = value;
            }
        }

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
        /// Gets the Uri for general message operations.
        /// </summary>
        internal Uri MessageRequestAddress
        {
            get
            {
                if (this.messageRequestAddress == null)
                {
                    this.messageRequestAddress = NavigationHelper.AppendPathToUri(this.TransformedAddress, Constants.Messages);
                }

                return this.messageRequestAddress;
            }
        }

        /// <summary>
        /// Gets the Uri after applying authentication transformation.
        /// </summary>
        internal Uri TransformedAddress
        {
            get
            {
                if (this.ServiceClient.Credentials.NeedsTransformUri)
                {
                    // This is required to support key rotation
                    // Potential improvement: cache the value of credential and derived Uri to avoid recomputation
                    this.transformedAddress = new Uri(this.ServiceClient.Credentials.TransformUri(this.Uri.AbsoluteUri));

                    return this.transformedAddress;
                }
                else
                {
                    return this.Uri;
                }
            }
        }

        /// <summary>
        /// Creates a queue.
        /// </summary>
        public void Create()
        {
            TaskImplHelper.ExecuteImplWithRetry(this.CreateImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreate(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(this.CreateImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create a queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndCreate(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Creates the queue if it does not exist.
        /// </summary>
        /// <returns><c>true</c> if the queue did not exist and was created; otherwise <c>false</c>.</returns>
        public bool CreateIfNotExist()
        {
            return TaskImplHelper.ExecuteImplWithRetry<bool>(
                (setResult) => this.CreateIfNotExistImpl(setResult),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to create the queue if it does not exist.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginCreateIfNotExist(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<bool>(
                (setResult) => this.CreateIfNotExistImpl(setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to create the queue if it does not exist.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>Returns <c>true</c> if the creation succeeded; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndCreateIfNotExist(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<bool>(asyncResult);
        }

        /// <summary>
        /// Deletes the queue.
        /// </summary>
        public void Delete()
        {
            TaskImplHelper.ExecuteImplWithRetry(this.DeleteImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete the queue. 
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDelete(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(this.DeleteImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation")]
        public void EndDelete(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Determines if the queue exists.
        /// </summary>
        /// <returns><c>True</c> if the queue exists; otherwise <c>false</c>.</returns>
        public bool Exists()
        {
            return TaskImplHelper.ExecuteImplWithRetry<bool>(this.ExistsImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to determine whether the queue exists.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginExists(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<bool>(this.ExistsImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to determine whether the queue exists.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>Returns <c>true</c> if the queue exists; otherwise, <c>false</c>.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public bool EndExists(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<bool>(asyncResult);
        }

        /// <summary>
        /// Fetches the queue's attributes.
        /// </summary>
        public void FetchAttributes()
        {
            TaskImplHelper.ExecuteImplWithRetry(this.FetchAttributesImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginFetchAttributes(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(this.FetchAttributesImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to fetch the queue's attributes.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndFetchAttributes(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Sets the queue's metadata.
        /// </summary>
        public void SetMetadata()
        {
            TaskImplHelper.ExecuteImplWithRetry(this.SetMetadataImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to set the queue's metadata.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetMetadata(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(this.SetMetadataImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to set the queue's metadata.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndSetMetadata(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Retrieves the approximate message count for the queue. This method fetches
        /// the value from the server and updates the <see cref="ApproximateMessageCount"/>
        /// property as well.
        /// </summary>
        /// <returns>The approximate message count.</returns>
        public int RetrieveApproximateMessageCount()
        {
            this.FetchAttributes();

            return this.ApproximateMessageCount.Value;
        }

        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        public void AddMessage(CloudQueueMessage message)
        {
            CommonUtils.AssertNotNull("message", message);
            TaskImplHelper.ExecuteImplWithRetry(() => this.AddMessageImpl(message, null, null), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue.</param>
        public void AddMessage(CloudQueueMessage message, TimeSpan timeToLive)
        {
            CommonUtils.AssertNotNull("message", message);
            TaskImplHelper.ExecuteImplWithRetry(() => this.AddMessageImpl(message, timeToLive, null), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If null then the message will be visible immediately.</param>
        public void AddMessage(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay)
        {
            CommonUtils.AssertNotNull("message", message);
            TaskImplHelper.ExecuteImplWithRetry(() => this.AddMessageImpl(message, timeToLive, initialVisibilityDelay), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAddMessage(CloudQueueMessage message, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("message", message);
            return TaskImplHelper.BeginImplWithRetry(() => this.AddMessageImpl(message, null, null), this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAddMessage(CloudQueueMessage message, TimeSpan timeToLive, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("message", message);
            return TaskImplHelper.BeginImplWithRetry(() => this.AddMessageImpl(message, timeToLive, null), this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If null then the message will be visible immediately.</param>        
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginAddMessage(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("message", message);
            return TaskImplHelper.BeginImplWithRetry(() => this.AddMessageImpl(message, timeToLive, initialVisibilityDelay), this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to add a message to the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndAddMessage(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Gets a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>An enumerable collection of messages.</returns>
        public IEnumerable<CloudQueueMessage> GetMessages(int messageCount)
        {
            return this.GetMessagesInternal(messageCount, null);
        }

        /// <summary>
        /// Gets a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <returns>An enumerable collection of messages.</returns>
        public IEnumerable<CloudQueueMessage> GetMessages(int messageCount, TimeSpan visibilityTimeout)
        {
            return this.GetMessagesInternal(messageCount, visibilityTimeout);
        }

        /// <summary>
        /// Begins an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetMessages(int messageCount, AsyncCallback callback, object state)
        {
            return this.BeginGetMessagesInternal(messageCount, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetMessages(int messageCount, TimeSpan visibilityTimeout, AsyncCallback callback, object state)
        {
            return this.BeginGetMessagesInternal(messageCount, visibilityTimeout, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public IEnumerable<CloudQueueMessage> EndGetMessages(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<IEnumerable<CloudQueueMessage>>(asyncResult);
        }

        /// <summary>
        /// Gets a single message from the queue.
        /// </summary>
        /// <returns>A message.</returns>
        public CloudQueueMessage GetMessage()
        {
            return this.GetMessageInternal(null);
        }

        /// <summary>
        /// Gets a single message from the queue.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <returns>A message.</returns>
        public CloudQueueMessage GetMessage(TimeSpan visibilityTimeout)
        {
            return this.GetMessageInternal(visibilityTimeout);
        }

        /// <summary>
        /// Begins an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetMessage(AsyncCallback callback, object state)
        {
            return this.BeginGetMessagesInternal(1, null, callback, state);
        }

        /// <summary>
        /// Begins an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetMessage(TimeSpan visibilityTimeout, AsyncCallback callback, object state)
        {
            return this.BeginGetMessagesInternal(1, visibilityTimeout, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to get a single message from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A message.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public CloudQueueMessage EndGetMessage(IAsyncResult asyncResult)
        {
            var resultList = TaskImplHelper.EndImplWithRetry<IEnumerable<CloudQueueMessage>>(asyncResult);

            return resultList.FirstOrDefault();
        }

        /// <summary>
        /// Peeks a message from the queue.
        /// </summary>
        /// <returns>A message.</returns>
        public CloudQueueMessage PeekMessage()
        {
            IEnumerable<CloudQueueMessage> peekedMessages = TaskImplHelper.ExecuteImplWithRetry<IEnumerable<CloudQueueMessage>>(
                (setResult) => this.PeekMessagesImpl(1, setResult),
                this.ServiceClient.RetryPolicy);

            return peekedMessages.FirstOrDefault();
        }

        /// <summary>
        /// Begins an asynchronous operation to peek a message from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPeekMessage(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<IEnumerable<CloudQueueMessage>>(
                (setResult) => this.PeekMessagesImpl(1, setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to peek a message from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>A message.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public CloudQueueMessage EndPeekMessage(IAsyncResult asyncResult)
        {
            var resultList = TaskImplHelper.EndImplWithRetry<IEnumerable<CloudQueueMessage>>(asyncResult);
            return resultList.FirstOrDefault();
        }

        /// <summary>
        /// Peeks a set of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>A enumerable collection of messages.</returns>
        public IEnumerable<CloudQueueMessage> PeekMessages(int messageCount)
        {
            return TaskImplHelper.ExecuteImplWithRetry<IEnumerable<CloudQueueMessage>>(
                (setResult) => this.PeekMessagesImpl(messageCount, setResult),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to peek a set of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginPeekMessages(int messageCount, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<IEnumerable<CloudQueueMessage>>(
                (setResult) => this.PeekMessagesImpl(messageCount, setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to peek a set of messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public IEnumerable<CloudQueueMessage> EndPeekMessages(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImplWithRetry<IEnumerable<CloudQueueMessage>>(asyncResult);
        }

        /// <summary>
        /// Deletes a message.
        /// </summary>
        /// <param name="message">A message.</param>
        public void DeleteMessage(CloudQueueMessage message)
        {
            CommonUtils.AssertNotNull("message", message);

            TaskImplHelper.ExecuteImplWithRetry(
                () => this.DeleteMessageImpl(message.Id, message.PopReceipt),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Deletes a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        public void DeleteMessage(string messageId, string popReceipt)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.DeleteMessageImpl(messageId, popReceipt), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="message">A message.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteMessage(CloudQueueMessage message, AsyncCallback callback, object state)
        {
            CommonUtils.AssertNotNull("message", message);

            return TaskImplHelper.BeginImplWithRetry(
                () => this.DeleteMessageImpl(message.Id, message.PopReceipt),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Begins an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginDeleteMessage(string messageId, string popReceipt, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(
                () => this.DeleteMessageImpl(messageId, popReceipt),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to delete a message.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndDeleteMessage(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Updates the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The length of time from now during which the message will be invisible.</param>
        /// <param name="updateFields">Flags indicating which parts of the message are to be updated. This must include the Visibility flag.</param>
        public void UpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
        {
            TaskImplHelper.ExecuteImplWithRetry(
                () => this.UpdateMessageImpl(message, visibilityTimeout, updateFields),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to update the visibility timeout and optionally the content of a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The length of time from now during which the message will be invisible.</param>
        /// <param name="updateFields">Flags indicating which parts of the message are to be updated. This must include the Visibility flag.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginUpdateMessage(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(
                () => this.UpdateMessageImpl(message, visibilityTimeout, updateFields),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Ends an asynchronous operation to update the visibility timeout and possibly the contents of a message.
        /// </summary>
        /// <param name="asyncResult">The <c>IAsyncResult</c> returned from a prior call to <see cref="BeginUpdateMessage"/>.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndUpdateMessage(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Clears all messages from the queue.
        /// </summary>
        public void Clear()
        {
            TaskImplHelper.ExecuteImplWithRetry(this.ClearMessagesImpl, this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginClear(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(this.ClearMessagesImpl, this.ServiceClient.RetryPolicy, callback, state);
        }

        /// <summary>
        /// Ends an asynchronous operation to clear all messages from the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "This is a member-operation")]
        public void EndClear(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImplWithRetry(asyncResult);
        }

        /// <summary>
        /// Gets the permissions settings for the queue.
        /// </summary>
        /// <returns>The queue's permissions.</returns>
        public QueuePermissions GetPermissions()
        {
            return TaskImplHelper.ExecuteImplWithRetry<QueuePermissions>(
                (setResult) => this.GetPermissionsImpl(setResult),
                this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginGetPermissions(AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<QueuePermissions>(
                (setResult) => this.GetPermissionsImpl(setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the asynchronous result of the request to get the permissions settings for the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        /// <returns>The queue's permissions.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public QueuePermissions EndGetPermissions(IAsyncResult asyncResult)
        {
            return TaskImplHelper.EndImpl<QueuePermissions>(asyncResult);
        }

        /// <summary>
        /// Sets permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        public void SetPermissions(QueuePermissions permissions)
        {
            TaskImplHelper.ExecuteImplWithRetry(() => this.SetPermissionsImpl(permissions), this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An <see cref="IAsyncResult"/> that references the asynchronous operation.</returns>
        public IAsyncResult BeginSetPermissions(QueuePermissions permissions, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry(
                () => this.SetPermissionsImpl(permissions),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Returns the result of an asynchronous request to set permissions for the queue.
        /// </summary>
        /// <param name="asyncResult">An <see cref="IAsyncResult"/> that references the pending asynchronous operation.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This is a member-operation.")]
        public void EndSetPermissions(IAsyncResult asyncResult)
        {
            TaskImplHelper.EndImpl(asyncResult);
        }

        /// <summary>
        /// Returns a shared access signature for the queue.
        /// </summary>
        /// <param name="policy">The access policy for the shared access signature.</param>
        /// <param name="accessPolicyIdentifier">An access policy identifier.</param>
        /// <returns>A shared access signature.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the current credentials don't support creating a shared access signature.</exception>
        public string GetSharedAccessSignature(SharedAccessQueuePolicy policy, string accessPolicyIdentifier)
        {
            if (!this.ServiceClient.Credentials.CanSignRequest)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASWithoutAccountKey);
                throw new InvalidOperationException(errorMessage);
            }

            string resourceName = this.GetCanonicalName();

            string signature = SharedAccessSignatureHelper.GetSharedAccessSignatureHashImpl(policy, accessPolicyIdentifier, resourceName, this.ServiceClient);

            string accountKeyName = null;

            if (this.ServiceClient.Credentials is StorageCredentialsAccountAndKey)
            {
                accountKeyName = (this.ServiceClient.Credentials as StorageCredentialsAccountAndKey).AccountKeyName;
            }

            UriQueryBuilder builder = SharedAccessSignatureHelper.GetSharedAccessSignatureImpl(policy, accessPolicyIdentifier, signature, accountKeyName);

            return builder.ToString();
        }

        /// <summary>
        /// Gets the individual message address.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <returns>The Uri of the message.</returns>
        internal Uri GetIndividualMessageAddress(string messageId)
        {
            Uri individualMessageUri = NavigationHelper.AppendPathToUri(this.Uri, Constants.Messages + NavigationHelper.Slash + messageId);

            if (this.ServiceClient.Credentials.NeedsTransformUri)
            {
                return new Uri(this.ServiceClient.Credentials.TransformUri(individualMessageUri.AbsoluteUri));
            }
            else
            {
                return individualMessageUri;
            }
        }

        /// <summary>
        /// Materialize results so that we can close the response object.
        /// </summary>
        /// <param name="protocolList">List of response objects from the Protocol layer.</param>
        /// <param name="responseProjector">Projection function.</param>
        /// <returns>A materialized list of messages.</returns>
        private static IEnumerable<CloudQueueMessage> MaterializeAndParseResponse(IEnumerable<QueueMessage> protocolList, Func<QueueMessage, CloudQueueMessage> responseProjector)
        {
            List<CloudQueueMessage> messages = new List<CloudQueueMessage>();
            messages.AddRange(protocolList.Select(responseProjector));
            return messages;
        }

        /// <summary>
        /// Gets the canonical name of the queue, formatted as /&lt;account-name&gt;/&lt;queue-name&gt;.
        /// </summary>
        /// <returns>The canonical name of the queue.</returns>
        private string GetCanonicalName()
        {
            string accountName = this.ServiceClient.Credentials.AccountName;
            string queueName = this.Name;

            return string.Format("/{0}/{1}", accountName, queueName);
        }

        /// <summary>
        /// Selects the get message response.
        /// </summary>
        /// <param name="protocolMessage">The protocol message.</param>
        /// <returns>The parsed message.</returns>
        private CloudQueueMessage SelectGetMessageResponse(QueueMessage protocolMessage)
        {
            var message = this.SelectPeekMessageResponse(protocolMessage);
            message.PopReceipt = protocolMessage.PopReceipt;

            if (protocolMessage.TimeNextVisible.HasValue)
            {
                message.NextVisibleTime = protocolMessage.TimeNextVisible.Value;
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
        /// Gets the message internal.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <returns>The retrieved message.</returns>
        private CloudQueueMessage GetMessageInternal(TimeSpan? visibilityTimeout)
        {
            IEnumerable<CloudQueueMessage> messages = this.GetMessagesInternal(1, visibilityTimeout);

            return messages.FirstOrDefault();
        }

        /// <summary>
        /// Gets the messages internal.
        /// </summary>
        /// <param name="numberOfMessages">The number of messages.</param>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <returns>A list of retrieved messages.</returns>
        private IEnumerable<CloudQueueMessage> GetMessagesInternal(int? numberOfMessages, TimeSpan? visibilityTimeout)
        {
            return TaskImplHelper.ExecuteImplWithRetry<IEnumerable<CloudQueueMessage>>(
               (setResult) => this.GetMessagesImpl(numberOfMessages, visibilityTimeout, setResult),
               this.ServiceClient.RetryPolicy);
        }

        /// <summary>
        /// Begins the get messages internal.
        /// </summary>
        /// <param name="numberOfMesages">The number of mesages.</param>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <param name="callback">The callback delegate that will receive notification when the asynchronous operation completes.</param>
        /// <param name="state">A user-defined object that will be passed to the callback delegate.</param>
        /// <returns>An asynchronous result that represents the operation.</returns>
        private IAsyncResult BeginGetMessagesInternal(int? numberOfMesages, TimeSpan? visibilityTimeout, AsyncCallback callback, object state)
        {
            return TaskImplHelper.BeginImplWithRetry<IEnumerable<CloudQueueMessage>>(
                (setResult) => this.GetMessagesImpl(numberOfMesages, visibilityTimeout, setResult),
                this.ServiceClient.RetryPolicy,
                callback,
                state);
        }

        /// <summary>
        /// Existses the impl.
        /// </summary>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that detects whether the queue exists.</returns>
        private TaskSequence ExistsImpl(Action<bool> setResult)
        {
            var webRequest = QueueRequest.GetMetadata(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            try
            {
                // Materialize exceptions
                using (var webResponse = task.Result as HttpWebResponse)
                {
                    setResult(true);
                }
            }
            catch (StorageClientException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    setResult(false);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Sets the metadata impl.
        /// </summary>
        /// <returns>A <see cref="TaskSequence"/> that sets the metadata.</returns>
        private TaskSequence SetMetadataImpl()
        {
            var webRequest = QueueRequest.SetMetadata(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            QueueRequest.AddMetadata(webRequest, this.Metadata);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Fetches the metadata and properties impl.
        /// </summary>
        /// <returns>A <see cref="TaskSequence"/> that fetches the attributes.</returns>
        private TaskSequence FetchAttributesImpl()
        {
            var webRequest = QueueRequest.GetMetadata(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                this.GetPropertiesAndMetadataFromResponse(webResponse);
            }
        }

        /// <summary>
        /// Creates the impl.
        /// </summary>
        /// <returns>A <see cref="TaskSequence"/> that creates the queue.</returns>
        private TaskSequence CreateImpl()
        {
            var webRequest = QueueRequest.Create(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            QueueRequest.AddMetadata(webRequest, this.Metadata);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Creates if not exist impl.
        /// </summary>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that creates the queue if it doesn't exist.</returns>
        private TaskSequence CreateIfNotExistImpl(Action<bool> setResult)
        {
            var webRequest = QueueRequest.Create(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            QueueRequest.AddMetadata(webRequest, this.Metadata);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            try
            {
                // Materialize exceptions
                using (var webResponse = task.Result as HttpWebResponse)
                {
                    if (webResponse.StatusCode != HttpStatusCode.NoContent)
                    {
                        setResult(true);

                        this.GetPropertiesAndMetadataFromResponse(webResponse);
                    }
                    else
                    {
                        setResult(false);
                    }
                }
            }
            catch (StorageClientException e)
            {
                if (e.StatusCode == HttpStatusCode.Conflict && e.ExtendedErrorInformation.ErrorCode == QueueErrorCodeStrings.QueueAlreadyExists)
                {
                    setResult(false);
                }
                else
                {
                    throw;
                }
            }
        }

        /// <summary>
        /// Deletes the impl.
        /// </summary>
        /// <returns>A <see cref="TaskSequence"/> that deletes the queue.</returns>
        private TaskSequence DeleteImpl()
        {
            var webRequest = QueueRequest.Delete(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Clears the messages impl.
        /// </summary>
        /// <returns>A <see cref="TaskSequence"/> that clears the messages in the queue.</returns>
        private TaskSequence ClearMessagesImpl()
        {
            var webRequest = QueueRequest.ClearMessages(this.MessageRequestAddress, this.ServiceClient.Timeout.RoundUpToSeconds());
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);

            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Generates a task sequence for adding a message to the queue.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="timeToLive">The time to live.</param>
        /// <param name="initialVisibilityDelay">The initial visibility delay.</param>
        /// <returns>A <see cref="TaskSequence"/> that adds the message.</returns>
        private TaskSequence AddMessageImpl(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay)
        {
            int? timeToLiveInSec = null;
            int? initialVisibilityDelayInSec = null;

            if (timeToLive != null)
            {
                CommonUtils.AssertInBounds<TimeSpan>("timeToLive", timeToLive.Value, TimeSpan.Zero, CloudQueueMessage.MaxTimeToLive);
                timeToLiveInSec = (int)timeToLive.Value.TotalSeconds;
            }

            if (initialVisibilityDelay != null)
            {
                CommonUtils.AssertInBounds<TimeSpan>("initialVisibilityDelay", initialVisibilityDelay.Value, TimeSpan.Zero, timeToLive ?? CloudQueueMessage.MaxTimeToLive);
                initialVisibilityDelayInSec = (int)initialVisibilityDelay.Value.TotalSeconds;
            }

            CommonUtils.AssertNotNull("message", message);
            CommonUtils.AssertNotNull("MessageContent", message.AsBytes);

            HttpWebRequest webRequest = QueueRequest.PutMessage(this.MessageRequestAddress, this.ServiceClient.Timeout.RoundUpToSeconds(), timeToLiveInSec, initialVisibilityDelayInSec);
            
            byte[] requestBody = QueueRequest.GenerateMessageRequestBody(this.GenerateMessageContentsForRequest(message));
            CommonUtils.ApplyRequestOptimizations(webRequest, requestBody.Length);
            this.ServiceClient.Credentials.SignRequest(webRequest);

            var requestTask = webRequest.GetRequestStreamAsync();
            yield return requestTask;

            using (var requestStream = requestTask.Result)
            {
                var writeTask = requestStream.WriteAsync(requestBody, 0, requestBody.Length);
                yield return writeTask;
                var scratch = writeTask.Result;
            }

            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Generates a suitable string for representing the content of a message in the body of a web request.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>A string appropriately encoded depending on the format of the message and the EncodeMessage property.</returns>
        private string GenerateMessageContentsForRequest(CloudQueueMessage message)
        {
            // when EncodeMessage is false, it is not allowed to upload a CloudQueueMessage that has been created with a byte array
            // even if the byte array is the UTF8 encoding of a text string.
            if (!this.EncodeMessage && message.MessageType == QueueMessageType.Base64Encoded)
            {
                throw new ArgumentException(SR.BinaryMessageShouldUseBase64Encoding);
            }

            string outgoingMessageString = null;
            if (message.MessageType == QueueMessageType.RawString)
            {
                if (this.EncodeMessage)
                {
                    outgoingMessageString = Convert.ToBase64String(message.AsBytes);

                    // the size of Base64 encoded string is the number of bytes this message will take up on server.
                    if (outgoingMessageString.Length > CloudQueueMessage.MaxMessageSize)
                    {
                        throw new ArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            SR.MessageTooLarge,
                            CloudQueueMessage.MaxMessageSize));
                    }
                }
                else
                {
                    outgoingMessageString = message.RawString;

                    // we need to calculate the size of its UTF8 byte array, as that will be the storage usage on server.
                    if (Encoding.UTF8.GetBytes(outgoingMessageString).Length > CloudQueueMessage.MaxMessageSize)
                    {
                        throw new ArgumentException(string.Format(
                            CultureInfo.InvariantCulture,
                            SR.MessageTooLarge,
                            CloudQueueMessage.MaxMessageSize));
                    }
                }
            }
            else
            {
                // at this point, this.EncodeMessage must be true
                outgoingMessageString = message.RawString;

                // the size of Base64 encoded string is the number of bytes this message will take up on server.
                if (outgoingMessageString.Length > CloudQueueMessage.MaxMessageSize)
                {
                    throw new ArgumentException(string.Format(
                        CultureInfo.InvariantCulture,
                        SR.MessageTooLarge,
                        CloudQueueMessage.MaxMessageSize));
                }
            }

            return outgoingMessageString;
        }

        /// <summary>
        /// Peeks the messages impl.
        /// </summary>
        /// <param name="numberOfMessages">The number of messages.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that returns the peeked messages.</returns>
        private TaskSequence PeekMessagesImpl(int? numberOfMessages, Action<IEnumerable<CloudQueueMessage>> setResult)
        {
            if (numberOfMessages.HasValue)
            {
                CommonUtils.AssertInBounds("numberOfMessages", numberOfMessages.Value, 0, CloudQueueMessage.MaxNumberOfMessagesToPeek);
            }

            var webRequest = QueueRequest.PeekMessages(this.MessageRequestAddress, this.ServiceClient.Timeout.RoundUpToSeconds(), numberOfMessages);
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                var parsedResponse = QueueResponse.PeekMessages(webResponse);
                setResult(MaterializeAndParseResponse(parsedResponse.Messages, this.SelectGetMessageResponse));
            }
        }

        /// <summary>
        /// Deletes the message impl.
        /// </summary>
        /// <param name="messageId">The message id.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <returns>A <see cref="TaskSequence"/> that deletes the message.</returns>
        private TaskSequence DeleteMessageImpl(string messageId, string popReceipt)
        {
            CommonUtils.AssertNotNullOrEmpty("messageId", messageId);
            CommonUtils.AssertNotNullOrEmpty("popReceipt", popReceipt);

            Uri messageUri = this.GetIndividualMessageAddress(messageId);

            var webRequest = QueueRequest.DeleteMessage(messageUri, this.ServiceClient.Timeout.RoundUpToSeconds(), popReceipt);
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
            }
        }

        /// <summary>
        /// Generates a task sequence for updating a message in the queue.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <param name="updateFlags">The flags controlling which parts of the message to update. Must include Visibility.</param>
        /// <returns>A <see cref="TaskSequence"/> that updates the message.</returns>
        private TaskSequence UpdateMessageImpl(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFlags)
        {
            CommonUtils.AssertNotNull("message", message);
            CommonUtils.AssertNotNullOrEmpty("messageId", message.Id);
            CommonUtils.AssertNotNullOrEmpty("popReceipt", message.PopReceipt);
            CommonUtils.AssertInBounds<TimeSpan>("visibilityTimeout", visibilityTimeout, TimeSpan.Zero, CloudQueueMessage.MaxTimeToLive);
            
            if ((updateFlags & MessageUpdateFields.Visibility) == 0)
            {
                throw new ArgumentException("Calls to UpdateMessage must include the Visibility flag.", "updateFlags");
            }

            Uri messageUri = this.GetIndividualMessageAddress(message.Id);

            HttpWebRequest webRequest = QueueRequest.UpdateMessage(messageUri, this.ServiceClient.Timeout.RoundUpToSeconds(), message.PopReceipt, (int)visibilityTimeout.TotalSeconds);

            if ((updateFlags & MessageUpdateFields.Content) != 0)
            {
                byte[] requestBody = QueueRequest.GenerateMessageRequestBody(this.GenerateMessageContentsForRequest(message));
                CommonUtils.ApplyRequestOptimizations(webRequest, requestBody.Length);
                this.ServiceClient.Credentials.SignRequest(webRequest);

                Task<Stream> requestTask = webRequest.GetRequestStreamAsync();
                yield return requestTask;

                using (Stream requestStream = requestTask.Result)
                {
                    Task<NullTaskReturn> writeTask = requestStream.WriteAsync(requestBody, 0, requestBody.Length);
                    yield return writeTask;
                    NullTaskReturn scratch = writeTask.Result;
                }
            }
            else
            {
                CommonUtils.ApplyRequestOptimizations(webRequest, 0);
                this.ServiceClient.Credentials.SignRequest(webRequest);
            }

            Task<WebResponse> task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (HttpWebResponse webResponse = task.Result as HttpWebResponse)
            {
                // Update the message pop receipt and next visible time
                message.PopReceipt = QueueResponse.GetPopReceipt(webResponse);
                message.NextVisibleTime = QueueResponse.GetNextVisibleTime(webResponse);
            }
        }

        /// <summary>
        /// Gets the messages impl.
        /// </summary>
        /// <param name="numberOfMessages">The number of messages.</param>
        /// <param name="visibilityTimeout">The visibility timeout.</param>
        /// <param name="setResult">The set result.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the message.</returns>
        private TaskSequence GetMessagesImpl(int? numberOfMessages, TimeSpan? visibilityTimeout, Action<IEnumerable<CloudQueueMessage>> setResult)
        {
            if (visibilityTimeout.HasValue)
            {
                CommonUtils.AssertInBounds("visibiliyTimeout", visibilityTimeout.Value, TimeSpan.Zero, TimeSpan.MaxValue);
            }

            if (numberOfMessages.HasValue)
            {
                CommonUtils.AssertInBounds("numberOfMessage", numberOfMessages.Value, 0, int.MaxValue);
            }

            int? visibilityTimeoutInSec = visibilityTimeout != null ? visibilityTimeout.RoundUpToSeconds() : (int?)null;

            var webRequest = QueueRequest.GetMessages(this.MessageRequestAddress, this.ServiceClient.Timeout.RoundUpToSeconds(), numberOfMessages, visibilityTimeoutInSec);
            CommonUtils.ApplyRequestOptimizations(webRequest, -1);
            this.ServiceClient.Credentials.SignRequest(webRequest);
            var task = webRequest.GetResponseAsyncWithTimeout(this.ServiceClient, this.ServiceClient.Timeout);
            yield return task;

            using (var webResponse = task.Result as HttpWebResponse)
            {
                var parsedResponse = QueueResponse.GetMessages(webResponse);
                setResult(MaterializeAndParseResponse(parsedResponse.Messages, this.SelectGetMessageResponse));
            }
        }

        /// <summary>
        /// Generate a task sequence for setting the permissions.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <returns>A <see cref="TaskSequence"/> that sets the permissions.</returns>
        private TaskSequence SetPermissionsImpl(QueuePermissions acl)
        {
            return this.ServiceClient.GenerateWebTask(
                QueueRequest.SetAcl(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds()),
                (stream) => QueueRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, stream),
                null /* no response header processing */,
                null /* no response body */);
        }

        /// <summary>
        /// Generate a task sequence for getting the permissions.
        /// </summary>
        /// <param name="setResult">The result report delegate.</param>
        /// <returns>A <see cref="TaskSequence"/> that gets the permissions.</returns>
        private TaskSequence GetPermissionsImpl(Action<QueuePermissions> setResult)
        {
            return this.ServiceClient.GenerateWebTask(
                QueueRequest.GetAcl(this.TransformedAddress, this.ServiceClient.Timeout.RoundUpToSeconds()),
                null /* no request body */,
                null /* no response header processing */,
                (stream) =>
                {
                    QueuePermissions queueAcl = new QueuePermissions();

                    // Get the policies from the web response.
                    QueueResponse.ReadSharedAccessIdentifiers(stream, queueAcl);

                    setResult(queueAcl);
                });
        }

        /// <summary>
        /// Gets the properties and metadata from response.
        /// </summary>
        /// <param name="webResponse">The web response.</param>
        private void GetPropertiesAndMetadataFromResponse(HttpWebResponse webResponse)
        {
            this.Metadata = QueueResponse.GetMetadata(webResponse);

            string count = QueueResponse.GetApproximateMessageCount(webResponse);
            this.ApproximateMessageCount = string.IsNullOrEmpty(count) ? (int?)null : int.Parse(count);
        }
    }
}
