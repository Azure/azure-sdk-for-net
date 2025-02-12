// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using NUnit.Framework;

namespace Azure.CloudMachine.Tests;

public class E2ETests
{
    [Test]
    public void Foundry()
    {
        ProjectInfrastructure infra = new("cm0c420d2f21084ca");
        infra.AddFeature(new AIFoundry.AIFoundryFeature());
        infra.TryExecuteCommand(["-init"]);
    }
}
