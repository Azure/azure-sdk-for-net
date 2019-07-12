// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Diagnostics;

namespace Azure.Core.Pipeline
{
    public sealed class ClientDiagnostics
    {
        private readonly bool _isActivityEnabled;

        public ClientDiagnostics(bool isActivityEnabled)
        {
            _isActivityEnabled = isActivityEnabled;
        }

        private static readonly DiagnosticListener s_source = new DiagnosticListener("Azure");

        public ClientDiagnosticScope CreateScope(string name)
        {
            if (!_isActivityEnabled)
            {
                return default;
            }
            return new ClientDiagnosticScope(name, s_source);
        }
    }
}
