// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Cloud audiences available for AppConfiguration. </summary>
    public readonly struct AppConfigurationAudience : IEquatable<AppConfigurationAudience>
    {
        private readonly string _value;
        private const string AzureChinaValue = "https://appconfig.azure.cn";
        private const string AzureGovernmentValue = "https://appconfig.azure.us";
        private const string AzurePublicCloudValue = "https://appconfig.azure.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="AppConfigurationAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes.
        /// For the App Configuration service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public AppConfigurationAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        /// <summary> Azure China. </summary>
        public static AppConfigurationAudience AzureChina { get; } = new AppConfigurationAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static AppConfigurationAudience AzureGovernment { get; } = new AppConfigurationAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static AppConfigurationAudience AzurePublicCloud { get; } = new AppConfigurationAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="AppConfigurationAudience"/> values are the same. </summary>
        public static bool operator ==(AppConfigurationAudience left, AppConfigurationAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="AppConfigurationAudience"/> values are not the same. </summary>
        public static bool operator !=(AppConfigurationAudience left, AppConfigurationAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="AppConfigurationAudience"/>. </summary>
        public static implicit operator AppConfigurationAudience(string value) => new AppConfigurationAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is AppConfigurationAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(AppConfigurationAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
