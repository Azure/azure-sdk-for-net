param ($pr, $sdks)

$builds = az pipelines build list --organization https://dev.azure.com/azure-sdk --project internal --branch "refs/pull/$pr/merge"