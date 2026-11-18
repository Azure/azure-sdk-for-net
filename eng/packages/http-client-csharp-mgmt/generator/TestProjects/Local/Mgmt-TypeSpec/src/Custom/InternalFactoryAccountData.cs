// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Azure.Generator.MgmtTypeSpec.Tests.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Generator.MgmtTypeSpec.Tests
{
    [CodeGenSuppress("Properties")]
    public partial class InternalFactoryAccountData
    {
        [WirePath("properties")]
        internal InternalFactoryAccountProperties Properties { get; set; }

        /// <summary> Gets the organization identifier. </summary>
        [WirePath("properties.organizationId")]
        public string OrganizationId => Properties?.OrganizationId;

        /// <summary> Gets the account identifier. </summary>
        [WirePath("properties.accountId")]
        public string AccountId => Properties?.AccountId;
    }
}
