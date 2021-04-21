// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Azure.Core.TestFramework
{
#pragma warning disable SA1649 // File name should match first type name
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
    {
        private static bool IsEnvironmentReady;

        protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        public override void StartTestRecording()
        {
            // Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
            TestEnvironment.Mode = Mode;

            base.StartTestRecording();
            TestEnvironment.SetRecording(Recording);
        }

        public TEnvironment TestEnvironment { get; }

        [OneTimeSetUp]
        public async Task WaitForEnvironment()
        {
            if (IsEnvironmentReady)
            {
                return;
            }

            int numberOfTries = 60;
            TimeSpan delay = TimeSpan.FromSeconds(10);
            for (int i = 0; i < numberOfTries; i++)
            {
                var isReady = await TestEnvironment.IsEnvironmentReady();
                if (isReady)
                {
                    IsEnvironmentReady = isReady;
                    return;
                }
                await Task.Delay(delay);
            }

            throw new InvalidOperationException("The environment has not become ready, check your TestEnvironment.IsEnvironmentReady scenario.");
        }
    }
}
