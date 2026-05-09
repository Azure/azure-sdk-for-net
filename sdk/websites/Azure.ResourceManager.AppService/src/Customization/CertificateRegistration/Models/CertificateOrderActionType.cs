// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Action type. </summary>
    [Obsolete("All certificate registration APIs are moved to the new Azure.ResourceManager.CertificateRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum CertificateOrderActionType
    {
        /// <summary> Unknown. </summary>
        Unknown,
        /// <summary> CertificateIssued. </summary>
        CertificateIssued,
        /// <summary> CertificateOrderCanceled. </summary>
        CertificateOrderCanceled,
        /// <summary> CertificateOrderCreated. </summary>
        CertificateOrderCreated,
        /// <summary> CertificateRevoked. </summary>
        CertificateRevoked,
        /// <summary> DomainValidationComplete. </summary>
        DomainValidationComplete,
        /// <summary> FraudDetected. </summary>
        FraudDetected,
        /// <summary> OrgNameChange. </summary>
        OrgNameChange,
        /// <summary> OrgValidationComplete. </summary>
        OrgValidationComplete,
        /// <summary> SanDrop. </summary>
        SanDrop,
        /// <summary> FraudCleared. </summary>
        FraudCleared,
        /// <summary> CertificateExpired. </summary>
        CertificateExpired,
        /// <summary> CertificateExpirationWarning. </summary>
        CertificateExpirationWarning,
        /// <summary> FraudDocumentationRequired. </summary>
        FraudDocumentationRequired
    }
}
