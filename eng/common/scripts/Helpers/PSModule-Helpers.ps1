$DefaultPSRepositoryUrl = "https://www.powershellgallery.com/api/v2"
$global:CurrentUserModulePath = ""

function Update-PSModulePathForCI()
{
  # Information on PSModulePath taken from docs
  # https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_psmodulepath

  # Information on Az custom module paths on hosted agents taken from
  # https://github.com/microsoft/azure-pipelines-tasks/blob/c9771bc064cd60f47587c68e5c871b7cd13f0f28/Tasks/AzurePowerShellV5/Utility.ps1

  if ($IsWindows) {
    $hostedAgentModulePath = $env:SystemDrive + "\Modules"
    $moduleSeperator = ";"
  } else {
    $hostedAgentModulePath = "/usr/share"
    $moduleSeperator = ":"
  }
  $modulePaths = $env:PSModulePath -split $moduleSeperator

  # Remove any hosted agent paths (needed to remove old default azure/azurerm paths which cause conflicts)
  $modulePaths = $modulePaths.Where({ !$_.StartsWith($hostedAgentModulePath) })

  # Add any "az_" paths from the agent which is the lastest set of azure modules
  $AzModuleCachePath = (Get-ChildItem "$hostedAgentModulePath/az_*" -Attributes Directory) -join $moduleSeperator
  if ($AzModuleCachePath -and $env:PSModulePath -notcontains $AzModuleCachePath) {
    $modulePaths += $AzModuleCachePath
  }

  $env:PSModulePath = $modulePaths -join $moduleSeperator

  # Find the path that is under user home directory
  $homeDirectories = $modulePaths.Where({ $_.StartsWith($home) })
  if ($homeDirectories.Count -gt 0) {
    $global:CurrentUserModulePath = $homeDirectories[0]
    if ($homeDirectories.Count -gt 1) {
      Write-Verbose "Found more then one module path starting with $home so selecting the first one $global:CurrentUserModulePath"
    }

    # In some cases the directory might not exist so we need to create it otherwise caching an empty directory will fail
    if (!(Test-Path $global:CurrentUserModulePath)) {
      New-Item $global:CurrentUserModulePath -ItemType Directory > $null
    }
  }
  else {
    Write-Error "Did not find a module path starting with $home to set up a user module path in $env:PSModulePath"
  }
}

# Manual test at eng/common-tests/psmodule-helpers/Install-Module-Parallel.ps1
# If we want to use another default repository other then PSGallery we can update the default parameters
function Install-ModuleIfNotInstalled()
{
  [CmdletBinding(SupportsShouldProcess = $true)]
  param(
    [string]$moduleName,
    [string]$version,
    [string]$repositoryUrl
  )

  # List of modules+versions we want to replace with internal feed sources for reliability, security, etc.
  $packageFeedOverrides = @{
    'powershell-yaml' = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-tools/nuget/v2'
  }

  try {
    $mutex = New-Object System.Threading.Mutex($false, "Install-ModuleIfNotInstalled")
    $null = $mutex.WaitOne()

    # Check installed modules again after acquiring lock
    $modules = (Get-Module -ListAvailable $moduleName)
    if ($version -as [Version]) {
      $modules = $modules.Where({ [Version]$_.Version -ge [Version]$version })
    }

    if ($modules.Count -gt 0)
    {
      Write-Host "Using module $($modules[0].Name) with version $($modules[0].Version)."
      return $modules[0]
    }

    $repositoryUrl = if ($repositoryUrl) {
      $repositoryUrl
    } elseif ($mirrorFeedOverrides.Contains("${moduleName}")) {
      $mirrorFeedOverrides["${moduleName}"]
    } else {
      $DefaultPSRepositoryUrl
    }

    $repositories = (Get-PSRepository).Where({ $_.SourceLocation -eq $repositoryUrl })
    if ($repositories.Count -eq 0)
    {
      Register-PSRepository -Name $repositoryUrl -SourceLocation $repositoryUrl -InstallationPolicy Trusted
      $repositories = (Get-PSRepository).Where({ $_.SourceLocation -eq $repositoryUrl })
      if ($repositories.Count -eq 0) {
        Write-Error "Failed to register package repository $repositoryUrl."
        return
      }
    }
    $repository = $repositories[0]

    if ($repository.InstallationPolicy -ne "Trusted") {
      Set-PSRepository -Name $repository.Name -InstallationPolicy "Trusted"
    }

    Write-Host "Installing module $moduleName with min version $version from $repositoryUrl"
    # Install under CurrentUser scope so that the end up under $CurrentUserModulePath for caching
    Install-Module $moduleName -MinimumVersion $version -Repository $repository.Name -Scope CurrentUser -Force

    # Ensure module installed
    $modules = (Get-Module -ListAvailable $moduleName)
    if ($version -as [Version]) {
      $modules = $modules.Where({ [Version]$_.Version -ge [Version]$version })
    }

    if ($modules.Count -eq 0) {
      Write-Error "Failed to install module $moduleName with version $version"
      return
    }

    Write-Host "Using module $($modules[0].Name) with version $($modules[0].Version)."
  } finally {
    $mutex.ReleaseMutex()
  }

  return $modules[0]
}

if ($null -ne $env:SYSTEM_TEAMPROJECTID) {
    Update-PSModulePathForCI
}
