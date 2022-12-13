param (
    [hashtable] $DeploymentOutputs
)

$webappRoot = "$PSScriptRoot/Azure.Identity/integration" | Resolve-Path
$workingFolder = $webappRoot;
if ($null -ne $Env:AGENT_WORKFOLDER) {
    $workingFolder = $Env:AGENT_WORKFOLDER
}
az login --service-principal -u $DeploymentOutputs['IDENTITY_CLIENT_ID'] -p $DeploymentOutputs['IDENTITY_CLIENT_SECRET'] --tenant $DeploymentOutputs['IDENTITY_TENANT_ID']
az account set --subscription $DeploymentOutputs['IDENTITY_SUBSCRIPTION_ID']
dotnet publish "$webappRoot/WebApp/Integration.Identity.WebApp.csproj" -o "$workingFolder/Pub" /p:EnableSourceLink=false
Compress-Archive -Path "$workingFolder/Pub/*" -DestinationPath "$workingFolder/Pub/package.zip" -Force
az webapp deploy --resource-group $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] --name $DeploymentOutputs['IDENTITY_WEBAPP_NAME'] --src-path "$workingFolder/Pub/package.zip"
Remove-Item -Force -Recurse "$workingFolder/Pub"
if ($null -eq $Env:AGENT_WORKFOLDER) {
    Remove-Item -Force -Recurse "$webappRoot/%AGENT_WORKFOLDER%"
}
az logout