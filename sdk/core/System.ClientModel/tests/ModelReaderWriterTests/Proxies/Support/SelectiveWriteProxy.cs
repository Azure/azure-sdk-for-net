// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;

namespace System.ClientModel.Tests.ModelReaderWriterTests.Proxies.Support
{
    /// <summary>
    /// A proxy that can be configured to accept or decline write via CanHandle(model).
    /// Used to test the write-path chain-of-responsibility where first proxy declines.
    /// </summary>
    internal class SelectiveWriteProxy : TrackingModel
    {
        private readonly bool _canWrite;

        public SelectiveWriteProxy(bool canWrite)
        {
            _canWrite = canWrite;
        }

        public override bool CanHandle(SimpleModel model, ModelReaderWriterOptions options) => _canWrite;
    }
}
