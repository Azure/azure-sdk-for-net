//-----------------------------------------------------------------------
// <copyright file="CanonicalizationStrategy.cs" company="Microsoft">
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
//    Contains code for the CanonicalizationStrategy class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using Microsoft.WindowsAzure.StorageClient;

    /// <summary>
    /// Represents the base canonicalization strategy used to authenticate a request against the storage services.
    /// </summary>
    public abstract class CanonicalizationStrategy
    {
        /// <summary>
        /// Constructs a canonicalized string for signing a request.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>A canonicalized string.</returns>
        public abstract string CanonicalizeHttpRequest(HttpWebRequest request, string accountName);

        /// <summary>
        /// Constructs a canonicalized string from the request's headers that will be used to construct the signature
        /// string for signing a Blob or Queue service request under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="address">The request URI.</param>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="method">The verb to be used for the HTTP request.</param>
        /// <param name="contentType">The content type of the HTTP request.</param>
        /// <param name="date">The date/time specification for the HTTP request.</param>
        /// <param name="headers">A collection of additional headers specified on the HTTP request.</param>
        /// <returns>A canonicalized string.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Globalization",
            "CA1308:NormalizeStringsToUppercase",
            Justification = "Authentication algorithm requires canonicalization by converting to lower case")]
        protected static string CanonicalizeHttpRequest(
            Uri address,
            string accountName,
            string method,
            string contentType,
            string date,
            NameValueCollection headers)
        {
            // The first element should be the Method of the request.
            // I.e. GET, POST, PUT, or HEAD.
            CanonicalizedString canonicalizedString = new CanonicalizedString(method);

            // The second element should be the MD5 value.
            // This is optional and may be empty.
            string httpContentMD5Value = string.Empty;

            // First extract all the content MD5 values from the header.
            ArrayList httpContentMD5Values = GetHeaderValues(headers, "Content-MD5");

            // If we only have one, then set it to the value we want to append to the canonicalized string.
            if (httpContentMD5Values.Count == 1)
            {
                httpContentMD5Value = (string)httpContentMD5Values[0];
            }

            canonicalizedString.AppendCanonicalizedElement(httpContentMD5Value);

            // The third element should be the content type.
            canonicalizedString.AppendCanonicalizedElement(contentType);

            // The fourth element should be the request date.
            // See if there's an storage date header.
            // If there's one, then don't use the date header.
            ArrayList httpStorageDateValues = GetHeaderValues(headers, Constants.HeaderConstants.Date);
            if (httpStorageDateValues.Count > 0)
            {
                date = null;
            }

            canonicalizedString.AppendCanonicalizedElement(date);

            AddCanonicalizedHeaders(headers, canonicalizedString);

            AddCanonicalizedResource(address, accountName, canonicalizedString);

            return canonicalizedString.Value;
        }

        /// <summary>
        /// Constructs a canonicalized string from the request's headers that will be used to construct the signature
        /// string for signing a Blob or Queue service request under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="address">The request URI.</param>
        /// <param name="accountName">The storage account name.</param>
        /// <param name="method">The verb to be used for the HTTP request.</param>
        /// <param name="contentType">The content type of the HTTP request.</param>
        /// <param name="contentLength">The length of the HTTP request, in bytes.</param>
        /// <param name="date">The date/time specification for the HTTP request.</param>
        /// <param name="headers">A collection of additional headers specified on the HTTP request.</param>
        /// <returns>A canonicalized string.</returns>
        protected static string CanonicalizeHttpRequestVersion2(
            Uri address,
            string accountName,
            string method,
            string contentType,
            long contentLength,
            string date,
            NameValueCollection headers)
        {
            // The first element should be the Method of the request.
            // I.e. GET, POST, PUT, or HEAD.
            CanonicalizedString canonicalizedString = new CanonicalizedString(method);

            // The next elements are 
            // If any element is missing it may be empty.
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "Content-Encoding"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "Content-Language"));
            canonicalizedString.AppendCanonicalizedElement(contentLength == -1 ? String.Empty : contentLength.ToString());
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "Content-MD5"));
            canonicalizedString.AppendCanonicalizedElement(contentType);

            // If x-ms-date header exists, Date should be empty string
            canonicalizedString.AppendCanonicalizedElement(
                GetStandardHeaderValue(headers, Constants.HeaderConstants.Date) != string.Empty 
                ? string.Empty : GetStandardHeaderValue(headers, "Date"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "If-Modified-Since"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "If-Match"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "If-None-Match"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "If-Unmodified-Since"));
            canonicalizedString.AppendCanonicalizedElement(GetStandardHeaderValue(headers, "Range"));

            AddCanonicalizedHeaders(headers, canonicalizedString);

            AddCanonicalizedResourceVer2(address, accountName, canonicalizedString);

            return canonicalizedString.Value;
        }

        /// <summary>
        /// Gets the value of a standard HTTP header.
        /// </summary>
        /// <param name="headers">The collection of headers.</param>
        /// <param name="headerName">The name of the header.</param>
        /// <returns>The header value.</returns>
        protected static string GetStandardHeaderValue(NameValueCollection headers, string headerName)
        {
            ArrayList headerValues = GetHeaderValues(headers, headerName);

            return headerValues.Count == 1 ? (string)headerValues[0] : string.Empty;
        }

        /// <summary>
        /// Returns an <see cref="ArrayList"/> of HTTP header values for a named header.
        /// </summary>
        /// <param name="headers">A collection of HTTP headers as name-values pairs.</param>
        /// <param name="headerName">The name of the header to return.</param>
        /// <returns>An <see cref="ArrayList"/> of HTTP header values, stored in the same order as they appear in the collection.</returns>
        protected static ArrayList GetHeaderValues(NameValueCollection headers, string headerName)
        {
            ArrayList arrayOfValues = new ArrayList();
            string[] values = headers.GetValues(headerName);

            if (values != null)
            {
                foreach (string value in values)
                {
                    // canonization formula requires the string to be left trimmed.
                    arrayOfValues.Add(value.TrimStart());
                }
            }

            return arrayOfValues;
        }

        /// <summary>
        /// Appends a string to the canonicalized resource string.
        /// </summary>
        /// <param name="canonicalizedString">The canonicalized resource string.</param>
        /// <param name="stringToAppend">The string to append.</param>
        /// <returns>The modified canonicalized resource string.</returns>
        protected static string AppendStringToCanonicalizedString(StringBuilder canonicalizedString, string stringToAppend)
        {
            canonicalizedString.Append("\n");
            canonicalizedString.Append(stringToAppend);

            return canonicalizedString.ToString();
        }

        /// <summary>
        /// Gets the canonicalized resource string for a Blob or Queue service request under the Shared Key Lite authentication scheme.
        /// </summary>
        /// <param name="address">The resource URI.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized resource string.</returns>
        protected static string GetCanonicalizedResource(Uri address, string accountName)
        {
            // Algorithm is as follows
            // 1. Start with the empty string ("")
            // 2. Append the account name owning the resource preceded by a
            //     the name of the account making the request but the account that owns the
            //     resource being accessed.
            // 3. Append the path part of the un-decoded HTTP Request-URI, up-to but not
            //     including the query string.
            // 4. If the request addresses a particular component of a resource, like?comp=
            //     metadata then append the sub-resource including question mark (like ?comp=
            //     metadata)
            StringBuilder canonicalizedResource = new StringBuilder("/");
            canonicalizedResource.Append(accountName);

            // Note that AbsolutePath starts with a '/'.
            canonicalizedResource.Append(address.AbsolutePath);
            NameValueCollection queryVariables = HttpUtility.ParseQueryString(address.Query);

            // Add only comp for the old scheme
            string compQueryParameterValue = queryVariables["comp"];

            if (compQueryParameterValue != null)
            {
                canonicalizedResource.Append("?comp=");
                canonicalizedResource.Append(compQueryParameterValue);
            }

            return canonicalizedResource.ToString();
        }

        /// <summary>
        /// Gets the canonicalized resource string for a Blob or Queue service request under the Shared Key authentication scheme.
        /// </summary>
        /// <param name="address">The resource URI.</param>
        /// <param name="accountName">The name of the storage account.</param>
        /// <returns>The canonicalized resource string.</returns>
        protected static string GetCanonicalizedResourceVersion2(Uri address, string accountName)
        {
            // Resource path
            StringBuilder resourcepath = new StringBuilder("/");
            resourcepath.Append(accountName);

            // Note that AbsolutePath starts with a '/'.
            resourcepath.Append(address.AbsolutePath);

            CanonicalizedString canonicalizedResource = new CanonicalizedString(resourcepath.ToString());

            // query parameters
            NameValueCollection queryVariables = HttpUtility.ParseQueryString(address.Query);
            NameValueCollection lowercasedKeyNameValue = new NameValueCollection();

            foreach (string key in queryVariables.Keys)
            {
                // sort the value and organize it as comma separated values
                object[] values = queryVariables.GetValues(key);

                ArrayList sortedValues = new ArrayList(values);
                sortedValues.Sort();

                StringBuilder stringValue = new StringBuilder();

                foreach (object value in sortedValues)
                {
                    if (stringValue.Length > 0)
                    {
                        stringValue.Append(",");
                    }

                    stringValue.Append(value.ToString());
                }

                // key turns out to be null for ?a&b&c&d
                lowercasedKeyNameValue.Add(key == null ? key : key.ToLowerInvariant(), stringValue.ToString());
            }

            ArrayList sortedKeys = new ArrayList(lowercasedKeyNameValue.AllKeys);

            sortedKeys.Sort();

            foreach (string key in sortedKeys)
            {
                StringBuilder queryParamString = new StringBuilder(string.Empty);

                queryParamString.Append(key);
                queryParamString.Append(":");
                queryParamString.Append(lowercasedKeyNameValue[key]);

                canonicalizedResource.AppendCanonicalizedElement(queryParamString.ToString());
            }

            return canonicalizedResource.Value;
        }

        /// <summary>
        /// Adds the canonicalized resource for version 2.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        private static void AddCanonicalizedResourceVer2(Uri address, string accountName, CanonicalizedString canonicalizedString)
        {
            // Now we append the canonicalized resource element.
            string canonicalizedResource = GetCanonicalizedResourceVersion2(address, accountName);

            canonicalizedString.AppendCanonicalizedElement(canonicalizedResource);
        }

        /// <summary>
        /// Add the resource name.
        /// </summary>
        /// <param name="address">The address.</param>
        /// <param name="accountName">Name of the account.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        private static void AddCanonicalizedResource(Uri address, string accountName, CanonicalizedString canonicalizedString)
        {
            // Now we append the canonicalized resource element.
            string canonicalizedResource = GetCanonicalizedResource(address, accountName);
            canonicalizedString.AppendCanonicalizedElement(canonicalizedResource);
        }

        /// <summary>
        /// Add x-ms- prefixed headers in a fixed order.
        /// </summary>
        /// <param name="headers">The headers.</param>
        /// <param name="canonicalizedString">The canonicalized string.</param>
        private static void AddCanonicalizedHeaders(NameValueCollection headers, CanonicalizedString canonicalizedString)
        {
            // Look for header names that start with HeaderNames.PrefixForStorageHeader
            // Then sort them in case-insensitive manner.
            ArrayList httpStorageHeaderNameArray = new ArrayList();

            foreach (string key in headers.Keys)
            {
                if (key.ToLowerInvariant().StartsWith(Constants.HeaderConstants.PrefixForStorageHeader, StringComparison.Ordinal))
                {
                    httpStorageHeaderNameArray.Add(key.ToLowerInvariant());
                }
            }

            httpStorageHeaderNameArray.Sort();

            // Now go through each header's values in the sorted order and append them to the canonicalized string.
            foreach (string key in httpStorageHeaderNameArray)
            {
                StringBuilder canonicalizedElement = new StringBuilder(key);
                string delimiter = ":";
                ArrayList values = GetHeaderValues(headers, key);

                // Go through values, unfold them, and then append them to the canonicalized element string.
                foreach (string value in values)
                {
                    // Unfolding is simply removal of CRLF.
                    string unfoldedValue = value.Replace("\r\n", string.Empty);

                    // Append it to the canonicalized element string.
                    canonicalizedElement.Append(delimiter);
                    canonicalizedElement.Append(unfoldedValue);
                    delimiter = ",";
                }

                // Now, add this canonicalized element to the canonicalized header string.
                canonicalizedString.AppendCanonicalizedElement(canonicalizedElement.ToString());
            }
        }
    }
}
