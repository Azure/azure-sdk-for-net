// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Billing.Models
{
    // Workaround for MPG codegen bug #59545: enable-wire-path-attribute: true makes
    // the generator emit 4 duplicate [WirePath("tags")] attributes on Tags
    // (flatten + envelope name-collision). Suppress the generated Tags and
    // redeclare it with a single [WirePath("tags")].
    // TODO: remove once https://github.com/Azure/azure-sdk-for-net/issues/59545 ships.
    [CodeGenSuppress("Tags")]
    public partial class BillingTransactionData
    {
        /// <summary> Dictionary of metadata associated with the resource. It may not be populated for all resource types. Maximum key/value length supported of 256 characters. Keys/value should not empty value nor null. Keys can not contain &lt; &gt; % &amp; \ ? /. </summary>
        [WirePath("tags")]
        public IDictionary<string, string> Tags { get; }
    }
}
