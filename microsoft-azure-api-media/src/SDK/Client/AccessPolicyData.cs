// Copyright 2012 Microsoft Corporation
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Data.Services.Common;

namespace Microsoft.WindowsAzure.MediaServices.Client
{
    [DataServiceKey("Id")]
    partial class AccessPolicyData
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        public double DurationInMinutes { get; set; }

        TimeSpan IAccessPolicy.Duration
        {
            get
            {
                return GetExposedDuration(DurationInMinutes);
            }
        }

        private static TimeSpan GetExposedDuration(double duration)
        {
            return TimeSpan.FromMinutes(duration);
        }

        internal static double GetInternalDuration(TimeSpan value)
        {
            return value.TotalMinutes;
        }

        private static AccessPermissions GetExposedPermissions(int permissions)
        {
            return (AccessPermissions)permissions;
        }

        internal static int GetInternalPermissions(AccessPermissions value)
        {
            return (int)value;
        }
    }
}
