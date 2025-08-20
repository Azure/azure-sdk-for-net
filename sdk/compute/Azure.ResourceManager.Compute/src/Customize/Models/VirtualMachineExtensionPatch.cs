﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    public partial class VirtualMachineExtensionPatch
    {
        /// <summary>
        /// The extensions protected settings that are passed by reference, and consumed from key vault
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formated json string to this property use <see cref="BinaryData.FromString(string)"/>.
        /// </para>
        /// <para>
        /// Examples:
        /// <list type="bullet">
        /// <item>
        /// <term>BinaryData.FromObjectAsJson("foo")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("\"foo\"")</term>
        /// <description>Creates a payload of "foo".</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromObjectAsJson(new { key = "value" })</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// <item>
        /// <term>BinaryData.FromString("{\"key\": \"value\"}")</term>
        /// <description>Creates a payload of { "key": "value" }.</description>
        /// </item>
        /// </list>
        /// </para>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BinaryData ProtectedSettingsFromKeyVault
        {
            get => BinaryData.FromObjectAsJson(KeyVaultProtectedSettings);
            set => KeyVaultProtectedSettings = value.ToObjectFromJson<KeyVaultSecretReference>();
        }
    }
}
