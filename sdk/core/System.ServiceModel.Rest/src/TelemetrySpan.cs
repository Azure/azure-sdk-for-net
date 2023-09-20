// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Pipeline;

namespace System.ServiceModel.Rest
{
    /// <summary>
    /// TBD.
    /// </summary>
    public readonly struct TelemetrySpan : IDisposable
    {
        private readonly DiagnosticScope _scope;

        internal TelemetrySpan(DiagnosticScope scope)
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

#if NETCOREAPP2_1
        internal static DiagnosticScope.ActivityKind FromActivityKind(ActivityKind kind)
        {
            return kind switch
            {
                ActivityKind.Internal => DiagnosticScope.ActivityKind.Internal,
                ActivityKind.Server => DiagnosticScope.ActivityKind.Server,
                ActivityKind.Client => DiagnosticScope.ActivityKind.Client,
                ActivityKind.Producer => DiagnosticScope.ActivityKind.Producer,
                ActivityKind.Consumer => DiagnosticScope.ActivityKind.Consumer,
                _ => throw new NotSupportedException(),
            };
        }

        /// <summary>
        /// Kind describes the relationship between the Activity, its parents, and its children in a Trace.
        /// </summary>
        internal enum ActivityKind
        {
            /// <summary>
            /// Default value.
            /// Indicates that the Activity represents an internal operation within an application, as opposed to an operations with remote parents or children.
            /// </summary>
            Internal = 0,

            /// <summary>
            /// Server activity represents request incoming from external component.
            /// </summary>
            Server = 1,

            /// <summary>
            /// Client activity represents outgoing request to the external component.
            /// </summary>
            Client = 2,

            /// <summary>
            /// Producer activity represents output provided to external components.
            /// </summary>
            Producer = 3,

            /// <summary>
            /// Consumer activity represents output received from an external component.
            /// </summary>
            Consumer = 4,
        }
#endif
    }
}