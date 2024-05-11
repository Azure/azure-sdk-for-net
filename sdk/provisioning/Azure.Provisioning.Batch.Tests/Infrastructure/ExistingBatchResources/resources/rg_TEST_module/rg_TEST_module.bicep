resource batch_ljkLJsDS 'Microsoft.Batch/batchAccounts@2023-11-01' existing = {
    name: 'existingBatchAccount'
}

resource batchPool_JHZV2LAK 'Microsoft.Batch/batchAccounts/pools@2023-11-01' existing = {
    name: '${batch_ljkLJsDS}/existingPool'
}
