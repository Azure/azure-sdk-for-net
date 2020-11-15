﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    internal class StubException : Exception
    {
        public Func<string> OnGetStackTrace = () => string.Empty;
        public Func<string> OnToString = () => string.Empty;

        public override string StackTrace
        {
            get { return this.OnGetStackTrace(); }
        }

        public override string ToString()
        {
            return this.OnToString();
        }
    }
}
