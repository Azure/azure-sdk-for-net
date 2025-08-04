// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Microsoft.ClientModel.TestFramework.Tests.RecordedTests;

[TestFixture]
public class RecordedTestAttributeTests
{
    private class MockRecordedTestBase : RecordedTestBase
    {
        public MockRecordedTestBase(RecordedTestMode mode)
        {
            Mode = mode;
        }

        protected override void AddSanitizers()
        {
            // Mock implementation
        }
    }

    private class MockTestCommand : TestCommand
    {
        private readonly TestResult _result;

        public MockTestCommand(ITest test, TestResult result) : base(test)
        {
            _result = result;
        }

        public override TestResult Execute(TestExecutionContext context)
        {
            context.CurrentResult = _result;
            return _result;
        }
    }

    private class MockTest : ITest
    {
        public object? Fixture { get; set; }
        public ITest? Parent { get; set; }
        public string Name => "MockTest";
        public string FullName => "MockTest";
        public string ClassName => "MockTestClass";
        public string MethodName => "MockMethod";
        public ITypeInfo TypeInfo => throw new NotImplementedException();
        public IMethodInfo Method => throw new NotImplementedException();
        public RunState RunState { get; set; } = RunState.Runnable;
        public int TestCaseCount => 1;
        public IPropertyBag Properties => new PropertyBag();
        public bool IsSuite => false;
        public bool HasChildren => false;
        public IList<ITest> Tests => new List<ITest>();
        public object[] Arguments => Array.Empty<object>();
        public TNode AddToXml(TNode parentNode, bool recursive) => throw new NotImplementedException();
        public string Id { get; set; } = "1";
        public TNode ToXml(bool recursive) => throw new NotImplementedException();

        public TestResult MakeTestResult()
        {
            return new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(MockTest))));
        }
    }

    [Test]
    public void RecordedTestAttribute_InheritsFromTestAttribute()
    {
        // Arrange & Act
        var attribute = new RecordedTestAttribute();

        // Assert
        Assert.That(attribute, Is.InstanceOf<TestAttribute>());
        Assert.That(attribute, Is.InstanceOf<IWrapSetUpTearDown>());
    }

    [Test]
    public void Wrap_WithRecordedTestBaseFixture_ReturnsWrappedCommand()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest { Fixture = fixture };
        var originalCommand = new MockTestCommand(test, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithRecordedTestBaseFixture_ReturnsWrappedCommand)))));

        // Act
        var wrappedCommand = attribute.Wrap(originalCommand);

        // Assert
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
        Assert.That(wrappedCommand, Is.Not.Null);
    }

    [Test]
    public void Wrap_WithoutRecordedTestBaseFixture_ReturnsOriginalCommand()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();
        var test = new MockTest { Fixture = new object() }; // Not a RecordedTestBase
        var originalCommand = new MockTestCommand(test, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithoutRecordedTestBaseFixture_ReturnsOriginalCommand)))));

        // Act
        var wrappedCommand = attribute.Wrap(originalCommand);

        // Assert
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }

    [Test]
    public void Wrap_WithNullFixture_ReturnsOriginalCommand()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();
        var test = new MockTest { Fixture = null };
        var originalCommand = new MockTestCommand(test, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithNullFixture_ReturnsOriginalCommand)))));

        // Act
        var wrappedCommand = attribute.Wrap(originalCommand);

        // Assert
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }

    [Test]
    public void Wrap_WithParentFixture_FindsRecordedTestBase()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var parentTest = new MockTest { Fixture = fixture };
        var childTest = new MockTest { Fixture = null, Parent = parentTest };
        var originalCommand = new MockTestCommand(childTest, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithParentFixture_FindsRecordedTestBase)))));

        // Act
        var wrappedCommand = attribute.Wrap(originalCommand);

        // Assert
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }

    [Test]
    public void RecordedTestAttributeCommand_ExecutesInnerCommand()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest { Fixture = fixture };
        var expectedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_ExecutesInnerCommand))));
        expectedResult.SetResult(ResultState.Success);
        
        var innerCommand = new MockTestCommand(test, expectedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;

        // Act
        var result = wrappedCommand.Execute(context);

        // Assert
        Assert.That(result, Is.SameAs(expectedResult));
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Passed));
    }

    [Test]
    public void RecordedTestAttributeCommand_WithPassedTest_ReturnsOriginalResult()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest { Fixture = fixture };
        var passedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_WithPassedTest_ReturnsOriginalResult))));
        passedResult.SetResult(ResultState.Success);
        
        var innerCommand = new MockTestCommand(test, passedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;

        // Act
        var result = wrappedCommand.Execute(context);

        // Assert
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Passed));
    }

    [Test]
    public void RecordedTestAttributeCommand_WithSkippedTest_ReturnsOriginalResult()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest { Fixture = fixture };
        var skippedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_WithSkippedTest_ReturnsOriginalResult))));
        skippedResult.SetResult(ResultState.Skipped, "Test skipped");
        
        var innerCommand = new MockTestCommand(test, skippedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;

        // Act
        var result = wrappedCommand.Execute(context);

        // Assert
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Skipped));
    }

    [Test]
    public void RecordedTestAttributeCommand_WithFailedTestInLiveMode_ReturnsOriginalResult()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_WithFailedTestInLiveMode_ReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;

        // Act
        var result = wrappedCommand.Execute(context);

        // Assert
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
        Assert.That(result.Message, Is.EqualTo("Test failed"));
    }

    [Test]
    public void RecordedTestAttributeCommand_WithFailedTestInRecordMode_ReturnsOriginalResult()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var test = new MockTest { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_WithFailedTestInRecordMode_ReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;

        // Act
        var result = wrappedCommand.Execute(context);

        // Assert
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
        Assert.That(result.Message, Is.EqualTo("Test failed"));
    }

    [Test]
    public void RecordedTestAttributeCommand_CanBeCreatedWithDifferentModes()
    {
        // Arrange
        var liveFixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var recordFixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var playbackFixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        
        var liveTest = new MockTest { Fixture = liveFixture };
        var recordTest = new MockTest { Fixture = recordFixture };
        var playbackTest = new MockTest { Fixture = playbackFixture };
        
        var passedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_CanBeCreatedWithDifferentModes))));
        passedResult.SetResult(ResultState.Success);
        
        var attribute = new RecordedTestAttribute();

        // Act & Assert
        var liveCommand = attribute.Wrap(new MockTestCommand(liveTest, passedResult));
        var recordCommand = attribute.Wrap(new MockTestCommand(recordTest, passedResult));
        var playbackCommand = attribute.Wrap(new MockTestCommand(playbackTest, passedResult));

        Assert.That(liveCommand, Is.Not.Null);
        Assert.That(recordCommand, Is.Not.Null);
        Assert.That(playbackCommand, Is.Not.Null);
    }

    [Test]
    public void RecordedTestAttribute_HasCorrectAttributeUsage()
    {
        // Arrange
        var attributeUsage = typeof(RecordedTestAttribute)
            .GetCustomAttributes(typeof(AttributeUsageAttribute), false)
            .Cast<AttributeUsageAttribute>()
            .FirstOrDefault();

        // Assert
        Assert.That(attributeUsage, Is.Not.Null);
        Assert.That(attributeUsage.ValidOn, Is.EqualTo(AttributeTargets.Method));
    }

    [Test]
    public void RecordedTestAttribute_ImplementsRequiredInterfaces()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();

        // Assert
        Assert.That(attribute, Is.InstanceOf<TestAttribute>());
        Assert.That(attribute, Is.InstanceOf<IWrapSetUpTearDown>());
    }

    [Test]
    public void Wrap_WithMultipleLevelsOfParents_FindsFixture()
    {
        // Arrange
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        
        var grandParent = new MockTest { Fixture = fixture };
        var parent = new MockTest { Fixture = null, Parent = grandParent };
        var child = new MockTest { Fixture = null, Parent = parent };
        
        var originalCommand = new MockTestCommand(child, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithMultipleLevelsOfParents_FindsFixture)))));

        // Act
        var wrappedCommand = attribute.Wrap(originalCommand);

        // Assert
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }

    [Test]
    public void RecordedTestAttributeCommand_PreservesTestContext()
    {
        // Arrange
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest { Fixture = fixture };
        var result = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_PreservesTestContext))));
        result.SetResult(ResultState.Success);
        
        var innerCommand = new MockTestCommand(test, result);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var originalTestObject = new object();
        context.TestObject = originalTestObject;

        // Act
        wrappedCommand.Execute(context);

        // Assert
        Assert.That(context.CurrentTest, Is.SameAs(test));
        Assert.That(context.TestObject, Is.SameAs(originalTestObject));
    }
}
