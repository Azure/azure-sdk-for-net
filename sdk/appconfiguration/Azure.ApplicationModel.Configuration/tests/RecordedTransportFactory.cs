// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Core.Testing
{
    public class RecordedTransportFactory
    {
        private readonly RecordedTestMode _mode;

        private readonly RecordSession _session;

        public RecordedTransportFactory(RecordedTestMode mode, RecordSession session)
        {
            _mode = mode;
            _session = session;
        }

        public HttpPipelineTransport CreateTransport(HttpPipelineTransport currentTransport)
        {
            switch (_mode)
            {
                case RecordedTestMode.Live:
                    return currentTransport;
                case RecordedTestMode.Record:
                    return new RecordTransport(_session, currentTransport);
                case RecordedTestMode.Playback:
                    return new PlaybackTransport(_session);
                default:
                    throw new ArgumentOutOfRangeException(nameof(_mode), _mode, null);
            }
        }

    }
}
