<#
.SYNOPSIS
Helpers for retrying commands that fail because a package is not on our NuGet feed yet.

.DESCRIPTION
The .NET SDK references a number of packages implicitly, at versions baked into whichever SDK the
build resolved: the trimming and native AOT tool packs (Microsoft.NET.ILLink.Tasks,
Microsoft.DotNet.ILCompiler) plus the targeting, runtime and host packs. Every new SDK patch brings
brand new versions of those packages, and global.json rolls forward, so CI picks them up as soon as
they ship.

Our feed mirrors nuget.org automatically, but the mirroring is not instantaneous. The first build to
ask for a just-released version can outrun it and fail restore with NU1101/NU1102/NU1103 even though
nothing is wrong with the repo. Waiting briefly and asking again resolves it.

Only that specific class of failure is retried. Anything else fails on the first attempt so that real
breaks are not delayed.
#>

. $PSScriptRoot/../common/scripts/logging.ps1

# NuGet codes meaning "the requested package or version is not on the feed", plus NU1301 for a feed
# that could not be reached at all. NU1603 is a warning by default but is escalated to an error in
# builds that treat warnings as errors, and it has the same cause.
$TransientRestoreErrorPattern = '\bNU(1101|1102|1103|1301|1603)\b'

function Invoke-WithRestoreRetry {
    <#
    .PARAMETER Command
    Command line to run through Invoke-Expression, matching how Invoke-LoggedCommand is called.

    .PARAMETER ScriptBlock
    Script block to run, for callers that already handle a non-zero $LASTEXITCODE themselves.

    .PARAMETER MsBuildLogging
    Surface msbuild error and warning lines as pipeline issues, the way Invoke-LoggedMsbuildCommand
    does. Transient restore errors are left undecorated while retries remain, so that an attempt we
    are about to discard does not register an error against the build.

    .PARAMETER ExitOnFailure
    Log the failure and exit, matching Invoke-LoggedCommand. Omit this when the caller inspects
    $LASTEXITCODE itself.
    #>
    [CmdletBinding(DefaultParameterSetName = 'ScriptBlock')]
    param (
        [Parameter(Mandatory = $true, ParameterSetName = 'Command', Position = 0)]
        [string] $Command,

        [Parameter(Mandatory = $true, ParameterSetName = 'ScriptBlock', Position = 0)]
        [scriptblock] $ScriptBlock,

        [switch] $MsBuildLogging,
        [switch] $ExitOnFailure,
        [int] $MaxAttempts = 3,
        [int] $RetryDelaySeconds = 30
    )

    for ($attempt = 1; $attempt -le $MaxAttempts; $attempt++) {
        $output = [System.Collections.Generic.List[string]]::new()
        $suppressTransientIssues = $attempt -lt $MaxAttempts
        $startTime = Get-Date

        if ($PSCmdlet.ParameterSetName -eq 'Command') {
            Write-Host "> $Command"
            $invocation = { Invoke-Expression $Command }
        }
        else {
            $invocation = $ScriptBlock
        }

        & $invocation 2>&1 | ForEach-Object {
            $line = "$_"
            $output.Add($line)

            if ($MsBuildLogging -and -not ($suppressTransientIssues -and $line -match $TransientRestoreErrorPattern)) {
                ProcessMsBuildLogLine $line
            }
            else {
                $line
            }
        }

        $exitCode = if ($null -eq $LASTEXITCODE) { 0 } else { $LASTEXITCODE }
        $duration = (Get-Date) - $startTime

        if ($exitCode -eq 0) {
            if ($PSCmdlet.ParameterSetName -eq 'Command') {
                Write-Host "Command succeeded ($duration)`n"
            }
            return
        }

        if (-not $suppressTransientIssues -or -not ($output -match $TransientRestoreErrorPattern)) {
            if ($ExitOnFailure) {
                LogError "Command failed to execute ($duration) after $attempt attempt(s).`n"
                exit $exitCode
            }
            return
        }

        Write-Host "Restore failed because a package is not on the feed yet. This is usually our feed still mirroring a version that a newly released .NET SDK asked for."

        # NuGet caches the "not found" response, so without clearing it a retry would replay the
        # cached miss instead of asking the feed again.
        dotnet nuget locals http-cache --clear | Out-Null

        $delay = $RetryDelaySeconds * $attempt
        Write-Host "Retrying in $delay seconds (attempt $($attempt + 1) of $MaxAttempts)."
        Start-Sleep -Seconds $delay
    }
}
