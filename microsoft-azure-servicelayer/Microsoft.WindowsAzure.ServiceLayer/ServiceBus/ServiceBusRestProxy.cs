﻿//
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
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, "$Resources/Queues");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return Channel
                .SendAsync(request)
                .ContinueWith<IEnumerable<QueueInfo>>(r => { return GetQueues(r.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<IEnumerable<QueueInfo>>();
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

            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return Channel
                .SendAsync(request)
                .ContinueWith<QueueInfo>(r => { return GetQueue(r.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<QueueInfo>();
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

            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);

            return Channel
                .SendAsync(request)
                .AsAsyncAction();
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

            return CreateQueueAsync(queueName, new QueueSettings());
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

            return CreateQueueAsync(queueName, queueSettings);
        }

        /// <summary>
        /// Extracts queues from the given HTTP response.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        /// <returns>Collection of queues.</returns>
        private IEnumerable<QueueInfo> GetQueues(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            SyndicationFeed feed = new SyndicationFeed();
            feed.Load(response.Content.ReadAsStringAsync().Result);

            return SerializationHelper.DeserializeCollection<QueueInfo>(feed, (item, queue) => queue.Initialize(item));
        }

        /// <summary>
        /// Extracts a single queue from the given response.
        /// </summary>
        /// <param name="response">HTTP response.</param>
        /// <returns>Queue data.</returns>
        private QueueInfo GetQueue(HttpResponseMessage response)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(response.Content.ReadAsStringAsync().Result);

            SyndicationItem feedItem = new SyndicationItem();
            feedItem.LoadFromXml(doc);
            return SerializationHelper.DeserializeItem<QueueInfo>(feedItem, (item, queue) => queue.Initialize(item));
        }

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Name of the queue.</param>
        /// <param name="queueSettings">Parameters of the queue.</param>
        /// <returns>Created queue.</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri);

            return Task.Factory
                .StartNew(() => SetBody(request, queueSettings))
                .ContinueWith<HttpResponseMessage>(tr => { return Channel.SendAsync(request).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<QueueInfo>(tr => { return GetQueue(tr.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<QueueInfo>();

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
    }
}
