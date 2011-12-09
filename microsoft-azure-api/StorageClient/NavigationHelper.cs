//-----------------------------------------------------------------------
// <copyright file="NavigationHelper.cs" company="Microsoft">
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
//    Contains code for the NavigationHelper class.
// </summary>
//-----------------------------------------------------------------------

namespace Microsoft.WindowsAzure.StorageClient
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Contains methods for dealing with navigation.
    /// </summary>
    internal static class NavigationHelper
    {
        /// <summary>
        /// The name of the root container.
        /// </summary>
        public const string RootContainerName = "$root";

        /// <summary>
        /// Used in address parsing.
        /// </summary>
        public const string Slash = "/";

        /// <summary>
        /// Used in address parsing.
        /// </summary>
        public const string Dot = ".";

        /// <summary>
        /// Used in address parsing.
        /// </summary>
        public const char SlashChar = '/';

        /// <summary>
        /// Used to split string on slash.
        /// </summary>
        public static readonly char[] SlashAsSplitOptions = new char[] { '/' };

        /// <summary>
        /// Used to split hostname.
        /// </summary>
        public static readonly char[] DotAsSplitOptions = new char[] { '.' };

        /// <summary>
        /// Retrieves the container part of a storage Uri, or "$root" if the container is implicit.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>Name of the container.</returns>
        /// <remarks>
        /// The trailing slash is always removed.
        /// <example>
        /// GetContainerName(new Uri("http://test.blob.core.windows.net/mycontainer/myfolder/myblob")) will return "mycontainer"
        /// GetConatinerName(new Uri("http://test.blob.core.windows.net/mycontainer/")) will return "mycontainer"
        /// GetConatinerName(new Uri("http://test.blob.core.windows.net/myblob")) will return "$root"
        /// GetConatinerName(new Uri("http://test.blob.core.windows.net/")) will throw ArgumentException
        /// </example>
        /// </remarks>
        internal static string GetContainerName(Uri blobAddress, bool usePathStyleUris)
        {
            string containerName;
            string blobName;

            GetContainerNameAndBlobName(blobAddress, usePathStyleUris, out containerName, out blobName);

            return containerName;
        }

        /// <summary>
        /// Retrieves the blob part of a storage Uri.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>The name of the blob.</returns>
        internal static string GetBlobName(Uri blobAddress, bool usePathStyleUris)
        {
            string containerName;
            string blobName;

            GetContainerNameAndBlobName(blobAddress, usePathStyleUris, out containerName, out blobName);

            return blobName;
        }

        /// <summary>
        /// Retreives the complete container address from a storage Uri
        /// Example GetContainerAddress(new Uri("http://test.blob.core.windows.net/mycontainer/myfolder/myblob"))
        /// will return http://test.blob.core.windows.net/mycontainer.
        /// </summary>
        /// <param name="blobAddress">The BLOB address.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <returns>Uri of the container.</returns>
        internal static string GetContainerAddress(Uri blobAddress, bool usePathStyleUris)
        {
            string containerName;
            Uri containerAddress;
            GetContainerNameAndAddress(blobAddress, usePathStyleUris, out containerName, out containerAddress);

            return containerAddress.AbsoluteUri;
        }

        /// <summary>
        /// Retreives the parent name from a storage Uri.
        /// </summary>
        /// <param name="blobAddress">The BLOB address.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>The name of the parent.</returns>
        /// <remarks>
        /// Adds the trailing delimiter as the prefix returned by the storage REST api always contains the delimiter.
        /// </remarks>
        /// <example>
        /// GetParentName(new Uri("http://test.blob.core.windows.net/mycontainer/myfolder/myblob", "/")) will return "/mycontainer/myfolder/"
        /// GetParentName(new Uri("http://test.blob.core.windows.net/mycontainer/myfolder|myblob", "|") will return "/mycontainer/myfolder|"
        /// GetParentName(new Uri("http://test.blob.core.windows.net/mycontainer/myblob", "/") will return "/mycontainer/"
        /// GetParentName(new Uri("http://test.blob.core.windows.net/mycontainer/", "/") will return "/mycontainer/"
        /// </example>
        internal static string GetParentName(Uri blobAddress, string delimiter, bool usePathStyleUris)
        {
            CommonUtils.AssertNotNull("blobAbsoluteUriString", blobAddress);
            CommonUtils.AssertNotNullOrEmpty("delimiter", delimiter);

            string containerName;
            Uri containerUri;
            GetContainerNameAndAddress(blobAddress, usePathStyleUris, out containerName, out containerUri);

            // Get the blob path as the rest of the Uri
            var blobPathUri = containerUri.MakeRelativeUri(blobAddress);
            var blobPath = blobPathUri.OriginalString;

            if (blobPath.EndsWith(delimiter))
            {
                blobPath = blobPath.Substring(0, blobPath.Length - delimiter.Length);
            }

            string parentName = null;

            if (string.IsNullOrEmpty(blobPath))
            {
                // Case 1 /<ContainerName>[Delimiter]*? => /<ContainerName>
                // Parent of container is container itself
                parentName = containerName + delimiter;
            }
            else
            {
                var parentLength = blobPath.LastIndexOf(delimiter);

                if (parentLength <= 0)
                {
                    // Case 2 /<Container>/<folder>
                    // Parent of a folder is container
                    parentName = containerName + delimiter;
                }
                else
                {
                    // Case 3 /<Container>/<folder>/[<subfolder>/]*<BlobName>
                    // Parent of blob is folder
                    parentName = blobPath.Substring(0, parentLength + delimiter.Length);
                }
            }

            return parentName;
        }

        /// <summary>
        /// Retrieves the parent address for a blob Uri.
        /// </summary>
        /// <param name="blobAddress">The BLOB address.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>The address of the parent.</returns>
        /// <example>
        /// GetParentName(new Uri("http://test.blob.core.windows.net/mycontainer/myfolder/myblob", null))
        /// will return "http://test.blob.core.windows.net/mycontainer/myfolder/"
        /// </example>
        internal static string GetParentAddress(Uri blobAddress, string delimiter, bool usePathStyleUris)
        {
            var parentName = GetParentName(blobAddress, delimiter, usePathStyleUris);
            Uri parentUri = NavigationHelper.AppendPathToUri(new Uri(NavigationHelper.GetServiceClientBaseAddress(blobAddress, usePathStyleUris)), parentName);
            return parentUri.AbsoluteUri;
        }

        /// <summary>
        /// Get service client address from a complete Uri.
        /// </summary>
        /// <param name="address">Complete address of the resource.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <returns>Uri of the service client.</returns>
        /// <example>
        /// GetServiceClientBaseAddress("http://testaccount.blob.core.windows.net/testconatiner/blob1") 
        /// returns "http://testaccount.blob.core.windows.net"
        /// </example>
        internal static string GetServiceClientBaseAddress(string address, bool? usePathStyleUris)
        {
            return GetServiceClientBaseAddress(new Uri(address), usePathStyleUris);
        }

        /// <summary>
        /// Gets the service client base address.
        /// </summary>
        /// <param name="addressUri">The address Uri.</param>
        /// <param name="usePathStyleUris">The use path style Uris.</param>
        /// <returns>The base address of the client.</returns>
        internal static string GetServiceClientBaseAddress(Uri addressUri, bool? usePathStyleUris)
        {
            if (usePathStyleUris == null)
            {
                // Automatically determine whether to use path style vs host style uris
                usePathStyleUris = CommonUtils.UsePathStyleAddressing(addressUri);
            }

            if (usePathStyleUris.Value)
            {
                // Path style uri
                string[] segments = addressUri.Segments;
                if (segments.Length < 2)
                {
                    string error = string.Format(CultureInfo.CurrentCulture, SR.PathStyleUriMissingAccountNameInformation, addressUri.AbsoluteUri);
                    throw new ArgumentException("address", error);
                }

                string completeAddress = addressUri.GetLeftPart(UriPartial.Authority) + Slash + segments[1];
                completeAddress = completeAddress.Trim(SlashChar);
                return completeAddress;
            }
            else
            {
                return addressUri.GetLeftPart(UriPartial.Authority);
            }
        }

        /// <summary>
        /// Appends a path to a Uri correctly using "/" as separator.
        /// </summary>
        /// <param name="uri">The base Uri.</param>
        /// <param name="relativeOrAbslouteUri">The relative or absloute URI.</param>
        /// <returns>The appended Uri.</returns>
        /// <example>
        /// AppendPathToUri(new Uri("http://test.blob.core.windows.net/test", "abc")
        /// will return "http://test.blob.core.windows.net/test/abc"
        /// AppendPathToUri(new Uri("http://test.blob.core.windows.net/test"), "http://test.blob.core.windows.net/test/abc")
        /// will return "http://test.blob.core.windows.net/test/abc"
        /// </example>
        internal static Uri AppendPathToUri(Uri uri, string relativeOrAbslouteUri)
        {
            return AppendPathToUri(uri, relativeOrAbslouteUri, NavigationHelper.Slash);
        }

        /// <summary>
        /// Append a relative path to a Uri, handling traling slashes appropiately.
        /// </summary>
        /// <param name="uri">The base Uri.</param>
        /// <param name="relativeOrAbslouteUri">The relative or absloute URI.</param>
        /// <param name="sep">The seperator.</param>
        /// <returns>The appended Uri.</returns>
        internal static Uri AppendPathToUri(Uri uri, string relativeOrAbslouteUri, string sep)
        {
            Uri relativeUri;

            // Because of URI's Scheme, URI.TryCreate() can't differentiate a string with colon from an absolute URI. 
            // A workaround is added here to verify if a given string is an absolute URI.
            if (Uri.TryCreate(relativeOrAbslouteUri, UriKind.Absolute, out relativeUri) && (relativeUri.Scheme == "http" || relativeUri.Scheme == "https"))
            {
                // Handle case if relPath is an absolute Uri
                if (uri.IsBaseOf(relativeUri))
                {
                    return relativeUri;
                }
                else
                {
                    // Happens when using fiddler, DNS aliases, or potentially NATs
                    var absoluteUri = new Uri(relativeOrAbslouteUri);
                    return new Uri(uri, absoluteUri.AbsolutePath);
                }
            }

            var ub = new UriBuilder(uri);
            string appendString = null;
            if (ub.Path.EndsWith(sep))
            {
                appendString = relativeOrAbslouteUri;
            }
            else
            {
                appendString = sep + relativeOrAbslouteUri;
            }

            string escapedRelativeOrAbslouteUri = Uri.EscapeUriString(appendString);
            ub.Path += escapedRelativeOrAbslouteUri;

            return ub.Uri;
        }

        /// <summary>
        /// Get container name from address for styles of paths
        /// Eg: http://test.blob.core.windows.net/container/blob =&gt; container
        /// http://127.0.0.1:10000/test/container/blob =&gt; container.
        /// </summary>
        /// <param name="uri">The container Uri.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>The container name.</returns>
        internal static string GetContainerNameFromContainerAddress(Uri uri, bool usePathStyleUris)
        {
            if (usePathStyleUris)
            {
                string[] parts = uri.AbsolutePath.Split(NavigationHelper.SlashAsSplitOptions);

                if (parts.Length < 3)
                {
                    string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.MissingAccountInformationInUri, uri.AbsoluteUri);
                    throw new InvalidOperationException(errorMessage);
                }

                return parts[2];
            }
            else
            {                
                return uri.AbsolutePath.Substring(1);
            }
        }

        /// <summary>
        /// Gets the canonical path from creds.
        /// </summary>
        /// <param name="credentials">The credentials.</param>
        /// <param name="absolutePath">The absolute path.</param>
        /// <returns>The canonical path.</returns>
        internal static string GetCanonicalPathFromCreds(StorageCredentials credentials, string absolutePath)
        {
            string account = credentials.AccountName;

            if (account == null)
            {
                string errorMessage = string.Format(CultureInfo.CurrentCulture, SR.CannotCreateSASSignatureForGivenCred);
                throw new InvalidOperationException(errorMessage);
            }

            return NavigationHelper.Slash + account + absolutePath;
        }

        /// <summary>
        /// Similar to getting container name from Uri.
        /// </summary>
        /// <param name="uri">The queue Uri.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <returns>The queue name.</returns>
        internal static string GetQueueNameFromUri(Uri uri, bool usePathStyleUris)
        {
            return GetContainerNameFromContainerAddress(uri, usePathStyleUris);
        }

        /// <summary>
        /// Retrieve the container address and address.
        /// </summary>
        /// <param name="blobAddress">The BLOB address.</param>
        /// <param name="usePathStyleUris">True to use path style Uris.</param>
        /// <param name="containerName">Name of the container.</param>
        /// <param name="containerUri">The container URI.</param>
        private static void GetContainerNameAndAddress(Uri blobAddress, bool usePathStyleUris, out string containerName, out Uri containerUri)
        {
            containerName = GetContainerName(blobAddress, usePathStyleUris);
            containerUri = NavigationHelper.AppendPathToUri(new Uri(GetServiceClientBaseAddress(blobAddress, usePathStyleUris)), containerName);
        }

        /// <summary>
        /// Retrieve the container name and the blob name from a blob address.
        /// </summary>
        /// <param name="blobAddress">The blob address.</param>
        /// <param name="usePathStyleUris">If set to <c>true</c> use path style Uris.</param>
        /// <param name="containerName">The resulting container name.</param>
        /// <param name="blobName">The resulting blob name.</param>
        private static void GetContainerNameAndBlobName(Uri blobAddress, bool usePathStyleUris, out string containerName, out string blobName)
        {
            CommonUtils.AssertNotNull("blobAddress", blobAddress);

            var addressParts = blobAddress.Segments;

            int containerIndex = usePathStyleUris ? 2 : 1;
            int firstBlobIndex = containerIndex + 1;

            if (addressParts.Length - 1 < containerIndex)
            {
                // No reference appears to any container or blob
                string error = string.Format(CultureInfo.CurrentCulture, SR.MissingContainerInformation, blobAddress);
                throw new ArgumentException(error, "blobAddress");
            }
            else if (addressParts.Length - 1 == containerIndex)
            {
                // This is either the root directory of a container or a blob in the root container
                string containerOrBlobName = addressParts[containerIndex];
                if (containerOrBlobName[containerOrBlobName.Length - 1] == SlashChar)
                {
                    // This is the root directory of a container
                    containerName = containerOrBlobName.Trim(SlashChar);
                    blobName = string.Empty;
                }
                else
                {
                    // This is a blob implicitly in the root container
                    containerName = RootContainerName;
                    blobName = containerOrBlobName;
                }
            }
            else
            {
                // This is a blob in an explicit container
                containerName = addressParts[containerIndex].Trim(SlashChar);
                string[] blobNameSegments = new string[addressParts.Length - firstBlobIndex];
                Array.Copy(addressParts, firstBlobIndex, blobNameSegments, 0, blobNameSegments.Length);
                blobName = string.Concat(blobNameSegments);
            }
        }
    }
}
