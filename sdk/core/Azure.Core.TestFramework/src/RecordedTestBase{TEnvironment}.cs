// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.TestFramework
{
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment: TestEnvironment, new()
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
            base.StartTestRecording();
            TestEnvironment.SetRecording(Recording);
        }

        public TEnvironment TestEnvironment { get; }
    }
}