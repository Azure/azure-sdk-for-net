// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework
{
#pragma warning disable SA1649 // File name should match first type name
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment : TestEnvironment, new()
#pragma warning restore SA1649 // File name should match first type name
    {
        protected RecordedTestBase(bool isAsync) : base(isAsync)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
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
    }
}
