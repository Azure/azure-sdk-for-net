// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

param accountName string
param sampleModel {
  name: string
  version: string
  sku: string
  capacity: int
}

resource account 'Microsoft.CognitiveServices/accounts@2025-10-01-preview' existing = {
  name: accountName
}

resource model 'Microsoft.CognitiveServices/accounts/deployments@2025-10-01-preview' = {
  parent: account
  name: sampleModel.name
  sku: {
    name: sampleModel.sku
    capacity: sampleModel.capacity
  }
  properties: {
    model: {
      format: 'OpenAI'
      name: sampleModel.name
      version: sampleModel.version
    }
    versionUpgradeOption: 'NoAutoUpgrade'
  }
}

output modelName string = model.name
