// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using Azure.AI.Tests.Shared;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace Azure.AI.Projects.Tests
{
    public class SampleConsoleOutputTests
    {
        [TestCase("Azure.AI.Projects.Tests.Samples.Sample_AIAgents")]
        [TestCase("Azure.AI.Projects.Agents.Tests.Samples.Sample_agents_CRUD")]
        [TestCase("Azure.AI.Extensions.OpenAI.Tests.Samples.Sample_ResponseBasic")]
        public void CapturesConsoleOutputAsATestAttachment(string className)
        {
            var result = TestExecutionContext.CurrentContext.CurrentResult;
            int originalCount = result.TestAttachments.Count;
            Console.Write("Sample output: ");
            Console.WriteLine("caf\u00e9");
            TestContext.Out.WriteLine("Additional test output");
            string expected = result.Output;

            new SampleConsoleOutputAttribute().AfterTest(
                Mock.Of<ITest>(test => test.ClassName == className));

            Assert.That(result.TestAttachments.Count, Is.EqualTo(originalCount + 1));
            string path = result.TestAttachments.Last().FilePath;
            Assert.That(Path.GetFileName(path), Is.EqualTo("console-output.txt"));
            Assert.That(File.ReadAllText(path), Is.EqualTo(expected));
            Assert.That(expected, Does.Contain("Sample output: caf\u00e9"));
            Assert.That(expected, Does.Contain("Additional test output"));
        }

        [Test]
        public void AttachesAnEmptyFileWhenTheSampleWritesNothing()
        {
            var result = TestExecutionContext.CurrentContext.CurrentResult;
            Assert.That(result.Output, Is.Empty);

            new SampleConsoleOutputAttribute().AfterTest(
                Mock.Of<ITest>(test => test.ClassName == "Azure.AI.Projects.Tests.Samples.EmptySample"));

            Assert.That(File.ReadAllText(result.TestAttachments.Last().FilePath), Is.Empty);
        }

        [Test]
        public void FailedSamplesStillAttachTheirConsoleOutput()
        {
            string path;
            using (new TestExecutionContext.IsolatedContext())
            {
                var result = TestExecutionContext.CurrentContext.CurrentResult;
                Console.WriteLine("Output before the sample failed");
                result.SetResult(ResultState.Failure, "Simulated sample failure");

                new SampleConsoleOutputAttribute().AfterTest(
                    Mock.Of<ITest>(test => test.ClassName == "Azure.AI.Projects.Tests.Samples.FailedSample"));

                path = result.TestAttachments.Last().FilePath;
                Assert.That(result.ResultState.Status, Is.EqualTo(TestStatus.Failed));
                Assert.That(File.ReadAllText(path), Does.Contain("Output before the sample failed"));
            }
            TestContext.AddTestAttachment(path, "Failed sample console output");
        }

        [Test]
        public void UsesSeparateFilesForEachAttachment()
        {
            var result = TestExecutionContext.CurrentContext.CurrentResult;
            var action = new SampleConsoleOutputAttribute();
            var test = Mock.Of<ITest>(item => item.ClassName == "Azure.AI.Projects.Tests.Samples.Example");
            action.AfterTest(test);
            string firstPath = result.TestAttachments.Last().FilePath;
            action.AfterTest(test);

            Assert.That(result.TestAttachments.Last().FilePath, Is.Not.EqualTo(firstPath));
            Assert.That(File.Exists(firstPath), Is.True);
        }

        [TestCase(null, false)]
        [TestCase("Azure.AI.Projects.Tests.OtherTests", false)]
        [TestCase("Azure.AI.Projects.Tests.Samples.Example", true)]
        public void DoesNotAttachOutputForOtherTestsOrSuites(string className, bool isSuite)
        {
            var result = TestExecutionContext.CurrentContext.CurrentResult;
            int originalCount = result.TestAttachments.Count;

            new SampleConsoleOutputAttribute().AfterTest(
                Mock.Of<ITest>(test => test.ClassName == className && test.IsSuite == isSuite));

            Assert.That(result.TestAttachments.Count, Is.EqualTo(originalCount));
        }
    }
}
