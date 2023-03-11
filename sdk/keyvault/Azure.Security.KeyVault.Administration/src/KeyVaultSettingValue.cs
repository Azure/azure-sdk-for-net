// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Azure.Security.KeyVault.Administration
{
    /// <summary>
    /// An account setting value.
    /// </summary>
    public class KeyVaultSettingValue
    {
        internal KeyVaultSettingValue(string value, KeyVaultSettingType? settingType)
        {
            // Service may not response with settingType for boolean (originally only supported value type).
            if (settingType == null || settingType == KeyVaultSettingType.Boolean)
            {
                if (!bool.TryParse(value, out bool result))
                {
                    throw InvalidSettingType(KeyVaultSettingType.Boolean);
                }

                ValueBool = result;
                SettingType = KeyVaultSettingType.Boolean;
            }
            else
            {
                ValueString = value;
                SettingType = settingType;
            }
        }

        internal KeyVaultSettingValue(bool value)
        {
            ValueBool = value;
            SettingType = KeyVaultSettingType.Boolean;
        }

        /// <summary>
        /// Gets the type specifier of the value.
        /// </summary>
        internal KeyVaultSettingType? SettingType { get; }

        /// <summary>
        /// Gets the boolean value of this account setting if <see cref="Type"/> is <see cref="KeyVaultSettingType.Boolean"/>.
        /// </summary>
        /// <returns>A boolean value if <see cref="Type"/> is <see cref="KeyVaultSettingType.Boolean"/>.</returns>
        /// <exception cref="InvalidOperationException">The <see cref="Type"/> is not <see cref="KeyVaultSettingType.Boolean"/>, or the value cannot be normalized as a Boolean.</exception>
        public bool AsBoolean() => CheckType(KeyVaultSettingType.Boolean, ValueBool);

        /// <summary>
        /// Gets the raw string value of this account setting.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string conversionMethod = null;
            if (SettingType == KeyVaultSettingType.Boolean)
            {
                conversionMethod = nameof(AsBoolean);
            }

            return conversionMethod == null
                ? $"{nameof(KeyVaultSetting)}: {nameof(SettingType)}={SettingType}"
                : $"{nameof(KeyVaultSetting)}: {nameof(SettingType)}={SettingType}, {conversionMethod}()=>Value";
        }

        internal string Serialize()
        {
            if (SettingType == KeyVaultSettingType.Boolean)
            {
                // bool.ToString() returns "True" or "False", but the service wants "true" or "false".
                return ValueBool.Value ? "true" : "false";
            }

            // A value is required.
            return ValueString ?? string.Empty;
        }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private bool? ValueBool { get; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string ValueString { get; }

        private T CheckType<T>(KeyVaultSettingType expectedType, T? value) where T : struct
        {
            if (SettingType != expectedType)
            {
                throw new InvalidOperationException($"Cannot get setting as {expectedType}. Setting type is {SettingType}.");
            }

            return value.Value;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static InvalidOperationException InvalidSettingType(KeyVaultSettingType expectedType) =>
            new($"Cannot normalize the setting as {expectedType}. Use '{nameof(KeyVaultSetting)}.{nameof(KeyVaultSetting.Content)}' for a textual representation of the setting.");
    }
}
