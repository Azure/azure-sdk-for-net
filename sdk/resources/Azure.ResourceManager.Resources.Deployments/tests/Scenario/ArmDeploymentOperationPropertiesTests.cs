// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.ResourceManager.Resources.Deployments.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Resources.Deployments.Tests;

public class ArmDeploymentOperationPropertiesTests
{
    [Test]
    public void DeserializeStatusCode_String()
    {
        var json = """
                   {
                       "provisioningOperation": "Create",
                       "provisioningState": "Failed",
                       "timestamp": "2025-08-15T04:59:34.9900267Z",
                       "duration": "PT0.4692629S",
                       "statusCode": "Conflict",
                       "statusMessage": {
                           "status": "Failed",
                           "error": {
                               "code": "ServiceIsInMaintenance",
                               "message": "[Conflict] Storage account 'seashore' is in process of maintenance for a short period. Please try again later."
                           }
                       },
                       "targetResource": {
                           "id": "/subscriptions/xxxxxxxxx/resourceGroups/my-rg/providers/Microsoft.Storage/storageAccounts/seashore",
                           "resourceType": "Microsoft.Storage/storageAccounts",
                           "resourceName": "seashore"
                       }
                   }
                   """;
        var jsonDocument = JsonDocument.Parse(json);
        var deploymentOperations = ArmDeploymentOperationProperties.DeserializeArmDeploymentOperationProperties(jsonDocument.RootElement, ModelReaderWriterOptions.Json);
        Assert.AreEqual("Conflict", deploymentOperations.StatusCode);
    }

    [Test]
    public void DeserializeStatusCode_Integer()
    {
        var json = """
                   {
                       "provisioningOperation": "Create",
                       "provisioningState": "Failed",
                       "timestamp": "2025-08-15T04:59:34.9900267Z",
                       "duration": "PT0.4692629S",
                       "statusCode": 429,
                       "statusMessage": {
                           "status": "Failed",
                           "error": {
                               "code": "TooManyRequests",
                               "message": "The request is being throttled as the limit has been reached. Please try again later."
                           }
                       },
                       "targetResource": {
                           "id": "/subscriptions/xxxxxxxxx/resourceGroups/my-rg/providers/Microsoft.Storage/storageAccounts/seashore",
                           "resourceType": "Microsoft.Storage/storageAccounts",
                           "resourceName": "seashore"
                       }
                   }
                   """;
        var jsonDocument = JsonDocument.Parse(json);
        var deploymentOperations = ArmDeploymentOperationProperties.DeserializeArmDeploymentOperationProperties(jsonDocument.RootElement, ModelReaderWriterOptions.Json);
        Assert.AreEqual("429", deploymentOperations.StatusCode);
    }
}
