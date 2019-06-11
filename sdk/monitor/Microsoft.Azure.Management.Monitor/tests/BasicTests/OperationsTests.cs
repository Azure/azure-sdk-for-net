// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Monitor.Tests.Helpers;
using Microsoft.Azure.Management.Monitor;
using Microsoft.Azure.Management.Monitor.Models;
using Xunit;

namespace Monitor.Tests.BasicTests
{
    public class OperationsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void OperationsTests_ListOperationsTest()
        {
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetMonitorManagementClient(handler);

            var expResponse = new OperationListResult
            {
                Value = new List<Operation>
                {
                    new Operation
                    {
                        Name = "Operation1",
                        Display = new OperationDisplay {
                            Operation = "Operation1",
                            Provider = "microsoft.insights",
                            Resource = "resource1"
                        }
                    },
                    new Operation
                    {
                        Name = "Operation2",
                        Display = new OperationDisplay {
                            Operation = "Operation2",
                            Provider = "microsoft.insights",
                            Resource = "resource2"
                        }
                    },
                }
            };

            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetMonitorManagementClient(handler);

            OperationListResult operations = insightsClient.Operations.List();
            Assert.Equal(2, operations.Value.Count);
            Assert.Equal("Operation1", operations.Value[0].Name);
            Assert.Equal("Operation1", operations.Value[0].Display.Operation);
            Assert.Equal("microsoft.insights", operations.Value[0].Display.Provider);
            Assert.Equal("resource1", operations.Value[0].Display.Resource);

            Assert.Equal("Operation2", operations.Value[1].Name);
            Assert.Equal("Operation2", operations.Value[1].Display.Operation);
            Assert.Equal("microsoft.insights", operations.Value[1].Display.Provider);
            Assert.Equal("resource2", operations.Value[1].Display.Resource);
        }
    }
}
