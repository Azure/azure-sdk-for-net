// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.Security.KeyVault.Administration.Models;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// An account setting.
    /// </summary>
    [CodeGenType("Setting")]
    [CodeGenSuppress(nameof(KeyVaultSetting), typeof(string), typeof(string))]
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
            SettingType = KeyVaultSettingType.Boolean;
        }

        // TODO: Move construction to KeyVaultSettingValue and hide constructors here when the number of supported value types warrants it e.g., more than 3 intrinsic types.

        /// <summary>
        /// Creates a new instance of the <see cref="KeyVaultSetting"/> class.
        /// </summary>
        /// <param name="name">The name of the account setting.</param>
        /// <param name="content">The string content of the account setting.</param>
        /// <param name="settingType">The type specifier of the value.</param>
        /// <param name="additionalBinaryDataProperties">Additional properties.</param>
        internal KeyVaultSetting(string name, string content, KeyVaultSettingType? settingType, IDictionary<string, BinaryData> additionalBinaryDataProperties)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(content, nameof(content));

            Name = name;
            SettingType = settingType;
            Value = new KeyVaultSettingValue(content, settingType);
            Content = content;
            _additionalBinaryDataProperties = additionalBinaryDataProperties;
        }

        /// <summary>
        /// Gets the type specifier of the value.
        /// </summary>
        [CodeGenMember("Type")]
        public KeyVaultSettingType? SettingType { get; }

        /// <summary>
        /// Gets the value of the account setting.
        /// </summary>
        public KeyVaultSettingValue Value { get; }

        internal string Content { get; }

        /// <summary>
        /// Returns the setting name, value, and type.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{Name}={Value} ({SettingType ?? string.Empty})";

        /// <summary> Convert into a <see cref="RequestContent"/>. </summary>
        internal virtual RequestContent ToRequestContent()
        {
            var content = new Utf8JsonRequestContent();
            content.JsonWriter.WriteObjectValue(new UpdateSettingRequest(this.Value.ToString()));
            return content;
        }
    }
}
