// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Microsoft.Azure.WebJobs.Description
{
    /// <summary>
    /// DataAnnotation attribute to validate a Blob Path against Azure Storage rules.
    /// A BlobPath could be:
    /// <list>
    /// <item>A Container / Blob Name</item>
    /// <item>An absolute URI specifying a Blob</item>
    /// <item>Just a Container Name</item>
    /// </list>
    /// Naming rules are here: http://msdn.microsoft.com/en-us/library/dd135715.aspx
    /// Validate this on the client side so that we can get a user-friendly error rather than a 400 from the service.
    /// See code here: http://social.msdn.microsoft.com/Forums/en-GB/windowsazuredata/thread/d364761b-6d9d-4c15-8353-46c6719a3392
    /// </summary>
    public class BlobNameValidationAttribute : ValidationAttribute
    {
        // Tested against storage service on July 2016. All other unsafe and reserved characters work fine.
        private static readonly char[] UnsafeBlobNameCharacters = { '\\' };

        // Called by the framework. 
        // This has already resolved any %%, { }  in the path.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string path = (string)value; 
            if (value == null)
            {
                return new ValidationResult("Blob path can't be null");
            }

            // Could be either just a container, container/blob, or url            
            Uri uri;
            if (Uri.TryCreate(path, UriKind.Absolute, out uri))
            {
                // still get container and blob name 
                return null;
            }

            int slashIndex = path.IndexOf('/');

            string containerName;
            if (slashIndex <= 0)
            {
                // Container-only name
                containerName = path;
            }
            else
            {
                if (slashIndex == path.Length - 1)
                {
                    // if there is a slash present, there must be at least one character before
                    // the slash and one character after the slash.
                    return new ValidationResult("Illegal blob path");
                }

                containerName = path.Substring(0, slashIndex);
                string blobName = path.Substring(slashIndex + 1);

                string msg;
                if (!IsValidBlobName(blobName, out msg))
                {
                    return new ValidationResult(msg);
                }
            }
            if (!IsValidContainerName(containerName))
            {
                return new ValidationResult("Invalid container name");
            }

            return null;
        }

        public static bool IsValidContainerName(string containerName)
        {
            if (containerName == null)
            {
                return false;
            }

            if (containerName.Equals("$root"))
            {
                return true;
            }

            return Regex.IsMatch(containerName, @"^[a-z0-9](([a-z0-9\-[^\-])){1,61}[a-z0-9]$");
        }

        // See http://msdn.microsoft.com/en-us/library/windowsazure/dd135715.aspx.
        public static bool IsValidBlobName(string blobName, out string errorMessage)
        {
            const string UnsafeCharactersMessage =
                "The given blob name '{0}' contain illegal characters. A blob name cannot the following character(s): '\\'.";
            const string TooLongErrorMessage =
                "The given blob name '{0}' is too long. A blob name must be at least one character long and cannot be more than 1,024 characters long.";
            const string TooShortErrorMessage =
                "The given blob name '{0}' is too short. A blob name must be at least one character long and cannot be more than 1,024 characters long.";
            const string InvalidSuffixErrorMessage =
                "The given blob name '{0}' has an invalid suffix. Avoid blob names that end with a dot ('.'), a forward slash ('/'), or a sequence or combination of the two.";

            if (blobName == null)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, TooShortErrorMessage, String.Empty);
                return false;
            }
            if (blobName.Length == 0)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, TooShortErrorMessage, blobName);
                return false;
            }

            if (blobName.Length > 1024)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, TooLongErrorMessage, blobName);
                return false;
            }

            if (blobName.EndsWith(".", StringComparison.OrdinalIgnoreCase) || blobName.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, InvalidSuffixErrorMessage, blobName);
                return false;
            }

            if (blobName.IndexOfAny(UnsafeBlobNameCharacters) > -1)
            {
                errorMessage = string.Format(CultureInfo.CurrentCulture, UnsafeCharactersMessage, blobName);
                return false;
            }

            errorMessage = null;
            return true;
        }
    }
}