// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;

namespace Azure.Security.KeyVault.Administration
{
    [CodeGenModel("Setting")]
    public partial class KeyVaultSetting
    {
        /// <summary>
        /// Gets the boolean value of this account setting if <see cref="Type"/> is <see cref="SettingType.Boolean"/>.
        /// </summary>
        /// <returns>A boolean value if <see cref="Type"/> is <see cref="SettingType.Boolean"/>.</returns>
        /// <exception cref="FormatException">The value is neither "true" or "false" (case-insensitive).</exception>
        public bool GetBoolean() => bool.Parse(Value);

        /// <summary>
        /// Tries to get the boolean value of this account setting if <see cref="Type"/> is <see cref="SettingType.Boolean"/>.
        /// </summary>
        /// <param name="value">A boolean value if <see cref="Type"/> is <see cref="SettingType.Boolean"/>.</param>
        /// <returns><c>true</c> the raw string value could be converted to a boolean value; otherwise, <c>false</c>.</returns>
        public bool TryGetBoolean(out bool value) => bool.TryParse(Value, out value);

        /// <summary>
        /// Gets the raw string value of this account setting.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value ?? string.Empty;

        [CodeGenMember("Value")]
        internal string Value { get; }

        /// <summary>
        /// Helper to convert boolean value to properly-cased "true" or "false" unlike <see cref="bool.ToString()"/>.
        /// </summary>
        /// <param name="value">The boolean to convert.</param>
        /// <returns>"true" or "false" appropriately.</returns>
        internal static string Convert(bool value) => value ? "true" : "false";
    }
}
