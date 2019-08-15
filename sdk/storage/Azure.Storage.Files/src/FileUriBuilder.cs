// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Net;
using Azure.Storage.Sas;

namespace Azure.Storage.Files
{
    /// <summary>
    /// The <see cref="FileUriBuilder"/> class provides a convenient way to 
    /// modify the contents of a <see cref="Uri"/> instance to point to
    /// different Azure Storage resources like an account, share, or file.
    /// 
    /// For more information, see <see href="https://docs.microsoft.com/en-us/rest/api/storageservices/naming-and-referencing-shares--directories--files--and-metadata" />.
    /// </summary>
    internal struct FileUriBuilder : IEquatable<FileUriBuilder>
    {
        /// <summary>
        /// Gets or sets the scheme name of the URI.
        /// Example: "https"
        /// </summary>
        public string Scheme { get; set; }

        /// <summary>
        /// Gets or sets the Domain Name System (DNS) host name or IP address
        /// of a server.
        /// Example: "account.file.core.windows.net"
        /// </summary>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the port number of the URI.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the Azure Storage account name.  This is only
        /// populated for IP-style <see cref="Uri"/>s.
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// Gets or sets the name of a file storage share.  The value
        /// defaults to <see cref="String.Empty"/> if not present in the
        /// <see cref="Uri"/>.
        /// </summary>
        public string ShareName { get; set; }

        /// <summary>
        /// Gets or sets the path of the directory or file.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="Uri"/>.
        /// Example: "mydirectory/myfile"
        /// </summary>
        public string DirectoryOrFilePath { get; set; }

        /// <summary>
        /// Gets or sets the name of a file snapshot.  The value defaults to
        /// <see cref="String.Empty"/> if not present in the <see cref="Uri"/>.
        /// </summary>
        public string Snapshot { get; set; }

        /// <summary>
        /// Gets or sets the Shared Access Signature query parameters, or null
        /// if not present in the <see cref="Uri"/>.
        /// </summary>
        public SasQueryParameters Sas { get; set; }

        /// <summary>
        /// Gets or sets the query parameters not relevant to addressing
        /// Azure storage resources.
        /// </summary>
        public string UnparsedParams { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="FileUriBuilder"/>
        /// class with the specified <see cref="Uri"/>. 
        /// </summary>
        /// <param name="uri">
        /// The <see cref="Uri"/> to a storage resource.
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

            this.UnparsedParams = paramsMap.ToString();
        }

        /// <summary>
        /// Construct a <see cref="Uri"/> representing the
        /// <see cref="FileUriBuilder"/>'s fields.   The <see cref="Uri.Query"/>
        /// property contains the SAS, snapshot, and unparsed query parameters.     
        /// </summary>
        /// <returns>The constructed <see cref="Uri"/>.</returns>
        public Uri ToUri()
        {
            var path = "";

            // Concatenate account, share & directory/file path (if they exist)
            if (!String.IsNullOrWhiteSpace(this.AccountName))
            {
                path += "/" + this.AccountName;
            }

            if (!String.IsNullOrWhiteSpace(this.ShareName))
            {
                path += "/" + this.ShareName;
                if (!String.IsNullOrWhiteSpace(this.DirectoryOrFilePath))
                {
                    path += "/" + this.DirectoryOrFilePath;
                }
            }

            var rawQuery = this.UnparsedParams;

            // Concatenate snapshot query parameter (if it exists)

            if (!String.IsNullOrWhiteSpace(this.Snapshot))
            {
                if (rawQuery.Length > 0)
                {
                    rawQuery += "&";
                }

                rawQuery += Constants.SnapshotParameterName + "=" + this.Snapshot;
            }

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
        // TODO refactor to shared method
        private static bool IsHostIPEndPointStyle(string host)
            => String.IsNullOrEmpty(host) ? false : IPAddress.TryParse(host, out _);

        /// <summary>
        /// Check if two FileUriBuilder instances are equal.
        /// </summary>
        /// <param name="obj">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public override bool Equals(object obj)
            => obj is FileUriBuilder other && this.Equals(other);

        /// <summary>
        /// Get a hash code for the FileUriBuilder.
        /// </summary>
        /// <returns>Hash code for the FileUriBuilder.</returns>
        public override int GetHashCode()
            => (this.Scheme?.GetHashCode() ?? 0)
            ^ (this.Host?.GetHashCode() ?? 0)
            ^ this.Port.GetHashCode()
            ^ (this.AccountName?.GetHashCode() ?? 0)
            ^ (this.ShareName?.GetHashCode() ?? 0)
            ^ (this.DirectoryOrFilePath?.GetHashCode() ?? 0)
            ^ (this.Snapshot?.GetHashCode()?? 0)
            ^ (this.Sas?.GetHashCode() ?? 0)
            ^ (this.UnparsedParams?.GetHashCode() ?? 0)
            ;

        /// <summary>
        /// Check if two FileUriBuilder instances are equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public static bool operator ==(FileUriBuilder left, FileUriBuilder right) => left.Equals(right);

        /// <summary>
        /// Check if two FileUriBuilder instances are not equal.
        /// </summary>
        /// <param name="left">The first instance to compare.</param>
        /// <param name="right">The second instance to compare.</param>
        /// <returns>True if they're not equal, false otherwise.</returns>
        public static bool operator !=(FileUriBuilder left, FileUriBuilder right) => !(left == right);

        /// <summary>
        /// Check if two FileUriBuilder instances are equal.
        /// </summary>
        /// <param name="other">The instance to compare to.</param>
        /// <returns>True if they're equal, false otherwise.</returns>
        public bool Equals(FileUriBuilder other)
            => this.Scheme == other.Scheme
            && this.Host == other.Host
            && this.Port == other.Port
            && this.ShareName == other.ShareName
            && this.DirectoryOrFilePath == other.DirectoryOrFilePath
            && this.Snapshot == other.Snapshot
            && this.Sas == other.Sas
            && this.UnparsedParams == other.UnparsedParams
            ;
    }
}
