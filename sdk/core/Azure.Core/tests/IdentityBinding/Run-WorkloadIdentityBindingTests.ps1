# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License.

#Requires -Version 7.4

[CmdletBinding()]
param(
    [Parameter(Mandatory)]
    [string] $SubscriptionId,
    [Parameter(Mandatory)]
    [string] $ResourceGroup,
    [Parameter(Mandatory)]
    [string] $ClusterName,
    [Parameter(Mandatory)]
    [string] $IdentityName
)

$ErrorActionPreference = 'Stop'
$PSNativeCommandUseErrorActionPreference = $true
$repo = (Resolve-Path (Join-Path $PSScriptRoot '..\..\..\..\..')).Path
$state = Join-Path $repo "artifacts\aks-identity-binding-ga\live-$(Get-Date -Format 'yyyyMMdd-HHmmss')"
New-Item -ItemType Directory -Path $state | Out-Null

$account = az account show --subscription $SubscriptionId --output json | ConvertFrom-Json
if ($account.environmentName -ne 'AzureCloud') {
    throw 'This live test requires Azure public cloud.'
}
$group = az group show --subscription $SubscriptionId --name $ResourceGroup --output json | ConvertFrom-Json
if ($group.tags.sample -ne 'workload-identity-proxy') {
    throw 'Use a dedicated resource group tagged sample=workload-identity-proxy.'
}
$deadline = [DateTimeOffset]::UtcNow.AddMinutes(10)
do {
    $cluster = az aks show --subscription $SubscriptionId --resource-group $ResourceGroup --name $ClusterName --output json | ConvertFrom-Json
    if ($cluster.provisioningState -eq 'Succeeded') {
        break
    }
    if ($cluster.provisioningState -notin @('Creating', 'Updating') -or [DateTimeOffset]::UtcNow -ge $deadline) {
        throw "Cluster readiness failed: $($cluster.provisioningState)."
    }
    Start-Sleep -Seconds 10
} while ($true)
if ($cluster.provisioningState -ne 'Succeeded' -or !$cluster.securityProfile.workloadIdentity.enabled -or !$cluster.oidcIssuerProfile.enabled) {
    throw 'The cluster must be ready with workload identity and OIDC enabled.'
}
if ($cluster.apiServerAccessProfile.enableVnetIntegration) {
    throw 'AKS identity binding does not support API server VNet integration.'
}
$identity = az identity show --subscription $SubscriptionId --resource-group $ResourceGroup --name $IdentityName --output json | ConvertFrom-Json
if ($identity.tenantId -ne $account.tenantId) {
    throw 'The identity and cluster subscription must use the same tenant.'
}
$bindings = @(az aks identity-binding list --subscription $SubscriptionId --resource-group $ResourceGroup --cluster-name $ClusterName --output json | ConvertFrom-Json)
if (!($bindings | Where-Object { $_.properties.managedIdentity.resourceId -ieq $identity.id -and $_.properties.provisioningState -eq 'Succeeded' })) {
    az aks identity-binding create --subscription $SubscriptionId --resource-group $ResourceGroup --cluster-name $ClusterName `
        --name "$IdentityName-binding" --managed-identity-resource-id $identity.id --output none
}
$fics = @(az identity federated-credential list --subscription $SubscriptionId --resource-group $ResourceGroup --identity-name $IdentityName --output json | ConvertFrom-Json)
if ($fics.Count -ne 1 -or $fics[0].name -ne 'aks-identity-binding') {
    throw 'The negative test requires only the AKS-managed aks-identity-binding FIC; do not add a conventional FIC.'
}
$roles = @(az role assignment list --subscription $SubscriptionId --scope $group.id --include-inherited --output json | ConvertFrom-Json)
if ($roles | Where-Object { $_.principalId -eq $identity.principalId }) {
    throw 'The direct-upload test identity must not have Azure roles on the test resource group.'
}

$kubeconfig = Join-Path $state 'kubeconfig'
az aks get-credentials --subscription $SubscriptionId --resource-group $ResourceGroup --name $ClusterName --admin --file $kubeconfig --output none
$kube = @('--kubeconfig', $kubeconfig)
kubectl @kube wait --for=condition=Ready nodes --all --timeout=180s
$existingNamespace = kubectl @kube get namespace wi-proxy --ignore-not-found --output json
if ($existingNamespace) {
    $namespace = $existingNamespace | ConvertFrom-Json
    if ($namespace.metadata.labels.'app.kubernetes.io/part-of' -ne 'workload-identity-proxy') {
        throw 'Refusing to overwrite a namespace that is not owned by this test.'
    }
}

$publish = Join-Path $state 'publish'
dotnet publish (Join-Path $PSScriptRoot '..\Azure.Core.Tests.csproj') --configuration Release `
    --framework net10.0 --runtime linux-x64 --self-contained false --output $publish --verbosity quiet
$expectedCoreHash = (Get-FileHash (Join-Path $publish 'Azure.Core.dll') -Algorithm SHA256).Hash

$identityManifest = @"
apiVersion: v1
kind: Namespace
metadata:
  name: wi-proxy
  labels:
    app.kubernetes.io/part-of: workload-identity-proxy
---
apiVersion: v1
kind: ServiceAccount
metadata:
  name: wi-proxy
  namespace: wi-proxy
  annotations:
    azure.workload.identity/client-id: "$($identity.clientId)"
    azure.workload.identity/tenant-id: "$($identity.tenantId)"
---
apiVersion: rbac.authorization.k8s.io/v1
kind: ClusterRole
metadata:
  name: wi-proxy-$($identity.clientId)
rules:
  - verbs: ["use-managed-identity"]
    apiGroups: ["cid.wi.aks.azure.com"]
    resources: ["$($identity.clientId)"]
---
apiVersion: rbac.authorization.k8s.io/v1
kind: ClusterRoleBinding
metadata:
  name: wi-proxy-$($identity.clientId)
roleRef:
  apiGroup: rbac.authorization.k8s.io
  kind: ClusterRole
  name: wi-proxy-$($identity.clientId)
subjects:
  - kind: ServiceAccount
    name: wi-proxy
    namespace: wi-proxy
"@
$identityManifest | kubectl @kube apply --filename -
kubectl @kube --namespace wi-proxy delete job wi-proxy-enabled wi-proxy-disabled --ignore-not-found --wait=true

$jobTimeoutSeconds = 600

function Get-RemainingJobSeconds {
    param(
        [System.Diagnostics.Stopwatch] $Timer,
        [int] $MaximumSeconds = $jobTimeoutSeconds
    )

    $remaining = [int][Math]::Floor($jobTimeoutSeconds - $Timer.Elapsed.TotalSeconds)
    if ($remaining -le 0) {
        throw "Live job exceeded its $jobTimeoutSeconds-second lifecycle budget. See redacted logs in $state."
    }
    return [Math]::Min($remaining, $MaximumSeconds)
}

$logCollectionFailures = @()
foreach ($mode in @('enabled', 'disabled')) {
    $testMethod = if ($mode -eq 'enabled') { 'AuthenticateWithProxy' } else { 'AuthenticateWithoutProxy' }
    $jobManifest = @"
apiVersion: batch/v1
kind: Job
metadata:
  name: wi-proxy-$mode
  namespace: wi-proxy
spec:
  backoffLimit: 0
  activeDeadlineSeconds: $jobTimeoutSeconds
  template:
    metadata:
      labels:
        azure.workload.identity/use: "true"
      annotations:
        azure.workload.identity/use-identity-binding: "true"
    spec:
      serviceAccountName: wi-proxy
      restartPolicy: Never
      nodeSelector:
        kubernetes.io/os: linux
        kubernetes.io/arch: amd64
      securityContext:
        runAsNonRoot: true
        runAsUser: 1654
        runAsGroup: 1654
        fsGroup: 1654
        seccompProfile:
          type: RuntimeDefault
      containers:
        - name: app
          image: mcr.microsoft.com/dotnet/sdk:10.0
          command: ["/bin/sh", "-c"]
          args:
            - >-
              while [ ! -f /app/.ready ]; do sleep 1; done;
              dotnet vstest /app/Azure.Core.Tests.dll
              --TestCaseFilter:FullyQualifiedName=Azure.Core.Tests.IdentityBinding.WorkloadIdentityBindingLiveTests.$testMethod
              --TestAdapterPath:/app
              '--logger:trx;LogFileName=$mode.trx'
              '--logger:console;verbosity=detailed'
              --ResultsDirectory:/tmp/test-results;
              result=`$?;
              grep -o '<Counters [^>]*/>' /tmp/test-results/$mode.trx;
              exit "`$result"
          env:
            - name: ARM_RESOURCE_ID
              value: "$($group.id)"
            - name: AZURE_TEST_MODE
              value: Live
            - name: AZURE_CORE_IDENTITY_BINDING_TESTS
              value: "true"
            - name: DOTNET_CLI_HOME
              value: /tmp
            - name: HOME
              value: /tmp
            - name: DOTNET_NOLOGO
              value: "true"
            - name: DOTNET_CLI_TELEMETRY_OPTOUT
              value: "1"
            - name: DOTNET_GENERATE_ASPNET_CERTIFICATE
              value: "false"
          securityContext:
            readOnlyRootFilesystem: true
            allowPrivilegeEscalation: false
            capabilities:
              drop: ["ALL"]
          resources:
            requests:
              cpu: 250m
              memory: 256Mi
            limits:
              cpu: "2"
              memory: 1Gi
          volumeMounts:
            - name: app
              mountPath: /app
            - name: tmp
              mountPath: /tmp
      volumes:
        - name: app
          emptyDir: {}
        - name: tmp
          emptyDir: {}
"@
    $jobTimer = [System.Diagnostics.Stopwatch]::StartNew()
    try {
        $remaining = Get-RemainingJobSeconds $jobTimer
        $jobManifest | kubectl @kube --request-timeout="${remaining}s" apply --filename -
        $remaining = Get-RemainingJobSeconds $jobTimer
        $waitTimeout = Get-RemainingJobSeconds $jobTimer -MaximumSeconds 180
        kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy wait --for=create pod --selector "job-name=wi-proxy-$mode" --timeout="${waitTimeout}s"
        $remaining = Get-RemainingJobSeconds $jobTimer
        $waitTimeout = Get-RemainingJobSeconds $jobTimer -MaximumSeconds 180
        kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy wait --for=condition=Ready pod --selector "job-name=wi-proxy-$mode" --timeout="${waitTimeout}s"
        $remaining = Get-RemainingJobSeconds $jobTimer
        $pod = kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy get pod --selector "job-name=wi-proxy-$mode" --output 'jsonpath={.items[0].metadata.name}'
        # The emptyDir root is kubelet-owned; do not restore its archived directory metadata.
        $remaining = Get-RemainingJobSeconds $jobTimer
        tar -C $publish -cf - . | kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy exec --stdin $pod --container app -- tar --no-same-owner --no-same-permissions --no-overwrite-dir -xf - -C /app
        $remaining = Get-RemainingJobSeconds $jobTimer
        kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy exec $pod --container app -- touch /app/.ready
        do {
            $remaining = Get-RemainingJobSeconds $jobTimer
            $job = kubectl @kube --request-timeout="${remaining}s" --namespace wi-proxy get job "wi-proxy-$mode" --output json | ConvertFrom-Json
            $failed = @($job.status.conditions | Where-Object { $_.type -in @('Failed', 'FailureTarget') -and $_.status -eq 'True' })
            if ($failed.Count -gt 0) {
                throw "Live job failed: wi-proxy-$mode. See redacted logs in $state."
            }
            $complete = @($job.status.conditions | Where-Object { $_.type -eq 'Complete' -and $_.status -eq 'True' })
            if ($complete.Count -gt 0) {
                break
            }
            Start-Sleep -Seconds (Get-RemainingJobSeconds $jobTimer -MaximumSeconds 5)
        } while ($true)
    }
    finally {
        try {
            $output = @(kubectl @kube --request-timeout=30s --namespace wi-proxy logs "job/wi-proxy-$mode" --container app)
            $output | Set-Content (Join-Path $state "$mode.log") -Encoding utf8
            # NUnit repeats live console output in the detailed per-test result.
            $output | Where-Object { $_.TrimStart().StartsWith('{"scenario":') } |
                ForEach-Object { $_.Trim() } | Select-Object -Unique |
                Set-Content (Join-Path $state "$mode.jsonl") -Encoding utf8
        }
        catch {
            $logCollectionFailures += $mode
            Write-Warning "Could not collect logs for wi-proxy-${mode}: $($_.Exception.Message)"
        }
    }
}

if ($logCollectionFailures.Count -gt 0) {
    throw "Live job logs are unavailable for: $($logCollectionFailures -join ', '). See the collection warnings."
}

$nunitResults = @{}
foreach ($mode in @('enabled', 'disabled')) {
    $results = @(Get-Content (Join-Path $state "$mode.jsonl") | ForEach-Object { $_ | ConvertFrom-Json })
    $expectedScenarios = if ($mode -eq 'enabled') { @('candidate', 'configuration', 'async', 'cache', 'sync', 'concurrent', 'arm-authentication', 'nunit') } else { @('candidate', 'configuration', 'disabled', 'nunit') }
    if ($results.Count -ne $expectedScenarios.Count -or ($results | Where-Object { $_.passed -ne $true }) -or
        (Compare-Object $expectedScenarios @($results.scenario))) {
        throw "Unexpected or failing results in $mode.jsonl."
    }
    $candidate = $results | Where-Object { $_.scenario -eq 'candidate' }
    if ($candidate.details.coreSha256 -ne $expectedCoreHash -or $candidate.details.credentialAssembly -ne 'Azure.Core') {
        throw 'The pod did not run the Azure.Core candidate published from this worktree.'
    }
    $testMethod = if ($mode -eq 'enabled') { 'AuthenticateWithProxy' } else { 'AuthenticateWithoutProxy' }
    $nunit = $results | Where-Object { $_.scenario -eq 'nunit' }
    if ($nunit.details.assembly -ne 'Azure.Core.Tests' -or
        $nunit.details.test -ne "Azure.Core.Tests.IdentityBinding.WorkloadIdentityBindingLiveTests.$testMethod") {
        throw 'The pod did not execute the expected Azure.Core NUnit test.'
    }
    $counterLines = @(Get-Content (Join-Path $state "$mode.log") | Where-Object { $_.TrimStart().StartsWith('<Counters ') })
    if ($counterLines.Count -ne 1) {
        throw "Expected one genuine TRX result counter in $mode.log."
    }
    [xml] $counters = $counterLines[0].Trim()
    if ($counters.Counters.total -ne '1' -or $counters.Counters.executed -ne '1' -or
        $counters.Counters.passed -ne '1' -or $counters.Counters.failed -ne '0') {
        throw "The Azure.Core NUnit test must pass, not be skipped or undiscovered: $mode."
    }
    $nunitResults[$mode] = @{ test = $nunit.details.test; passed = 1; failed = 0 }
    Get-Content (Join-Path $state "$mode.jsonl")
}
$jobs = kubectl @kube --namespace wi-proxy get jobs --output json | ConvertFrom-Json
$pods = kubectl @kube --namespace wi-proxy get pods --output json | ConvertFrom-Json
@{
    testedAt = [DateTimeOffset]::UtcNow.ToString('O')
    resourceGroup = $group.id
    cluster = $cluster.name
    kubernetesVersion = $cluster.currentKubernetesVersion
    coreSha256 = $expectedCoreHash
    nunitResults = $nunitResults
    jobs = @($jobs.items | ForEach-Object { @{ name = $_.metadata.name; succeeded = $_.status.succeeded } })
    images = @($pods.items.status.containerStatuses.imageID)
} | ConvertTo-Json -Depth 5 | Set-Content (Join-Path $state 'summary.json') -Encoding utf8
Write-Host "Both Azure.Core NUnit live tests and Kubernetes jobs passed. Redacted evidence: $state"
