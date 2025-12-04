// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Security.CodeTransparency
{
    /// <summary>
    /// Specifies how receipts whose issuer domains ARE in the authorized list should be enforced.
    /// </summary>
    public enum AuthorizedReceiptBehavior
    {
        /// <summary>
        /// At least one receipt from any authorized domain must be present and valid.
        /// </summary>
        VerifyAnyMatching = 0,
        /// <summary>
        /// ALL receipts whose issuer is in the authorized list MUST pass verification. Receipts not in the authorized list are treated according to <see cref="CodeTransparencyVerificationOptions.UnauthorizedReceiptBehavior"/>.
        /// </summary>
        VerifyAllMatching = 1,
        /// <summary>
        /// There MUST be at least one valid receipt for EACH domain in the authorized list (coverage requirement). If a domain has no receipt or only invalid receipts, verification fails.
        /// </summary>
        RequireAll = 2
    }
    /// <summary>
    /// Specifies behaviors for receipts whose issuer domains are not contained in <see cref="CodeTransparencyVerificationOptions.AuthorizedDomains"/>.
    /// </summary>
    public enum UnauthorizedReceiptBehavior
    {
        /// <summary>
        /// Verify receipts even if their issuer domain is not in the authorized list.
        /// </summary>
        VerifyAll = 0,
        /// <summary>
        /// Ignore (skip verifying) receipts whose issuer domain is not in the authorized list.
        /// </summary>
        IgnoreAll = 1,
        /// <summary>
        /// Fail verification immediately if any receipt exists whose issuer domain is not in the authorized list.
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
        /// Gets or sets an authorized list of issuer domains. If provided and not empty, at least one receipt must be issued by one of these domains.
        /// Domains are matched case-insensitively.
        /// </summary>
        public IList<string> AuthorizedDomains { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the behavior for receipts whose issuer domain is not in <see cref="AuthorizedDomains"/>.
        /// Defaults to <see cref="UnauthorizedReceiptBehavior.VerifyAll"/> to preserve current behavior.
        /// </summary>
        public UnauthorizedReceiptBehavior UnauthorizedReceiptBehavior { get; set; } = UnauthorizedReceiptBehavior.FailIfPresent;

        /// <summary>
        /// Gets or sets the enforcement behavior for receipts whose issuer domain IS contained in <see cref="AuthorizedDomains"/>.
        /// Defaults to <see cref="AuthorizedReceiptBehavior.VerifyAllMatching"/>.
        /// </summary>
        public AuthorizedReceiptBehavior AuthorizedReceiptBehavior { get; set; } = AuthorizedReceiptBehavior.VerifyAllMatching;
    }
}
