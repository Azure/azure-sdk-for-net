//-----------------------------------------------------------------------
// <copyright file="Request.cs" company="Microsoft">
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
//    Contains code for the Request class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient.Protocol
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    
    /// <summary>
    /// Factory class for creating requests internally.
    /// </summary>
    internal static class Request
    {
        /// <summary>
        /// Internal override for the storage version string.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.StyleCop.CSharp.MaintainabilityRules",
            "SA1401:FieldsMustBePrivate",
            Justification = "Unable to change while remaining backwards compatible.")]
        internal static string TargetVersionOverride;

        /// <summary>
        /// Initializes static members of the Request class.
        /// </summary>
        static Request()
        {
            Request.UserAgent = Constants.HeaderConstants.UserAgent;
        }

        /// <summary>
        /// Gets or sets the user agent to send over the wire to identify the client.
        /// </summary>
        private static string UserAgent { get; set; }

        /// <summary>
        /// Creates the web request.
        /// </summary>
        /// <param name="uri">The request Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest CreateWebRequest(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            if (timeout != 0)
            {
                builder.Add("timeout", timeout.ToString());
            }

            Uri uriRequest = builder.AddToUri(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uriRequest);

            request.Headers.Add(Constants.HeaderConstants.StorageVersionHeader, GetTargetVersion());
            request.UserAgent = Request.UserAgent;
            return request;
        }

        /// <summary>
        /// Creates the specified Uri.
        /// </summary>
        /// <param name="uri">The Uri to create.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest Create(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);
            request.ContentLength = 0;
            request.Method = "PUT";

            return request;
        }

        /// <summary>
        /// Deletes the specified Uri.
        /// </summary>
        /// <param name="uri">The Uri to delete.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest Delete(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "DELETE";

            return request;
        }

        /// <summary>
        /// Gets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest GetMetadata(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");
            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "HEAD";

            return request;
        }

        /// <summary>
        /// Gets the properties.
        /// </summary>
        /// <param name="uri">The Uri to query.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest GetProperties(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "HEAD";

            return request;
        }

        /// <summary>
        /// Sets the metadata.
        /// </summary>
        /// <param name="uri">The blob Uri.</param>
        /// <param name="timeout">The timeout.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>A web request for performing the operation.</returns>
        internal static HttpWebRequest SetMetadata(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "metadata");
            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            return request;
        }

        /// <summary>
        /// Creates a web request to get the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to get the service properties.</returns>
        internal static HttpWebRequest GetServiceProperties(Uri uri, int timeout)
        {
            UriQueryBuilder builder = GetServiceUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpWebRequest request = Request.CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Creates a web request to set the properties of the service.
        /// </summary>
        /// <param name="uri">The absolute URI to the service.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <returns>A web request to set the service properties.</returns>
        internal static HttpWebRequest SetServiceProperties(Uri uri, int timeout)
        {
            UriQueryBuilder builder = GetServiceUriQueryBuilder();
            builder.Add(Constants.QueryConstants.Component, "properties");

            HttpWebRequest request = Request.CreateWebRequest(uri, timeout, builder);

            request.Method = "PUT";

            return request;
        }

        /// <summary>
        /// Constructs a web request to return the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        internal static HttpWebRequest GetAcl(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.Method = "GET";

            return request;
        }

        /// <summary>
        /// Constructs a web request to set the ACL for a cloud resource.
        /// </summary>
        /// <param name="uri">The absolute URI to the resource.</param>
        /// <param name="timeout">The server timeout interval.</param>
        /// <param name="builder">An optional query builder to use.</param>
        /// <returns><returns>A web request to use to perform the operation.</returns></returns>
        internal static HttpWebRequest SetAcl(Uri uri, int timeout, UriQueryBuilder builder)
        {
            if (builder == null)
            {
                builder = new UriQueryBuilder();
            }

            builder.Add(Constants.QueryConstants.Component, "acl");

            HttpWebRequest request = CreateWebRequest(uri, timeout, builder);

            request.ContentLength = 0;
            request.Method = "PUT";

            return request;
        }

        /// <summary>
        /// Writes service properties to a stream, formatted in XML.
        /// </summary>
        /// <param name="properties">The service properties to format and write to the stream.</param>
        /// <param name="outputStream">The stream to which the formatted properties are to be written.</param>
        internal static void WriteServiceProperties(ServiceProperties properties, Stream outputStream)
        {
            XDocument propertiesDocument = properties.ToServiceXml();
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;
            settings.NewLineHandling = NewLineHandling.Entitize;

            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                propertiesDocument.Save(writer);
                writer.Close();
            }
        }

        /// <summary>
        /// Generates a query builder for building service requests.
        /// </summary>
        /// <returns>A <see cref="UriQueryBuilder"/> for building service requests.</returns>
        internal static UriQueryBuilder GetServiceUriQueryBuilder()
        {
            UriQueryBuilder uriBuilder = new UriQueryBuilder();
            uriBuilder.Add(Constants.QueryConstants.ResourceType, "service");
            return uriBuilder;
        }

        /// <summary>
        /// Signs the request appropriately to make it an authenticated request for Blob and Queue.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="credentials">The credentials.</param>
        internal static void SignRequestForBlobAndQueue(HttpWebRequest request, Credentials credentials)
        {
            // Add the date header to the request
            string dateString = ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add("x-ms-date", dateString);

            // Add the key name header to the request, if applicable
            if (!string.IsNullOrEmpty(credentials.KeyName))
            {
                request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, credentials.KeyName);
            }

            // Compute the signature and add the authentication scheme
            CanonicalizationStrategy canonicalizer = CanonicalizationStrategyFactory.GetBlobQueueFullCanonicalizationStrategy(request);

            string message = canonicalizer.CanonicalizeHttpRequest(request, credentials.AccountName);
            string computedBase64Signature = StorageKey.ComputeMacSha256(credentials.Key, message);

            request.Headers.Add(
                "Authorization",
                string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", "SharedKey", credentials.SigningAccountName, computedBase64Signature));
        }

        /// <summary>
        /// Signs requests using the SharedKey authentication scheme for the table storage service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="credentials">The credentials.</param>
        internal static void SignRequestForTablesSharedKey(HttpWebRequest request, Credentials credentials)
        {
            // Add the date header to the request
            string dateString = ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add("x-ms-date", dateString);

            // Add the key name header to the request, if applicable
            if (!string.IsNullOrEmpty(credentials.KeyName))
            {
                request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, credentials.KeyName);
            }

            // Compute the signature and add the authentication scheme
            CanonicalizationStrategy canonicalizer =
                CanonicalizationStrategyFactory.GetTableFullCanonicalizationStrategy(request);

            string message = canonicalizer.CanonicalizeHttpRequest(request, credentials.AccountName);
            string computedBase64Signature = StorageKey.ComputeMacSha256(credentials.Key, message);

            request.Headers.Add(
                "Authorization",
                string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", "SharedKey", credentials.SigningAccountName, computedBase64Signature));
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="metadata">The metadata.</param>
        internal static void AddMetadata(HttpWebRequest request, NameValueCollection metadata)
        {
            if (metadata != null)
            {
                foreach (string key in metadata.AllKeys)
                {
                    AddMetadata(request, key, metadata[key]);
                }
            }
        }

        /// <summary>
        /// Adds the metadata.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="name">The metadata name.</param>
        /// <param name="value">The metadata value.</param>
        internal static void AddMetadata(HttpWebRequest request, string name, string value)
        {
            CommonUtils.AssertNotNullOrEmpty("value", value);

            request.Headers.Add("x-ms-meta-" + name, value);
        }

        /// <summary>
        /// Signs requests using the SharedKeyLite authentication scheme with is used for the table storage service.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="credentials">The credentials.</param>
        internal static void SignRequestForTablesSharedKeyLite(HttpWebRequest request, Credentials credentials)
        {
            // Add the date header to the request
            string dateString = ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add("x-ms-date", dateString);

            // Add the key name header to the request, if applicable
            if (!string.IsNullOrEmpty(credentials.KeyName))
            {
                request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, credentials.KeyName);
            }

            // Compute the signature and add the authentication scheme
            CanonicalizationStrategy canonicalizer =
                CanonicalizationStrategyFactory.GetTableLiteCanonicalizationStrategy(request);

            string message = canonicalizer.CanonicalizeHttpRequest(request, credentials.AccountName);
            string computedBase64Signature = StorageKey.ComputeMacSha256(credentials.Key, message);

            request.Headers.Add(
                "Authorization",
                string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", "SharedKeyLite", credentials.SigningAccountName, computedBase64Signature));
        }

        /// <summary>
        /// Signs requests using the SharedKeyLite authentication scheme with is used for the table storage service.
        /// Currently we only support for table.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="credentials">The credentials.</param>
        internal static void SignRequestForBlobAndQueuesSharedKeyLite(HttpWebRequest request, Credentials credentials)
        {
            // Add the date header to the request
            string dateString = ConvertDateTimeToHttpString(DateTime.UtcNow);
            request.Headers.Add("x-ms-date", dateString);

            // Add the key name header to the request, if applicable
            if (!string.IsNullOrEmpty(credentials.KeyName))
            {
                request.Headers.Add(Constants.HeaderConstants.KeyNameHeader, credentials.KeyName);
            }

            // Compute the signature and add the authentication scheme
            CanonicalizationStrategy canonicalizer =
                CanonicalizationStrategyFactory.GetBlobQueueLiteCanonicalizationStrategy(request);

            string message = canonicalizer.CanonicalizeHttpRequest(request, credentials.AccountName);
            string computedBase64Signature = StorageKey.ComputeMacSha256(credentials.Key, message);

            request.Headers.Add(
                "Authorization",
                string.Format(CultureInfo.InvariantCulture, "{0} {1}:{2}", "SharedKeyLite", credentials.SigningAccountName, computedBase64Signature));
        }

        /// <summary>
        /// Adds a proposed lease id to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="proposedLeaseId">The proposed lease id.</param>
        internal static void AddProposedLeaseId(HttpWebRequest request, string proposedLeaseId)
        {
            AddOptionalHeader(request, Constants.HeaderConstants.ProposedLeaseIdHeader, proposedLeaseId);
        }

        /// <summary>
        /// Adds a lease duration to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseDuration">The lease duration.</param>
        internal static void AddLeaseDuration(HttpWebRequest request, int? leaseDuration)
        {
            AddOptionalHeader(request, Constants.HeaderConstants.LeaseDurationHeader, leaseDuration);
        }

        /// <summary>
        /// Adds a lease break period to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseBreakPeriod">The lease break period.</param>
        internal static void AddLeaseBreakPeriod(HttpWebRequest request, int? leaseBreakPeriod)
        {
            AddOptionalHeader(request, Constants.HeaderConstants.LeaseBreakPeriodHeader, leaseBreakPeriod);
        }

        /// <summary>
        /// Adds a lease action to a request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="leaseAction">The lease action.</param>
        internal static void AddLeaseAction(HttpWebRequest request, LeaseAction leaseAction)
        {
            request.Headers.Add(Constants.HeaderConstants.LeaseActionHeader, leaseAction.ToString().ToLower());
        }

        /// <summary>
        /// Adds an optional header to a request.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        internal static void AddOptionalHeader(HttpWebRequest request, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                request.Headers.Add(name, value);
            }
        }

        /// <summary>
        /// Adds an optional header to a request.
        /// </summary>
        /// <param name="request">The web request.</param>
        /// <param name="name">The header name.</param>
        /// <param name="value">The header value.</param>
        internal static void AddOptionalHeader(HttpWebRequest request, string name, int? value)
        {
            if (value.HasValue)
            {
                request.Headers.Add(name, value.Value.ToString());
            }
        }

        /// <summary>
        /// Applies an access condition to a web request.
        /// </summary>
        /// <param name="accessCondition">The access condition to apply, or null if no access condition is to be applied.</param>
        /// <param name="request">The web request to apply the condition to.</param>
        /// <param name="applyToSource">Whether to apply the access condition to the source of an operation.</param>
        internal static void ApplyAccessCondition(AccessCondition accessCondition, HttpWebRequest request, bool applyToSource)
        {
            if (accessCondition != null)
            {
                accessCondition.ApplyCondition(request, applyToSource);
            }
        }

        /// <summary>
        /// Writes a collection of shared access policies to the specified stream in XML format.
        /// </summary>
        /// <param name="sharedAccessPolicies">A collection of shared access policies.</param>
        /// <param name="outputStream">An output stream.</param>
        /// <param name="writePolicyXml">A delegate that writes a policy to an XML writer.</param>
        /// <typeparam name="T">The type of policy to write.</typeparam>
        internal static void WriteSharedAccessIdentifiers<T>(Dictionary<string, T> sharedAccessPolicies, Stream outputStream, Action<T, XmlWriter> writePolicyXml)
        {
            CommonUtils.AssertNotNull("sharedAccessPolicies", sharedAccessPolicies);
            CommonUtils.AssertNotNull("outputStream", outputStream);

            if (sharedAccessPolicies.Count > Constants.MaxSharedAccessPolicyIdentifiers)
            {
                string errorMessage = string.Format(
                    CultureInfo.CurrentCulture,
                    SR.TooManyPolicyIdentifiers,
                    sharedAccessPolicies.Count,
                    Constants.MaxSharedAccessPolicyIdentifiers);

                throw new ArgumentOutOfRangeException("sharedAccessPolicies", errorMessage);
            }

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(outputStream, settings))
            {
                writer.WriteStartElement(Constants.SignedIdentifiers);

                foreach (string key in sharedAccessPolicies.Keys)
                {
                    writer.WriteStartElement(Constants.SignedIdentifier);

                    // Set the identifier
                    writer.WriteElementString(Constants.Id, key);

                    // Set the permissions
                    writer.WriteStartElement(Constants.AccessPolicy);

                    T policy = sharedAccessPolicies[key];

                    writePolicyXml(policy, writer);

                    writer.WriteEndElement(); // AccessPolicy
                    writer.WriteEndElement(); // SignedIdentifier
                }

                writer.WriteEndDocument();
            }
        }

        /// <summary>
        /// Creates a standard datetime string for the shared key lite authentication scheme.
        /// </summary>
        /// <param name="dateTime">DateTime value to convert to a string in the expected format.</param>
        /// <returns>The converted DateTime.</returns>
        internal static string ConvertDateTimeToHttpString(DateTime dateTime)
        {
            // On the wire everything should be represented in UTC. This assert will catch invalid callers who
            // are violating this rule.
            Debug.Assert(
                dateTime == DateTime.MaxValue ||
                dateTime == DateTime.MinValue ||
                dateTime.Kind == DateTimeKind.Utc,
                "The date must be UTC.");

            // 'R' means rfc1123 date which is what the storage services use for all dates...
            // It will be in the following format:
            // Sun, 28 Jan 2008 12:11:37 GMT
            return dateTime.ToString("R", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Gets the target version.
        /// </summary>
        /// <returns>The target version.</returns>
        internal static string GetTargetVersion()
        {
            string targetVersion = Constants.HeaderConstants.TargetStorageVersion;

            if (!string.IsNullOrEmpty(TargetVersionOverride))
            {
                targetVersion = TargetVersionOverride;
            }

            return targetVersion;
        }

        /// <summary>
        /// Converts the date time to snapshot string.
        /// </summary>
        /// <param name="dateTime">The date time.</param>
        /// <returns>The converted string.</returns>
        internal static string ConvertDateTimeToSnapshotString(DateTime dateTime)
        {
            // On the wire everything should be represented in UTC. This assert will catch invalid callers who
            // are violating this rule.
            Debug.Assert(
                dateTime == DateTime.MaxValue ||
                dateTime == DateTime.MinValue ||
                dateTime.Kind == DateTimeKind.Utc,
                "The DateTime must be UTC.");

            return dateTime.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffff'Z'", CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// This gets the file version, but fails under partial trust with a security exception.
        /// The caller should catch the exception.
        /// </summary>
        /// <returns>File version of current assembly.</returns>
        /// <remarks>
        /// Inlining of this fuction is explicitly disabled to support degrading gracefully under partial trust.
        /// FileVersionInfo.GetVersionInfo has a link demand assoicated with it. Therefore, we must make
        /// sure we never inline this function, otherwise the caller cannot catch the security 
        /// exception associated with the link demand.
        /// </remarks>
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string GetFileVersionOrThrowSecurityException()
        {
            FileVersionInfo version = FileVersionInfo.GetVersionInfo(System.Reflection.Assembly.GetExecutingAssembly().Location);
            return version.FileVersion;
        }
    }
}
