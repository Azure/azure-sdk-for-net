---
title: "Quickstart: Upload firmware images to firmware analysis using .NET SDK"
description: "Learn how to upload firmware images for analysis using the .NET SDK."
author: karengu0
ms.author: karenguo
ms.topic: quickstart
ms.date: 03/07/2025
ms.service: azure
---

# Quickstart: Upload firmware images to firmware analysis using .NET SDK

This article explains how to use the .NET SDK to upload firmware images to firmware analysis.

[Firmware analysis](./overview-firmware-analysis.md) is a tool that analyzes firmware images and provides an understanding of security vulnerabilities in the firmware images.

## Prerequisites

This quickstart assumes a basic understanding of firmware analysis. For more information, see [Firmware analysis for device builders](./overview-firmware-analysis.md). For a list of the file systems that are supported, see [Frequently asked questions about firmware analysis](./firmware-analysis-faq.md#what-types-of-firmware-images-does-firmware-analysis-support).

The prerequisites you need are the following:
* An Azure subscription
* .NET SDK installed on your machine
* An Azure IoT Firmware Defense resource created in your Azure account

### Prepare your environment

1. Install the SDK
    
    Use the .NET CLI to install the Azure Resource Manager IoT Firmware Defense SDK:

    ```
    dotnet add package Azure.ResourceManager.IotFirmwareDefense
    ```

2. Authenticate the Client
    
    To authenticate your client, you can use the DefaultAzureCredential from the Azure.Identity package. Ensure you have the necessary environment variables set up for authentication.

    ```
    using Azure.Identity;
    using Azure.ResourceManager;
    using Azure.ResourceManager.IotFirmwareDefense;

    var credential = new DefaultAzureCredential();
    var armClient = new ArmClient(credential);
    ```

### Upload Firmware

1. Get the IoT Firmware Defense Resource

    Replace `resourceGroupName` and `iotFirmwareDefenseName` with your actual resource group and IoT Firmware Defense resource names.

    ```
    var subscriptionId = "<your_subscription_id>";
    var resourceGroupName = "<your_resource_group_name>";
    var iotFirmwareDefenseName = "<your_iot_firmware_defense_name>";

    var iotFirmwareDefenseResource = armClient.GetIotFirmwareDefenseResource(subscriptionId, resourceGroupName, iotFirmwareDefenseName);
    ```

2. Upload the Firmware

    Use the UploadFirmwareAsync method to upload your firmware file.

    ```
    var firmwareFilePath = "<path_to_your_firmware_file>";
    using var firmwareStream = File.OpenRead(firmwareFilePath);

    var uploadResult = await iotFirmwareDefenseResource.UploadFirmwareAsync(firmwareStream);
    Console.WriteLine($"Firmware upload status: {uploadResult.Status}");
    ```

### Retrieve Firmware Analysis Results

1. Get the Firmware Analysis Summary

    After uploading the firmware, you can retrieve the analysis summary using the GetFirmwareAnalysisSummaries method.

    ```
    var firmwareAnalysisSummaries = await iotFirmwareDefenseResource.GetFirmwareAnalysisSummariesAsync();
    foreach (var summary in firmwareAnalysisSummaries)
    {
        Console.WriteLine($"Analysis ID: {summary.Id}");
        Console.WriteLine($"Status: {summary.Status}");
        Console.WriteLine($"Issues Found: {summary.IssuesFound}");
    }
    ```

2. Get Detailed Analysis Results

    For more detailed results, you can access specific analysis details using the GetFirmwareAnalysisSummary method.

    ```
    var analysisId = "<your_analysis_id>";
    var analysisSummary = await iotFirmwareDefenseResource.GetFirmwareAnalysisSummaryAsync(analysisId);

    Console.WriteLine($"Analysis ID: {analysisSummary.Id}");
    Console.WriteLine($"Status: {analysisSummary.Status}");
    Console.WriteLine($"Issues Found: {analysisSummary.IssuesFound}");
    Console.WriteLine($"Detailed Report: {analysisSummary.DetailedReport}");
    ```

3. SBOM

    The following command retrieves the SBOM in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```

4. Weaknesses

    The following command retrieves CVEs found in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```

5. Binary hardening

    The following command retrieves analysis results on binary hardening in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```

6. Password hashes

    The following command retrieves password hashes in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```

7. Certificates

    The following command retrieves vulnerable crypto certificates that were found in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```

8. Keys

    The following command retrieves vulnerable crypto keys that were found in your firmware image. Replace each argument with the appropriate value for your resource group, subscription, workspace name, and firmware ID.

    ```

    ```
