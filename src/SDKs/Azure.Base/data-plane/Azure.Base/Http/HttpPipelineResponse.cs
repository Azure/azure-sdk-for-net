// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;

namespace Azure.Base.Http
{
    public abstract class HttpPipelineResponse: IDisposable
    {
        public abstract int Status { get; }

        public abstract bool TryGetHeader(ReadOnlySpan<byte> name, out ReadOnlySpan<byte> value);

        public abstract Stream ResponseContentStream { get; }
        public abstract void Dispose();
    }
}