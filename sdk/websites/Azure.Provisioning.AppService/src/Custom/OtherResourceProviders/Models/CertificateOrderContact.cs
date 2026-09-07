// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppService;

/// <summary>
/// The CertificateOrderContact.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public partial class CertificateOrderContact : ProvisionableConstruct
{
    /// <summary>
    /// Gets the email.
    /// </summary>
    public BicepValue<string> Email
    {
        get { Initialize(); return _email; }
    }
    private BicepValue<string> _email;

    /// <summary>
    /// Gets the name first.
    /// </summary>
    public BicepValue<string> NameFirst
    {
        get { Initialize(); return _nameFirst; }
    }
    private BicepValue<string> _nameFirst;

    /// <summary>
    /// Gets the name last.
    /// </summary>
    public BicepValue<string> NameLast
    {
        get { Initialize(); return _nameLast; }
    }
    private BicepValue<string> _nameLast;

    /// <summary>
    /// Gets the phone.
    /// </summary>
    public BicepValue<string> Phone
    {
        get { Initialize(); return _phone; }
    }
    private BicepValue<string> _phone;

    /// <summary>
    /// Creates a new CertificateOrderContact.
    /// </summary>
    public CertificateOrderContact()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of CertificateOrderContact.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _email = DefineProperty<string>("Email", ["email"], isOutput: true);
        _nameFirst = DefineProperty<string>("NameFirst", ["nameFirst"], isOutput: true);
        _nameLast = DefineProperty<string>("NameLast", ["nameLast"], isOutput: true);
        _phone = DefineProperty<string>("Phone", ["phone"], isOutput: true);
    }
}
