// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // FINDING (2026-05): The header comment previously claimed v1.15.0 exposed bare
    // names (UnixReadOnly, Cifs, Nfsv3, etc.) and that these shims preserve backcompat
    // for that surface. That premise is INCORRECT. Inspection of the v1.15.0 GA tag
    // (Azure.ResourceManager.NetApp_1.15.0) shows the released API already used
    // `IsUnixReadOnly`, `IsKerberos5*ReadOnly/ReadWrite`, `AllowCifsProtocol`,
    // `AllowNfsV3Protocol`, `AllowNfsV41Protocol` — i.e. the SAME names the new
    // generator currently produces. The bare-name properties below were never part of
    // any released NetApp SDK surface, so they are NOT required for ApiCompat.
    //
    // This whole file should be deleted as part of a follow-up regen pass. It is left
    // in place for this PR only to keep the diff focused on review feedback. New code
    // (tests, samples, customizations) MUST use the generated `Is*` / `Allow*Protocol`
    // names rather than the shims below.
    public partial class NetAppVolumeExportPolicyRule
    {
        // Formerly UnixReadOnly; renamed to IsUnixReadOnly.
        /// <summary> Compatibility alias for <see cref="IsUnixReadOnly"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UnixReadOnly
        {
            get => IsUnixReadOnly;
            set => IsUnixReadOnly = value;
        }

        // Formerly UnixReadWrite; renamed to IsUnixReadWrite.
        /// <summary> Compatibility alias for <see cref="IsUnixReadWrite"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? UnixReadWrite
        {
            get => IsUnixReadWrite;
            set => IsUnixReadWrite = value;
        }

        // Formerly Kerberos5ReadOnly; renamed to IsKerberos5ReadOnly.
        /// <summary> Compatibility alias for <see cref="IsKerberos5ReadOnly"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5ReadOnly
        {
            get => IsKerberos5ReadOnly;
            set => IsKerberos5ReadOnly = value;
        }

        // Formerly Kerberos5ReadWrite; renamed to IsKerberos5ReadWrite.
        /// <summary> Compatibility alias for <see cref="IsKerberos5ReadWrite"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5ReadWrite
        {
            get => IsKerberos5ReadWrite;
            set => IsKerberos5ReadWrite = value;
        }

        // Formerly Kerberos5IReadOnly; renamed to IsKerberos5iReadOnly.
        /// <summary> Compatibility alias for <see cref="IsKerberos5iReadOnly"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5IReadOnly
        {
            get => IsKerberos5iReadOnly;
            set => IsKerberos5iReadOnly = value;
        }

        // Formerly Kerberos5IReadWrite; renamed to IsKerberos5iReadWrite.
        /// <summary> Compatibility alias for <see cref="IsKerberos5iReadWrite"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5IReadWrite
        {
            get => IsKerberos5iReadWrite;
            set => IsKerberos5iReadWrite = value;
        }

        // Formerly Kerberos5PReadOnly; renamed to IsKerberos5pReadOnly.
        /// <summary> Compatibility alias for <see cref="IsKerberos5pReadOnly"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5PReadOnly
        {
            get => IsKerberos5pReadOnly;
            set => IsKerberos5pReadOnly = value;
        }

        // Formerly Kerberos5PReadWrite; renamed to IsKerberos5pReadWrite.
        /// <summary> Compatibility alias for <see cref="IsKerberos5pReadWrite"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Kerberos5PReadWrite
        {
            get => IsKerberos5pReadWrite;
            set => IsKerberos5pReadWrite = value;
        }

        // Formerly Cifs; renamed to AllowCifsProtocol.
        /// <summary> Compatibility alias for <see cref="AllowCifsProtocol"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Cifs
        {
            get => AllowCifsProtocol;
            set => AllowCifsProtocol = value;
        }

        // Formerly Nfsv3; renamed to AllowNfsV3Protocol.
        /// <summary> Compatibility alias for <see cref="AllowNfsV3Protocol"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Nfsv3
        {
            get => AllowNfsV3Protocol;
            set => AllowNfsV3Protocol = value;
        }

        // Formerly Nfsv41; renamed to AllowNfsV41Protocol.
        /// <summary> Compatibility alias for <see cref="AllowNfsV41Protocol"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Nfsv41
        {
            get => AllowNfsV41Protocol;
            set => AllowNfsV41Protocol = value;
        }
    }
}
