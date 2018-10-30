// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.Intune.Models;

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    /// <summary>
    /// Class to help prepare default Android MAM Policy payload for a PUT request
    /// </summary>
    public class DefaultAndroidPolicy
    {
        public static AndroidMAMPolicy GetPayload(string friendlyName)
        {
            return new AndroidMAMPolicy()
            {
                FriendlyName = friendlyName,
                AppSharingToLevel = AppSharingType.none.ToString(),
                Description = Properties.Resources.AndroidPolicyDescription,
                AppSharingFromLevel = AppSharingType.none.ToString(),
                Authentication = ChoiceType.required.ToString(),
                ClipboardSharingLevel = ClipboardSharingLevelType.blocked.ToString(),
                DataBackup = FilterType.allow.ToString(),
                FileSharingSaveAs = FilterType.allow.ToString(),
                Pin = ChoiceType.required.ToString(),
                PinNumRetry = IntuneConstants.DefaultPinRetries,
                DeviceCompliance = OptionType.enable.ToString(),
                ManagedBrowser = ChoiceType.required.ToString(),
                AccessRecheckOfflineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessOfflineGraceperiodMinutes),
                AccessRecheckOnlineTimeout = TimeSpan.FromMinutes(IntuneConstants.DefaultRecheckAccessTimeoutMinutes),
                OfflineWipeTimeout = TimeSpan.FromDays(IntuneConstants.DefaultOfflineWipeIntervalDays),

                //Verify Android specific defaults
                FileEncryption = ChoiceType.required.ToString(),
                ScreenCapture = FilterType.allow.ToString(),
            };
        }
    }
}
