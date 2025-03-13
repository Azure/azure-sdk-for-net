  # Download and Extract or restore Packages required for Doc Generation
  Write-Host "Download and Extract mdoc to Build.BinariesDirectory/mdoc"
  try {
    # Currently having issues downloading from github on windows 2022 so moved to a blob account
    # https://github.com/mono/api-doc-tools/releases/download/mdoc-5.7.4.9/mdoc-5.7.4.9.zip
    Invoke-WebRequest -MaximumRetryCount 10 -Uri "https://azuresdkartifacts.z5.web.core.windows.net/tools/mdoc/5.7.4.9/mdoc-5.7.4.9.zip" `
      -OutFile "mdoc.zip" | Wait-Process; Expand-Archive -Path "mdoc.zip" -DestinationPath "./mdoc/"
  } catch {
    $_.Exception | Format-List | Out-Host
    throw
  }

  Write-Host "Download and Extract docfx to Build.BinariesDirectory/docfx"
  try {
    # Currently having issues downloading from github on windows 2022 so moved to a blob account
    # https://github.com/dotnet/docfx/releases/download/$(DocFxVersion)/docfx.zip
    Invoke-WebRequest -MaximumRetryCount 10 -Uri "https://azuresdkartifacts.z5.web.core.windows.net/tools/docfx/$($env:DOCFXVERSION)/docfx.zip" `
    -OutFile "docfx.zip" | Wait-Process; Expand-Archive -Path "docfx.zip" -DestinationPath "./docfx/"
  } catch {
    $_.Exception | Format-List | Out-Host
    throw
  }

  Write-Host "Restore $($env:DOC_GENERATION_DIR)/assets/docgen.csproj, to get ECMA2Yml and popimport"
  dotnet restore "$($env:DOC_GENERATION_DIR)/assets/docgen.csproj" /p:BuildBinariesDirectory=$($env:BUILD_BINARIESDIRECTORY)
