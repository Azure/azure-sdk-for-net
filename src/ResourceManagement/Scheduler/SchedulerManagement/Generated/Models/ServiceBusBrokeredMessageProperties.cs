
namespace Microsoft.Azure.Management.Scheduler.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class ServiceBusBrokeredMessageProperties
    {
        /// <summary>
        /// Initializes a new instance of the
        /// ServiceBusBrokeredMessageProperties class.
        /// </summary>
        public ServiceBusBrokeredMessageProperties() { }

        /// <summary>
        /// Initializes a new instance of the
        /// ServiceBusBrokeredMessageProperties class.
        /// </summary>
        public ServiceBusBrokeredMessageProperties(string contentType = default(string), string correlationId = default(string), bool? forcePersistence = default(bool?), string label = default(string), string messageId = default(string), string partitionKey = default(string), string replyTo = default(string), string replyToSessionId = default(string), DateTime? scheduledEnqueueTimeUtc = default(DateTime?), string sessionId = default(string), DateTime? timeToLive = default(DateTime?), string to = default(string), string viaPartitionKey = default(string))
        {
            ContentType = contentType;
            CorrelationId = correlationId;
            ForcePersistence = forcePersistence;
            Label = label;
            MessageId = messageId;
            PartitionKey = partitionKey;
            ReplyTo = replyTo;
            ReplyToSessionId = replyToSessionId;
            ScheduledEnqueueTimeUtc = scheduledEnqueueTimeUtc;
            SessionId = sessionId;
            TimeToLive = timeToLive;
            To = to;
            ViaPartitionKey = viaPartitionKey;
        }

        /// <summary>
        /// Gets or sets the content type.
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// Gets or sets the correlation id.
        /// </summary>
        [JsonProperty(PropertyName = "correlationId")]
        public string CorrelationId { get; set; }

        /// <summary>
        /// Gets or sets the force persistence.
        /// </summary>
        [JsonProperty(PropertyName = "forcePersistence")]
        public bool? ForcePersistence { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the message id.
        /// </summary>
        [JsonProperty(PropertyName = "messageId")]
        public string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the partition key.
        /// </summary>
        [JsonProperty(PropertyName = "partitionKey")]
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the reply to.
        /// </summary>
        [JsonProperty(PropertyName = "replyTo")]
        public string ReplyTo { get; set; }

        /// <summary>
        /// Gets or sets the reply to session id.
        /// </summary>
        [JsonProperty(PropertyName = "replyToSessionId")]
        public string ReplyToSessionId { get; set; }

        /// <summary>
        /// Gets or sets the scheduled enqueue time UTC.
        /// </summary>
        [JsonProperty(PropertyName = "scheduledEnqueueTimeUtc")]
        public DateTime? ScheduledEnqueueTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the session id.
        /// </summary>
        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the time to live.
        /// </summary>
        [JsonProperty(PropertyName = "timeToLive")]
        public DateTime? TimeToLive { get; set; }

        /// <summary>
        /// Gets or sets the to.
        /// </summary>
        [JsonProperty(PropertyName = "to")]
        public string To { get; set; }

        /// <summary>
        /// Gets or sets the via partition key.
        /// </summary>
        [JsonProperty(PropertyName = "viaPartitionKey")]
        public string ViaPartitionKey { get; set; }

    }
}
