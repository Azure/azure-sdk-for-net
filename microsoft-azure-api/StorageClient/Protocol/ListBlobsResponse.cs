//-----------------------------------------------------------------------
// <copyright file="ListBlobsResponse.cs" company="Microsoft">
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
//    Contains code for the ListBlobsResponse class.
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
    /// Provides methods for parsing the response from a blob listing operation.
    /// </summary>
    public class ListBlobsResponse : ResponseParsingBase<IListBlobEntry>
    {
        /// <summary>
        /// Stores the blob prefix.
        /// </summary>
        private string prefix;

        /// <summary>
        /// Signals when the blob prefix can be consumed.
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
        /// Stores the blob delimiter.
        /// </summary>
        private string delimiter;

        /// <summary>
        /// Signals when the blob delimiter can be consumed.
        /// </summary>
        private bool delimiterConsumable;

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
        /// Initializes a new instance of the <see cref="ListBlobsResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        internal ListBlobsResponse(Stream stream) : base(stream)
        {
        }

        /// <summary>
        /// Gets the listing context from the XML response.
        /// </summary>
        /// <value>A set of parameters for the listing operation.</value>
        public BlobListingContext ListingContext
        {
            get
            {
                string prefix = this.Prefix;
                int maxResults = this.MaxResults;
                string delimiter = this.Delimiter;
                string nextMarker = this.NextMarker;
                BlobListingContext listingContext = new BlobListingContext(
                    prefix,
                    maxResults,
                    delimiter,
                    BlobListingDetails.None);
                listingContext.Marker = nextMarker;
                return listingContext;
            }
        }

        /// <summary>
        /// Gets an enumerable collection of objects that implement <see cref="IListBlobEntry"/> from the response.
        /// </summary>
        /// <value>An enumerable collection of objects that implement <see cref="IListBlobEntry"/>.</value>
        public IEnumerable<IListBlobEntry> Blobs
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
        /// Gets the Delimiter value provided for the listing operation from the XML response.
        /// </summary>
        /// <value>The Delimiter value.</value>
        public string Delimiter
        {
            get
            {
                this.Variable(ref this.delimiterConsumable);

                return this.delimiter;
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
        /// Parses the response XML for a blob listing operation.
        /// </summary>
        /// <returns>An enumerable collection of objects that implement <see cref="IListBlobEntry"/>.</returns>
        protected override IEnumerable<IListBlobEntry> ParseXml()
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
                        case Constants.DelimiterElement:
                            needToRead = false;
                            this.delimiter = reader.ReadElementContentAsString();
                            this.delimiterConsumable = true;
                            yield return null;
                            break;
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
                        case Constants.BlobsElement:
                            // While we're still in the blobs section.
                            while (reader.Read())
                            {
                                // We found a blob.
                                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.BlobElement)
                                {
                                    BlobAttributes blob = null;
                                    string url = null;
                                    DateTime? lastModifiedTime = null;
                                    string etag = null;
                                    string name = null;
                                    long? contentLength = null;
                                    string contentType = null;
                                    string contentEncoding = null;
                                    string contentLanguage = null;
                                    string contentMD5 = null;
                                    BlobType? blobType = null;
                                    LeaseStatus? leaseStatus = null;
                                    DateTime? snapshot = null;
                                    NameValueCollection metadata = null;

                                    // Go until we are out of the blob.
                                    bool blobNeedToRead = true;

                                    while (true)
                                    {
                                        if (blobNeedToRead && !reader.Read())
                                        {
                                            break;
                                        }

                                        blobNeedToRead = true;

                                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                                        {
                                            switch (reader.Name)
                                            {
                                                case Constants.UrlElement:
                                                    url = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.LastModifiedElement:
                                                    lastModifiedTime = reader.ReadElementContentAsString().ToUTCTime();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.EtagElement:
                                                    etag = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.NameElement:
                                                    name = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.ContentLengthElement:
                                                    contentLength = reader.ReadElementContentAsLong();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.ContentTypeElement:
                                                    contentType = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.ContentEncodingElement:
                                                    contentEncoding = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.ContentLanguageElement:
                                                    contentLanguage = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.ContentMD5Element:
                                                    contentMD5 = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.BlobTypeElement:
                                                    string blobTypeString = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;

                                                    switch (blobTypeString)
                                                    {
                                                        case Constants.BlockBlobValue:
                                                            blobType = BlobType.BlockBlob;
                                                            break;
                                                        case Constants.PageBlobValue:
                                                            blobType = BlobType.PageBlob;
                                                            break;
                                                    }

                                                    break;
                                                case Constants.LeaseStatusElement:
                                                    string leaseStatusString = reader.ReadElementContentAsString();
                                                    blobNeedToRead = false;

                                                    switch (leaseStatusString)
                                                    {
                                                        case Constants.LockedValue:
                                                            leaseStatus = LeaseStatus.Locked;
                                                            break;
                                                        case Constants.UnlockedValue:
                                                            leaseStatus = LeaseStatus.Unlocked;
                                                            break;
                                                    }

                                                    break;
                                                case Constants.SnapshotElement:
                                                    snapshot = reader.ReadElementContentAsString().ToUTCTime();
                                                    blobNeedToRead = false;
                                                    break;
                                                case Constants.MetadataElement:
                                                    metadata = Response.ParseMetadata(reader);
                                                    blobNeedToRead = false;
                                                    break;
                                            }
                                        }
                                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.BlobElement)
                                        {
                                            blob = new BlobAttributes();
                                            blob.Properties = new BlobProperties();
                                            blob.Properties.ContentEncoding = contentEncoding;
                                            blob.Properties.ContentLanguage = contentLanguage;
                                            blob.Properties.ContentMD5 = contentMD5;
                                            blob.Properties.Length = contentLength ?? 0;
                                            blob.Properties.ContentType = contentType;
                                            blob.Properties.ETag = etag;

                                            if (lastModifiedTime != null)
                                            {
                                                blob.Properties.LastModifiedUtc = (DateTime)lastModifiedTime;
                                            }

                                            var blobNameSectionIndex = url.LastIndexOf(NavigationHelper.Slash + name);
                                            string baseUri = url.Substring(0, blobNameSectionIndex + 1);
                                            var ub = new UriBuilder(baseUri);
                                            ub.Path += Uri.EscapeUriString(name);
                                            if (baseUri.Length + name.Length < url.Length)
                                            {
                                                // it's a url for snapshot. 
                                                // Snapshot blob URI example:http://<yourstorageaccount>.blob.core.windows.net/<yourcontainer>/<yourblobname>?snapshot=2009-12-03T15%3a26%3a19.4466877Z 
                                                ub.Query = url.Substring(baseUri.Length + name.Length + 1);
                                            }

                                            blob.Uri = ub.Uri;
                                            
                                            blob.Properties.LeaseStatus = leaseStatus ?? LeaseStatus.Unspecified;

                                            if (snapshot != null)
                                            {
                                                blob.Snapshot = (DateTime)snapshot;
                                            }

                                            blob.Properties.BlobType = blobType ?? BlobType.Unspecified;

                                            if (metadata != null)
                                            {
                                                blob.Metadata = metadata;
                                            }

                                            break;
                                        }
                                    }

                                    yield return new BlobEntry(name, blob);
                                }
                                else if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement && reader.Name == Constants.BlobPrefixElement)
                                {
                                    BlobPrefixEntry commonPrefix = new BlobPrefixEntry();

                                    // Go until we are out of the blob.
                                    bool blobPrefixNeedToRead = true;

                                    while (true)
                                    {
                                        if (blobPrefixNeedToRead && !reader.Read())
                                        {
                                            break;
                                        }

                                        blobPrefixNeedToRead = true;

                                        if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                                        {
                                            switch (reader.Name)
                                            {
                                                case Constants.NameElement:
                                                    commonPrefix.Name = reader.ReadElementContentAsString();
                                                    blobPrefixNeedToRead = false;
                                                    break;
                                            }
                                        }
                                        else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.BlobPrefixElement)
                                        {
                                            break;
                                        }
                                    }

                                    yield return commonPrefix;
                                }
                                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.BlobsElement)
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
