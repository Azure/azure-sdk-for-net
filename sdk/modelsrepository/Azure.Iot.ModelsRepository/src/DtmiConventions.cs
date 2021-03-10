// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azure.Iot.ModelsRepository
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
        private static readonly Regex s_validDtmiRegex = new Regex(@"^dtmi:[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?(?::[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?)*;[1-9][0-9]{0,8}$");

        /// <summary>
        /// Indicates whether a given string DTMI value is well-formed.
        /// </summary>
        public static bool IsValidDtmi(string dtmi) => !string.IsNullOrEmpty(dtmi) && s_validDtmiRegex.IsMatch(dtmi);

        /// <summary>
        /// Produces a fully qualified path to a model file.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when a given DTMI string is malformed.</exception>
        /// <param name="dtmi">A well-formed DTMI. For example 'dtmi:com:example:Thermostat;1'.</param>
        /// <param name="basePath">The base path in which a transformed DTMI to path will be appended to.</param>
        /// <param name="fromExpanded">Indicates whether the produced path should be for the expanded model definition.</param>
        public static string DtmiToQualifiedPath(string dtmi, string basePath, bool fromExpanded = false)
        {
            string dtmiPath = DtmiToPath(dtmi);

            if (dtmiPath == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, StandardStrings.InvalidDtmiFormat, dtmi));
            }

            // Normalize directory seperators
            basePath = basePath.Replace("\\", "/");

            if (!basePath.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                basePath += "/";
            }

            string fullyQualifiedPath = $"{basePath}{dtmiPath}";

            if (fromExpanded)
            {
                fullyQualifiedPath = fullyQualifiedPath.Replace(
                    ModelsRepositoryConstants.JsonFileExtension,
                    ModelsRepositoryConstants.ExpandedJsonFileExtension);
            }

            return fullyQualifiedPath;
        }

        internal static string DtmiToPath(string dtmi) => IsValidDtmi(dtmi) ? $"{dtmi.ToLowerInvariant().Replace(":", "/").Replace(";", "-")}.json" : null;
    }
}
