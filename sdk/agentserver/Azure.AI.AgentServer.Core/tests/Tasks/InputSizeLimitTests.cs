// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.AI.AgentServer.Core.Tasks;
using Azure.AI.AgentServer.Core.Tasks.Serialization;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Core.Tests.Tasks;

[TestFixture]
public sealed class InputSizeLimitTests
{
    [Test]
    public void OversizedInputThrowsBeforeNetwork()
    {
        using var host = TaskTestHost.Create();
        bool handlerRan = false;
        host.Builder.AddTask<string, int>("big", (ctx, ct) =>
        {
            handlerRan = true;
            return Task.FromResult(ctx.Input.Length);
        });

        // Exceed the per-attachment ceiling (10 MiB) so the serialized input is rejected up front.
        string huge = new string('x', AttachmentPromoter.MaxAttachmentValueBytes + (1024 * 1024));

        Assert.ThrowsAsync<InputTooLargeException>(async () =>
            await host.Invoker.RunAsync<string, int>("big", huge));
        Assert.That(handlerRan, Is.False, "handler must not run when input is rejected");
    }
}
