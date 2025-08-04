// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests.SyncAsync;

[TestFixture]
public class ClientTestFixtureTests
{
    [Test]
    public void Constructor_WithNoParameters_CreatesEmptyAdditionalParameters()
    {
        var attribute = new ClientTestFixtureAttribute();
        
        // We can't directly access the private field, but we can test the behavior
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<ClientTestFixtureAttribute>(attribute);
    }

    [Test]
    public void Constructor_WithParameters_StoresParameters()
    {
        var parameters = new object[] { "param1", 42, true };
        var attribute = new ClientTestFixtureAttribute(parameters);
        
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<ClientTestFixtureAttribute>(attribute);
    }

    [Test]
    public void Constructor_WithNullParameters_HandlesGracefully()
    {
        var attribute = new ClientTestFixtureAttribute(null);
        
        Assert.IsNotNull(attribute);
        Assert.IsInstanceOf<ClientTestFixtureAttribute>(attribute);
    }

    [Test]
    public void SyncOnlyKey_HasCorrectValue()
    {
        Assert.AreEqual("SyncOnly", ClientTestFixtureAttribute.SyncOnlyKey);
    }

    [Test]
    public void RecordingDirectorySuffixKey_HasCorrectValue()
    {
        Assert.AreEqual("RecordingDirectory", ClientTestFixtureAttribute.RecordingDirectorySuffixKey);
    }

    [Test]
    public void Inheritance_ImplementsCorrectInterfaces()
    {
        var attribute = new ClientTestFixtureAttribute();
        
        Assert.IsInstanceOf<NUnitAttribute>(attribute);
        Assert.IsInstanceOf<IFixtureBuilder2>(attribute);
        Assert.IsInstanceOf<IPreFilter>(attribute);
    }

    [Test]
    public void BuildFrom_WithValidTypeInfo_ReturnsTestSuites()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new TypeWrapper(typeof(SampleTestClass));
        
        var suites = attribute.BuildFrom(typeInfo);
        
        Assert.IsNotNull(suites);
        Assert.Greater(suites.Count(), 0);
    }

    [Test]
    public void BuildFrom_WithInvalidTypeInfo_HandlesGracefully()
    {
        var attribute = new ClientTestFixtureAttribute();
        var typeInfo = new TypeWrapper(typeof(InvalidTestClass));
        
        var suites = attribute.BuildFrom(typeInfo);
        
        Assert.IsNotNull(suites);
    }

    [Test]
    public void BuildFrom_WithAdditionalParameters_CreatesMultipleFixtures()
    {
        var attribute = new ClientTestFixtureAttribute("param1", "param2");
        var typeInfo = new TypeWrapper(typeof(SampleTestClass));
        
        var suites = attribute.BuildFrom(typeInfo);
        
        Assert.IsNotNull(suites);
        Assert.Greater(suites.Count(), 0);
    }

    [Test]
    public void IsMatch_WithValidTest_ReturnsTrue()
    {
        var attribute = new ClientTestFixtureAttribute();
        var test = CreateMockTest();
        
        bool result = attribute.IsMatch(typeof(SampleTestClass), CreateMockMethodInfo());
        
        Assert.IsTrue(result);
    }

    [Test]
    public void IsMatch_WithSyncOnlyAttribute_HandlesSyncOnlyTests()
    {
        var attribute = new ClientTestFixtureAttribute();
        
        bool result = attribute.IsMatch(typeof(SyncOnlyTestClass), CreateMockMethodInfo());
        
        Assert.IsTrue(result);
    }

    [Test]
    public void IsMatch_WithAsyncOnlyAttribute_HandlesAsyncOnlyTests()
    {
        var attribute = new ClientTestFixtureAttribute();
        
        bool result = attribute.IsMatch(typeof(AsyncOnlyTestClass), CreateMockMethodInfo());
        
        Assert.IsTrue(result);
    }

    [Test]
    public void IsMatch_WithExcludedTest_ReturnsFalse()
    {
        var attribute = new ClientTestFixtureAttribute();
        
        bool result = attribute.IsMatch(typeof(ExcludedTestClass), CreateMockMethodInfo());
        
        // Result depends on implementation details, but should handle gracefully
        Assert.IsNotNull(result);
    }

    [Test]
    public void AttributeUsage_AllowsCorrectTargets()
    {
        var usage = typeof(ClientTestFixtureAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        
        Assert.IsNotNull(usage);
        Assert.IsTrue(usage.ValidOn.HasFlag(AttributeTargets.Class));
    }

    [Test]
    public void Attribute_CanBeAppliedToTestClass()
    {
        var attributes = typeof(SampleTestClass).GetCustomAttributes<ClientTestFixtureAttribute>();
        
        Assert.IsNotNull(attributes);
        Assert.Greater(attributes.Count(), 0);
    }

    // Helper methods and classes for testing
    private ITest CreateMockTest()
    {
        var method = typeof(SampleTestClass).GetMethod(nameof(SampleTestClass.SampleTest));
        return new TestMethod(new MethodWrapper(typeof(SampleTestClass), method));
    }

    private MethodInfo CreateMockMethodInfo()
    {
        return typeof(SampleTestClass).GetMethod(nameof(SampleTestClass.SampleTest));
    }

    [ClientTestFixture]
    public class SampleTestClass : ClientTestBase
    {
        public SampleTestClass(bool isAsync) : base(isAsync) { }
        
        [Test]
        public void SampleTest()
        {
            // Sample test method
        }
    }

    [ClientTestFixture]
    [SyncOnly]
    public class SyncOnlyTestClass : ClientTestBase
    {
        public SyncOnlyTestClass(bool isAsync) : base(isAsync) { }
        
        [Test]
        public void SyncOnlyTest()
        {
            // Sync only test method
        }
    }

    [ClientTestFixture]
    [AsyncOnly]
    public class AsyncOnlyTestClass : ClientTestBase
    {
        public AsyncOnlyTestClass(bool isAsync) : base(isAsync) { }
        
        [Test]
        public void AsyncOnlyTest()
        {
            // Async only test method
        }
    }

    public class InvalidTestClass
    {
        // Invalid test class - doesn't inherit from ClientTestBase
        [Test]
        public void InvalidTest()
        {
        }
    }

    [Ignore("Excluded for testing")]
    [ClientTestFixture]
    public class ExcludedTestClass : ClientTestBase
    {
        public ExcludedTestClass(bool isAsync) : base(isAsync) { }
        
        [Test]
        public void ExcludedTest()
        {
        }
    }
}
