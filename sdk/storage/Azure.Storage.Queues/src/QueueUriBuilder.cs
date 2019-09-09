// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using System.Text;
using Azure.Core.Http;
using Azure.Storage.Sas;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// The <see cref="QueueUriBuilder"/> class provides a convenient way to
    /// modify the contents of a <see cref="System.Uri"/> instance to point to
    /// different Azure Storage resources like an account, queue, or message.
    ///
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/addressing-queue-service-resources"/>
    /// </summary>
    public class QueueUriBuilder
    {
        /// <summary>
        /// The Uri instance constructed by this builder.  It will be reset to
        /// null when changes are made and reconstructed when <see cref="System.Uri"/>
        /// is accessed.
        /// </summary>
        private Uri _uri;

        /// <summary>
        /// Gets or sets the scheme name of the URI.
        /// Example: "https"
        /// </summary>
        public string Scheme
        {
            get => this._scheme;
            set { this.ResetUri(); this._scheme = value; }
        }
        private string _scheme;

        /// <summary>
        /// Gets or sets the Domain Name System (DNS) host name or IP address
        /// of a server.
        /// 
        /// Example: "account.queue.core.windows.net"
        /// </summary>
        public string Host
        {
            get => this._host;
            set { this.ResetUri(); this._host = value; }
        }
        private string _host;

        /// <summary>
        /// Gets or sets the port number of the URI.
        /// </summary>
        public int Port
        {
            get => this._port;
            set { this.ResetUri(); this._port = value; }
        }
        private int _port;

        /// <summary>
        /// Gets or sets the Azure Storage account name.  This is only
        /// populated for IP-style <see cref="System.Uri"/>s.
        /// </summary>
        public string AccountName
        {
            get => this._accountName;
            set { this.ResetUri(); this._accountName = value; }
        }
        private string _accountName;

        /// <summary>
        /// Gets or sets the name of a Azure Storage Queue.  The value defaults
        /// to <see cref="String.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// </summary>
        public string QueueName
        {
            get => this._queueName;
            set { this.ResetUri(); this._queueName = value; }
        }
        private string _queueName;

        /// <summary>
        /// Gets or sets whether to reference a queue's messages.
        /// </summary>
        public bool Messages
        {
            get => this._messages;
            set { this.ResetUri(); this._messages = value; }
        }
        private bool _messages;

        /// <summary>
        /// Gets or sets the ID of a message in a queue.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string MessageId
        {
            get => this._messageId;
            set { this.ResetUri(); this._messageId = value; }
        }
        private string _messageId;

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public SasQueryParameters Sas
        {
            get => this._sas;
            set { this.ResetUri(); this._sas = value; }
        }
        private SasQueryParameters _sas;

        /// <summary>
        /// Gets or sets any query information included in the URI that's not
        /// relevant to addressing Azure storage resources.
        /// </summary>
        public string Query
        {
            get => this._query;
            set { this.ResetUri(); this._query = value; }
        }
        private string _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueUriBuilder"/>
        /// class with the specified <see cref="System.Uri"/>.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="System.Uri"/> to a storage resource.
        /// </param>
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

            // Find the account, queue, and message id (if any)
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
            this.Query = paramsMap.ToString();
        }

        /// <summary>
        /// Gets a <see cref="System.Uri"/> representing the
        /// <see cref="QueueUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS and additional query parameters.
        /// </summary>
        public Uri Uri
        {
            get
            {
                if (this._uri == null)
                {
                    this._uri = this.BuildUri().Uri;
                }
                return this._uri;
            }
        }

        /// <summary>
        /// Returns the display string for the specified
        /// <see cref="QueueUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// The display string for the specified <see cref="QueueUriBuilder"/>
        /// instance.
        /// </returns>
        public override string ToString() =>
            this.BuildUri().ToString();

        /// <summary>
        /// Reset our cached URI.
        /// </summary>
        private void ResetUri() =>
            this._uri = null;

        /// <summary>
        /// Construct a <see cref="RequestUriBuilder"/> representing the
        /// <see cref="QueueUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and unparsed query parameters.
        /// </summary>
        /// <returns>The constructed <see cref="RequestUriBuilder"/>.</returns>
        private RequestUriBuilder BuildUri()
        {
            // Concatenate account, queue, & messageId (if they exist)
            var path = new StringBuilder("");
            if (!String.IsNullOrWhiteSpace(this.AccountName))
            {
                path.Append("/").Append(this.AccountName);
            }

            if(!String.IsNullOrWhiteSpace(this.QueueName))
            {
                path.Append("/").Append(this.QueueName);
                if (this.Messages)
                {
                    path.Append("/messages");
                    if (!String.IsNullOrWhiteSpace(this.MessageId))
                    {
                        path.Append("/").Append(this.MessageId);
                    }
                }
            }

            // Concatenate query parameters
            var query = new StringBuilder(this.Query);
            var sas = this.Sas?.ToString();
            if (!String.IsNullOrWhiteSpace(sas))
            {
                if (query.Length > 0) { query.Append("&"); }
                query.Append(sas);
            }

            // Use RequestUriBuilder, which has slightly nicer formatting
            return new RequestUriBuilder
            {
                Scheme = this.Scheme,
                Host = this.Host,
                Port = this.Port,
                Path = path.ToString(),
                Query = query.Length > 0 ? "?" + query.ToString() : null
            };
        }

        // TODO See remarks at https://docs.microsoft.com/en-us/dotnet/api/system.net.ipaddress.tryparse?view=netframework-4.7.2
        private static bool IsHostIPEndPointStyle(string host)
            => String.IsNullOrEmpty(host) ? false : IPAddress.TryParse(host, out var _);
    }
}
