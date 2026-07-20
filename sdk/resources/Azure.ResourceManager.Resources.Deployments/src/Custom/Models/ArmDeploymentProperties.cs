// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class ArmDeploymentProperties
    {
        // NOTE: The type of the Parameters property is changed from BinaryData to IDictionary<string, ArmDeploymentParameterValue>, this customization is intentionally kept for backward compatibility.
        /// <summary>
        /// Name and value pairs that define the deployment parameters for the template. You use this element when you want to provide the parameter values directly in the request rather than link to an existing parameter file. Use either the parametersLink property or the parameters property, but not both. It can be a JObject or a well formed JSON string.
        /// <para>
        /// This property redirects to <see cref="DeploymentParameters"/>; getting it serializes the dictionary to JSON, and setting it parses the JSON into the dictionary.
        /// </para>
        /// <para>
        /// To assign an object to this property use <see cref="BinaryData.FromObjectAsJson{T}(T, System.Text.Json.JsonSerializerOptions?)"/>.
        /// </para>
        /// <para>
        /// To assign an already formatted json string to this property use <see cref="BinaryData.FromString(string)"/>.
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
        [WirePath("parameters")]
        public BinaryData Parameters
        {
            get
            {
                if (DeploymentParameters == null || DeploymentParameters.Count == 0)
                {
                    return null;
                }
                using MemoryStream stream = new MemoryStream();
                using (Utf8JsonWriter writer = new Utf8JsonWriter(stream))
                {
                    writer.WriteStartObject();
                    foreach (var kvp in DeploymentParameters)
                    {
                        writer.WritePropertyName(kvp.Key);
                        if (kvp.Value == null)
                        {
                            writer.WriteNullValue();
                        }
                        else
                        {
                            ((IJsonModel<ArmDeploymentParameterValue>)kvp.Value).Write(writer, ModelSerializationExtensions.WireOptions);
                        }
                    }
                    writer.WriteEndObject();
                }
                return BinaryData.FromBytes(stream.ToArray());
            }
            set
            {
                DeploymentParameters.Clear();
                if (value == null)
                {
                    return;
                }
                using JsonDocument document = JsonDocument.Parse(value.ToMemory());
                if (document.RootElement.ValueKind == JsonValueKind.Null)
                {
                    return;
                }
                foreach (JsonProperty property in document.RootElement.EnumerateObject())
                {
                    DeploymentParameters[property.Name] = property.Value.ValueKind == JsonValueKind.Null
                        ? null
                        : ArmDeploymentParameterValue.DeserializeArmDeploymentParameterValue(property.Value, ModelSerializationExtensions.WireOptions);
                }
            }
        }
    }
}
