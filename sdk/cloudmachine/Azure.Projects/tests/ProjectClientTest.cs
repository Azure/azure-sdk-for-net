// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using Azure.Core.TestFramework;
using Azure.Projects.Ofx;
using NUnit.Framework;

namespace Azure.Projects.Tests;

public partial class ProjectClientTests : SamplesBase<AzureProjectsTestEnvironment>
{
    [Test]
    public void EmptyProject()
    {
        ProjectInfrastructure infrastructure = new();
        ProjectClient project = new();
    }

    [Test]
    public void CloudMachineProject()
    {
        ProjectInfrastructure infrastructure = new();
        infrastructure.AddFeature(new OfxFeatures());

        OfxClient project = new();
    }
}
