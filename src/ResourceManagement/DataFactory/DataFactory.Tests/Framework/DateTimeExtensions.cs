// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 
using System;

namespace DataFactory.Tests.Framework
{
    public static class DateTimeExtentions
    {
        /// <summary>
        /// When converting a time to Utc and there is no timezone information, assume 
        /// the time is Utc time by default for api-version greater or equal to 2015-01-01-preview.
        /// For older clients, the behavior is the same as call ToUniversalTime(), i.e. assume
        /// user input is Local time before converting to Utc time.
        /// </summary>
        /// <param name="dateTime">A date time to be converted to Utc time.</param>
        /// <param name="apiVersion">The api version of the incoming client.</param>
        /// <returns></returns>
        public static DateTime EnforceUtcZone(this DateTime dateTime, string apiVersion = null)
        {
            return dateTime.Kind == DateTimeKind.Unspecified
                       ? new DateTime(dateTime.Ticks, DateTimeKind.Utc)
                       : dateTime.ToUniversalTime();
        }
    }
}
