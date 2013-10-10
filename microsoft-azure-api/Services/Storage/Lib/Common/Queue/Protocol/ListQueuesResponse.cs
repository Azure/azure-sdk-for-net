namespace Microsoft.WindowsAzure.Storage.Queue.Protocol
{
    using Microsoft.WindowsAzure.Storage.Shared.Protocol;
    using System;
    using System.Collections.Generic;
    using System.IO;

    /// <summary>
    /// Provides methods for parsing the response from a queue listing operation.
    /// </summary>
#if WINDOWS_RT
    internal
#else
    public
#endif
 sealed class ListQueuesResponse : ResponseParsingBase<QueueEntry>
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
        /// Initializes a new instance of the <see cref="ListQueuesResponse"/> class.
        /// </summary>
        /// <param name="stream">The stream to be parsed.</param>
        public ListQueuesResponse(Stream stream)
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
        /// Gets an enumerable collection of <see cref="QueueEntry"/> objects from the response.
        /// </summary>
        /// <value>An enumerable collection of <see cref="QueueEntry"/> objects.</value>
        public IEnumerable<QueueEntry> Queues
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
        /// Parses a queue entry in a queue listing response.
        /// </summary>
        /// <returns>Queue listing entry</returns>
        private QueueEntry ParseQueueEntry()
        {
            Uri uri = null;
            string name = null;
            IDictionary<string, string> metadata = null;

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
                        case Constants.UrlElement:
                            string url = reader.ReadElementContentAsString();
                            Uri.TryCreate(url, UriKind.Absolute, out uri);
                            break;

                        case Constants.NameElement:
                            name = reader.ReadElementContentAsString();
                            break;

                        case Constants.MetadataElement:
                            metadata = Response.ParseMetadata(this.reader);
                            break;

                        default:
                            this.reader.Skip();
                            break;
                    }
                }
            }

            this.reader.ReadEndElement();
            if (metadata == null)
            {
                metadata = new Dictionary<string, string>();
            }

            return new QueueEntry(name, uri, metadata);
        }

        /// <summary>
        /// Parses the response XML for a queue listing operation.
        /// </summary>
        /// <returns>An enumerable collection of <see cref="QueueEntry"/> objects.</returns>
        protected override IEnumerable<QueueEntry> ParseXml()
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
                            switch (reader.Name)
                            {
                                case Constants.MarkerElement:
                                    this.marker = reader.ReadElementContentAsString();
                                    this.markerConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.NextMarkerElement:
                                    this.nextMarker = reader.ReadElementContentAsString();
                                    this.nextMarkerConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.MaxResultsElement:
                                    this.maxResults = reader.ReadElementContentAsInt();
                                    this.maxResultsConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.PrefixElement:
                                    this.prefix = reader.ReadElementContentAsString();
                                    this.prefixConsumable = true;
                                    yield return null;
                                    break;

                                case Constants.QueuesElement:
                                    this.reader.ReadStartElement();
                                    while (this.reader.IsStartElement())
                                    {
                                        yield return this.ParseQueueEntry();
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
