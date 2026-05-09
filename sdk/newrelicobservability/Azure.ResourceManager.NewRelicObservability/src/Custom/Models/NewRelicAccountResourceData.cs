// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.NewRelicObservability.Models
{
    // Backward compatibility: the previous (AutoRest) SDK exposed a public
    // parameterless constructor and setters on the flattened properties.
    // These are response-only models that are never sent to the API, so the
    // setters are non-functional, but removing them would break source
    // compatibility for existing consumers.
    public partial class NewRelicAccountResourceData
    {
        /// <summary> Initializes a new instance of <see cref="NewRelicAccountResourceData"/>. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NewRelicAccountResourceData()
        {
        }

        /// <summary> The resource-specific properties for this resource. </summary>
        [WirePath("properties")]
        internal AccountProperties Properties { get; set; }

        /// <summary> organization id. </summary>
        [WirePath("properties.organizationId")]
        public string OrganizationId
        {
            get => Properties?.OrganizationId;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new AccountProperties();
                Properties.OrganizationId = value;
            }
        }

        /// <summary> account id. </summary>
        [WirePath("properties.accountId")]
        public string AccountId
        {
            get => Properties?.AccountId;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new AccountProperties();
                Properties.AccountId = value;
            }
        }

        /// <summary> account name. </summary>
        [WirePath("properties.accountName")]
        public string AccountName
        {
            get => Properties?.AccountName;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new AccountProperties();
                Properties.AccountName = value;
            }
        }

        /// <summary> Region where New Relic account is present. </summary>
        [WirePath("properties.region")]
        public AzureLocation? Region
        {
            get => Properties?.Region;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                Properties ??= new AccountProperties();
                Properties.Region = value;
            }
        }
    }
}
