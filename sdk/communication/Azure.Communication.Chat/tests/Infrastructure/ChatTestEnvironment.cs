// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Communication.Pipeline;
using Azure.Core.TestFramework;

namespace Azure.Communication.Chat.Tests
{
    /// <summary>
    /// A helper class used to retrieve information to be used for tests.
    /// </summary>
    public class ChatTestEnvironment: TestEnvironment
    {
        public ChatTestEnvironment() : base("communication")
        {
        }

        public string ConnectionString => GetRecordedVariable(CommunicationEnvironmentVariableNames.ConnectionStringEnvironmentVariableName);

        public string ChatApiUrl()
        {
            var url = ConnectionString.Replace("endpoint=", "");
            var len = url.IndexOf("/;accesskey=");
            return url.Substring(0, len);
        }
    }
}
