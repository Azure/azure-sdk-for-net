// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("GetTestRunsAsync", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestRuns", typeof(string), typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(string), typeof(int?), typeof(RequestContext))]
    public partial class LoadTestRunClient
    {
    }
}
