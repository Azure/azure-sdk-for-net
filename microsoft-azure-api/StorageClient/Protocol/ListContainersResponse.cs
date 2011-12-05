//-----------------------------------------------------------------------
// <copyright file="ListContainersResponse.cs" company="Microsoft">
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
//    Contains code for the ListContainersResponse class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.IO;
    using System.Xml;

    /// <summary>
    /// Provides methods for parsing the response from a container listing operation.
    /// </summary>
    public class ListContainersResponse : ResponseParsingBase<BlobContainerEntry>
    {
        /// <summary>
        /// Stores the container prefix.
        /// </summary>
        private string prefix;

        /// <summary>
        /// Signals when the container prefix can be consumed.
        /// </summary>
        private bool prefixConsumable;

        /// <summary>
        /// Stores the marker.
        /// </summary>
        private string marker;

        /// <summary>
        /// Signals when the marker can be consumed.
        /// </summary>
        private bool markerConsumable;

        /// <summary>
        /// Stores the max results.
        /// </summary>
        private int maxResults;

        /// <summary>
        /// Signals when the max results can be consumed.
        /// </summary>
        private bool maxResultsConsumable;

        /// <summary>
        /// Stores the next marker.
        /// </summary>
        private string nextMarker;

        /// <summary>
        /// Signals when the next marker can be consumed.
        /// </summary>
        private bool nextMarkerConsumable;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListContainersResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal ListContainersResponse(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Gets the listing context from the XML response.
        /// </summary>
        /// <value>A set of parameters for the listing operation.</value>
        public ListingContext ListingContext
        {
            get
            {
                // Force a parsing in order
                ListingContext listingContext = new ListingContext(this.Prefix, this.MaxResults);
                listingContext.Marker = this.NextMarker;
                return listingContext;
            }
        }

        /// <summary>
        /// Gets an enumerable collection of <see cref="BlobContainerEntry"/> objects from the response.
        /// </summary>
        /// <value>An enumerable collection of <see cref="BlobContainerEntry"/> objects.</value>
        public IEnumerable<BlobContainerEntry> Containers
        {
            get
            {
                return this.ObjectsToParse;
            }
        }

        /// <summary>
        /// Gets the Prefix value provided for the listing operation from the XML response.
        /// </summary>
        /// <value>The Prefix value.</value>
        public string Prefix
        {
            get
            {
                this.Variable(ref this.prefixConsumable);

                return this.prefix;
            }
        }

        /// <summary>
        /// Gets the Marker value provided for the listing operation from the XML response.
        /// </summary>
        /// <value>The Marker value.</value>
        public string Marker
        {
            get
            {
                this.Variable(ref this.markerConsumable);

                return this.marker;
            }
        }

        /// <summary>
        /// Gets the MaxResults value provided for the listing operation from the XML response.
        /// </summary>
        /// <value>The MaxResults value.</value>
        public int MaxResults
        {
            get
            {
                this.Variable(ref this.maxResultsConsumable);

                return this.maxResults;
            }
        }

        /// <summary>
        /// Gets the NextMarker value from the XML response, if the listing was not complete.
        /// </summary>
        /// <value>The NextMarker value.</value>
        public string NextMarker
        {
            get
            {
                this.Variable(ref this.nextMarkerConsumable);

                return this.nextMarker;
            }
        }

        /// <summary>
        /// Parses the response XML for a container listing operation.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="BlobContainerEntry"/> objects.</returns>
        protected override IEnumerable<BlobContainerEntry> ParseXml()
        {
            bool needToRead = true;

            while (true)
            {
                if (needToRead && !reader.Read())
                {
                    break;
                }

                needToRead = true;

                // Run through the stream until we find what we are looking for.  Retain what we've found.
                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                {
                    switch (reader.Name)
                    {
                        case Constants.MarkerElement:
                            needToRead = false;
                            this.marker = reader.ReadElementContentAsString();
                            this.markerConsumable = true;
                            yield return null;
                            break;
                        case Constants.NextMarkerElement:
                            needToRead = false;
                            this.nextMarker = reader.ReadElementContentAsString();
                            this.nextMarkerConsumable = true;
                            yield return null;
                            break;
                        case Constants.MaxResultsElement:
                            needToRead = false;
                            this.maxResults = reader.ReadElementContentAsInt();
                            this.maxResultsConsumable = true;
                            yield return null;
                            break;
                        case Constants.PrefixElement:
                            needToRead = false;
                            this.prefix = reader.ReadElementContentAsString();
                            this.prefixConsumable = true;
                            yield return null;
                            break;
                        case Constants.ContainersElement:
                            while (reader.Read())
                            {
                                // We found a container.
                                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.ContainerElement)
                                {
                                    BlobContainerAttributes container = null;
                                    Uri uri = null;
                                    DateTime? lastModifiedTime = null;
                                    string etag = null;
                                    string name = null;
                                    NameValueCollection metadata = null;

                                    // Go until we are out of the container.
                                    bool containersNeedToRead = true;
                                    while (true)
                                    {
                                        if (containersNeedToRead && !reader.Read())
                                        {
                                            break;
                                        }

                                        containersNeedToRead = true;

                                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                                        {
                                            switch (reader.Name)
                                            {
                                                case Constants.UrlElement:
                                                    string url = reader.ReadElementContentAsString();
                                                    containersNeedToRead = false;
                                                    Uri.TryCreate(url, UriKind.Absolute, out uri);
                                                    break;
                                                case Constants.LastModifiedElement:
                                                    lastModifiedTime = reader.ReadElementContentAsString().ToUTCTime();
                                                    containersNeedToRead = false;
                                                    break;
                                                case Constants.EtagElement:
                                                    etag = reader.ReadElementContentAsString();
                                                    containersNeedToRead = false;
                                                    break;
                                                case Constants.NameElement:
                                                    name = reader.ReadElementContentAsString();
                                                    containersNeedToRead = false;
                                                    break;
                                                case Constants.MetadataElement:
                                                    metadata = Response.ParseMetadata(reader);
                                                    containersNeedToRead = false;
                                                    break;
                                            }
                                        }
                                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.ContainerElement)
                                        {
                                            container = new BlobContainerAttributes();
                                            container.Name = name;
                                            container.Uri = uri;

                                            if (metadata != null)
                                            {
                                                container.Metadata = metadata;
                                            }

                                            var containerProperties = container.Properties;
                                            containerProperties.ETag = etag;

                                            if (lastModifiedTime != null)
                                            {
                                                containerProperties.LastModifiedUtc = (DateTime)lastModifiedTime;
                                            }

                                            break;
                                        }
                                    }

                                    yield return new BlobContainerEntry
                                    {
                                        Attributes = container
                                    };
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.ContainersElement)
                                {
                                    this.allObjectsParsed = true;
                                    break;
                                }
                            }

                            break;
                    }
                }
            }
        }
    }
}
