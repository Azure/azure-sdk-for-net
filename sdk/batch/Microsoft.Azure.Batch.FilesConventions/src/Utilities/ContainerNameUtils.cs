// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Microsoft.Azure.Batch.Conventions.Files.Utilities
{
    internal static class ContainerNameUtils
    {
        private static readonly Regex PermittedContainerNamePattern = new Regex("^[a-z0-9][-a-z0-9]*$");

        // new instance each time because a shared instance would not be thread-safe
#if FullNetFx
        private static readonly Func<HashAlgorithm> hasher = () => new SHA1CryptoServiceProvider();
#elif netstandard14
        private static readonly Func<HashAlgorithm> hasher = () => SHA1.Create();
#endif
        private static readonly int MaxJobIdLengthInMungedContainerName = 15;  // must be <= 63 - "job-".Length - 1 (hyphen before hash) - length of hash string (40 for SHA1)
        private static readonly char[] ForbiddenLeadingTrailingContainerNameChars = new[] { '-' };
        private static readonly Regex InvalidContainerCharacters = new Regex("[:_-]+");
        private const string ContainerPrefix = "job-";
        private static readonly int MaxUsableJobIdLength = 63 - ContainerPrefix.Length;

        internal static string GetSafeContainerName(string jobId)
        {
            return ContainerPrefix + GetUnprefixedSafeContainerName(jobId);
        }

        private static string GetUnprefixedSafeContainerName(string jobId)
        {
            jobId = jobId.ToLowerInvariant();  // it's safe to do this early as job ids cannot differ only by case, so the lower case job id is still a unique identifier

            // Check that job-{jobId} won't overflow the maximum container name length.
            // We don't need a minimum length check because the "job-" prefix ensures
            // that the actual container name will be >= 3 characters.
            if (jobId.Length > MaxUsableJobIdLength)  
            {
                return TransformToContainerName(jobId);
            }

            // Check that the jobId contains only characters that are valid in a container
            // name, and doesn't start with a '-'.
            if (!PermittedContainerNamePattern.IsMatch(jobId))
            {
                return TransformToContainerName(jobId);
            }

            // Check that jobId doesn't end with a '-', and doesn't contain consecutive hyphens.
            if (jobId[jobId.Length - 1] == '-' || jobId.Contains("--"))
            {
                return TransformToContainerName(jobId);
            }

            return jobId;
        }

        private static string TransformToContainerName(string str)
        {
            var hash = hasher().ComputeHash(Encoding.UTF8.GetBytes(str));
            var hashText = ToHex(hash);

            var safeStr = MakeSafe(str);

            safeStr = safeStr.Trim(ForbiddenLeadingTrailingContainerNameChars);

            if (safeStr.Length > MaxJobIdLengthInMungedContainerName)
            {
                safeStr = safeStr.Substring(0, MaxJobIdLengthInMungedContainerName)
                                 .Trim(ForbiddenLeadingTrailingContainerNameChars);  // do this again as truncation may have unleashed a trailing dash
            }
            else if (safeStr.Length == 0)
            {
                safeStr = "job";
            }

            return safeStr + "-" + hashText;
        }

        private static string MakeSafe(string rawString)
        {
            return InvalidContainerCharacters.Replace(rawString, "-");
        }

        private static string ToHex(byte[] bytes)
        {
            var sb = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes)
            {
                sb.AppendFormat(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
