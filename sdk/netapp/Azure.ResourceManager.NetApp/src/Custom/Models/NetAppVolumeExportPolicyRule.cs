// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward compatibility: v1.15.0 exposed the protocol/permission flags with bare
    // names (UnixReadOnly, Cifs, Nfsv3, etc.). They were renamed in this migration to
    // the `Is...`/`Allow...Protocol` style for naming consistency. The old names are
    // preserved here as `[EditorBrowsable(Never)]` forwarding shims so existing user
    // code continues to compile while new code uses the renamed properties.
    public partial class NetAppVolumeExportPolicyRule
    {
        /// <summary> Compatibility shim — formerly <c>UnixReadOnly</c>; use <see cref="IsUnixReadOnly"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UnixReadOnly
        {
            get => IsUnixReadOnly;
            set => IsUnixReadOnly = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UnixReadWrite
        {
            get => IsUnixReadWrite;
            set => IsUnixReadWrite = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5ReadOnly
        {
            get => IsKerberos5ReadOnly;
            set => IsKerberos5ReadOnly = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5ReadWrite
        {
            get => IsKerberos5ReadWrite;
            set => IsKerberos5ReadWrite = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5IReadOnly
        {
            get => IsKerberos5iReadOnly;
            set => IsKerberos5iReadOnly = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5IReadWrite
        {
            get => IsKerberos5iReadWrite;
            set => IsKerberos5iReadWrite = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5PReadOnly
        {
            get => IsKerberos5pReadOnly;
            set => IsKerberos5pReadOnly = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5PReadWrite
        {
            get => IsKerberos5pReadWrite;
            set => IsKerberos5pReadWrite = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Cifs
        {
            get => AllowCifsProtocol;
            set => AllowCifsProtocol = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Nfsv3
        {
            get => AllowNfsV3Protocol;
            set => AllowNfsV3Protocol = value;
        }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Nfsv41
        {
            get => AllowNfsV41Protocol;
            set => AllowNfsV41Protocol = value;
        }
    }
}
