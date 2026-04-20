#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Analyzes an Azure SDK management-plane library DLL and outputs the resource
    hierarchy as JSON (stdout) and a markdown summary (stderr).

.DESCRIPTION
    Reflects over an Azure.ResourceManager.<RP>.dll to discover ArmResource,
    ArmCollection and ResourceData subtypes, maps parent-child relationships by
    inspecting Get* methods, and identifies scopes (ResourceGroup, Subscription,
    Tenant, ManagementGroup) via Mockable extension types.

    The DLL's directory must contain its dependencies (notably
    Azure.ResourceManager.dll). Typically you produce that with:
        dotnet publish sdk/<rp>/Azure.ResourceManager.<RP>/src -f net10.0 -o <out>

.PARAMETER DllPath
    Path to the Azure.ResourceManager.<RP>.dll to analyze.

.EXAMPLE
    pwsh eng/scripts/Get-ResourceHierarchy.ps1 ./publish/Azure.ResourceManager.Compute.dll > hierarchy.json
#>
[CmdletBinding()]
param(
    [Parameter(Mandatory = $true, Position = 0)]
    [string] $DllPath
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path -LiteralPath $DllPath)) {
    [Console]::Error.WriteLine("Error: File not found: $DllPath")
    exit 1
}

$DllPath = (Resolve-Path -LiteralPath $DllPath).ProviderPath
$dllDir  = Split-Path -Parent $DllPath

$armDllPath = Join-Path $dllDir 'Azure.ResourceManager.dll'
if (-not (Test-Path -LiteralPath $armDllPath)) {
    [Console]::Error.WriteLine("Error: Azure.ResourceManager.dll not found in $dllDir")
    [Console]::Error.WriteLine("The target DLL directory must contain Azure.ResourceManager.dll (e.g., from a build output).")
    exit 1
}

# Resolve sibling dependencies from the DLL's directory.
$resolveHandler = [ResolveEventHandler] {
    param($sender, $eventArgs)
    $name = ([System.Reflection.AssemblyName]::new($eventArgs.Name)).Name
    $candidate = Join-Path $dllDir "$name.dll"
    if (Test-Path -LiteralPath $candidate) {
        return [System.Reflection.Assembly]::LoadFrom($candidate)
    }
    return $null
}
[System.AppDomain]::CurrentDomain.add_AssemblyResolve($resolveHandler)

try {
    $armAssembly    = [System.Reflection.Assembly]::LoadFrom($armDllPath)
    $targetAssembly = [System.Reflection.Assembly]::LoadFrom($DllPath)

    [Console]::Error.WriteLine("Loaded: $($targetAssembly.GetName().Name) v$($targetAssembly.GetName().Version)")
    [Console]::Error.WriteLine("Loaded: $($armAssembly.GetName().Name) v$($armAssembly.GetName().Version)")

    $armResourceType        = $armAssembly.GetType('Azure.ResourceManager.ArmResource', $true)
    $armCollectionType      = $armAssembly.GetType('Azure.ResourceManager.ArmCollection', $true)
    $resourceDataType       = $armAssembly.GetType('Azure.ResourceManager.Models.ResourceData', $true)
    $trackedResourceDataType= $armAssembly.GetType('Azure.ResourceManager.Models.TrackedResourceData', $true)

    $assemblyName = $targetAssembly.GetName().Name
    $rpPrefix     = $assemblyName -replace '^Azure\.ResourceManager\.', ''

    $allTypes = $targetAssembly.GetExportedTypes()

    function Test-AssignableTo {
        param([Type] $Type, [Type] $BaseType)
        $current = $Type
        while ($null -ne $current) {
            if ($current.FullName -eq $BaseType.FullName) { return $true }
            $current = $current.BaseType
        }
        return $false
    }

    $resourceTypes = @($allTypes |
        Where-Object { $_.IsClass -and -not $_.IsAbstract -and (Test-AssignableTo $_ $armResourceType) } |
        Sort-Object Name)

    $collectionTypes = @($allTypes |
        Where-Object { $_.IsClass -and -not $_.IsAbstract -and (Test-AssignableTo $_ $armCollectionType) } |
        Sort-Object Name)

    $dataTypes = @($allTypes |
        Where-Object {
            $_.IsClass -and -not $_.IsAbstract -and
            (Test-AssignableTo $_ $resourceDataType) -and
            $_.FullName -ne $resourceDataType.FullName -and
            $_.FullName -ne $trackedResourceDataType.FullName
        } |
        Sort-Object Name)

    [Console]::Error.WriteLine("Found $($resourceTypes.Count) resource types, $($collectionTypes.Count) collection types, $($dataTypes.Count) data types")

    $mockableTypes = @($allTypes | Where-Object { $_.Name.StartsWith('Mockable') })

    function Get-InnerReturnType {
        param([Type] $ReturnType)
        $rt = $ReturnType
        if ($rt.IsGenericType) { $rt = $rt.GetGenericArguments()[0] }
        if ($rt.IsGenericType) { $rt = $rt.GetGenericArguments()[0] }
        return $rt
    }

    $bindingFlags = [System.Reflection.BindingFlags] 'Public, Instance, DeclaredOnly'
    $staticFlags  = [System.Reflection.BindingFlags] 'Public, Static'

    $resources = New-Object System.Collections.Generic.List[object]

    foreach ($resType in $resourceTypes) {
        $info = [ordered]@{
            Name              = $resType.Name
            FullName          = $resType.FullName
            ResourceType      = $null
            ResourceId        = $null
            DataType          = $null
            IsTrackedResource = $false
            CollectionType    = $null
            ChildCollections  = New-Object System.Collections.Generic.List[object]
            ChildResources    = New-Object System.Collections.Generic.List[object]
            ParentResources   = New-Object System.Collections.Generic.List[string]
            Scopes            = New-Object System.Collections.Generic.List[string]
        }

        # Static ResourceType field
        $rtField = $resType.GetField('ResourceType', $staticFlags)
        if ($null -ne $rtField) {
            try { $info.ResourceType = [string]$rtField.GetValue($null) } catch { }
        }

        # CreateResourceIdentifier(...) with placeholder args
        $createIdMethod = $resType.GetMethod('CreateResourceIdentifier', $staticFlags)
        if ($null -ne $createIdMethod) {
            $placeholderArgs = @($createIdMethod.GetParameters() | ForEach-Object { "{$($_.Name)}" })
            try { $info.ResourceId = [string]$createIdMethod.Invoke($null, $placeholderArgs) } catch { }
        }

        # Data property type
        $dataProp = $resType.GetProperty('Data', [System.Reflection.BindingFlags] 'Public, Instance')
        if ($null -ne $dataProp) {
            $info.DataType = $dataProp.PropertyType.Name
            $info.IsTrackedResource = Test-AssignableTo $dataProp.PropertyType $trackedResourceDataType
        }

        # Matching collection type
        $expectedCollectionName = $resType.Name -replace 'Resource$', 'Collection'
        $collType = $collectionTypes | Where-Object { $_.Name -eq $expectedCollectionName } | Select-Object -First 1
        if ($null -ne $collType) {
            $info.CollectionType = $collType.Name
        }

        # Get* methods: child collections / child resources
        $getMethods = $resType.GetMethods($bindingFlags) | Where-Object {
            $_.Name.StartsWith('Get') -and -not $_.Name.StartsWith('GetAsync') -and $_.GetParameters().Length -le 1
        }
        foreach ($method in $getMethods) {
            $rt = Get-InnerReturnType $method.ReturnType
            if (Test-AssignableTo $rt $armCollectionType) {
                $info.ChildCollections.Add([ordered]@{
                    MethodName     = $method.Name
                    ReturnType     = $rt.Name
                    ParameterCount = $method.GetParameters().Length
                }) | Out-Null
            }
            elseif ((Test-AssignableTo $rt $armResourceType) -and $rt.FullName -ne $resType.FullName) {
                $info.ChildResources.Add([ordered]@{
                    MethodName     = $method.Name
                    ReturnType     = $rt.Name
                    ParameterCount = $method.GetParameters().Length
                }) | Out-Null
            }
        }

        # Parent resources: who returns this resource's collection?
        if ($null -ne $info.CollectionType) {
            foreach ($otherRes in $resourceTypes) {
                if ($otherRes -eq $resType) { continue }
                $parentMethods = $otherRes.GetMethods($bindingFlags) | Where-Object { $_.Name.StartsWith('Get') }
                foreach ($pm in $parentMethods) {
                    $rt = Get-InnerReturnType $pm.ReturnType
                    if ($rt.Name -eq $info.CollectionType -and -not $info.ParentResources.Contains($otherRes.Name)) {
                        $info.ParentResources.Add($otherRes.Name) | Out-Null
                    }
                }
            }
        }

        # Scopes via Mockable* extension types
        foreach ($mockType in $mockableTypes) {
            $mockMethods = $mockType.GetMethods($bindingFlags) | Where-Object { $_.Name.StartsWith('Get') }
            foreach ($mm in $mockMethods) {
                $rt = Get-InnerReturnType $mm.ReturnType
                if ($null -ne $info.CollectionType -and $rt.Name -eq $info.CollectionType) {
                    $scope = $mockType.Name -replace "^Mockable$rpPrefix", '' -replace 'Resource$', ''
                    if (-not $info.Scopes.Contains($scope)) {
                        $info.Scopes.Add($scope) | Out-Null
                    }
                }
            }
        }

        $resources.Add([pscustomobject]$info)
    }

    # JSON to stdout
    $resources | ConvertTo-Json -Depth 8

    # Markdown summary to stderr
    [Console]::Error.WriteLine("`n## $assemblyName Resource Hierarchy`n")
    foreach ($r in $resources) {
        if ($r.Name.StartsWith('Mockable')) { continue }
        $scopeStr  = if ($r.Scopes.Count -gt 0)          { " (scopes: $($r.Scopes -join ', '))" }          else { '' }
        $parentStr = if ($r.ParentResources.Count -gt 0) { " [parent: $($r.ParentResources -join ', ')]" } else { ' [top-level]' }
        [Console]::Error.WriteLine("- **$($r.Name)**$parentStr$scopeStr")
        if ($null -ne $r.DataType)     { [Console]::Error.WriteLine("  - Data: $($r.DataType) (tracked: $($r.IsTrackedResource))") }
        if ($null -ne $r.ResourceType) { [Console]::Error.WriteLine("  - ResourceType: $($r.ResourceType)") }
        if ($null -ne $r.ResourceId)   { [Console]::Error.WriteLine("  - ResourceId: $($r.ResourceId)") }
        if ($r.ChildCollections.Count -gt 0) {
            [Console]::Error.WriteLine("  - Children:")
            foreach ($c in $r.ChildCollections) {
                [Console]::Error.WriteLine("    - $($c.MethodName)() -> $($c.ReturnType)")
            }
        }
    }

    exit 0
}
finally {
    [System.AppDomain]::CurrentDomain.remove_AssemblyResolve($resolveHandler)
}
