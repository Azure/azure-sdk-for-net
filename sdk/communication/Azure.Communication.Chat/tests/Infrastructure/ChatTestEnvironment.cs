// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class ChatTestEnvironment: TestEnvironment
    {
        /// <summary>The name of the environment variable from which the Azure Communicion Service resource's connection string will be extracted for the live tests.</summary>
        internal const string ConnectionStringEnvironmentVariableName = "COMMUNICATION_CONNECTION_STRING";

        public string ConnectionString => GetRecordedVariable(ConnectionStringEnvironmentVariableName);

        public string ChatApiUrl()
        {
            var url = ConnectionString.Replace("endpoint=", "");
            var len = url.IndexOf("/;accesskey=");
            return url.Substring(0, len);
        }
    }
}
