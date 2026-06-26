// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.ComponentModel;
using System.Text.Json;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    // Generated code only emits extensible-enum CLR types that are still referenced by the current TypeSpec model graph; this previous GA enum name is no longer generated, but existing public signatures still reference it. Keep the enum wrapper so constants, conversions, and equality remain source-compatible.
    /// <summary>
    /// Provides a compatibility shim for the AuthenticationDetailsProperties class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public abstract partial class AuthenticationDetailsProperties : IJsonModel<AuthenticationDetailsProperties>, IPersistableModel<AuthenticationDetailsProperties>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationDetailsProperties"/> type for compatibility with the previous public API surface.
        /// </summary>
        protected AuthenticationDetailsProperties() { }
        /// <summary>
        /// Gets the AuthenticationProvisioningState value preserved from the previous public API surface.
        /// </summary>
        public AuthenticationProvisioningState? AuthenticationProvisioningState { get; }
        /// <summary>
        /// Gets the GrantedPermissions value preserved from the previous public API surface.
        /// </summary>
        public System.Collections.Generic.IReadOnlyList<SecurityCenterCloudPermission> GrantedPermissions { get; }
        /// <summary>
        /// Provides a compatibility shim for the JsonModelWriteCore operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="writer">The value preserved for API compatibility.</param>
        /// <param name="options">The value preserved for API compatibility.</param>
        protected virtual void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AuthenticationDetailsProperties IJsonModel<AuthenticationDetailsProperties>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        void IJsonModel<AuthenticationDetailsProperties>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) { }
        AuthenticationDetailsProperties IPersistableModel<AuthenticationDetailsProperties>.Create(System.BinaryData data, ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        string IPersistableModel<AuthenticationDetailsProperties>.GetFormatFromOptions(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
        System.BinaryData IPersistableModel<AuthenticationDetailsProperties>.Write(ModelReaderWriterOptions options) { throw new NotSupportedException("This API is no longer supported by the service."); }
    }
    /// <summary>
    /// Provides a compatibility shim for the AuthenticationProvisioningState structure.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public readonly partial struct AuthenticationProvisioningState : IEquatable<AuthenticationProvisioningState>
    {
        private readonly string _value;
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationProvisioningState"/> type for compatibility with the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        public AuthenticationProvisioningState(string value) => _value = value ?? throw new ArgumentNullException(nameof(value));
        /// <summary>
        /// Gets the Expired value preserved from the previous public API surface.
        /// </summary>
        public static AuthenticationProvisioningState Expired { get; } = new AuthenticationProvisioningState("Expired");
        /// <summary>
        /// Gets the IncorrectPolicy value preserved from the previous public API surface.
        /// </summary>
        public static AuthenticationProvisioningState IncorrectPolicy { get; } = new AuthenticationProvisioningState("IncorrectPolicy");
        /// <summary>
        /// Gets the Invalid value preserved from the previous public API surface.
        /// </summary>
        public static AuthenticationProvisioningState Invalid { get; } = new AuthenticationProvisioningState("Invalid");
        /// <summary>
        /// Gets the Valid value preserved from the previous public API surface.
        /// </summary>
        public static AuthenticationProvisioningState Valid { get; } = new AuthenticationProvisioningState("Valid");
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="other">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public bool Equals(AuthenticationProvisioningState other) => string.Equals(_value, other._value, StringComparison.InvariantCultureIgnoreCase);
        /// <summary>
        /// Provides a compatibility shim for the Equals operation preserved from the previous public API surface.
        /// </summary>
        /// <param name="obj">The value preserved for API compatibility.</param>
        /// <returns>The compatibility result.</returns>
        public override bool Equals(object obj) => obj is AuthenticationProvisioningState other && Equals(other);
        /// <summary>
        /// Provides a compatibility shim for the GetHashCode operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override int GetHashCode() => _value != null ? StringComparer.InvariantCultureIgnoreCase.GetHashCode(_value) : 0;
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator ==(AuthenticationProvisioningState left, AuthenticationProvisioningState right) => left.Equals(right);
        /// <summary>
        /// Provides a compatibility conversion operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="value">The value preserved for API compatibility.</param>
        /// <returns>The converted compatibility value.</returns>
        public static implicit operator AuthenticationProvisioningState(string value) => new AuthenticationProvisioningState(value);
        /// <summary>
        /// Provides a compatibility operator preserved from the previous public API surface.
        /// </summary>
        /// <param name="left">The value used by the compatibility operator.</param>
        /// <param name="right">The value used by the compatibility operator.</param>
        /// <returns>The compatibility operator result.</returns>
        public static bool operator !=(AuthenticationProvisioningState left, AuthenticationProvisioningState right) => !left.Equals(right);
        /// <summary>
        /// Provides a compatibility shim for the ToString operation preserved from the previous public API surface.
        /// </summary>
        /// <returns>The compatibility result.</returns>
        public override string ToString() => _value ?? string.Empty;
    }
}
