// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AlertsManagement.Tests.Helpers;
using Microsoft.Azure.Management.AlertsManagement;
using Microsoft.Azure.Management.AlertsManagement.Models;
using Xunit;
using Microsoft.Rest.Azure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AlertsManagement.Tests.UnitTests
{
    public class OperationsTests : TestBase
    {
        [Fact]
        [Trait("Category", "Mock")]
        public void ListOperationsTest()
        {
            var handler = new RecordedDelegatingHandler();
            var insightsClient = GetAlertsManagementClient(handler);

            List<Operation> operationsList = new List<Operation>
            {
                new Operation
                {
                    Name = "Operation1",
                    Display = new OperationDisplay {
                        Operation = "Operation1",
                        Provider = "microsoft.alertsmanagement",
                        Resource = "resource1"
                    }
                },
                new Operation
                {
                    Name = "Operation2",
                    Display = new OperationDisplay {
                        Operation = "Operation2",
                        Provider = "microsoft.alertsmanagement",
                        Resource = "resource2"
                    }
                },
            };

            var expResponse = new Page<Operation>
            {
                Items = operationsList
            };

            var serializedObject = Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(expResponse, insightsClient.SerializationSettings);
            var expectedResponse = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(serializedObject)
            };

            handler = new RecordedDelegatingHandler(expectedResponse);
            insightsClient = GetAlertsManagementClient(handler);

            var operations = insightsClient.Operations.List();
            ComparisonUtility.AreEqual(operationsList, operations.ToList());
        }
    }
}
