// <copyright file="ActivityInstrumentationHelper.cs" company="OpenTelemetry Authors">
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

using System.Diagnostics;
#pragma warning restore IDE0005

namespace OpenTelemetry.Instrumentation;

internal static class ActivityInstrumentationHelper
{
    internal static readonly Action<Activity, ActivityKind> SetKindProperty = CreateActivityKindSetter();
    internal static readonly Action<Activity, ActivitySource> SetActivitySourceProperty = CreateActivitySourceSetter();

    private static Action<Activity, ActivitySource> CreateActivitySourceSetter()
    {
        return (Action<Activity, ActivitySource>)typeof(Activity).GetProperty("Source")
            .SetMethod.CreateDelegate(typeof(Action<Activity, ActivitySource>));
    }

    private static Action<Activity, ActivityKind> CreateActivityKindSetter()
    {
        return (Action<Activity, ActivityKind>)typeof(Activity).GetProperty("Kind")
            .SetMethod.CreateDelegate(typeof(Action<Activity, ActivityKind>));
    }
}
