// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Azure.ResourceManager.SelfHelp.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;
using Azure.Core;
using System;
using System.Text;
using Azure.ResourceManager.Resources;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using System.IO;

namespace Azure.ResourceManager.SelfHelp.Tests.Helpers
{
    public class ResourceDataHelpers
    {
        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.AreEqual(r1.Name, r2.Name);
            Assert.AreEqual(r1.Id, r2.Id);
            Assert.AreEqual(r1.ResourceType, r2.ResourceType);
        }

        #region Diagnostic
        public static void AssertSecurityInsightsAlertRuleData(SelfHelpDiagnosticResourceData data1, SelfHelpDiagnosticResourceData data2)
        {
            AssertResource(data1, data2);
            Assert.AreEqual(data1.AcceptedTime, data2.AcceptedTime);
            Assert.AreEqual(data1.ProvisioningState, data2.ProvisioningState);
            Assert.AreEqual(data1.GlobalParameters, data2.GlobalParameters);
        }
        public static SelfHelpDiagnosticResourceData GetDiagnosticData()
        {
            var data = new SelfHelpDiagnosticResourceData()
            {
                Insights =
                {
                    new DiagnosticInvocation()
                    {
                        SolutionId = "SampleSolutionId",
                        AdditionalParameters =
                        {
                            {"serverName", "testServer" }
                        }
                    }
                },
                GlobalParameters =
                {
                    {"startTime", "2023.04.19" }
                }
            };
            return data;
        }
        #endregion
    }
}
