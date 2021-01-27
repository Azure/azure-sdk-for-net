// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Text;
using Azure.Core;

namespace Azure.Data.Tables.Sas
{
    /// <summary>
    /// <see cref="TableUriBuilder"/> is used to generate a Shared Access
    /// Signature (SAS) for an Azure Storage table.
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/create-account-sas" />.
    /// </summary>
    public class TableUriBuilder
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
        /// Example: "account.table.core.windows.net"
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
        /// Gets or sets the Azure Table account name.
        /// </summary>
        public string AccountName
        {
            get => _accountName;
            set { ResetUri(); _accountName = value; }
        }
        private string _accountName;

        /// <summary>
        /// Gets or sets the name of the Azure Table.  The value defaults
        /// to <see cref="string.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// </summary>
        public string Tablename
        {
            get => _tablename;
            set { ResetUri(); _tablename = value; }
        }
        private string _tablename;

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public TableSasQueryParameters Sas
        {
            get => _sas;
            set { ResetUri(); _sas = value; }
        }
        private TableSasQueryParameters _sas;

        /// <summary>
        /// Gets or sets any query information included in the URI that's not
        /// relevant to addressing Azure Table resources.
        /// </summary>
        public string Query
        {
            get => _query;
            set { ResetUri(); _query = value; }
        }
        private string _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableUriBuilder"/>
        /// class with the specified <see cref="System.Uri"/>.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="System.Uri"/> to a Table resource.
        /// </param>
        public TableUriBuilder(Uri uri)
        {
            _uri = uri ?? throw new ArgumentNullException(nameof(uri));

            Scheme = uri.Scheme;
            Host = uri.Host;
            Port = uri.Port;
            _isPathStyleUri = uri.IsLoopback || Uri.CheckHostName(uri.Host) == UriHostNameType.IPv4;
            AccountName = TableConnectionString.GetAccountNameFromUri(uri);
            Tablename = TableConnectionString.GetTableNameFromUri(uri);
            Sas = null;

            // Convert the query parameters to a case-sensitive map & trim whitespace
            var paramsMap = new UriQueryParamsCollection(uri.Query);
            if (paramsMap.ContainsKey(TableConstants.Sas.Parameters.Version))
            {
                Sas = new TableSasQueryParameters(paramsMap);
            }
            Query = paramsMap.ToString();
        }

        /// <summary>
        /// Returns the <see cref="System.Uri"/> constructed from the
        /// <see cref="TableUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
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
        /// <see cref="TableUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// The display string for the specified <see cref="TableUriBuilder"/>
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
        /// <see cref="TableUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and unparsed query parameters.
        /// </summary>
        /// <returns>The constructed <see cref="RequestUriBuilder"/>.</returns>
        private RequestUriBuilder BuildUri()
        {
            var path = new StringBuilder();

            // only append the account name to the path for Ip style Uri.
            // regular style Uri will already have account name in domain
            if (_isPathStyleUri && !string.IsNullOrWhiteSpace(AccountName))
            {
                path.Append('/').Append(AccountName);
            }

            if (!string.IsNullOrWhiteSpace(Tablename))
            {
                path.Append('/').Append(Tablename);
            }

            // Concatenate query parameters
            var query = new StringBuilder(Query);
            var sas = Sas?.ToString();
            if (!string.IsNullOrWhiteSpace(sas))
            {
                if (query.Length > 0)
                {
                    query.Append('&');
                }
                query.Append(sas);
                query.Insert(0, "?");
            }

            // Use RequestUriBuilder, which has slightly nicer formatting
            return new RequestUriBuilder
            {
                Scheme = Scheme,
                Host = Host,
                Port = Port,
                Path = path.ToString(),
                Query = query.Length > 0 ? query.ToString() : null
            };
        }
    }
}
