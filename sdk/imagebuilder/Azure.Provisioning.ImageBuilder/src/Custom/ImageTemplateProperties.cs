// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.Provisioning.ImageBuilder
{
    internal partial class ImageTemplateProperties
    {
        private ImageTemplateValidationConfig _validation;

        /// <summary> Gets or sets the validation configuration. </summary>
        [CodeGenMember("Validate")]
        public ImageTemplateValidationConfig Validation
        {
            get
            {
                Initialize();
                return _validation;
            }
            set
            {
                Initialize();
                AssignOrReplace(ref _validation, value);
            }
        }

        partial void DefineAdditionalProperties()
        {
            _validation = DefineModelProperty<ImageTemplateValidationConfig>(
                nameof(Validation),
                new string[] { "validate" });
        }
    }
}
