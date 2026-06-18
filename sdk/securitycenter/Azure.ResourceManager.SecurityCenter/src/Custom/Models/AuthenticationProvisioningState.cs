// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS0618
#pragma warning disable CS1591
#pragma warning disable CS0169
#pragma warning disable SA1508
#pragma warning disable SA1516
#pragma warning disable CA1822

namespace Azure.ResourceManager.SecurityCenter.Models
{
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public abstract partial class AuthenticationDetailsProperties : System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>, System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>
    {
        protected AuthenticationDetailsProperties() { }
        public Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState? AuthenticationProvisioningState { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public System.Collections.Generic.IReadOnlyList<Azure.ResourceManager.SecurityCenter.Models.SecurityCenterCloudPermission> GrantedPermissions { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        protected virtual void JsonModelWriteCore(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Create(ref System.Text.Json.Utf8JsonReader reader, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        void System.ClientModel.Primitives.IJsonModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Write(System.Text.Json.Utf8JsonWriter writer, System.ClientModel.Primitives.ModelReaderWriterOptions options) { }
        Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Create(System.BinaryData data, System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        string System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.GetFormatFromOptions(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData System.ClientModel.Primitives.IPersistableModel<Azure.ResourceManager.SecurityCenter.Models.AuthenticationDetailsProperties>.Write(System.ClientModel.Primitives.ModelReaderWriterOptions options) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }

    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public readonly partial struct AuthenticationProvisioningState : System.IEquatable<Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState>
    {
        private readonly object _dummy;
        private readonly int _dummyPrimitive;
        public AuthenticationProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Expired { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState IncorrectPolicy { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Invalid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public static Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState Valid { get { throw new System.NotSupportedException("This API is no longer supported by the service."); } }
        public bool Equals(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState other) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override bool Equals(object obj) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override int GetHashCode() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator ==(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static implicit operator Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState(string value) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public static bool operator !=(Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState left, Azure.ResourceManager.SecurityCenter.Models.AuthenticationProvisioningState right) { throw new System.NotSupportedException("This API is no longer supported by the service."); }
        public override string ToString() { throw new System.NotSupportedException("This API is no longer supported by the service."); }
    }
}
