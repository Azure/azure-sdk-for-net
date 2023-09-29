param (
  [hashtable] $DeploymentOutputs
)
$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true

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

$containerImage = 'azsdkengsys.azurecr.io/dotnet/ubuntu_netcore_keyring:3080193'
$MIClientId = $DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY_CLIENT_ID']
$MIName = $DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY_NAME']
$SaAccountName = 'workload-identity-sa'
$PodName = $DeploymentOutputs['IDENTITY_AKS_POD_NAME']

if ($IsMacOS -eq $true) {
  # Not supported on MacOS agents
  az logout
  return
}
# Get the aks cluster credentials
Write-Host "Getting AKS credentials"
az aks get-credentials --resource-group $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] --name $DeploymentOutputs['IDENTITY_AKS_CLUSTER_NAME']

#Get the aks cluster OIDC issuer
Write-Host "Getting AKS OIDC issuer"
$AKS_OIDC_ISSUER = az aks show -n $DeploymentOutputs['IDENTITY_AKS_CLUSTER_NAME'] -g $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] --query "oidcIssuerProfile.issuerUrl" -otsv

# Create the federated identity
Write-Host "Creating federated identity"
az identity federated-credential create --name $MIName --identity-name $MIName --resource-group $DeploymentOutputs['IDENTITY_RESOURCE_GROUP'] --issuer $AKS_OIDC_ISSUER --subject system:serviceaccount:default:workload-identity-sa

# Build the kubernetes deployment yaml
$kubeConfig = @"
apiVersion: v1
kind: ServiceAccount
metadata:
  annotations:
    azure.workload.identity/client-id: $MIClientId
  name: $SaAccountName
  namespace: default
---
apiVersion: v1
kind: Pod
metadata:
  name: $PodName
  namespace: default
  labels:
    azure.workload.identity/use: "true"
spec:
  serviceAccountName: $SaAccountName
  containers:
  - name: $PodName
    image: $containerImage
    env:
    - name: AZURE_TEST_MODE
      value: "LIVE"
    - name: IS_RUNNING_IN_IDENTITY_CLUSTER
      value: "true"
    command: ["tail"]
    args: ["-f", "/dev/null"]
    ports:
    - containerPort: 80
  nodeSelector:
    kubernetes.io/os: linux
"@

Set-Content -Path "$workingFolder/kubeconfig.yaml" -Value $kubeConfig
Write-Host "Created kubeconfig.yaml with contents:"
Write-Host $kubeConfig

# Apply the config
kubectl apply -f "$workingFolder/kubeconfig.yaml" --overwrite=true
Write-Host "Applied kubeconfig.yaml"
az logout