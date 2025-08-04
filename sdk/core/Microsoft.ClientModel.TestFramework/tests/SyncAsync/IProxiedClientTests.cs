// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class IProxiedClientTests
{
    [Test]
    public void Interface_HasOriginalProperty()
    {
        var interfaceType = typeof(IProxiedClient);
        var originalProperty = interfaceType.GetProperty("Original");
        
        Assert.IsNotNull(originalProperty);
        Assert.AreEqual(typeof(object), originalProperty.PropertyType);
        Assert.IsTrue(originalProperty.CanRead);
        Assert.IsFalse(originalProperty.CanWrite);
    }

    [Test]
    public void Interface_IsPublic()
    {
        var interfaceType = typeof(IProxiedClient);
        
        Assert.IsTrue(interfaceType.IsPublic);
        Assert.IsTrue(interfaceType.IsInterface);
    }

    [Test]
    public void Implementation_CanProvideOriginal()
    {
        var originalClient = new MockClient();
        var proxiedClient = new MockProxiedClient(originalClient);
        
        Assert.AreSame(originalClient, proxiedClient.Original);
    }

    [Test]
    public void Implementation_WithNullOriginal_AllowsNull()
    {
        var proxiedClient = new MockProxiedClient(null);
        
        Assert.IsNull(proxiedClient.Original);
    }

    [Test]
    public void Interface_CanBeImplementedByMultipleTypes()
    {
        var client1 = new MockProxiedClient(new MockClient());
        var client2 = new AnotherMockProxiedClient(new MockClient());
        
        Assert.IsInstanceOf<IProxiedClient>(client1);
        Assert.IsInstanceOf<IProxiedClient>(client2);
    }

    [Test]
    public void Original_Property_IsReadOnly()
    {
        var interfaceType = typeof(IProxiedClient);
        var originalProperty = interfaceType.GetProperty("Original");
        
        Assert.IsTrue(originalProperty.CanRead);
        Assert.IsFalse(originalProperty.CanWrite);
        Assert.IsNull(originalProperty.SetMethod);
        Assert.IsNotNull(originalProperty.GetMethod);
    }

    [Test]
    public void Interface_HasOnlyOriginalMember()
    {
        var interfaceType = typeof(IProxiedClient);
        var members = interfaceType.GetMembers();
        
        // Should have only the Original property getter
        Assert.AreEqual(2, members.Length); // Property and its getter method
        Assert.IsTrue(Array.Exists(members, m => m.Name == "Original"));
        Assert.IsTrue(Array.Exists(members, m => m.Name == "get_Original"));
    }

    [Test]
    public void Interface_CanBeCastFromImplementation()
    {
        var originalClient = new MockClient();
        var proxiedClient = new MockProxiedClient(originalClient);
        
        IProxiedClient interfaceRef = proxiedClient;
        
        Assert.IsNotNull(interfaceRef);
        Assert.AreSame(originalClient, interfaceRef.Original);
    }

    // Helper classes for testing
    public class MockClient
    {
        public string Value => "mock";
    }

    public class MockProxiedClient : IProxiedClient
    {
        public object Original { get; }
        
        public MockProxiedClient(object original)
        {
            Original = original;
        }
    }

    public class AnotherMockProxiedClient : IProxiedClient
    {
        private readonly object _original;
        
        public object Original => _original;
        
        public AnotherMockProxiedClient(object original)
        {
            _original = original;
        }
    }
}
