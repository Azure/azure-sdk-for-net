param (
    [hashtable] $DeploymentOutputs,
    [string] $TenantId,
    [string] $TestApplicationId,
    [string] $TestApplicationSecret
)

Import-AzContainerRegistryImage `
    -ResourceGroupName $DeploymentOutputs['CONTAINERREGISTRY_RESOURCE_GROUP'] `
    -RegistryName $DeploymentOutputs['CONTAINERREGISTRY_USERNAME'] `
    -SourceImage 'library/hello-world' -SourceRegistryUri 'registry.hub.docker.com' `
    -TargetTag @('library/hello-world:latest', 'library/hello-world:v1', 'library/hello-world:v2', 'library/hello-world:v3', 'library/hello-world:v4') `
    -Mode 'Force' 

Import-AzContainerRegistryImage `
    -ResourceGroupName $DeploymentOutputs['CONTAINERREGISTRY_RESOURCE_GROUP'] `
    -RegistryName $DeploymentOutputs['CONTAINERREGISTRY_USERNAME'] `
    -SourceImage 'library/alpine' -SourceRegistryUri 'registry.hub.docker.com' `
    -Mode 'Force'

Import-AzContainerRegistryImage `
    -ResourceGroupName $DeploymentOutputs['CONTAINERREGISTRY_RESOURCE_GROUP'] `
    -RegistryName $DeploymentOutputs['CONTAINERREGISTRY_USERNAME'] `
    -SourceImage 'library/busybox' -SourceRegistryUri 'registry.hub.docker.com' `
    -Mode 'Force'
