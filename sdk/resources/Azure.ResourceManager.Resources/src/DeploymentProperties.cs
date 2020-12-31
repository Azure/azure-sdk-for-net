// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class DeploymentProperties
    {
        [CodeGenMember("Template")]
        internal JsonElement TemplateJson { get; set; } = JsonDocument.Parse("null").RootElement;

        [CodeGenMember("Parameters")]
        internal JsonElement ParametersJson { get; set; } = JsonDocument.Parse("null").RootElement;

        /// <summary>
        /// Template
        /// </summary>
        public string Template
        {
            get => TemplateJson.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    TemplateJson = JsonDocument.Parse(value).RootElement;
                }
            }
        }

        /// <summary>
        /// Parameters
        /// </summary>
        public string Parameters
        {
            get => ParametersJson.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    ParametersJson = JsonDocument.Parse(value).RootElement;
                }
            }
        }
    }
}
