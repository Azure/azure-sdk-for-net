$Resources = @(
    #"BatchDeploymentTrackedResource",
    #"BatchEndpointTrackedResource",
    #"CodeContainerResource",
    #"CodeVersionResource",
    #"DataContainerResource",
    #"DatastorePropertiesResource",
    #"DataVersionResource",
    "EnvironmentContainerResource",
    "EnvironmentSpecificationVersionResource",
    #"JobBaseResource",
    #"LabelingJobResource",
    #"ModelContainerResource",
    #"ModelVersionResource",
    #"OnlineDeploymentTrackedResource",
    #"OnlineEndpointTrackedResource",
    #"PrivateEndpointConnection",
    "WorkspaceConnection"
)

$templateFiles = Get-ChildItem "TestTemplate"
ForEach ($resource in $Resources)
{
    foreach ($file in Get-ChildItem "TestTemplate")
    {
        $resourceTestFileName = "ScenarioTests\" + $file.Name -replace "Template", $resource
        Write-Host $resource $file.Name $resourceTestFileName
        #Copy-Item $file -Destination $resourceTestFileName
        (Get-Content -Path $file) -replace "Template", $Resource | Set-Content -Path $resourceTestFileName
    }
}

<#
Completed Resources
    "ComputeResource",
    "Workspace"
#>
