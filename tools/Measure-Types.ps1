#Requires -Version 5
#Requires -PSEdition Desktop

# Gets information about the number of public types, and public and protected mbmers.
[CmdletBinding(DefaultParameterSetName = 'Path')]
param (
    [Parameter(ParameterSetName = 'Path', Position = 0)]
    [string[]] $Path,

    [Parameter(ParameterSetName = 'LiteralPath', Mandatory = $true, ValueFromPipelineByPropertyName = $true)]
    [Alias('PSPath')]
    [string[]] $LiteralPath,

    [Parameter(ParameterSetName = 'Path')]
    [ValidateNotNullOrEmpty()]
    [string] $Configuration = 'Debug',

    [Parameter(ParameterSetName = 'Path')]
    [ValidateNotNullOrEmpty()]
    [string] $TargetVersion = 'netstandard2.0',

    [Parameter()]
    [switch] $PassThru
)

begin {
    $LiteralPaths = @()
}

process {
    if ($PSCmdlet.ParameterSetName -eq 'Path') {
        $LiteralPath = if ($Path) {
            $Path | Resolve-Path
        }
        else {
            Join-Path -Path "$PSScriptRoot\..\artifacts\bin\Azure.*" -ChildPath "$Configuration\$TargetVersion" `
                | Get-ChildItem -Include Azure.*.dll -Exclude *.Tests.dll, *.Samples.dll -Recurse `
                | ForEach-Object -Begin {
                    $unique = @{}
                } -Process {
                    if (!$unique.ContainsKey($_.Name)) {
                        $unique.Add($_.Name, $_)
                    }
                } -End {
                    $unique.Values
                }
        }
    }

    $script:LiteralPaths += $LiteralPath
}

end {
    $references = @(
        ([System.AppDomain].Assembly.Location)
        ([System.ResolveEventHandler].Assembly.Location)
        ([ScriptBlock].Assembly.Location)
    )

    Write-Verbose 'Compiling assembly to hook AppDomain.AssemblyResolve'
    Add-Type -ReferencedAssemblies $references -TypeDefinition @'
public static class Hook
{
    private static System.Management.Automation.ScriptBlock _action;

    public static void Register(System.Management.Automation.ScriptBlock action)
    {
        _action = action;
        System.AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
    }

    public static void Unregister()
    {
        System.AppDomain.CurrentDomain.AssemblyResolve -= ResolveAssembly;
    }

    private static System.Reflection.Assembly ResolveAssembly(object source, System.ResolveEventArgs args)
    {
        System.Collections.ObjectModel.Collection<System.Management.Automation.PSObject> output = _action.Invoke(args.Name);
        if (output != null && output.Count > 0 && output[0] != null)
        {
            return output[0].BaseObject as System.Reflection.Assembly;
        }

        return null;
    }
}
'@

    $resolvePaths = @(
        "$PSScriptRoot\..\artifacts\bin\{0}\$Configuration\$TargetVersion\{0}.dll"
        "${env:USERPROFILE}\.nuget\packages\{0}\{1}\lib\{2}\{0}.dll"
    )

    $resolveTargets = @(
        $TargetVersion
        'netcoreapp2.0'
        'net462'
        'net461'
        'netstandard1.6'
        'netstandard1.5'
        'netstandard1.4'
        'netstandard1.3'
        'net46'
        'netstandard1.2'
        'net451'
        'netstandrad1.1'
        'net45'
    )

    $resolve = {
        param([string] $assemblyName)

        $name, $ignore, $version, $ignore = ($assemblyName -split ',') -split '='
        $version = [Version]::Parse($version)

        Write-Verbose "Attempting to resolve $name, Version=$version"
        foreach ($resolvePath in $resolvePaths) {
            foreach ($versionPattern in @($version, "$($version.Major).*")) {
                foreach ($resolveTarget in $resolveTargets) {
                    $resolvedPath = $resolvePath -f $name, $versionPattern, $resolveTarget
                    if (Test-Path $resolvedPath) {
                        $resolvedPath = Resolve-Path $resolvedPath | Convert-Path | Sort-Object -Descending | Select-Object -First 1

                        Write-Verbose "Loading $resolvedPath"
                        try {
                            return [System.Reflection.Assembly]::LoadFile($resolvedPath)
                        }
                        catch {
                            Write-Verbose "Failed to load $($resolvedPath): $($_.Exception.Message)"
                        }
                    }
                }
            }
        }

        $null
    }

    Write-Verbose 'Hooking AppDomain.AssemblyResolve event'
    [Hook]::Register($resolve);
    trap {
        Write-Verbose 'Unhooking AppDomain.AssemblyResolve event'
        [Hook]::Unregister()
    }

    $asmMeasures = foreach ($localPath in (Convert-Path -LiteralPath $LiteralPaths)) {
        Write-Verbose "Loading $localPath"
        $asm = [System.Reflection.Assembly]::LoadFile($localPath)

        Write-Verbose "Getting exported types from $($asm.GetName())"
        $types = $asm.GetExportedTypes()
        $typeMeasures = foreach ($type in $types) {
            Write-Verbose "Getting public and protected members from $type"
            $members = $type.GetMembers('Static,Instance,Public,NonPublic,DeclaredOnly') | Where-Object { $_.IsPublic -or $_.IsFamily }
            $typeMeasure = [pscustomobject]@{
                PSTypeName = 'TypeMeasure'
                Assembly = $asm
                Type = $type
                TypeName = $type.Name
                Members = $members
                MemberCount = $members.Count
            }

            if ($PassThru) {
                $PSCmdlet.WriteObject($typeMeasure)
            }

            $typeMeasure
        }

        $asmMeasure = [pscustomobject]@{
            PSTypeName = 'AssemblyMeasure'
            Assembly = $asm
            AssemblyName = $asm.GetName().Name
            Types = $typeMeasures.Type
            TypeCount = $typeMeasures.Type | Measure-Object | Select-Object -ExpandProperty Count
            TypeNames = $typeMeasures.TypeName
            Members = $typeMeasures.Members
            MemberCount = $typeMeasures.MemberCount | Measure-Object -Sum | Select-Object -ExpandProperty Sum
        }

        if ($PassThru) {
            $PSCmdlet.WriteObject($asmMeasure)
        }

        $asmMeasure
    }

    [pscustomobject]@{
        PSTypeName = 'Measure'
        Assemblies = $asmMeasures.Assembly
        AssemblyCount = $asmMeasures.Assembly | Measure-Object | Select-Object -ExpandProperty Count
        Types = $asmMeasures.Types
        TypeCount = $asmMeasures.TypeCount | Measure-Object -Sum | Select-Object -ExpandProperty Sum
        TypeNames = $asmMeasures.TypeNames
        Members = $asmMeasures.Members
        MemberCount = $asmMeasures.MemberCount | Measure-Object -Sum | Select-Object -ExpandProperty Sum
    }
}

<#
.Synopsis
Gets assembly, public type, and total public and protected member counts for assemblies.

.Description
Given a list of files or the defaults on a full build, an object or objects is returned with measures
including how many assemblies, public export types, and public and protected members were declared.

.Parameter Path
Path to the assembly or assemblies to refelct. The default is ..\artifacts\Azure.*\bin\$Configuration\**\Azure.*.dll sans tests and samples.

.Parameter LiteralPath
Used for pipeline input using your own list of assembly file paths. Wildcards are not supported.

.Parameter Configuration
The build configuration to enumerate if no Path was specified. The default is Debug.

.Parameter TargetVersion
The target .NET version. The default is netstandard2.0.

.Parameter PassThru
Also output intermediate measures including TypeMeasure and AssemblyMeasure.

.Outputs
Measure Information including total assembly, type, and member counts.
AssemblyMeasure Information including total type and member counts.
TypeMeasure Information including member count.
#>
