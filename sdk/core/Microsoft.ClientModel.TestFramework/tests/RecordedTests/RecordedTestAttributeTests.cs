// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Microsoft.ClientModel.TestFramework.Tests;

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
    public void WrapWithRecordedTestBaseFixtureReturnsWrappedCommand()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(WrapWithRecordedTestBaseFixtureReturnsWrappedCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
        Assert.That(wrappedCommand, Is.Not.Null);
    }

    [Test]
    public void WrapWithoutRecordedTestBaseFixtureReturnsOriginalCommand()
    {
        var attribute = new RecordedTestAttribute();
        var test = new MockTest("TestMethod") { Fixture = new object() }; // Not a RecordedTestBase
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(WrapWithoutRecordedTestBaseFixtureReturnsOriginalCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }

    [Test]
    public void WrapWithNullFixtureReturnsOriginalCommand()
    {
        var attribute = new RecordedTestAttribute();
        var test = new MockTest("TestMethod") { Fixture = null };
        var originalCommand = new MockTestCommand(test,
            new TestCaseResult(new TestMethod(
                new MethodWrapper(typeof(RecordedTestAttributeTests),
                nameof(WrapWithNullFixtureReturnsOriginalCommand)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.SameAs(originalCommand));
    }

    [Test]
    public void WrapWithParentFixtureFindsRecordedTestBase()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var parentTest = new MockTest("ParentTest") { Fixture = fixture };
        var childTest = new MockTest("ChildTest") { Fixture = null, Parent = parentTest };
        var originalCommand = new MockTestCommand(childTest,
            new TestCaseResult(new TestMethod(
                    new MethodWrapper(typeof(RecordedTestAttributeTests),
                    nameof(WrapWithParentFixtureFindsRecordedTestBase)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }

    [Test]
    public void ExecutionWithSuccessfulTestExecutesInnerCommand()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var expectedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(ExecutionWithSuccessfulTestExecutesInnerCommand))));
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
    public void ExecutionWithPassedTestReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var passedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(ExecutionWithPassedTestReturnsOriginalResult))));
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
    public void ExecutionWithSkippedTestReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var skippedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(ExecutionWithSkippedTestReturnsOriginalResult))));
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
    public void ExecutionWithFailedTestInLiveModeReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(
            new MethodWrapper(typeof(RecordedTestAttributeTests),
            nameof(ExecutionWithFailedTestInLiveModeReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
            Assert.That(result.Message, Is.EqualTo("Test failed"));
        }
    }

    [Test]
    public void ExecutionWithFailedTestInRecordModeReturnsOriginalResult()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var failedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(ExecutionWithFailedTestInRecordModeReturnsOriginalResult))));
        failedResult.SetResult(ResultState.Failure, "Test failed");
        var innerCommand = new MockTestCommand(test, failedResult);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var result = wrappedCommand.Execute(context);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
            Assert.That(result.Message, Is.EqualTo("Test failed"));
        }
    }

    [Test]
    public void WrapCanBeCreatedWithDifferentModes()
    {
        var liveFixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var recordFixture = new MockRecordedTestBase(RecordedTestMode.Record);
        var playbackFixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var liveTest = new MockTest("LiveTest") { Fixture = liveFixture };
        var recordTest = new MockTest("RecordTest") { Fixture = recordFixture };
        var playbackTest = new MockTest("PlaybackTest") { Fixture = playbackFixture };
        var passedResult = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(WrapCanBeCreatedWithDifferentModes))));
        passedResult.SetResult(ResultState.Success);
        var attribute = new RecordedTestAttribute();
        var liveCommand = attribute.Wrap(new MockTestCommand(liveTest, passedResult));
        var recordCommand = attribute.Wrap(new MockTestCommand(recordTest, passedResult));
        var playbackCommand = attribute.Wrap(new MockTestCommand(playbackTest, passedResult));
        using (Assert.EnterMultipleScope())
        {
            Assert.That(liveCommand, Is.Not.Null);
            Assert.That(recordCommand, Is.Not.Null);
            Assert.That(playbackCommand, Is.Not.Null);
        }
    }

    [Test]
    public void WrapWithMultipleLevelsOfParentsFindsFixture()
    {
        var attribute = new RecordedTestAttribute();
        var fixture = new MockRecordedTestBase(RecordedTestMode.Playback);
        var grandParent = new MockTest("GrandParent") { Fixture = fixture };
        var parent = new MockTest("Parent") { Fixture = null, Parent = grandParent };
        var child = new MockTest("Child") { Fixture = null, Parent = parent };
        var originalCommand = new MockTestCommand(child, new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(WrapWithMultipleLevelsOfParentsFindsFixture)))));
        var wrappedCommand = attribute.Wrap(originalCommand);
        Assert.That(wrappedCommand, Is.Not.SameAs(originalCommand));
    }

    [Test]
    public void RecordedTestAttributeCommandPreservesTestContext()
    {
        var fixture = new MockRecordedTestBase(RecordedTestMode.Live);
        var test = new MockTest("TestMethod") { Fixture = fixture };
        var result = new TestCaseResult(new TestMethod(new MethodWrapper(typeof(RecordedTestAttributeTests), nameof(RecordedTestAttributeCommandPreservesTestContext))));
        result.SetResult(ResultState.Success);
        var innerCommand = new MockTestCommand(test, result);
        var attribute = new RecordedTestAttribute();
        var wrappedCommand = attribute.Wrap(innerCommand);
        var context = new TestExecutionContext();
        context.CurrentTest = test;
        var originalTestObject = new object();
        context.TestObject = originalTestObject;
        wrappedCommand.Execute(context);
        using (Assert.EnterMultipleScope())
        {
            Assert.That(context.CurrentTest, Is.SameAs(test));
            Assert.That(context.TestObject, Is.SameAs(originalTestObject));
        }
    }
}
