// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core.Shared
{
    /// <summary>
    /// Represents the common set of operations for messaging diagnostics, as per the Open Telemetry semantic conventions.
    /// This is defined as a partial struct so that it can be extended by other libraries.
    /// <seealso href="https://github.com/open-telemetry/opentelemetry-specification/blob/main/specification/trace/semantic_conventions/messaging.md#operation-names"/>
    /// </summary>
    internal readonly partial struct MessagingDiagnosticOperation : IEquatable<MessagingDiagnosticOperation>
    {
        private readonly string _operation;

        private MessagingDiagnosticOperation(string operation)
        {
            Argument.AssertNotNull(operation, nameof(operation));
            _operation = operation;
        }

        public static MessagingDiagnosticOperation Publish = new("publish");
        public static MessagingDiagnosticOperation Receive = new("receive");
        public static MessagingDiagnosticOperation Process = new("process");
        public override string ToString() => _operation;

        public static bool operator ==(MessagingDiagnosticOperation left, MessagingDiagnosticOperation right) => left.Equals(right);
        public static bool operator !=(MessagingDiagnosticOperation left, MessagingDiagnosticOperation right) => !left.Equals(right);
        public static implicit operator MessagingDiagnosticOperation(string value) => new MessagingDiagnosticOperation(value);

        public bool Equals(MessagingDiagnosticOperation other)
        {
            return _operation == other._operation;
        }

        public override bool Equals(object? obj)
        {
            return obj is MessagingDiagnosticOperation other && Equals(other);
        }

        public override int GetHashCode() => _operation.GetHashCode();
    }
}