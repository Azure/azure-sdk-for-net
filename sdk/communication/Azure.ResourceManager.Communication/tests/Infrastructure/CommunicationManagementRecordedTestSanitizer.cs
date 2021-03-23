// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using Castle.Core.Internal;

namespace Azure.ResourceManager.Communication.Tests
{
    public class CommunicationManagementRecordedTestSanitizer : RecordedTestSanitizer
    {
        public string SubscriptionId { get; set; }

        public CommunicationManagementRecordedTestSanitizer(): base()
        {
            // Lazy sanitize fields in the request and response bodies
            JsonPathSanitizers.Add("$..token");
            JsonPathSanitizers.Add("$..identity");
            JsonPathSanitizers.Add("$..primaryKey");
            JsonPathSanitizers.Add("$..secondaryKey");
            JsonPathSanitizers.Add("$..primaryConnectionString");
            JsonPathSanitizers.Add("$..secondaryConnectionString");
            JsonPathSanitizers.Add("$..connectionString");
        }

        /// <summary>Fetch the value to replace with the Subscription ID. This value is not in the same format, but could easierly be change to be.</summary>
        private string SanitizeSubscriptionIdString(string text) => SubscriptionId.IsNullOrEmpty() ? text : text.Replace(SubscriptionId, SanitizeValue.ToLower());

        public override string SanitizeTextBody(string contentType, string body) => base.SanitizeTextBody(contentType, SanitizeSubscriptionIdString(body));

        public override string SanitizeUri(string uri) => base.SanitizeUri(SanitizeSubscriptionIdString(uri));

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                CommunicationManagementTestEnvironment.NotificationHubsConnectionStringEnvironmentVariableName => SanitizeValue.ToLower(),
                _ => base.SanitizeVariable(variableName, SanitizeSubscriptionIdString(environmentVariableValue))
            };
        }

        public override void Sanitize(RecordSession session)
        {
            // Save the Subscription ID so that it can be sanitized from all fields later
            if (session.Variables.ContainsKey(CommunicationManagementTestEnvironment.SubscriptionIdEnvironmentVariableName))
            {
                SubscriptionId = session.Variables[CommunicationManagementTestEnvironment.SubscriptionIdEnvironmentVariableName];
            }

            base.Sanitize(session);
        }
    }
}
