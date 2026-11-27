// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

targetScope = 'subscription'

param location string
param resourceGroupName string
param runId string
param queueName string
param ownerToken string
param expiresUtc string

resource testResources 'Microsoft.Resources/resourceGroups@2024-03-01' = {
  name: resourceGroupName
  location: location
  tags: {
    purpose: 'azure-ai-projects-sample-ci'
    'sample-ci-run': runId
    'sample-ci-queue': queueName
    'sample-ci-owner': ownerToken
    'expires-utc': expiresUtc
  }
}

output resourceGroupId string = testResources.id
