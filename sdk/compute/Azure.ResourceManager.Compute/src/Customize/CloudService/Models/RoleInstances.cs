// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class RoleInstances : IJsonModel<RoleInstances>, IPersistableModel<RoleInstances>
    {
        /// <summary> Initializes a new instance of RoleInstances. </summary>
        /// <param name="roleInstancesValue"> The role instances. </param>
        public RoleInstances(IEnumerable<string> roleInstancesValue)
        {
            RoleInstancesValue = roleInstancesValue != null ? new List<string>(roleInstancesValue) : new List<string>();
        }

        /// <summary> The role instances. </summary>
        public IList<string> RoleInstancesValue { get; }

        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        RoleInstances IJsonModel<RoleInstances>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        void IJsonModel<RoleInstances>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        RoleInstances IPersistableModel<RoleInstances>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");

        string IPersistableModel<RoleInstances>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<RoleInstances>.Write(ModelReaderWriterOptions options)
            => throw new NotSupportedException("CloudService operations are no longer supported.");
    }
}
