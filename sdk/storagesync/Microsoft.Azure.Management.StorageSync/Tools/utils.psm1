$global:ErrorActionPreference = "Stop"
Set-StrictMode -Version Latest
$scriptDirectory = Split-Path ($MyInvocation.MyCommand.Path)  

# This function can be used from outside of devshell
# to bootstrap the environment.
# it is only safe to use functions from within this library.
# do not use anything from devshell as it might not be available, yet.
function Setup-DevShell
{    
    $libraryDir = Join-Path $scriptDirectory "lib"
    $devShellModuleName = "Microsoft.Utility.DevShell"
    $devShellModuleVersion = "1.0.0.6"
    $devShellModuleDirectoryName = "$($devShellModuleName).$($devShellModuleVersion)"
    
    $nugetPath = Join-Path $libraryDir "nuget.exe"
    if (! (Test-Path $nugetPath))
    {
        mkdir $libraryDir -Force | Out-Null
        Write-Output "Downloading latest nuget.exe to $nugetPath"
        Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
        if (!(Test-Path $nugetPath))
        {
            throw "nuget.exe is not available at $nugetPath"
        }
    }

    $devShellPath = Join-Path $libraryDir $devShellModuleDirectoryName
    if (!(Test-Path $devShellPath))
    {
        $output = & $nugetPath install $devShellModuleName -Version $devShellModuleVersion -OutputDirectory ($libraryDir) -Source "https://msazure.pkgs.visualstudio.com/DefaultCollection/_apis/packaging/ManualMirror/nuget/index.json"

        if (!(Test-Path $devShellPath))
        {
            throw "DevShell is not available at $($devShellPath)`nNuget was supposed to install it. Check out of command 'nuget install $devShellModuleName -Version $devShellModuleVersion' below:`n`n$output"
        }
        else
        {
            Write-Output "DevShell has been successfully downloaded to $($devShellPath)"

            $env:DevShellPath = $devShellPath
            $envVar = "DevShellPath"
            [environment]::SetEnvironmentVariable($envVar, $devShellPath, "MACHINE") | Out-Null
            Write-Output "Environment variable $($envVar) has been setup appropriately"
            
            Write-Warning "You might need to restart you command shell..."
        }
    }
}

function Generate-StorageSyncSDK
{
    <#  
    .SYNOPSIS 
    Generates new SDK source code based on input swagger
    .PARAMETER NewSDKVersion
    Specify the new SDK version
    .PARAMETER UpdateDevSDK
    Specify that Dev SDK source code should be updated
    .PARAMETER UpdateIntSDK
    Specify that INT SDK source code should be updated
    .PARAMETER SpecsRepoBranch
    Specify the branch in the azure-rest-api-specs repo to use as the source for swagger.  If not specified, it will default to the master branch
    .PARAMETER LocalConfigFilePath
    Specify the local path to use as the source for swagger.
    #>        
    param(
        [Parameter(Mandatory = $true)]
        [string]$NewSDKVersion,
        [Parameter(Mandatory = $false)]
        [switch]$UpdateDevSDK,
        [Parameter(Mandatory = $false)]
        [switch]$UpdateIntSDK,
        [Parameter(ParameterSetName="GenerateFromRemoteBranch", Mandatory = $false)]
        [string]$SpecsRepoBranch,
        [Parameter(ParameterSetName="GenerateFromLocalFile", Mandatory = $true)]
        [string]$LocalConfigFilePath
    )

    $resourceProvider = "storagesync/resource-manager"
    $autoRestVersion = "latest"
    
    if ($PSCmdlet.ParameterSetName -eq "GenerateFromLocalFile")
    {
        Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider $resourceProvider -AutoRestVersion $autoRestVersion -LocalConfigFilePath "D:\github\azure-rest-api-specs\specification\storagesync\resource-manager\readme.md" -Verbose
    }
    elseif ($PSCmdlet.ParameterSetName -eq "GenerateFromRemoteBranch")
    {
        if ($SpecsRepoBranch)
        {
            Start-AutoRestCodeGeneration -ResourceProvider $resourceProvider -AutoRestVersion $autoRestVersion -SpecsRepoBranch $SpecsRepoBranch -Verbose
        }
        else
        {
            Start-AutoRestCodeGeneration -ResourceProvider $resourceProvider -AutoRestVersion $autoRestVersion -Verbose
        }
    }
    
    # Update the version
    $repoPath = git rev-parse --show-toplevel
    $projectPath = "$repoPath\src\SDKs\StorageSync\Management.StorageSync\Microsoft.Azure.Management.StorageSync.csproj"
    Update-FileContents -FileName $projectPath -RegExp "<Version>.*</Version>" -Replacement "<Version>$NewSDKVersion</Version>" | Out-Null
    
    if ($UpdateDevSDK)
    {
        $generatedPath = "$repoPath\src\SDKs\StorageSync\Management.StorageSync\Generated"
        $devPath = "$repoPath\src\SDKs\StorageSync\Dev"
        $devGeneratedPath = "$devPath\Management.StorageSync\Generated"
    
        # Copy contents of Generated folder to Dev
        if (Test-Path $devGeneratedPath)
        {
            Remove-Item $devGeneratedPath -Recurse
        }
    
        Copy-Item $generatedPath -Recurse -Destination $devGeneratedPath
    
        Get-ChildItem -Path $devGeneratedPath -Include "*.cs", "*.csproj" -Recurse | ForEach-Object {
            Update-FileContents -FileName $_.FullName -RegExp "Microsoft\.StorageSync" -Replacement 'Microsoft.StorageSyncDev' | Out-Null
        }
    
        # Update the version
        Update-FileContents -FileName "$devPath\Management.StorageSync\Microsoft.Azure.Management.StorageSyncDev.csproj" -RegExp "<Version>.*</Version>" -Replacement "<Version>$NewSDKVersion</Version>" | Out-Null
    }
    
    if ($UpdateIntSDK)
    {
        $generatedPath = "$repoPath\src\SDKs\StorageSync\Management.StorageSync\Generated"
        $intPath = "$repoPath\src\SDKs\StorageSync\INT"
        $intGeneratedPath = "$intPath\Management.StorageSync\Generated"
    
        if (Test-Path $intGeneratedPath)
        {
            Remove-Item $intGeneratedPath -Recurse
        }
    
        Copy-Item $generatedPath -Recurse -Destination $intGeneratedPath
    
        Get-ChildItem -Path $intGeneratedPath -Include "*.cs", "*.csproj" -Recurse | ForEach-Object {
            Update-FileContents -FileName $_.FullName -RegExp "Microsoft\.StorageSync" -Replacement 'Microsoft.StorageSyncInt' | Out-Null
        }
    
        Update-FileContents -FileName "$intPath\Management.StorageSync\Microsoft.Azure.Management.StorageSyncInt.csproj" -RegExp "<Version>.*</Version>" -Replacement "<Version>$NewSDKVersion</Version>" | Out-Null
    }    
}

if ($null -ne $env:DevShellPath -and (Test-Path $env:DevShellPath))
{
    Import-Module (Join-Path $env:DevShellPath "DevShellCommon.psm1") -NoClobber -DisableNameChecking
    Import-Module (Find-DevShellModule "KailaniPSUtilities.psm1") -NoClobber -DisableNameChecking
    Import-Module (Find-DevShellModule "KeyVault.psm1") -NoClobber -DisableNameChecking
}
else
{
    Write-Warning "Running without DevShell - functionality is limited."
    Write-Warning "You probably want to run Setup-DevShell and restart your shell..."
}

function Rebuild-StorageSyncSDK 
{
    param(
        [switch]$SkipTests,
        [switch]$ShowOutput
    )
    $SkipTestsProperty = if ($SkipTests) { "/p:SkipTests=true" } else { "" }
    
    $cmdline = "msbuild build.proj /t:CreateNugetPackage /p:Scope=SDKs\StorageSync $SkipTestsProperty"

    if ($ShowOutput)
    {
        & cmd.exe /c $cmdline '2>&1' | Trace-Output "Rebuild"
    }
    else
    {
        & cmd.exe /c $cmdline '2>&1' | Out-Null
    }

    if (! $?)
    {
        "Build process exit code: $lastExitCode" | Trace-Output "Rebuild"
        return $False
    }

    return $True
}

function Setup-Environment
{
    & Sn -Vr *,31bf3856ad364e35
}

function Setup-Secrets
{
    param (
        [Parameter(Mandatory = $True)]
        $SecretForInt,

        [Parameter(Mandatory = $True)]
        $SecretForDev,

        [Parameter(Mandatory = $True)]
        $SecretForProd,

        [Parameter(Mandatory = $True)]
        $UserLoginForProd,

        [Parameter(Mandatory = $True)]
        $UserPasswordForProd
    )

    Trace-Start

    foreach ($secretString in @($SecretForInt, $SecretForDev, $SecretForProd))
    {
        $validationMap = @{
            "SubscriptionId" = 0;
            "ServicePrincipal" = 0;
            "ServicePrincipalSecret" = 0;
            "AADTenant" = 0;
            "Environment" = 0;
        }
        $keys = $secretString -split ";" | %{ ($_ -split "=")[0] }
        foreach ($key in $keys)
        {
            if (!$key) { continue; }
            Trace-AssertCondition ($validationMap.ContainsKey($key)) "Unexpected secret attribute: $key"
            $validationMap[$key] += 1
        }

        foreach ($expectedKey in $validationMap.Keys)
        {
            $actual = $validationMap[$expectedKey]
            Trace-AssertCondition ($actual -eq 1) "Attribute $expectedKey was supposed to be specified exactly once, actual = $actual"
        }
    }

    Trace-AssertCondition ($null -ne $UserLoginForProd) "User login is not provided"
    Trace-AssertCondition ($null -ne $UserPasswordForProd) "User password is not provided"

    Set-KeyVaultTestSecret -Name "SdkTestIntAuthenticationString" -Value $SecretForInt
    Set-KeyVaultTestSecret -Name "SdkTestDevAuthenticationString" -Value $SecretForDev
    Set-KeyVaultTestSecret -Name "SdkTestProdAuthenticationString" -Value $SecretForProd

    Set-KeyVaultTestSecret -Name "SdkTestProdUserLoginString" -Value $UserLoginForProd
    Set-KeyVaultTestSecret -Name "SdkTestProdUserPasswordString" -Value $UserPasswordForProd

    Trace-Exit | Out-Null
}

function Get-TestUserCredential
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode)

    Trace-Start

    Trace-Argument -Name Mode -Value $Mode

    $cred = $null

    switch ($Mode)
    {
        "Prod" 
        {
            $username = Get-KeyVaultTestSecret -Name "SdkTestProdUserLoginString"
            $passwordSecureString = Get-KeyVaultTestSecret -Name "SdkTestProdUserPasswordString" | ConvertTo-SecureString -asPlainText -Force            
            $cred = New-Object System.Management.Automation.PSCredential($username, $passwordSecureString)
            break
        }
        default { throw "Unsupported mode: $Mode"}
    }    
    Trace-Exit | Out-Null
    return $cred
}

function Get-TestAuthenticationString
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode,
        [Parameter(Mandatory = $True)]
        [ValidateSet('Record','Playback')]
        $TestMode)

    Trace-Start

    Trace-Argument -Name Mode -Value $Mode
    Trace-Argument -Name TestMode -Value $TestMode

    switch ($Mode)
    {
        "Int" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestIntAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);"
        }
        "Dev" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestDevAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);"
        }
        "Prod" 
        {
            $secret = Get-KeyVaultTestSecret -Name "SdkTestProdAuthenticationString"
            return "$($secret);HttpRecorderMode=$($TestMode);OptimizeRecordedFile=false;"
        }
        default { throw "Unsupported mode: $Mode"}
    }    
    Trace-Exit | Out-Null
}

function Record-UnitTests
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode)

    Trace-Start
    Trace-Argument -Name Mode -Value $Mode
    $solutionPath = Join-Path $scriptDirectory "..\Microsoft.Azure.Management.StorageSync.sln"
    Trace-AssertCondition (Test-Path $solutionPath) "Cannot access path: $solutionPath"

    $authString = Get-TestAuthenticationString -Mode $Mode -TestMode Record
    [environment]::SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $authString) | Out-Null
    [environment]::SetEnvironmentVariable("AZURE_TEST_MODE", "Record") | Out-Null

    start $solutionPath
    Trace-Exit | Out-Null
}

function Replay-UnitTests
{
    param(
        [Parameter(Mandatory = $True)]
        [ValidateSet('Int','Dev','Prod')]
        $Mode)

    Trace-Start
    Trace-Argument -Name Mode -Value $Mode
    $solutionPath = Join-Path $scriptDirectory "..\Microsoft.Azure.Management.StorageSync.sln"
    Trace-AssertCondition (Test-Path $solutionPath) "Cannot access path: $solutionPath"

    $authString = Get-TestAuthenticationString -Mode $Mode -TestMode Playback
    [environment]::SetEnvironmentVariable("TEST_CSM_ORGID_AUTHENTICATION", $authString) | Out-Null
    [environment]::SetEnvironmentVariable("AZURE_TEST_MODE", "Playback") | Out-Null

    start $solutionPath
    Trace-Exit | Out-Null
}

Export-ModuleMember -Function Setup-DevShell
Export-ModuleMember -Function Setup-Environment
Export-ModuleMember -Function *-StorageSyncSDK
Export-ModuleMember -Function *-UnitTests
Export-ModuleMember -Function *-Secrets
Export-ModuleMember -Function Get-TestAuthenticationString
Export-ModuleMember -Function Get-TestUserCredential