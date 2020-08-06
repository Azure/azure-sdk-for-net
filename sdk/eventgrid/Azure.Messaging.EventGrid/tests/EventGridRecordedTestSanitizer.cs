// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;
using Azure.Core.TestFramework;

namespace Azure.Messaging.EventGrid.Tests
{
    public class EventGridRecordedTestSanitizer : RecordedTestSanitizer
    {

        public override string SanitizeVariable(string variableName, string environmentVariableValue)
        {
            return variableName switch
            {
                EventGridTestEnvironment.TopicKeyEnvironmentVariableName => "Kg==",
                EventGridTestEnvironment.DomainKeyEnvironmentVariableName => "Kg==",
                EventGridTestEnvironment.CloudEventTopicKeyEnvironmentVariableName => "Kg==",
                EventGridTestEnvironment.CustomEventTopicKeyEnvironmentVariableName => "Kg==",
                _ => base.SanitizeVariable(variableName, environmentVariableValue)
            };
        }
    }
}
