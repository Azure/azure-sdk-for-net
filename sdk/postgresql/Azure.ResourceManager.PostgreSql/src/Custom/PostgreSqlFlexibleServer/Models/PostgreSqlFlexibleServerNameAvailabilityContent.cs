// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.PostgreSql.FlexibleServers.Models
{
    public partial class PostgreSqlFlexibleServerNameAvailabilityContent
    {
        /// <summary> Initializes a new instance of <see cref="PostgreSqlFlexibleServerNameAvailabilityContent"/>. </summary>
        /// <param name="name"> The name of the resource for which availability needs to be checked. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PostgreSqlFlexibleServerNameAvailabilityContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));
            Name = name;
        }

        /// <summary> The resource type. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ResourceType? ResourceType
        {
            get => Type is null ? null : new ResourceType(Type);
            set => Type = value?.ToString();
        }
    }
}
