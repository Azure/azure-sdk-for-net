// -----------------------------------------------------------------------------------------
// <copyright file="GetMessagesResponse.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Provides methods for parsing the response from an operation to get messages from a queue.
    /// </summary>
#if WINDOWS_RT
    internal
#else
    public
#endif
 sealed class GetMessagesResponse : ResponseParsingBase<QueueMessage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetMessagesResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream of messages to parse.</param>
        public GetMessagesResponse(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Gets an enumerable collection of <see cref="QueueMessage"/> objects from the response.
        /// </summary>
        /// <value>An enumerable collection of <see cref="QueueMessage"/> objects.</value>
        public IEnumerable<QueueMessage> Messages
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Parses a message entry in a queue get messages response.
        /// </summary>
        /// <returns>Message entry</returns>
        private QueueMessage ParseMessageEntry()
        {
            QueueMessage message = null;
            string id = null;
            string popReceipt = null;
            DateTime? insertionTime = null;
            DateTime? expirationTime = null;
            DateTime? timeNextVisible = null;
            string text = null;
            int dequeueCount = 0;

            this.reader.ReadStartElement();
            while (this.reader.IsStartElement())
            {
                if (this.reader.IsEmptyElement)
                {
                    this.reader.Skip();
                }
                else
                {
                    switch (reader.Name)
                    {
                        case Constants.MessageIdElement:
                            id = reader.ReadElementContentAsString();
                            break;

                        case Constants.PopReceiptElement:
                            popReceipt = reader.ReadElementContentAsString();
                            break;

                        case Constants.InsertionTimeElement:
                            insertionTime = reader.ReadElementContentAsString().ToUTCTime();
                            break;

                        case Constants.ExpirationTimeElement:
                            expirationTime = reader.ReadElementContentAsString().ToUTCTime();
                            break;

                        case Constants.TimeNextVisibleElement:
                            timeNextVisible = reader.ReadElementContentAsString().ToUTCTime();
                            break;

                        case Constants.MessageTextElement:
                            text = reader.ReadElementContentAsString();
                            break;

                        case Constants.DequeueCountElement:
                            dequeueCount = reader.ReadElementContentAsInt();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            this.reader.ReadEndElement();
            message = new QueueMessage();
            message.Text = text;
            message.Id = id;
            message.PopReceipt = popReceipt;
            message.DequeueCount = dequeueCount;

            if (insertionTime != null)
            {
                message.InsertionTime = (DateTime)insertionTime;
            }

            if (expirationTime != null)
            {
                message.ExpirationTime = (DateTime)expirationTime;
            }

            if (timeNextVisible != null)
            {
                message.NextVisibleTime = (DateTime)timeNextVisible;
            }

            return message;
        }

        /// <summary>
        /// Parses the XML response returned by an operation to get messages from a queue.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="QueueMessage"/> objects.</returns>
        protected override IEnumerable<QueueMessage> ParseXml()
        {
            if (this.reader.ReadToFollowing(Constants.MessagesElement))
            {
                if (this.reader.IsEmptyElement)
                {
                    this.reader.Skip();
                }
                else
                {
                    this.reader.ReadStartElement();
                    while (this.reader.IsStartElement())
                    {
                        if (this.reader.IsEmptyElement)
                        {
                            this.reader.Skip();
                        }
                        else
                        {
                            switch (this.reader.Name)
                            {
                                case Constants.MessageElement:
                                    while (this.reader.IsStartElement())
                                    {
                                        yield return this.ParseMessageEntry();
                                    }

                                    break;

                                default:
                                    reader.Skip();
                                    break;
                            }
                        }
                    }

                    this.allObjectsParsed = true;
                    this.reader.ReadEndElement();
                }
            }
        }
    }
}