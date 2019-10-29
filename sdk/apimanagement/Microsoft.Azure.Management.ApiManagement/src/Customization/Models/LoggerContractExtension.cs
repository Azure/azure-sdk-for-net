// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ApiManagement.Models
{
    /// <summary>
    /// Logger Contract extension.
    /// </summary>
    public partial class LoggerContract
    {
        public string CredentialsPropertyName
        {
            get
            {
                if (this.Credentials != null)
                {
                    if (this.LoggerType.Equals(Models.LoggerType.AzureEventHub))
                    {
                        if (this.Credentials.TryGetValue(LoggerConstants.EventHubPropertyName, out string propertyName))
                        {
                            return propertyName?.Replace("{", "").Replace("}", "");
                        }
                    }
                    else if (this.LoggerType.Equals(Models.LoggerType.ApplicationInsights))
                    {
                        if (this.Credentials.TryGetValue(LoggerConstants.ApplicationInsightsPropertyName, out string propertyName))
                        {
                            return propertyName?.Replace("{", "").Replace("}", "");
                        }
                    }
                }

                return null;
            }
        }
    }

    public class LoggerConstants
    {
        /// <summary>
        /// Property required for EventHub Logger Create Contract
        /// </summary>
        public const string EventHubPropertyName = "connectionString";

        /// <summary>
        /// Property required for ApplicationInsights Logger Create Contract
        /// </summary>
        public const string ApplicationInsightsPropertyName = "instrumentationKey";
    }
}
