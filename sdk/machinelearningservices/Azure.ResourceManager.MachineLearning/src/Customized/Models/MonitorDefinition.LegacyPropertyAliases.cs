// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore GA flattened notification emails setter over the generated
    // AlertNotificationEmails collection backed by nested MonitorNotificationSettings.
    public partial class MonitorDefinition
    {
        /// <summary> The email recipient list which has a limitation of 499 characters in total. </summary>
        [WirePath("alertNotificationSettings.emailNotificationSettings.emails")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IList<string> Emails
        {
            get => AlertNotificationEmails;
            set
            {
                AlertNotificationEmails.Clear();
                if (value is null)
                {
                    return;
                }

                foreach (string email in value)
                {
                    AlertNotificationEmails.Add(email);
                }
            }
        }
    }
}
