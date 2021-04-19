// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Storage.Blobs;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    internal class BlobPath
    {
        private readonly string _containerName;
        private readonly string _blobName;

        public BlobPath(string containerName, string blobName)
        {
            if (containerName == null)
            {
                throw new ArgumentNullException(nameof(containerName));
            }

            _containerName = containerName;
            _blobName = blobName;
        }

        public string ContainerName
        {
            get { return _containerName; }
        }

        public string BlobName
        {
            get { return _blobName; }
        }

        public override string ToString()
        {
            string result = _containerName;
            if (!string.IsNullOrEmpty(_blobName))
            {
                result += "/" + _blobName;
            }

            return result;
        }

        public static BlobPath ParseAndValidate(string value, bool isContainerBinding = false)
        {
            string errorMessage;
            BlobPath path;

            if (!TryParseAndValidate(value, out errorMessage, out path, isContainerBinding))
            {
                throw new FormatException(errorMessage);
            }

            return path;
        }

        // throws exception if failed
        public static BlobPath ParseAbsUrl(string blobUrl)
        {
            BlobPath returnV;
            if (TryParseAbsUrl(blobUrl, out returnV))
            {
                return returnV;
            }
            throw new FormatException($"Invalid absolute blob url: {blobUrl}");
        }

        // similar to TryParse, but take in Url
        // does not take argument isContainerBinding since Url is blob only
        public static bool TryParseAbsUrl(string blobUrl, out BlobPath path)
        {
            Uri uri;
            path = null;
            if (Uri.TryCreate(blobUrl, UriKind.Absolute, out uri))
            {
                var blob = new BlobClient(uri);
                path = new BlobPath(blob.BlobContainerName, blob.Name); // use storage sdk to parse url
                return true;
            }
            return false;
        }

        public static bool TryParse(string value, bool isContainerBinding, out BlobPath path)
        {
            path = null;

            if (value == null)
            {
                return false;
            }

            int slashIndex = value.IndexOf('/');
            if (!isContainerBinding && slashIndex <= 0)
            {
                return false;
            }

            if (slashIndex > 0 && slashIndex == value.Length - 1)
            {
                // if there is a slash present, there must be at least one character before
                // the slash and one character after the slash.
                return false;
            }

            string containerName = slashIndex > 0 ? value.Substring(0, slashIndex) : value;
            string blobName = slashIndex > 0 ? value.Substring(slashIndex + 1) : string.Empty;

            path = new BlobPath(containerName, blobName);
            return true;
        }

        private static bool TryParseAndValidate(string value, out string errorMessage, out BlobPath path, bool isContainerBinding = false)
        {
            BlobPath possiblePath;

            if (!isContainerBinding && TryParseAbsUrl(value, out possiblePath))
            {
                path = possiblePath;
                errorMessage = null;
                return true;
            }

            if (!TryParse(value, isContainerBinding, out possiblePath))
            {
                errorMessage = $"Invalid blob path specified : '{value}'. Blob identifiers must be in the format 'container/blob'.";
                path = null;
                return false;
            }

            if (!BlobClientExtensions.IsValidContainerName(possiblePath.ContainerName))
            {
                errorMessage = "Invalid container name: " + possiblePath.ContainerName;
                path = null;
                return false;
            }

            // for container bindings, we allow an empty blob name/path
            string possibleErrorMessage;
            if (!(isContainerBinding && string.IsNullOrEmpty(possiblePath.BlobName)) &&
                !BlobClientExtensions.IsValidBlobName(possiblePath.BlobName, out possibleErrorMessage))
            {
                errorMessage = possibleErrorMessage;
                path = null;
                return false;
            }

            errorMessage = null;
            path = possiblePath;
            return true;
        }
    }
}
