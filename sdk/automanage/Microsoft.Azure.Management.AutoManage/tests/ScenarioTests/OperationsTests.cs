// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
namespace Automanage.Tests.ScenarioTests
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using Automanage.Tests.Helpers;
    using Microsoft.Azure.Management.Automanage;
    using Microsoft.Azure.Management.Automanage.Models;
    using Microsoft.Rest.Azure;
    using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
    using Xunit;
    using Xunit.Abstractions;
    
    public class OperationsTests : TestBase
    {
        private RecordedDelegatingHandler handler;

        public OperationsTests()
            : base()
        {
            handler = new RecordedDelegatingHandler { SubsequentStatusCodeToReturn = HttpStatusCode.OK };
        }

        [Fact]
        [Trait("Category", "Scenario")]
        public void ListOperationsGetsAllValidOperations()
        {
            var thisType = this.GetType();
            using (MockContext context = MockContext.Start(thisType))
            {
                var automanageClient = GetAutomanagementClient(context, handler);

                var actual = automanageClient.Operations.List();

                Assert.NotNull(actual);
                if (!this.IsRecording)
                {
                    CheckListedOperations(actual);
                }
            }
        }

        private static void CheckListedOperations(IEnumerable<Operation> operationListResult)
        {
            List<String> supportedOperations = new List<String>
            {
                "Microsoft.Automanage/register/Action",
                "Microsoft.Automanage/accounts/Delete",
                "Microsoft.Automanage/accounts/Read",
                "Microsoft.Automanage/accounts/Write",
                "Microsoft.Automanage/configurationProfileAssignments/Delete",
                "Microsoft.Automanage/configurationProfileAssignments/Read",
                "Microsoft.Automanage/configurationProfileAssignments/Write",

            };

            string expectedProvider = "Microsoft Automanage";

            var enumerator = operationListResult.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Operation current = enumerator.Current;
                Assert.Contains(current.Name, supportedOperations);
                Assert.Equal(expectedProvider, current.Display.Provider);
            }
        }
    }
}