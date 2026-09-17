#Requires -Version 7.0

function Invoke-SdkChangeProcess {
    param([string[]]$Arguments, [string]$WorkingDirectory)

    $startInfo = [System.Diagnostics.ProcessStartInfo]::new('dotnet')
    $startInfo.WorkingDirectory = $WorkingDirectory
    $startInfo.UseShellExecute = $false
    $startInfo.RedirectStandardOutput = $true
    $startInfo.RedirectStandardError = $true
    $startInfo.Environment['DOTNET_CLI_UI_LANGUAGE'] = 'en'
    $startInfo.Environment['VSLANG'] = '1033'
    foreach ($argument in $Arguments) {
        $startInfo.ArgumentList.Add($argument)
    }
    $process = [System.Diagnostics.Process]::new()
    $process.StartInfo = $startInfo
    try {
        if (!$process.Start()) {
            throw 'Could not start dotnet for SDK change extraction.'
        }
        $stdout = $process.StandardOutput.ReadToEndAsync()
        $stderr = $process.StandardError.ReadToEndAsync()
        if (!$process.WaitForExit(600000)) {
            $process.Kill($true)
            $process.WaitForExit()
            throw 'SDK change extraction timed out while running dotnet.'
        }
        return @{
            ExitCode = $process.ExitCode
            StdOut = $stdout.GetAwaiter().GetResult()
            StdErr = $stderr.GetAwaiter().GetResult()
        }
    }
    finally {
        $process.Dispose()
    }
}

function Initialize-SdkChangeNativeLibraries {
    param([string]$MSBuildToolsPath)

    $framework = [System.Runtime.Versioning.FrameworkName]::new(
        (Get-SdkChangeAssemblyInfo (Join-Path $MSBuildToolsPath 'Microsoft.Build.dll')).TargetFramework)
    if ($framework.Identifier -eq '.NETCoreApp' -and [System.Environment]::Version.Major -lt $framework.Version.Major) {
        throw "The selected SDK's diagnostic reader requires PowerShell running on .NET $($framework.Version.Major) or newer; this PowerShell host uses .NET $([System.Environment]::Version)."
    }
    foreach ($name in @('Microsoft.Build.Framework', 'Microsoft.Build', 'NuGet.Versioning', 'NuGet.Frameworks')) {
        $path = Join-Path $MSBuildToolsPath "$name.dll"
        if (!(Test-Path -LiteralPath $path -PathType Leaf)) {
            throw "The selected .NET SDK is missing $path."
        }
        [void][System.Reflection.Assembly]::LoadFrom($path)
    }
}

function Read-SdkChangeBuildLog {
    param([string]$Path)

    if (!(Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "MSBuild did not produce its diagnostic log: $Path"
    }
    $result = @{
        Diagnostics = [System.Collections.Generic.List[object]]::new()
        Imports = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
        Targets = [System.Collections.Generic.List[string]]::new()
        ReadErrors = [System.Collections.Generic.List[string]]::new()
        Completed = $false
        Finished = $false
        Succeeded = $false
    }
    $reader = [Microsoft.Build.Logging.BinaryLogReplayEventSource]::new()
    $reader.add_RecoverableReadError([System.Action[Microsoft.Build.Logging.BinaryLogReaderErrorEventArgs]]{
        param($eventArgs)
        $result.ReadErrors.Add($eventArgs.ToString())
    })
    $reader.add_AnyEventRaised([Microsoft.Build.Framework.AnyEventHandler]{
        param($sender, $eventArgs)
        if ($eventArgs -is [Microsoft.Build.Framework.BuildErrorEventArgs] -or
            $eventArgs -is [Microsoft.Build.Framework.BuildWarningEventArgs]) {
            $context = $eventArgs.BuildEventContext
            $eventKey = [string]$eventArgs.Timestamp.Ticks
            if ($null -ne $context) {
                $eventKey += ":$($context.NodeId):$($context.ProjectContextId):$($context.TargetId):$($context.TaskId)"
            }
            $result.Diagnostics.Add(@{
                Code = $eventArgs.Code
                Message = $eventArgs.Message
                IsError = $eventArgs -is [Microsoft.Build.Framework.BuildErrorEventArgs]
                EventKey = $eventKey
            })
        }
        elseif ($eventArgs -is [Microsoft.Build.Framework.ProjectImportedEventArgs] -and
            !$eventArgs.ImportIgnored -and $eventArgs.ImportedProjectFile) {
            [void]$result.Imports.Add($eventArgs.ImportedProjectFile)
        }
        elseif ($eventArgs -is [Microsoft.Build.Framework.TargetStartedEventArgs]) {
            $result.Targets.Add($eventArgs.TargetName)
        }
        elseif ($eventArgs -is [Microsoft.Build.Framework.BuildFinishedEventArgs]) {
            $result.Finished = $true
            $result.Succeeded = $eventArgs.Succeeded
        }
        elseif ($eventArgs -is [Microsoft.Build.Framework.BuildMessageEventArgs] -and
            $eventArgs.Message -eq 'SDK_CHANGES_API_COMPAT_COMPLETED') {
            $result.Completed = $true
        }
        elseif ($eventArgs -is [Microsoft.Build.Framework.BuildMessageEventArgs] -and
            $eventArgs.Message -cmatch "^Could not resolve reference '[^']+' directly or transitively referenced by .+ in any of the provided search directories\.$") {
            # The SDK temporarily emits CP1002 as a message (dotnet/sdk#46236). It still
            # means comparison inputs are incomplete, not that compatibility succeeded.
            $result.Diagnostics.Add(@{
                Code = 'CP1002'
                Message = $eventArgs.Message
                IsError = $true
                EventKey = [string]$eventArgs.Timestamp.Ticks
            })
        }
    })
    $reader.Replay($Path)
    if ($result.ReadErrors.Count -gt 0) {
        throw "MSBuild's diagnostic log contains unreadable event records: $Path"
    }
    return $result
}

function Read-SdkChangeJson {
    param([string]$Path)

    if (!(Test-Path -LiteralPath $Path -PathType Leaf)) {
        throw "The expected JSON file was not produced: $Path"
    }
    return (Get-Content -LiteralPath $Path -Raw | ConvertFrom-Json -AsHashtable -Depth 100 -ErrorAction Stop)
}

function Get-SdkChangeProject {
    param([string]$PackagePath, [string]$SdkRepoPath)

    foreach ($path in @($PackagePath, $SdkRepoPath)) {
        if (![System.IO.Path]::IsPathFullyQualified($path)) {
            throw "An absolute path is required: $path"
        }
    }
    $repo = (Resolve-Path -LiteralPath $SdkRepoPath -ErrorAction Stop).Path
    $package = Get-Item -LiteralPath $PackagePath -ErrorAction Stop
    $relative = [System.IO.Path]::GetRelativePath($repo, $package.FullName)
    if ($relative -eq '..' -or $relative.StartsWith("..$([System.IO.Path]::DirectorySeparatorChar)") -or
        [System.IO.Path]::IsPathFullyQualified($relative)) {
        throw "PackagePath must be inside SdkRepoPath: $PackagePath"
    }
    if (!$package.PSIsContainer) {
        if ($package.Extension -ne '.csproj') {
            throw "PackagePath must identify a C# SDK source project: $PackagePath"
        }
        return $package.FullName
    }
    $source = Join-Path $package.FullName 'src'
    if (!(Test-Path -LiteralPath $source -PathType Container)) {
        $source = $package.FullName
    }
    $projects = @(Get-ChildItem -LiteralPath $source -Filter '*.csproj' -File)
    if ($projects.Count -ne 1) {
        throw "Expected exactly one SDK source project in $source; found $($projects.Count)."
    }
    return $projects[0].FullName
}

function Get-SdkChangeEvaluation {
    param(
        [string]$Project,
        [string]$SdkRepoPath,
        [string]$WorkDirectory,
        [string]$TargetFramework,
        [string]$Configuration
    )

    $id = [guid]::NewGuid().ToString('N')
    $jsonPath = Join-Path $WorkDirectory "$id.json"
    $logPath = Join-Path $WorkDirectory "$id.binlog"
    $properties = @(
        'PackageId', 'MSBuildProjectName', 'MSBuildProjectFullPath', 'MSBuildToolsPath',
        'TargetFramework', 'TargetFrameworks', 'TargetFrameworkMoniker', 'RuntimeIdentifier',
        'Configuration', 'TargetFileName', 'TargetPath', 'TargetRefPath', 'ProjectAssetsFile',
        'IntermediateOutputPath', 'PdbFile', 'DebugType',
        'MSBuildAllProjects', 'AssemblyName', 'NuGetPackageRoot', 'RoslynAssembliesPath',
        'ApiCompatBaselineTargetFramework', 'ApiCompatVersion', 'ApiCompatRespectInternals',
        'ApiCompatStrictMode', 'ApiCompatEnableRuleAttributesMustMatch',
        'ApiCompatEnableRuleCannotChangeParameterName', 'ApiCompatPermitUnnecessarySuppressions',
        'NoWarn', 'CompileUsingReferenceAssemblies',
        'TargetFrameworkRootPath', 'TargetFrameworkFallbackSearchPaths',
        'FrameworkPathOverride', 'BypassFrameworkInstallChecks'
    )
    $items = @(
        'Compile', 'AdditionalFiles', 'EmbeddedResource', 'Reference', 'FrameworkReference',
        'IntermediateAssembly', 'ApiCompatSuppressionFile', 'ApiCompatExcludeAttributesFile'
    )
    $arguments = @(
        'msbuild', $Project, '-nologo', '-tl:off', '-nodeReuse:false',
        "-getProperty:$($properties -join ',')", "-getItem:$($items -join ',')",
        "-getResultOutputFile:$jsonPath", "-binaryLogger:$logPath;ProjectImports=None"
    )
    if ($TargetFramework) { $arguments += "-property:TargetFramework=$TargetFramework" }
    if ($Configuration) { $arguments += "-property:Configuration=$Configuration" }
    $process = Invoke-SdkChangeProcess -Arguments $arguments -WorkingDirectory $SdkRepoPath
    if ($process.ExitCode -ne 0) {
        throw "SDK project evaluation failed (exit $($process.ExitCode)).`n$($process.StdOut)`n$($process.StdErr)"
    }
    $evaluation = Read-SdkChangeJson $jsonPath
    if (!$evaluation.Contains('Properties') -or !$evaluation.Contains('Items')) {
        throw "MSBuild returned malformed project metadata for $Project."
    }
    Initialize-SdkChangeNativeLibraries $evaluation.Properties.MSBuildToolsPath
    $log = Read-SdkChangeBuildLog $logPath
    $evaluation.ImportedProjects = @($log.Imports)
    $evaluation.RepositoryPath = $SdkRepoPath
    return $evaluation
}

function Get-SdkChangeAssemblyInfo {
    param([string]$Path, [switch]$IgnoreNonAssembly)

    $stream = [System.IO.File]::OpenRead($Path)
    $pe = [System.Reflection.PortableExecutable.PEReader]::new($stream)
    try {
        if (!$pe.HasMetadata) {
            if ($IgnoreNonAssembly) { return $null }
            throw "Not a managed assembly: $Path"
        }
        $metadata = [System.Reflection.Metadata.PEReaderExtensions]::GetMetadataReader($pe)
        if (!$metadata.IsAssembly) {
            if ($IgnoreNonAssembly) { return $null }
            throw "Not a managed assembly: $Path"
        }
        $definition = $metadata.GetAssemblyDefinition()
        $targetFramework = $null
        foreach ($handle in $definition.GetCustomAttributes()) {
            $attribute = $metadata.GetCustomAttribute($handle)
            if ($attribute.Constructor.Kind -ne [System.Reflection.Metadata.HandleKind]::MemberReference) { continue }
            $constructor = $metadata.GetMemberReference($attribute.Constructor)
            if ($constructor.Parent.Kind -ne [System.Reflection.Metadata.HandleKind]::TypeReference) { continue }
            $type = $metadata.GetTypeReference($constructor.Parent)
            if ($metadata.GetString($type.Namespace) -eq 'System.Runtime.Versioning' -and
                $metadata.GetString($type.Name) -eq 'TargetFrameworkAttribute') {
                $blob = $metadata.GetBlobReader($attribute.Value)
                if ($blob.ReadUInt16() -ne 1) { throw "Invalid TargetFrameworkAttribute in $Path." }
                $targetFramework = $blob.ReadSerializedString()
            }
        }
        return @{
            Name = $metadata.GetString($definition.Name)
            TargetFramework = $targetFramework
            References = @($metadata.AssemblyReferences | ForEach-Object {
                $metadata.GetString($metadata.GetAssemblyReference($_).Name)
            })
        }
    }
    finally {
        $pe.Dispose()
        $stream.Dispose()
    }
}

function Get-SdkChangeCompilationDocuments {
    param([string]$Assembly, [hashtable]$Evaluation)

    $stream = [System.IO.File]::OpenRead($Assembly)
    $pe = [System.Reflection.PortableExecutable.PEReader]::new($stream)
    $provider = $null
    $pdbStream = $null
    try {
        $entries = @($pe.ReadDebugDirectory())
        $embedded = @($entries | Where-Object { $_.Type -eq 'EmbeddedPortablePdb' })
        if ($embedded.Count -eq 1) {
            $provider = $pe.ReadEmbeddedPortablePdbDebugDirectoryData($embedded[0])
        }
        else {
            $pdb = if ($Evaluation.Properties.PdbFile) {
                [System.IO.Path]::GetFullPath($Evaluation.Properties.PdbFile, (Split-Path $Evaluation.Properties.MSBuildProjectFullPath -Parent))
            }
            else { [System.IO.Path]::ChangeExtension($Assembly, '.pdb') }
            if (!(Test-Path -LiteralPath $pdb -PathType Leaf)) {
                throw "Current portable PDB is missing: $pdb. Build the current package with portable or embedded debug information to verify artifact freshness."
            }
            $pdbStream = [System.IO.File]::OpenRead($pdb)
            $provider = [System.Reflection.Metadata.MetadataReaderProvider]::FromPortablePdbStream($pdbStream)
        }
        $metadata = $provider.GetMetadataReader()
        $codeView = @($entries | Where-Object { $_.Type -eq 'CodeView' })
        $id = [byte[]]$metadata.DebugMetadataHeader.Id
        if ($codeView.Count -ne 1 -or $id.Length -ne 20 -or
            $pe.ReadCodeViewDebugDirectoryData($codeView[0]).Guid -ne [guid]::new([byte[]]$id[0..15])) {
            throw "Current PDB does not match the current assembly: $Assembly."
        }
        $sourceCount = $metadata.Documents.Count
        foreach ($handle in $metadata.CustomDebugInformation) {
            $info = $metadata.GetCustomDebugInformation($handle)
            if ($info.Parent.Kind -eq 'ModuleDefinition' -and
                $metadata.GetGuid($info.Kind) -eq [guid]'b5feec05-8cd0-4a83-96da-466284bb4bd8') {
                $options = [System.Text.Encoding]::UTF8.GetString($metadata.GetBlobBytes($info.Value)).Split([char]0)
                for ($i = 0; $i + 1 -lt $options.Length; $i += 2) {
                    if ($options[$i] -eq 'source-file-count') { $sourceCount = [int]$options[$i + 1] }
                }
            }
        }
        if ($sourceCount -lt 0 -or $sourceCount -gt $metadata.Documents.Count) {
            throw "The current PDB contains an invalid compilation source count: $Assembly."
        }
        $documents = [System.Collections.Generic.List[object]]::new()
        $algorithms = @{
            '8829d00f-11b8-4213-878b-770e8597ac16' = 'SHA256'
            'ff1816ec-aa5e-4d10-87f7-6f4963833460' = 'SHA1'
        }
        foreach ($handle in $metadata.Documents) {
            # Roslyn appends #line documents after its compilation source documents.
            if ($documents.Count -eq $sourceCount) { break }
            $document = $metadata.GetDocument($handle)
            $documents.Add(@{
                Name = $metadata.GetString($document.Name)
                Algorithm = $algorithms[$metadata.GetGuid($document.HashAlgorithm).ToString()]
                Hash = [System.Convert]::ToHexString($metadata.GetBlobBytes($document.Hash))
            })
        }
        return @($documents)
    }
    finally {
        if ($null -ne $provider) { $provider.Dispose() }
        if ($null -ne $pdbStream) { $pdbStream.Dispose() }
        $pe.Dispose()
        $stream.Dispose()
    }
}

function Assert-SdkChangeCompilationSources {
    param([string]$Assembly, [hashtable]$Evaluation)

    $documents = @(Get-SdkChangeCompilationDocuments -Assembly $Assembly -Evaluation $Evaluation)
    $projectDirectory = Split-Path $Evaluation.Properties.MSBuildProjectFullPath -Parent
    $intermediateDirectory = [System.IO.Path]::GetFullPath($Evaluation.Properties.IntermediateOutputPath, $projectDirectory).Replace('\', '/').TrimEnd('/') + '/'
    $repoDirectory = $Evaluation.RepositoryPath.Replace('\', '/').TrimEnd('/') + '/'
    $sources = @{}
    $mappings = @{ $repoDirectory = $repoDirectory }
    $projectPrefix = $projectDirectory.Replace('\', '/').TrimEnd('/') + '/'
    $mappings[$projectPrefix] = $projectPrefix
    foreach ($source in $Evaluation.Items.Compile) {
        $path = $source.FullPath.Replace('\', '/')
        $sources[$path] = $false
        $relative = [System.IO.Path]::GetRelativePath($Evaluation.RepositoryPath, $source.FullPath).Replace('\', '/')
        if ($relative.StartsWith('../')) { continue }
        foreach ($document in $documents) {
            $name = $document.Name.Replace('\', '/')
            if ($name.EndsWith("/$relative", [System.StringComparison]::OrdinalIgnoreCase)) {
                $prefix = $name.Substring(0, $name.Length - $relative.Length)
                if ($mappings.Contains($prefix) -and $mappings[$prefix] -ne $repoDirectory) {
                    throw "Ambiguous source path mapping in the current PDB: $($document.Name)"
                }
                $mappings[$prefix] = $repoDirectory
            }
        }
    }
    foreach ($document in $documents) {
        $path = $document.Name.Replace('\', '/')
        if (!$sources.Contains($path)) {
            foreach ($prefix in ($mappings.Keys | Sort-Object Length -Descending)) {
                if ($path.StartsWith($prefix, [System.StringComparison]::OrdinalIgnoreCase)) {
                    $path = $mappings[$prefix] + $path.Substring($prefix.Length)
                    break
                }
            }
        }
        if ($path.StartsWith($intermediateDirectory, [System.StringComparison]::OrdinalIgnoreCase)) { continue }
        if (!$sources.Contains($path)) {
            throw "Current assembly is stale or its PDB source mapping cannot be verified: '$($document.Name)' is not an evaluated Compile input. Build the current package first."
        }
        if (!$document.Algorithm -or !$document.Hash) {
            throw "The current PDB has no supported source checksum for $path."
        }
        $actual = (Get-FileHash -LiteralPath $path -Algorithm $document.Algorithm).Hash
        if ($actual -ne $document.Hash) {
            throw "Current assembly is stale: the compiled checksum for $path differs from the current source. Build the current package first."
        }
        $sources[$path] = $true
    }
    foreach ($path in $sources.Keys) {
        if (!$sources[$path]) {
            throw "Current assembly is stale: the PDB does not contain the evaluated Compile input $path. Build the current package first."
        }
    }
}

function Assert-SdkChangeCurrentAssembly {
    param([hashtable]$Evaluation)

    $properties = $Evaluation.Properties
    $assemblies = @($Evaluation.Items.IntermediateAssembly)
    if ($assemblies.Count -ne 1 -or !$properties.TargetPath -or !$properties.TargetFramework) {
        throw "Could not determine the current assembly/target framework for $($properties.MSBuildProjectFullPath)."
    }
    $assembly = $assemblies[0].FullPath
    if (!(Test-Path -LiteralPath $assembly -PathType Leaf)) {
        throw "Current assembly is missing for $($properties.TargetFramework): $assembly. Build the current package first."
    }
    $info = Get-SdkChangeAssemblyInfo $assembly
    if ($info.Name -ne $properties.AssemblyName -or $info.TargetFramework -ne $properties.TargetFrameworkMoniker) {
        throw "Current assembly identity/target framework does not match the evaluated project: $assembly."
    }
    $inputs = @($properties.MSBuildProjectFullPath, $properties.ProjectAssetsFile) +
        @($properties.MSBuildAllProjects -split ';' | Where-Object { $_ }) + @($Evaluation.ImportedProjects)
    $globalJson = Join-Path $Evaluation.RepositoryPath 'global.json'
    if (Test-Path -LiteralPath $globalJson -PathType Leaf) { $inputs += $globalJson }
    foreach ($itemType in @('Compile', 'AdditionalFiles', 'EmbeddedResource')) {
        $inputs += @($Evaluation.Items[$itemType] | ForEach-Object { $_.FullPath })
    }
    $builtAt = (Get-Item -LiteralPath $assembly).LastWriteTimeUtc
    foreach ($inputPath in ($inputs | Sort-Object -Unique)) {
        if (!$inputPath -or !(Test-Path -LiteralPath $inputPath -PathType Leaf)) {
            throw "A current build input is missing: $inputPath. Build the current package first."
        }
        if ((Get-Item -LiteralPath $inputPath).LastWriteTimeUtc -gt $builtAt) {
            throw "Current assembly is stale for $($properties.TargetFramework): $inputPath is newer than $assembly. Build the current package first."
        }
    }
    Assert-SdkChangeCompilationSources -Assembly $assembly -Evaluation $Evaluation
    return $assembly
}

function Get-SdkChangeLatestGaVersion {
    param([string]$PackageId)

    if ($PackageId -notmatch '^[A-Za-z0-9_.-]+$') { throw "Invalid NuGet package ID: $PackageId" }
    $uri = "https://api.nuget.org/v3-flatcontainer/$($PackageId.ToLowerInvariant())/index.json"
    try {
        $response = Invoke-RestMethod -Uri $uri -Method Get -TimeoutSec 60 -MaximumRetryCount 3 -RetryIntervalSec 2 -ErrorAction Stop
    }
    catch [Microsoft.PowerShell.Commands.HttpResponseException] {
        if ($null -ne $_.Exception.Response -and [int]$_.Exception.Response.StatusCode -eq 404) { return $null }
        throw
    }
    if ($null -eq $response -or $null -eq $response.PSObject.Properties['versions'] -or
        $response.versions -isnot [System.Collections.IList]) {
        throw "NuGet returned a malformed version index for $PackageId."
    }
    $latest = $null
    foreach ($text in $response.versions) {
        if ($text -isnot [string]) {
            throw "NuGet returned an invalid version for ${PackageId}: $text"
        }
        $version = [NuGet.Versioning.NuGetVersion]::new($text)
        if (!$version.IsPrerelease -and
            ($null -eq $latest -or [NuGet.Versioning.VersionComparer]::VersionRelease.Compare($version, $latest) -gt 0)) {
            $latest = $version
        }
    }
    if ($null -ne $latest) { return $latest.ToNormalizedString() }
    return $null
}

function Write-SdkChangeInputs {
    param(
        [string]$Path,
        [hashtable]$Properties,
        [hashtable]$Items = @{},
        [string[]]$RemoveItems = @()
    )

    $document = [System.Xml.XmlDocument]::new()
    $root = $document.CreateElement('Project')
    [void]$document.AppendChild($root)
    $group = $document.CreateElement('PropertyGroup')
    [void]$root.AppendChild($group)
    foreach ($name in $Properties.Keys) {
        $element = $document.CreateElement($name)
        $element.InnerText = if ($name -eq 'NoWarn') {
            ($Properties[$name] -split ';' | ForEach-Object { [Microsoft.Build.Evaluation.ProjectCollection]::Escape($_.Trim()) }) -join ';'
        }
        else {
            [Microsoft.Build.Evaluation.ProjectCollection]::Escape([string]$Properties[$name])
        }
        [void]$group.AppendChild($element)
    }
    $group = $document.CreateElement('ItemGroup')
    [void]$root.AppendChild($group)
    foreach ($name in $RemoveItems) {
        $element = $document.CreateElement($name)
        $element.SetAttribute('Remove', "@($name)")
        [void]$group.AppendChild($element)
    }
    foreach ($name in $Items.Keys) {
        foreach ($item in $Items[$name]) {
            $element = $document.CreateElement($name)
            $identity = if ($item -is [string]) { $item } else { $item.Identity }
            $element.SetAttribute('Include', [Microsoft.Build.Evaluation.ProjectCollection]::Escape($identity))
            if ($item -isnot [string]) {
                foreach ($key in $item.Keys | Where-Object { $_ -ne 'Identity' }) {
                    $metadata = $document.CreateElement($key)
                    $metadata.InnerText = [Microsoft.Build.Evaluation.ProjectCollection]::Escape([string]$item[$key])
                    [void]$element.AppendChild($metadata)
                }
            }
            [void]$group.AppendChild($element)
        }
    }
    $document.Save($Path)
}

function Invoke-SdkChangeReferenceResolution {
    param(
        [string]$SdkRepoPath,
        [string]$WorkDirectory,
        [string]$TargetFramework,
        [hashtable]$Properties,
        [hashtable]$Items,
        [switch]$Restore
    )

    [void][System.IO.Directory]::CreateDirectory($WorkDirectory)
    $inputPath = Join-Path $WorkDirectory 'inputs.xml'
    $jsonPath = Join-Path $WorkDirectory 'references.json'
    $logPath = Join-Path $WorkDirectory 'references.binlog'
    $removeItems = if ($Restore) { @() } else { @('Reference', 'FrameworkReference') }
    Write-SdkChangeInputs -Path $inputPath -Properties $Properties -Items $Items -RemoveItems $removeItems
    $arguments = @(
        (Join-Path $PSScriptRoot 'SdkChangeReferences.proj'), '-nologo', '-tl:off', '-nodeReuse:false',
        "-property:SdkChangesWorkDirectory=$WorkDirectory", "-property:SdkChangesInputFile=$inputPath",
        "-property:TargetFramework=$TargetFramework"
    )
    if ($Restore) {
        $nugetConfig = Join-Path $SdkRepoPath 'NuGet.Config'
        if (!(Test-Path -LiteralPath $nugetConfig -PathType Leaf)) {
            throw "The SDK repository NuGet configuration is missing: $nugetConfig"
        }
        $restoreResult = Invoke-SdkChangeProcess -WorkingDirectory $SdkRepoPath -Arguments (@('msbuild') + $arguments + @(
            '-target:Restore', '-verbosity:minimal', "-property:RestoreConfigFile=$nugetConfig"
        ))
        if ($restoreResult.ExitCode -ne 0) {
            throw "Could not restore the exact NuGet GA baseline (exit $($restoreResult.ExitCode)).`n$($restoreResult.StdOut)`n$($restoreResult.StdErr)"
        }
    }
    $process = Invoke-SdkChangeProcess -WorkingDirectory $SdkRepoPath -Arguments (@('msbuild') + $arguments + @(
        '-target:ResolveSdkChangeReferences', '-verbosity:minimal',
        '-getProperty:ProjectAssetsFile,NuGetPackageRoot,TargetFrameworkDirectory', '-getItem:ReferencePathWithRefAssemblies',
        "-getResultOutputFile:$jsonPath", "-binaryLogger:$logPath;ProjectImports=None"
    ))
    if ($process.ExitCode -ne 0) {
        throw "Reference resolution failed (exit $($process.ExitCode)).`n$($process.StdOut)`n$($process.StdErr)"
    }
    $log = Read-SdkChangeBuildLog $logPath
    if (!$log.Finished -or !$log.Succeeded -or $log.Diagnostics.Count -ne 0) {
        throw "Reference resolution was incomplete or produced diagnostics: $($log.Diagnostics | ConvertTo-Json -Compress)"
    }
    $result = Read-SdkChangeJson $jsonPath
    $references = @($result.Items.ReferencePathWithRefAssemblies | ForEach-Object { $_.FullPath } | Sort-Object -Unique)
    if ($references.Count -eq 0) { throw 'No reference assemblies were resolved.' }
    # Classic framework references can depend on framework assemblies not directly used by the SDK.
    $referenceNames = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::OrdinalIgnoreCase)
    foreach ($reference in $references) { [void]$referenceNames.Add([System.IO.Path]::GetFileName($reference)) }
    foreach ($directory in @($result.Properties.TargetFrameworkDirectory -split ';' | Where-Object { $_ } | Sort-Object -Unique)) {
        if (!(Test-Path -LiteralPath $directory -PathType Container)) {
            throw "A resolved framework reference directory is missing: $directory"
        }
        foreach ($file in Get-ChildItem -LiteralPath $directory -Filter '*.dll' -File) {
            if (!$referenceNames.Contains($file.Name) -and
                $null -ne (Get-SdkChangeAssemblyInfo -Path $file.FullName -IgnoreNonAssembly)) {
                [void]$referenceNames.Add($file.Name)
                $references += $file.FullName
            }
        }
    }
    return @{ References = $references; AssetsFile = $result.Properties.ProjectAssetsFile }
}

function Get-SdkChangeCurrentReferences {
    param([hashtable]$Evaluation, [string]$SdkRepoPath, [string]$WorkDirectory)

    [void][System.IO.Directory]::CreateDirectory($WorkDirectory)
    $properties = $Evaluation.Properties
    $assets = Read-SdkChangeJson $properties.ProjectAssetsFile
    if (!$assets.Contains('targets') -or !$assets.Contains('libraries') -or !$assets.Contains('project') -or
        [System.IO.Path]::GetFullPath($assets.project.restore.projectPath) -ne $properties.MSBuildProjectFullPath) {
        throw "The existing NuGet assets do not belong to the evaluated project: $($properties.ProjectAssetsFile)"
    }
    $framework = [NuGet.Frameworks.NuGetFramework]::Parse($properties.TargetFramework)
    $targetKeys = @($assets.targets.Keys | Where-Object {
        !($_.Contains('/')) -and [NuGet.Frameworks.NuGetFramework]::Parse($_).Equals($framework)
    })
    if ($targetKeys.Count -ne 1) { throw "Existing NuGet assets do not contain $($properties.TargetFramework)." }
    $references = [System.Collections.Generic.List[object]]::new()
    foreach ($reference in $Evaluation.Items.Reference) {
        $item = @{ Identity = $reference.Identity }
        foreach ($name in @('HintPath', 'Aliases', 'EmbedInteropTypes', 'SpecificVersion', 'Private', 'ReferenceAssembly')) {
            if ($reference.Contains($name) -and $reference[$name]) {
                $value = $reference[$name]
                if ($name -in @('HintPath', 'ReferenceAssembly')) {
                    $value = [System.IO.Path]::GetFullPath($value, (Split-Path $properties.MSBuildProjectFullPath -Parent))
                }
                $item[$name] = $value
            }
        }
        if ([System.IO.Path]::GetExtension($item.Identity) -eq '.dll') {
            $item.Identity = [System.IO.Path]::GetFullPath($item.Identity, (Split-Path $properties.MSBuildProjectFullPath -Parent))
        }
        $references.Add($item)
    }
    $target = $assets.targets[$targetKeys[0]]
    foreach ($key in $target.Keys) {
        $library = $target[$key]
        if ($library.type -ne 'project' -or !$library.Contains('compile')) { continue }
        $project = [System.IO.Path]::GetFullPath($assets.libraries[$key].msbuildProject, (Split-Path $properties.MSBuildProjectFullPath -Parent))
        $dependencyFramework = [NuGet.Frameworks.NuGetFramework]::Parse($library.framework).GetShortFolderName()
        $dependency = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $SdkRepoPath -WorkDirectory $WorkDirectory `
            -TargetFramework $dependencyFramework -Configuration $properties.Configuration
        $assembly = Assert-SdkChangeCurrentAssembly $dependency
        # Use the existing compiler output, not a possibly stale copied project-reference assembly.
        $references.Add(@{ Identity = $assembly; ReferenceAssembly = $assembly })
    }
    $frameworkReferences = @($Evaluation.Items.FrameworkReference | ForEach-Object {
        $item = @{ Identity = $_.Identity }
        foreach ($name in @('TargetingPackVersion', 'RuntimeFrameworkVersion', 'IsImplicitlyDefined', 'PrivateAssets')) {
            if ($_.Contains($name) -and $_[$name]) { $item[$name] = $_[$name] }
        }
        $item
    })
    return (Invoke-SdkChangeReferenceResolution -SdkRepoPath $SdkRepoPath -WorkDirectory $WorkDirectory `
        -TargetFramework $properties.TargetFramework -Properties @{
            ProjectAssetsFile = $properties.ProjectAssetsFile
            NuGetPackageRoot = $properties.NuGetPackageRoot
            RuntimeIdentifier = $properties.RuntimeIdentifier
            CompileUsingReferenceAssemblies = $properties.CompileUsingReferenceAssemblies
            TargetFrameworkRootPath = $properties.TargetFrameworkRootPath
            TargetFrameworkFallbackSearchPaths = $properties.TargetFrameworkFallbackSearchPaths
            FrameworkPathOverride = $properties.FrameworkPathOverride
            BypassFrameworkInstallChecks = $properties.BypassFrameworkInstallChecks
        } -Items @{ Reference = @($references); FrameworkReference = $frameworkReferences }).References
}

function Get-SdkChangeBaseline {
    param(
        [string]$PackageId, [string]$Version, [string]$TargetFramework, [string]$TargetFileName,
        [string]$SdkRepoPath, [string]$WorkDirectory
    )

    $resolved = Invoke-SdkChangeReferenceResolution -SdkRepoPath $SdkRepoPath -WorkDirectory $WorkDirectory `
        -TargetFramework $TargetFramework -Properties @{ RestorePackagesPath = Join-Path $WorkDirectory 'packages' } -Items @{
            PackageReference = @(@{ Identity = $PackageId; Version = "[$Version]" })
        } -Restore
    $assets = Read-SdkChangeJson $resolved.AssetsFile
    $key = "$PackageId/$Version"
    if (!$assets.libraries.Contains($key)) { throw "NuGet did not resolve the requested GA package $key." }
    $packageDirectory = $null
    foreach ($folder in $assets.packageFolders.Keys) {
        $candidate = Join-Path $folder $assets.libraries[$key].path
        if (Test-Path -LiteralPath $candidate -PathType Container) { $packageDirectory = $candidate; break }
    }
    if (!$packageDirectory) { throw "The restored GA package directory is missing: $key." }
    $assembly = Join-Path $packageDirectory 'lib' $TargetFramework $TargetFileName
    if (!(Test-Path -LiteralPath $assembly -PathType Leaf)) {
        throw "The latest GA $key does not contain the evaluated baseline assembly lib/$TargetFramework/$TargetFileName. No older version or different framework was substituted."
    }
    return @{
        Assembly = $assembly
        References = @($resolved.References | Where-Object { [System.IO.Path]::GetFileName($_) -ne $TargetFileName })
    }
}

function Assert-SdkChangeReferences {
    param([string]$Assembly, [string[]]$References)

    $paths = @($Assembly) + $References
    $assemblies = @{}
    foreach ($path in $paths | Sort-Object -Unique) {
        if ($path.Contains(',') -or !(Test-Path -LiteralPath $path -PathType Leaf)) {
            throw "A required assembly reference is missing or cannot be represented by ApiCompat: $path"
        }
        $info = Get-SdkChangeAssemblyInfo $path
        $assemblies[$info.Name] = $info
    }
    # ApiCompat resolves API-reachable transitive references. A recursive PE closure would also
    # require private framework implementation dependencies absent from reference-assembly packs.
    $info = Get-SdkChangeAssemblyInfo $Assembly
    foreach ($reference in $info.References) {
        if (!$assemblies.Contains($reference)) {
            throw "Missing assembly reference '$reference', required by '$($info.Name)'. API compatibility cannot be determined."
        }
    }
}

function Get-SdkChangeRules {
    param([hashtable]$Evaluation, [string]$SdkRepoPath)

    $properties = $Evaluation.Properties
    $rules = @{}
    $defaults = @{
        ApiCompatRespectInternals = $false
        ApiCompatStrictMode = $false
        ApiCompatEnableRuleAttributesMustMatch = $true
        ApiCompatEnableRuleCannotChangeParameterName = $true
        ApiCompatPermitUnnecessarySuppressions = $true
    }
    foreach ($name in $defaults.Keys) {
        $rules[$name] = if ($properties[$name]) { [bool]::Parse($properties[$name]) } else { $defaults[$name] }
    }
    $rules.NoWarn = $properties.NoWarn
    $rules.RoslynAssembliesPath = $properties.RoslynAssembliesPath
    $excludes = @($Evaluation.Items.ApiCompatExcludeAttributesFile | ForEach-Object { $_.FullPath })
    if ($excludes.Count -eq 0) { $excludes = @(Join-Path $SdkRepoPath 'eng' 'ApiListing.exclude-attributes.txt') }
    $suppressions = @($Evaluation.Items.ApiCompatSuppressionFile | ForEach-Object { $_.FullPath })
    $central = Join-Path $SdkRepoPath 'eng' 'apicompatbaselines' "$($properties.MSBuildProjectName).xml"
    if ((Test-Path -LiteralPath $central -PathType Leaf) -and $central -notin $suppressions) { $suppressions += $central }
    foreach ($path in $excludes + $suppressions) {
        if (!(Test-Path -LiteralPath $path -PathType Leaf)) { throw "ApiCompat configuration file is missing: $path" }
    }
    foreach ($name in @('ApiCompatBaseline.txt', "ApiCompatBaseline.$($properties.TargetFramework).txt", 'CompatibilitySuppressions.xml')) {
        $path = Join-Path (Split-Path $properties.MSBuildProjectFullPath -Parent) $name
        if (Test-Path -LiteralPath $path -PathType Leaf) { throw "Local ApiCompat suppressions are not supported; use $central instead of $path." }
    }
    return @{ Properties = $rules; Excludes = $excludes; Suppressions = $suppressions }
}

function Invoke-SdkChangeApiCompat {
    param(
        [string]$LeftAssembly, [string]$RightAssembly,
        [string[]]$LeftReferences, [string[]]$RightReferences,
        [hashtable]$Evaluation, [hashtable]$Rules,
        [string]$SdkRepoPath, [string]$WorkDirectory
    )

    [void][System.IO.Directory]::CreateDirectory($WorkDirectory)
    $inputPath = Join-Path $WorkDirectory 'inputs.xml'
    $logPath = Join-Path $WorkDirectory 'apicompat.binlog'
    $properties = @{} + $Rules.Properties
    $properties.SdkChangesLeftAssembly = $LeftAssembly
    $properties.SdkChangesRightAssembly = $RightAssembly
    $properties.SdkChangesAssemblyIdentity = "lib/$($Evaluation.Properties.ApiCompatBaselineTargetFramework)/$($Evaluation.Properties.TargetFileName)"
    Write-SdkChangeInputs -Path $inputPath -Properties $properties -Items @{
        SdkChangesLeftReference = $LeftReferences
        SdkChangesRightReference = $RightReferences
        SdkChangesSuppressionFile = $Rules.Suppressions
        SdkChangesExcludeAttributesFile = $Rules.Excludes
    }
    $process = Invoke-SdkChangeProcess -WorkingDirectory $SdkRepoPath -Arguments @(
        'msbuild', (Join-Path $PSScriptRoot 'ApiCompat.proj'),
        '-target:CompareSdkAssemblies', '-nologo', '-tl:off', '-nodeReuse:false', '-verbosity:minimal',
        "-property:TargetFramework=$($Evaluation.Properties.TargetFramework)",
        "-property:SdkChangesInputFile=$inputPath", "-property:SdkChangesWorkDirectory=$WorkDirectory",
        "-binaryLogger:$logPath;ProjectImports=None"
    )
    $log = Read-SdkChangeBuildLog $logPath
    $log.ExitCode = $process.ExitCode
    $log.ProcessOutput = "$($process.StdOut)`n$($process.StdErr)"
    $log.CompatibilityHeader = "API compatibility errors between '$($properties.SdkChangesAssemblyIdentity)' (left) and '$($properties.SdkChangesAssemblyIdentity)' (right):"
    return $log
}

function ConvertFrom-SdkChangeApiCompat {
    param([hashtable]$Log, [string]$TargetFramework, [switch]$Reverse)

    if (!$Log.Finished -or !$Log.Completed -or $Log.ExitCode -notin @(0, 1)) {
        throw "ApiCompat did not complete (exit $($Log.ExitCode)).`n$($Log.ProcessOutput)"
    }
    $changes = [System.Collections.Generic.List[object]]::new()
    $diagnostics = [System.Collections.Generic.List[string]]::new()
    $limitations = [System.Collections.Generic.List[string]]::new()
    $seen = [System.Collections.Generic.HashSet[string]]::new([System.StringComparer]::Ordinal)
    $compatibilityCount = 0
    $direction = if ($Reverse) { 'reverse' } else { 'forward' }
    foreach ($diagnostic in $Log.Diagnostics) {
        $code = $diagnostic.Code
        $message = $diagnostic.Message
        $isNativeSummary = ($Log.Contains('CompatibilityHeader') -and $message -ceq $Log.CompatibilityHeader) -or
            $message -ceq "API breaking changes found. If those are intentional, the APICompat suppression file can be updated by rebuilding with '/p:ApiCompatGenerateSuppressionFile=true'"
        if (!$code -and $isNativeSummary) {
            if ($seen.Add($message)) { $diagnostics.Add("[$direction][$TargetFramework] $message") }
            continue
        }
        # CP0004 means an assembly could not be matched, not an API removal. Unknown codes fail closed.
        if ($code -notmatch '^CP(000[12356789]|001[0-9]|002[01])$') {
            throw "Unrecognized or fatal ApiCompat diagnostic ${code}: $message"
        }
        $eventKey = if ($diagnostic.Contains('EventKey')) { $diagnostic.EventKey } else { '' }
        if (!$seen.Add("$eventKey`n$code`n$message")) { continue }
        $compatibilityCount++
        $diagnostics.Add("[$direction][$TargetFramework] ${code}: $message")
        if ($Reverse -and $code -notin @('CP0001', 'CP0002')) {
            $limitations.Add("Reverse $code is a structural difference, not evidence of an added API or a new breaking change.")
            continue
        }
        $symbol = ''
        if ($code -eq 'CP0003') {
            if ($message -match "^(?<symbol>.+) assembly version '[^']+' should be equal to or higher than .+ version '[^']+'\.$") {
                $symbol = $Matches.symbol
            }
        }
        elseif ($code -in @('CP0014', 'CP0015', 'CP0016')) {
            if ($message -match "^Cannot (?:change arguments of|add|remove) attribute '[^']+' (?:on|to|from) '(?<symbol>[^']+)'\.$") {
                $symbol = $Matches.symbol
            }
        }
        elseif ($code -eq 'CP0011') {
            if ($message -match "^Value of field '(?<member>[^']+)' in enum '(?<enum>[^']+)' changed from '[^']*' to '[^']*'\.$") {
                $symbol = "$($Matches.enum).$($Matches.member)"
                $limitations.Add('ApiCompat CP0011 can provide unqualified enum/field names; identifying the namespace requires review.')
            }
        }
        elseif ($message -match "'(?<symbol>[^']+)'") {
            $symbol = $Matches.symbol
        }
        if (!$symbol) {
            $limitations.Add("The symbol for $code could not be extracted; consult the original diagnostic description.")
        }
        $kind = if ($Reverse) { 'added' } elseif ($code -in @('CP0001', 'CP0002')) { 'removed' } else { 'changed' }
        $changes.Add([ordered]@{
            kind = $kind
            symbol = $symbol
            description = $message
            isBreaking = !$Reverse
            diagnosticId = $code
            targetFramework = $TargetFramework
        })
    }
    if (($Log.ExitCode -eq 1 -or !$Log.Succeeded) -and $compatibilityCount -eq 0) {
        throw "ApiCompat failed without a recognized compatibility diagnostic.`n$($Log.ProcessOutput)"
    }
    return @{ Changes = @($changes); Diagnostics = @($diagnostics); Limitations = @($limitations) }
}

function New-SdkChangeReport {
    param([AllowNull()][string]$BaselineVersion, [object[]]$Changes, [string[]]$Diagnostics, [string[]]$Limitations)

    $breaking = @($Changes | Where-Object { $_.isBreaking })
    $added = @($Changes | Where-Object { $_.kind -eq 'added' })
    if (!$BaselineVersion) {
        $text = '### Breaking Changes' + "`n" + 'Not applicable: no GA NuGet baseline exists; no comparison was performed.' +
            "`n`n" + '### Features Added' + "`n" + 'Not determined without a GA baseline.'
    }
    else {
        $sections = @()
        foreach ($section in @(
            @{ Heading = '### Breaking Changes'; Items = $breaking },
            @{ Heading = '### Features Added'; Items = $added }
        )) {
            $lines = @($section.Items | ForEach-Object {
                "- [$($_.diagnosticId)] $($_.description) (target framework: $($_.targetFramework))"
            })
            if ($lines.Count -eq 0) { $lines = @('None.') }
            $sections += $section.Heading + "`n" + ($lines -join "`n")
        }
        $text = $sections -join "`n`n"
    }
    if (@($Changes | Where-Object { $_.kind -eq 'removed' }).Count -gt 0 -and $added.Count -gt 0) {
        $Limitations += 'Removals and additions are independent evidence. Correlating changed signatures or renames requires review; no similarity matching was performed.'
    }
    return [ordered]@{
        changes = $text
        hasBreakingChange = $breaking.Count -gt 0
        details = [ordered]@{
            baselineVersion = $(if ($BaselineVersion) { $BaselineVersion } else { $null })
            apiChanges = @($Changes)
            diagnostics = @($Diagnostics | Sort-Object -Unique)
            limitations = @($Limitations | Sort-Object -Unique)
        }
    }
}

function Get-SdkChangeTargetFrameworks {
    param([hashtable]$Properties)

    $frameworks = if ($Properties.TargetFramework) { @($Properties.TargetFramework) } else { $Properties.TargetFrameworks -split ';' }
    return @($frameworks | Where-Object { $_ } | Sort-Object -Unique)
}

function Invoke-SdkChangeExtraction {
    param([string]$PackagePath, [string]$SdkRepoPath, [string]$OutputJsonFile)

    if (![System.IO.Path]::IsPathFullyQualified($OutputJsonFile)) {
        throw "OutputJsonFile must be absolute: $OutputJsonFile"
    }
    if (Test-Path -LiteralPath $OutputJsonFile) {
        if (!(Test-Path -LiteralPath $OutputJsonFile -PathType Leaf)) { throw "OutputJsonFile is not a file: $OutputJsonFile" }
        Remove-Item -LiteralPath $OutputJsonFile -Force
    }
    $work = Join-Path ([System.IO.Path]::GetTempPath()) "sdk-changes-$([guid]::NewGuid().ToString('N'))"
    [void][System.IO.Directory]::CreateDirectory($work)
    try {
        $project = Get-SdkChangeProject -PackagePath $PackagePath -SdkRepoPath $SdkRepoPath
        $outer = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $SdkRepoPath -WorkDirectory $work
        $frameworks = @(Get-SdkChangeTargetFrameworks $outer.Properties)
        if ($frameworks.Count -eq 0) { throw "No target frameworks were evaluated for $project." }
        $current = @{}
        foreach ($framework in $frameworks) {
            $evaluation = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $SdkRepoPath -WorkDirectory $work `
                -TargetFramework $framework -Configuration $outer.Properties.Configuration
            if ($evaluation.Properties.PackageId -ne $outer.Properties.PackageId -or
                !$evaluation.Properties.ApiCompatBaselineTargetFramework) {
                throw "Package identity or ApiCompat baseline framework is not consistent for $framework."
            }
            $assembly = Assert-SdkChangeCurrentAssembly $evaluation
            $current[$framework] = @{
                Evaluation = $evaluation
                Assembly = $assembly
                Hash = (Get-FileHash -LiteralPath $assembly).Hash
            }
        }
        $version = Get-SdkChangeLatestGaVersion $outer.Properties.PackageId
        $changes = @()
        $diagnostics = @("Current artifact scope: Configuration=$($outer.Properties.Configuration); TargetFrameworks=$($frameworks -join ', ').")
        $limitations = @(
            'Metadata/API compatibility does not determine runtime behavior or wire-contract compatibility.',
            'Freshness uses portable/embedded PDB source checksums and evaluated build-input timestamps. Build-time-generated inputs and timestamp-preserving changes to non-source build inputs require a fresh build.',
            'Approved ApiCompat suppressions and NoWarn are honored; suppressed differences are not listed.'
        )
        $omittedFrameworks = @($outer.Properties.TargetFrameworks -split ';' | Where-Object { $_ -and $_ -notin $frameworks } | Sort-Object -Unique)
        if ($omittedFrameworks.Count -gt 0) {
            $limitations += "TargetFramework limits this extraction to $($frameworks -join ', '); declared frameworks not evaluated: $($omittedFrameworks -join ', '). This is not a full multi-target package comparison."
        }
        if (!$version) {
            $limitations += "No GA NuGet release exists for $($outer.Properties.PackageId). Compatibility and additions are not applicable; no comparison was performed."
        }
        else {
            $baselines = @{}
            foreach ($framework in $frameworks) {
                $entry = $current[$framework]
                $evaluation = $entry.Evaluation
                $properties = $evaluation.Properties
                $baselineFramework = $properties.ApiCompatBaselineTargetFramework
                $key = "$baselineFramework|$($properties.TargetFileName)"
                if (!$baselines.Contains($key)) {
                    $baselines[$key] = Get-SdkChangeBaseline -PackageId $properties.PackageId -Version $version `
                        -TargetFramework $baselineFramework -TargetFileName $properties.TargetFileName `
                        -SdkRepoPath $SdkRepoPath -WorkDirectory (Join-Path $work "baseline-$baselineFramework")
                    Assert-SdkChangeReferences -Assembly $baselines[$key].Assembly -References $baselines[$key].References
                }
                $baseline = $baselines[$key]
                $referenceDirectory = Join-Path $work "current-$framework"
                [void][System.IO.Directory]::CreateDirectory($referenceDirectory)
                $references = @(Get-SdkChangeCurrentReferences -Evaluation $evaluation -SdkRepoPath $SdkRepoPath -WorkDirectory $referenceDirectory)
                Assert-SdkChangeReferences -Assembly $entry.Assembly -References $references
                $rules = Get-SdkChangeRules -Evaluation $evaluation -SdkRepoPath $SdkRepoPath
                $forward = Invoke-SdkChangeApiCompat -LeftAssembly $baseline.Assembly -RightAssembly $entry.Assembly `
                    -LeftReferences $baseline.References -RightReferences $references -Evaluation $evaluation -Rules $rules `
                    -SdkRepoPath $SdkRepoPath -WorkDirectory (Join-Path $work "forward-$framework")
                $reverse = Invoke-SdkChangeApiCompat -LeftAssembly $entry.Assembly -RightAssembly $baseline.Assembly `
                    -LeftReferences $references -RightReferences $baseline.References -Evaluation $evaluation -Rules $rules `
                    -SdkRepoPath $SdkRepoPath -WorkDirectory (Join-Path $work "reverse-$framework")
                foreach ($result in @(
                    (ConvertFrom-SdkChangeApiCompat -Log $forward -TargetFramework $framework),
                    (ConvertFrom-SdkChangeApiCompat -Log $reverse -TargetFramework $framework -Reverse)
                )) {
                    $changes += $result.Changes
                    $diagnostics += $result.Diagnostics
                    $limitations += $result.Limitations
                }
            }
        }
        $finalOuter = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $SdkRepoPath -WorkDirectory $work
        if ($finalOuter.Properties.PackageId -ne $outer.Properties.PackageId -or
            (@(Get-SdkChangeTargetFrameworks $finalOuter.Properties) -join ';') -ne ($frameworks -join ';')) {
            throw 'The package identity or target frameworks changed during extraction. Run extraction again.'
        }
        foreach ($framework in $frameworks) {
            $finalEvaluation = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $SdkRepoPath -WorkDirectory $work `
                -TargetFramework $framework -Configuration $outer.Properties.Configuration
            $assembly = Assert-SdkChangeCurrentAssembly $finalEvaluation
            if ($assembly -ne $current[$framework].Assembly -or (Get-FileHash -LiteralPath $assembly).Hash -ne $current[$framework].Hash) {
                throw "The current assembly changed during extraction for $framework. Run extraction again."
            }
        }
        $report = New-SdkChangeReport -BaselineVersion $version -Changes $changes -Diagnostics $diagnostics -Limitations $limitations
        $json = $report | ConvertTo-Json -Depth 10
    }
    finally {
        Remove-Item -LiteralPath $work -Recurse -Force
    }
    [void][System.IO.Directory]::CreateDirectory((Split-Path $OutputJsonFile -Parent))
    $temporaryOutput = "$OutputJsonFile.$([guid]::NewGuid().ToString('N')).tmp"
    try {
        [System.IO.File]::WriteAllText($temporaryOutput, $json, [System.Text.UTF8Encoding]::new($false))
        [System.IO.File]::Move($temporaryOutput, $OutputJsonFile, $true)
    }
    finally {
        if (Test-Path -LiteralPath $temporaryOutput -PathType Leaf) { Remove-Item -LiteralPath $temporaryOutput -Force }
    }
}
