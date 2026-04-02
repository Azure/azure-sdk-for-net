// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System.ComponentModel;
using System.ClientModel.Primitives;
using System.Text.Json;

namespace Azure.ResourceManager.ContainerInstance.Models
{    /// <summary> Backward-compatible alias for UpdateProfile. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NGroupUpdateProfile : UpdateProfile,
        IJsonModel<NGroupUpdateProfile>, IPersistableModel<NGroupUpdateProfile>
    {
        /// <summary> Initializes a new instance of <see cref="NGroupUpdateProfile"/>. </summary>
        public NGroupUpdateProfile() : base() { }
        NGroupUpdateProfile IJsonModel<NGroupUpdateProfile>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UpdateProfile directly.");
        void IJsonModel<NGroupUpdateProfile>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<UpdateProfile>)this).Write(writer, options);
        NGroupUpdateProfile IPersistableModel<NGroupUpdateProfile>.Create(System.BinaryData data, ModelReaderWriterOptions options)
            => throw new System.NotSupportedException("Backward compat type - use UpdateProfile directly.");
        string IPersistableModel<NGroupUpdateProfile>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<UpdateProfile>)this).GetFormatFromOptions(options);
        System.BinaryData IPersistableModel<NGroupUpdateProfile>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<UpdateProfile>)this).Write(options);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public new NGroupRollingUpdateProfile RollingUpdateProfile
        {
            get => default;
            set => base.RollingUpdateProfile = value;
        }
    }
}
