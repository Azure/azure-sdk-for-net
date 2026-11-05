// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ImageBuilder
{
    public partial class ImageTemplate
    {
        /// <summary> Gets or sets the validation configuration. </summary>
        [CodeGenMember("Validate")]
        public ImageTemplateValidationConfig Validation
        {
            get
            {
                return Properties is null ? default : Properties.Validation;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new ImageTemplateProperties();
                }
                Properties.Validation = value;
            }
        }
    }
}
