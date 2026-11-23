// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Reflection;
using Azure.AI.AgentServer.Responses.Models;

namespace Azure.AI.AgentServer.Responses.Tests.PublicApi;

/// <summary>
/// T009: Reflection tests asserting ResponseObject and CreateResponse have public constructors,
/// and that the OutputItem base cannot be constructed directly. Item, content and
/// event types owned by the OpenAI SDK are constructed through its factory methods, so their
/// constructors are not asserted here.
/// </summary>
public class PublicConstructorModelTests
{
    // ========================================
    // ResponseObject and CreateResponse
    // ========================================

    [Test]
    public void Response_HasAtLeastOnePublicConstructor()
    {
        var publicCtors = typeof(ResponseObject).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True, "Response should have at least one public constructor.");
    }

    [Test]
    public void CreateResponse_HasAtLeastOnePublicConstructor()
    {
        var publicCtors = typeof(CreateResponse).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors.Length > 0, Is.True, "CreateResponse should have at least one public constructor.");
    }

    // ========================================
    // Base item type must NOT be constructable
    // ========================================

    [Test]
    public void OutputItem_HasNoPublicConstructors()
    {
        // OpenAI models the item hierarchy with a concrete-but-uninstantiable base.
        var publicCtors = typeof(OutputItem).GetConstructors(BindingFlags.Public | BindingFlags.Instance);
        Assert.That(publicCtors, Is.Empty);
    }
}
