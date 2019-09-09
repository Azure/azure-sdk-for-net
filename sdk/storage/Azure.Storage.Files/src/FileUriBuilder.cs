// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using System.Text;
using Azure.Core.Http;
using Azure.Storage.Sas;

namespace Azure.Storage.Files
{
    /// <summary>
    /// The <see cref="FileUriBuilder"/> class provides a convenient way to 
    /// modify the contents of a <see cref="System.Uri"/> instance to point to
    /// different Azure Storage resources like an account, share, or file.
    /// 
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata" />.
    /// </summary>
    public class FileUriBuilder
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
        /// Example: "account.file.core.windows.net"
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
        /// Gets or sets the name of a file storage share.  The value defaults
        /// to <see cref="String.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// </summary>
        public string ShareName
        {
            get => this._shareName;
            set { this.ResetUri(); this._shareName = value; }
        }
        private string _shareName;

        /// <summary>
        /// Gets or sets the path of the directory or file.  The value defaults
        /// to <see cref="String.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// 
        /// Example: "mydirectory/myfile"
        /// </summary>
        public string DirectoryOrFilePath
        {
            get => this._directoryOrFilePath;
            set { this.ResetUri(); this._directoryOrFilePath = value; }
        }
        private string _directoryOrFilePath;

        /// <summary>
        /// Gets or sets the name of a file snapshot.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string Snapshot
        {
            get => this._snapshot;
            set { this.ResetUri(); this._snapshot = value; }
        }
        private string _snapshot;

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
        /// Initializes a new instance of the <see cref="FileUriBuilder"/>
        /// class with the specified <see cref="System.Uri"/>. 
        /// </summary>
        /// <param name="uri">
        /// The <see cref="System.Uri"/> to a storage resource.
        /// </param>
        public FileUriBuilder(Uri uri)
        {
            this.Scheme = uri.Scheme;
            this.Host = uri.Host;
            this.Port = uri.Port;
            this.AccountName = "";

            this.ShareName = "";
            this.DirectoryOrFilePath = "";

            this.Snapshot = "";
            this.Sas = null;

            // Find the share & directory/file path (if any)
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

                    // Slash not found; path has account name & no share name
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

                var shareEndIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture);
                if (shareEndIndex == -1)
                {
                    this.ShareName = path.Substring(startIndex); // Slash not found; path has share name & no directory/file path
                }
                else
                {
                    this.ShareName = path.Substring(startIndex, shareEndIndex - startIndex); // The share name is the part between the slashes
                    this.DirectoryOrFilePath = path.Substring(shareEndIndex + 1);   // The directory/file path name is after the share slash
                }
            }

            // Convert the query parameters to a case-sensitive map & trim whitespace

            var paramsMap = new UriQueryParamsCollection(uri.Query);

            if (paramsMap.TryGetValue(Constants.SnapshotParameterName, out var snapshotTime))
            {
                this.Snapshot = snapshotTime;

                // If we recognized the query parameter, remove it from the map
                paramsMap.Remove(Constants.SnapshotParameterName);
            }

            if (paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
            {
                this.Sas = new SasQueryParameters(paramsMap);
            }

            this.Query = paramsMap.ToString();
        }

        /// <summary>
        /// Gets a <see cref="System.Uri"/> representing the
        /// <see cref="FileUriBuilder"/>'s fields.   The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and additional query parameters.
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
        /// <see cref="FileUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// The display string for the specified <see cref="FileUriBuilder"/>
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
        /// <see cref="FileUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and additional query parameters.
        /// </summary>
        /// <returns>The constructed <see cref="RequestUriBuilder"/>.</returns>
        private RequestUriBuilder BuildUri()
        {
            // Concatenate account, share & directory/file path (if they exist)
            var path = new StringBuilder("");
            if (!String.IsNullOrWhiteSpace(this.AccountName))
            {
                path.Append("/").Append(this.AccountName);
            }
            if (!String.IsNullOrWhiteSpace(this.ShareName))
            {
                path.Append("/").Append(this.ShareName);
                if (!String.IsNullOrWhiteSpace(this.DirectoryOrFilePath))
                {
                    path.Append("/").Append(this.DirectoryOrFilePath);
                }
            }

            // Concatenate query parameters
            var query = new StringBuilder(this.Query);
            if (!String.IsNullOrWhiteSpace(this.Snapshot))
            {
                if (query.Length > 0) { query.Append("&"); }
                query.Append(Constants.SnapshotParameterName).Append("=").Append(this.Snapshot);
            }
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
        // TODO refactor to shared method
        private static bool IsHostIPEndPointStyle(string host)
            => String.IsNullOrEmpty(host) ? false : IPAddress.TryParse(host, out _);
    }
}
