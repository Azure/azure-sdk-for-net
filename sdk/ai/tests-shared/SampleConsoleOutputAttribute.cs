// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

[assembly: Azure.AI.Tests.Shared.SampleConsoleOutput]

namespace Azure.AI.Tests.Shared
{
    [AttributeUsage(AttributeTargets.Assembly)]
    internal sealed class SampleConsoleOutputAttribute : TestActionAttribute
    {
        public override ActionTargets Targets => ActionTargets.Test;

        public override void AfterTest(ITest test)
        {
            if (test.IsSuite || test.ClassName?.Contains(".Tests.Samples.") != true)
            {
                return;
            }

            string directory = Path.Combine(
                TestContext.CurrentContext.WorkDirectory, "TestResults", "sample-console-output", Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, "console-output.txt");
            File.WriteAllText(path, TestExecutionContext.CurrentContext.CurrentResult.Output);
            TestContext.AddTestAttachment(path, "Sample console output");
        }
    }
}
