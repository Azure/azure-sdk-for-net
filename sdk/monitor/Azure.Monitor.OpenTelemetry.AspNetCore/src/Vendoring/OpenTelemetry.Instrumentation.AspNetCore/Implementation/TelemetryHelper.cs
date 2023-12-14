// <copyright file="TelemetryHelper.cs" company="OpenTelemetry Authors">
// Copyright The OpenTelemetry Authors
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>

namespace OpenTelemetry.Instrumentation.AspNetCore.Implementation;

internal static class TelemetryHelper
{
    public static readonly object[] BoxedStatusCodes;

    static TelemetryHelper()
    {
        BoxedStatusCodes = new object[500];
        for (int i = 0, c = 100; i < BoxedStatusCodes.Length; i++, c++)
        {
            BoxedStatusCodes[i] = c;
        }
    }

    public static object GetBoxedStatusCode(int statusCode)
    {
        if (statusCode >= 100 && statusCode < 600)
        {
            return BoxedStatusCodes[statusCode - 100];
        }

        return statusCode;
    }
}
