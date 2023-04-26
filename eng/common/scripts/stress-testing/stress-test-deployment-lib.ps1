$ErrorActionPreference = 'Stop'

. $PSScriptRoot/find-all-stress-packages.ps1
$FailedCommands = New-Object Collections.Generic.List[hashtable]

. (Join-Path $PSScriptRoot "../Helpers" PSModule-Helpers.ps1)
. (Join-Path $PSScriptRoot "../SemVer.ps1")

$limitRangeSpec = @"
apiVersion: v1
kind: LimitRange
metadata:
  name: default-resource-request
spec:
  limits:
  - defaultRequest:
      cpu: 100m
      memory: 100Mi
    type: Container
"@

$MIN_HELM_VERSION = "3.11.0"

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

    $kubeContext = (RunOrExitOnFailure kubectl config view -o json) | ConvertFrom-Json -AsHashtable
    $defaultNamespace = $null
    $targetContext = $kubeContext.contexts.Where({ $_.name -eq $clusterName }) | Select -First 1
    if ($targetContext -ne $null -and $targetContext.PSObject.Properties.Name -match "namespace") {
        $defaultNamespace = $targetContext.context.namespace
    }

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
    [Parameter(Mandatory=$False)][switch]$Template,
    [Parameter(Mandatory=$False)][switch]$RetryFailedTests,
    [Parameter(Mandatory=$False)][string]$MatrixFileName,
    [Parameter(Mandatory=$False)][string]$MatrixSelection = "sparse",
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
    } elseif (!$clusterGroup -or !$subscription) {
        throw "clusterGroup and subscription parameters must be specified when deploying to an environment that is not pg or prod."
    }

    if ($login) {
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
                -MatrixFileName $MatrixFileName `
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
            -login:$login `
            -clusterGroup $clusterGroup `
            -subscription $subscription
    }

    if ($FailedCommands.Count -lt $pkgs.Count) {
        Write-Host "Releases deployed by $deployer"
        Run helm list --all-namespaces -l deployId=$deployer
    }

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
    [switch]$login,
    [string]$clusterGroup,
    [string]$subscription
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
    Write-Host "Adding default resource requests to namespace/$($pkg.Namespace)"
    $limitRangeSpec | kubectl apply -n $pkg.Namespace -f -
    if ($LASTEXITCODE) {exit $LASTEXITCODE}

    $dockerBuildConfigs = @()

    $generatedHelmValuesFilePath = Join-Path $pkg.Directory "generatedValues.yaml"
    $generatedHelmValues = Get-Content $generatedHelmValuesFilePath -Raw | ConvertFrom-Yaml -Ordered
    $releaseName = $pkg.ReleaseName
    if ($RetryFailedTests) {
        $releaseName, $generatedHelmValues = generateRetryTestsHelmValues $pkg $releaseName $generatedHelmValues
    }

    if (Test-Path $generatedHelmValuesFilePath) {
        $scenarios = $generatedHelmValues.Scenarios
        foreach ($scenario in $scenarios) {
            if ("image" -in $scenario.keys) {
                $dockerFilePath = Join-Path $pkg.Directory $scenario.image
            } else {
                $dockerFilePath = "$($pkg.Directory)/Dockerfile"
            }
            $dockerFilePath = [System.IO.Path]::GetFullPath($dockerFilePath).Trim()
            if (!(Test-Path $dockerFilePath)) {
                continue
            }

            if ("imageBuildDir" -in $scenario.keys) {
                $dockerBuildDir = Join-Path $pkg.Directory $scenario.imageBuildDir
            } else {
                $dockerBuildDir = Split-Path $dockerFilePath
            }
            $dockerBuildDir = [System.IO.Path]::GetFullPath($dockerBuildDir).Trim()
            $dockerBuildConfigs += @{"dockerFilePath"=$dockerFilePath;
                                    "dockerBuildDir"=$dockerBuildDir;
                                    "scenario"=$scenario}
        }
    }
    if ($pkg.Dockerfile -or $pkg.DockerBuildDir) {
        throw "The chart.yaml docker config is deprecated, please use the scenarios matrix instead."
    }
    

    foreach ($dockerBuildConfig in $dockerBuildConfigs) {
        $dockerFilePath = $dockerBuildConfig.dockerFilePath
        $dockerBuildFolder = $dockerBuildConfig.dockerBuildDir
        if (!(Test-Path $dockerFilePath)) {
            throw "Invalid dockerfile path, cannot find dockerfile at ${dockerFilePath}"
        }
        if (!(Test-Path $dockerBuildFolder)) {
            throw "Invalid docker build directory, cannot find directory ${dockerBuildFolder}"
        }
        $dockerfileName = ($dockerFilePath -split { $_ -in '\', '/' })[-1].ToLower()
        $imageTag = $imageTagBase + "/${dockerfileName}:${deployId}"
        if ($pushImages) {
            Write-Host "Building and pushing stress test docker image '$imageTag'"
            $dockerFile = Get-ChildItem $dockerFilePath

            $dockerBuildCmd = "docker", "build", "-t", $imageTag, "-f", $dockerFile
            foreach ($buildArg in $dockerBuildConfig.scenario.GetEnumerator()) {
                $dockerBuildCmd += "--build-arg"
                $dockerBuildCmd += "'$($buildArg.Key)'='$($buildArg.Value)'"
            }
            $dockerBuildCmd += $dockerBuildFolder

            Run @dockerBuildCmd
            
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
            }
        }
        $generatedHelmValues.scenarios = @( foreach ($scenario in $generatedHelmValues.scenarios) {
            $dockerPath = if ("image" -notin $scenario) {
                $dockerFilePath
            } else {
                Join-Path $pkg.Directory $scenario.image
            }
            if ([System.IO.Path]::GetFullPath($dockerPath) -eq $dockerFilePath) {
                $scenario.imageTag = $imageTag
            }
            $scenario
        } )

        $generatedHelmValues | ConvertTo-Yaml | Out-File -FilePath $generatedHelmValuesFilePath
    }

    Write-Host "Installing or upgrading stress test $releaseName from $($pkg.Directory)"

    $generatedConfigPath = Join-Path $pkg.Directory generatedValues.yaml
    $subCommand = $Template ? "template" : "upgrade"
    $installFlag = $Template ? "" : "--install"
    $helmCommandArg = "helm", $subCommand, $releaseName, $pkg.Directory, "-n", $pkg.Namespace, $installFlag, "--set", "stress-test-addons.env=$environment", "--values", $generatedConfigPath

    $result = (Run @helmCommandArg) 2>&1 | Write-Host

    if ($LASTEXITCODE) {
        # Error: UPGRADE FAILED: create: failed to create: Secret "sh.helm.release.v1.stress-test.v3" is invalid: data: Too long: must have at most 1048576 bytes
        # Error: UPGRADE FAILED: create: failed to create: Request entity too large: limit is 3145728
        if ($result -like "*Too long*" -or $result -like "*Too large*") {
          $result
          Write-Warning "*** Ensure any files or directories not part of the stress config are added to .helmignore ***"
          Write-Warning "*** See https://helm.sh/docs/chart_template_guide/helm_ignore_file/ ***"
          return
        } else {
          # Issues like 'UPGRADE FAILED: another operation (install/upgrade/rollback) is in progress'
          # can be the result of cancelled `upgrade` operations (e.g. ctrl-c).
          # See https://github.com/helm/helm/issues/4558
          Write-Warning "The issue may be fixable by first running 'helm rollback -n $($pkg.Namespace) $releaseName'"
          return
        }
    }

    # Helm 3 stores release information in kubernetes secrets. The only way to add extra labels around
    # specific releases (thereby enabling filtering on `helm list`) is to label the underlying secret resources.
    # There is not currently support for setting these labels via the helm cli.
    if(!$Template) {
        $helmReleaseConfig = RunOrExitOnFailure kubectl get secrets `
                                                -n $pkg.Namespace `
                                                -l "status=deployed,name=$releaseName" `
                                                -o jsonpath='{.items[0].metadata.name}'
        Run kubectl label secret -n $pkg.Namespace --overwrite $helmReleaseConfig deployId=$deployId
    }
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

    # helm version example: v3.11.2+g912ebc1
    $helmVersionString = (helm version --short).substring(1) -replace '\+.*',''
    $helmVersion = [AzureEngSemanticVersion]::new($helmVersionString)
    $minHelmVersion = [AzureEngSemanticVersion]::new($MIN_HELM_VERSION)
    if ($helmVersion.CompareTo($minHelmVersion) -lt 0) {
        throw "Please update helm to version >= $MIN_HELM_VERSION (current version: $helmVersionString)`nAdditional information for updating helm version can be found here: https://helm.sh/docs/intro/install/"
    }

    if ($shouldError) {
        exit 1
    }

}

function generateRetryTestsHelmValues ($pkg, $releaseName, $generatedHelmValues) {

    $podOutput = RunOrExitOnFailure kubectl get pods -n $pkg.namespace -o json
    $pods = $podOutput | ConvertFrom-Json

    # Get all jobs within this helm release
    $helmStatusOutput = RunOrExitOnFailure helm status -n $pkg.Namespace $pkg.ReleaseName --show-resources
    # -----Example output-----
    # NAME: <Release Name>
    # LAST DEPLOYED: Mon Jan 01 12:12:12 2020
    # NAMESPACE: <namespace>
    # STATUS: deployed
    # REVISION: 10
    # RESOURCES:
    # ==> v1alpha1/Schedule
    # NAME                          AGE
    # <schedule resource name 1>    5h5m
    # <schedule resource name 2>    5h5m

    # ==> v1/SecretProviderClass
    # <secret provider name 1>   7d4h

    # ==> v1/Job
    # NAME          COMPLETIONS   DURATION   AGE
    # <job name 1>   0/1          5h5m       5h5m
    # <job name 2>   0/1          5h5m       5h5m
    $discoveredJob = $False
    $jobs = @()
    foreach ($line in $helmStatusOutput) {
        if ($discoveredJob -and $line -match "==>") {break}
        if ($discoveredJob) {
            $jobs += ($line -split '\s+')[0] | Where-Object {($_ -ne "NAME") -and ($_)}
        }
        if ($line -match "==> v1/Job") {
            $discoveredJob = $True
        }
    }

    $failedJobsScenario = @()
    $revision = 0
    foreach ($job in $jobs) {
        $jobRevision = [int]$job.split('-')[-1]
        if ($jobRevision -gt $revision) {
            $revision = $jobRevision
        }

        $jobOutput = RunOrExitOnFailure kubectl describe jobs -n $pkg.Namespace $job
        $podPhase = $jobOutput | Select-String "0 Failed"
        if ([System.String]::IsNullOrEmpty($podPhase)) {
            $failedJobsScenario += $job.split("-$($pkg.ReleaseName)")[0]
        }
    }
    
    $releaseName = "$($pkg.ReleaseName)-$revision-retry"

    $retryTestsHelmVal = @{"scenarios"=@()}
    foreach ($failedScenario in $failedJobsScenario) {
        $failedScenarioObject = $generatedHelmValues.scenarios | Where {$_.Scenario -eq $failedScenario}
        $retryTestsHelmVal.scenarios += $failedScenarioObject
    }

    if (!$retryTestsHelmVal.scenarios.length) {
        Write-Host "There are no failed pods to retry."
        return
    }
    $generatedHelmValues = $retryTestsHelmVal
    return $releaseName, $generatedHelmValues
}
