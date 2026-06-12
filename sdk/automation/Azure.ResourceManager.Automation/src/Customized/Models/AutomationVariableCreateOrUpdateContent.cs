// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.ResourceManager.Automation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Compatibility shim preserving GA setters for flattened variable create/update properties.
    [CodeGenSuppress("AutomationVariableCreateOrUpdateContent", typeof(string))]
    [CodeGenSuppress("Description")]
    [CodeGenSuppress("IsEncrypted")]
    [CodeGenSuppress("Value")]
    public partial class AutomationVariableCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationVariableCreateOrUpdateContent"/>. </summary>
        /// <param name="name"> Gets or sets the name of the variable. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public AutomationVariableCreateOrUpdateContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Properties = new VariableCreateOrUpdateProperties();
        }

        /// <summary> Gets or sets the description of the variable. </summary>
        public string Description
        {
            get => Properties.Description;
            set => Properties.Description = value;
        }

        /// <summary> Gets or sets the encrypted flag of the variable. </summary>
        public bool? IsEncrypted
        {
            get => Properties.IsEncrypted;
            set => Properties.IsEncrypted = value;
        }

        /// <summary> Gets or sets the value of the variable. </summary>
        public string Value
        {
            get => Properties.Value;
            set => Properties.Value = value;
        }
    }
}
