// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Microsoft.Azure.WebJobs.Description;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;

namespace Microsoft.Azure.WebJobs
{
    internal static class BlobClient
    {
        // Tested against storage service on July 2016. All other unsafe and reserved characters work fine.
        private static readonly char[] UnsafeBlobNameCharacters = { '\\' };

        public static string GetAccountName(this CloudStorageAccount account)
        {
            return account.Credentials?.AccountName;
        }

        public static string GetAccountName(this CloudBlobClient client)
        {
            return client?.Credentials?.AccountName;
        }

        // Naming rules are here: http://msdn.microsoft.com/en-us/library/dd135715.aspx
        // Validate this on the client side so that we can get a user-friendly error rather than a 400.
        // See code here: http://social.msdn.microsoft.com/Forums/en-GB/windowsazuredata/thread/d364761b-6d9d-4c15-8353-46c6719a3392
        public static void ValidateContainerName(string containerName)
        {
            if (containerName == null)
            {
                throw new ArgumentNullException("containerName");
            }

            if (!IsValidContainerName(containerName))
            {
                throw new FormatException("Invalid container name: " + containerName);
            }
        }

        public static bool IsValidContainerName(string containerName)
        {
            return BlobNameValidationAttribute.IsValidContainerName(containerName);
        }

        public static void ValidateBlobName(string blobName)
        {
            string errorMessage;

            if (!IsValidBlobName(blobName, out errorMessage))
            {
                throw new FormatException(errorMessage);
            }
        }

        // See http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx.
        public static bool IsValidBlobName(string blobName, out string errorMessage)
        {
            return BlobNameValidationAttribute.IsValidBlobName(blobName, out errorMessage);
        }
    }
}
