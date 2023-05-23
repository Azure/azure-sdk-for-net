// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.Automation
{
    /// <summary>
    /// A class representing the AutomationWebhook data model.
    /// Definition of the webhook type.
    /// </summary>
    public partial class AutomationWebhookData
    {
        /// <summary> Gets or sets the webhook uri. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property has been replaced by UriString", false)]
        public Uri Uri { get; set; }
    }
}
