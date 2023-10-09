// <copyright file="HttpRequestMessageContextPropagation.cs" company="OpenTelemetry Authors">
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

#if NETFRAMEWORK
using System.Net.Http;
#endif

using System;
using System.Collections.Generic;
using System.Net.Http;

namespace OpenTelemetry.Instrumentation.Http
{
    internal static class HttpRequestMessageContextPropagation
    {
        internal static Func<HttpRequestMessage, string, IEnumerable<string>> HeaderValuesGetter => (request, name) =>
        {
            if (request.Headers.TryGetValues(name, out var values))
            {
                return values;
            }

            return null;
        };

        internal static Action<HttpRequestMessage, string, string> HeaderValueSetter => (request, name, value) =>
        {
            request.Headers.Remove(name);
            request.Headers.Add(name, value);
        };
    }
}
