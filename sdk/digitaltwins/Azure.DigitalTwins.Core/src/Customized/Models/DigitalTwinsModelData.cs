// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Azure.Core;

namespace Azure.DigitalTwins.Core
{
    [CodeGenModel("DigitalTwinsModelData")]
    public partial class DigitalTwinsModelData
    {
        // This class declaration:
        // - Changes the namespace and renames the type from "ModelData" to "DigitalTwinsModelData"
        // - Makes the generated class of the same name declare Model as a **string** rather than an **object**.
        // - Renames Model to DtdlModel.
        // Do not remove.

        /// <summary>
        /// The model definition that conforms to Digital Twins Definition Language (DTDL) v2.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.microsoft.com/en-us/azure/digital-twins/concepts-models">Understand twin models in Azure Digital Twins</see>.
        /// </remarks>
        [CodeGenMember("Model")]
        public string DtdlModel { get; }

        /// <summary>
        /// The date and time the model was uploaded to the service.
        /// </summary>
        [CodeGenMember("UploadTime")]
        public DateTimeOffset? UploadedOn { get; }

        /// <summary> A language dictionary that contains the localized display names as specified in the model definition. </summary>
        [CodeGenMember("DisplayName")]
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(ReadLanguageDisplayNames))]
        public IReadOnlyDictionary<string, string> LanguageDisplayNames { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLanguageDisplayNames(JsonProperty property, ref Optional<IReadOnlyDictionary<string, string>> languageDisplayNames)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            // manual change: deserialize as a dictionary
            languageDisplayNames = JsonSerializer.Deserialize<Dictionary<string, string>>(property.Value.GetRawText());
        }

        /// <summary> A language dictionary that contains the localized descriptions as specified in the model definition. </summary>
        [CodeGenMember("Description")]
        [CodeGenMemberSerializationHooks(DeserializationValueHook = nameof(ReadLanguageDescriptions))]
        public IReadOnlyDictionary<string, string> LanguageDescriptions { get; }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static void ReadLanguageDescriptions(JsonProperty property, ref Optional<IReadOnlyDictionary<string, string>> languageDescriptions)
        {
            if (property.Value.ValueKind == JsonValueKind.Null)
            {
                return;
            }
            // manual change: deserialize as a dictionary
            languageDescriptions = JsonSerializer.Deserialize<Dictionary<string, string>>(property.Value.GetRawText());
        }

        #region null overrides

#pragma warning disable CA1801 // Remove unused parameter

        private DigitalTwinsModelData(string id)
        {
        }

#pragma warning restore CA1801 // Remove unused parameter

        #endregion null overrides
    }
}
