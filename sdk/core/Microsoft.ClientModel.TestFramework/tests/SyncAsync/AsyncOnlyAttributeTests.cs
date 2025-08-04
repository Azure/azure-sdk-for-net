// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class AsyncOnlyAttributeTests
{
    [Test]
    public void Constructor_CreatesValidInstance()
    {
        var attribute = new AsyncOnlyAttribute();
        
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<AsyncOnlyAttribute>(attribute);
    }

    [Test]
    public void Inheritance_ExtendsNUnitAttribute()
    {
        var attribute = new AsyncOnlyAttribute();
        
        Assert.IsInstanceOf<NUnitAttribute>(attribute);
    }

    [Test]
    public void AttributeUsage_AllowsMethodClassAndAssembly()
    {
        var usage = typeof(AsyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        
        Assert.IsNotNull(usage);
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Method));
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Class));
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Assembly));
        Assert.IsFalse(usage.AllowMultiple);
        Assert.IsTrue(usage.Inherited);
    }

    [Test]
    public void Attribute_CanBeAppliedToMethod()
    {
        var method = typeof(TestClassWithAsyncOnlyMethod).GetMethod(nameof(TestClassWithAsyncOnlyMethod.AsyncOnlyMethod));
        var attribute = method.GetCustomAttribute<AsyncOnlyAttribute>();
        
        Assert.IsNotNull(attribute);
    }

    [Test]
    public void Attribute_CanBeAppliedToClass()
    {
        var attribute = typeof(AsyncOnlyTestClass).GetCustomAttribute<AsyncOnlyAttribute>();
        
        Assert.IsNotNull(attribute);
    }

    [Test]
    public void AllowMultiple_IsFalse()
    {
        var usage = typeof(AsyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        
        Assert.IsFalse(usage.AllowMultiple);
    }

    [Test]
    public void Inherited_IsTrue()
    {
        var usage = typeof(AsyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        
        Assert.IsTrue(usage.Inherited);
    }

    [Test]
    public void Attribute_InheritsToSubclass()
    {
        var baseAttribute = typeof(AsyncOnlyTestClass).GetCustomAttribute<AsyncOnlyAttribute>();
        var derivedAttribute = typeof(DerivedAsyncOnlyTestClass).GetCustomAttribute<AsyncOnlyAttribute>(inherit: true);
        
        Assert.IsNotNull(baseAttribute);
        Assert.IsNotNull(derivedAttribute);
    }

    [Test]
    public void Multiple_AsyncOnlyAttributes_NotAllowed()
    {
        // Since AllowMultiple is false, applying multiple attributes should not be possible
        // This is enforced at compile time, so we just verify the AttributeUsage setting
        var usage = typeof(AsyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsFalse(usage.AllowMultiple);
    }

    // Helper classes for testing
    public class TestClassWithAsyncOnlyMethod
    {
        [AsyncOnly]
        public void AsyncOnlyMethod()
        {
            // Test method with AsyncOnly attribute
        }

        public void RegularMethod()
        {
            // Regular method without attribute
        }
    }

    [AsyncOnly]
    public class AsyncOnlyTestClass
    {
        public void TestMethod()
        {
            // Method in async-only class
        }
    }

    public class DerivedAsyncOnlyTestClass : AsyncOnlyTestClass
    {
        public void DerivedMethod()
        {
            // Method in derived class should inherit AsyncOnly attribute
        }
    }
}
