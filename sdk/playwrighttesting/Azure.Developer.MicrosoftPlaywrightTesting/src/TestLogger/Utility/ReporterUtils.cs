// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Security.Cryptography;
using Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Model;

namespace Azure.Developer.MicrosoftPlaywrightTesting.TestLogger.Utility
{
    internal class ReporterUtils
    {
        internal static string GetRunId(CIInfo cIInfo)
        {
            if (cIInfo.Provider == Constants.DEFAULT)
            {
                return Guid.NewGuid().ToString();
            }
            var concatString = $"{cIInfo.Provider}-{cIInfo.Repo}-{cIInfo.RunId}-{cIInfo.RunAttempt}";
            return CalculateSha1Hash(concatString);
        }

        internal static string CalculateSha1Hash(string input)
        {
            using (var sha1 = SHA1.Create())
            {
                var hash = sha1.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
            }
        }
    }
}
