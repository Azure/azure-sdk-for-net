#!/usr/bin/env pwsh -c

<#
.SYNOPSIS
Easy start/stop of docker proxy.

.DESCRIPTION
Start the docker proxy container. If it is already running, quietly exit. Any other error should fail.

.PARAMETER Mode
Pass value "start" or "stop" to start up or stop the test-proxy instance.

.PARAMETER TargetFolder
The folder in which context the test proxy will be started. Defaults to current working directory.

.PARAMETER VersionOverride
This script defaults the proxy version to the "common" version synced across all sdk repositories. If provided,
this parameter's value will be used as the target tag when downloading the image from azsdk docker hosting.
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [ValidateSet("start", "stop")]
    [String]
    $Mode,
    [String]
    $TargetFolder = "",
    [String]
    $VersionOverride = ""
)

try {
    docker --version | Out-Null
}
catch {
    Write-Error "A invocation of docker --version failed. This indicates that docker is not properly installed or running."
    Write-Error "Please check your docker invocation and try running the script again."
}

$SELECTED_IMAGE_TAG = $(Get-Content "$PSScriptRoot/target_version.txt" -Raw).Trim()
$CONTAINER_NAME = "ambitious_azsdk_test_proxy"
$IMAGE_SOURCE = "azsdkengsys.azurecr.io/engsys/test-proxy:${SELECTED_IMAGE_TAG}"

if($VersionOverride) { 
    Write-Host "Overriding default target proxy version of '$SELECTED_IMAGE_TAG' with override $VersionOverride."
    $SELECTED_IMAGE_TAG = $VersionOverride
} 

if (-not $TargetFolder){
    $TargetFolder = Join-Path -Path $PSScriptRoot -ChildPath "../../../"
}

$root = (Resolve-Path $TargetFolder).Path.Replace("`\", "/")

function Get-Proxy-Container(){
    return (docker container ls -a --format "{{ json . }}" --filter "name=$CONTAINER_NAME" `
                | ConvertFrom-Json `
                | Select-Object -First 1)
}

$Initial = ""
$AdditionalContainerArgs = "--add-host=host.docker.internal:host-gateway"

# most of the time, running this script on a windows machine will work just fine, as docker defaults to linux containers
# however, in CI, windows images default to _windows_ containers. We cannot swap them. We can tell if we're in a CI build by
# checking for the environment variable TF_BUILD.
if ($IsWindows -and $env:TF_BUILD){
    $Initial = "C:"
    $AdditionalContainerArgs = ""
}

# there isn't really a great way to get environment variables automagically from the CI environment to the docker image
# handle loglevel here so that setting such a setting in CI will also bump the docker logging
if ($env:Logging__LogLevel__Default) {
    $AdditionalContainerArgs += "-e Logging__LogLevel__Default=$($env:Logging__LogLevel__Default)"
}

if ($Mode -eq "start"){
    $proxyContainer = Get-Proxy-Container

    # if we already have one, we just need to check the state
    if($proxyContainer){
        if ($proxyContainer.State -eq "running")
        {
            Write-Host "Discovered an already running instance of the test-proxy!. Exiting"
            exit(0)
        }
    }
    # else we need to create it
    else {
        $attempts = 0
        Write-Host "Attempting creation of Docker host $CONTAINER_NAME"
        Write-Host "docker container create -v `"${root}:${Initial}/srv/testproxy`" $AdditionalContainerArgs -p 5001:5001 -p 5000:5000 --name $CONTAINER_NAME $IMAGE_SOURCE"
        while($attempts -lt 3){
            docker container create -v "${root}:${Initial}/srv/testproxy" $AdditionalContainerArgs -p 5001:5001 -p 5000:5000 --name $CONTAINER_NAME $IMAGE_SOURCE

            if($LASTEXITCODE -ne 0){
                $attempts += 1
                Start-Sleep -s 10

                if($attempts -lt 3){
                    Write-Host "Attempt $attempts failed. Retrying."
                }

                continue
            }
            else {
                break
            }
        }

        if($LASTEXITCODE -ne 0){
            Write-Host "Unable to successfully create docker container. Exiting."
            exit(1)
        }
    }

    Write-Host "Attempting start of Docker host $CONTAINER_NAME"
    docker container start $CONTAINER_NAME
}

if ($Mode -eq "stop"){
    $proxyContainer = Get-Proxy-Container

    if($proxyContainer){
        if($proxyContainer.State -eq "running"){
            Write-Host "Found a running instance of $CONTAINER_NAME, shutting it down."
            docker container stop $CONTAINER_NAME
        }
    }
}