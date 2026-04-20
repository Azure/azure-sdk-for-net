// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataBoxEdge.Models
{
    // In the old SDK (autorest-based), these types were plain models returned directly by device resource methods.
    // In the new SDK (TypeSpec-based), they are full ARM sub-resources with their own resource classes
    // (DataBoxEdgeDeviceCapacityInfoResource) and data classes (DataBoxEdgeDeviceCapacityInfoData).
    // These stubs are kept only for ApiCompat backward compatibility. All members throw NotSupportedException
    // at runtime; callers should migrate to GetDataBoxEdgeDeviceCapacityInfo().Get().Data.
    /// <summary>
    /// Object for capturing device capacity info.
    /// This class is obsolete; use <see cref="DataBoxEdgeDeviceCapacityInfoData"/> via
    /// <c>GetDataBoxEdgeDeviceCapacityInfo().Get().Data</c> instead.
    /// </summary>
    [Obsolete("Use DataBoxEdgeDeviceCapacityInfoData via GetDataBoxEdgeDeviceCapacityInfo().Get().Data instead.", false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class DataBoxEdgeDeviceCapacityInfo : ResourceData, IJsonModel<DataBoxEdgeDeviceCapacityInfo>
    {
        /// <summary> Initializes a new instance of <see cref="DataBoxEdgeDeviceCapacityInfo"/>. </summary>
        public DataBoxEdgeDeviceCapacityInfo() { }

        /// <summary> Timestamp of request in UTC. </summary>
        public DateTimeOffset? TimeStamp { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Cluster capacity data for storage resources (CSV). </summary>
        public EdgeClusterStorageViewInfo ClusterStorageCapacityInfo { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> Cluster capacity data for compute resources (Memory and GPU). </summary>
        public EdgeClusterCapacityViewInfo ClusterComputeCapacityInfo { get => throw new NotSupportedException(); set => throw new NotSupportedException(); }
        /// <summary> The dictionary of individual node names and node capacities in the cluster. </summary>
        public IDictionary<string, HostCapacity> NodeCapacityInfos { get => throw new NotSupportedException(); }

        /// <inheritdoc/>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();

        DataBoxEdgeDeviceCapacityInfo IJsonModel<DataBoxEdgeDeviceCapacityInfo>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        void IJsonModel<DataBoxEdgeDeviceCapacityInfo>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        DataBoxEdgeDeviceCapacityInfo IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        string IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
        BinaryData IPersistableModel<DataBoxEdgeDeviceCapacityInfo>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException();
    }
}