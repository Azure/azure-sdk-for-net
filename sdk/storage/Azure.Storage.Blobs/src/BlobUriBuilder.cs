// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using System.Net;
using System.Text;
using Azure.Core;
using Azure.Storage.Sas;
using Azure.Storage.Shared;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobUriBuilder"/> class provides a convenient way to
    /// modify the contents of a <see cref="System.Uri"/> instance to point to
    /// different Azure Storage resources like an account, container, or blob.
    ///
    /// For more information, see
    /// <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata">
    /// Naming and Referencing Containers, Blobs, and Metadata</see>.
    /// </summary>
    public class BlobUriBuilder
    {
        /// <summary>
        /// The Uri instance constructed by this builder.  It will be reset to
        /// null when changes are made and reconstructed when <see cref="Uri"/>
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
        /// Example: "account.blob.core.windows.net"
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
        /// Gets or sets the name of a blob storage Container.  The value
        /// defaults to <see cref="String.Empty"/> if not present in the
        /// <see cref="System.Uri"/>.
        /// </summary>
        public string BlobContainerName
        {
            get => _containerName;
            set { ResetUri(); _containerName = value; }
        }
        private string _containerName;

        /// <summary>
        /// Gets or sets the name of a blob.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string BlobName
        {
            get => _blobName;
            set { ResetUri(); _blobName = value; }
        }
        private string _blobName;

        /// <summary>
        /// Gets or sets the name of a blob snapshot.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string Snapshot
        {
            get => _snapshot;
            set { ResetUri(); _snapshot = value; }
        }
        private string _snapshot;

        /// <summary>
        /// Gets or sets the name of a blob version.  The value defaults to
        /// <see cref="string.Empty"/> if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public string VersionId
        {
            get => _versionId;
            set { ResetUri(); _versionId = value; }
        }
        private string _versionId;

        ///// <summary>
        ///// Gets or sets the VersionId.  The value defaults to
        ///// <see cref="String.Empty"/> if not present in the <see cref="Uri"/>.
        ///// </summary>
        //public string VersionId
        //{
        //    get => this._versionId;
        //    set { this.ResetUri(); this._versionId = value; }
        //}
        //private string _versionId;

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="System.Uri"/>.
        /// </summary>
        public BlobSasQueryParameters Sas
        {
            get => _sas;
            set { ResetUri(); _sas = value; }
        }
        private BlobSasQueryParameters _sas;

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
        /// Initializes a new instance of the <see cref="BlobUriBuilder"/>
        /// class with the specified <see cref="System.Uri"/>.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="System.Uri"/> to a storage resource.
        /// </param>
        public BlobUriBuilder(Uri uri)
        {
            uri = uri ?? throw new ArgumentNullException(nameof(uri));

            Scheme = uri.Scheme;
            Host = uri.Host;
            Port = uri.Port;

            AccountName = "";
            BlobContainerName = "";
            BlobName = "";

            Snapshot = "";
            VersionId = "";
            Sas = null;
            Query = "";

            // Find the account, container, & blob names (if any)
            if (!string.IsNullOrEmpty(uri.AbsolutePath))
            {
                var path = uri.GetPath();

                var startIndex = 0;

                if (uri.IsHostIPEndPointStyle())
                {
                    _isPathStyleUri = true;
                    var accountEndIndex = path.IndexOf("/", StringComparison.InvariantCulture);

                    // Slash not found; path has account name & no container name
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
                    AccountName = uri.GetAccountNameFromDomain(Constants.Blob.UriSubDomain) ?? string.Empty;
                }

                // Find the next slash (if it exists)
                var containerEndIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture);
                if (containerEndIndex == -1)
                {
                    BlobContainerName = path.Substring(startIndex); // Slash not found; path has container name & no blob name
                }
                else
                {
                    BlobContainerName = path.Substring(startIndex, containerEndIndex - startIndex); // The container name is the part between the slashes
                    BlobName = path.Substring(containerEndIndex + 1).UnescapePath();   // The blob name is after the container slash
                }
            }

            // Convert the query parameters to a case-sensitive map & trim whitespace
            var paramsMap = new UriQueryParamsCollection(uri.Query);

            if (paramsMap.TryGetValue(Constants.SnapshotParameterName, out var snapshotTime))
            {
                Snapshot = snapshotTime;

                // If we recognized the query parameter, remove it from the map
                paramsMap.Remove(Constants.SnapshotParameterName);
            }

            if (paramsMap.TryGetValue(Constants.VersionIdParameterName, out var versionId))
            {
                VersionId = versionId;

                // If we recognized the query parameter, remove it from the map
                paramsMap.Remove(Constants.VersionIdParameterName);
            }

            if (!string.IsNullOrEmpty(Snapshot) && !string.IsNullOrEmpty(VersionId))
            {
                throw new ArgumentException("Snapshot and VersionId cannot both be set.");
            }

            if (paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
            {
                Sas = new BlobSasQueryParameters(paramsMap);
            }

            Query = paramsMap.ToString();
        }

        /// <summary>
        /// Returns the <see cref="System.Uri"/> constructed from the
        /// <see cref="BlobUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
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
        /// <see cref="BlobUriBuilder"/> instance.
        /// </summary>
        /// <returns>
        /// The display string for the specified <see cref="BlobUriBuilder"/>
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
        /// <see cref="BlobUriBuilder"/>'s fields. The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and unparsed query parameters.
        /// </summary>
        /// <returns>The constructed <see cref="RequestUriBuilder"/>.</returns>
        private RequestUriBuilder BuildUri()
        {
            // Concatenate account, container, & blob names (if they exist)
            var path = new StringBuilder("");
            // only append the account name to the path for Ip style Uri.
            // regular style Uri will already have account name in domain
            if (_isPathStyleUri && !string.IsNullOrWhiteSpace(AccountName))
            {
                path.Append('/').Append(AccountName);
            }
            if (!string.IsNullOrWhiteSpace(BlobContainerName))
            {
                path.Append('/').Append(BlobContainerName);
                if (BlobName != null && BlobName.Length > 0)
                {
                    path.Append('/').Append(Uri.EscapeDataString(BlobName));
                }
            }

            // Concatenate query parameters
            var query = new StringBuilder(Query);
            if (!string.IsNullOrWhiteSpace(Snapshot))
            {
                if (query.Length > 0)
                { query.Append('&'); }
                query.Append(Constants.SnapshotParameterName).Append('=').Append(Snapshot);
            }
            if (!string.IsNullOrWhiteSpace(VersionId))
            {
                if (query.Length > 0)
                { query.Append('&'); }
                query.Append(Constants.VersionIdParameterName).Append('=').Append(VersionId);
            }
            var sas = Sas?.ToString();
            if (!string.IsNullOrWhiteSpace(sas))
            {
                if (query.Length > 0)
                { query.Append('&'); }
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
