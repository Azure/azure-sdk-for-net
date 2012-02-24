//
// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//    http://www.apache.org/licenses/LICENSE-2.0
// 
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Windows.Data.Xml.Dom;
using Windows.Foundation;
using Windows.Web.Syndication;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// REST proxy for the service bus interface.
    /// </summary>
    internal class ServiceBusRestProxy: IServiceBusService
    {
        /// <summary>
        /// Gets the service options.
        /// </summary>
        private ServiceConfiguration ServiceConfig { get; set; }

        /// <summary>
        /// Gets HTTP client used for communicating with the service.
        /// </summary>
        private HttpClient Channel { get; set; }


        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceOptions">Configuration parameters.</param>
        internal ServiceBusRestProxy(ServiceConfiguration serviceOptions)
        {
            Debug.Assert(serviceOptions != null);

            ServiceConfig = serviceOptions;
            HttpMessageHandler chain = new HttpErrorHandler(
                new WrapAuthenticationHandler(serviceOptions));
            Channel = new HttpClient(chain);
        }

        /// <summary>
        /// Gets all available queues in the namespace.
        /// </summary>
        /// <returns>All queues in the namespace.</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> IServiceBusService.ListQueuesAsync()
        {
            return GetItemsAsync<QueueInfo>("$Resources/Queues", (item, queue) => queue.Initialize(item));
        }

        /// <summary>
        /// Gets the queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.GetQueueAsync(string queueName)
        {
            if (queueName == null)
            {
                throw new ArgumentNullException("queueName");
            }

            return GetItemAsync<QueueInfo>(queueName, (item, queue) => queue.Initialize(item));
        }

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name.</param>
        /// <returns>Asycnrhonous action.</returns>
        IAsyncAction IServiceBusService.DeleteQueueAsync(string queueName)
        {
            if (queueName == null)
            {
                throw new ArgumentNullException("queueName");
            }

            return DeleteItemAsync(queueName);
        }

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <returns>Queue data.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName)
        {
            if (queueName == null)
            {
                throw new ArgumentNullException("queueName");
            }

            return CreateItemAsync<QueueInfo, QueueSettings>(queueName, new QueueSettings(), InitQueue);
        }

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="queueSettings">Parameters of the queue.</param>
        /// <returns>Created queue.</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            if (queueName == null)
            {
                throw new ArgumentNullException("queueName");
            }
            if (queueSettings == null)
            {
                throw new ArgumentNullException("queueSettings");
            }

            return CreateItemAsync<QueueInfo, QueueSettings>(queueName, queueSettings, InitQueue);
        }

        /// <summary>
        /// Lists all topics in the namespace.
        /// </summary>
        /// <returns>A collection of topics.</returns>
        IAsyncOperation<IEnumerable<TopicInfo>> IServiceBusService.ListTopicsAsync()
        {
            return GetItemsAsync<TopicInfo>("$Resources/Topics", InitTopic);
        }

        /// <summary>
        /// Creates a topic with the given name and default settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Created topic.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.CreateTopicAsync(string topicName)
        {
            if (topicName == null)
            {
                throw new ArgumentNullException("topicName");
            }
            return CreateItemAsync<TopicInfo, TopicSettings>(topicName, new TopicSettings(), InitTopic);
        }

        /// <summary>
        /// Creates a topic with the given name and settings.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <param name="topicSettings">Topic settings.</param>
        /// <returns>Created topic.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.CreateTopicAsync(string topicName, TopicSettings topicSettings)
        {
            if (topicName == null)
            {
                throw new ArgumentNullException("topicName");
            }
            if (topicSettings == null)
            {
                throw new ArgumentNullException("topicSettings");
            }

            return CreateItemAsync<TopicInfo, TopicSettings>(topicName, topicSettings, InitTopic);
        }

        /// <summary>
        /// Gets a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Topic information.</returns>
        IAsyncOperation<TopicInfo> IServiceBusService.GetTopicAsync(string topicName)
        {
            if (topicName == null)
            {
                throw new ArgumentNullException("topicName");
            }

            return GetItemAsync<TopicInfo>(topicName, InitTopic);
        }

        /// <summary>
        /// Deletes a topic with the given name.
        /// </summary>
        /// <param name="topicName">Topic name.</param>
        /// <returns>Deletion result.</returns>
        IAsyncAction IServiceBusService.DeleteTopicAsync(string topicName)
        {
            if (topicName == null)
            {
                throw new ArgumentNullException("topicName");
            }

            return DeleteItemAsync(topicName);
        }

        /// <summary>
        /// Gets service bus items of the given type.
        /// </summary>
        /// <typeparam name="INFO">Item type.</typeparam>
        /// <param name="path">Path of the items.</param>
        /// <param name="initAction">Initialization action for a single item.</param>
        /// <returns>A collection of items.</returns>
        private IAsyncOperation<IEnumerable<INFO>> GetItemsAsync<INFO>(string path, Action<SyndicationItem, INFO> initAction)
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, path);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return Channel
                .SendAsync(request)
                .ContinueWith<IEnumerable<INFO>>(r => { return GetItems<INFO>(r.Result, initAction); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<IEnumerable<INFO>>();

        }

        /// <summary>
        /// Deserializes collection of items of the given type from an atom feed contained in the specified response.
        /// </summary>
        /// <typeparam name="INFO">Item type.</typeparam>
        /// <param name="response">Source HTTP response.</param>
        /// <param name="initAction">Initialization action.</param>
        /// <returns>Collection of deserialized items.</returns>
        private IEnumerable<INFO> GetItems<INFO>(HttpResponseMessage response, Action<SyndicationItem, INFO> initAction)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            SyndicationFeed feed = new SyndicationFeed();
            feed.Load(response.Content.ReadAsStringAsync().Result);

            return SerializationHelper.DeserializeCollection<INFO>(feed, initAction);
        }

        /// <summary>
        /// Obtains a service bus item of the given name and type.
        /// </summary>
        /// <typeparam name="INFO">Item type</typeparam>
        /// <param name="itemName">Item name</param>
        /// <param name="initAction">Initialization action for the deserialized item.</param>
        /// <returns>Item data</returns>
        private IAsyncOperation<INFO> GetItemAsync<INFO>(string itemName, Action<SyndicationItem, INFO> initAction)
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, itemName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return Channel
                .SendAsync(request)
                .ContinueWith<INFO>(tr => { return GetItem<INFO>(tr.Result, initAction); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<INFO>();
        }

        /// <summary>
        /// Deserializes a service bus item of the specified type from the given HTTP response.
        /// </summary>
        /// <typeparam name="INFO">Type of the object to deserialize.</typeparam>
        /// <param name="response">Source HTTP response.</param>
        /// <param name="initAction">Initialization action for deserialized items.</param>
        /// <returns>Deserialized object.</returns>
        private INFO GetItem<INFO>(HttpResponseMessage response, Action<SyndicationItem, INFO> initAction)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content.ReadAsStringAsync().Result);

            SyndicationItem feedItem = new SyndicationItem();
            feedItem.LoadFromXml(doc);

            return SerializationHelper.DeserializeItem<INFO>(feedItem, initAction);
        }

        /// <summary>
        /// Deletes an item with the given name.
        /// </summary>
        /// <param name="itemName">Item name.</param>
        /// <returns>Deletion result.</returns>
        private IAsyncAction DeleteItemAsync(string itemName)
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, itemName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);

            return Channel
                .SendAsync(request)
                .AsAsyncAction();
        }

        /// <summary>
        /// Creates a service bus object with the given name and parameters.
        /// </summary>
        /// <typeparam name="INFO">Service bus object type (queue, topic, etc.).</typeparam>
        /// <typeparam name="SETTINGS">Settings for the given object type.</typeparam>
        /// <param name="itemName">Name of the object.</param>
        /// <param name="itemSettings">Settings of the object.</param>
        /// <param name="initAction">Initialization action</param>
        /// <returns>Created object.</returns>
        private IAsyncOperation<INFO> CreateItemAsync<INFO, SETTINGS>(
            string itemName, 
            SETTINGS itemSettings, 
            Action<SyndicationItem, INFO> initAction
            ) where SETTINGS: class
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, itemName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri);

            return Task.Factory
                .StartNew(() => SetBody(request, itemSettings))
                .ContinueWith<HttpResponseMessage>(tr => { return Channel.SendAsync(request).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<INFO>(tr => { return GetItem<INFO>(tr.Result, initAction); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<INFO>();
        }

        /// <summary>
        /// Serializes given object and sets the request's body.
        /// </summary>
        /// <param name="request">Target request.</param>
        /// <param name="bodyObject">Object to serialize.</param>
        private void SetBody(HttpRequestMessage request, object bodyObject)
        {
            string content = SerializationHelper.Serialize(bodyObject);
            request.Content = new StringContent(content, Encoding.UTF8, Constants.BodyContentType);
            request.Content.Headers.ContentType.Parameters.Add(new System.Net.Http.Headers.NameValueHeaderValue("type", "entry"));
        }

        private static void InitTopic(SyndicationItem feedItem, TopicInfo topicInfo)
        {
            topicInfo.Initialize(feedItem);
        }

        private static void InitQueue(SyndicationItem feedItem, QueueInfo queueInfo)
        {
            queueInfo.Initialize(feedItem);
        }
    }
}
