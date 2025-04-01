// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("GetTestsAsync", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTests", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTestsAsync", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTests", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfiles", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfilesAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(RequestContext))]
    [CodeGenSuppress("GetTestProfiles", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    [CodeGenSuppress("GetTestProfilesAsync", typeof(int?), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(IEnumerable<string>), typeof(IEnumerable<string>), typeof(CancellationToken))]
    public partial class LoadTestAdministrationClient
    {
    }
}
