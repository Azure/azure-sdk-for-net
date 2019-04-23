﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using Azure.Core.Pipeline;

namespace Azure
{
    public abstract class Response: IDisposable
    {
        public abstract int Status { get; }

        public abstract bool TryGetHeader(string name, out string value);

        public abstract Stream ContentStream { get; set; }

        public abstract string RequestId { get; set; }

        public abstract IEnumerable<HttpHeader> Headers { get; }

        public abstract void Dispose();
    }
}
