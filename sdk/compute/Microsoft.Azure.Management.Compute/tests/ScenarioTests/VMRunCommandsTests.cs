// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Xunit;

namespace Compute.Tests
{
    public class VMRunCommandsTests
    {
        [Fact]
        public void TestListVMRunCommands()
        {
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                var computeClient = ComputeManagementTestUtilities.GetComputeManagementClient(context,
                    new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK });
                string location = ComputeManagementTestUtilities.DefaultLocation.Replace(" ", "");
                string documentId = "RunPowerShellScript";

                // Verify the List of commands
                IEnumerable<RunCommandDocumentBase> runCommandListResponse = computeClient.VirtualMachineRunCommands.List(location);
                Assert.NotNull(runCommandListResponse);
                Assert.True(runCommandListResponse.Count() > 0, "ListRunCommands should return at least 1 command");
                RunCommandDocumentBase documentBase =
                    runCommandListResponse.FirstOrDefault(x => string.Equals(x.Id, documentId));
                Assert.NotNull(documentBase);

                // Verify Get a specific RunCommand
                RunCommandDocument document = computeClient.VirtualMachineRunCommands.Get(location, documentId);
                Assert.NotNull(document);
                Assert.NotNull(document.Script);
                Assert.True(document.Script.Count > 0, "Script should contain at least one command.");
                Assert.NotNull(document.Parameters);
                Assert.True(document.Parameters.Count == 2, "Script should have 2 parameters.");
            }
        }
    }
}
