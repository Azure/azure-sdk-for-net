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
        protected RecordedTestBase(bool isAsync, RecordedTestMode? mode = null, bool useLegacyTransport = false) : base(isAsync, mode, useLegacyTransport)
        {
            TestEnvironment = new TEnvironment();
            TestEnvironment.Mode = Mode;
        }

        public override async Task StartTestRecordingAsync()
        {
            // Set the TestEnvironment Mode here so that any Mode changes in RecordedTestBase are picked up here also.
            TestEnvironment.Mode = Mode;

            await base.StartTestRecordingAsync();
            TestEnvironment.SetRecording(Recording);
        }

        public TEnvironment TestEnvironment { get; }

        [OneTimeSetUp]
        public async ValueTask WaitForEnvironment()
        {
            await TestEnvironment.WaitForEnvironmentAsync();
        }
    }
}
