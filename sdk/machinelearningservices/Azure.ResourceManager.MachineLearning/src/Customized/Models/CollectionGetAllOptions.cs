// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat options types are grouped to keep related shims together.
#pragma warning disable SA1649 // The grouped shim file intentionally contains multiple legacy options types.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.ResourceManager.MachineLearning;

namespace Azure.ResourceManager.MachineLearning.Models
{
    /// <summary> Optional parameters for listing machine learning datastore resources. </summary>
    public class MachineLearningDatastoreCollectionGetAllOptions
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Number of items to retrieve. </summary>
        [WirePath("count")]
        public int? Count { get; set; }
        /// <summary> Whether to list default datastores. </summary>
        [WirePath("isDefault")]
        public bool? IsDefault { get; set; }
        /// <summary> Datastore names to filter by. </summary>
        [WirePath("names")]
        public IList<string> Names { get; set; }
        /// <summary> Search text. </summary>
        [WirePath("searchText")]
        public string SearchText { get; set; }
        /// <summary> Field to order by. </summary>
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        /// <summary> Whether ordering is ascending. </summary>
        [WirePath("orderByAsc")]
        public bool? OrderByAsc { get; set; }
    }

    /// <summary> Optional parameters for listing machine learning feature resources. </summary>
    public class MachineLearningFeatureCollectionGetAllOptions
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> Feature name filter. </summary>
        [WirePath("featureName")]
        public string FeatureName { get; set; }
        /// <summary> Description filter. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> List view type. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> Page size. </summary>
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
    }

    /// <summary> Optional parameters for listing machine learning feature set containers. </summary>
    public class MachineLearningFeatureSetContainerCollectionGetAllOptions : MachineLearningNamedCollectionGetAllOptions { }

    /// <summary> Optional parameters for listing machine learning feature store entity containers. </summary>
    public class MachineLearningFeatureStoreEntityContainerCollectionGetAllOptions : MachineLearningNamedCollectionGetAllOptions { }

    /// <summary> Optional parameters for listing machine learning feature set versions. </summary>
    public class MachineLearningFeatureSetVersionCollectionGetAllOptions : MachineLearningVersionedCollectionGetAllOptions { }

    /// <summary> Optional parameters for listing machine learning feature store entity versions. </summary>
    public class MachineLearningFeaturestoreEntityVersionCollectionGetAllOptions : MachineLearningVersionedCollectionGetAllOptions { }

    /// <summary> Optional parameters for listing machine learning model versions. </summary>
    public class MachineLearningModelVersionCollectionGetAllOptions
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Field to order by. </summary>
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        /// <summary> Maximum result count. </summary>
        [WirePath("top")]
        public int? Top { get; set; }
        /// <summary> Version filter. </summary>
        [WirePath("version")]
        public string Version { get; set; }
        /// <summary> Description filter. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Offset. </summary>
        [WirePath("offset")]
        public int? Offset { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> Properties filter. </summary>
        [WirePath("properties")]
        public string Properties { get; set; }
        /// <summary> Feed filter. </summary>
        [WirePath("feed")]
        public string Feed { get; set; }
        /// <summary> List view type. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
    }

    /// <summary> Optional parameters for listing machine learning registry model versions. </summary>
    public class MachineLearningRegistryModelVersionCollectionGetAllOptions
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Field to order by. </summary>
        [WirePath("orderBy")]
        public string OrderBy { get; set; }
        /// <summary> Maximum result count. </summary>
        [WirePath("top")]
        public int? Top { get; set; }
        /// <summary> Version filter. </summary>
        [WirePath("version")]
        public string Version { get; set; }
        /// <summary> Description filter. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> Properties filter. </summary>
        [WirePath("properties")]
        public string Properties { get; set; }
        /// <summary> List view type. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
    }

    /// <summary> Optional parameters for listing machine learning online endpoints. </summary>
    public class MachineLearningOnlineEndpointCollectionGetAllOptions
    {
        /// <summary> Name filter. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> Number of items to retrieve. </summary>
        [WirePath("count")]
        public int? Count { get; set; }
        /// <summary> Compute type filter. </summary>
        [WirePath("computeType")]
        public MachineLearningEndpointComputeType? ComputeType { get; set; }
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> Properties filter. </summary>
        [WirePath("properties")]
        public string Properties { get; set; }
        /// <summary> Field to order by. </summary>
        [WirePath("orderBy")]
        public MachineLearningOrderString? OrderBy { get; set; }
    }

    /// <summary> Shared optional parameters for listing named feature resources. </summary>
    public class MachineLearningNamedCollectionGetAllOptions : IJsonModel<MachineLearningNamedCollectionGetAllOptions>
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> List view type. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> Page size. </summary>
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        /// <summary> Name filter. </summary>
        [WirePath("name")]
        public string Name { get; set; }
        /// <summary> Description filter. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Created-by filter. </summary>
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }

        void IJsonModel<MachineLearningNamedCollectionGetAllOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Skip is not null)
                writer.WriteString("skip", Skip);
            if (Tags is not null)
                writer.WriteString("tags", Tags);
            if (ListViewType.HasValue)
                writer.WriteString("listViewType", ListViewType.Value.ToString());
            if (PageSize.HasValue)
                writer.WriteNumber("pageSize", PageSize.Value);
            if (Name is not null)
                writer.WriteString("name", Name);
            if (Description is not null)
                writer.WriteString("description", Description);
            if (CreatedBy is not null)
                writer.WriteString("createdBy", CreatedBy);
            writer.WriteEndObject();
        }

        MachineLearningNamedCollectionGetAllOptions IJsonModel<MachineLearningNamedCollectionGetAllOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeNamedOptions(document.RootElement);
        }

        BinaryData IPersistableModel<MachineLearningNamedCollectionGetAllOptions>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<MachineLearningNamedCollectionGetAllOptions>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        MachineLearningNamedCollectionGetAllOptions IPersistableModel<MachineLearningNamedCollectionGetAllOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeNamedOptions(document.RootElement);
        }

        string IPersistableModel<MachineLearningNamedCollectionGetAllOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningNamedCollectionGetAllOptions DeserializeNamedOptions(JsonElement element)
        {
            var result = new MachineLearningNamedCollectionGetAllOptions();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("skip"u8))
                    result.Skip = property.Value.GetString();
                else if (property.NameEquals("tags"u8))
                    result.Tags = property.Value.GetString();
                else if (property.NameEquals("listViewType"u8))
                    result.ListViewType = property.Value.GetString();
                else if (property.NameEquals("pageSize"u8))
                    result.PageSize = property.Value.GetInt32();
                else if (property.NameEquals("name"u8))
                    result.Name = property.Value.GetString();
                else if (property.NameEquals("description"u8))
                    result.Description = property.Value.GetString();
                else if (property.NameEquals("createdBy"u8))
                    result.CreatedBy = property.Value.GetString();
            }
            return result;
        }
    }

    /// <summary> Shared optional parameters for listing versioned feature resources. </summary>
    public class MachineLearningVersionedCollectionGetAllOptions : IJsonModel<MachineLearningVersionedCollectionGetAllOptions>
    {
        /// <summary> Continuation token for pagination. </summary>
        [WirePath("skip")]
        public string Skip { get; set; }
        /// <summary> Comma-separated tag filter. </summary>
        [WirePath("tags")]
        public string Tags { get; set; }
        /// <summary> List view type. </summary>
        [WirePath("listViewType")]
        public MachineLearningListViewType? ListViewType { get; set; }
        /// <summary> Page size. </summary>
        [WirePath("pageSize")]
        public int? PageSize { get; set; }
        /// <summary> Version name filter. </summary>
        [WirePath("versionName")]
        public string VersionName { get; set; }
        /// <summary> Version filter. </summary>
        [WirePath("version")]
        public string Version { get; set; }
        /// <summary> Description filter. </summary>
        [WirePath("description")]
        public string Description { get; set; }
        /// <summary> Created-by filter. </summary>
        [WirePath("createdBy")]
        public string CreatedBy { get; set; }
        /// <summary> Stage filter. </summary>
        [WirePath("stage")]
        public string Stage { get; set; }

        void IJsonModel<MachineLearningVersionedCollectionGetAllOptions>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (Skip is not null)
                writer.WriteString("skip", Skip);
            if (Tags is not null)
                writer.WriteString("tags", Tags);
            if (ListViewType.HasValue)
                writer.WriteString("listViewType", ListViewType.Value.ToString());
            if (PageSize.HasValue)
                writer.WriteNumber("pageSize", PageSize.Value);
            if (VersionName is not null)
                writer.WriteString("versionName", VersionName);
            if (Version is not null)
                writer.WriteString("version", Version);
            if (Description is not null)
                writer.WriteString("description", Description);
            if (CreatedBy is not null)
                writer.WriteString("createdBy", CreatedBy);
            if (Stage is not null)
                writer.WriteString("stage", Stage);
            writer.WriteEndObject();
        }

        MachineLearningVersionedCollectionGetAllOptions IJsonModel<MachineLearningVersionedCollectionGetAllOptions>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeVersionedOptions(document.RootElement);
        }

        BinaryData IPersistableModel<MachineLearningVersionedCollectionGetAllOptions>.Write(ModelReaderWriterOptions options)
        {
            using var stream = new MemoryStream();
            using (var writer = new Utf8JsonWriter(stream))
            {
                ((IJsonModel<MachineLearningVersionedCollectionGetAllOptions>)this).Write(writer, options);
            }
            return BinaryData.FromBytes(stream.ToArray());
        }

        MachineLearningVersionedCollectionGetAllOptions IPersistableModel<MachineLearningVersionedCollectionGetAllOptions>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using JsonDocument document = JsonDocument.Parse(data, ModelSerializationExtensions.JsonDocumentOptions);
            return DeserializeVersionedOptions(document.RootElement);
        }

        string IPersistableModel<MachineLearningVersionedCollectionGetAllOptions>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        private static MachineLearningVersionedCollectionGetAllOptions DeserializeVersionedOptions(JsonElement element)
        {
            var result = new MachineLearningVersionedCollectionGetAllOptions();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("skip"u8))
                    result.Skip = property.Value.GetString();
                else if (property.NameEquals("tags"u8))
                    result.Tags = property.Value.GetString();
                else if (property.NameEquals("listViewType"u8))
                    result.ListViewType = property.Value.GetString();
                else if (property.NameEquals("pageSize"u8))
                    result.PageSize = property.Value.GetInt32();
                else if (property.NameEquals("versionName"u8))
                    result.VersionName = property.Value.GetString();
                else if (property.NameEquals("version"u8))
                    result.Version = property.Value.GetString();
                else if (property.NameEquals("description"u8))
                    result.Description = property.Value.GetString();
                else if (property.NameEquals("createdBy"u8))
                    result.CreatedBy = property.Value.GetString();
                else if (property.NameEquals("stage"u8))
                    result.Stage = property.Value.GetString();
            }
            return result;
        }
    }
}

#pragma warning restore SA1649
#pragma warning restore SA1402
