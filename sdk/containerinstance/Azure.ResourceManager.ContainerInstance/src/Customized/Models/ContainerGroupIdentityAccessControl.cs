// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

// Backward-compat: type alias for renamed type (ApiCompat TypesMustExist + CannotRemoveBaseTypeOrInterface)
// Old name: ContainerGroupIdentityAccessControl, New name: IdentityAccessControl

namespace Azure.ResourceManager.ContainerInstance.Models
{
    /// <summary> Backward compatibility alias for <see cref="IdentityAccessControl"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupIdentityAccessControl : IdentityAccessControl,
        IJsonModel<ContainerGroupIdentityAccessControl>,
        IPersistableModel<ContainerGroupIdentityAccessControl>
    {
        /// <summary> Initializes a new instance of <see cref="ContainerGroupIdentityAccessControl"/>. </summary>
        public ContainerGroupIdentityAccessControl()
        {
        }

        /// <summary> The access level of the identity (compat shim). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ContainerGroupIdentityAccessLevel? Access
        {
            get => base.Access.HasValue ? new ContainerGroupIdentityAccessLevel(base.Access.Value.ToString()) : (ContainerGroupIdentityAccessLevel?)null;
            set => base.Access = value.HasValue ? new IdentityAccessLevel(value.Value.ToString()) : (IdentityAccessLevel?)null;
        }

        ContainerGroupIdentityAccessControl IJsonModel<ContainerGroupIdentityAccessControl>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use IdentityAccessControl for deserialization.");

        void IJsonModel<ContainerGroupIdentityAccessControl>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<IdentityAccessControl>)this).Write(writer, options);

        ContainerGroupIdentityAccessControl IPersistableModel<ContainerGroupIdentityAccessControl>.Create(BinaryData data, ModelReaderWriterOptions options)
            => throw new InvalidOperationException("Use IdentityAccessControl for deserialization.");

        string IPersistableModel<ContainerGroupIdentityAccessControl>.GetFormatFromOptions(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAccessControl>)this).GetFormatFromOptions(options);

        BinaryData IPersistableModel<ContainerGroupIdentityAccessControl>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<IdentityAccessControl>)this).Write(options);
    }
}
