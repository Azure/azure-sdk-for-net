// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text;
using Azure.Core;

namespace Azure.Developer.LoadTesting
{
    [CodeGenSuppress("GetTestsAsync", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(RequestContext))]
    [CodeGenSuppress("GetTests", typeof(string), typeof(string), typeof(DateTimeOffset?), typeof(DateTimeOffset?), typeof(int?), typeof(RequestContext))]
    public partial class LoadTestAdministrationClient
    {
    }
}
