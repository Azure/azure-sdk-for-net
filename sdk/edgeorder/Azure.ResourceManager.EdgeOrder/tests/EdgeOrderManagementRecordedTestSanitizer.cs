// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.ResourceManager.EdgeOrder.Tests
{
    public class EdgeOrderManagementRecordedTestSanitizer : RecordedTestSanitizer
    {
        public string SubscriptionId { get; set; }

        public EdgeOrderManagementRecordedTestSanitizer() : base()
        {
            AddJsonPathSanitizer("$..identity");
            AddJsonPathSanitizer("$..createdBy");
            AddJsonPathSanitizer("$..lastModifiedBy");
        }

        /// <summary>Fetch the value to replace with the Subscription ID. This value is not in the same format, but could easily be changed to be.</summary>
        private string SanitizeSubscriptionIdString(string text) => string.IsNullOrEmpty(SubscriptionId) ? text : text.Replace(SubscriptionId, SanitizeValue.ToLower());

        public override void SanitizeHeaders(IDictionary<string, string[]> headers)
        {
            base.SanitizeHeaders(headers);
            if (headers.ContainsKey("Location"))
            {
                List<string> locations = new  List<string>();
                foreach (var location in headers["Location"])
                {
                    locations.Add(SanitizeSubscriptionIdString(location));
                }
                headers["Location"] = locations.ToArray();
            }
        }

        public override string SanitizeTextBody(string contentType, string body) => base.SanitizeTextBody(contentType, SanitizeSubscriptionIdString(body));

        public override string SanitizeUri(string uri) => base.SanitizeUri(SanitizeSubscriptionIdString(uri));

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                _ => base.SanitizeVariable(variableName, SanitizeSubscriptionIdString(environmentVariableValue))
            };
        }

        public override void Sanitize(RecordSession session)
        {
            // Save the Subscription ID so that it can be sanitized from all fields later
            if (session.Variables.ContainsKey(EdgeOrderManagementTestEnvironment.SubscriptionIdEnvironmentVariableName))
            {
                SubscriptionId = session.Variables[EdgeOrderManagementTestEnvironment.SubscriptionIdEnvironmentVariableName];
            }

            base.Sanitize(session);
        }
    }
}
