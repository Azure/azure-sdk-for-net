// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using NUnit.Framework.Internal.Commands;

namespace Microsoft.ClientModel.TestFramework.Tests;

[TestFixture]
public class RetryOnErrorAttributeTests
{
    [Test]
    public void ConstructorCreatesInstance()
    {
        var attribute = new TestRetryAttribute(3, _ => true);
        Assert.That(attribute, Is.Not.Null);
    }

    [Test]
    public void WrapCreatesRetryCommand()
    {
        var test = new SimpleTest("Test");
        var testMethod = new TestMethod(new MethodWrapper(typeof(RetryOnErrorAttributeTests), nameof(WrapCreatesRetryCommand)));
        var result = new TestCaseResult(testMethod);
        var command = new SimpleTestCommand(test, result);
        var attribute = new TestRetryAttribute(3, _ => true);

        var wrappedCommand = attribute.Wrap(command);

        Assert.That(wrappedCommand, Is.Not.Null);
        Assert.That(wrappedCommand, Is.TypeOf<RetryOnErrorAttribute.RetryOnErrorCommand>());
    }

    [Test]
    public void ExecuteSuccessfulTestRunsOnce()
    {
        var test = new SimpleTest("Test");
        var testMethod = new TestMethod(new MethodWrapper(typeof(RetryOnErrorAttributeTests), nameof(ExecuteSuccessfulTestRunsOnce)));
        var result = new TestCaseResult(testMethod);
        result.SetResult(ResultState.Success);
        var command = new SimpleTestCommand(test, result);
        var attribute = new TestRetryAttribute(3, _ => true);
        var wrappedCommand = attribute.Wrap(command);
        var context = new TestExecutionContext { CurrentTest = test };

        var finalResult = wrappedCommand.Execute(context);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(finalResult.ResultState.Status, Is.EqualTo(TestStatus.Passed));
            Assert.That(command.ExecutionCount, Is.EqualTo(1));
        }
    }

    [Test]
    public void ExecuteWithShouldRetryFalseDoesNotRetry()
    {
        var test = new SimpleTest("Test");
        var testMethod = new TestMethod(new MethodWrapper(typeof(RetryOnErrorAttributeTests), nameof(ExecuteWithShouldRetryFalseDoesNotRetry)));
        var result = new TestCaseResult(testMethod);
        result.SetResult(ResultState.Error, "Test failed");
        var command = new SimpleTestCommand(test, result);
        var attribute = new TestRetryAttribute(3, _ => false); // shouldRetry always returns false
        var wrappedCommand = attribute.Wrap(command);
        var context = new TestExecutionContext { CurrentTest = test };

        var finalResult = wrappedCommand.Execute(context);

        using (Assert.EnterMultipleScope())
        {
            Assert.That(finalResult.ResultState.Status, Is.EqualTo(TestStatus.Failed));
            Assert.That(command.ExecutionCount, Is.EqualTo(1)); // Should not retry
        }
    }

    // Mock classes for testing
    private class SimpleTest : Test
    {
        public SimpleTest(string name) : base(name) { }

        public override object[] Arguments => Array.Empty<object>();
        public override string MethodName => Name;
        public override bool HasChildren => false;
        public override IList<ITest> Tests => new List<ITest>();

        public override string XmlElementName => throw new NotImplementedException();

        public override TNode AddToXml(TNode parentNode, bool recursive) => parentNode;
        public override TestResult MakeTestResult()
        {
            var testMethod = new TestMethod(new MethodWrapper(typeof(RetryOnErrorAttributeTests), Name));
            return new TestCaseResult(testMethod);
        }
    }

    private class SimpleTestCommand : TestCommand
    {
        private readonly TestResult _resultToReturn;
        public int ExecutionCount { get; private set; }

        public SimpleTestCommand(Test test, TestResult result) : base(test)
        {
            _resultToReturn = result;
        }

        public override TestResult Execute(TestExecutionContext context)
        {
            ExecutionCount++;
            return _resultToReturn;
        }
    }

    private class TestRetryAttribute : RetryOnErrorAttribute
    {
        public TestRetryAttribute(int maxRetryCount, Func<TestExecutionContext, bool> shouldRetry)
            : base(maxRetryCount, shouldRetry) { }
    }
}
