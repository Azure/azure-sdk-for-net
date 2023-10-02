
function create-service-readme(
  $readmeFolder,
  $readmeName,
  $moniker,
  $msService,
  $indexTableLink,
  $serviceName
) {

  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $content = ""
  if (Test-Path (Join-Path $readmeFolder -ChildPath $indexTableLink)) {
    $content = "## Packages - $moniker`r`n"
    $content += "[!INCLUDE [packages]($indexTableLink)]"
  }
  if (!$content) {
    LogError "There are no packages under service '$serviceName'. "
    return
  }
  # Generate the front-matter for docs needs
  # $Language, $LanguageDisplayName are the variables globally defined in Language-Settings.ps1
  $metadataString = GenerateDocsMsMetadata `
    -language $Language `
    -languageDisplayName $LanguageDisplayName `
    -serviceName $serviceName `
    -msService $msService

  Add-Content -Path $readmePath -Value $metadataString -NoNewline

  # Add tables, conbined client and mgmt together.
  $readmeHeader = "# Azure $serviceName SDK for $languageDisplayName - $moniker`r`n"
  Set-Content -Path $readmePath -Value "$metadataString$readmeHeader$content" -NoNewline
}

# Update the metadata table.
function update-metadata-table($readmeFolder, $readmeName, $serviceName, $msService, $author, $msAuthor)
{
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  $readmeContent = Get-Content -Path $readmePath -Raw
  $match = $readmeContent -match "^---\n*(?<metadata>(.*\n?)*?)---\n*(?<content>(.*\n?)*)"
  $restContent = $readmeContent
  $metadata = ""
  if ($match) {
    $restContent = $Matches["content"].trim()
    $metadata = $Matches["metadata"].trim()
  }

  # $Language, $LanguageDisplayName are the variables globally defined in Language-Settings.ps1
  $metadataString = GenerateDocsMsMetadata `
    -originalMetadata $metadata `
    -language $Language `
    -languageDisplayName $LanguageDisplayName `
    -serviceName $serviceName `
    -msService $msService

  Set-Content -Path $readmePath -Value "$metadataString$restContent" -NoNewline
}

function generate-markdown-table($readmeFolder, $readmeName, $packageInfos, $moniker) {
  $tableHeader = "| Reference | Package | Source |`r`n|---|---|---|`r`n"
  $tableContent = ""
  $packageInfos = $packageInfos | Sort-Object -Property Type,Package
  # Here is the table, the versioned value will
  foreach ($pkg in $packageInfos) {
    $repositoryLink = "$PackageRepositoryUri/$($pkg.Package)"
    if (Test-Path "Function:$GetRepositoryLinkFn") {
      $repositoryLink = &$GetRepositoryLinkFn -packageInfo $pkg
    }
    $packageLevelReadme = ""
    if (Test-Path "Function:$GetPackageLevelReadmeFn") {
      $packageLevelReadme = &$GetPackageLevelReadmeFn -packageMetadata $pkg
    }

    $referenceLink = "[$($pkg.DisplayName)]($packageLevelReadme-readme.md)"
    if (!(Test-Path (Join-Path $readmeFolder -ChildPath "$packageLevelReadme-readme.md"))) {
      $referenceLink = $pkg.DisplayName
    }
    $githubLink = $GithubUri
    if ($pkg.PSObject.Members.Name -contains "DirectoryPath") {
      $githubLink = "$GithubUri/blob/main/$($pkg.DirectoryPath)"
    }
    $line = "|$referenceLink|[$($pkg.Package)]($repositoryLink)|[GitHub]($githubLink)|`r`n"
    $tableContent += $line
  }
  $readmePath = Join-Path $readmeFolder -ChildPath $readmeName
  if($tableContent) {
    Set-Content -Path $readmePath -Value "$tableHeader$tableContent" -NoNewline -Force
  }
}

function generate-service-level-readme(
  $docRepoLocation,
  $readmeBaseName,
  $pathPrefix,
  $packageInfos,
  $serviceName,
  $moniker,
  $msService
) {
  $readmeFolder = "$docRepoLocation/$pathPrefix/$moniker/"
  $serviceReadme = "$readmeBaseName.md"
  $indexReadme  = "$readmeBaseName-index.md"
 
  if ($packageInfos) {
    generate-markdown-table `
      -readmeFolder $readmeFolder `
      -readmeName $indexReadme `
      -packageInfos $packageInfos `
      -moniker $moniker  
  }
  
  if (!(Test-Path "$readmeFolder$serviceReadme") -and $packageInfos) {
    create-service-readme `
      -readmeFolder $readmeFolder `
      -readmeName $serviceReadme `
      -moniker $moniker `
      -msService $msService `
      -indexTableLink $indexReadme `
      -serviceName $serviceName

  } elseif (Test-Path "$readmeFolder$serviceReadme") {
    update-metadata-table `
      -readmeFolder $readmeFolder `
      -readmeName $serviceReadme `
      -serviceName $serviceName `
      -msService $msService
  }
}