#Requires -Version 7.6

BeforeAll {
    Set-StrictMode -Version 3
    . (Join-Path $PSScriptRoot '..' 'Get-SdkChanges.Helpers.ps1')
    . (Join-Path $PSScriptRoot '..' 'SdkChangesCI.Helpers.ps1')
    $repo = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..' '..')).Path
}

Describe 'Large SDK source freshness validation' -Tag 'IntegrationTest' {
    It 'finishes the production detector within its default CI timeout for 4278 <Mode> sources and three frameworks' -TestCases @(
        @{ Mode = 'physical' }, @{ Mode = 'mapped' }
    ) {
        param($Mode)
        $root = Join-Path $TestDrive $Mode
        $sourceDirectory = Join-Path $root 'src'
        $localFeed = Join-Path $root 'feed'
        $detectorDirectory = Join-Path $root 'eng' 'scripts' 'compatibility'
        foreach ($directory in @($sourceDirectory, $localFeed, $detectorDirectory)) {
            [void][System.IO.Directory]::CreateDirectory($directory)
        }
        Copy-Item -LiteralPath (Join-Path $repo 'global.json') -Destination $root
        Copy-Item -LiteralPath (Join-Path $repo 'eng' 'ApiListing.exclude-attributes.txt') -Destination (Join-Path $root 'eng')
        foreach ($name in @('Get-SdkChanges.ps1', 'Get-SdkChanges.Helpers.ps1', 'ApiCompat.proj', 'SdkChangeReferences.proj')) {
            Copy-Item -LiteralPath (Join-Path $PSScriptRoot '..' $name) -Destination $detectorDirectory
        }
        [System.IO.File]::WriteAllText((Join-Path $root 'NuGet.Config'),
            "<configuration><packageSources><clear /><add key=`"fixtures`" value=`"$([System.Security.SecurityElement]::Escape($localFeed))`" /></packageSources></configuration>")
        $project = Join-Path $sourceDirectory 'LargeFixture.csproj'
        $pathMap = if ($Mode -eq 'mapped') {
            [System.Security.SecurityElement]::Escape("$root$([System.IO.Path]::DirectorySeparatorChar)=/_/")
        } else { '' }
        $projectContent = @'
<Project>
  <PropertyGroup>
    <ImportDirectoryBuildProps>false</ImportDirectoryBuildProps>
    <ImportDirectoryBuildTargets>false</ImportDirectoryBuildTargets>
    <ImportDirectoryPackagesProps>false</ImportDirectoryPackagesProps>
  </PropertyGroup>
  <Import Project="Sdk.props" Sdk="Microsoft.NET.Sdk" />
  <PropertyGroup>
    <TargetFrameworks>netstandard2.0;net8.0;net10.0</TargetFrameworks>
    <ApiCompatBaselineTargetFramework>$(TargetFramework)</ApiCompatBaselineTargetFramework>
    <PackageId>SdkChange.LargeFixture</PackageId>
    <PackageVersion>1.0.0</PackageVersion>
    <LangVersion>latest</LangVersion>
    <NuGetAudit>false</NuGetAudit>
    <PathMap>PATH_MAP</PathMap>
  </PropertyGroup>
  <Import Project="Sdk.targets" Sdk="Microsoft.NET.Sdk" />
  <Target Name="DoNotBuildDuringDetection" BeforeTargets="Build;Compile;CoreCompile;RunAnalyzers;ResolveReferences"
          Condition="Exists('do-not-build')">
    <Error Text="The detector must use existing artifacts." />
  </Target>
</Project>
'@
        [System.IO.File]::WriteAllText($project, $projectContent.Replace('PATH_MAP', $pathMap))
        for ($i = 0; $i -lt 4278; $i++) {
            $access = if ($i -eq 0) { 'public' } else { 'internal' }
            [System.IO.File]::WriteAllText((Join-Path $sourceDirectory "Source$i.cs"), "$access class Source$i { public int Read() => $i; }")
        }
        $restored = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments @('restore', $project, '--source', $localFeed, '--verbosity', 'quiet')
        if ($restored.ExitCode -ne 0 -and "$($restored.StdOut)`n$($restored.StdErr)" -match 'error NU1101:') {
            $restored = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments @(
                'restore', $project, '--configfile', (Join-Path $repo 'NuGet.Config'), '--verbosity', 'quiet'
            )
        }
        if ($restored.ExitCode -ne 0) { throw "Large fixture restore failed.`n$($restored.StdOut)`n$($restored.StdErr)" }
        $built = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments @(
            'build', $project, '--no-restore', '--configuration', 'Release', '--verbosity', 'quiet',
            '-p:UseSharedCompilation=false', '-tl:off'
        )
        if ($built.ExitCode -ne 0) { throw "Large fixture compilation failed.`n$($built.StdOut)`n$($built.StdErr)" }
        $packed = Invoke-SdkChangeProcess -WorkingDirectory $root -Arguments @(
            'pack', $project, '--no-build', '--no-restore', '--configuration', 'Release', '--output', $localFeed, '--verbosity', 'quiet'
        )
        if ($packed.ExitCode -ne 0) { throw "Large fixture packaging failed.`n$($packed.StdOut)`n$($packed.StdErr)" }
        $assets = Read-SdkChangeJson (Join-Path $sourceDirectory 'obj' 'project.assets.json')
        foreach ($key in $assets.libraries.Keys) {
            $library = $assets.libraries[$key]
            if ($library.type -ne 'package') { continue }
            $archiveName = ($key.Replace('/', '.') + '.nupkg').ToLowerInvariant()
            $archives = @($assets.packageFolders.Keys | ForEach-Object {
                Join-Path $_ $library.path $archiveName
            } | Where-Object { Test-Path -LiteralPath $_ -PathType Leaf })
            $archives.Count | Should -BeGreaterThan 0
            Copy-Item -LiteralPath $archives[0] -Destination $localFeed -Force
        }
        [System.IO.File]::WriteAllText((Join-Path $sourceDirectory 'do-not-build'), '')
        $work = Join-Path $root 'evaluation'
        [void][System.IO.Directory]::CreateDirectory($work)
        $evaluation = Get-SdkChangeEvaluation -Project $project -SdkRepoPath $root -WorkDirectory $work `
            -TargetFramework 'net8.0' -Configuration 'Release'
        $evaluation.Items.Compile.Count | Should -BeGreaterOrEqual 4278
        $documents = @(Get-SdkChangeCompilationDocuments -Assembly $evaluation.Items.IntermediateAssembly[0].FullPath -Evaluation $evaluation)
        $documents.Count | Should -BeGreaterOrEqual 4278
        if ($Mode -eq 'mapped') { @($documents | Where-Object { $_.Name -like '/_/*' }).Count | Should -BeGreaterOrEqual 4278 }

        $output = Join-Path $root 'report.json'
        $watch = [System.Diagnostics.Stopwatch]::StartNew()
        $process = Invoke-SdkChangesCIProcess -PowerShellPath (Get-Process -Id $PID).Path `
            -DetectorPath (Join-Path $PSScriptRoot 'fixtures' 'LargeSourceDetector.ps1') `
            -SdkRepoPath $root -PackagePath $sourceDirectory -OutputJsonFile $output
        $watch.Stop()
        Write-Host "Large $Mode fixture detector: $($watch.Elapsed.TotalSeconds.ToString('F1')) seconds."
        $process.TimedOut | Should -BeFalse
        $process.ExitCode | Should -Be 0 -Because "$($process.StdOut)`n$($process.StdErr)"
        $watch.Elapsed.TotalSeconds | Should -BeLessThan 300
        $report = Read-SdkChangeJson $output
        $report.hasBreakingChange | Should -BeFalse
        $report.details.baselineVersion | Should -Be '1.0.0'
        $report.details.diagnostics | Should -Contain 'Current artifact scope: Configuration=Release; TargetFrameworks=net10.0, net8.0, netstandard2.0.'
    }
}
