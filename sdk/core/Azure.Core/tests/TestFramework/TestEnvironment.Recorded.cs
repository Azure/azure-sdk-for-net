// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Identity;

namespace Azure.Core.Testing
{
    public partial class TestEnvironment
    {
        private TestRecording _recording;
        private bool _playback;

        public void SetRecording(TestRecording recording, bool playback)
        {
            _credential = null;
            _recording = recording;
            _playback = playback;
        }

        partial void GetRecordedValue(string name, ref string value)
        {
            if (_recording == null)
            {
                return;
            }

            value =  _recording.GetVariable(name, null);
        }

        partial void GetIsPlayback(ref bool playback)
        {
            playback = _playback;
        }

        partial void SetRecordedValue(string name, string value)
        {
            _recording?.SetVariable(name, value);
        }
    }
}