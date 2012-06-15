﻿//-----------------------------------------------------------------------
// <copyright file="PeekMessagesResponse.cs" company="Microsoft">
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
// <summary>
//    Contains code for the PeekMessagesResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Provides methods for parsing the response from an operation to peek messages from a queue.
    /// </summary>
    public class PeekMessagesResponse : ResponseParsingBase<QueueMessage>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PeekMessagesResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal PeekMessagesResponse(Stream stream) : base(stream)
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
        /// Parses the XML response returned by an operation to get messages from a queue.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="QueueMessage"/> objects.</returns>
        protected override IEnumerable<QueueMessage> ParseXml()
        {
            // While we're still in the QueueMessageList section.
            while (reader.Read())
            {
                // We found a queue message.
                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.MessageElement)
                {
                    QueueMessage message = null;
                    string id = null;
                    DateTime? insertionTime = null;
                    DateTime? expirationTime = null;
                    string text = null;
                    int dequeueCount = 0;

                    // Go until we are out of the block.
                    bool needToRead = true;
                    while (true)
                    {
                        if (needToRead && !reader.Read())
                        {
                            break;
                        }

                        needToRead = true;

                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                        {
                            switch (reader.Name)
                            {
                                case Constants.MessageIdElement:
                                    id = reader.ReadElementContentAsString();
                                    needToRead = false;
                                    break;
                                case Constants.InsertionTimeElement:
                                    insertionTime = reader.ReadElementContentAsString().ToUTCTime();
                                    needToRead = false;
                                    break;
                                case Constants.ExpirationTimeElement:
                                    expirationTime = reader.ReadElementContentAsString().ToUTCTime();
                                    needToRead = false;
                                    break;
                                case Constants.MessageTextElement:
                                    text = reader.ReadElementContentAsString();
                                    needToRead = false;
                                    break;
                                case Constants.DequeueCountElement:
                                    dequeueCount = reader.ReadElementContentAsInt();
                                    needToRead = false;
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.MessageElement)
                        {
                            message = new QueueMessage();
                            message.Id = id;
                            message.Text = text;
                            message.DequeueCount = dequeueCount;

                            if (expirationTime != null)
                            {
                                message.ExpirationTime = (DateTime)expirationTime;
                            }

                            if (insertionTime != null)
                            {
                                message.InsertionTime = (DateTime)insertionTime;
                            }

                            break;
                        }
                    }

                    yield return message;
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.MessagesElement)
                {
                    break;
                }
            }
        }
    }
}
