// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Monitor.Models;

namespace Azure.ResourceManager.Monitor
{
    /// <summary> A class representing diagnostic settings category data. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is no longer supported.", false)]
    public partial class DiagnosticSettingsCategoryData : ResourceData, IJsonModel<DiagnosticSettingsCategoryData>, IPersistableModel<DiagnosticSettingsCategoryData>
    {
        /// <summary> Initializes a new instance of <see cref="DiagnosticSettingsCategoryData"/>. </summary>
        public DiagnosticSettingsCategoryData()
        {
        }

        /// <summary> The collection of what category groups are supported. </summary>
        public IList<string> CategoryGroups { get; }

        /// <summary> The type of the diagnostic settings category. </summary>
        public MonitorCategoryType? CategoryType { get; set; }

        void IJsonModel<DiagnosticSettingsCategoryData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingsCategoryData IJsonModel<DiagnosticSettingsCategoryData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        BinaryData IPersistableModel<DiagnosticSettingsCategoryData>.Write(ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        DiagnosticSettingsCategoryData IPersistableModel<DiagnosticSettingsCategoryData>.Create(BinaryData data, ModelReaderWriterOptions options) => throw new NotSupportedException("This API is no longer supported.");

        string IPersistableModel<DiagnosticSettingsCategoryData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
