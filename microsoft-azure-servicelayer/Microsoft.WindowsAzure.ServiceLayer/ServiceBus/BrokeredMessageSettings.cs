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
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.ServiceLayer.ServiceBus
{
    /// <summary>
    /// Settings of a new brokered message.
    /// </summary>
    public sealed class BrokeredMessageSettings
    {
        /// <summary>
        /// Gets broker propertiesof the message.
        /// </summary>
        private BrokerProperties BrokerProperties { get; set; }

        /// <summary>
        /// Text of the message.
        /// </summary>
        public string Text { get; internal set; }

        /// <summary>
        /// Gets or sets the identifier of the correlation.
        /// </summary>
        public string CorrelationId 
        { 
            get { return BrokerProperties.CorrelationId; } 
            set { BrokerProperties.CorrelationId = value; } 
        }

        /// <summary>
        /// Gets or sets the application specific label.
        /// </summary>
        public string Label 
        { 
            get { return BrokerProperties.Label; } 
            set { BrokerProperties.Label = value; } 
        }

        /// <summary>
        /// Gets or sets the identifier of the message.
        /// </summary>
        public string MessageId
        {
            get { return BrokerProperties.MessageId; }
            set { BrokerProperties.MessageId = value; }
        }

        /// <summary>
        /// Gets or sets the address of the queue to reply to.
        /// </summary>
        public string ReplyTo
        {
            get { return BrokerProperties.ReplyTo; }
            set { BrokerProperties.ReplyTo = value; }
        }

        /// <summary>
        /// Gets or sets the session identifier to reply to.
        /// </summary>
        public string ReplyToSessionId
        {
            get { return BrokerProperties.ReplyToSessionId; }
            set { BrokerProperties.ReplyToSessionId = value; }
        }

        /// <summary>
        /// Gets or sets the date and time at which the message will be 
        /// enqueued.
        /// </summary>
        public DateTime? ScheduledEnqueueTime
        {
            get { return BrokerProperties.ScheduledEnqueueTime; }
            set { BrokerProperties.ScheduledEnqueueTime = value; }
        }

        /// <summary>
        /// Gets or sets the identifier of the session.
        /// </summary>
        public string SessionId
        {
            get { return BrokerProperties.SessionId; }
            set { BrokerProperties.SessionId = value; }
        }

        /// <summary>
        /// Gets or sets the message's time to live.
        /// </summary>
        public TimeSpan? TimeToLive
        {
            get { return BrokerProperties.TimeToLive; }
            set { BrokerProperties.TimeToLive = value; } 
        }

        /// <summary>
        /// Gets or sets the send to address.
        /// </summary>
        public string To
        {
            get { return BrokerProperties.To; }
            set { BrokerProperties.To = value; }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="messageText">Text of the message.</param>
        public BrokeredMessageSettings(string messageText)
        {
            if (messageText == null)
            {
                throw new ArgumentNullException("messageText");
            }

            Text = messageText;
            BrokerProperties = new BrokerProperties();
        }

        /// <summary>
        /// Submits content to the given request.
        /// </summary>
        /// <param name="request">Target request.</param>
        internal void SubmitTo(HttpRequestMessage request)
        {
            request.Content = new StringContent(Text, Encoding.UTF8, Constants.MessageContentType);
            BrokerProperties.SubmitTo(request);
        }
    }
}
