//-----------------------------------------------------------------------
// <copyright file="GetPageRangesResponse.cs" company="Microsoft">
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
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.Storage.Blob.Protocol
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Provides methods for parsing the response from an operation to get a range of pages for a page blob.
    /// </summary>
#if WINDOWS_DESKTOP
    public
#else
    internal
#endif
        sealed class GetPageRangesResponse : ResponseParsingBase<PageRange>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPageRangesResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream of page ranges to be parsed.</param>
        public GetPageRangesResponse(Stream stream)
            : base(stream)
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
        /// Reads a page range.
        /// </summary>
        /// <returns>Page range entry</returns>
        private PageRange ParsePageRange()
        {
            long start = 0L;
            long end = 0L;

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
                        case Constants.StartElement:
                            start = reader.ReadElementContentAsLong();
                            break;

                        case Constants.EndElement:
                            end = reader.ReadElementContentAsLong();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            this.reader.ReadEndElement();

            return new PageRange(start, end);
        }

        /// <summary>
        /// Parses the XML response for an operation to get a range of pages for a page blob.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="PageRange"/> objects.</returns>
        protected override IEnumerable<PageRange> ParseXml()
        {
            if (this.reader.ReadToFollowing(Constants.PageListElement))
            {
                if (this.reader.IsEmptyElement)
                {
                    this.reader.Skip();
                }
                else
                {
                    this.reader.ReadStartElement();
                    while (this.reader.IsStartElement(Constants.PageRangeElement))
                    {
                        yield return this.ParsePageRange();
                    }

                    this.allObjectsParsed = true;
                    this.reader.ReadEndElement();
                }
            }
        }
    }
}
