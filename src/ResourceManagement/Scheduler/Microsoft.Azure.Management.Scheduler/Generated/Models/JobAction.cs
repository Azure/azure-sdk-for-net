
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class JobAction
    {
        /// <summary>
        /// Initializes a new instance of the JobAction class.
        /// </summary>
        public JobAction() { }

        /// <summary>
        /// Initializes a new instance of the JobAction class.
        /// </summary>
        public JobAction(JobActionType? type = default(JobActionType?), HttpRequest request = default(HttpRequest), StorageQueueMessage queueMessage = default(StorageQueueMessage), ServiceBusQueueMessage serviceBusQueueMessage = default(ServiceBusQueueMessage), ServiceBusTopicMessage serviceBusTopicMessage = default(ServiceBusTopicMessage), RetryPolicy retryPolicy = default(RetryPolicy), JobErrorAction errorAction = default(JobErrorAction))
        {
            Type = type;
            Request = request;
            QueueMessage = queueMessage;
            ServiceBusQueueMessage = serviceBusQueueMessage;
            ServiceBusTopicMessage = serviceBusTopicMessage;
            RetryPolicy = retryPolicy;
            ErrorAction = errorAction;
        }

        /// <summary>
        /// Gets or sets the job action type. Possible values include: 'Http',
        /// 'Https', 'StorageQueue', 'ServiceBusQueue', 'ServiceBusTopic'
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public JobActionType? Type { get; set; }

        /// <summary>
        /// Gets or sets the http requests.
        /// </summary>
        [JsonProperty(PropertyName = "request")]
        public HttpRequest Request { get; set; }

        /// <summary>
        /// Gets or sets the storage queue message.
        /// </summary>
        [JsonProperty(PropertyName = "queueMessage")]
        public StorageQueueMessage QueueMessage { get; set; }

        /// <summary>
        /// Gets or sets the service bus queue message.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusQueueMessage")]
        public ServiceBusQueueMessage ServiceBusQueueMessage { get; set; }

        /// <summary>
        /// Gets or sets the service bus topic message.
        /// </summary>
        [JsonProperty(PropertyName = "serviceBusTopicMessage")]
        public ServiceBusTopicMessage ServiceBusTopicMessage { get; set; }

        /// <summary>
        /// Gets or sets the retry policy.
        /// </summary>
        [JsonProperty(PropertyName = "retryPolicy")]
        public RetryPolicy RetryPolicy { get; set; }

        /// <summary>
        /// Gets or sets the error action.
        /// </summary>
        [JsonProperty(PropertyName = "errorAction")]
        public JobErrorAction ErrorAction { get; set; }

    }
}
