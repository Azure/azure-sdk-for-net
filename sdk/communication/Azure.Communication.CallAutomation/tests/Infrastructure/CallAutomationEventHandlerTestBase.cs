// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Communication.CallAutomation.Tests.Infrastructure
{
    public abstract class CallAutomationEventHandlerTestBase
    {
        protected const string ConnectionString = "endpoint=https://contoso.azure.com/;accesskey=ZHVtbXlhY2Nlc3NrZXk=";
        protected const string ServerCallId = "someServerCallId";
        protected const string CallConnectionId = "someCallConnectionId";
        protected const string OperationContext = "someOperationContext";
        protected const string CorelationId = "someCorelationId";
        protected const int defaultTestTimeout = 3;

        protected CallAutomationClient CreateMockCallAutomationClient(CallAutomationClientOptions? options = default)
        {
            if (options == default)
            {
                options = new CallAutomationClientOptions();
                options.EventHandlerOptions.TimeoutException = TimeSpan.FromSeconds(defaultTestTimeout);
            }

            return new CallAutomationClient(ConnectionString, options);
        }

        protected void SendAndProcessEvent(
            CallAutomationEventHandler eventHandler,
            CallAutomationEventBase eventToBeSent)
        {
            eventHandler.ProcessEvents(new List<CallAutomationEventBase>() { eventToBeSent });
        }
    }
}
