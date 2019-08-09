// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using Azure.Storage.Sas;

namespace Azure.Storage.Blobs
{
    /// <summary>
    /// The <see cref="BlobUriBuilder"/> class provides a convenient way to
    /// modify the contents of a <see cref="Uri"/> instance to point to
    /// different Azure Storage resources like an account, container, or blob.
    ///
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-containers--blobs--and-metadata" />.
    /// </summary>
    internal struct BlobUriBuilder : IEquatable<BlobUriBuilder>
    {
        /// <summary>
        /// Gets or sets the scheme name of the URI.
        /// Example: "https"
        /// </summary>
        public string Scheme;

        /// <summary>
        /// Gets or sets the Domain Name System (DNS) host name or IP address
        /// of a server.
        /// Example: "account.blob.core.windows.net"
        /// </summary>
        public string Host;

        /// <summary>
        /// Gets or sets the port number of the URI.
        /// </summary>
        public int Port;

        /// <summary>
        /// Gets or sets the Azure Storage account name.  This is only
        /// populated for IP-style <see cref="Uri"/>s.
        /// </summary>
        public string AccountName;

        /// <summary>
        /// Gets or sets the name of a blob storage Container.  The value
        /// defaults to <see cref="String.Empty"/> if not present in the
        /// <see cref="Uri"/>.
        /// </summary>
        public string ContainerName;

        /// <summary>
        /// Gets or sets the name of a blob.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="Uri"/>.
        /// </summary>
        public string BlobName;

        /// <summary>
        /// Gets or sets the name of a blob snapshot.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="Uri"/>.
        /// </summary>
        public string Snapshot;

        ///// <summary>
        ///// VersionId.  Empty string if not present in URI.
        ///// </summary>
        //public string VersionId;

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="Uri"/>.
        /// </summary>
        public BlobSasQueryParameters Sas;

        /// <summary>
        /// Gets or sets the query parameters not relevant to addressing
        /// Azure storage resources.
        /// </summary>
        public string UnparsedParams;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlobUriBuilder"/>
        /// class with the specified <see cref="Uri"/>.
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> to a storage resource.
        /// </param>
        public BlobUriBuilder(Uri uri)
        {
            this.Scheme = uri.Scheme;
            this.Host = uri.Host;
            this.Port = uri.Port;
            this.AccountName = "";

            this.ContainerName = "";
            this.BlobName = "";

            this.Snapshot = "";
            //this.VersionId = "";
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

                if(IsHostIPEndPointStyle(uri.Host))
                {
                    var accountEndIndex = path.IndexOf("/", StringComparison.InvariantCulture);

                    // Slash not found; path has account name & no container name
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
                var containerEndIndex = path.IndexOf("/", startIndex, StringComparison.InvariantCulture);
                if (containerEndIndex == -1)
                {
                    this.ContainerName = path.Substring(startIndex); // Slash not found; path has container name & no blob name
                }
                else
                {
                    this.ContainerName = path.Substring(startIndex, containerEndIndex - startIndex); // The container name is the part between the slashes
                    this.BlobName = path.Substring(containerEndIndex + 1);   // The blob name is after the container slash
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

            //if(paramsMap.TryGetValue(VersionIdParameterName, out var versionId))
            //{
            //    this.VersionId = versionId;

            //    // If we recognized the query parameter, remove it from the map
            //    paramsMap.Remove(VersionIdParameterName);
            //}

            if (paramsMap.ContainsKey(Constants.Sas.Parameters.Version))
            {
                this.Sas = new BlobSasQueryParameters(paramsMap);
            }

            this.UnparsedParams = paramsMap.ToString();
        }

        /// <summary>
        /// Construct a <see cref="Uri"/> representing the
        /// <see cref="BlobUriBuilder"/>'s fields.   The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and unparsed query parameters.
        /// </summary>
        /// <returns>The constructed <see cref="Uri"/>.</returns>
        public Uri ToUri()
        {
            var path = "";

            // Concatenate account, container, & blob names (if they exist)
            if (!String.IsNullOrWhiteSpace(this.AccountName))
            {
                path += "/" + this.AccountName;
            }

            if (!String.IsNullOrWhiteSpace(this.ContainerName))
            {
                path += "/" + this.ContainerName;
                if (!String.IsNullOrWhiteSpace(this.BlobName))
                {
                    path += "/" + this.BlobName;
                }
            }

            var rawQuery = this.UnparsedParams;

            // Concatenate blob snapshot query parameter (if it exists)
            if (!String.IsNullOrWhiteSpace(this.Snapshot))
            {
                if (rawQuery.Length > 0)
                {
                    rawQuery += "&";
                }

                rawQuery += Constants.SnapshotParameterName + "=" + this.Snapshot;
            }

            //// Concatenate blob version query parameter (if it exists)
            //if (!String.IsNullOrWhiteSpace(this.VersionId))
            //{
            //    if (rawQuery.Length > 0)
            //    {
            //        rawQuery += "&";
            //    }

            //    rawQuery += VersionIdParameterName + "=" + this.VersionId;
            //}

            if(this.Sas != null)
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
        // TODO refactor to shared method
        private static bool IsHostIPEndPointStyle(string host)
            => String.IsNullOrEmpty(host) ? false : IPAddress.TryParse(host, out _);

        /// <summary>
        /// Check if two BlobUriBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is BlobUriBuilder other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the BlobUriBuilder.
        /// </summary>
        /// <returns>Hash code for the BlobUriBuilder.</returns>
        public override int GetHashCode()
            => (this.Scheme?.GetHashCode() ?? 0)
            ^ (this.Host?.GetHashCode() ?? 0)
            ^ this.Port.GetHashCode()
            ^ (this.AccountName?.GetHashCode() ?? 0)
            ^ (this.ContainerName?.GetHashCode() ?? 0)
            ^ (this.BlobName?.GetHashCode() ?? 0)
            ^ (this.Snapshot?.GetHashCode() ?? 0)
            // ^ (this.VersionId?.GetHashCode() ?? 0)
            ^ (this.Sas?.GetHashCode() ?? 0)
            ^ (this.UnparsedParams?.GetHashCode() ?? 0)
            ;

        /// <summary>
        /// Check if two BlobUriBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(BlobUriBuilder left, BlobUriBuilder right) => left.Equals(right);

        /// <summary>
        /// Check if two BlobUriBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(BlobUriBuilder left, BlobUriBuilder right) => !(left == right);

        /// <summary>
        /// Check if two BlobUriBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(BlobUriBuilder other)
            => this.Scheme == other.Scheme
            && this.Host == other.Host
            && this.Port == other.Port
            && this.AccountName == other.AccountName
            && this.ContainerName == other.ContainerName
            && this.BlobName == other.BlobName
            && this.Snapshot == other.Snapshot
            // && this.VersionId == other.VersionId
            && this.Sas == other.Sas
            && this.UnparsedParams == other.UnparsedParams
            ;
    }
}
