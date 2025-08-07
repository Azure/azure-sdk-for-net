// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azure.IoT.ModelsRepository
{
    /// <summary>
    /// DtmiConventions implements the core aspects of the IoT model repo conventions
    /// which includes DTMI validation and calculating a URI path from a DTMI.
    /// </summary>
    public static class DtmiConventions
    {
        // A DTMI has three components: scheme, path, and version.
        // Scheme and path are separated by a colon. Path and version are separated by a semicolon i.e. <scheme> : <path> ; <version>.
        // The scheme is the string literal "dtmi" in lowercase. The path is a sequence of one or more segments, separated by colons.
        // The version is a sequence of one or more digits. Each path segment is a non-empty string containing only letters, digits, and underscores.
        // The first character may not be a digit, and the last character may not be an underscore.
        // The version length is limited to nine digits, because the number 999,999,999 fits in a 32-bit signed integer value.
        // The first digit may not be zero, so there is no ambiguity regarding whether version 1 matches version 01 since the latter is invalid.
        private static readonly Regex s_validDtmiRegex = new Regex(@"^dtmi:[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?(?::[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?)*(?:;[1-9][0-9]{0,8}(?:\.[1-9][0-9]{0,5})?)?$");

        /// <summary>
        /// Indicates whether a given string DTMI value is well-formed.
        /// </summary>
        public static bool IsValidDtmi(string dtmi) => !string.IsNullOrEmpty(dtmi) && s_validDtmiRegex.IsMatch(dtmi);

        /// <summary>
        /// Get the URI object representing a digital twin model file in a target model repository.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when a given DTMI string is malformed.</exception>
        /// <param name="dtmi">A well-formed DTMI. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="repositoryUri">The repository URI in which a transformed DTMI to path will be combined with.</param>
        /// <param name="expanded">Indicates whether the produced path should be for the expanded model definition.</param>
        public static Uri GetModelUri(string dtmi, Uri repositoryUri, bool expanded = false)
        {
            string dtmiPath = DtmiToPath(dtmi);

            if (dtmiPath == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, StandardStrings.InvalidDtmiFormat, dtmi));
            }

            if (expanded)
            {
                dtmiPath = dtmiPath.Replace(
                    ModelsRepositoryConstants.JsonFileExtension,
                    ModelsRepositoryConstants.ExpandedJsonFileExtension);
            }

            var repositoryUriBuilder = new UriBuilder(repositoryUri);

            // If the base URI (repositoryUri in this case) path segment does not end in slash
            // that segment will be dropped and not properly anchored to by the intended relative URI.
            if (!repositoryUriBuilder.Path.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                repositoryUriBuilder.Path += "/";
            }

            return new Uri(repositoryUriBuilder.Uri, dtmiPath);
        }

        internal static Uri GetMetadataUri(Uri repositoryUri)
        {
            var repositoryUriBuilder = new UriBuilder(repositoryUri);

            // If the base URI (repositoryUri in this case) path segment does not end in slash
            // that segment will be dropped and not properly anchored to by the intended relative URI.
            if (!repositoryUriBuilder.Path.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                repositoryUriBuilder.Path += "/";
            }
            return new Uri(repositoryUriBuilder.Uri, ModelsRepositoryConstants.ModelsRepositoryMetadataFile);
        }

        internal static string DtmiToPath(string dtmi) => IsValidDtmi(dtmi) ? $"{dtmi.ToLowerInvariant().Replace(":", "/").Replace(";", "-")}.json" : null;
    }
}
