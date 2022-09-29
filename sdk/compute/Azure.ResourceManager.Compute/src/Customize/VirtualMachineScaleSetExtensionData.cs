// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Compute.Models;

namespace Azure.ResourceManager.Compute
{
    // this piece of customized code adds back the ability to set name of this class in its constructor
    public partial class VirtualMachineScaleSetExtensionData
    {
        /// <summary> Initializes a new instance of VmssExtensionData. </summary>
        /// <param name="name"> The name. </param>
        public VirtualMachineScaleSetExtensionData(string name) : base(default, name, default, default)
        {
        }

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
            get
            {
                string raw;
                using var stream = new MemoryStream();
                using (var writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteObjectValue(KeyVaultProtectedSettings);
                    writer.Flush();
                    raw = Encoding.UTF8.GetString(stream.ToArray());
                }
                return BinaryData.FromBytes(stream.ToArray());
            }
            set
            {
                var jsonElement = value.ToObjectFromJson<JsonElement>();
                KeyVaultProtectedSettings = KeyVaultSecretReference.DeserializeKeyVaultSecretReference(jsonElement);
            }
        }
    }
}
