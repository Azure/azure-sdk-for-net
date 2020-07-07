// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;

namespace Microsoft.Azure.WebJobs.Host.Executors
{
    internal static class HostIdValidator
    {
        // The Host ID will be used as a queue name (after adding some prefixes).
        // The longer of the two is HostQueueNames.BlobTriggerPoisonQueue, and queue names must be less than 63
        // characters. Keep enough space for the longest current queue prefix plus some buffer.
        private const int MaximumHostIdLength = 32;

        public static string ValidationMessage
        {
            get
            {
                return "A host ID must be between 1 and 32 characters, contain only lowercase letters, numbers, and " +
                    "dashes, not start or end with a dash, and not contain consecutive dashes.";
            }
        }

        public static bool IsValid(string hostId)
        {
            if (String.IsNullOrEmpty(hostId))
            {
                return false;
            }

            if (hostId.Length > MaximumHostIdLength)
            {
                return false;
            }

            string longestPrefixedQueueName = HostQueueNames.GetHostBlobTriggerQueueName(hostId);

            if (!IsValidQueueName(longestPrefixedQueueName))
            {
                return false;
            }

            return true;
        }

        private static bool IsValidQueueName(string name)
        {
            string ignore;
            return IsValidQueueName(name, out ignore);
        }

        // This function from: http://blogs.msdn.com/b/neilkidd/archive/2008/11/11/windows-azure-queues-are-quite-particular.aspx
        // See http://msdn.microsoft.com/library/dd179349.aspx for rules to enforce.
        private static bool IsValidQueueName(string name, out string errorMessage)
        {
            if (String.IsNullOrEmpty(name))
            {
                errorMessage = "A queue name can't be null or empty";
                return false;
            }

            // A queue name must be from 3 to 63 characters long.
            if (name.Length < 3 || name.Length > 63)
            {
                errorMessage = "A queue name must be from 3 to 63 characters long - \"" + name + "\"";
                return false;
            }

            // The dash (-) character may not be the first or last letter.
            // we will check that the 1st and last chars are valid later on.
            if (name[0] == '-' || name[name.Length - 1] == '-')
            {
                errorMessage = "The dash (-) character may not be the first or last letter - \"" + name + "\"";
                return false;
            }

            Char previousCharacter = 'a';

            // A queue name must start with a letter or number, and may 
            // contain only letters, numbers and the dash (-) character
            // All letters in a queue name must be lowercase.
            foreach (Char ch in name)
            {
                if (Char.IsUpper(ch))
                {
                    errorMessage = "Queue names must be all lower case - \"" + name + "\"";
                    return false;
                }
                if (Char.IsLetterOrDigit(ch) == false && ch != '-')
                {
                    errorMessage =
                        "A queue name can contain only letters, numbers, and dash(-) characters - \"" + name + "\"";
                    return false;
                }
                if (ch == '-' && previousCharacter == '-')
                {
                    errorMessage = "A queue name cannot contain consecutive dash(-) characters.";
                    return false;
                }
                previousCharacter = ch;
            }

            errorMessage = null;
            return true;
        }
    }
}
