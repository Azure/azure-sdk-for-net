// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using System;
using System.Reflection;
namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;
[TestFixture]
public class SyncOnlyAttributeTests
{
    [Test]
    public void Constructor_CreatesValidInstance()
    {
        var attribute = new SyncOnlyAttribute();
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<SyncOnlyAttribute>(attribute);
    }
    [Test]
    public void Inheritance_ExtendsNUnitAttribute()
    {
        var attribute = new SyncOnlyAttribute();
        Assert.IsInstanceOf<NUnitAttribute>(attribute);
    }
    [Test]
    public void AttributeUsage_AllowsMethodClassAndAssembly()
    {
        var usage = typeof(SyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
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
        var method = typeof(TestClassWithSyncOnlyMethod).GetMethod(nameof(TestClassWithSyncOnlyMethod.SyncOnlyMethod));
        var attribute = method.GetCustomAttribute<SyncOnlyAttribute>();
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void Attribute_CanBeAppliedToClass()
    {
        var attribute = typeof(SyncOnlyTestClass).GetCustomAttribute<SyncOnlyAttribute>();
        Assert.IsNotNull(attribute);
    }
    [Test]
    public void AllowMultiple_IsFalse()
    {
        var usage = typeof(SyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsFalse(usage.AllowMultiple);
    }
    [Test]
    public void Inherited_IsTrue()
    {
        var usage = typeof(SyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsTrue(usage.Inherited);
    }
    [Test]
    public void Attribute_InheritsToSubclass()
    {
        var baseAttribute = typeof(SyncOnlyTestClass).GetCustomAttribute<SyncOnlyAttribute>();
        var derivedAttribute = typeof(DerivedSyncOnlyTestClass).GetCustomAttribute<SyncOnlyAttribute>(inherit: true);
        Assert.IsNotNull(baseAttribute);
        Assert.IsNotNull(derivedAttribute);
    }
    [Test]
    public void Multiple_SyncOnlyAttributes_NotAllowed()
    {
        // Since AllowMultiple is false, applying multiple attributes should not be possible
        // This is enforced at compile time, so we just verify the AttributeUsage setting
        var usage = typeof(SyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsFalse(usage.AllowMultiple);
    }
    [Test]
    public void SyncOnly_And_AsyncOnly_AreCompatible()
    {
        // Both attributes should be able to exist in the same assembly without conflicts
        var syncUsage = typeof(SyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        var asyncUsage = typeof(AsyncOnlyAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsNotNull(syncUsage);
        Assert.IsNotNull(asyncUsage);
        Assert.AreEqual(syncUsage.ValidOn, asyncUsage.ValidOn);
        Assert.AreEqual(syncUsage.AllowMultiple, asyncUsage.AllowMultiple);
        Assert.AreEqual(syncUsage.Inherited, asyncUsage.Inherited);
    }
    // Helper classes for testing
    public class TestClassWithSyncOnlyMethod
    {
        [SyncOnly]
        public void SyncOnlyMethod()
        {
            // Test method with SyncOnly attribute
        }
        public void RegularMethod()
        {
            // Regular method without attribute
        }
    }
    [SyncOnly]
    public class SyncOnlyTestClass
    {
        public void TestMethod()
        {
            // Method in sync-only class
        }
    }
    public class DerivedSyncOnlyTestClass : SyncOnlyTestClass
    {
        public void DerivedMethod()
        {
            // Method in derived class should inherit SyncOnly attribute
        }
    }
}
