// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.SelfHelp.Tests;

public class BasicSelfHelpTests
{
    internal static Trycep CreateDiagnosticTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:SelfHelpBasic
                Infrastructure infra = new();

                ProvisioningParameter solutionId = new(nameof(solutionId), typeof(string))
                {
                    Description = "The diagnostic solution ID returned by the discovery solutions API.",
                };
                infra.Add(solutionId);

                SelfHelpDiagnostic diagnostic =
                    new(nameof(diagnostic), SelfHelpDiagnostic.ResourceVersions.V2024_03_01_PREVIEW)
                    {
                        Name = "diagnostic",
                        Insights =
                        {
                            new SelfHelpDiagnosticInvocation
                            {
                                SolutionId = solutionId,
                            },
                        },
                    };
                infra.Add(diagnostic);

                infra.Add(new ProvisioningOutput("diagnosticId", typeof(string)) { Value = diagnostic.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.help/2024-03-01-preview/diagnostics")]
    public async Task CreateDiagnostic()
    {
        await using Trycep test = CreateDiagnosticTest();
        test.Compare(
            """
            @description('The diagnostic solution ID returned by the discovery solutions API.')
            param solutionId string

            resource diagnostic 'Microsoft.Help/diagnostics@2024-03-01-preview' = {
              name: 'diagnostic'
              properties: {
                insights: [
                  {
                    solutionId: solutionId
                  }
                ]
              }
            }

            output diagnosticId string = diagnostic.id
            """);
    }
}
