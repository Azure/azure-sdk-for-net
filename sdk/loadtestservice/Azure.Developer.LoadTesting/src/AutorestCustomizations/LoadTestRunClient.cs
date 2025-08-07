// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("GetTestRunsAsync", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestRuns", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestRunsAsync", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestRuns", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfileRuns", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfileRunsAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfileRuns", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfileRunsAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    public partial class LoadTestRunClient
    {
    }
}
