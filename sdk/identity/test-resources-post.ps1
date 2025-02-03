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

if ($IsMacOS -eq $true) {
  # Not supported on MacOS agents
  az logout
  return
}

$containerImage = 'azsdkengsys.azurecr.io/dotnet/ubuntu_netcore_keyring:4484670'
$MIClientId = $DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY_CLIENT_ID']
$MIName = $DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY_NAME']
$SaAccountName = 'workload-identity-sa'
$PodName = $DeploymentOutputs['IDENTITY_AKS_POD_NAME']

Write-Host "Building container"
$image = "$($DeploymentOutputs['IDENTITY_ACR_LOGIN_SERVER'])/identity-managed-id-test"

Set-Content -Path "$PSScriptRoot/Dockerfile" -Value @"
FROM mcr.microsoft.com/azure-powershell:10.3.0-ubuntu-20.04 AS build

ENV \
    NO_AT_BRIDGE=1 \
    DOCKER_CONTAINER_NAME="ubuntu_netcore_keyring" \
     # Unset ASPNETCORE_URLS from aspnet base image
    ASPNETCORE_URLS= \
    # Do not generate certificate
    DOTNET_GENERATE_ASPNET_CERTIFICATE=false \
    # SDK version
    DOTNET_SDK_VERSION_8_0=8.0.405\
    DOTNET_SDK_VERSION_6_0=6.0.413 \
    DOTNET_SDK_VERSION_3_1=3.1.416 \
    # Enable correct mode for dotnet watch (only mode supported in a container)
    DOTNET_USE_POLLING_FILE_WATCHER=true \
    # Skip extraction of XML docs - generally not useful within an image/container - helps performance
    NUGET_XMLDOC_MODE=skip \
    # PowerShell telemetry for docker image usage
    POWERSHELL_DISTRIBUTION_CHANNEL=PSDocker-DotnetSDK-Ubuntu-20.04 \
    # Setup Dotnet envs
    DOTNET_ROOT=/usr/share/dotnet  \
    PATH=$PATH:usr/share/dotnet

# Install apt-add-repository
RUN apt-get update && apt-get install -y software-properties-common

# Install GNOME keyring, git >= 2.35 (for 'git sparse-checkout add' command)
RUN apt-add-repository ppa:git-core/ppa \
    && apt-get update \
    && apt-get install -y \
        libsecret-1-dev \
        dbus-x11 \
        gnome-keyring \
        python \
        curl \
        git


# Install .NET SDK

# https://builds.dotnet.microsoft.com/dotnet/release-metadata/8.0/releases.json
RUN curl -fSL --output dotnet.tar.gz https://download.visualstudio.microsoft.com/download/pr/a91ddad4-a3c2-4303-9efc-1ca6b7af850c/be1763df9211599df1cf1c6f504b3c41/dotnet-sdk-$DOTNET_SDK_VERSION_8_0-linux-x64.tar.gz \
    && dotnet_sha512='2499faa1520e8fd9a287a6798755de1a3ffef31c0dc3416213c8a9bec64861419bfc818f1c1c410b86bb72848ce56d4b6c74839afd8175a922345fc649063ec6' \
    && echo "$dotnet_sha512  dotnet.tar.gz" | sha512sum -c - \
    && mkdir -p /usr/share/dotnet \
    && tar -ozxf dotnet.tar.gz -C /usr/share/dotnet \
    && rm dotnet.tar.gz \
    && if [ ! -e /usr/bin/dotnet ]; then ln -s /usr/share/dotnet/dotnet /usr/bin/dotnet; fi \
    # Trigger first run experience by running arbitrary cmd
    && dotnet help

# Create the target directory
RUN mkdir -p /repo

# Copy relevant top-level files
COPY ../../*.Config /repo/
COPY ../../*.props /repo/
COPY ../../*.targets /repo/

# Copy the eng folder recursively
COPY ../../eng /repo/eng

# Copy Core Shared Source
COPY ../core/Azure.Core/src/Shared /repo/sdk/core/Azure.Core/src/Shared

# Copy the Azure.Identity folder recursively
COPY ./Azure.Identity /repo/sdk/identity/Azure.Identity

# Set the working directory
WORKDIR /repo

# Execute dotnet build
RUN dotnet build /repo/sdk/identity/Azure.Identity/integration/Integration.Identity.Container

RUN echo "Build completed successfully"

# Keep the container running indefinitely
CMD ["tail", "-f", "/dev/null"]
"@

docker build -t $image "$PSScriptRoot"
az acr login -n $DeploymentOutputs['IDENTITY_ACR_NAME']
docker push $image


$aciName = "identity-test"
az container create -g $rg -n $aciName --image $image --os-type Linux --cpu 1 --memory 1 `
  --acr-identity $($DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY']) `
  --assign-identity [system] $($DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY']) `
  --role "Storage Blob Data Reader" `
  --scope $($DeploymentOutputs['IDENTITY_STORAGE_ID']) `
  -e IDENTITY_STORAGE_NAME=$($DeploymentOutputs['IDENTITY_STORAGE_NAME']) `
     AZIDENTITY_STORAGE_NAME_USER_ASSIGNED=$($DeploymentOutputs['IDENTITY_STORAGE_NAME_USER_ASSIGNED']) `
     AZIDENTITY_USER_DEFINED_IDENTITY=$($DeploymentOutputs['IDENTITY_USER_DEFINED_IDENTITY']) `
     FUNCTIONS_CUSTOMHANDLER_PORT=80
Write-Host "##vso[task.setvariable variable=IDENTITY_ACI_NAME;]$aciName"

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