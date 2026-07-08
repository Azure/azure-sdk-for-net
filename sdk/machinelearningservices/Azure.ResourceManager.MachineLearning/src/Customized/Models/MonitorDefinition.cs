// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.MachineLearning.Models
{
    // Customized: restore constructor overloads for legacy parameter ordering and formerly public simple constructors that TypeSpec generation normalized.
    public partial class MonitorDefinition
    {
        /// <summary> Initializes a new instance of <see cref="MonitorDefinition"/>. </summary>
        public MonitorDefinition(IDictionary<string, MonitoringSignalBase> signals, MonitorComputeConfigurationBase computeConfiguration)
            : this(computeConfiguration, signals)
        {
        }

        // The current spec nests notification emails under MonitorNotificationSettings, but GA exposed a flattened Emails property.
        // TypeSpec decorators cannot re-add a removed flattened property, so keep this alias over the generated collection.
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
