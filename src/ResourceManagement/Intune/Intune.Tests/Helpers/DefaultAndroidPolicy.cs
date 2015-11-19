//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

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
