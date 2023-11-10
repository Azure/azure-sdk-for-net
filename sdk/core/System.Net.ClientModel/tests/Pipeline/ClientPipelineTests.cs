// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.Net.ClientModel.Core;

namespace System.Net.ClientModel.Tests;

public class ClientPipelineTests
{
    [Test]
    public void CannotReusePipelineAcrossClients()
    {
        ClientA clientA = new();
        ClientB clientB = new();

        PipelineOptions options = new PipelineOptions();
        ClientPipeline pipeline = ClientPipeline.GetPipeline(clientA, options);

        Assert.Throws<NotSupportedException>(() => { ClientPipeline.GetPipeline(clientB, options); });
    }

    #region Helpers
    private class ClientA { }
    private class ClientB { }
    #endregion
}
