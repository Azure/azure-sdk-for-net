// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class IProxiedOperationResultTests
{
    [Test]
    public void Interface_HasOriginalProperty()
    {
        var interfaceType = typeof(IProxiedOperationResult);
        var originalProperty = interfaceType.GetProperty("Original");
        
        Assert.IsNotNull(originalProperty);
        Assert.AreEqual(typeof(object), originalProperty.PropertyType);
        Assert.IsTrue(originalProperty.CanRead);
        Assert.IsFalse(originalProperty.CanWrite);
    }

    [Test]
    public void Interface_IsPublic()
    {
        var interfaceType = typeof(IProxiedOperationResult);
        
        Assert.IsTrue(interfaceType.IsPublic);
        Assert.IsTrue(interfaceType.IsInterface);
    }

    [Test]
    public void Implementation_CanProvideOriginal()
    {
        var originalOperation = new MockOperationResult();
        var proxiedOperation = new MockProxiedOperationResult(originalOperation);
        
        Assert.AreSame(originalOperation, proxiedOperation.Original);
    }

    [Test]
    public void Implementation_WithNullOriginal_AllowsNull()
    {
        var proxiedOperation = new MockProxiedOperationResult(null);
        
        Assert.IsNull(proxiedOperation.Original);
    }

    [Test]
    public void Interface_CanBeImplementedByMultipleTypes()
    {
        var operation1 = new MockProxiedOperationResult(new MockOperationResult());
        var operation2 = new AnotherMockProxiedOperationResult(new MockOperationResult());
        
        Assert.IsInstanceOf<IProxiedOperationResult>(operation1);
        Assert.IsInstanceOf<IProxiedOperationResult>(operation2);
    }

    [Test]
    public void Original_Property_IsReadOnly()
    {
        var interfaceType = typeof(IProxiedOperationResult);
        var originalProperty = interfaceType.GetProperty("Original");
        
        Assert.IsTrue(originalProperty.CanRead);
        Assert.IsFalse(originalProperty.CanWrite);
        Assert.IsNull(originalProperty.SetMethod);
        Assert.IsNotNull(originalProperty.GetMethod);
    }

    [Test]
    public void Interface_HasOnlyOriginalMember()
    {
        var interfaceType = typeof(IProxiedOperationResult);
        var members = interfaceType.GetMembers();
        
        // Should have only the Original property getter
        Assert.AreEqual(2, members.Length); // Property and its getter method
        Assert.IsTrue(Array.Exists(members, m => m.Name == "Original"));
        Assert.IsTrue(Array.Exists(members, m => m.Name == "get_Original"));
    }

    [Test]
    public void Interface_CanBeCastFromImplementation()
    {
        var originalOperation = new MockOperationResult();
        var proxiedOperation = new MockProxiedOperationResult(originalOperation);
        
        IProxiedOperationResult interfaceRef = proxiedOperation;
        
        Assert.IsNotNull(interfaceRef);
        Assert.AreSame(originalOperation, interfaceRef.Original);
    }

    [Test]
    public void Interface_DifferentFromIProxiedClient()
    {
        var clientInterface = typeof(IProxiedClient);
        var operationInterface = typeof(IProxiedOperationResult);
        
        Assert.AreNotEqual(clientInterface, operationInterface);
        Assert.IsFalse(clientInterface.IsAssignableFrom(operationInterface));
        Assert.IsFalse(operationInterface.IsAssignableFrom(clientInterface));
    }

    // Helper classes for testing
    public class MockOperationResult
    {
        public bool HasCompleted => true;
        public string Status => "Completed";
    }

    public class MockProxiedOperationResult : IProxiedOperationResult
    {
        public object Original { get; }
        
        public MockProxiedOperationResult(object original)
        {
            Original = original;
        }
    }

    public class AnotherMockProxiedOperationResult : IProxiedOperationResult
    {
        private readonly object _original;
        
        public object Original => _original;
        
        public AnotherMockProxiedOperationResult(object original)
        {
            _original = original;
        }
    }
}
