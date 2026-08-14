// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using System.Runtime.Serialization;

namespace Azure.Provisioning.EventGrid;

/// <summary>
/// Alternative authentication name sources related to client authentication
/// settings for namespace resource.
/// </summary>
[EditorBrowsable(EditorBrowsableState.Never)] // Removed from Preview
public enum AlternativeAuthenticationNameSource
{
    /// <summary>
    /// ClientCertificateSubject.
    /// </summary>
    ClientCertificateSubject,

    /// <summary>
    /// ClientCertificateDns.
    /// </summary>
    ClientCertificateDns,

    /// <summary>
    /// ClientCertificateUri.
    /// </summary>
    ClientCertificateUri,

    /// <summary>
    /// ClientCertificateIp.
    /// </summary>
    [DataMember(Name = "ClientCertificateIp")]
    ClientCertificateIP,

    /// <summary>
    /// ClientCertificateEmail.
    /// </summary>
    ClientCertificateEmail,
}
