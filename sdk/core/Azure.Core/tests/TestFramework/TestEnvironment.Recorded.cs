// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Testing
{
    public partial class TestEnvironment
    {
        private TestRecording _recording;
        private RecordedTestMode? _mode;

        public void SetMode(RecordedTestMode? mode)
        {
            _mode = mode;
        }

        public void SetRecording(TestRecording recording)
        {
            _credential = null;
            _recording = recording;
        }

        partial void GetRecordedValue(string name, ref string value)
        {
            if (_recording == null)
            {
                throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
            }

            value =  _recording.GetVariable(name, null);
        }

        partial void GetIsPlayback(ref bool playback)
        {
            playback = _mode == RecordedTestMode.Playback;
        }

        partial void SetRecordedValue(string name, string value)
        {
            if (!_mode.HasValue)
            {
                return;
            }

            if (_recording == null)
            {
                throw new InvalidOperationException("Recorded value should not be retrieved outside the test method invocation");
            }

            _recording?.SetVariable(name, value);
        }
    }
}