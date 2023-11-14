// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using NUnit.Framework;
using System.ClientModel.Primitives;

namespace System.ClientModel.Tests;

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

    // Test that users can't pass a list of policies where the last policy is not a transport

    // Tests for invalid inputs to all public methods

    // Tests that the correct pipeline is constructed for different variants of PipelineOptions

    // Tests that the correct pipeline is constructed for different variants of RequestOptions

    // Tests that pipeline is frozen as expected by the various GetPipeline methods

    // TODO: Test Pipeline.CreateMessage

    // TODO: Test Pipeline.Send and Pipeline.SendAsync

    #region Helpers
    private class ClientA { }
    private class ClientB { }
    #endregion
}
