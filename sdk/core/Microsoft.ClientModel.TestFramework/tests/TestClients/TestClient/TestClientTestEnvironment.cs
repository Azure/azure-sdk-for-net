// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.ClientModel.TestFramework.Tests;

public class TestClientTestEnvironment : TestEnvironment
{
    public override Dictionary<string, string> ParseEnvironmentFile() => [];

    public override Task WaitForEnvironmentAsync() => Task.CompletedTask;
}
