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
