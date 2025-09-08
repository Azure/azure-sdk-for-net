// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.MySql
{
    public partial class MySqlRecommendationActionResource : IJsonModel<MySqlRecommendationActionData>
    {
        private static MySqlRecommendationActionData s_dataDeserializationInstance;
        private static MySqlRecommendationActionData DataDeserializationInstance => s_dataDeserializationInstance ??= new();

        void IJsonModel<MySqlRecommendationActionData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => ((IJsonModel<MySqlRecommendationActionData>)Data).Write(writer, options);

        MySqlRecommendationActionData IJsonModel<MySqlRecommendationActionData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) => ((IJsonModel<MySqlRecommendationActionData>)DataDeserializationInstance).Create(ref reader, options);

        BinaryData IPersistableModel<MySqlRecommendationActionData>.Write(ModelReaderWriterOptions options) => ModelReaderWriter.Write<MySqlRecommendationActionData>(Data, options, AzureResourceManagerMySqlContext.Default);

        MySqlRecommendationActionData IPersistableModel<MySqlRecommendationActionData>.Create(BinaryData data, ModelReaderWriterOptions options) => ModelReaderWriter.Read<MySqlRecommendationActionData>(data, options, AzureResourceManagerMySqlContext.Default);

        string IPersistableModel<MySqlRecommendationActionData>.GetFormatFromOptions(ModelReaderWriterOptions options) => ((IPersistableModel<MySqlRecommendationActionData>)DataDeserializationInstance).GetFormatFromOptions(options);
    }
}