// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Storage.CoreWCF.Runtime.Diagnostics
{
    internal sealed class EtwDiagnosticTrace
    {
        public static readonly Guid ImmutableDefaultEtwProviderId = new Guid("{79f88dc7-9062-4cff-af90-09b2455644b6}");
        private static Guid s_defaultEtwProviderId = ImmutableDefaultEtwProviderId;

        public static Guid DefaultEtwProviderId
        {
            get
            {
                return s_defaultEtwProviderId;
            }
            set
            {
                s_defaultEtwProviderId = value;
            }
        }

        public EtwDiagnosticTrace(string traceSourceName, Guid etwProviderId)
        {
        }
    }
}
