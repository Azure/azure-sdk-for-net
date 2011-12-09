//-----------------------------------------------------------------------
// <copyright file="GetPageRangesResponse.cs" company="Microsoft">
//    Copyright 2011 Microsoft Corporation
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
//    Contains code for the GetPageRangesResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Provides methods for parsing the response from an operation to get a range of pages for a page blob.
    /// </summary>
    public class GetPageRangesResponse : ResponseParsingBase<PageRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPageRangesResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream of page ranges to be parsed.</param>
        internal GetPageRangesResponse(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Gets an enumerable collection of <see cref="PageRange"/> objects from the response.
        /// </summary>
        /// <value>An enumerable collection of <see cref="PageRange"/> objects.</value>
        public IEnumerable<PageRange> PageRanges
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Parses the XML response for an operation to get a range of pages for a page blob.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="PageRange"/> objects.</returns>
        protected override IEnumerable<PageRange> ParseXml()
        {
            // While we're still in the QueueMessageList section.
            while (reader.Read())
            {
                // We found a queue message.
                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.PageRangeElement)
                {
                    PageRange pageRange = null;
                    long start = 0L;
                    long end = 0L;
                    bool needToRead = true;

                    // Go until we are out of the block.
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
                                case Constants.StartElement:
                                    start = reader.ReadElementContentAsLong();
                                    needToRead = false;
                                    break;
                                case Constants.EndElement:
                                    end = reader.ReadElementContentAsLong();
                                    needToRead = false;
                                    break;
                            }
                        }
                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.PageRangeElement)
                        {
                            pageRange = new PageRange(start, end);
                            break;
                        }
                    }

                    yield return pageRange;
                }
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.PageListElement)
                {
                    break;
                }
            }
        }
    }
}
