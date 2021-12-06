function Generate-Readme() {
  param(
      [string]$resourceProvider = "",
      [string]$packageName = "",
      [string]$sdkPath = ""
  )

  $projectFolder=$sdkPath/sdk/$packageName/Azure.ResourceManager.*
  if (Test-Path -Path $projectFolder) {
    Write-Host "Path exists!"
  } else {
    Write-Host "Path doesn't exist. create template."
    dotnet new -i $sdkPath/eng/templates/Azure.ResourceManager.Template
    $projectFolder=$sdkPath/sdk/$packageName/Azure.ResourceManager.$packageName
    Write-Host "Create project folder $projectFolder"
    New-Item -Path $projectFolder -ItemType Directory
    cd $projectFolder
    dotnet new azuremgmt --provider $packageName --includeCI true --force

    # update the readme url
    Write-Host "Updating autorest.md file."
    
  }

  function Generate() {
      param(
          [string]$swaggerPath = ""
          [string]$sdkfolder= ""
      )
      cd $sdkfolder/src
      dotnet build /t:GenerateCode
  }

  Generate-Readme resourceProvider=$resourceProvider packageName=$packageName sdkPath=$sdkPath
  Generate sdkfolder=$sdkPath/sdk/$packageName/Azure.ResourceManager.$packageName
}