// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure.ResourceManager.Monitor.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Monitor
{
    [CodeGenSuppress("Notifications")]
    public partial class AutoscaleSettingData
    {
        /// <summary> The collection of notifications. </summary>
        public IList<AutoscaleNotification> Notifications
        {
            get
            {
                if (Properties is null)
                {
                    Properties = new AutoscaleSettingProperties();
                }
                return Properties.Notifications;
            }
            set
            {
                if (Properties is null)
                {
                    Properties = new AutoscaleSettingProperties();
                }
                Properties.Notifications.Clear();
                if (value is not null)
                {
                    foreach (AutoscaleNotification item in value)
                    {
                        Properties.Notifications.Add(item);
                    }
                }
            }
        }
    }
}
