// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;
using Azure.Core.TestFramework;

using NUnit.Framework;

namespace Azure.Projects.Tests;

public partial class ProjectClientTests : SamplesBase<AzureProjectsTestEnvironment>
{
    [Test]
    public void OfxProject()
    {
        Assert.IsTrue(false);
        ProjectInfrastructure infrastructure = new();

        ProjectClient client = new();
    }
}
