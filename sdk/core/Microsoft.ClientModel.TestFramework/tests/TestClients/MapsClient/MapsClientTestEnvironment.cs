// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class MapsClientTestEnvironment : TestEnvironment
{
    public override Dictionary<string, string> ParseEnvironmentFile() => new()
    {
        { "MAPS_API_KEY", Environment.GetEnvironmentVariable("MAPS_API_KEY") ?? "api-key" }
    };

    public override Task WaitForEnvironmentAsync() => Task.CompletedTask;

    public string ApiKey => GetRecordedVariable("MAPS_API_KEY", options => options.IsSecret("api-key"));
}
