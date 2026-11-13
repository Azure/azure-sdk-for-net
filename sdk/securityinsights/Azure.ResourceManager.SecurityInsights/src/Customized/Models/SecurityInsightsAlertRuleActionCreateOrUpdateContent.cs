// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.SecurityInsights.Models
{
    // Usage.input does not restore this setter because triggerUri is generated as a required constructor-only property; keep the GA SDK settable surface.
    [CodeGenSuppress("TriggerUri")]
    public partial class SecurityInsightsAlertRuleActionCreateOrUpdateContent
    {
        /// <summary> Logic App Callback URL for this specific workflow. </summary>
        [WirePath("properties.triggerUri")]
        public Uri TriggerUri
        {
            get => Properties is null ? default : Properties.TriggerUri;
            set
            {
                if (Properties is null)
                {
                    Properties = new ActionRequestProperties();
                }

                Properties.TriggerUri = value;
            }
        }
    }
}
