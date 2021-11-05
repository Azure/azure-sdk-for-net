// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Core;
using Azure.Storage.Sas;

namespace Azure.Storage.Queues
{
    /// <summary>
    /// The <see cref="QueueUriBuilder"/> class provides a convenient way to
    /// modify the contents of a <see cref="System.Uri"/> instance to point to
    /// different Azure Storage resources like an account, queue, or message.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/rest/api/storageservices/addressing-queue-service-resources">
    /// Addressing Queue Service Resources</see>.
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
        /// Whether the Uri is a path-style Uri (i.e. it is an IP Uri or the domain includes a port that is used by the local emulator).
        /// </summary>
        private readonly bool _isPathStyleUri;

        /// <summary>
        /// Gets or sets the scheme name of the URI.
        /// Example: "https"
        /// </summary>
        public string Scheme
        {
            get => _scheme;
            set { ResetUri(); _scheme = value; }
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
            get => _host;
            set { ResetUri(); _host = value; }
        }
        private string _host;

        /// <summary>
        /// Gets or sets the port number of the URI.
        /// </summary>
        public int Port
        {
            get => _port;
            set { ResetUri(); _port = value; }
        }
        private int _port;

        /// <summary>
        /// Gets or sets the Azure Storage account name.
        /// </summary>
        public string AccountName
        {
            get => _accountName;
            set { ResetUri(); _accountName = value; }
        }
        private string _accountName;

        /// <summary>
        /// Gets or sets the name of a Azure Storage Queue.  The value defaults
        /// to <see cref="string.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// </summary>
        public string QueueName
        {
            get => _queueName;
            set { ResetUri(); _queueName = value; }
        }
        private string _queueName;

        /// <summary>
        /// Gets or sets whether to reference a queue's messages.
        /// </summary>
        public bool Messages
        {
            get => _messages;
            set { ResetUri(); _messages = value; }
        }
        private bool _messages;

        /// <summary>
        /// Gets or sets the ID of a message in a queue.  The value defaults to
        /// <see cref="string.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string MessageId
        {
            get => _messageId;
            set { ResetUri(); _messageId = value; }
        }
        private string _messageId;

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public SasQueryParameters Sas
        {
            get => _sas;
            set { ResetUri(); _sas = value; }
        }
        private SasQueryParameters _sas;

        /// <summary>
        /// Gets or sets any query information included in the URI that's not
        /// relevant to addressing Azure storage resources.
        /// </summary>
        public string Query
        {
            get => _query;
            set { ResetUri(); _query = value; }
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
            uri = uri ?? throw new ArgumentNullException(nameof(uri));

            Scheme = uri.Scheme;
            Host = uri.Host;
            Port = uri.Port;
            AccountName = "";
            QueueName = "";
            Messages = false;
            MessageId = "";
            Sas = null;

            // Find the account, queue, and message id (if any)
            if (!string.IsNullOrEmpty(uri.AbsolutePath))
            {
                var path = uri.GetPath();

                var startIndex = 0;

                if (uri.IsHostIPEndPointStyle())
                {
                    _isPathStyleUri = true;
                    var accountEndIndex = path.IndexOf("/", StringComparison.InvariantCulture);

                    // Slash not found; path has account name & no queue name
                    if (accountEndIndex == -1)
                    {
                        AccountName = path;
                        startIndex = path.Length;
                    }
                    else
                    {
                        AccountName = path.Substring(0, accountEndIndex);
                        startIndex = accountEndIndex + 1;
                    }
                }
                else
                {
                    AccountName = uri.GetAccountNameFromDomain(Constants.Queue.UriSubDomain) ?? string.Empty;
                }

                // Find the next slash (if it exists)
                var queueEndIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture);

                // Slash not found; path has queue name & no message id
                if (queueEndIndex == -1)
                {
                    QueueName = path.Substring(startIndex);
                }
                else
                {
                    // The queue name is the part between the slashes
                    QueueName = path.Substring(startIndex, queueEndIndex - startIndex);

                    // skip "messages"
                    Messages = true;
                    startIndex = startIndex + (queueEndIndex - startIndex) + 1;
                    startIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture) + 1;

                    if (startIndex != 0)
                    {
                        // set messageId
                        MessageId = path.Substring(startIndex, path.Length - startIndex);
                    }
                }
            }

            // Convert the query parameters to a case-sensitive map & trim whitespace
            var paramsMap = new UriQueryParamsCollection(uri.Query);
            if (paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
            {
                Sas = SasQueryParametersInternals.Create(paramsMap);
            }
            Query = paramsMap.ToString();
        }

        /// <summary>
        /// Returns the <see cref="System.Uri"/> constructed from the
        /// <see cref="QueueUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS and additional query parameters.
        /// </summary>
        public Uri ToUri()
        {
            if (_uri == null)
            {
                _uri = BuildUri().ToUri();
            }
            return _uri;
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
            BuildUri().ToString();

        /// <summary>
        /// Reset our cached URI.
        /// </summary>
        private void ResetUri() =>
            _uri = null;

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
            // only append the account name to the path for Ip style Uri.
            // regular style Uri will already have account name in domain
            if (_isPathStyleUri && !string.IsNullOrWhiteSpace(AccountName))
            {
                path.Append('/').Append(AccountName);
            }

            if (!string.IsNullOrWhiteSpace(QueueName))
            {
                path.Append('/').Append(QueueName);
                if (Messages)
                {
                    path.Append("/messages");
                    if (!string.IsNullOrWhiteSpace(MessageId))
                    {
                        path.Append('/').Append(MessageId);
                    }
                }
            }

            // Concatenate query parameters
            var query = new StringBuilder(Query);
            var sas = Sas?.ToString();
            if (!string.IsNullOrWhiteSpace(sas))
            {
                if (query.Length > 0) { query.Append('&'); }
                query.Append(sas);
            }

            // Use RequestUriBuilder, which has slightly nicer formatting
            return new RequestUriBuilder
            {
                Scheme = Scheme,
                Host = Host,
                Port = Port,
                Path = path.ToString(),
                Query = query.Length > 0 ? "?" + query.ToString() : null
            };
        }
    }
}
