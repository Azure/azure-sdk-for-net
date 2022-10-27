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
        /// <exception cref="InvalidOperationException">The <see cref="Type"/> is not <see cref="SettingType.Boolean"/>, or the value cannot be normalized as a Boolean.</exception>
        public bool AsBoolean() => CheckType(SettingType.Boolean, () => (bool.TryParse(Value, out bool parsedValue), parsedValue));

        /// <summary>
        /// Gets the string value of this account setting. Use <see cref="Type"/> to determine if a more appropriate method like <see cref="AsBoolean"/> should be used instead.
        /// </summary>
        /// <returns>The string value of this account setting.</returns>
        public string AsString() => Value;

        /// <summary>
        /// Gets the raw string value of this account setting.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string method = nameof(AsString);
            if (Type == SettingType.Boolean)
            {
                method = nameof(AsBoolean);
            }

            return $"{Name}: {method}()=>{Value}";
        }

        [CodeGenMember("Value")]
        internal string Value { get; }

        /// <summary>
        /// Helper to convert boolean value to properly-cased "true" or "false" unlike <see cref="bool.ToString()"/>.
        /// </summary>
        /// <param name="value">The boolean to convert.</param>
        /// <returns>"true" or "false" appropriately.</returns>
        internal static string ToString(bool value) => value ? "true" : "false";

        private T CheckType<T>(SettingType expectedType, Func<(bool IsValid, T ParsedValue)> converter)
        {
            if (Type != expectedType)
            {
                throw new InvalidOperationException($"Cannot get setting as {SettingType.Boolean}. Setting type is {Type}.");
            }

            (bool isValid, T parsedValue) = converter();
            if (isValid)
            {
                return parsedValue;
            }

            throw new InvalidOperationException($"Cannot normalize the setting as {expectedType}. Use AsString() for a textual representation of the setting.");
        }
    }
}
