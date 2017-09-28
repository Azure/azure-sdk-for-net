// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Microsoft.Azure.Management.Intune.Tests.Helpers
{
    /// <summary>
    /// Constants with name starting with Default are Default property values when unspecified during policy creation.
    /// </summary>
    public class IntuneConstants
    {
        public static int DefaultPinRetries = 15;
        public static int DefaultRecheckAccessOfflineGraceperiodMinutes = 720;
        public static int DefaultRecheckAccessTimeoutMinutes = 30;
        public static int DefaultOfflineWipeIntervalDays = 1;

        public const string IntuneAndroidPolicy = "IntuneAndroidPolicy";
        public const string IntuneiOSPolicy = "IntuneiOSPolicy";
        public const string PlatformTypeQuery = "platform eq '{0}'";
    }
}
