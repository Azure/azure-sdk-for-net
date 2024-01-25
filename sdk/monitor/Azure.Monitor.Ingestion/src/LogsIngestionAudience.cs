// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.Monitor.Ingestion
{
    /// <summary> Cloud audiences available for Ingestion. </summary>
    public readonly partial struct LogsIngestionAudience : IEquatable<LogsIngestionAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsIngestionAudience"/> object.
        /// </summary>
        /// <param name="value">The Azure Active Directory audience to use when forming authorization scopes. For the language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/azure/azure-government/documentation-government-cognitiveservices" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Use one of the constant members over creating a custom value, unless you have special needs for doing so.</remarks>
        public LogsIngestionAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://monitor.azure.cn//.default";
        private const string AzureGovernmentValue = "https://monitor.azure.us//.default";
        private const string AzurePublicCloudValue = "https://monitor.azure.com//.default";

        /// <summary> Azure China. </summary>
        public static LogsIngestionAudience AzureChina { get; } = new LogsIngestionAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static LogsIngestionAudience AzureGovernment { get; } = new LogsIngestionAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static LogsIngestionAudience AzurePublicCloud { get; } = new LogsIngestionAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="LogsIngestionAudience"/> values are the same. </summary>
        public static bool operator ==(LogsIngestionAudience left, LogsIngestionAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LogsIngestionAudience"/> values are not the same. </summary>
        public static bool operator !=(LogsIngestionAudience left, LogsIngestionAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LogsIngestionAudience"/>. </summary>
        public static implicit operator LogsIngestionAudience(string value) => new LogsIngestionAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LogsIngestionAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LogsIngestionAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
