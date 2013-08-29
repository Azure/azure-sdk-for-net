// -----------------------------------------------------------------------------------------
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
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.Threading.Tasks;
    using Windows.Foundation;
    using Microsoft.WindowsAzure.Storage.Queue.Protocol;
    using Microsoft.WindowsAzure.Storage.Core;
    using Microsoft.WindowsAzure.Storage.Core.Executor;
    using Microsoft.WindowsAzure.Storage.Core.Util;
    using Microsoft.WindowsAzure.Storage.Shared;
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;

    /// <summary>
    /// This class represents a queue in the Windows Azure Queue service.
    /// </summary>
    public sealed partial class CloudQueue
    {
        /// <summary>
        /// Creates the queue.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction CreateAsync()
        {
            return this.CreateAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Creates the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction CreateAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.CreateQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Creates the queue if it does not already exist.
        /// </summary>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> CreateIfNotExistsAsync()
        {
            return this.CreateIfNotExistsAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Creates the queue if it does not already exist.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the queue did not already exist and was created; otherwise <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> CreateIfNotExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) =>
            {
                bool exists = await this.ExistsAsync(modifiedOptions, operationContext).AsTask(token);

                if (exists)
                {
                    return false;
                }

                try
                {
                    await this.CreateAsync(modifiedOptions, operationContext).AsTask(token);

                    if (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.NoContent)
                    {
                        return false;
                    }

                    return true;
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.Conflict)
                    {
                        StorageExtendedErrorInformation extendedInfo = operationContext.LastResult.ExtendedErrorInformation;
                        if ((extendedInfo == null) ||
                            (extendedInfo.ErrorCode == QueueErrorCodeStrings.QueueAlreadyExists))
                        {
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            });
        }

        /// <summary>
        /// Deletes the queue.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteAsync()
        {
            return this.DeleteAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the queue.
        /// </summary>
        /// <param name="options">An object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.DeleteQueueImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Deletes the queue if it already exists.
        /// </summary>
        /// <returns><c>true</c> if the queue already existed and was deleted; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> DeleteIfExistsAsync()
        {
            return this.DeleteIfExistsAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the queue if it already exists.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the queue already existed and was deleted; otherwise, <c>false</c>.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> DeleteIfExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) =>
            {
                bool exists = await this.ExistsAsync(modifiedOptions, operationContext).AsTask(token);

                if (!exists)
                {
                    return false;
                }

                try
                {
                    await this.DeleteAsync(modifiedOptions, operationContext).AsTask(token);
                    return true;
                }
                catch (Exception)
                {
                    if (operationContext.LastResult.HttpStatusCode == (int)HttpStatusCode.NotFound)
                    {
                        StorageExtendedErrorInformation extendedInfo = operationContext.LastResult.ExtendedErrorInformation;
                        if ((extendedInfo == null) ||
                            (extendedInfo.ErrorCode == QueueErrorCodeStrings.QueueNotFound))
                        {
                            return false;
                        }
                        else
                        {
                            throw;
                        }
                    }
                    else
                    {
                        throw;
                    }
                }
            });
        }

        /// <summary>
        /// Sets permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetPermissionsAsync(QueuePermissions permissions)
        {
            return this.SetPermissionsAsync(permissions, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Sets permissions for the queue.
        /// </summary>
        /// <param name="permissions">The permissions to apply to the queue.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetPermissionsAsync(QueuePermissions permissions, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.SetPermissionsImpl(permissions, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Gets the permissions settings for the queue.
        /// </summary>
        /// <returns>The queue's permissions.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<QueuePermissions> GetPermissionsAsync()
        {
            return this.GetPermissionsAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets the permissions settings for the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>The queue's permissions.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<QueuePermissions> GetPermissionsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.GetPermissionsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Checks existence of the queue.
        /// </summary>
        /// <returns><c>true</c> if the queue exists.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> ExistsAsync()
        {
            return this.ExistsAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Checks existence of the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns><c>true</c> if the queue exists.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<bool> ExistsAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.ExistsImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Retrieves the queue's attributes.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction FetchAttributesAsync()
        {
            return this.FetchAttributesAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Retrieves the queue's attributes.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction FetchAttributesAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
               this.FetchAttributesImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Sets the queue's user-defined metadata.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetMetadataAsync()
        {
            return this.SetMetadataAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Sets the queue's user-defined metadata.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction SetMetadataAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.SetMetadataImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction AddMessageAsync(CloudQueueMessage message)
        {
            return this.AddMessageAsync(message, null /* timeToLive */, null /* initialVisibilityDelay */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Adds a message to the queue.
        /// </summary>
        /// <param name="message">The message to add.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction AddMessageAsync(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.AddMessageImpl(message, timeToLive, initialVisibilityDelay, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">The message update fields.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields)
        {
            return this.UpdateMessageAsync(message, visibilityTimeout, updateFields, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Updates a message.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">The message update fields.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction UpdateMessageAsync(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.UpdateMessageImpl(message, visibilityTimeout, updateFields, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="message">The message to delete.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteMessageAsync(CloudQueueMessage message)
        {
            return this.DeleteMessageAsync(message, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="message">The message to delete.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteMessageAsync(CloudQueueMessage message, QueueRequestOptions options, OperationContext operationContext)
        {
            return this.DeleteMessageAsync(message.Id, message.PopReceipt, options, operationContext);
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteMessageAsync(string messageId, string popReceipt)
        {
            return this.DeleteMessageAsync(messageId, popReceipt, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Deletes the message.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction DeleteMessageAsync(string messageId, string popReceipt, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.DeleteMessageImpl(messageId, popReceipt, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Gets a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount)
        {
            return this.GetMessagesAsync(messageCount, null /* visibilityTimeout */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<CloudQueueMessage>> GetMessagesAsync(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.GetMessagesImpl(messageCount, visibilityTimeout, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Gets a single message from the queue.
        /// </summary>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudQueueMessage> GetMessageAsync()
        {
            return this.GetMessageAsync(null /* visibilityTimeout */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Gets a single message from the queue.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudQueueMessage> GetMessageAsync(TimeSpan? visibilityTimeout, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.GetMessageImpl(visibilityTimeout, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Peeks a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount)
        {
            return this.GetMessagesAsync(messageCount, null /* visibilityTimeout */, null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Peeks a list of messages from the queue.
        /// </summary>
        /// <param name="messageCount">The number of messages to retrieve.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An enumerable collection of messages.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<IEnumerable<CloudQueueMessage>> PeekMessagesAsync(int messageCount, QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.PeekMessagesImpl(messageCount, modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Peeks a single message from the queue.
        /// </summary>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudQueueMessage> PeekMessageAsync()
        {
            return this.PeekMessageAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Peeks a single message from the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>A message.</returns>
        [DoesServiceRequest]
        public IAsyncOperation<CloudQueueMessage> PeekMessageAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsync(
                this.PeekMessageImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Clears the messages of the queue.
        /// </summary>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction ClearAsync()
        {
            return this.ClearAsync(null /* options */, null /* operationContext */);
        }

        /// <summary>
        /// Clears the messages of the queue.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <param name="operationContext">An <see cref="OperationContext"/> object that represents the context for the current operation.</param>
        /// <returns>An <see cref="IAsyncAction"/> that represents an asynchronous action.</returns>
        [DoesServiceRequest]
        public IAsyncAction ClearAsync(QueueRequestOptions options, OperationContext operationContext)
        {
            QueueRequestOptions modifiedOptions = QueueRequestOptions.ApplyDefaults(options, this.ServiceClient);
            operationContext = operationContext ?? new OperationContext();

            return AsyncInfo.Run(async (token) => await Executor.ExecuteAsyncNullReturn(
                this.ClearImpl(modifiedOptions),
                modifiedOptions.RetryPolicy,
                operationContext,
                token));
        }

        /// <summary>
        /// Implementation for the Create method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that creates the queue.</returns>
        private RESTCommand<NullType> CreateQueueImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) =>
            {
                HttpRequestMessage msg = QueueHttpRequestMessageFactory.Create(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
                QueueHttpRequestMessageFactory.AddMetadata(msg, this.Metadata);
                return msg;
            };
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpStatusCode[] expectedHttpStatusCodes = new HttpStatusCode[2];
                expectedHttpStatusCodes[0] = HttpStatusCode.Created;
                expectedHttpStatusCodes[1] = HttpStatusCode.NoContent;
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(expectedHttpStatusCodes, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Delete method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that deletes the queue.</returns>
        private RESTCommand<NullType> DeleteQueueImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.Delete(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the Clear method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that deletes the queue.</returns>
        private RESTCommand<NullType> ClearImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.Delete(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the FetchAttributes method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that fetches the attributes.</returns>
        private RESTCommand<NullType> FetchAttributesImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> getCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetMetadata(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the Exists method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that checks existence.</returns>
        private RESTCommand<bool> ExistsImpl(QueueRequestOptions options)
        {
            RESTCommand<bool> getCmd = new RESTCommand<bool>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetMetadata(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                if (resp.StatusCode == HttpStatusCode.NotFound)
                {
                    return false;
                }

                if (resp.StatusCode == HttpStatusCode.PreconditionFailed)
                {
                    return true;
                }

                return HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, true, cmd, ex);
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the SetMetadata method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the metadata.</returns>
        private RESTCommand<NullType> SetMetadataImpl(QueueRequestOptions options)
        {
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) =>
            {
                HttpRequestMessage msg = QueueHttpRequestMessageFactory.SetMetadata(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
                QueueHttpRequestMessageFactory.AddMetadata(msg, this.Metadata);
                return msg;
            };
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the SetPermissions method.
        /// </summary>
        /// <param name="acl">The permissions to set.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the permissions.</returns>
        private RESTCommand<NullType> SetPermissionsImpl(QueuePermissions acl, QueueRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            QueueRequest.WriteSharedAccessIdentifiers(acl.SharedAccessPolicies, memoryStream);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.Uri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.SetAcl(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null /* md5 */, cmd, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<QueuePermissions> GetPermissionsImpl(QueueRequestOptions options)
        {
            RESTCommand<QueuePermissions> getCmd = new RESTCommand<QueuePermissions>(this.ServiceClient.Credentials, this.Uri);

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetAcl(cmd.Uri, cmd.ServerTimeoutInSeconds, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                this.GetMessageCountAndMetadataFromResponse(resp);
                return Task<QueuePermissions>.Factory.StartNew(() =>
                {
                    QueuePermissions queueAcl = new QueuePermissions();
                    QueueHttpResponseParsers.ReadSharedAccessIdentifiers(cmd.ResponseStream, queueAcl);
                    return queueAcl;
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the AddMessage method.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="timeToLive">The maximum time to allow the message to be in the queue, or null.</param>
        /// <param name="initialVisibilityDelay">The length of time from now during which the message will be invisible.
        /// If <c>null</c> then the message will be visible immediately.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the permissions.</returns>
        private RESTCommand<NullType> AddMessageImpl(CloudQueueMessage message, TimeSpan? timeToLive, TimeSpan? initialVisibilityDelay, QueueRequestOptions options)
        {
            MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
            QueueRequest.WriteMessageContent(message.GetMessageContentForTransfer(this.EncodeMessage), memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);

            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.AddMessage(cmd.Uri, cmd.ServerTimeoutInSeconds, timeToLive, initialVisibilityDelay, cnt, ctx);
            putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null, cmd, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.Created, resp, NullType.Value, cmd, ex);
                GetMessageCountAndMetadataFromResponse(resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the UpdateMessage method.
        /// </summary>
        /// <param name="message">The message to update.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="updateFields">The message update fields.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that sets the permissions.</returns>
        private RESTCommand<NullType> UpdateMessageImpl(CloudQueueMessage message, TimeSpan visibilityTimeout, MessageUpdateFields updateFields, QueueRequestOptions options)
        {
            CommonUtility.AssertNotNull("message", message);
            CommonUtility.AssertNotNullOrEmpty("messageId", message.Id);
            CommonUtility.AssertNotNullOrEmpty("popReceipt", message.PopReceipt);
            CommonUtility.AssertInBounds<TimeSpan>("visibilityTimeout", visibilityTimeout, TimeSpan.Zero, CloudQueueMessage.MaxTimeToLive);

            if ((updateFields & MessageUpdateFields.Visibility) == 0)
            {
                throw new ArgumentException(SR.UpdateMessageVisibilityRequired, "updateFlags");
            }

            Uri messageUri = this.GetIndividualMessageAddress(message.Id);
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, messageUri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.UpdateMessage(cmd.Uri, cmd.ServerTimeoutInSeconds, message.PopReceipt, visibilityTimeout, cnt, ctx);

            if ((updateFields & MessageUpdateFields.Content) != 0)
            {
                MultiBufferMemoryStream memoryStream = new MultiBufferMemoryStream(null /* bufferManager */, (int)(1 * Constants.KB));
                QueueRequest.WriteMessageContent(message.GetMessageContentForTransfer(this.EncodeMessage), memoryStream);
                memoryStream.Seek(0, SeekOrigin.Begin);

                putCmd.BuildContent = (cmd, ctx) => HttpContentFactory.BuildContentFromStream(memoryStream, 0, memoryStream.Length, null, cmd, ctx);
            }

            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) =>
            {
                HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);
                GetPopReceiptAndNextVisibleTimeFromResponse(message, resp);
                return NullType.Value;
            };

            return putCmd;
        }

        /// <summary>
        /// Implementation for the DeleteMessage method.
        /// </summary>
        /// <param name="messageId">The message ID.</param>
        /// <param name="popReceipt">The pop receipt value.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that deletes the queue.</returns>
        private RESTCommand<NullType> DeleteMessageImpl(string messageId, string popReceipt, QueueRequestOptions options)
        {
            Uri messageUri = this.GetIndividualMessageAddress(messageId);
            RESTCommand<NullType> putCmd = new RESTCommand<NullType>(this.ServiceClient.Credentials, messageUri);

            putCmd.ApplyRequestOptions(options);
            putCmd.Handler = this.ServiceClient.AuthenticationHandler;
            putCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            putCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.DeleteMessage(cmd.Uri, cmd.ServerTimeoutInSeconds, popReceipt, cnt, ctx);
            putCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.NoContent, resp, NullType.Value, cmd, ex);

            return putCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="messageCount">The message count.</param>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<IEnumerable<CloudQueueMessage>> GetMessagesImpl(int messageCount, TimeSpan? visibilityTimeout, QueueRequestOptions options)
        {
            RESTCommand<IEnumerable<CloudQueueMessage>> getCmd = new RESTCommand<IEnumerable<CloudQueueMessage>>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetMessages(getCmd.Uri, getCmd.ServerTimeoutInSeconds, messageCount, visibilityTimeout, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    GetMessagesResponse getMessagesResponse = new GetMessagesResponse(cmd.ResponseStream);

                    IEnumerable<CloudQueueMessage> messagesList = new List<CloudQueueMessage>(
                        getMessagesResponse.Messages.Select(item => SelectGetMessageResponse(item)));

                    return messagesList;
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the PeekMessages method.
        /// </summary>
        /// <param name="messageCount">The message count.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<IEnumerable<CloudQueueMessage>> PeekMessagesImpl(int messageCount, QueueRequestOptions options)
        {
            RESTCommand<IEnumerable<CloudQueueMessage>> getCmd = new RESTCommand<IEnumerable<CloudQueueMessage>>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.PeekMessages(getCmd.Uri, getCmd.ServerTimeoutInSeconds, messageCount, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    GetMessagesResponse getMessagesResponse = new GetMessagesResponse(cmd.ResponseStream);

                    IEnumerable<CloudQueueMessage> messagesList = new List<CloudQueueMessage>(
                        getMessagesResponse.Messages.Select(item => SelectPeekMessageResponse(item)));

                    return messagesList;
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the GetPermissions method.
        /// </summary>
        /// <param name="visibilityTimeout">The visibility timeout interval.</param>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<CloudQueueMessage> GetMessageImpl(TimeSpan? visibilityTimeout, QueueRequestOptions options)
        {
            RESTCommand<CloudQueueMessage> getCmd = new RESTCommand<CloudQueueMessage>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.GetMessages(getCmd.Uri, getCmd.ServerTimeoutInSeconds, 1, visibilityTimeout, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    using (IEnumerator<QueueMessage> enumerator = new GetMessagesResponse(cmd.ResponseStream).Messages.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            return SelectGetMessageResponse(enumerator.Current);
                        }
                    }

                    return null;
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Implementation for the PeekMessage method.
        /// </summary>
        /// <param name="options">A <see cref="QueueRequestOptions"/> object that specifies any additional options for the request.</param>
        /// <returns>A <see cref="RESTCommand"/> that gets the permissions.</returns>
        private RESTCommand<CloudQueueMessage> PeekMessageImpl(QueueRequestOptions options)
        {
            RESTCommand<CloudQueueMessage> getCmd = new RESTCommand<CloudQueueMessage>(this.ServiceClient.Credentials, this.GetMessageRequestAddress());

            getCmd.ApplyRequestOptions(options);
            getCmd.Handler = this.ServiceClient.AuthenticationHandler;
            getCmd.BuildClient = HttpClientFactory.BuildHttpClient;
            getCmd.RetrieveResponseStream = true;
            getCmd.BuildRequest = (cmd, cnt, ctx) => QueueHttpRequestMessageFactory.PeekMessages(getCmd.Uri, getCmd.ServerTimeoutInSeconds, 1, cnt, ctx);
            getCmd.PreProcessResponse = (cmd, resp, ex, ctx) => HttpResponseParsers.ProcessExpectedStatusCodeNoException(HttpStatusCode.OK, resp, null /* retVal */, cmd, ex);
            getCmd.PostProcessResponse = (cmd, resp, ctx) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    using (IEnumerator<QueueMessage> enumerator = new GetMessagesResponse(cmd.ResponseStream).Messages.GetEnumerator())
                    {
                        if (enumerator.MoveNext())
                        {
                            return SelectPeekMessageResponse(enumerator.Current);
                        }
                    }

                    return null;
                });
            };

            return getCmd;
        }

        /// <summary>
        /// Gets the ApproximateMessageCount and metadata from response.
        /// </summary>
        /// <param name="response">The web response.</param>
        private void GetMessageCountAndMetadataFromResponse(HttpResponseMessage response)
        {
            this.Metadata = QueueHttpResponseParsers.GetMetadata(response);

            string count = QueueHttpResponseParsers.GetApproximateMessageCount(response);
            this.ApproximateMessageCount = string.IsNullOrEmpty(count) ? (int?)null : int.Parse(count);
        }

        /// <summary>
        /// Update the message pop receipt and next visible time.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="webResponse">The web response.</param>
        private void GetPopReceiptAndNextVisibleTimeFromResponse(CloudQueueMessage message, HttpResponseMessage webResponse)
        {
            message.PopReceipt = webResponse.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.PopReceipt);
            message.NextVisibleTime = DateTime.Parse(
                webResponse.Headers.GetHeaderSingleValueOrDefault(Constants.HeaderConstants.NextVisibleTime),
                System.Globalization.DateTimeFormatInfo.InvariantInfo,
                System.Globalization.DateTimeStyles.AdjustToUniversal);
        }
    }
}
