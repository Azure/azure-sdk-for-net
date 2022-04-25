// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;

namespace Azure.Identity
{
    /// <summary>
    /// Options for configuring the <see cref="VisualStudioCodeCredential"/>.
    /// </summary>
    public class VisualStudioCodeCredentialOptions : TokenCredentialOptions
    {
        private string _tenantId;

        /// <summary>
        /// The tenant ID the user will be authenticated to. If not specified the user will be authenticated to the tenant the user originally authenticated to via the Visual Studio Code Azure Account plugin.
        /// </summary>
        public string TenantId
        {
            get { return _tenantId; }
            set { _tenantId = Validations.ValidateTenantId(value, allowNull: true); }
        }
    }
}
