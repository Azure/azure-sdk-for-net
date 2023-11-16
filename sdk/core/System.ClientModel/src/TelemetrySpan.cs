// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace System.ClientModel.Primitives
{
    public readonly struct TelemetrySpan : IDisposable
    {
        private readonly DiagnosticScope _scope;

        internal TelemetrySpan(DiagnosticScope scope)
        {
            _scope = scope;
        }

        public void Start() => _scope.Start();

        public void Failed(Exception exception) => _scope.Failed(exception);

        /// <inheritdoc/>
        public void Dispose() => _scope.Dispose();
    }
}