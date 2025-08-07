// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;
using System;
using System.Reflection;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RetryOnErrorAttributeTests
{
    [Test]
    public void RetryOnErrorAttribute_IsAbstract()
    {
        var type = typeof(RetryOnErrorAttribute);
        Assert.IsTrue(type.IsAbstract);
    }

    [Test]
    public void Inheritance_ExtendsNUnitAttribute()
    {
        var type = typeof(RetryOnErrorAttribute);
        Assert.IsTrue(typeof(NUnitAttribute).IsAssignableFrom(type));
    }

    [Test]
    public void Interface_ImplementsIRepeatTest()
    {
        var type = typeof(RetryOnErrorAttribute);
        Assert.IsTrue(typeof(IRepeatTest).IsAssignableFrom(type));
    }

    [Test]
    public void AttributeUsage_AllowsMethodOnly()
    {
        var usage = typeof(RetryOnErrorAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsNotNull(usage);
        Assert.AreEqual(AttributeTargets.Method, usage.ValidOn);
        Assert.IsFalse(usage.AllowMultiple);
        Assert.IsFalse(usage.Inherited);
    }

    [Test]
    public void Constructor_IsProtected()
    {
        var type = typeof(RetryOnErrorAttribute);
        var constructors = type.GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
        Assert.Greater(constructors.Length, 0);
        Assert.IsTrue(Array.Exists(constructors, c => c.IsFamily)); // Protected constructor exists
    }

    [Test]
    public void Wrap_Method_Exists()
    {
        var type = typeof(RetryOnErrorAttribute);
        var wrapMethod = type.GetMethod("Wrap", new[] { typeof(TestCommand) });
        Assert.IsNotNull(wrapMethod);
        Assert.AreEqual(typeof(TestCommand), wrapMethod.ReturnType);
    }

    [Test]
    public void ConcreteImplementation_CanBeCreated()
    {
        var concreteAttribute = new TestRetryOnErrorAttribute(3, context => true);
        Assert.IsNotNull(concreteAttribute);
        Assert.IsInstanceOf<RetryOnErrorAttribute>(concreteAttribute);
    }

    [Test]
    public void Wrap_WithValidCommand_ReturnsWrappedCommand()
    {
        var concreteAttribute = new TestRetryOnErrorAttribute(3, context => true);
        var originalCommand = new MockTestCommand();
        var wrappedCommand = concreteAttribute.Wrap(originalCommand);
        Assert.IsNotNull(wrappedCommand);
        Assert.AreNotSame(originalCommand, wrappedCommand);
    }

    [Test]
    public void Wrap_ReturnsRetryOnErrorCommand()
    {
        var concreteAttribute = new TestRetryOnErrorAttribute(2, context => false);
        var originalCommand = new MockTestCommand();
        var wrappedCommand = concreteAttribute.Wrap(originalCommand);
        Assert.IsNotNull(wrappedCommand);
        // Verify it's the correct type by checking the class name
        Assert.That(wrappedCommand.GetType().Name, Contains.Substring("RetryOnErrorCommand"));
    }

    [Test]
    public void Constructor_WithTryCount_AcceptsValidValues()
    {
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(1, context => true));
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(5, context => true));
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(10, context => true));
    }

    [Test]
    public void Constructor_WithShouldRetryFunction_AcceptsValidFunctions()
    {
        Func<TestExecutionContext, bool> alwaysRetry = context => true;
        Func<TestExecutionContext, bool> neverRetry = context => false;
        Func<TestExecutionContext, bool> conditionalRetry = context => context.CurrentResult?.ResultState.Status == TestStatus.Failed;
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(3, alwaysRetry));
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(3, neverRetry));
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(3, conditionalRetry));
    }

    [Test]
    public void Constructor_WithNullShouldRetry_AllowsNull()
    {
        Assert.DoesNotThrow(() => new TestRetryOnErrorAttribute(3, null));
    }

    [Test]
    public void RetryOnErrorCommand_IsInternalClass()
    {
        // The RetryOnErrorCommand class should be internal
        var assembly = typeof(RetryOnErrorAttribute).Assembly;
        var commandType = assembly.GetType("Microsoft.ClientModel.TestFramework.RetryOnErrorAttribute+RetryOnErrorCommand");
        Assert.IsNotNull(commandType);
        Assert.IsTrue(commandType.IsNotPublic); // Internal types are not public
    }

    [Test]
    public void Attribute_CanBeAppliedToMethod()
    {
        var method = typeof(TestClassWithRetryOnError).GetMethod(nameof(TestClassWithRetryOnError.RetriableMethod));
        // Since RetryOnErrorAttribute is abstract and can't be used directly,
        // we verify the method exists and can be annotated in principle
        Assert.IsNotNull(method);
        Assert.IsTrue(method.IsStatic);
    }

    [Test]
    public void AllowMultiple_IsFalse()
    {
        var usage = typeof(RetryOnErrorAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsFalse(usage.AllowMultiple);
    }

    [Test]
    public void Inherited_IsFalse()
    {
        var usage = typeof(RetryOnErrorAttribute).GetCustomAttribute<AttributeUsageAttribute>();
        Assert.IsFalse(usage.Inherited);
    }

    // Helper classes for testing
    public class TestRetryOnErrorAttribute : RetryOnErrorAttribute
    {
        public TestRetryOnErrorAttribute(int tryCount, Func<TestExecutionContext, bool> shouldRetry)
            : base(tryCount, shouldRetry)
        {
        }
    }

    public class MockTestCommand : TestCommand
    {
        public MockTestCommand() : base(new TestMethod(new MethodWrapper(typeof(RetryOnErrorAttributeTests), typeof(RetryOnErrorAttributeTests).GetMethod(nameof(MockTestMethod)))))
        {
        }
        public override TestResult Execute(TestExecutionContext context)
        {
            return context.CurrentResult ?? new TestCaseResult(Test as TestMethod);
        }
        public void MockTestMethod() { }
    }

    public class TestClassWithRetryOnError
    {
        // Since RetryOnErrorAttribute is abstract and takes a Func parameter,
        // we can't use it directly as an attribute. This is just for structural testing.
        public static void RetriableMethod()
        {
            // Method that would have retry on error attribute
        }
    }
}
