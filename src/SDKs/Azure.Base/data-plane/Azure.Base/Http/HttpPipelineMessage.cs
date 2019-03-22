﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Base.Collections;
using System;
using System.ComponentModel;
using System.Threading;

namespace Azure.Base.Http
{
    public partial class HttpPipelineMessage  : IDisposable
    {
        internal OptionsStore _options = new OptionsStore();

        public CancellationToken Cancellation { get; }

        public HttpMessageOptions Options => new HttpMessageOptions(this);

        public HttpPipelineMessage(CancellationToken cancellation)
        {
            Cancellation = cancellation;
        }

        public HttpPipelineRequest Request { get; set; }

        public HttpPipelineResponse Response { get; set; }

        // make many of these protected internal
        public virtual void Dispose()
        {
            _options.Clear();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => base.Equals(obj);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => base.GetHashCode();
    }
}
