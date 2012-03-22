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
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Windows.Foundation;
using Windows.Storage.Streams;

using NetHttpContent = System.Net.Http.HttpContent;
using NetHttpResponseMessage = System.Net.Http.HttpResponseMessage;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Brokered message obtained from the service.
    /// </summary>
    public sealed class BrokeredMessageInfo
    {
        private HttpContent _content;                               // Source HTTP content.
        private BrokerProperties _brokerProperties;                 // Message's broker properties.
        private CustomPropertiesDictionary _customProperties;       // Custom properties of the message.

        /// <summary>
        /// Gets the content type of the message.
        /// </summary>
        public string ContentType
        {
            get { return _content.ContentType; }
        }

        /// <summary>
        /// Gets the identifier of the correlation.
        /// </summary>
        public string CorrelationId
        {
            get { return _brokerProperties.CorrelationId; }
        }

        /// <summary>
        /// Gets the number of deliveries.
        /// </summary>
        public int DeliveryCount
        {
            get { return _brokerProperties.DeliveryCount.Value; }
        }

        /// <summary>
        /// Gets the date and time of the sent time.
        /// </summary>
        public DateTimeOffset? EnqueuedTime
        {
            get { return _brokerProperties.EnqueuedTime; }
        }

        /// <summary>
        /// Gets the date and time at which the message is set to expire.
        /// </summary>
        public DateTimeOffset? ExpiresAt
        {
            get { return _brokerProperties.ExpiresAt; }
        }

        /// <summary>
        /// Gets the application specific label.
        /// </summary>
        public string Label
        {
            get { return _brokerProperties.Label; }
        }

        /// <summary>
        /// Gets the date and time until which the message will be locked in
        /// the queue/subscription.
        /// </summary>
        public DateTimeOffset? LockedUntil
        {
            get { return _brokerProperties.LockedUntil; }
        }

        /// <summary>
        /// Gets the lock token assigned by Service Bus to the message.
        /// </summary>
        public string LockToken
        {
            get { return _brokerProperties.LockToken; }
        }

        /// <summary>
        /// Gets the identifier of the message.
        /// </summary>
        public string MessageId
        {
            get { return _brokerProperties.MessageId; } 
        }

        /// <summary>
        /// Gets the property bag.
        /// </summary>
        public IDictionary<string, object> Properties
        {
            get { return _customProperties; }
        }

        /// <summary>
        /// Gets the address of the queue to reply to.
        /// </summary>
        public string ReplyTo
        {
            get { return _brokerProperties.ReplyTo; }
        }

        /// <summary>
        /// Gets the session identifier to reply to.
        /// </summary>
        public string ReplyToSessionId
        {
            get { return _brokerProperties.ReplyToSessionId; }
        }

        /// <summary>
        /// Gets the date and time at which the message will be enqueued.
        /// </summary>
        public DateTimeOffset? ScheduledEnqueueTime
        {
            get { return _brokerProperties.ScheduledEnqueueTime; }
        }

        /// <summary>
        /// Gets the unique number assigned to the message by the Service Bus.
        /// </summary>
        public long SequenceNumber
        {
            get { return _brokerProperties.SequenceNumber.Value; }
        }

        /// <summary>
        /// Gets the identifier of the session.
        /// </summary>
        public string SessionId
        {
            get { return _brokerProperties.SessionId; }
        }

        /// <summary>
        /// Gets the size of the message in bytes.
        /// </summary>
        public long Size
        {
            get { return _brokerProperties.Size.Value; }
        }

        /// <summary>
        /// Gets the message's time to live.
        /// </summary>
        public TimeSpan? TimeToLive
        {
            get { return _brokerProperties.TimeToLive; }
        }

        /// <summary>
        /// Gets the send to address.
        /// </summary>
        public string To
        {
            get { return _brokerProperties.To; }
        }

        /// <summary>
        /// Reads content of the message as a string.
        /// </summary>
        /// <returns>Content of the message.</returns>
        public IAsyncOperation<string> ReadContentAsStringAsync()
        {
            return _content.ReadAsStringAsync();
        }

        /// <summary>
        /// Reads the content as an array of bytes.
        /// </summary>
        /// <returns>Array of bytes.</returns>
        public IAsyncOperation<IEnumerable<byte>> ReadContentAsBytesAsync()
        {
            return _content.ReadAsByteArrayAsync();
        }

        /// <summary>
        /// Reads the content as a stream.
        /// </summary>
        /// <returns>Stream.</returns>
        public IAsyncOperation<IInputStream> ReadContentAsStreamAsync()
        {
            return _content.ReadAsStreamAsync();
        }

        /// <summary>
        /// Copies content into the given stream.
        /// </summary>
        /// <param name="stream">Target stream.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncInfo CopyContentToAsync(IOutputStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            return _content.CopyToAsync(stream);
        }

        /// <summary>
        /// Creates a brokered message from the response. Returns null if the
        /// response contains no data.
        /// </summary>
        /// <param name="response">Response with data.</param>
        /// <returns></returns>
        internal static BrokeredMessageInfo CreateFromPeekResponse(NetHttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.NoContent || response.StatusCode == System.Net.HttpStatusCode.ResetContent)
            {
                return null;
            }
            return new BrokeredMessageInfo(response);
        }

        /// <summary>
        /// Constructor. Initializes the object from the HTTP response.
        /// </summary>
        /// <param name="response">HTTP reponse with the data.</param>
        internal BrokeredMessageInfo(NetHttpResponseMessage response)
        {
            Debug.Assert(response.IsSuccessStatusCode);
            _content = HttpContent.CreateFromResponse(response);
            _customProperties = new CustomPropertiesDictionary(response);

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(Dictionary<string, object>));
            string propertiesString = null;
            IEnumerable<string> values;

            if (response.Headers.TryGetValues(Constants.BrokerPropertiesHeader, out values))
            {
                propertiesString = string.Join(string.Empty, values);
            }

            if (string.IsNullOrEmpty(propertiesString))
            {
                _brokerProperties = new BrokerProperties();
            }
            else
            {
                _brokerProperties = BrokerProperties.Deserialize(propertiesString);
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        public BrokeredMessageInfo()
        {
            //TODO: get rid of this constructor once the issue with JavaScript serialization has been fixed.
        }
    }
}
