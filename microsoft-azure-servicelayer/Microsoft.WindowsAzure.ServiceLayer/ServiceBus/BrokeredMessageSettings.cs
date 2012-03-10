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
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Settings of a new brokered message.
    /// </summary>
    public sealed class BrokeredMessageSettings
    {
        private HttpContent _content;                           // Body content.
        private BrokerProperties _brokerProperties;             // Broker properties of the message.
        private CustomPropertiesDictionary _customProperties;   // Custom properties of the message.

        /// <summary>
        /// Gets the content type of the message.
        /// </summary>
        public string ContentType
        {
            get { return _content.Headers.ContentType.ToString(); }
        }

        /// <summary>
        /// Gets or sets the identifier of the correlation.
        /// </summary>
        public string CorrelationId 
        { 
            get { return _brokerProperties.CorrelationId; } 
            set { _brokerProperties.CorrelationId = value; } 
        }

        /// <summary>
        /// Gets or sets the application specific label.
        /// </summary>
        public string Label 
        { 
            get { return _brokerProperties.Label; } 
            set { _brokerProperties.Label = value; } 
        }

        /// <summary>
        /// Gets or sets the identifier of the message.
        /// </summary>
        public string MessageId
        {
            get { return _brokerProperties.MessageId; }
            set { _brokerProperties.MessageId = value; }
        }

        /// <summary>
        /// Gets the property bag.
        /// </summary>
        public IDictionary<string, object> Properties 
        { 
            get { return _customProperties; } 
        }

        /// <summary>
        /// Gets or sets the address of the queue to reply to.
        /// </summary>
        public string ReplyTo
        {
            get { return _brokerProperties.ReplyTo; }
            set { _brokerProperties.ReplyTo = value; }
        }

        /// <summary>
        /// Gets or sets the session identifier to reply to.
        /// </summary>
        public string ReplyToSessionId
        {
            get { return _brokerProperties.ReplyToSessionId; }
            set { _brokerProperties.ReplyToSessionId = value; }
        }

        /// <summary>
        /// Gets or sets the date and time at which the message will be 
        /// enqueued.
        /// </summary>
        public DateTimeOffset? ScheduledEnqueueTime
        {
            get { return _brokerProperties.ScheduledEnqueueTime; }
            set { _brokerProperties.ScheduledEnqueueTime = value; }
        }

        /// <summary>
        /// Gets or sets the identifier of the session.
        /// </summary>
        public string SessionId
        {
            get { return _brokerProperties.SessionId; }
            set { _brokerProperties.SessionId = value; }
        }

        /// <summary>
        /// Gets or sets the message's time to live.
        /// </summary>
        public TimeSpan? TimeToLive
        {
            get { return _brokerProperties.TimeToLive; }
            set { _brokerProperties.TimeToLive = value; } 
        }

        /// <summary>
        /// Gets or sets the send to address.
        /// </summary>
        public string To
        {
            get { return _brokerProperties.To; }
            set { _brokerProperties.To = value; }
        }

        /// <summary>
        /// Constructor for a message consisting of text.
        /// </summary>
        /// <param name="messageText">Text of the message.</param>
        public BrokeredMessageSettings(string contentType, string messageText)
        {
            if (contentType == null)
            {
                throw new ArgumentNullException("contentType");
            }
            if (messageText == null)
            {
                throw new ArgumentNullException("messageText");
            }
            _content = new StringContent(messageText, Encoding.UTF8, contentType);
            _brokerProperties = new BrokerProperties();
            _customProperties = new CustomPropertiesDictionary();
        }

        /// <summary>
        /// Constructor for a message consisting of bytes.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="messageBytes">Content of the message.</param>
        public BrokeredMessageSettings(byte[] messageBytes)
        {
            if (messageBytes == null)
            {
                throw new ArgumentNullException("messageBytes");
            }
            _content = new ByteArrayContent(messageBytes);
            _brokerProperties = new BrokerProperties();
            _customProperties = new CustomPropertiesDictionary();
        }

        /// <summary>
        /// Constructor for a message with the content specified in the stream.
        /// </summary>
        /// <param name="contentType">Content type.</param>
        /// <param name="stream">Stream with the content.</param>
        public BrokeredMessageSettings(IInputStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            _content = new StreamContent(stream.AsStreamForRead());
            _brokerProperties = new BrokerProperties();
            _customProperties = new CustomPropertiesDictionary();
        }

        /// <summary>
        /// Reads message's body as a string. This method is not thread-safe.
        /// </summary>
        /// <returns>Message body.</returns>
        public IAsyncOperation<string> ReadContentAsStringAsync()
        {
            return _content
                .ReadAsStringAsync()
                .AsAsyncOperation();
        }

        /// <summary>
        /// Reads message's body as an array of bytes.
        /// </summary>
        /// <returns>Message body.</returns>
        public IAsyncOperation<byte[]> ReadContentAsBytesAsync()
        {
            return _content
                .ReadAsByteArrayAsync()
                .AsAsyncOperation();
        }

        /// <summary>
        /// Gets stream with the content of the message.
        /// </summary>
        /// <returns>Stream with the content.</returns>
        public IAsyncOperation<IInputStream> ReadContentAsStreamAsync()
        {
            return _content
                .ReadAsStreamAsync()
                .ContinueWith(t => t.Result.AsInputStream(), TaskContinuationOptions.OnlyOnRanToCompletion)
                .AsAsyncOperation();
        }

        /// <summary>
        /// Copies content of the body to the given stream.
        /// </summary>
        /// <param name="stream">Target stream.</param>
        /// <returns>Result of the operation.</returns>
        public IAsyncAction CopyContentToAsync(IOutputStream stream)
        {
            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }
            return _content
                .CopyToAsync(stream.AsStreamForWrite())
                .AsAsyncAction();
        }

        /// <summary>
        /// Submits content to the given request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            _brokerProperties.SubmitTo(request);
            _customProperties.SubmitTo(request);
            request.Content = _content;
        }
    }
}
