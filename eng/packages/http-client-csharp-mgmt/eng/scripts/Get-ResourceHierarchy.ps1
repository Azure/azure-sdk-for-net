#!/usr/bin/env pwsh
<#
.SYNOPSIS
    Analyzes an Azure SDK management-plane library DLL and outputs the resource
    hierarchy as JSON.

.DESCRIPTION
    Reflects over an Azure.ResourceManager.<RP>.dll to discover ArmResource,
    ArmCollection and ResourceData subtypes, maps parent-child relationships by
    inspecting Get* methods, and identifies scopes (ResourceGroup, Subscription,
    Tenant, ManagementGroup) via Mockable extension types.

    Diagnostic messages are written to stderr; the JSON result is written to stdout.

    The DLL's directory must contain its dependencies (notably
    Azure.ResourceManager.dll). Typically you produce that with:
        dotnet publish sdk/<rp>/Azure.ResourceManager.<RP>/src -f net10.0 -o <out>

.PARAMETER DllPath
    Path to the Azure.ResourceManager.<RP>.dll to analyze.

.EXAMPLE
    pwsh eng/packages/http-client-csharp-mgmt/eng/scripts/Get-ResourceHierarchy.ps1 ./publish/Azure.ResourceManager.Compute.dll > hierarchy.json
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
        # Unwrap Task<T> or ValueTask<T> to get T
        if ($rt.IsGenericType -and ($rt.GetGenericTypeDefinition().FullName -eq 'System.Threading.Tasks.Task`1' -or
                                    $rt.GetGenericTypeDefinition().FullName -eq 'System.Threading.Tasks.ValueTask`1')) {
            $rt = $rt.GetGenericArguments()[0]
        }
        # Unwrap Response<T> or NullableResponse<T> to get T
        if ($rt.IsGenericType -and ($rt.GetGenericTypeDefinition().Name -eq 'Response`1' -or
                                    $rt.GetGenericTypeDefinition().Name -eq 'NullableResponse`1')) {
            $rt = $rt.GetGenericArguments()[0]
        }
        return $rt
    }

    # Reads [Obsolete] and [EditorBrowsable(EditorBrowsableState.Never)] without
    # instantiating attribute types (works regardless of how the assembly is loaded).
    function Get-DeprecationInfo {
        param([System.Reflection.MemberInfo] $Member)
        $isObsolete = $false
        $obsoleteMessage = $null
        $isEbn = $false
        foreach ($a in $Member.GetCustomAttributesData()) {
            $n = $a.AttributeType.FullName
            if ($n -eq 'System.ObsoleteAttribute') {
                $isObsolete = $true
                if ($a.ConstructorArguments.Count -ge 1) {
                    $obsoleteMessage = [string]$a.ConstructorArguments[0].Value
                }
            }
            elseif ($n -eq 'System.ComponentModel.EditorBrowsableAttribute' -and
                    $a.ConstructorArguments.Count -ge 1 -and
                    [int]$a.ConstructorArguments[0].Value -eq 1) {
                # EditorBrowsableState.Never == 1
                $isEbn = $true
            }
        }
        return @{ IsObsolete = $isObsolete; ObsoleteMessage = $obsoleteMessage; IsEditorBrowsableNever = $isEbn }
    }

    $bindingFlags = [System.Reflection.BindingFlags] 'Public, Instance, DeclaredOnly'
    $staticFlags  = [System.Reflection.BindingFlags] 'Public, Static'

    $resources = New-Object System.Collections.Generic.List[object]

    foreach ($resType in $resourceTypes) {
        $info = [ordered]@{
            Name                   = $resType.Name
            FullName               = $resType.FullName
            ResourceType           = $null
            ResourceId             = $null
            DataType               = $null
            IsTrackedResource      = $false
            IsSingleton            = $false
            IsObsolete             = $false
            ObsoleteMessage        = $null
            IsEditorBrowsableNever = $false
            CollectionType         = $null
            ChildCollections       = New-Object System.Collections.Generic.List[object]
            ChildResources         = New-Object System.Collections.Generic.List[object]
            ParentResources        = New-Object System.Collections.Generic.List[string]
            Scopes                 = New-Object System.Collections.Generic.List[string]
        }

        $deprecation = Get-DeprecationInfo $resType
        $info.IsObsolete             = $deprecation.IsObsolete
        $info.ObsoleteMessage        = $deprecation.ObsoleteMessage
        $info.IsEditorBrowsableNever = $deprecation.IsEditorBrowsableNever

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

        # Matching collection type. Resources without a Collection are singletons
        # (parent exposes a param-less Get<Name>() returning the resource directly).
        $expectedCollectionName = $resType.Name -replace 'Resource$', 'Collection'
        $collType = $collectionTypes | Where-Object { $_.Name -eq $expectedCollectionName } | Select-Object -First 1
        if ($null -ne $collType) {
            $info.CollectionType = $collType.Name
        }
        else {
            $info.IsSingleton = $true
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

        # Parent resources:
        #  - for non-singletons: any other resource with a Get*() returning this resource's collection
        #  - for singletons:     any other resource (or Mockable) with a param-less Get*() returning this resource type
        foreach ($otherRes in $resourceTypes) {
            if ($otherRes -eq $resType) { continue }
            $parentMethods = $otherRes.GetMethods($bindingFlags) | Where-Object { $_.Name.StartsWith('Get') }
            foreach ($pm in $parentMethods) {
                $rt = Get-InnerReturnType $pm.ReturnType
                $matchesCollection = $null -ne $info.CollectionType -and $rt.Name -eq $info.CollectionType
                $matchesSingleton  = $info.IsSingleton -and $rt.FullName -eq $resType.FullName -and $pm.GetParameters().Length -eq 0
                if (($matchesCollection -or $matchesSingleton) -and -not $info.ParentResources.Contains($otherRes.Name)) {
                    $info.ParentResources.Add($otherRes.Name) | Out-Null
                }
            }
        }

        # Scopes via Mockable* extension types
        foreach ($mockType in $mockableTypes) {
            $mockMethods = $mockType.GetMethods($bindingFlags) | Where-Object { $_.Name.StartsWith('Get') }
            foreach ($mm in $mockMethods) {
                $rt = Get-InnerReturnType $mm.ReturnType
                $matchesCollection = $null -ne $info.CollectionType -and $rt.Name -eq $info.CollectionType
                $matchesSingleton  = $info.IsSingleton -and $rt.FullName -eq $resType.FullName -and $mm.GetParameters().Length -eq 0
                if ($matchesCollection -or $matchesSingleton) {
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

    exit 0
}
finally {
    [System.AppDomain]::CurrentDomain.remove_AssemblyResolve($resolveHandler)
}
