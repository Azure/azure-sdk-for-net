. $PSScriptRoot/../logging.ps1

function Format-CommandArgument([string] $Argument) {
  if ($Argument -match '[\s"'']') {
    return '"' + $Argument.Replace('"', '\"') + '"'
  }
  return $Argument
}

function ConvertFrom-AzSdkCliJsonResponse([string[]] $Streams) {
  $responses = [System.Collections.Generic.List[object]]::new()
  $lastParseError = $null

  foreach ($stream in $Streams) {
    if ([string]::IsNullOrWhiteSpace($stream)) {
      continue
    }

    for ($start = 0; $start -lt $stream.Length; $start++) {
      if ($stream[$start] -ne "{") {
        continue
      }

      $stack = [System.Collections.Generic.List[char]]::new()
      $inString = $false
      $escaped = $false
      for ($index = $start; $index -lt $stream.Length; $index++) {
        $character = $stream[$index]
        if ($inString) {
          if ($escaped) {
            $escaped = $false
          }
          elseif ($character -eq "\") {
            $escaped = $true
          }
          elseif ($character -eq '"') {
            $inString = $false
          }
          continue
        }

        if ($character -eq '"') {
          $inString = $true
        }
        elseif ($character -eq "{" -or $character -eq "[") {
          $stack.Add($character)
        }
        elseif ($character -eq "}" -or $character -eq "]") {
          if ($stack.Count -eq 0 -or
            ($character -eq "}" -and $stack[$stack.Count - 1] -ne "{") -or
            ($character -eq "]" -and $stack[$stack.Count - 1] -ne "[")) {
            break
          }

          $stack.RemoveAt($stack.Count - 1)
          if ($stack.Count -eq 0) {
            $candidate = $stream.Substring($start, $index - $start + 1)
            try {
              $response = $candidate | ConvertFrom-Json -ErrorAction Stop
              if ($response.PSObject.Properties["operation_status"] -and
                $response.operation_status -is [string] -and
                $response.operation_status -in @("Succeeded", "Failed")) {
                $responses.Add($response)
              }
              $start = $index
            }
            catch {
              $lastParseError = $_.Exception.Message
            }
            break
          }
        }
      }

    }
  }

  if ($responses.Count -eq 1) {
    return [PSCustomObject]@{
      Response = $responses[0]
      Error = $null
    }
  }

  $errorMessage = if ($responses.Count -gt 1) {
    "Multiple JSON objects were found in the azsdk output."
  }
  elseif ($lastParseError) {
    "No valid JSON object was found in the azsdk output. $lastParseError"
  }
  else {
    "No valid JSON object was found in the azsdk output."
  }
  return [PSCustomObject]@{
    Response = $null
    Error = $errorMessage
  }
}

function New-AzSdkCliCommandResult(
  [int] $ExitCode,
  [string] $Output,
  [string] $Stdout,
  [string] $Stderr,
  [switch] $ParseJsonResponse
) {
  $result = [PSCustomObject]@{
    ExitCode = $ExitCode
    Output = $Output
    Stdout = $Stdout
    Stderr = $Stderr
  }
  if ($ParseJsonResponse) {
    $parsedResult = ConvertFrom-AzSdkCliJsonResponse @($Stdout, $Stderr)
    $result | Add-Member -NotePropertyName ParsedResponse -NotePropertyValue $parsedResult.Response
    $result | Add-Member -NotePropertyName ParseError -NotePropertyValue $parsedResult.Error
  }
  return $result
}

function Invoke-AzSdkCliCommand([string] $Executable, [string[]] $Arguments, [switch] $ParseJsonResponse) {
  $command = Get-Command $Executable -ErrorAction SilentlyContinue
  if (-not $command) {
    throw "The azsdk CLI executable was not found at '$Executable'. Install azsdk before continuing."
  }

  if ($command.CommandType -ne [System.Management.Automation.CommandTypes]::Application) {
    $output = @(& $command @Arguments 2>&1)
    $stdout = ($output | ForEach-Object { "$_" }) -join [Environment]::NewLine
    return New-AzSdkCliCommandResult $LASTEXITCODE $stdout $stdout "" -ParseJsonResponse:$ParseJsonResponse
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

  $output = if (-not [string]::IsNullOrWhiteSpace($stdout)) { $stdout } else { $stderr }
  return New-AzSdkCliCommandResult $process.ExitCode $output $stdout $stderr -ParseJsonResponse:$ParseJsonResponse
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
