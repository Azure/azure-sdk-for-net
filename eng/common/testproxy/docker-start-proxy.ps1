 #!/usr/bin/env pwsh -c

<#
.DESCRIPTION
Start the docker proxy container. If it is already running, quietly exit. Any other error should fail.
.PARAMETER Mode
"start" or "stop" to start up or stop the test-proxy instance.
.PARAMETER TargetFolder
The folder in which context the test proxy will be started. Defaults to current working directory.
#>
[CmdletBinding(SupportsShouldProcess = $true)]
param(
    [ValidateSet("start", "stop")]
    [String]
    $Mode,
    [String]
    $TargetFolder = "."
)

try {
    docker --version | Out-Null
}
catch {
    Write-Error "A invocation of docker --version failed. This indicates that docker is not properly installed or running."
    Write-Error "Please check your docker invocation and try running the script again."
}

$SELECTED_IMAGE_TAG = "1084681"
$CONTAINER_NAME = "ambitious_azsdk_test_proxy"
$LINUX_IMAGE_SOURCE = "azsdkengsys.azurecr.io/engsys/testproxy-lin:${SELECTED_IMAGE_TAG}"
$WINDOWS_IMAGE_SOURCE = "azsdkengsys.azurecr.io/engsys/testproxy-win:${SELECTED_IMAGE_TAG}"
$root = (Resolve-Path $TargetFolder).Path.Replace("`\", "/")

function Get-Proxy-Container(){
    return (docker container ls -a --format "{{ json . }}" --filter "name=$CONTAINER_NAME" `
                | ConvertFrom-Json `
                | Select-Object -First 1)
}


$SelectedImage = $LINUX_IMAGE_SOURCE
$Initial = ""

# most of the time, running this script on a windows machine will work just fine, as docker defaults to linux containers
# however, in CI, windows images default to _windows_ containers. We cannot swap them. We can tell if we're in a CI build by
# checking for the environment variable TF_BUILD.
if ($IsWindows -and $env:TF_BUILD){
    $SelectedImage = $WINDOWS_IMAGE_SOURCE
    $Initial = "C:"
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
        Write-Host "Attempting creation of Docker host $CONTAINER_NAME"
        Write-Host "docker container create -v `"${root}:${Initial}/etc/testproxy`" -p 5001:5001 -p 5000:5000 --name $CONTAINER_NAME $SelectedImage"
        docker container create -v "${root}:${Initial}/etc/testproxy" -p 5001:5001 -p 5000:5000 --name $CONTAINER_NAME $SelectedImage
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
