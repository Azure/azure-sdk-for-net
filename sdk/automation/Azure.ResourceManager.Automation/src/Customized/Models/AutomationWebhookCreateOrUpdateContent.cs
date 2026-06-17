// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.ResourceManager.Automation;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Automation.Models
{
    // Generated webhook content keeps most fields under WebhookCreateOrUpdateProperties.
    // Keep the GA name constructor and top-level setters for expiry, enabled state, runbook, runOn, and URI.
    public partial class AutomationWebhookCreateOrUpdateContent
    {
        /// <summary> Initializes a new instance of <see cref="AutomationWebhookCreateOrUpdateContent"/>. </summary>
        /// <param name="name"> Gets or sets the name of the webhook. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public AutomationWebhookCreateOrUpdateContent(string name)
        {
            Argument.AssertNotNull(name, nameof(name));

            Name = name;
            Properties = new WebhookCreateOrUpdateProperties();
        }

        /// <summary> Gets or sets the expiry time. </summary>
        public DateTimeOffset? ExpireOn
        {
            get => Properties.ExpireOn;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.ExpireOn = value;
        }

        /// <summary> Gets or sets the value of the enabled flag of webhook. </summary>
        public bool? IsEnabled
        {
            get => Properties.IsEnabled;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.IsEnabled = value;
        }

        /// <summary> Gets or sets the name of the runbook. </summary>
        public string RunbookName
        {
            get => Properties.RunbookName;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.RunbookName = value;
        }

        /// <summary> Gets or sets the name of the hybrid worker group the webhook job will run on. </summary>
        public string RunOn
        {
            get => Properties.RunOn;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.RunOn = value;
        }

        /// <summary> Gets or sets the uri. </summary>
        public Uri Uri
        {
            get => Properties.Uri;
            [EditorBrowsable(EditorBrowsableState.Never)]
            set => Properties.Uri = value;
        }
    }
}
