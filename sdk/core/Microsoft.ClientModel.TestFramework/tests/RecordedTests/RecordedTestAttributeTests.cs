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
        public MockRecordedTestBase(RecordedTestMode mode) : base(false)
        {
            Mode = mode;
        }
    }
    private class MockTestCommand : TestCommand
    {
        private readonly TestResult _result;
        public MockTestCommand(Test test, TestResult result) : base(test)
        {
            _result = result;
        }
        public override TestResult Execute(TestExecutionContext context)
        {
            context.CurrentResult = _result;
            return _result;
        }
    }
    private class MockTest : Test
    {
        public override object[] Arguments => Array.Empty<object>();
        public override string XmlElementName => "test";
        public override bool HasChildren => false;
        public override IList<ITest> Tests => new List<ITest>();
        public MockTest(string name) : base(name)
        {
        }
        public override TestResult MakeTestResult()
        {
            return new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), "MockTest")));
        }
        public override TNode AddToXml(TNode parentNode, bool recursive)
        {
            var node = parentNode.AddElement("test");
            node.AddAttribute("name", Name);
            return node;
        }
    }
    [Test]
    public void RecordedTestAttribute_InheritsFromTestAttribute()
    {
        var attribute = new RecordedTestAttribute();
        Assert.That(attribute, Is.InstanceOf<TestAttribute>());
        Assert.That(attribute, Is.InstanceOf<IWrapSetUpTearDown>());
    }
    [Test]
    public void Wrap_WithRecordedTestBaseFixture_ReturnsWrappedCommand()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(Wrap_WithRecordedTestBaseFixture_ReturnsWrappedCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
        Assert.That(wrappedCommand, Is.Not.Null);
    }
    [Test]
    public void Wrap_WithoutRecordedTestBaseFixture_ReturnsOriginalCommand()
    {
        var attribute = new RecordedTestAttribute();
        var test = new MockTest("TestMethod") { Fixture = new object() }; // Not a RecordedTestBase
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(Wrap_WithoutRecordedTestBaseFixture_ReturnsOriginalCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }
    [Test]
    public void Wrap_WithNullFixture_ReturnsOriginalCommand()
    {
        var attribute = new RecordedTestAttribute();
        var test = new MockTest("TestMethod") { Fixture = null };
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(
                new MethodWrapper(typeof(RecordedTestAttributeTests),
                nameof(Wrap_WithNullFixture_ReturnsOriginalCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }
    [Test]
    public void Wrap_WithParentFixture_FindsRecordedTestBase()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var parentTest = new MockTest("ParentTest") { Fixture = fixture };
        var childTest = new MockTest("ChildTest") { Fixture = null, Parent = parentTest };
        var originalCommand = new MockTestCommand(childTest,
            new TestCaseResult(new TestMethod(
                    new MethodWrapper(typeof(RecordedTestAttributeTests),
                    nameof(Wrap_WithParentFixture_FindsRecordedTestBase)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }
    [Test]
    public void RecordedTestAttributeCommand_ExecutesInnerCommand()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var expectedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(RecordedTestAttributeCommand_ExecutesInnerCommand))));
        expectedResult.SetResult(ResultState.Success);
        var innerCommand = new MockTestCommand(test, expectedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        Assert.That(result, Is.SameAs(expectedResult));
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Passed));
    }
    [Test]
    public void RecordedTestAttributeCommand_WithPassedTest_ReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var passedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(RecordedTestAttributeCommand_WithPassedTest_ReturnsOriginalResult))));
        passedResult.SetResult(ResultState.Success);
        var innerCommand = new MockTestCommand(test, passedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Passed));
    }
    [Test]
    public void RecordedTestAttributeCommand_WithSkippedTest_ReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var skippedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(RecordedTestAttributeCommand_WithSkippedTest_ReturnsOriginalResult))));
        skippedResult.SetResult(ResultState.Skipped, "Test skipped");
        var innerCommand = new MockTestCommand(test, skippedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Skipped));
    }
    [Test]
    public void RecordedTestAttributeCommand_WithFailedTestInLiveMode_ReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(RecordedTestAttributeCommand_WithFailedTestInLiveMode_ReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
        Assert.That(result.Message, Is.EqualTo("Test failed"));
    }
    [Test]
    public void RecordedTestAttributeCommand_WithFailedTestInRecordMode_ReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_WithFailedTestInRecordMode_ReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
        Assert.That(result.Message, Is.EqualTo("Test failed"));
    }
    [Test]
    public void RecordedTestAttributeCommand_CanBeCreatedWithDifferentModes()
    {
        var liveFixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var recordFixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var playbackFixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var liveTest = new MockTest("LiveTest") { Fixture = liveFixture };
        var recordTest = new MockTest("RecordTest") { Fixture = recordFixture };
        var playbackTest = new MockTest("PlaybackTest") { Fixture = playbackFixture };
        var passedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_CanBeCreatedWithDifferentModes))));
        passedResult.SetResult(ResultState.Success);
        var attribute = new RecordedTestAttribute();
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
        var attributeUsage = typeof(RecordedTestAttribute)
            .GetCustomAttributes(typeof(AttributeUsageAttribute), false)
            .Cast<AttributeUsageAttribute>()
            .FirstOrDefault();
        Assert.That(attributeUsage, Is.Not.Null);
        Assert.That(attributeUsage.ValidOn, Is.EqualTo(AttributeTargets.Method));
    }
    [Test]
    public void RecordedTestAttribute_ImplementsRequiredInterfaces()
    {
        var attribute = new RecordedTestAttribute();
        Assert.That(attribute, Is.InstanceOf<TestAttribute>());
        Assert.That(attribute, Is.InstanceOf<IWrapSetUpTearDown>());
    }
    [Test]
    public void Wrap_WithMultipleLevelsOfParents_FindsFixture()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var grandParent = new MockTest("GrandParent") { Fixture = fixture };
        var parent = new MockTest("Parent") { Fixture = null, Parent = grandParent };
        var child = new MockTest("Child") { Fixture = null, Parent = parent };
        var originalCommand = new MockTestCommand(child, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(Wrap_WithMultipleLevelsOfParents_FindsFixture)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }
    [Test]
    public void RecordedTestAttributeCommand_PreservesTestContext()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var result = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommand_PreservesTestContext))));
        result.SetResult(ResultState.Success);
        var innerCommand = new MockTestCommand(test, result);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var originalTestObject = new object();
        context.TestObject = originalTestObject;
        wrappedCommand.Execute(context);
        Assert.That(context.CurrentTest, Is.SameAs(test));
        Assert.That(context.TestObject, Is.SameAs(originalTestObject));
    }
}
