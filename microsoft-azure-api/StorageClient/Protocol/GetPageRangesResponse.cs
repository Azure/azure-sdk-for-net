//-----------------------------------------------------------------------
// <copyright file="GetPageRangesResponse.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
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
