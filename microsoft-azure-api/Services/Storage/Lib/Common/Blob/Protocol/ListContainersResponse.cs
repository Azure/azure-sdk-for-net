//-----------------------------------------------------------------------
// <copyright file="ListContainersResponse.cs" company="Microsoft">
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
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Provides methods for parsing the response from a container listing operation.
    /// </summary>
#if RTMD
    internal
#else
    public
#endif
        sealed class ListContainersResponse : ResponseParsingBase<BlobContainerEntry>
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
        public ListContainersResponse(Stream stream)
            : base(stream)
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
        /// Reads a container entry completely including its properties and metadata.
        /// </summary>
        /// <returns>Container listing entry</returns>
        private BlobContainerEntry ParseContainerEntry()
        {
            Uri uri = null;
            string name = null;
            IDictionary<string, string> metadata = null;
            BlobContainerProperties containerProperties = new BlobContainerProperties();

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
                        case Constants.UrlElement:
                            string url = this.reader.ReadElementContentAsString();
                            Uri.TryCreate(url, UriKind.Absolute, out uri);
                            break;

                        case Constants.NameElement:
                            name = this.reader.ReadElementContentAsString();
                            break;

                        case Constants.PropertiesElement:
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
                                        case Constants.LastModifiedElement:
                                            containerProperties.LastModified = reader.ReadElementContentAsString().ToUTCTime();
                                            break;

                                        case Constants.EtagElement:
                                            containerProperties.ETag = reader.ReadElementContentAsString();
                                            break;

                                        case Constants.LeaseStatusElement:
                                            containerProperties.LeaseStatus = BlobHttpResponseParsers.GetLeaseStatus(reader.ReadElementContentAsString());
                                            break;

                                        case Constants.LeaseStateElement:
                                            containerProperties.LeaseState = BlobHttpResponseParsers.GetLeaseState(reader.ReadElementContentAsString());
                                            break;

                                        case Constants.LeaseDurationElement:
                                            containerProperties.LeaseDuration = BlobHttpResponseParsers.GetLeaseDuration(reader.ReadElementContentAsString());
                                            break;

                                        default:
                                            reader.Skip();
                                            break;
                                    }
                                }
                            }

                            this.reader.ReadEndElement();
                            break;

                        case Constants.MetadataElement:
                            metadata = Response.ParseMetadata(this.reader);
                            break;

                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            this.reader.ReadEndElement();

            if (metadata == null)
            {
                metadata = new Dictionary<string, string>();
            }

            return new BlobContainerEntry
            {
                Properties = containerProperties,
                Name = name,
                Uri = uri,
                Metadata = metadata,
            };
        }

        /// <summary>
        /// Parses the response XML for a container listing operation.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="BlobContainerEntry"/> objects.</returns>
        protected override IEnumerable<BlobContainerEntry> ParseXml()
        {
            if (this.reader.ReadToFollowing(Constants.EnumerationResultsElement))
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
                                case Constants.MarkerElement:
                                    this.marker = this.reader.ReadElementContentAsString();
                                    this.markerConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.NextMarkerElement:
                                    this.nextMarker = this.reader.ReadElementContentAsString();
                                    this.nextMarkerConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.MaxResultsElement:
                                    this.maxResults = this.reader.ReadElementContentAsInt();
                                    this.maxResultsConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.PrefixElement:
                                    this.prefix = this.reader.ReadElementContentAsString();
                                    this.prefixConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.ContainersElement:
                                    this.reader.ReadStartElement();
                                    while (this.reader.IsStartElement(Constants.ContainerElement))
                                    {
                                        yield return this.ParseContainerEntry();
                                    }

                                    this.reader.ReadEndElement();
                                    this.allObjectsParsed = true;
                                    break;

                                default:
                                    reader.Skip();
                                    break;
                            }
                        }
                    }

                    this.reader.ReadEndElement();
                }
            }
        }
    }
}
