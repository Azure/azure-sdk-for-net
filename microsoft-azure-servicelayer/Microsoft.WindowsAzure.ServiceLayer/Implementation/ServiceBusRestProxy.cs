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

namespace Microsoft.WindowsAzure.ServiceLayer.Implementation
{
    /// <summary>
    /// REST proxy for the service bus interface.
    /// </summary>
    class ServiceBusRestProxy: IServiceBusService
    {
        /// <summary>
        /// Gets the service options.
        /// </summary>
        internal ServiceBusServiceConfig ServiceConfig { get; private set; }

        /// <summary>
        /// Gets HTTP client used for communicating with the service.
        /// </summary>
        HttpClient Channel { get; set; }

        /// <summary>
        /// Gets the token manager used for authentication
        /// </summary>
        Implementation.WrapTokenManager TokenManager { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceOptions">Service options</param>
        internal ServiceBusRestProxy(ServiceBusServiceConfig serviceOptions)
        {
            Debug.Assert(serviceOptions != null);

            ServiceConfig = serviceOptions;
            Channel = new HttpClient();
            TokenManager = new WrapTokenManager(ServiceConfig);
        }

        /// <summary>
        /// Gets all available queues in the namespace.
        /// </summary>
        /// <returns>All queues in the namespace</returns>
        IAsyncOperation<IEnumerable<QueueInfo>> IServiceBusService.ListQueuesAsync()
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, "$Resources/Queues");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return AuthenticateRequestAsync(request)
                .ContinueWith<HttpResponseMessage>(r => { return Channel.SendAsync(r.Result).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<IEnumerable<QueueInfo>>(r => { return GetQueues(r.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<IEnumerable<QueueInfo>>();
        }

        /// <summary>
        /// Gets the queue with the given name.
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <returns>Queue data</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.GetQueueAsync(string queueName)
        {
            if (queueName == null)
                throw new ArgumentNullException("queueName");

            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);

            return AuthenticateRequestAsync(request)
                .ContinueWith<HttpResponseMessage>(r => { return Channel.SendAsync(r.Result).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<QueueInfo>(r => { return GetQueue(r.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<QueueInfo>();
        }

        /// <summary>
        /// Deletes a queue with the given name.
        /// </summary>
        /// <param name="queueName">Queue name</param>
        /// <returns>Asycnrhonous action</returns>
        IAsyncAction IServiceBusService.DeleteQueueAsync(string queueName)
        {
            if (queueName == null)
                throw new ArgumentNullException("queueName");

            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);

            return AuthenticateRequestAsync(request)
                .ContinueWith<HttpResponseMessage>(r => { return Channel.SendAsync(r.Result).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncAction();
        }

        /// <summary>
        /// Creates a queue with the given name and default settings.
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <returns>Queue data</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName)
        {
            if (queueName == null)
                throw new ArgumentNullException("queueName");

            return CreateQueueAsync(queueName, new QueueSettings());
        }

        /// <summary>
        /// Creates a queue with the given parameters.
        /// </summary>
        /// <param name="queueName">Name of the queue</param>
        /// <param name="queueSettings">Parameters of the queue</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> IServiceBusService.CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            if (queueName == null)
                throw new ArgumentNullException("queueName");
            if (queueSettings == null)
                throw new ArgumentNullException("queueSettings");

            return CreateQueueAsync(queueName, queueSettings);
        }

        /// <summary>
        /// Authenticates the request.
        /// </summary>
        /// <param name="request">Request to authenticate</param>
        /// <returns>Authenticated request</returns>
        Task<HttpRequestMessage> AuthenticateRequestAsync(HttpRequestMessage request)
        {
            return TokenManager.GetTokenAsync(request.RequestUri.AbsolutePath)
                .ContinueWith(t => { return t.Result.Authorize(request); }, TaskContinuationOptions.OnlyOnRanToCompletion);
        }

        /// <summary>
        /// Extracts queues from the given HTTP response.
        /// </summary>
        /// <param name="response">HTTP response</param>
        /// <returns>Collection of queues</returns>
        IEnumerable<QueueInfo> GetQueues(HttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            SyndicationFeed feed = new SyndicationFeed();
            feed.Load(response.Content.ReadAsStringAsync().Result);

            return SerializationHelper.DeserializeCollection<QueueInfo>(feed, (item, queue) => queue.Initialize(item));
        }

        /// <summary>
        /// Extracts a single queue from the given response.
        /// </summary>
        /// <param name="response">HTTP response</param>
        /// <returns>Queue</returns>
        QueueInfo GetQueue(HttpResponseMessage response)
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
        /// <param name="queueName">Name of the queue</param>
        /// <param name="queueSettings">Parameters of the queue</param>
        /// <returns>Created queue</returns>
        IAsyncOperation<QueueInfo> CreateQueueAsync(string queueName, QueueSettings queueSettings)
        {
            Uri uri = new Uri(ServiceConfig.ServiceBusUri, queueName);
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri);
            string content = SerializationHelper.Serialize(queueSettings);

            request.Content = new StringContent(content, Encoding.UTF8, "application/atom+xml");
            request.Content.Headers.ContentType.Parameters.Add(new System.Net.Http.Headers.NameValueHeaderValue("type", "entry"));

            return AuthenticateRequestAsync(request)
                .ContinueWith<HttpResponseMessage>(tr => { return Channel.SendAsync(request).Result; }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .ContinueWith<QueueInfo>(tr => { return GetQueue(tr.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation<QueueInfo>();

        }
    }
}
