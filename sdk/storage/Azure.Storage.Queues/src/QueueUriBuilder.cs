// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using Azure.Storage.Sas;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// Constructs a Queue URI.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/addressing-queue-service-resources"/>
    /// </summary>
    internal struct QueueUriBuilder : IEquatable<QueueUriBuilder>
    {
        /// <summary>
        /// Scheme.
        /// Example: "http"
        /// </summary>
        public string Scheme;

        /// <summary>
        /// Host.
        /// Example: "account.query.core.windows.net"
        /// </summary>
        public string Host;

        /// <summary>
        /// Port.
        /// </summary>
        public int Port;

        /// <summary>
        /// Account Name.  Used for IP-style URLs.  This field will be an empty string for non-IP-style URLs.
        /// </summary>
        public string AccountName;

        /// <summary>
        /// Queue Name.  Empty string if not present in URL.
        /// </summary>
        public string QueueName;

        /// <summary>
        /// If this URI includes /messages/ component.
        /// </summary>
        public bool Messages;

        /// <summary>
        /// Message Id.  Empty string if not present in URL.
        /// </summary>
        public string MessageId;

        /// <summary>
        /// SAS query parameters.  Null if not present in URL.
        /// </summary>
        public SasQueryParameters Sas;

        /// <summary>
        /// Unparsed query parameters.
        /// </summary>
        public string UnparsedParams;

        /// <summary>
        /// Parses a URL initializing QueueUriBuilder's fields including any SAS-related query parameters.
        /// Any other query parameters remain in the UnparsedParams field.
        /// </summary>
        /// <param name="uri"><see cref="Uri"/></param>
        public QueueUriBuilder(Uri uri)
        {
            this.Scheme = uri.Scheme;
            this.Host = uri.Host;
            this.Port = uri.Port;
            this.AccountName = "";
            this.QueueName = "";
            this.Messages = false;
            this.MessageId = "";
            this.Sas = null;

            // Find the account, container, & blob names (if any)
            if (!String.IsNullOrEmpty(uri.AbsolutePath))
            {
                // If path starts with a slash, remove it
                var path =
                    (uri.AbsolutePath[0] == '/')
                    ? uri.AbsolutePath.Substring(1)
                    : uri.AbsolutePath;

                var startIndex = 0;

                if (IsHostIPEndPointStyle(uri.Host))
                {
                    var accountEndIndex = path.IndexOf("/", StringComparison.InvariantCulture);

                    // Slash not found; path has account name & no queue name
                    if (accountEndIndex == -1)
                    {
                        this.AccountName = path;
                        startIndex = path.Length;
                    }
                    else
                    {
                        this.AccountName = path.Substring(0, accountEndIndex);
                        startIndex = accountEndIndex + 1;
                    }
                }

                // Find the next slash (if it exists)
                var queueEndIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture);

                // Slash not found; path has queue name & no message id
                if (queueEndIndex == -1)
                {
                    this.QueueName = path.Substring(startIndex);
                }
                else
                {
                    // The queue name is the part between the slashes
                    this.QueueName = path.Substring(startIndex, queueEndIndex - startIndex);

                    // skip "messages"
                    this.Messages = true;
                    startIndex = startIndex + (queueEndIndex - startIndex) + 1;
                    startIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture) + 1;

                    if(startIndex != 0)
                    {
                        // set messageId
                        this.MessageId = path.Substring(startIndex, path.Length - startIndex);
                    }
                }
            }

            // Convert the query parameters to a case-sensitive map & trim whitespace
            var paramsMap = new UriQueryParamsCollection(uri.Query);
            if(paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
            {
                this.Sas = new SasQueryParameters(paramsMap);
            }
            this.UnparsedParams = paramsMap.ToString();
        }

        /// <summary>
        /// URL returns a URL object whose fields are initialized from the QueueUriBuilder fields. The URL's RawQuery
        /// field contains the SAS and unparsed query parameters.
        /// </summary>
        /// <returns><see cref="Uri"/></returns>
        public Uri ToUri()
        {
            var path = "";

            // Concatenate account, queue, & messageId (if they exist)
            if(!String.IsNullOrWhiteSpace(this.AccountName))
            {
                path += "/" + this.AccountName;
            }

            if(!String.IsNullOrWhiteSpace(this.QueueName))
            {
                path += "/" + this.QueueName;

                if(this.Messages)
                {
                    path += "/messages";
                }

                if(!String.IsNullOrWhiteSpace(this.MessageId))
                {
                    path += "/" + this.MessageId;
                }
            }

            var rawQuery = this.UnparsedParams;

            if (this.Sas != null)
            {
                var sas = this.Sas.ToString();

                if (!String.IsNullOrWhiteSpace(sas))
                {
                    if (rawQuery.Length > 0)
                    {
                        rawQuery += "&";
                    }

                    rawQuery += sas;
                }
            }

            rawQuery = "?" + rawQuery;

            var uriBuilder = new UriBuilder(this.Scheme, this.Host, this.Port, path, rawQuery);

            return uriBuilder.Uri;
        }

        // TODO See remarks at https://docs.microsoft.com/en-us/dotnet/api/system.net.ipaddress.tryparse?view=netframework-4.7.2
        private static bool IsHostIPEndPointStyle(string host)
            => String.IsNullOrEmpty(host) ? false : IPAddress.TryParse(host, out var _);

        /// <summary>
        /// Check if two QueueUriBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is QueueUriBuilder other && this.Equals(other);

        /// <summary>
        /// Check if two QueueUriBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(QueueUriBuilder other)
            => this.Scheme == other.Scheme
            && this.Host == other.Host
            && this.Port == other.Port
            && this.AccountName == other.AccountName
            && this.QueueName == other.QueueName
            && this.MessageId == other.MessageId
            && this.Sas == other.Sas
            && this.UnparsedParams == other.UnparsedParams
            ;

        /// <summary>
        /// Get a hash code for the QueueUriBuilder.
        /// </summary>
        /// <returns>Hash code for the QueueUriBuilder.</returns>
        public override int GetHashCode()
            => (this.Scheme?.GetHashCode() ?? 0)
            ^ (this.Host?.GetHashCode() ?? 0)
            ^ this.Port.GetHashCode()
            ^ (this.AccountName?.GetHashCode() ?? 0)
            ^ (this.QueueName?.GetHashCode() ?? 0)
            ^ (this.MessageId?.GetHashCode() ?? 0)
            ^ (this.Sas?.GetHashCode() ?? 0)
            ^ (this.UnparsedParams?.GetHashCode() ?? 0)
            ;

        /// <summary>
        /// Check if two QueueUriBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(QueueUriBuilder left, QueueUriBuilder right) => left.Equals(right);

        /// <summary>
        /// Check if two QueueUriBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(QueueUriBuilder left, QueueUriBuilder right) => !(left == right);
    }
}
