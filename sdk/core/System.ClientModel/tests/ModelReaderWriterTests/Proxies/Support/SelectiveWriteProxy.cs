// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// A proxy that can be configured to accept or decline write via CanHandle(model).
    /// Used to test the write-path chain-of-responsibility where first proxy declines.
    /// </summary>
    internal class SelectiveWriteProxy : ConditionalModelProxy<SimpleModel>
    {
        private readonly bool _canWrite;
        public bool WriteWasCalled => ((TrackingModel)Model).WriteWasCalled;

        public SelectiveWriteProxy(bool canWrite)
            : base(new TrackingModel())
        {
            _canWrite = canWrite;
        }

        public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options, ModelReaderWriterContext context) => _canWrite;
    }
}
