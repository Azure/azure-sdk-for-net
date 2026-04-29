// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    // Preserves the previous ResourceType property name for name-availability requests.
    [CodeGenSuppress("Type")]
    public partial class PostgreSqlFlexibleServerNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The name of the resource for which availability needs to be checked. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerNameAvailabilityContent(string name) : this()
        {
            Name = name;
        }

        /// <summary> The type of the resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("type")]
        public ResourceType? ResourceType
        {
            get => TypeInternal is null ? default(ResourceType?) : new ResourceType(TypeInternal);
            set => TypeInternal = value?.ToString();
        }

        internal string TypeInternal { get; set; }
    }
}
