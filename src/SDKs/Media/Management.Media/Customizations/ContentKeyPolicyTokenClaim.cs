// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Media.Models
{
    public partial class ContentKeyPolicyTokenClaim
    {
        /// <summary>
        /// The claim type for the ContentKeyIdentifierClaim.
        /// </summary>
        public static readonly string ContentKeyIdentifierClaimType = "urn:microsoft:azure:mediaservices:contentkeyidentifier";

        /// <summary>
        /// This claim requires that the value of the claim in the token must match the key identifier of the key being requested by the client.
        /// Adding this claim means that the token issued to the client authorizes access to the content key identifier listed in the token.
        /// </summary>        
        public static readonly ContentKeyPolicyTokenClaim ContentKeyIdentifierClaim = new ContentKeyPolicyTokenClaim(ContentKeyIdentifierClaimType, null);
    }
}
