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
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using Microsoft.WindowsAzure.ServiceLayer.Http;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Properties of a brokered message. This class is used as a collection of
    /// properties for BrokeredMessageSettings and BrokeredMessageInfo classes.
    /// </summary>
    [DataContract]
    internal class BrokerProperties
    {
        /// <summary>
        /// Gets or sets the identifier of the correlation.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string CorrelationId { get; set; }

        /// <summary>
        /// Gets the number of deliveries.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal int? DeliveryCount { get; set; }

        /// <summary>
        /// Gets/sets the date and time of the sent time.
        /// </summary>
        [IgnoreDataMember]
        internal DateTimeOffset? EnqueuedTime { get; set; }

        /// <summary>
        /// EnqueuedTime property as a string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string EnqueuedTimeUtc { get; set; }

        /// <summary>
        /// Gets/sets the date and time at whcih the message is set to expire.
        /// </summary>
        [IgnoreDataMember]
        internal DateTimeOffset? ExpiresAt { get; set; }

        /// <summary>
        /// ExpiresAt property as a string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string ExpiresAtUtc { get; set; }

        /// <summary>
        /// Get/set the application specific label.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string Label { get; set; }

        /// <summary>
        /// Gets/sets the date and time until which the message will be locked
        /// in the queue/subscription.
        /// </summary>
        [IgnoreDataMember]
        internal DateTimeOffset? LockedUntil { get; set; }

        /// <summary>
        /// LockedUntil property as a string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string LockedUntilUtc { get; set; }

        /// <summary>
        /// Gets/sets the lock token assigned by Service Bus to the message.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string LockToken { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the message.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string MessageId { get; set; }

        /// <summary>
        /// Gets or sets the address of the queue to reply to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string ReplyTo { get; set; }

        /// <summary>
        /// Gets or sets the session identifier to reply to.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string ReplyToSessionId { get; set; }

        /// <summary>
        /// Gets or sets the date and time at which the message will be 
        /// enqueued.
        /// </summary>
        [IgnoreDataMember]
        internal DateTimeOffset? ScheduledEnqueueTime { get; set; }

        /// <summary>
        /// ScheduledEnqueueTime property as a string.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string ScheduledEnqueueTimeUtc { get; set; }

        /// <summary>
        /// Gets or sets the unique number assigned to the message by the 
        /// Service Bus.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal long? SequenceNumber { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the session.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string SessionId { get; set; }

        /// <summary>
        /// Gets or sets the size of the message in bytes.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal long? Size { get; set; }

        /// <summary>
        /// Gets or sets the message's time to live.
        /// </summary>
        [IgnoreDataMember]
        internal TimeSpan? TimeToLive { get; set; }

        /// <summary>
        /// TimeToLive property as a string.
        /// </summary>
        [DataMember(Name = "TimeToLive", EmitDefaultValue = false)]
        internal double? TimeToLiveDouble { get; set; }

        /// <summary>
        /// Gets or sets the send to address.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        internal string To { get; set; }

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal BrokerProperties()
        {
        }

        /// <summary>
        /// Creates an object from JSon data.
        /// </summary>
        /// <param name="jsonData">Json data.</param>
        /// <returns></returns>
        internal static BrokerProperties Deserialize(string jsonData)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonData)))
            {
                BrokerProperties properties = serializer.ReadObject(stream) as BrokerProperties;
                return properties;
            }
        }

        /// <summary>
        /// Prepares data for serialization.
        /// </summary>
        /// <param name="context">Serialization context.</param>
        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            EnqueuedTimeUtc = DateTimeToUtcString(EnqueuedTime);
            ExpiresAtUtc = DateTimeToUtcString(ExpiresAt);
            LockedUntilUtc = DateTimeToUtcString(LockedUntil);
            ScheduledEnqueueTimeUtc = DateTimeToUtcString(ScheduledEnqueueTime);
            TimeToLiveDouble = TimeSpanToSeconds(TimeToLive);
        }

        /// <summary>
        /// Finalizes data after deserialization.
        /// </summary>
        /// <param name="context"></param>
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            EnqueuedTime = StringToUtcDateTime(EnqueuedTimeUtc);
            ExpiresAt = StringToUtcDateTime(ExpiresAtUtc);
            LockedUntil = StringToUtcDateTime(LockedUntilUtc);
            ScheduledEnqueueTime = StringToUtcDateTime(ScheduledEnqueueTimeUtc);

            if (TimeToLiveDouble.HasValue)
            {
                TimeToLive = TimeSpan.FromMilliseconds(TimeToLiveDouble.Value);
            }
        }

        /// <summary>
        /// Converts a nullable date/time to UTC time zone.
        /// </summary>
        /// <param name="source">Source date/time.</param>
        /// <returns>UTC date/time.</returns>
        private static string DateTimeToUtcString(DateTimeOffset? source)
        {
            string result = null;

            if (source.HasValue)
            {
                result = Convert.ToString(source.Value.ToUniversalTime(), CultureInfo.InvariantCulture);
            }
            return result;
        }

        /// <summary>
        /// Converts nullable time span into seconds.
        /// </summary>
        /// <param name="span">Source time span.</param>
        /// <returns>Seconds.</returns>
        private static double? TimeSpanToSeconds(TimeSpan? span)
        {
            double? retValue = null;

            if (span.HasValue)
            {
                retValue = span.Value.TotalMilliseconds;
            }
            return retValue;
        }

        /// <summary>
        /// Converts date/time string into a nullable DateTime.
        /// </summary>
        /// <param name="value">Date/time string to convert.</param>
        /// <returns>Converted value.</returns>
        private DateTimeOffset? StringToUtcDateTime(string value)
        {
            DateTimeOffset? retValue = null;

            if (!string.IsNullOrEmpty(value))
            {
                DateTime dateTime = Convert.ToDateTime(value, CultureInfo.InvariantCulture);
                retValue = new DateTimeOffset(dateTime.ToUniversalTime());
            }
            return retValue;
        }

        /// <summary>
        /// Submits content of the class to the given HTTP request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequest request)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(BrokerProperties));
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.WriteObject(stream, this);
                stream.Flush();
                stream.Seek(0, SeekOrigin.Begin);
                StreamReader reader = new StreamReader(stream);
                string content = reader.ReadToEnd();
                request.Headers.Add(Constants.BrokerPropertiesHeader, content);
            }
        }
    }
}
