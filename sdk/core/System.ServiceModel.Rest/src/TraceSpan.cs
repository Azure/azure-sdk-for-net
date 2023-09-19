// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TBD.
    /// </summary>
    public class TraceSpan : IDisposable
    {
        private readonly DiagnosticScope _scope;

        internal TraceSpan(DiagnosticScope scope)
        {
            _scope = scope;
        }

        /// <summary>
        /// TBD.
        /// </summary>
        public void Start() => _scope.Start();

        /// <summary>
        /// TBD.
        /// </summary>
        /// <param name="exception"></param>
        public void Failed(Exception exception) => _scope.Failed(exception);

        /// <inheritdoc/>
        public void Dispose() => _scope.Dispose();
    }
}