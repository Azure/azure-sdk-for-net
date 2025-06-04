// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;

namespace Azure.Storage
{
    internal static class CompatSwitches
    {
        private static bool? _disableRequestConditionsValidation;

        public static bool DisableRequestConditionsValidation => _disableRequestConditionsValidation
            ??= AppContextSwitchHelper.GetConfigValue(Constants.DisableRequestConditionsValidationSwitchName, Constants.DisableRequestConditionsValidationEnvVar);

        private static bool? _disableExpectContinueHeader;

        public static bool DisableExpectContinueHeader => _disableExpectContinueHeader
            ??= AppContextSwitchHelper.GetConfigValue(Constants.DisableExpectContinueHeaderSwitchName, Constants.DisableExpectContinueHeaderEnvVar);
    }
}
