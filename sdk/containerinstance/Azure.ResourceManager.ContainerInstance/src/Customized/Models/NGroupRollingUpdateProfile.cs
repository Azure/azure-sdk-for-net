// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward-compatible alias for UpdateProfileRollingUpdateProfile. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NGroupRollingUpdateProfile : UpdateProfileRollingUpdateProfile,
        IJsonModel<NGroupRollingUpdateProfile>, IPersistableModel<NGroupRollingUpdateProfile>
    {
        /// <summary> Initializes a new instance of <see cref="NGroupRollingUpdateProfile"/>. </summary>
        public NGroupRollingUpdateProfile() : base() { }
        NGroupRollingUpdateProfile IJsonModel<NGroupRollingUpdateProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UpdateProfileRollingUpdateProfile directly.");
        void IJsonModel<NGroupRollingUpdateProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UpdateProfileRollingUpdateProfile>)this).Write(writer, options);
        NGroupRollingUpdateProfile IPersistableModel<NGroupRollingUpdateProfile>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UpdateProfileRollingUpdateProfile directly.");
        string IPersistableModel<NGroupRollingUpdateProfile>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UpdateProfileRollingUpdateProfile>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<NGroupRollingUpdateProfile>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UpdateProfileRollingUpdateProfile>)this).Write(options);
    }
}
