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
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.ServiceLayer.Http;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.Storage.Streams;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Settings of a new brokered message.
    /// </summary>
    /// <remarks>Brokered messages support custom properties (see Properties).
    /// A custom property can be a string, a number, a date/time, or a Boolean
    /// variable; specifying a value of any other type will result in an error
    /// when sending the message. Setting a property to null will result in its
    /// removal from the message.
    /// All numeric properties will read as doubles when reading the message.</remarks>
    public sealed class BrokeredMessageSettings
    {
        private BrokerProperties _brokerProperties;             // Message's broker properties.
        private CustomPropertiesDictionary _customProperties;   // Custom properties of the message.

        /// <summary>
        /// Message content.
        /// </summary>
        public HttpContent Content { get; private set; }

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
        /// Creates a message with the given content.
        /// </summary>
        /// <param name="content">Content of the message.</param>
        /// <returns>Brokered message.</returns>
        public static BrokeredMessageSettings CreateFromContent(HttpContent content)
        {
            Validator.ArgumentIsNotNull("content", content);

            return new BrokeredMessageSettings(content);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="content">Message content.</param>
        private BrokeredMessageSettings(HttpContent content)
        {
            Content = content;
            _brokerProperties = new BrokerProperties();
            _customProperties = new CustomPropertiesDictionary();
        }

        /// <summary>
        /// Creates a message with the default content type from the given 
        /// text.
        /// </summary>
        /// <param name="messageText">Message text.</param>
        /// <returns>Message settings.</returns>
        public static BrokeredMessageSettings CreateFromText(string messageText)
        {
            return CreateFromText(messageText, Constants.DefaultMessageContentType);
        }

        /// <summary>
        /// Creates a message with the specified content type from the given 
        /// text.
        /// </summary>
        /// <param name="messageText">Message text.</param>
        /// <param name="contentType">Content type.</param>
        /// <returns>Message settings.</returns>
        public static BrokeredMessageSettings CreateFromText(string messageText, string contentType)
        {
            Validator.ArgumentIsNotNull("messageText", messageText);
            Validator.ArgumentIsNotNullOrEmptyString("contentType", contentType);

            HttpContent content = HttpContent.CreateFromText(messageText, contentType);
            return new BrokeredMessageSettings(content);
        }

        /// <summary>
        /// Creates a message from the array of bytes. This method exists only
        /// because JavaScript cannot work with multiple constructors with
        /// identical number of parameters.
        /// </summary>
        /// <param name="messageBytes">Array of bytes.</param>
        /// <returns>Message settings.</returns>
        public static BrokeredMessageSettings CreateFromByteArray([ReadOnlyArray] byte[] messageBytes)
        {
            Validator.ArgumentIsNotNull("messageBytes", messageBytes);

            HttpContent content = HttpContent.CreateFromByteArray(messageBytes);
            return new BrokeredMessageSettings(content);
        }

        /// <summary>
        /// Creates a message from the given stream. The method exists only
        /// because JavaScript cannot work with multiple constructors with
        /// identical number of parameters.
        /// </summary>
        /// <param name="stream">Stream with message data.</param>
        /// <returns>Message settings.</returns>
        public static BrokeredMessageSettings CreateFromStream(IInputStream stream)
        {
            Validator.ArgumentIsNotNull("stream", stream);

            HttpContent content = HttpContent.CreateFromStream(stream);
            return new BrokeredMessageSettings(content);
        }

        /// <summary>
        /// Submits content to the given request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequest request)
        {
            _brokerProperties.SubmitTo(request);
            _customProperties.SubmitTo(request);
            request.Content = Content;
        }
    }
}
