// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Search.Documents.Indexes.Models
{
    [CodeGenSuppress(nameof(SearchIndexerDataUserAssignedIdentity), typeof(string))]
    public partial class SearchIndexerDataUserAssignedIdentity
    {
        /// <summary> Initializes a new instance of <see cref="SearchIndexerDataUserAssignedIdentity"/>. </summary>
        /// <param name="userAssignedIdentity"> The fully qualified Azure resource Id of a user assigned managed identity typically in the form "/subscriptions/12345678-1234-1234-1234-1234567890ab/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId" that should have been assigned to the search service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="userAssignedIdentity"/> is null. </exception>
        public SearchIndexerDataUserAssignedIdentity(ResourceIdentifier userAssignedIdentity)
        {
            Argument.AssertNotNull(userAssignedIdentity, nameof(userAssignedIdentity));

            UserAssignedIdentity = userAssignedIdentity;
            OdataType = "#Microsoft.Azure.Search.DataUserAssignedIdentity";
        }

        internal string ResourceId { get; set; }

        /// <summary> The fully qualified Azure resource Id of a user assigned managed identity typically in the form "/subscriptions/12345678-1234-1234-1234-1234567890ab/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myId" that should have been assigned to the search service. </summary>
        public ResourceIdentifier UserAssignedIdentity
        {
            get => new ResourceIdentifier(ResourceId);
            set => ResourceId = value.ToString();
        }
    }
}
