// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.Configuration;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Messaging.EventGrid.Namespaces
{
    [CodeGenSuppress("Options")]
    [CodeGenSuppress("BindCore", typeof(IConfigurationSection))]
    public partial class EventGridSenderClientSettings
    {
        /// <summary> Gets or sets the Options. </summary>
        public EventGridSenderClientOptions Options { get; set; }

        /// <summary> Binds configuration values from the given section. </summary>
        /// <param name="section"> The configuration section. </param>
        protected override void BindCore(IConfigurationSection section)
        {
            if (Uri.TryCreate(section["Endpoint"], UriKind.Absolute, out Uri endpoint))
            {
                Endpoint = endpoint;
            }
        }
    }
}
