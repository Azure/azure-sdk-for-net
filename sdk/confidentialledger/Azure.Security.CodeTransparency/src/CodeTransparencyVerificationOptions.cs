// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Specifies how receipts whose issuer domains ARE in the allow list should be enforced.
    /// </summary>
    public enum AllowedDomainVerificationBehavior
    {
        /// <summary>
        /// At least one receipt from any allowed domain must be present and valid (previous behavior when allow list provided).
        /// </summary>
        AnyAllowedDomainPresentAndValid = 0,
        /// <summary>
        /// ALL receipts whose issuer is in the allow list MUST pass verification. Receipts not in the allow list are treated according to <see cref="CodeTransparencyVerificationOptions.NonAllowListedReceiptBehavior"/>.
        /// </summary>
        AllAllowListedReceiptsMustBeValid = 1,
        /// <summary>
        /// There MUST be at least one valid receipt for EACH domain in the allow list (coverage requirement). If a domain has no receipt or only invalid receipts, verification fails.
        /// </summary>
        EachAllowListedDomainMustHaveValidReceipt = 2
    }
    /// <summary>
    /// Specifies behaviors for receipts whose issuer domains are not contained in <see cref="CodeTransparencyVerificationOptions.AllowedIssuerDomains"/>.
    /// </summary>
    public enum NonAllowListedReceiptBehavior
    {
        /// <summary>
        /// Verify receipts even if their issuer domain is not in the allow list.
        /// </summary>
        Verify = 0,
        /// <summary>
        /// Ignore (skip verifying) receipts whose issuer domain is not in the allow list.
        /// </summary>
        Ignore = 1,
        /// <summary>
        /// Fail verification immediately if any receipt exists whose issuer domain is not in the allow list.
        /// </summary>
        FailIfPresent = 2
    }

    /// <summary>
    /// Options controlling <see cref="CodeTransparencyClient.VerifyTransparentStatement(byte[], CodeTransparencyVerificationOptions, CodeTransparencyClientOptions)"/>.
    /// </summary>
    public sealed class CodeTransparencyVerificationOptions
    {
        /// <summary>
        /// Creates a new instance.
        /// </summary>
        public CodeTransparencyVerificationOptions()
        {
        }

        /// <summary>
        /// Gets or sets an allow list of issuer domains. If provided and not empty, at least one receipt must be issued by one of these domains.
        /// Domains are matched case-insensitively.
        /// </summary>
        public IList<string> AllowedIssuerDomains { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the behavior for receipts whose issuer domain is not in <see cref="AllowedIssuerDomains"/>.
        /// Defaults to <see cref="NonAllowListedReceiptBehavior.Verify"/> to preserve current behavior.
        /// </summary>
        public NonAllowListedReceiptBehavior NonAllowListedReceiptBehavior { get; set; } = NonAllowListedReceiptBehavior.Verify;

        /// <summary>
        /// Gets or sets the enforcement behavior for receipts whose issuer domain IS contained in <see cref="AllowedIssuerDomains"/>.
        /// Defaults to <see cref="AllowedDomainVerificationBehavior.AnyAllowedDomainPresentAndValid"/>.
        /// </summary>
        public AllowedDomainVerificationBehavior AllowedDomainVerificationBehavior { get; set; } = AllowedDomainVerificationBehavior.AnyAllowedDomainPresentAndValid;
    }
}
