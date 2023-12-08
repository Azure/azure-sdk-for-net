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

using System.Net;

namespace OpenTelemetry.Instrumentation.Http.Implementation;

internal static class TelemetryHelper
{
    public static readonly (object, string)[] BoxedStatusCodes;

    static TelemetryHelper()
    {
        BoxedStatusCodes = new (object, string)[500];
        for (int i = 0, c = 100; i < BoxedStatusCodes.Length; i++, c++)
        {
            BoxedStatusCodes[i] = (c, c.ToString());
        }
    }

    public static object GetBoxedStatusCode(HttpStatusCode statusCode)
    {
        int intStatusCode = (int)statusCode;
        if (intStatusCode >= 100 && intStatusCode < 600)
        {
            return BoxedStatusCodes[intStatusCode - 100].Item1;
        }

        return statusCode;
    }

    public static string GetStatusCodeString(HttpStatusCode statusCode)
    {
        int intStatusCode = (int)statusCode;
        if (intStatusCode >= 100 && intStatusCode < 600)
        {
            return BoxedStatusCodes[intStatusCode - 100].Item2;
        }

        return statusCode.ToString();
    }
}
