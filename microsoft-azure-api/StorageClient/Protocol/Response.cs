//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="Microsoft">
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
//    Contains code for the Response class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Specialized;
    using System.IO;
    using System.Net;
    using System.Xml;
    using System.Xml.Linq;

    /// <summary>
    /// Implements the common parsing between all the responses.
    /// </summary>
    internal static class Response
    {
        /// <summary>
        /// Gets the error details from the response object.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>An extended error information parsed from the input.</returns>
        internal static StorageExtendedErrorInformation GetError(HttpWebResponse response)
        {
            Stream stream = response.GetResponseStream();

            return Utilities.GetExtendedErrorDetailsFromResponse(stream, response.ContentLength);
        }

        /// <summary>
        /// Gets the headers (metadata or properties).
        /// </summary>
        /// <param name="response">The response from sever.</param>
        /// <returns>A <see cref="NameValueCollection"/> of all the headers.</returns>
        internal static NameValueCollection GetHeaders(HttpWebResponse response)
        {
            return GetMetadataOrProperties(response, string.Empty);
        }

        /// <summary>
        /// Gets the user-defined metadata.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>A <see cref="NameValueCollection"/> of the metadata.</returns>
        internal static NameValueCollection GetMetadata(HttpWebResponse response)
        {
            return GetMetadataOrProperties(response, Constants.HeaderConstants.PrefixForStorageMetadata);
        }

        /// <summary>
        /// Gets a specific user-defined metadata.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <param name="name">The metadata header requested.</param>
        /// <returns>An array of the values for the metadata.</returns>
        internal static string[] GetMetadata(HttpWebResponse response, string name)
        {
            return response.Headers.GetValues(Constants.HeaderConstants.PrefixForStorageMetadata + name);
        }

        /// <summary>
        /// Parses the metadata.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns>A <see cref="NameValueCollection"/> of metadata.</returns>
        /// <remarks>
        /// Precondition: reader at &lt;Metadata&gt;
        /// Postcondition: reader after &lt;/Metadata&gt; (&lt;Metadata/&gt; consumed)
        /// </remarks>
        internal static NameValueCollection ParseMetadata(XmlReader reader)
        {
            NameValueCollection metadata = new NameValueCollection();
            bool needToRead = true;
            while (true)
            {
                if (needToRead && !reader.Read())
                {
                    return metadata;
                }

                if (reader.NodeType == XmlNodeType.Element && !reader.IsEmptyElement)
                {
                    needToRead = false;
                    string elementName = reader.Name;
                    string elementValue = reader.ReadElementContentAsString();
                    if (elementName != Constants.InvalidMetadataName)
                    {
                        metadata.Add(elementName, elementValue);
                    }
                } 
                else if (reader.NodeType == XmlNodeType.EndElement && reader.Name == Constants.MetadataElement)
                {
                    reader.Read();
                    return metadata;
                }
            }
        }

        /// <summary>
        /// Gets the storage properties.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>A <see cref="NameValueCollection"/> of the properties.</returns>
        internal static NameValueCollection GetProperties(HttpWebResponse response)
        {
            return GetMetadataOrProperties(response, Constants.HeaderConstants.PrefixForStorageProperties);
        }

        /// <summary>
        /// Gets a specific storage property.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <param name="name">The property requested.</param>
        /// <returns>An array of the values for the property.</returns>
        internal static string[] GetProperties(HttpWebResponse response, string name)
        {
            return response.Headers.GetValues(Constants.HeaderConstants.PrefixForStorageProperties + name);
        }

        /// <summary>
        /// Gets the request id.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <returns>The request ID.</returns>
        internal static string GetRequestId(HttpWebResponse response)
        {
            string[] values = response.Headers.GetValues(Constants.HeaderConstants.RequestIdHeader);

            if (values.Length == 1)
            {
                return values[0];
            }

            return null;
        }

        /// <summary>
        /// Reads service properties from a stream.
        /// </summary>
        /// <param name="inputStream">The stream from which to read the service properties.</param>
        /// <returns>The service properties stored in the stream.</returns>
        internal static ServiceProperties ReadServiceProperties(Stream inputStream)
        {
            using (XmlReader reader = XmlReader.Create(inputStream))
            {
                XDocument servicePropertyDocument = XDocument.Load(reader);

                return ServiceProperties.FromServiceXml(servicePropertyDocument);
            }
        }

        /// <summary>
        /// Gets the metadata or properties.
        /// </summary>
        /// <param name="response">The response from server.</param>
        /// <param name="prefix">The prefix for all the headers.</param>
        /// <returns>A <see cref="NameValueCollection"/> of the headers with the prefix.</returns>
        private static NameValueCollection GetMetadataOrProperties(HttpWebResponse response, string prefix)
        {
            NameValueCollection nameValues = new NameValueCollection();
            int prefixLength = prefix.Length;

            WebHeaderCollection headers = response.Headers;

            for (int i = 0; i < headers.Count; i++)
            {
                string header = headers.GetKey(i);

                if (!header.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                string[] values = headers.GetValues(header);

                for (int j = 0; j < values.Length; j++)
                {
                    nameValues.Add(header.Substring(prefixLength), values[j]);
                }
            }

            return nameValues;
        }
    }
}
