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

# Deploy the webapp
dotnet publish "$webappRoot/WebApp/Integration.Identity.WebApp.csproj" -o "$workingFolder/Pub" /p:EnableSourceLink=false
Compress-Archive -Path "$workingFolder/Pub/*" -DestinationPath "$workingFolder/Pub/package.zip" -Force
az webapp deploy --resource-group $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] --name $DeploymentOutputs['IDENTITY_WEBAPP_NAME'] --src-path "$workingFolder/Pub/package.zip"

# clean up
Remove-Item -Force -Recurse "$workingFolder/Pub"

# Deploy the function app
dotnet publish "$webappRoot/Integration.Identity.Func/Integration.Identity.Func.csproj" -o "$workingFolder/Pub" /p:EnableSourceLink=false
Compress-Archive -Path "$workingFolder/Pub/*" -DestinationPath "$workingFolder/Pub/package.zip" -Force
az functionapp deployment source config-zip -g $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] -n $DeploymentOutputs['IDENTITY_FUNCTION_NAME'] --src "$workingFolder/Pub/package.zip"

# clean up
Remove-Item -Force -Recurse "$workingFolder/Pub"

az logout