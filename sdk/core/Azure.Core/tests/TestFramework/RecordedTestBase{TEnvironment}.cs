// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Core.Testing
{
    public abstract class RecordedTestBase<TEnvironment> : RecordedTestBase where TEnvironment: TestEnvironment, new()
    {
        protected RecordedTestBase(bool isAsync) : base(isAsync)
        {
        }

        protected RecordedTestBase(bool isAsync, RecordedTestMode mode) : base(isAsync, mode)
        {
            TestEnvironment = new TEnvironment();
        }

        public override void StartTestRecording()
        {
            base.StartTestRecording();
            TestEnvironment.SetRecording(Recording, Mode == RecordedTestMode.Playback);
        }

        public TEnvironment TestEnvironment { get; }
    }

}