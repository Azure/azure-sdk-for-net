// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    public partial class TemplateSpecVersion
    {
        [CodeGenMember("MainTemplate")]
        internal JsonElement MainTemplateJson { get; set; } = JsonDocument.Parse("null").RootElement;

        /// <summary>
        /// The MainTemplate contents.
        /// </summary>
        public string MainTemplate
        {
            get => MainTemplateJson.ToString();
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    MainTemplateJson = JsonDocument.Parse(value).RootElement;
                }
            }
        }
    }
}
