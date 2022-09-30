$ErrorActionPreference = 'Stop'

. $PSScriptRoot/find-all-stress-packages.ps1
$FailedCommands = New-Object Collections.Generic.List[hashtable]

. (Join-Path $PSScriptRoot "../Helpers" PSModule-Helpers.ps1)

# Powershell does not (at time of writing) treat exit codes from external binaries
# as cause for stopping execution, so do this via a wrapper function.
# See https://github.com/PowerShell/PowerShell-RFC/pull/277
function Run()
{
    Write-Host "`n==> $args`n" -ForegroundColor Green
    $command, $arguments = $args
    & $command $arguments
    if ($LASTEXITCODE) {
        Write-Error "Command '$args' failed with code: $LASTEXITCODE" -ErrorAction 'Continue'
        $FailedCommands.Add(@{ command = "$args"; code = $LASTEXITCODE })
    }
}

function RunOrExitOnFailure()
{
    run @args
    if ($LASTEXITCODE) {
        exit $LASTEXITCODE
    }
}

function Login([string]$subscription, [string]$clusterGroup, [switch]$pushImages)
{
    Write-Host "Logging in to subscription, cluster and container registry"
    az account show *> $null
    if ($LASTEXITCODE) {
        RunOrExitOnFailure az login --allow-no-subscriptions
    }

    # Discover cluster name, only one cluster per group is expected
    Write-Host "Listing AKS cluster in $subscription/$clusterGroup"
    $cluster = RunOrExitOnFailure az aks list -g $clusterGroup --subscription $subscription -o json
    $clusterName = ($cluster | ConvertFrom-Json).name

    $kubeContext = (RunOrExitOnFailure kubectl config view -o json) | ConvertFrom-Json
    $defaultNamespace = $kubeContext.contexts.Where({ $_.name -eq $clusterName }).context.namespace

    RunOrExitOnFailure az aks get-credentials `
        -n "$clusterName" `
        -g "$clusterGroup" `
        --subscription "$subscription" `
        --overwrite-existing

    if ($defaultNamespace) {
        RunOrExitOnFailure kubectl config set-context $clusterName --namespace $defaultNamespace
    }

    if ($pushImages) {
        $registry = RunOrExitOnFailure az acr list -g $clusterGroup --subscription $subscription -o json
        $registryName = ($registry | ConvertFrom-Json).name
        RunOrExitOnFailure az acr login -n $registryName
    }
}

function DeployStressTests(
    [string]$searchDirectory = '.',
    [hashtable]$filters = @{},
    # Default to playground environment
    [string]$environment = 'pg',
    [string]$repository = '',
    [switch]$pushImages,
    [string]$clusterGroup = '',
    [string]$deployId = '',
    [switch]$login,
    [string]$subscription = '',
    [switch]$CI,
    [string]$Namespace,
    [ValidateScript({
        if (!(Test-Path $_)) {
            throw "LocalAddonsPath $LocalAddonsPath does not exist"
        }
        return $true
    })]
    [System.IO.FileInfo]$LocalAddonsPath,
    [string]$MatrixSelection,
    [Parameter(Mandatory=$False)][string]$MatrixDisplayNameFilter,
    [Parameter(Mandatory=$False)][array]$MatrixFilters,
    [Parameter(Mandatory=$False)][array]$MatrixReplace,
    [Parameter(Mandatory=$False)][array]$MatrixNonSparseParameters
) {
    if ($environment -eq 'pg') {
        if ($clusterGroup -or $subscription) {
            Write-Warning "Overriding cluster group and subscription with defaults for 'pg' environment."
        }
        $clusterGroup = 'rg-stress-cluster-pg'
        $subscription = 'Azure SDK Developer Playground'
    } elseif ($environment -eq 'prod') {
        if ($clusterGroup -or $subscription) {
            Write-Warning "Overriding cluster group and subscription with defaults for 'prod' environment."
        }
        $clusterGroup = 'rg-stress-cluster-prod'
        $subscription = 'Azure SDK Test Resources'
    }

    if ($login) {
        if (!$clusterGroup -or !$subscription) {
            throw "clusterGroup and subscription parameters must be specified when logging into an environment that is not pg or prod."
        }
        Login -subscription $subscription -clusterGroup $clusterGroup -pushImages:$pushImages
    }

    $chartRepoName = 'stress-test-charts'
    if ($LocalAddonsPath) {
        $absAddonsPath = Resolve-Path $LocalAddonsPath
        if (!(helm plugin list | Select-String 'file')) {
            RunOrExitOnFailure helm plugin add (Join-Path $absAddonsPath file-plugin)
        }
        RunOrExitOnFailure helm repo add --force-update $chartRepoName file://$absAddonsPath
    } else {
        RunOrExitOnFailure helm repo add --force-update $chartRepoName https://stresstestcharts.blob.core.windows.net/helm/
    }

    Run helm repo update
    if ($LASTEXITCODE) { return $LASTEXITCODE }
    $deployer = if ($deployId) { $deployId } else { GetUsername }
    $pkgs = @(FindStressPackages `
                -directory $searchDirectory `
                -filters $filters `
                -CI:$CI `
                -namespaceOverride $Namespace `
                -MatrixSelection $MatrixSelection `
                -MatrixFilters $MatrixFilters `
                -MatrixReplace $MatrixReplace `
                -MatrixNonSparseParameters $MatrixNonSparseParameters)
    Write-Host "" "Found $($pkgs.Length) stress test packages:"
    Write-Host $pkgs.Directory ""
    foreach ($pkg in $pkgs) {
        Write-Host "Deploying stress test at '$($pkg.Directory)'"
        DeployStressPackage `
            -pkg $pkg `
            -deployId $deployer `
            -environment $environment `
            -repositoryBase $repository `
            -pushImages:$pushImages `
            -login:$login
    }

    Write-Host "Releases deployed by $deployer"
    Run helm list --all-namespaces -l deployId=$deployer

    if ($FailedCommands) {
        Write-Warning "The following commands failed:"
        foreach ($cmd in $FailedCommands) {
            Write-Error "'$($cmd.command)' failed with code $($cmd.code)" -ErrorAction 'Continue'
        }
        exit 1
    }

    Write-Host "`nStress test telemetry links (dashboard, fileshare, etc.): https://aka.ms/azsdk/stress/dashboard"
}

function DeployStressPackage(
    [object]$pkg,
    [string]$deployId,
    [string]$environment,
    [string]$repositoryBase,
    [switch]$pushImages,
    [switch]$login
) {
    $registry = RunOrExitOnFailure az acr list -g $clusterGroup --subscription $subscription -o json
    $registryName = ($registry | ConvertFrom-Json).name

    Run helm dependency update $pkg.Directory
    if ($LASTEXITCODE) { return }

    if (Test-Path "$($pkg.Directory)/stress-test-resources.bicep") {
        Run az bicep build -f "$($pkg.Directory)/stress-test-resources.bicep"
        if ($LASTEXITCODE) { return }
    }

    $imageTagBase = "${registryName}.azurecr.io"
    if ($repositoryBase) {
        $imageTagBase += "/$repositoryBase"
    }
    $imageTagBase += "/$($pkg.Namespace)/$($pkg.ReleaseName)"

    Write-Host "Creating namespace $($pkg.Namespace) if it does not exist..."
    kubectl create namespace $pkg.Namespace --dry-run=client -o yaml | kubectl apply -f -
    if ($LASTEXITCODE) {exit $LASTEXITCODE}

    $dockerFilePaths = @()
    
    $genValFile = Join-Path $pkg.Directory "generatedValues.yaml"
    $genVal = Get-Content $genValFile -Raw | ConvertFrom-Yaml
    if (Test-Path $genValFile) {
        $scenarios = $genVal.Scenarios
        foreach ($scenario in $scenarios) {
            if ($scenario.image) {
                $dockerfilePath = Join-Path $pkg.Directory $scenario.image
                $dockerFilePath = [System.IO.Path]::GetFullPath($dockerFilePath)
                $dockerFilePaths += $dockerFilePath
            }
        }
    } else {
        if ($pkg.Dockerfile) {
            $dockerFilePath = Join-Path $pkg.Directory $pkg.Dockerfile
        } else {
            $dockerFilePath = "$($pkg.Directory)/Dockerfile"
        }
        $dockerFilePath = [System.IO.Path]::GetFullPath($dockerFilePath)
        $dockerFilePaths += $dockerFilePath
    }
    

    foreach ($dockerFilePath in $dockerFilePaths) {
        if (!(Test-Path $dockerFilePath)) {continue}
        $dockerfileName = ($dockerfilePath -split { $_ -in '\', '/' })[-1].ToLower()
        $imageTag = $imageTagBase + "/${dockerfileName}:${deployId}"
        if ($pushImages) {
            Write-Host "Building and pushing stress test docker image '$imageTag'"
            $dockerFile = Get-ChildItem $dockerFilePath
            $dockerBuildFolder = if ($pkg.DockerBuildDir) {
                Join-Path $pkg.Directory $pkg.DockerBuildDir
            } else {
                $dockerFile.DirectoryName
            }
            $dockerBuildFolder = [System.IO.Path]::GetFullPath($dockerBuildFolder).Trim()

            Run docker build -t $imageTag -f $dockerFile $dockerBuildFolder
            if ($LASTEXITCODE) { return }

            Write-Host "`nContainer image '$imageTag' successfully built. To run commands on the container locally:" -ForegroundColor Blue
            Write-Host "  docker run -it $imageTag" -ForegroundColor DarkBlue
            Write-Host "  docker run -it $imageTag <shell, e.g. 'bash' 'pwsh' 'sh'>" -ForegroundColor DarkBlue
            Write-Host "To show installed container images:" -ForegroundColor Blue
            Write-Host "  docker image ls" -ForegroundColor DarkBlue
            Write-Host "To show running containers:" -ForegroundColor Blue
            Write-Host "  docker ps" -ForegroundColor DarkBlue

            Run docker push $imageTag
            if ($LASTEXITCODE) {
                if ($login) {
                    Write-Warning "If docker push is failing due to authentication issues, try calling this script with '-Login'"
                }
                return
            }
        }
        ($genVal.scenarios | Where-Object {
                $dockerPath = Join-Path $pkg.Directory $_.image;
                [System.IO.Path]::GetFullPath($dockerPath) -eq
                $dockerFilePath }).ForEach({$_.imageTag = $imageTag})
        $genVal | ConvertTo-Yaml | Out-File -FilePath $genValFile
    }

    Write-Host "Installing or upgrading stress test $($pkg.ReleaseName) from $($pkg.Directory)"
    Run helm upgrade $pkg.ReleaseName $pkg.Directory `
        -n $pkg.Namespace `
        --install `
        --set stress-test-addons.env=$environment `
        --values generatedValues.yaml
    if ($LASTEXITCODE) {
        # Issues like 'UPGRADE FAILED: another operation (install/upgrade/rollback) is in progress'
        # can be the result of cancelled `upgrade` operations (e.g. ctrl-c).
        # See https://github.com/helm/helm/issues/4558
        Write-Warning "The issue may be fixable by first running 'helm rollback -n $($pkg.Namespace) $($pkg.ReleaseName)'"
        return
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

function CheckDependencies()
{
    $deps = @(
        @{
            Command = "docker";
            Help = "Docker must be installed: https://docs.docker.com/get-docker/";
        }
        @{
            Command = "kubectl";
            Help = "kubectl must be installed: https://kubernetes.io/docs/tasks/tools/#kubectl";
        },
        @{
            Command = "helm";
            Help = "helm must be installed: https://helm.sh/docs/intro/install/";
        },
        @{
            Command = "az";
            Help = "Azure CLI must be installed: https://docs.microsoft.com/cli/azure/install-azure-cli";
        }
    )

    Install-ModuleIfNotInstalled "powershell-yaml" "0.4.1" | Import-Module

    $shouldError = $false
    foreach ($dep in $deps) {
        if (!(Get-Command $dep.Command -ErrorAction SilentlyContinue)) {
            $shouldError = $true
            Write-Error $dep.Help
        }
    }

    if ($shouldError) {
        exit 1
    }

}
