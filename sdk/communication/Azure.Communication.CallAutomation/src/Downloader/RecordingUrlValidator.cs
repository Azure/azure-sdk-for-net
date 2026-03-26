// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Validates recording URLs to prevent credential exfiltration via SSRF attacks.
    /// </summary>
    internal static class RecordingUrlValidator
    {
        /// <summary>
        /// Validates that a recording URL points to Azure Communication Services
        /// or Azure Blob Storage endpoint before credentials are attached.
        /// </summary>
        /// <param name="recordingUrl">The recording URL to validate.</param>
        /// <param name="parameterName">The parameter name for exception messages.</param>
        /// <exception cref="ArgumentNullException">Thrown when recordingUrl is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the URL is not a valid recording endpoint.</exception>
        internal static void ValidateRecordingUrl(Uri recordingUrl, string parameterName)
        {
            if (recordingUrl == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            // Ensure the URL is absolute and uses HTTPS
            if (!recordingUrl.IsAbsoluteUri)
            {
                throw new ArgumentException(
                    "Recording URL must be an absolute URI.",
                    parameterName);
            }

            if (!string.Equals(recordingUrl.Scheme, "https", StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException(
                    "Recording URL must use HTTPS scheme for security.",
                    parameterName);
            }

            string host = recordingUrl.Host.ToLowerInvariant();

            // Check against allowed suffixes
            bool isValidEndpoint = false;
            foreach (var suffix in Constants.RecordingUrlValidation.AllowedHostSuffixes)
            {
                if (host.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    isValidEndpoint = true;
                    break;
                }
            }

            if (!isValidEndpoint)
            {
                throw new ArgumentException(
                    $"Recording URL host '{host}' is not a valid Azure Communication Services recording endpoint. " +
                    "Only URLs pointing to *.asm.skype.com, .asyncgw.teams.microsoft.com are allowed.",
                    parameterName);
            }
        }
    }
}
