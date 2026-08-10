// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.HDInsight.Models
{
    // This extensible enum was removed during TypeSpec migration because the async operation
    // status endpoints were suppressed via @@scope(..., "!csharp") to eliminate phantom
    // sub-resources. It is re-added here as custom code for backward compatibility.
    /// <summary> The async operation state. </summary>
    public readonly partial struct HDInsightAsyncOperationState : IEquatable<HDInsightAsyncOperationState>
    {
        private readonly string _value;

        /// <summary> Initializes a new instance of <see cref="HDInsightAsyncOperationState"/>. </summary>
        /// <param name="value"> The value. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        public HDInsightAsyncOperationState(string value)
        {
            _value = value ?? throw new ArgumentNullException(nameof(value));
        }

        private const string InProgressValue = "InProgress";
        private const string SucceededValue = "Succeeded";
        private const string FailedValue = "Failed";

        /// <summary> InProgress. </summary>
        public static HDInsightAsyncOperationState InProgress { get; } = new HDInsightAsyncOperationState(InProgressValue);
        /// <summary> Succeeded. </summary>
        public static HDInsightAsyncOperationState Succeeded { get; } = new HDInsightAsyncOperationState(SucceededValue);
        /// <summary> Failed. </summary>
        public static HDInsightAsyncOperationState Failed { get; } = new HDInsightAsyncOperationState(FailedValue);

        /// <summary> Determines if two <see cref="HDInsightAsyncOperationState"/> values are the same. </summary>
        public static bool operator ==(HDInsightAsyncOperationState left, HDInsightAsyncOperationState right) => left.Equals(right);
        /// <summary> Determines if two <see cref="HDInsightAsyncOperationState"/> values are not the same. </summary>
        public static bool operator !=(HDInsightAsyncOperationState left, HDInsightAsyncOperationState right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="HDInsightAsyncOperationState"/>. </summary>
        public static implicit operator HDInsightAsyncOperationState(string value) => new HDInsightAsyncOperationState(value);
        /// <summary> Converts a string to a nullable <see cref="HDInsightAsyncOperationState"/>. </summary>
        public static implicit operator HDInsightAsyncOperationState?(string value) => value == null ? null : new HDInsightAsyncOperationState(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HDInsightAsyncOperationState other && Equals(other);
        /// <inheritdoc />
        public bool Equals(HDInsightAsyncOperationState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
