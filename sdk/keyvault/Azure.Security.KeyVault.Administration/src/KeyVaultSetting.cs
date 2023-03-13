// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// An account setting.
    /// </summary>
    [CodeGenModel("Setting")]
    [CodeGenSuppress(nameof(KeyVaultSetting), typeof(string), typeof(string))]
#pragma warning disable CA1825 // Avoid zero-length array allocations
    [CodeGenSuppress("Content")]
#pragma warning restore CA1825 // Avoid zero-length array allocations
    public partial class KeyVaultSetting
    {
        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultSetting"/> class with the given name and boolean value.
        /// </summary>
        /// <param name="name">The name of the account setting.</param>
        /// <param name="value">The boolean value of the account setting.</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> is an empty string.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null.</exception>
        public KeyVaultSetting(string name, bool value)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            Name = name;
            Value = new KeyVaultSettingValue(value);
        }

        // TODO: Move construction to KeyVaultSettingValue and hide constructors here when the number of supported value types warrants it e.g., more than 3 intrinsic types.

        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultSetting"/> class.
        /// </summary>
        /// <param name="name">The name of the account setting.</param>
        /// <param name="value">The string value of the account setting.</param>
        /// <param name="settingType">The type specifier of the value.</param>
        internal KeyVaultSetting(string name, string value, KeyVaultSettingType? settingType)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(value, nameof(value));

            Name = name;
            Value = new KeyVaultSettingValue(value, settingType);
        }

        /// <summary>
        /// Gets the type specifier of the value.
        /// </summary>
        public KeyVaultSettingType? SettingType => Value.SettingType;

        /// <summary>
        /// Gets the value of the account setting.
        /// </summary>
        public KeyVaultSettingValue Value { get; }

        /// <summary>
        /// Returns the setting name, value, and type.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name}={Value} ({SettingType ?? string.Empty})";
    }
}
