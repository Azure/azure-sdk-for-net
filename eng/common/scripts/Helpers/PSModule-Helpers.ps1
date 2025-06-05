$global:CurrentUserModulePath = ""

function Update-PSModulePathForCI() {
  # Information on PSModulePath taken from docs
  # https://docs.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_psmodulepath

  # Information on Az custom module paths on hosted agents taken from
  # https://github.com/microsoft/azure-pipelines-tasks/blob/c9771bc064cd60f47587c68e5c871b7cd13f0f28/Tasks/AzurePowerShellV5/Utility.ps1

  if ($IsWindows) {
    $hostedAgentModulePath = $env:SystemDrive + "\Modules"
    $moduleSeperator = ";"
  }
  else {
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

function Get-ModuleRepositories([string]$moduleName) {
  $DefaultPSRepositoryUrl = "https://www.powershellgallery.com/api/v2"
  # List of modules+versions we want to replace with internal feed sources for reliability, security, etc.
  $packageFeedOverrides = @{
    'powershell-yaml' = 'https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-tools/nuget/v2'
  }

  $repoUrls = if ($packageFeedOverrides.Contains("${moduleName}")) {
    @($packageFeedOverrides["${moduleName}"], $DefaultPSRepositoryUrl)
  }
  else {
    @($DefaultPSRepositoryUrl)
  }

  return $repoUrls
}

function moduleIsInstalled([string]$moduleName, [string]$version) {
  if (-not (Test-Path variable:script:InstalledModules)) {
    $script:InstalledModules = @{}
  }

  if ($script:InstalledModules.ContainsKey("${moduleName}")) {
    $modules = $script:InstalledModules["${moduleName}"]
  }
  else {
    $modules = (Get-Module -ListAvailable $moduleName)
    $script:InstalledModules["${moduleName}"] = $modules
  }

  if ($version -as [Version]) {
    $modules = $modules.Where({ [Version]$_.Version -ge [Version]$version })
    if ($modules.Count -gt 0) {
      Write-Verbose "Using module $($modules[0].Name) with version $($modules[0].Version)."
      return $modules[0]
    }
  }
  return $null
}

function installModule([string]$moduleName, [string]$version, $repoUrl) {
  $repo = (Get-PSRepository).Where({ $_.SourceLocation -eq $repoUrl })
  if ($repo.Count -eq 0) {
    Register-PSRepository -Name $repoUrl -SourceLocation $repoUrl -InstallationPolicy Trusted | Out-Null
    $repo = (Get-PSRepository).Where({ $_.SourceLocation -eq $repoUrl })
    if ($repo.Count -eq 0) {
      throw "Failed to register package repository $repoUrl."
    }
  }

  if ($repo.InstallationPolicy -ne "Trusted") {
    Set-PSRepository -Name $repo.Name -InstallationPolicy "Trusted" | Out-Null
  }

  Write-Verbose "Installing module $moduleName with min version $version from $repoUrl"
  # Install under CurrentUser scope so that the end up under $CurrentUserModulePath for caching
  Install-Module $moduleName -MinimumVersion $version -Repository $repo.Name -Scope CurrentUser -Force -WhatIf:$false
  # Ensure module installed
  $modules = (Get-Module -ListAvailable $moduleName)
  if ($version -as [Version]) {
    $modules = $modules.Where({ [Version]$_.Version -ge [Version]$version })
  }
  if ($modules.Count -eq 0) {
    throw "Failed to install module $moduleName with version $version"
  }

  $script:InstalledModules["${moduleName}"] = $modules

  # Unregister repository as it can cause overlap issues with `dotnet tool install`
  # commands using the same devops feed
  Unregister-PSRepository -Name $repoUrl | Out-Null

  return $modules[0]
}

function InstallAndImport-ModuleIfNotInstalled([string]$module, [string]$version) {
  if ($null -eq (moduleIsInstalled $module $version)) {
    Install-ModuleIfNotInstalled -WhatIf:$false $module $version | Import-Module
  } elseif (!(Get-Module -Name $module)) {
    Import-Module $module
  }
}

# Manual test at eng/common-tests/psmodule-helpers/Install-Module-Parallel.ps1
# If we want to use another default repository other then PSGallery we can update the default parameters
function Install-ModuleIfNotInstalled() {
  [CmdletBinding(SupportsShouldProcess = $true)]
  param(
    [string]$moduleName,
    [string]$version,
    [string]$repositoryUrl
  )

  # Check installed modules before after acquiring lock to avoid a big queue
  $module = moduleIsInstalled -moduleName $moduleName -version $version
  if ($module) { return $module }

  try {
    $mutex = New-Object System.Threading.Mutex($false, "Install-ModuleIfNotInstalled")
    $null = $mutex.WaitOne()

    # Check installed modules again after acquiring lock, in case it has been installed
    $module = moduleIsInstalled -moduleName $moduleName -version $version
    if ($module) { return $module }

    $repoUrls = Get-ModuleRepositories $moduleName

    foreach ($url in $repoUrls) {
      try {
        $module = installModule -moduleName $moduleName -version $version -repoUrl $url
      }
      catch {
        if ($url -ne $repoUrls[-1]) {
          Write-Warning "Failed to install powershell module from '$url'. Retrying with fallback repository"
          Write-Warning $_
          continue
        }
        else {
          Write-Warning "Failed to install powershell module from $url"
          throw
        }
      }
      break
    }

    Write-Verbose "Using module '$($module.Name)' with version '$($module.Version)'."
  }
  finally {
    $mutex.ReleaseMutex()
  }

  return $module
}

if ($null -ne $env:SYSTEM_TEAMPROJECTID) {
  Update-PSModulePathForCI
}
