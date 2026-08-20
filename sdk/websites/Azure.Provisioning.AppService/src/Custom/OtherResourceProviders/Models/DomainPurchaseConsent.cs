// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Provisioning;
using Azure.Provisioning.Primitives;

namespace Azure.Provisioning.AppService;

/// <summary>
/// Domain purchase consent object, representing acceptance of applicable legal
/// agreements.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("This type is deprecated and it will be removed in a future version.")]
public partial class DomainPurchaseConsent : ProvisionableConstruct
{
    /// <summary>
    /// List of applicable legal agreement keys. This list can be retrieved
    /// using ListLegalAgreements API under
    /// &lt;code&gt;TopLevelDomain&lt;/code&gt; resource.
    /// </summary>
    public BicepList<string> AgreementKeys
    {
        get { Initialize(); return _agreementKeys; }
        set { Initialize(); _agreementKeys.Assign(value); }
    }
    private BicepList<string> _agreementKeys;

    /// <summary>
    /// Client IP address.
    /// </summary>
    public BicepValue<string> AgreedBy
    {
        get { Initialize(); return _agreedBy; }
        set { Initialize(); _agreedBy.Assign(value); }
    }
    private BicepValue<string> _agreedBy;

    /// <summary>
    /// Timestamp when the agreements were accepted.
    /// </summary>
    public BicepValue<DateTimeOffset> AgreedOn
    {
        get { Initialize(); return _agreedOn; }
        set { Initialize(); _agreedOn.Assign(value); }
    }
    private BicepValue<DateTimeOffset> _agreedOn;

    /// <summary>
    /// Creates a new DomainPurchaseConsent.
    /// </summary>
    public DomainPurchaseConsent()
    {
    }

    /// <summary>
    /// Define all the provisionable properties of DomainPurchaseConsent.
    /// </summary>
    protected override void DefineProvisionableProperties()
    {
        base.DefineProvisionableProperties();
        _agreementKeys = DefineListProperty<string>("AgreementKeys", ["agreementKeys"]);
        _agreedBy = DefineProperty<string>("AgreedBy", ["agreedBy"]);
        _agreedOn = DefineProperty<DateTimeOffset>("AgreedOn", ["agreedAt"]);
    }
}
