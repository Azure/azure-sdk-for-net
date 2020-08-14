// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.Pipeline;

namespace Azure.Identity
{
    internal interface IScopeHandler
    {
        DiagnosticScope CreateScope(string name);
        void Start(string name, in DiagnosticScope scope);
        void Dispose(string name, in DiagnosticScope scope);
        void Fail(string name, in DiagnosticScope scope, Exception exception);
    }
}
