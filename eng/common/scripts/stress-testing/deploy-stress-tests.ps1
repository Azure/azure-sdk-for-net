[CmdletBinding(DefaultParameterSetName = 'Default')]
param(
    [string]$SearchDirectory,
    [hashtable]$Filters,
    [string]$Environment,
    [string]$Repository,
    [switch]$PushImages,
    [string]$ClusterGroup,
    [string]$DeployId,

    [Parameter(ParameterSetName = 'DoLogin', Mandatory = $true)]
    [switch]$Login,

    [Parameter(ParameterSetName = 'DoLogin')]
    [string]$Subscription
)

$ErrorActionPreference = 'Stop'

. $PSScriptRoot/find-all-stress-packages.ps1
$FailedCommands = New-Object Collections.Generic.List[hashtable]

if (!(Get-Module powershell-yaml)) {
    Install-Module -Name powershell-yaml -RequiredVersion 0.4.1 -Force -Scope CurrentUser
}

# Powershell does not (at time of writing) treat exit codes from external binaries
# as cause for stopping execution, so do this via a wrapper function.
# See https://github.com/PowerShell/PowerShell-RFC/pull/277
function Run() {
    Write-Host "`n==> $args`n" -ForegroundColor Green
    $command, $arguments = $args
    & $command $arguments
    if ($LASTEXITCODE) {
        Write-Error "Command '$args' failed with code: $LASTEXITCODE" -ErrorAction 'Continue'
        $FailedCommands.Add(@{ command = "$args"; code = $LASTEXITCODE })
    }
}

function RunOrExitOnFailure() {
    run @args
    if ($LASTEXITCODE) {
        exit $LASTEXITCODE
    }
}

function Login([string]$subscription, [string]$clusterGroup, [boolean]$pushImages) {
    Write-Host "Logging in to subscription, cluster and container registry"
    az account show *> $null
    if ($LASTEXITCODE) {
        RunOrExitOnFailure az login --allow-no-subscriptions
    }

    $clusterName = (az aks list -g $clusterGroup -o json| ConvertFrom-Json).name

    RunOrExitOnFailure az aks get-credentials `
        -n "$clusterName" `
        -g "$clusterGroup" `
        --subscription "$subscription" `
        --overwrite-existing

    if ($pushImages) {
        $registry = (az acr list -g $clusterGroup -o json | ConvertFrom-Json).name
        RunOrExitOnFailure az acr login -n $registry
    }
}

function DeployStressTests(
    [string]$searchDirectory = '.',
    [hashtable]$filters = @{},
    [string]$environment = 'test',
    [string]$repository = 'images',
    [boolean]$pushImages = $false,
    [string]$clusterGroup = 'rg-stress-test-cluster-',
    [string]$deployId = 'local',
    [string]$subscription = 'Azure SDK Test Resources'
) {
    if ($PSCmdlet.ParameterSetName -eq 'DoLogin') {
        Login $subscription $clusterGroup $pushImages
    }

    RunOrExitOnFailure helm repo add stress-test-charts https://stresstestcharts.blob.core.windows.net/helm/
    Run helm repo update
    if ($LASTEXITCODE) { return $LASTEXITCODE }

    $pkgs = FindStressPackages $searchDirectory $filters
    Write-Host "" "Found $($pkgs.Length) stress test packages:"
    Write-Host $pkgs.Directory ""
    foreach ($pkg in $pkgs) {
        Write-Host "Deploying stress test at '$($pkg.Directory)'"
        DeployStressPackage $pkg $deployId $environment $repository $pushImages
    }

    Write-Host "Releases deployed by $deployId"
    Run helm list --all-namespaces -l deployId=$deployId

    if ($FailedCommands) {
        Write-Warning "The following commands failed:"
        foreach ($cmd in $FailedCommands) {
            Write-Error "'$($cmd.command)' failed with code $($cmd.code)" -ErrorAction 'Continue'
        }
        exit 1
    }
}

function DeployStressPackage(
    [object]$pkg,
    [string]$deployId,
    [string]$environment,
    [string]$repository,
    [boolean]$pushImages
) {
    $registry = (az acr list -g $clusterGroup -o json | ConvertFrom-Json).name
    if (!$registry) {
        Write-Host "Could not find container registry in resource group $clusterGroup"
        exit 1
    }

    if ($pushImages) {
        Run helm dependency update $pkg.Directory
        if ($LASTEXITCODE) { return $LASTEXITCODE }

        $dockerFiles = Get-ChildItem "$($pkg.Directory)/Dockerfile*"
        foreach ($dockerFile in $dockerFiles) {
            # Infer docker image name from parent directory name, if file is named `Dockerfile`
            # or from suffix, is file is named like `Dockerfile.myimage` (for multiple dockerfiles).
            $prefix, $imageName = $dockerFile.Name.Split(".")
            if (!$imageName) {
                $imageName = $dockerFile.Directory.Name
            }
            $imageTag = "${registry}.azurecr.io/$($repository.ToLower())/$($imageName):$deployId"
            Write-Host "Building and pushing stress test docker image '$imageTag'"
            Run docker build -t $imageTag -f $dockerFile.FullName $dockerFile.DirectoryName
            if ($LASTEXITCODE) { return $LASTEXITCODE }
            Run docker push $imageTag
            if ($LASTEXITCODE) {
                if ($PSCmdlet.ParameterSetName -ne 'DoLogin') {
                    Write-Warning "If docker push is failing due to authentication issues, try calling this script with '-Login'"
                }
                return $LASTEXITCODE
            }
        }
    }

    Write-Host "Creating namespace $($pkg.Namespace) if it does not exist..."
    kubectl create namespace $pkg.Namespace --dry-run=client -o yaml | kubectl apply -f -

    Write-Host "Installing or upgrading stress test $($pkg.ReleaseName) from $($pkg.Directory)"
    Run helm upgrade $pkg.ReleaseName $pkg.Directory `
        -n $pkg.Namespace `
        --install `
        --set repository=$registry.azurecr.io/$repository `
        --set tag=$deployId `
        --set stress-test-addons.env=$environment
    if ($LASTEXITCODE) {
        # Issues like 'UPGRADE FAILED: another operation (install/upgrade/rollback) is in progress'
        # can be the result of cancelled `upgrade` operations (e.g. ctrl-c).
        # See https://github.com/helm/helm/issues/4558
        Write-Warning "The issue may be fixable by first running 'helm rollback -n $($pkg.Namespace) $($pkg.ReleaseName)'"
        return $LASTEXITCODE
    }
    
    # Helm 3 stores release information in kubernetes secrets. The only way to add extra labels around
    # specific releases (thereby enabling filtering on `helm list`) is to label the underlying secret resources.
    # There is not currently support for setting these labels via the helm cli.
    $helmReleaseConfig = kubectl get secrets `
        -n $pkg.Namespace `
        -l status=deployed,name=$($pkg.ReleaseName) `
        -o jsonpath='{.items[0].metadata.name}'

    Run kubectl label secret -n $pkg.Namespace --overwrite $helmReleaseConfig deployId=$deployId
}

DeployStressTests @PSBoundParameters
