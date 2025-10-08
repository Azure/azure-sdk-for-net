# Azure ComputeSchedule Sample

This project demonstrates how to use the Azure ComputeSchedule SDK to automate operations (create, start, delete, deallocate) on Azure Virtual Machines using scheduled actions.

## Features

- Authenticate with Azure using `DefaultAzureCredential`
- Create, start, and delete, deallocate virtual machines via scheduled actions
- Handles operation polling and error scenarios
- Demonstrates use of retry policies for scheduled actions

## Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- An Azure subscription
- An existing resource group in Azure
- The following Azure SDK NuGet packages:
  - `Azure.Identity`
  - `Azure.ResourceManager`
  - `Azure.ResourceManager.ComputeSchedule`
  - `Azure.ResourceManager.Resources`

## Getting Started

1. Clone the repository.
2. Update the `subscriptionId` and `resourceGroupName` constants in `Program.cs` with your Azure details.
3. Ensure you are authenticated with Azure (e.g., via `az login` or environment variables for `DefaultAzureCredential`).
4. Build and run any project corresponding to the Create/Delete/Start/Deallocate operation you want to perform
