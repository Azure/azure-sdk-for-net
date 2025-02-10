﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Data.AppConfiguration
{
    /// <summary> Cloud audiences available for AppConfiguration. </summary>
    public readonly struct ConfigurationAudience : IEquatable<ConfigurationAudience>
    {
        private readonly string _value;
        private const string AzureChinaValue = "https://appconfig.azure.cn";
        private const string AzureGovernmentValue = "https://appconfig.azure.us";
        private const string AzurePublicCloudValue = "https://appconfig.azure.com";

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigurationAudience"/> object.
        /// </summary>
        /// <param name="value">The Microsoft Entra audience to use when forming authorization scopes.
        /// For the App Configuration service, this value corresponds to a URL that identifies the Azure cloud where the resource is located.</param>
        /// <exception cref="ArgumentNullException"> <paramref name="value"/> is null. </exception>
        /// <remarks>Please use one of the constant members over creating a custom value unless you have special needs for doing so.</remarks>
        public ConfigurationAudience(string value)
        {
            Argument.AssertNotNullOrEmpty(value, nameof(value));
            _value = value;
        }

        /// <summary> Azure China. </summary>
        public static ConfigurationAudience AzureChina { get; } = new ConfigurationAudience(AzureChinaValue);

        /// <summary> Azure Government. </summary>
        public static ConfigurationAudience AzureGovernment { get; } = new ConfigurationAudience(AzureGovernmentValue);

        /// <summary> Azure Public Cloud. </summary>
        public static ConfigurationAudience AzurePublicCloud { get; } = new ConfigurationAudience(AzurePublicCloudValue);

        /// <summary> Determines if two <see cref="ConfigurationAudience"/> values are the same. </summary>
        public static bool operator ==(ConfigurationAudience left, ConfigurationAudience right) => left.Equals(right);
        /// <summary> Determines if two <see cref="ConfigurationAudience"/> values are not the same. </summary>
        public static bool operator !=(ConfigurationAudience left, ConfigurationAudience right) => !left.Equals(right);
        /// <summary> Converts a string to a <see cref="ConfigurationAudience"/>. </summary>
        public static implicit operator ConfigurationAudience(string value) => new ConfigurationAudience(value);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is ConfigurationAudience other && Equals(other);
        /// <inheritdoc />
        public bool Equals(ConfigurationAudience other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);

        /// <inheritdoc />
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => _value?.GetHashCode() ?? 0;
        /// <inheritdoc />
        public override string ToString() => _value;
    }
}
