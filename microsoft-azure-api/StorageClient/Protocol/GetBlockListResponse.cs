//-----------------------------------------------------------------------
// <copyright file="GetBlockListResponse.cs" company="Microsoft">
//    Copyright (c)2010 Microsoft. All rights reserved.
// </copyright>
// <summary>
//    Contains code for the GetBlockListResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Provides methods for parsing the response from an operation to return a block list.
    /// </summary>
    public class GetBlockListResponse : ResponseParsingBase<ListBlockItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetBlockListResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal GetBlockListResponse(Stream stream) : base(stream)
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
        /// Parses the XML response returned by an operation to retrieve a list of blocks.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="ListBlockItem"/> objects.</returns>
        protected override IEnumerable<ListBlockItem> ParseXml()
        {
            bool committedBlocks = true;
            while (reader.Read())
            {
                // Run through the stream until we find what we are looking for.  Retain what we've found.
                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                {
                    switch (reader.Name)
                    {
                        case Constants.BlockElement:
                            // We found a block.
                            ListBlockItem block = null;
                            long size = 0;
                            string blockId = null;

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
                                        case Constants.SizeElement:
                                            size = reader.ReadElementContentAsLong();
                                            needToRead = false;
                                            break;
                                        case Constants.NameElement:
                                            blockId = reader.ReadElementContentAsString();
                                            needToRead = false;
                                            break;
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.BlockElement)
                                {
                                    block = new ListBlockItem() { Name = blockId, Size = size, Committed = committedBlocks };
                                    break;
                                }
                            }

                            yield return block;
                            break;
                        case Constants.CommittedBlocksElement:
                            committedBlocks = true;
                            break;
                        case Constants.UncommittedBlocksElement:
                            committedBlocks = false;
                            break;
                    }
                }
            }
        }
    }
}
