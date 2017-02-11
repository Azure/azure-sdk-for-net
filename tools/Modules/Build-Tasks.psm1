[CmdletBinding]
Function Get-BuildScopes
{
<#
.SYNOPSIS
You can build a particular package rather than doing a full build by providing Build Scope.
This cmdlet will help to identify existing Scope available
This will enable to execute Start-RepoBuild <scope>

#>

    Write-Host "Below are available scopes you can specify for building specific projects"
    Write-Host ""    
    Get-ChildItem -path "$env:repoRoot\src\ResourceManager" -dir | Format-Wide -Column 5 | Format-Table -Property Name
    Write-Host "e.g of a scope would be 'ResourceManager\Compute'" -ForegroundColor Yellow
    
    Get-ChildItem -path "$env:repoRoot\src\ServiceManagement" -dir -Exclude "ResourceManager" | Format-Wide -Column 5 | Format-Table -Property Name
    Write-Host "e.g of a scope would be 'ServiceManagement\ExpressRoute'" -ForegroundColor Yellow
}

[CmdletBinding]
Function Start-Build
{
<#
.SYNOPSIS
This cmdlet will help to do either with full build or targeted build for specific scopes.

.PARAMETER BuildScope
Use Get-BuildScope cmdLet to get list of existing scopes that can be used to build
#>
    param(
    [parameter(Mandatory=$false, Position=0, HelpMessage='BuildScope that you would like to use. For list of build scopes, run List-BuildScopes')]
    [string]$BuildScope
    )    
    
    if([string]::IsNullOrEmpty($BuildScope) -eq $true)
    {
       Write-Host "Starting Full build"
       msbuild.exe "$env:repoRoot\build.proj" /t:Build
    }
    else
    {
        Write-Host "Building $BuildScope"
        msbuild.exe "$env:repoRoot\build.proj" /t:Build /p:Scope=$BuildScope
    }
}

[CmdletBinding]
Function Invoke-CheckinTests
{
<#
.SYNOPSIS
Runs all the check in tests
#>
    Write-Host "cmdline Args: msbuild.exe $env:repoRoot\build.proj /t:Test"
    msbuild.exe "$env:repoRoot\build.proj" /t:Test
}

[cmdletBinding]
Function Install-VSProjectTemplates
{
<#
.SYNOPSIS

Install-VSProjectTemplates will install getting started project templates for
1) Autorest-.NET SDKProject
2) .NET SDK Test projectct

After executing the cmdlet, restart VS (if already open), create new project
Search for the project template as we install the following three project templates
AutoRest-AzureDotNetSDK
AzureDotNetSDK-TestProject
AzurePowerShell-TestProject
#>
    if($env:VisualStudioVersion -eq "14.0")
    {
        if((Test-Path "$env:repoRoot\tools\ProjectTemplates\") -eq $true)
        {
            Write-Host "Installing VS templates for 'AutoRest as well as Test Project'"
            Copy-Item "$env:repoRoot\tools\ProjectTemplates\*.zip" "$env:USERPROFILE\Documents\Visual Studio 2015\Templates\ProjectTemplates\"
            Write-Host "Installed VS Test Project Templates for Powershell test projects"
            Write-Host ""
            Write-Host "Restart VS (if already open), search for 'AzurePowerShell-TestProject'" -ForegroundColor Yellow
        }
        else
        {
            Write-Host "Missing templates to install, make sure you have project templates available in the repo under $env:repoRoot\tools\ProjectTemplates\"
        }
    }
    else
    {
        Write-Host "Unsupported VS Version detected. Visual Studio 2015 is the only supported version for current set of project templates"
    }
}

export-modulemember -Function Get-BuildScopes
export-modulemember -Function Start-Build
export-modulemember -Function Invoke-CheckinTests
export-modulemember -Function Install-VSProjectTemplates