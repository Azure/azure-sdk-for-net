// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.OracleDatabase
{
    [Microsoft.TypeSpec.Generator.Customizations.CodeGenSerialization(nameof(Plan), SerializationValueHook = nameof(SerializePlan), DeserializationValueHook = nameof(DeserializePlan))]
    public partial class OracleSubscriptionData : ResourceData
    {
        /// <summary> Details of the resource plan. </summary>
        public ArmPlan Plan { get; set; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal void SerializePlan(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            ((IJsonModel<ArmPlan>)Plan).Write(writer, options);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void DeserializePlan(JsonProperty property, ref ArmPlan plan)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            plan = ModelReaderWriter.Read<ArmPlan>(new BinaryData(Encoding.UTF8.GetBytes(property.Value.GetRawText())), null, AzureResourceManagerOracleDatabaseContext.Default);
        }
    }
}
