//-----------------------------------------------------------------------
// <copyright file="GetBlockListResponse.cs" company="Microsoft">
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
    /// Provides methods for parsing the response from an operation to return a block list.
    /// </summary>
#if WINDOWS_RT
    internal
#else
    public
#endif
        class GetBlockListResponse : ResponseParsingBase<ListBlockItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetBlockListResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        public GetBlockListResponse(Stream stream)
            : base(stream)
        {
        }

        /// <summary>
        /// Gets an enumerable collection of <see cref="ListBlockItem"/> objects from the response.
        /// </summary>
        /// <value>An enumerable collection of <see cref="ListBlockItem"/> objects.</value>
        public IEnumerable<ListBlockItem> Blocks
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Reads a block item for block listing.
        /// </summary>
        /// <param name="committed">Whether we are currently listing committed blocks or not</param>
        /// <returns>Block listing entry</returns>
        private ListBlockItem ParseBlockItem(bool committed)
        {
            ListBlockItem block = new ListBlockItem()
            {
                Committed = committed,
            };

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
                        case Constants.SizeElement:
                            block.Length = reader.ReadElementContentAsLong();
                            break;

                        case Constants.NameElement:
                            block.Name = reader.ReadElementContentAsString();
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            this.reader.ReadEndElement();

            return block;
        }

        /// <summary>
        /// Parses the XML response returned by an operation to retrieve a list of blocks.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="ListBlockItem"/> objects.</returns>
        protected override IEnumerable<ListBlockItem> ParseXml()
        {
            if (this.reader.ReadToFollowing(Constants.BlockListElement))
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
                                case Constants.CommittedBlocksElement:
                                    this.reader.ReadStartElement();
                                    while (this.reader.IsStartElement(Constants.BlockElement))
                                    {
                                        yield return this.ParseBlockItem(true);
                                    }

                                    this.reader.ReadEndElement();
                                    break;

                                case Constants.UncommittedBlocksElement:
                                    this.reader.ReadStartElement();
                                    while (this.reader.IsStartElement(Constants.BlockElement))
                                    {
                                        yield return this.ParseBlockItem(false);
                                    }

                                    this.reader.ReadEndElement();
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
