// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.TypeSpec;
using System.TypeSpec.Tests;
using Xunit;

namespace System.Tests;

public class DemoClientTests
{
    [Fact]
    public void DemoClientDoesNotExposeAzureTypes()
    {
        var client = new DemoClient();
        Result<FooModel> result = client.GetSetting();
    }
}
