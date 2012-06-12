//-----------------------------------------------------------------------
// <copyright file="Response.cs" company="Microsoft">
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
// <summary>
//    Contains code for the Response class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
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
        /// Extracts the lease ID header from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The lease ID.</returns>
        internal static string GetLeaseId(HttpWebResponse response)
        {
            return response.Headers[Constants.HeaderConstants.LeaseIdHeader];
        }

        /// <summary>
        /// Extracts the remaining lease time from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>The remaining lease time, in seconds.</returns>
        internal static int? GetRemainingLeaseTime(HttpWebResponse response)
        {
            int remainingLeaseTime;
            if (int.TryParse(response.Headers[Constants.HeaderConstants.LeaseTimeHeader], out remainingLeaseTime))
            {
                return remainingLeaseTime;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Extracts the lease status from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseStatus"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseStatus.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        internal static LeaseStatus GetLeaseStatus(HttpWebResponse response)
        {
            string leaseStatus = response.Headers[Constants.HeaderConstants.LeaseStatus];

            return GetLeaseStatus(leaseStatus);
        }

        /// <summary>
        /// Gets a <see cref="LeaseStatus"/> from a string.
        /// </summary>
        /// <param name="leaseStatus">The lease status string.</param>
        /// <returns>A <see cref="LeaseStatus"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseStatus.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseStatus GetLeaseStatus(string leaseStatus)
        {
            if (!string.IsNullOrEmpty(leaseStatus))
            {
                switch (leaseStatus)
                {
                    case Constants.LockedValue:
                        return LeaseStatus.Locked;

                    case Constants.UnlockedValue:
                        return LeaseStatus.Unlocked;

                    default:
                        throw new ArgumentException(string.Format("Invalid lease status in response: {0}", leaseStatus), "response");
                }
            }

            return LeaseStatus.Unspecified;
        }

        /// <summary>
        /// Extracts the lease state from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseState"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseState.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        internal static LeaseState GetLeaseState(HttpWebResponse response)
        {
            string leaseState = response.Headers[Constants.HeaderConstants.LeaseState];

            return GetLeaseState(leaseState);
        }

        /// <summary>
        /// Gets a <see cref="LeaseState"/> from a string.
        /// </summary>
        /// <param name="leaseState">The lease state string.</param>
        /// <returns>A <see cref="LeaseState"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseState.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseState GetLeaseState(string leaseState)
        {
            if (!string.IsNullOrEmpty(leaseState))
            {
                switch (leaseState)
                {
                    case Constants.LeaseAvailableValue:
                        return LeaseState.Available;

                    case Constants.LeasedValue:
                        return LeaseState.Leased;

                    case Constants.LeaseExpiredValue:
                        return LeaseState.Expired;

                    case Constants.LeaseBreakingValue:
                        return LeaseState.Breaking;

                    case Constants.LeaseBrokenValue:
                        return LeaseState.Broken;

                    default:
                        throw new ArgumentException(string.Format("Invalid lease state in response: {0}", leaseState), "response");
                }
            }

            return LeaseState.Unspecified;
        }

        /// <summary>
        /// Extracts the lease duration from a web response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A <see cref="LeaseDuration"/> enumeration from the web response.</returns>
        /// <remarks>If the appropriate header is not present, a status of <see cref="LeaseDuration.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The header contains an unrecognized value.</exception>
        internal static LeaseDuration GetLeaseDuration(HttpWebResponse response)
        {
            string leaseDuration = response.Headers[Constants.HeaderConstants.LeaseDurationHeader];

            return GetLeaseDuration(leaseDuration);
        }

        /// <summary>
        /// Gets a <see cref="LeaseDuration"/> from a string.
        /// </summary>
        /// <param name="leaseDuration">The lease duration string.</param>
        /// <returns>A <see cref="LeaseDuration"/> enumeration.</returns>
        /// <remarks>If a null or empty string is supplied, a status of <see cref="LeaseDuration.Unspecified"/> is returned.</remarks>
        /// <exception cref="System.ArgumentException">The string contains an unrecognized value.</exception>
        internal static LeaseDuration GetLeaseDuration(string leaseDuration)
        {
            if (!string.IsNullOrEmpty(leaseDuration))
            {
                switch (leaseDuration)
                {
                    case Constants.LeaseFixedValue:
                        return LeaseDuration.Fixed;

                    case Constants.LeaseInfiniteValue:
                        return LeaseDuration.Infinite;

                    default:
                        throw new ArgumentException(string.Format("Invalid lease duration in response: {0}", leaseDuration), "response");
                }
            }

            return LeaseDuration.Unspecified;
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
        /// Reads a collection of shared access policies from the specified <see cref="AccessPolicyResponseBase&lt;T&gt;"/> object.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies to be filled.</param>
        /// <param name="policyResponse">A policy response object for reading the stream.</param>
        /// <typeparam name="T">The type of policy to read.</typeparam>
        internal static void ReadSharedAccessIdentifiers<T>(Dictionary<string, T> sharedAccessPolicies, AccessPolicyResponseBase<T> policyResponse)
            where T : new()
        {
            foreach (KeyValuePair<string, T> pair in policyResponse.AccessIdentifiers)
            {
                sharedAccessPolicies.Add(pair.Key, pair.Value);
            }
        }

        /// <summary>
        /// Gets an ETag from a response.
        /// </summary>
        /// <param name="response">The web response.</param>
        /// <returns>A quoted ETag string.</returns>
        internal static string GetETag(HttpWebResponse response)
        {
            return response.Headers[HttpResponseHeader.ETag];
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
