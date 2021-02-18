// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Azure.Iot.ModelsRepository
{
    internal static class DtmiConventions
    {
        private static readonly Regex s_validDtmiRegex = new Regex(@"^dtmi:[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?(?::[A-Za-z](?:[A-Za-z0-9_]*[A-Za-z0-9])?)*;[1-9][0-9]{0,8}$");

        public static bool IsDtmi(string dtmi) => !string.IsNullOrEmpty(dtmi) && s_validDtmiRegex.IsMatch(dtmi);

        public static string DtmiToPath(string dtmi) => IsDtmi(dtmi) ? $"{dtmi.ToLowerInvariant().Replace(":", "/").Replace(";", "-")}.json" : null;

        public static string DtmiToQualifiedPath(string dtmi, string basePath, bool fromExpanded = false)
        {
            string dtmiPath = DtmiToPath(dtmi);

            if (dtmiPath == null)
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, StandardStrings.InvalidDtmiFormat, dtmi));
            }

            if (!basePath.EndsWith("/", StringComparison.InvariantCultureIgnoreCase))
            {
                basePath += "/";
            }

            string fullyQualifiedPath = $"{basePath}{dtmiPath}";

            if (fromExpanded)
            {
                fullyQualifiedPath = fullyQualifiedPath.Replace(
                    ModelRepositoryConstants.JsonFileExtension,
                    ModelRepositoryConstants.ExpandedJsonFileExtension);
            }

            return fullyQualifiedPath;
        }
    }
}
