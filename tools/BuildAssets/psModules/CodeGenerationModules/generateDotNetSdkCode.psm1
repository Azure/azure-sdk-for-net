function launchProcess {
    param(
        [Parameter(Mandatory = $true)]
        [string] $command, 
        [string] $args)
    $pinfo = New-Object System.Diagnostics.ProcessStartInfo
    $pinfo.FileName = $command
    $pinfo.RedirectStandardError = $true
    $pinfo.RedirectStandardOutput = $true
    $pinfo.UseShellExecute = $false
    
    if(![string]::IsNullOrEmpty($args))
    {
        $pinfo.Arguments = $args
    }
    
    $p = New-Object System.Diagnostics.Process
    $p.StartInfo = $pinfo
    $p.Start() | Out-Null
    $p.WaitForExit()
    $stdout = $p.StandardOutput.ReadToEnd()
    $stderr = $p.StandardError.ReadToEnd()
    Write-Host $stdout
    Write-Host $stderr
    return $p.ExitCode
}

function Get-AutoRestHelp {
    Write-Host("Fetching AutoRest help");
    launchProcess "cmd.exe" "/c autorest.cmd --help"
}

function Install-AutoRest {
    param(
        [Parameter(Mandatory = $true)]
        $Version
    )
    Write-Host "Installing AutoRest version: $Version";
    $exitCode = launchProcess "cmd.exe" "/c npm.cmd install -g autorest@$Version"
    if ($exitCode -ne 0) {
        Write-Error "AutoRest installation failed; please try again"
    }
    else {
        Write-Host "AutoRest installed successfully."
    }
}

function Start-CodeGeneration {
param(
    [Parameter(Mandatory = $true, HelpMessage ="Please provide a spec to generate the code")]
    [string] $ConfigFile,
    [Parameter(Mandatory = $true, HelpMessage ="Please provide an output directory for the generated code")]
    [string] $SdkDirectory,
    [Parameter(Mandatory = $true, HelpMessage ="Please provide a version for the AutoRest release")]
    [string] $Version
    )

    Write-Host("Generating CSharp code");
    $cmd = "cmd.exe"
    $args = "/c autorest.cmd $ConfigFile --csharp --csharp-sdks-folder=$SdkDirectory --version=$Version --reflect-api-versions"
    Write-Output "Executing AutoRest command"
    Write-Output "$cmd $args"
    launchProcess $cmd $args
}

function Start-MetadataGeneration {
    param(
        [Parameter(Mandatory = $true)]
        [string] $SpecsRepoFork,
        [Parameter(Mandatory = $true)]
        [string] $SpecsRepoBranch,
        [Parameter(Mandatory = $true)]
        [string] $Version
    )

    Write-Output $([DateTime]::UtcNow.ToString('u').Replace('Z',' UTC'))

    Write-Output ""
    Write-Output "1) azure-rest-api-specs repository information"
    Write-Output "GitHub fork: $SpecsRepoFork"
    Write-Output "Branch:      $SpecsRepoBranch"
    
    Try
    {
        [Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
        Write-Output "Commit:     " (Invoke-RestMethod "https://api.github.com/repos/$($SpecsRepoFork)/azure-rest-api-specs/branches/$($SpecsRepoBranch)").commit.sha
    }
    Catch [System.Exception]
    {
        Write-Output $_.Exception.ToString()
    }

    Write-Output ""
    Write-Output "2) AutoRest information"
    Write-Output "Requested version:" $Version
    Try
    {
        Write-Output "Bootstrapper version:   " (npm list -g autorest)
    }
    Catch{}
    Try
    {
        Write-Output "Latest installed version:   " (autorest --list-installed | Where {$_ -like "*Latest Core Installed*"}).Split()[-1]
    }
    Catch{}
    Try
    {
        Write-Output "Latest installed version:   " (autorest --list-installed | Where {$_ -like "*@microsoft.azure/autorest-core*"} | Select -Last 1).Split('|')[3]
    }
    Catch{}
}


export-modulemember -function Get-AutoRestHelp
export-modulemember -function Install-AutoRest
export-modulemember -function Start-CodeGeneration
export-modulemember -function Start-MetadataGeneration