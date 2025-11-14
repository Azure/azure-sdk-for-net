// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Monitor.Query.Logs
{
    /// <summary> Cloud audiences available for Query. </summary>
    public readonly partial struct LogsQueryAudience : IEquatable<LogsQueryAudience>
    {
        private readonly string _value;

        /// <summary>
        /// Initializes a new instance of the <see cref="LogsQueryAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes. For the language service, this value corresponds to a URL that identifies the Azure cloud where the resource is located. For more information: <see href="https://learn.microsoft.com/en-us/azure/azure-government/documentation-government-manage-oms" />.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Use one of the constant members over creating a custom value, unless you have special needs for doing so.</remarks>
        public LogsQueryAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        private const string AzureChinaValue = "https://api.loganalytics.azure.cn";
        private const string AzureGovernmentValue = "https://api.loganalytics.us";
        private const string AzurePublicCloudValue = "https://api.loganalytics.io";

        /// <summary> Azure China. </summary>
        public static LogsQueryAudience AzureChina { get; } = new LogsQueryAudience(AzureChinaValue);

        /// <summary> Azure US Government. </summary>
        public static LogsQueryAudience AzureGovernment { get; } = new LogsQueryAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static LogsQueryAudience AzurePublicCloud { get; } = new LogsQueryAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="LogsQueryAudience"/> values are the same. </summary>
        public static bool operator ==(LogsQueryAudience left, LogsQueryAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="LogsQueryAudience"/> values are not the same. </summary>
        public static bool operator !=(LogsQueryAudience left, LogsQueryAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="LogsQueryAudience"/>. </summary>
        public static implicit operator LogsQueryAudience(string value) => new LogsQueryAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is LogsQueryAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(LogsQueryAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
