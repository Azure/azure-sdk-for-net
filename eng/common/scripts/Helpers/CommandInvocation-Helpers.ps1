. $PSScriptRoot/../logging.ps1

function Format-CommandArgument([string] $Argument) {
  if ($Argument -match '[\s"'']') {
    return '"' + $Argument.Replace('"', '\"') + '"'
  }
  return $Argument
}

function Invoke-AzSdkCliCommand([string] $Executable, [string[]] $Arguments) {
  $command = Get-Command $Executable -ErrorAction SilentlyContinue
  if (-not $command) {
    throw "The azsdk CLI executable was not found at '$Executable'. Install azsdk before continuing."
  }

  if ($command.CommandType -ne [System.Management.Automation.CommandTypes]::Application) {
    $output = @(& $command @Arguments 2>&1)
    return [PSCustomObject]@{
      ExitCode = $LASTEXITCODE
      Output = ($output | ForEach-Object { "$_" }) -join [Environment]::NewLine
      Stdout = ($output | ForEach-Object { "$_" }) -join [Environment]::NewLine
      Stderr = ""
    }
  }

  $startInfo = [System.Diagnostics.ProcessStartInfo]::new()
  $startInfo.FileName = $command.Source
  $startInfo.UseShellExecute = $false
  $startInfo.RedirectStandardOutput = $true
  $startInfo.RedirectStandardError = $true
  $startInfo.CreateNoWindow = $true

  if ($startInfo.PSObject.Properties["ArgumentList"]) {
    foreach ($argument in $Arguments) {
      $startInfo.ArgumentList.Add($argument)
    }
  }
  else {
    $formattedArguments = @($Arguments | ForEach-Object { Format-CommandArgument $_ })
    $startInfo.Arguments = $formattedArguments -join " "
  }

  $process = [System.Diagnostics.Process]::Start($startInfo)
  $stdoutTask = $process.StandardOutput.ReadToEndAsync()
  $stderrTask = $process.StandardError.ReadToEndAsync()
  $process.WaitForExit()
  $stdout = $stdoutTask.GetAwaiter().GetResult()
  $stderr = $stderrTask.GetAwaiter().GetResult()

  return [PSCustomObject]@{
    ExitCode = $process.ExitCode
    Output = if (-not [string]::IsNullOrWhiteSpace($stdout)) { $stdout } else { $stderr }
    Stdout = $stdout
    Stderr = $stderr
  }
}

function Confirm-AzSdkCliMinimumVersion([string] $Executable, [version] $MinimumVersion) {
  $commandResult = Invoke-AzSdkCliCommand $Executable @("--version")
  $versionMatch = [regex]::Match($commandResult.Output, '(?<!\d)\d+\.\d+\.\d+(?:\.\d+)?(?!\d)')
  if ($commandResult.ExitCode -ne 0 -or -not $versionMatch.Success) {
    throw "Unable to determine the azsdk CLI version. Run 'azsdk --version' to verify the installation."
  }

  $installedVersion = [version] $versionMatch.Value
  if ($installedVersion -lt $MinimumVersion) {
    throw "azsdk CLI version $MinimumVersion or later is required; found $installedVersion."
  }
}

function Invoke-LoggedMsbuildCommand
{
    [CmdletBinding()]
    param
    (
        [string] $Command,
        [string] $ExecutePath,
        [switch] $GroupOutput,
        [int[]] $AllowedExitCodes = @(0)
    )
    return Invoke-LoggedCommand $Command -ExecutePath $ExecutePath -GroupOutput:$GroupOutput -AllowedExitCodes $AllowedExitCodes -OutputProcessor { param($line) ProcessMsBuildLogLine $line }

}

function Invoke-LoggedCommand
{
    [CmdletBinding()]
    param
    (
        [string] $Command,
        [string] $ExecutePath,
        [switch] $GroupOutput,
        [int[]] $AllowedExitCodes = @(0),
        [switch] $DoNotExitOnFailedExitCode,
        [scriptblock] $OutputProcessor
    )

    $startTime = Get-Date

    if($GroupOutput) {
        LogGroupStart $Command
    } else {
        Write-Host "> $Command"
    }

    if($ExecutePath) {
      Push-Location $ExecutePath
    }

    if (!$OutputProcessor) {
      $OutputProcessor = { param($line) $line }
    }

    try {
      Invoke-Expression $Command | Foreach-Object { & $OutputProcessor $_ }

      $duration = (Get-Date) - $startTime

      if($GroupOutput) {
        LogGroupEnd
      }

      if($LASTEXITCODE -notin $AllowedExitCodes)
      {
          LogError "Command failed to execute ($duration): $Command`n"
          if (!$DoNotExitOnFailedExitCode) {
              exit $LASTEXITCODE
          }
      }
      else {
          Write-Host "Command succeeded ($duration)`n"
      }
    }
    finally {
      if($ExecutePath) {
        Pop-Location
      }
    }
}

function Set-ConsoleEncoding
{
    [CmdletBinding()]
    param
    (
        [string] $Encoding = 'utf-8'
    )

    $outputEncoding = [System.Text.Encoding]::GetEncoding($Encoding)
    [Console]::OutputEncoding = $outputEncoding
    [Console]::InputEncoding = $outputEncoding
}
