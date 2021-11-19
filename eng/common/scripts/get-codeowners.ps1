param (
  [string]$TargetDirectory, # Code path to code owners. e.g sdk/core/azure-amqp
  [string]$RootDirectory = "$env:SYSTEM_DEFAULTWORKINGDIRECTORY", # The repo contains CODEOWNER file.
  [string]$CodeOwnerFileLocation = "$PSSCriptRoot/../../../.github/CODEOWNERS", # The absolute path of CODEOWNERS file. 
  [string]$ToolVersion = "1.0.0-dev.20211118.20", # Placeholder. Will update in next PR
  [string]$ToolPath = "$env:AGENT_TOOLSDIRECTORY", # The place to check the tool existence. Put $(Agent.ToolsDirectory) as default
  [string]$DevOpsFeed = "https://pkgs.dev.azure.com/azure-sdk/public/_packaging/azure-sdk-for-net/nuget/v3/index.json", # DevOp tool feeds.
  [string]$VsoVariable = "", # Option of write code owners into devop variable
  [switch]$Test  #Run test functions against the script logic
)

$ToolCommandName = "retrieve-codeowners"

function Get-CodeOwnersTool()
{
  # Check if the retrieve-codeowners tool exsits or not.
  if (Get-Command "$ToolPath/$ToolCommandName" -errorAction SilentlyContinue) {
    return "$ToolPath/$ToolCommandName"
  }
  if (!$ToolPath -or !(Test-Path $ToolPath)) {
    $ToolPath  = (Join-Path ([System.IO.Path]::GetTempPath()) ([System.IO.Path]::GetRandomFileName()))
    New-Item -ItemType Directory -Path $newPath | Out-Null
  }
  Write-Warning "Installing the ToolCommandName tool under $ToolPath... "
  dotnet tool install --tool-path $ToolPath --add-source $DevOpsFeed --version $ToolVersion "Azure.Sdk.Tools.RetrieveCodeOwners" | Out-Null

  # Test to see if the tool properly installed.
  if (!(Get-Command $Command -errorAction SilentlyContinue)) {
    Write-Error "The ToolCommandName tool is not properly installed. Please check your tool path. $ToolPath"
    return 
  }
  return Join-Path $ToolPath $ToolCommandName
}

function Get-CodeOwners ([string] $command)
{
  if (!$command) {
    return @()
  }
  # Params $RootDirectory is already in use in cpp release pipeline. 
  # Will use $CodeOwnerFileLocation and deprecate $RootDirectory once it is ready to retire $RootDirectory.
  if ($RootDirectory -and !(Test-Path $CodeOwnerFileLocation)) {
    $CodeOwnerFileLocation = Join-Path $RootDirectory ".github/CODEOWNERS"
  }
  
  $codeOwnersString = & $command --target-directory $targetDirectory --code-owner-file-path $CodeOwnerFileLocation
  # Failed at the command of fetching code owners.
  if ($LASTEXITCODE -ne 0) {
    return @()
  }
  
  $codeOwnersJson = $codeOwnersString | ConvertFrom-Json
  if (!$codeOwnersJson) {
    Write-Host "No code owners returned from the path: $targetDirectory"
    return @()
  }
  
  if ($VsoVariable) {
    $codeOwners = $codeOwnersJson.Owners -join ","
    Write-Host "##vso[task.setvariable variable=$VsoVariable;]$codeOwners"
  }

  return $codeOwnersJson.Owners
}


function TestGetCodeOwner([string] $command) {
  if (!$command) {
    exit
  }
  $actualReturn = GetCodeOwners -command $command 
  $expectReturn = @("person1", "person2")
  for ($i = 0; $i -lt $expectReturn.Length; $i++) {
    if ($actualReturn[$i] -ne $expectReturn[$i]) {
      Write-Error "Expect result $expectReturn[$i] is different than actual result $actualReturn[$i]."
      exit
    }
  }
}

# Install the tool first
$output = Get-CodeOwnersTool

if($Test) {
  TestGetCodeOwner -command $output
}
else {

  return GetCodeOwners -command $output
}
