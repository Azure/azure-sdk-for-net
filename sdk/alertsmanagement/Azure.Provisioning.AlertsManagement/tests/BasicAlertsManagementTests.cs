// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.AlertsManagement.Tests;

public class BasicAlertsManagementTests
{
    internal static Trycep CreateServiceAlertTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:AlertsManagementBasic
                Infrastructure infra = new();

                ServiceAlert alert = ServiceAlert.FromExisting(nameof(alert), ServiceAlert.ResourceVersions.V2025_05_25_PREVIEW);
                alert.Name = "existingAlert";
                infra.Add(alert);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task ReferenceExistingServiceAlert()
    {
        await using Trycep test = CreateServiceAlertTest();
        test.Compare(
            """
            resource alert 'Microsoft.AlertsManagement/alerts@2025-05-25-preview' existing = {
              name: 'existingAlert'
            }
            """);
    }
}
