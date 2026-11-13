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
  # URL-based lookup can reuse a feed registered under another name. Its URL is not
  # a safe cleanup name unless this invocation created that registration.
  $registeredRepositoryName = $null
  try {
    $repo = (Get-PSRepository).Where({ $_.SourceLocation -eq $repoUrl })
    if ($repo.Count -eq 0) {
      Register-PSRepository -Name $repoUrl -SourceLocation $repoUrl -InstallationPolicy Trusted -ErrorAction Stop | Out-Null
      $registeredRepositoryName = $repoUrl
      $repo = (Get-PSRepository).Where({ $_.SourceLocation -eq $repoUrl })
      if ($repo.Count -eq 0) {
        throw "Failed to register package repository $repoUrl."
      }
    }

    Write-Verbose "Installing module $moduleName with version $version from $repoUrl"
    # CurrentUser keeps modules in the CI cache path. -Force avoids trust prompts
    # without changing the policy of a pre-existing repository registration.
    Install-Module $moduleName -RequiredVersion $version -Repository $repo.Name -Scope CurrentUser -Force -WhatIf:$false -ErrorAction Stop
    # Ensure module installed
    $modules = (Get-Module -ListAvailable $moduleName)
    if ($version -as [Version]) {
      $modules = $modules.Where({ [Version]$_.Version -eq [Version]$version })
    }
    if ($modules.Count -eq 0) {
      throw "Failed to install module $moduleName with version $version"
    }

    $script:InstalledModules["${moduleName}"] = $modules
    return $modules[0]
  }
  finally {
    # Temporary registrations can interfere with dotnet tool install on the same feed.
    # Clean them up even on failure, but leave pre-existing registrations untouched.
    if ($registeredRepositoryName) {
      Unregister-PSRepository -Name $registeredRepositoryName -ErrorAction Stop | Out-Null
    }
  }
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

    # The first check can cache a miss while another process installs the module.
    # Invalidate that entry so the mutex-protected recheck reads fresh inventory.
    $script:InstalledModules.Remove($moduleName)
    $module = moduleIsInstalled -moduleName $moduleName -version $version
    if ($module) { return $module }

    # Use internal Azure Artifacts feed only.
    $repoUrl = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-tools/nuget/v2"
    Write-Host "Module '$moduleName' with version '$version' is not installed. Attempting to install from $repoUrl."

    $module = installModule -moduleName $moduleName -version $version -repoUrl $repoUrl
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
