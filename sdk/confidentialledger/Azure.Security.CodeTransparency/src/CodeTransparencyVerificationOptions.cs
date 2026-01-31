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
    /// Specifies behaviors for the use of offline keys contained in <see cref="CodeTransparencyVerificationOptions.OfflineKeys"/>.
    /// </summary>
    public enum OfflineKeysBehavior
    {
        /// <summary>
        /// Use offline keys when available, but fall back to network retrieval if no offline key is found for a given ledger domain.
        /// </summary>
        FallbackToNetwork = 0,
        /// <summary>
        /// Use only offline keys. If no offline key is found for a given ledger domain, verification fails.
        /// </summary>
        NoFallbackToNetwork = 1
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
        /// Defaults to <see cref="UnauthorizedReceiptBehavior.FailIfPresent"/>.
        /// </summary>
        public UnauthorizedReceiptBehavior UnauthorizedReceiptBehavior { get; set; } = UnauthorizedReceiptBehavior.FailIfPresent;

        /// <summary>
        /// Gets or sets the enforcement behavior for receipts whose issuer domain IS contained in <see cref="AuthorizedDomains"/>.
        /// Defaults to <see cref="AuthorizedReceiptBehavior.VerifyAllMatching"/>.
        /// </summary>
        public AuthorizedReceiptBehavior AuthorizedReceiptBehavior { get; set; } = AuthorizedReceiptBehavior.VerifyAllMatching;

        /// <summary>
        /// Gets or sets a store mapping ledger domains to JWKS documents for offline verification.
        /// When provided, will skip network calls and use the matching JWKS document from this store instead.
        /// </summary>
        public CodeTransparencyOfflineKeys OfflineKeys { get; set; } = null;

        /// <summary>
        /// Gets or sets the behavior for using offline keys in <see cref="CodeTransparencyOfflineKeys"/>.
        /// Defaults to <see cref="OfflineKeysBehavior.FallbackToNetwork"/>.
        /// </summary>
        public OfflineKeysBehavior OfflineKeysBehavior { get; set; } = OfflineKeysBehavior.FallbackToNetwork;
    }
}
