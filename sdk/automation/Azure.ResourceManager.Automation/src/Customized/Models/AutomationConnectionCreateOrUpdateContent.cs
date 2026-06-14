// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.ResourceManager.Automation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA constructors and flattened connection description setter.
    [CodeGenSuppress("AutomationConnectionCreateOrUpdateContent", typeof(string))]
    [CodeGenSuppress("Description")]
    public partial class AutomationConnectionCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationConnectionCreateOrUpdateContent"/>. </summary>
        /// <param name="name"> Gets or sets the name of the connection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public AutomationConnectionCreateOrUpdateContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Properties = new ConnectionCreateOrUpdateProperties();
        }

        /// <summary> Initializes a new instance of <see cref="AutomationConnectionCreateOrUpdateContent"/>. </summary>
        /// <param name="name"> Gets or sets the name of the connection. </param>
        /// <param name="connectionType"> Gets or sets the connectionType of the connection. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="connectionType"/> is null. </exception>
        public AutomationConnectionCreateOrUpdateContent(string name, ConnectionTypeAssociationProperty connectionType)
        {
            Argument.AssertNotNull(name, nameof(name));
            Argument.AssertNotNull(connectionType, nameof(connectionType));

            Name = name;
            Properties = new ConnectionCreateOrUpdateProperties(default, connectionType, new ChangeTrackingDictionary<string, string>(), default);
        }

        /// <summary> Gets or sets the description of the connection. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }
    }
}
