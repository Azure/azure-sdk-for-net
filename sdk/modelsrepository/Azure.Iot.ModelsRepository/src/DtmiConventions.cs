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
    internal static class DtmiConventions
    {
        // A dtmi has three components: scheme, path, and version.
        // Scheme and path are separated by a colon. Path and version are separated by a semicolon i.e. <scheme> : <path> ; <version>.
        // The scheme is the string literal "dtmi" in lowercase. The path is a sequence of one or more segments, separated by colons.
        // The version is a sequence of one or more digits. Each path segment is a non-empty string containing only letters, digits, and underscores.
        // The first character may not be a digit, and the last character may not be an underscore.
        // The version length is limited to nine digits, because the number 999,999,999 fits in a 32-bit signed integer value.
        // The first digit may not be zero, so there is no ambiguity regarding whether version 1 matches version 01 since the latter is invalid.
        private static readonly Regex s_validDtmiRegex = new Regex(@"^dtmi:[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?(?::[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?)*;[1-9][0-9]{0,8}$");

        public static bool IsDtmi(string dtmi) => !string.IsNullOrEmpty(dtmi) && s_validDtmiRegex.IsMatch(dtmi);

        public static string DtmiToPath(string dtmi) => IsDtmi(dtmi) ? $"{dtmi.ToLowerInvariant().Replace(":", "/").Replace(";", "-")}.json" : null;

        public static string DtmiToQualifiedPath(string dtmi, string basePath, bool fromExpanded = false)
        {
            string dtmiPath = DtmiToPath(dtmi);

            if (dtmiPath == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, StandardStrings.InvalidDtmiFormat, dtmi));
            }

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
    }
}
