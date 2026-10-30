// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T008: Reflection test asserting the ResponseStreamEvent base type cannot be constructed directly.
/// The concrete event subtypes are owned by the OpenAI SDK, which constructs them through factory
/// methods, so their constructors are not asserted here.
/// </summary>
public class PublicConstructorEventTests
{
    [Test]
    public void AbstractResponseStreamEvent_HasNoPublicConstructors()
    {
        // OpenAI models the event hierarchy with a concrete-but-uninstantiable base.
        var publicCtors = typeof(ResponseStreamEvent).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }
}
