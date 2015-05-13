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
//

using System;
using System.Globalization;

namespace Microsoft.Azure.Management.DataFactories
{
    // ToDo: In the Hyak generated code, DateTime in Uri does not support ISO8601 format by default.
    //       Remove this extension class once Hyak team has fixed the issue.    
    public static class DateTimeExtensions
    {
        public static string ConvertToISO8601DateTimeString(this DateTime date)
        {
            return date.ToString("o", CultureInfo.InvariantCulture);
        }
    }
}
