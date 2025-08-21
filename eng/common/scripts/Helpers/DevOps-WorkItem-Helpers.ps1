
$ReleaseDevOpsOrgParameters =  @("--organization", "https://dev.azure.com/azure-sdk")
$ReleaseDevOpsCommonParameters =  $ReleaseDevOpsOrgParameters + @("--output", "json")
$ReleaseDevOpsCommonParametersWithProject = $ReleaseDevOpsCommonParameters + @("--project", "Release")

function Get-DevOpsRestHeaders()
{
  # Get a temp access token from the logged in az cli user for azure devops resource
  $headerAccessToken = (az account get-access-token --resource "499b84ac-1321-427f-aa17-267ca6975798" --query "accessToken" --output tsv)

  if ([System.String]::IsNullOrEmpty($headerAccessToken)) {
    throw "Unable to create the DevOpsRestHeader due to access token being null or empty. The caller needs to be logged in with az login to an account with enough permissions to edit work items in the azure-sdk Release team project."
  }

  $headers = @{ Authorization = "Bearer $headerAccessToken" }

  return $headers
}

function CheckDevOpsAccess()
{
  # Dummy test query to validate permissions
  $query = "SELECT [System.ID] FROM WorkItems WHERE [Work Item Type] = 'Package' AND [Package] = 'azure-sdk-template'"

  $response = Invoke-RestMethod -Method POST `
    -Uri "https://dev.azure.com/azure-sdk/Release/_apis/wit/wiql/?api-version=6.0" `
    -Headers (Get-DevOpsRestHeaders) -Body "{ ""query"": ""$query"" }" -ContentType "application/json" | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashTable

  if ($response -isnot [HashTable] -or !$response.ContainsKey("workItems")) {
    throw "Failed to run test query against Azure DevOps. Please ensure you are logged into the public azure cloud. Consider running 'az logout' and then 'az login'."
  }
}

function Invoke-AzBoardsCmd($subCmd, $parameters, $output = $true)
{
  $azCmdStr = "az boards ${subCmd} $($parameters -join ' ')"
  if ($output) {
    Write-Host $azCmdStr
  }
  return Invoke-Expression "$azCmdStr" | ConvertFrom-Json -AsHashTable
}

function Invoke-Query($fields, $wiql, $output = $true)
{
  #POST https://dev.azure.com/{organization}/{project}/{team}/_apis/wit/wiql?timePrecision={timePrecision}&$top={$top}&api-version=6.1-preview.2

  $body = @"
{
  "query": "$wiql"
}
"@

  if ($output) {
    Write-Host "Executing query $wiql"
  }

  $response = Invoke-RestMethod -Method POST `
    -Uri "https://dev.azure.com/azure-sdk/Release/_apis/wit/wiql/?`$top=100000&api-version=6.0" `
    -Headers (Get-DevOpsRestHeaders) -Body $body -ContentType "application/json" | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashTable

  if ($response -isnot [HashTable] -or !$response.ContainsKey("workItems") -or $response.workItems.Count -eq 0) {
    Write-Verbose "Query returned no items. $wiql"
    return ,@()
  }

  $workItems = @()
  $i = 0
  do
  {
    $idBatch = @()
    while ($idBatch.Count -lt 200 -and $i -lt $response.workItems.Count)
    {
      $idBatch += $response.workItems[$i].id
      $i++
    }

    $uri = "https://dev.azure.com/azure-sdk/Release/_apis/wit/workitems?ids=$($idBatch -join ',')&fields=$($fields -join ',')&api-version=6.0"

    Write-Verbose "Pulling work items $uri "

    $batchResponse = Invoke-RestMethod -Method GET -Uri $uri `
      -Headers (Get-DevOpsRestHeaders) -ContentType "application/json" -MaximumRetryCount 3 | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashTable

      if ($batchResponse.value)
      {
        $batchResponse.value | ForEach-Object { $workItems += $_ }
      }
      else
      {
        Write-Warning "Batch return no items from $uri"
      }
  }
  while ($i -lt $response.workItems.Count)

  if ($output) {
    Write-Host "Query return $($workItems.Count) items"
  }

  return $workItems
}

function BuildHashKeyNoNull()
{
  $filterNulls = $args | Where-Object { $_ }
  # if we had any nulls then return null
  if (!$filterNulls -or $args.Count -ne $filterNulls.Count) {
    return $null
  }
  return BuildHashKey $args
}

function BuildHashKey()
{
  # if no args or the first arg is null return null
  if ($args.Count -lt 1 -or !$args[0]) {
    return $null
  }

  # exclude null values
  $keys = $args | Where-Object { $_ }
  return $keys -join "|"
}

$parentWorkItems = @{}
function FindParentWorkItem($serviceName, $packageDisplayName, $outputCommand = $false, $ignoreReleasePlannerTests = $true, $tag = $null)
{
  $key = BuildHashKey $serviceName $packageDisplayName
  if ($key -and $parentWorkItems.ContainsKey($key)) {
    return $parentWorkItems[$key]
  }

  if ($serviceName) {
    $serviceCondition = "[ServiceName] = '${serviceName}'"
    if ($packageDisplayName) {
      $serviceCondition += " AND [PackageDisplayName] = '${packageDisplayName}'"
    }
    else {
      $serviceCondition += " AND [PackageDisplayName] = ''"
    }
  }
  else {
    $serviceCondition = "[ServiceName] <> ''"
  }
  if ($tag) {
    $serviceCondition += " AND [Tags] CONTAINS '${tag}'"
  }
  if($ignoreReleasePlannerTests){
    $serviceCondition += " AND [Tags] NOT CONTAINS 'Release Planner App Test'"
  }
  $query = "SELECT [ID], [ServiceName], [PackageDisplayName], [Parent] FROM WorkItems WHERE [Work Item Type] = 'Epic' AND ${serviceCondition}"

  $fields = @("System.Id", "Custom.ServiceName", "Custom.PackageDisplayName", "System.Parent", "System.Tags")

  $workItems = Invoke-Query $fields $query $outputCommand

  foreach ($wi in $workItems)
  {
    $localKey = BuildHashKey $wi.fields["Custom.ServiceName"] $wi.fields["Custom.PackageDisplayName"]
    if (!$localKey) { continue }
    if ($parentWorkItems.ContainsKey($localKey) -and $parentWorkItems[$localKey].id -ne $wi.id) {
      Write-Warning "Already found parent [$($parentWorkItems[$localKey].id)] with key [$localKey], using that one instead of [$($wi.id)]."
    }
    else {
      Write-Verbose "[$($wi.id)]$localKey - Cached"
      $parentWorkItems[$localKey] = $wi
    }
  }

  if ($key -and $parentWorkItems.ContainsKey($key)) {
    return $parentWorkItems[$key]
  }
  return $null
}

$packageWorkItems = @{}
$packageWorkItemWithoutKeyFields = @{}

function FindLatestPackageWorkItem($lang, $packageName, $outputCommand = $true, $ignoreReleasePlannerTests = $true, $tag = $null)
{
  # Cache all the versions of this package and language work items
  $null = FindPackageWorkItem $lang $packageName -includeClosed $true -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests -tag $tag

  $latestWI = $null
  foreach ($wi in $packageWorkItems.Values)
  {
    if ($wi.fields["Custom.Language"] -ne $lang) { continue }
    if ($wi.fields["Custom.Package"] -ne $packageName) { continue }

    if (!$latestWI) {
      $latestWI = $wi
      continue
    }

    if (($wi.fields["Custom.PackageVersionMajorMinor"] -as [Version]) -gt ($latestWI.fields["Custom.PackageVersionMajorMinor"] -as [Version])) {
      $latestWI = $wi
    }
  }
  return $latestWI
}

function FindPackageWorkItem($lang, $packageName, $version, $outputCommand = $true, $includeClosed = $false, $ignoreReleasePlannerTests = $true, $tag = $null)
{
  $key = BuildHashKeyNoNull $lang $packageName $version
  if ($key -and $packageWorkItems.ContainsKey($key)) {
    return $packageWorkItems[$key]
  }

  $fields = @()
  $fields += "System.ID"
  $fields += "System.State"
  $fields += "System.AssignedTo"
  $fields += "System.Parent"
  $fields += "System.Tags"
  $fields += "Custom.Language"
  $fields += "Custom.Package"
  $fields += "Custom.PackageDisplayName"
  $fields += "System.Title"
  $fields += "Custom.PackageType"
  $fields += "Custom.PackageTypeNewLibrary"
  $fields += "Custom.PackageVersionMajorMinor"
  $fields += "Custom.PackageRepoPath"
  $fields += "Custom.ServiceName"
  $fields += "Custom.PlannedPackages"
  $fields += "Custom.ShippedPackages"
  $fields += "Custom.PackageBetaVersions"
  $fields += "Custom.PackageGAVersion"
  $fields += "Custom.PackagePatchVersions"
  $fields += "Custom.Generated"
  $fields += "Custom.RoadmapState"
  $fields += "Microsoft.VSTS.Common.StateChangeDate"

  $fieldList = ($fields | ForEach-Object { "[$_]"}) -join ", "
  $query = "SELECT ${fieldList} FROM WorkItems WHERE [Work Item Type] = 'Package'"

  if (!$includeClosed -and !$lang) {
    $query += " AND [State] <> 'No Active Development' AND [PackageTypeNewLibrary] = true"
  }
  if ($lang) {
    $query += " AND [Language] = '${lang}'"
  }
  if ($packageName) {
    $query += " AND [Package] = '${packageName}'"
  }
  if ($version) {
    $query += " AND [PackageVersionMajorMinor] = '${version}'"
  }
  if ($tag) {
    $query += " AND [Tags]  CONTAINS '${tag}'"
  }
  if($ignoreReleasePlannerTests){
    $query += " AND [Tags] NOT CONTAINS 'Release Planner App Test'"
  }
  $workItems = Invoke-Query $fields $query $outputCommand

  foreach ($wi in $workItems)
  {
    $localKey = BuildHashKeyNoNull $wi.fields["Custom.Language"] $wi.fields["Custom.Package"] $wi.fields["Custom.PackageVersionMajorMinor"]
    if (!$localKey) {
      $packageWorkItemWithoutKeyFields[$wi.id] = $wi
      Write-Host "Skipping package [$($wi.id)]$($wi.fields['System.Title']) which is missing required fields language, package, or version."
      continue
    }
    if ($packageWorkItems.ContainsKey($localKey) -and $packageWorkItems[$localKey].id -ne $wi.id) {
      Write-Warning "Already found package [$($packageWorkItems[$localKey].id)] with key [$localKey], using that one instead of [$($wi.id)]."
    }
    else {
      Write-Verbose "Caching package [$($wi.id)] for [$localKey]"
      $packageWorkItems[$localKey] = $wi
    }
  }

  if ($key -and $packageWorkItems.ContainsKey($key)) {
    return $packageWorkItems[$key]
  }
  return $null
}

function InitializeWorkItemCache($outputCommand = $true, $includeClosed = $false, $ignoreReleasePlannerTests = $true)
{
  # Pass null to cache all service parents
  $null = FindParentWorkItem -serviceName $null -packageDisplayName $null -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests

  # Pass null to cache all the package items
  $null = FindPackageWorkItem -lang $null -packageName $null -version $null -outputCommand $outputCommand -includeClosed $includeClosed -ignoreReleasePlannerTests $ignoreReleasePlannerTests
}

function GetCachedPackageWorkItems()
{
  return $packageWorkItems.Values
}

function UpdateWorkItemParent($childWorkItem, $parentWorkItem, $outputCommand = $true)
{
  $childId = $childWorkItem.id
  $existingParentId = $childWorkItem.fields["System.Parent"]
  $newParentId = $parentWorkItem.id

  if ($existingParentId -eq $newParentId) {
    return
  }

  CreateWorkItemParent $childId $newParentId $existingParentId -outputCommand $outputCommand
  $childWorkItem.fields["System.Parent"] = $newParentId
}

function CreateWorkItemParent($id, $parentId, $oldParentId, $outputCommand = $true)
{
  # Have to remove old parent first if you want to add a new parent.
  if ($oldParentId)
  {
     $parameters = $ReleaseDevOpsCommonParameters
     $parameters += "--yes"
     $parameters += "--id", $id
     $parameters += "--relation-type", "parent"
     $parameters += "--target-id", $oldParentId

     Invoke-AzBoardsCmd "work-item relation remove" $parameters $outputCommand | Out-Null
  }

  $parameters = $ReleaseDevOpsCommonParameters
  $parameters += "--id", $id
  $parameters += "--relation-type", "parent"
  $parameters += "--target-id", $parentId

  Invoke-AzBoardsCmd "work-item relation add" $parameters $outputCommand | Out-Null
}

function CreateWorkItem($title, $type, $iteration, $area, $fields, $assignedTo, $parentId, $relatedId = $null, $outputCommand = $true, $tag = $null)
{
  $parameters = $ReleaseDevOpsCommonParametersWithProject
  $parameters += "--title", "`"${title}`""
  $parameters += "--type", "`"${type}`""
  $parameters += "--iteration", "`"${iteration}`""
  $parameters += "--area", "`"${area}`""
  if ($assignedTo) {
    $parameters += "--assigned-to", "`"${assignedTo}`""
  }
  if ($tag)
  {
    if ($fields)
    {
      $fields += "`"System.Tags=${tag}`""
    }
    else
    {
      $parameters += "--fields"
      $parameters += "`"System.Tags=${tag}`""
    }
  }
  if ($fields) {
    $parameters += "--fields"
    $parameters += $fields
  }

  Write-Host "Creating work item"
  $workItem = Invoke-AzBoardsCmd "work-item create" $parameters $outputCommand
  Write-Host $workItem
  $workItemId = $workItem.id
  Write-Host "Created work item [$workItemId]."
  if ($parentId)
  {
    CreateWorkItemRelation $workItemId $parentId "parent" $outputCommand
  }

  # Add a work item as related if given.
  if ($relatedId)
  {
    CreateWorkItemRelation $workItemId $relatedId "Related" $outputCommand
  }
  return $workItem
}

function CreateWorkItemRelation($id, $relatedId, $relationType, $outputCommand = $true)
{
  $parameters = $ReleaseDevOpsCommonParameters
  $parameters += "--id", $id
  $parameters += "--relation-type", $relationType
  $parameters += "--target-id", $relatedId
  Write-Host "Updating work item [$relatedId] as [$relationType] of [$id]."
  Invoke-AzBoardsCmd "work-item relation add" $parameters $outputCommand | Out-Null
}

function UpdateWorkItem($id, $fields, $title, $state, $assignedTo, $outputCommand = $true)
{
  $parameters = $ReleaseDevOpsCommonParameters
  $parameters += "--id", $id
  if ($title) {
    $parameters += "--title", "`"${title}`""
  }
  if ($state) {
    $parameters += "--state", "`"${state}`""
  }
  if ($assignedTo) {
    $parameters += "--assigned-to", "`"${assignedTo}`""
  }
  if ($fields) {
    $parameters += "--fields"
    $parameters += $fields
  }

  return Invoke-AzBoardsCmd "work-item update" $parameters $outputCommand
}

function UpdatePackageWorkItemReleaseState($id, $state, $releaseType, $outputCommand = $true)
{
  $fields = "`"Custom.ReleaseType=${releaseType}`""
  return UpdateWorkItem -id $id -state $state -fields $fields -outputCommand $outputCommand
}

function FindOrCreateClonePackageWorkItem($lang, $pkg, $verMajorMinor, $allowPrompt = $false, $outputCommand = $false, $relatedId = $null, $tag= $null, $ignoreReleasePlannerTests = $true)
{
  $workItem = FindPackageWorkItem -lang $lang -packageName $pkg.Package -version $verMajorMinor -includeClosed $true -outputCommand $outputCommand -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests

  if (!$workItem) {
    $latestVersionItem = FindLatestPackageWorkItem -lang $lang -packageName $pkg.Package -outputCommand $outputCommand -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests
    $assignedTo = "me"
    $extraFields = @()
    if ($latestVersionItem) {
      Write-Verbose "Copying data from latest matching [$($latestVersionItem.id)] with version $($latestVersionItem.fields["Custom.PackageVersionMajorMinor"])"
      if ($latestVersionItem.fields["System.AssignedTo"]) {
        $assignedTo = $latestVersionItem.fields["System.AssignedTo"]["uniqueName"]
      }
      $pkg.DisplayName = $latestVersionItem.fields["Custom.PackageDisplayName"]
      $pkg.ServiceName = $latestVersionItem.fields["Custom.ServiceName"]
      if (!$pkg.RepoPath -and $pkg.RepoPath -ne "NA" -and $pkg.fields["Custom.PackageRepoPath"]) {
        $pkg.RepoPath = $pkg.fields["Custom.PackageRepoPath"]
      }

      if ($latestVersionItem.fields["Custom.Generated"]) {
        $extraFields += "`"Generated=" + $latestVersionItem.fields["Custom.Generated"] + "`""
      }

      if ($latestVersionItem.fields["Custom.RoadmapState"]) {
        $extraFields += "`"RoadmapState=" +  $latestVersionItem.fields["Custom.RoadmapState"] + "`""
      }
    }

    if ($allowPrompt) {
      if (!$pkg.DisplayName) {
        Write-Host "Display name is used to identify this package across languages and is usually the friendly name (i.e. For 'Azure Anomaly Detector' it would be 'Anomaly Detector'. For 'Azure Cognitive Search' it would be 'Search'.). See https://aka.ms/azsdk/mark-release-status for more info."
        while (($readInput = Read-Host -Prompt "Input the display name") -eq "") { }
        $packageInfo.DisplayName = $readInput
      }

      if (!$pkg.ServiceName) {
        Write-Host "This is the friendly service name for this package that is used to align it with other packages and languages (i.e., no need to include 'Azure' or 'Microsoft' in the title). The service name is sometimes the same as the `Package Display Name` if there is only one package for a service. (i.e. For 'Azure Anomaly Detector' it would be 'Anomaly Detector'). For services that ship multiple packages be sure to list the service only. (i.e. For 'Schema Registry Avro', the service name is just 'Schema Registry'; For 'Key Vault Certificates', the service name is simply Key Vault.). See https://aka.ms/azsdk/mark-release-status for more info."
        while (($readInput = Read-Host -Prompt "Input the service name") -eq "") { }
        $packageInfo.ServiceName = $readInput
      }
    }
    $workItem = CreateOrUpdatePackageWorkItem $lang $pkg $verMajorMinor -existingItem $null -assignedTo $assignedTo -extraFields $extraFields -outputCommand $outputCommand -relatedId $relatedId -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests
  }

  return $workItem
}

function CreateOrUpdatePackageWorkItem($lang, $pkg, $verMajorMinor, $existingItem, $assignedTo = $null, $extraFields = $null, $outputCommand = $true, $relatedId = $null, $tag = $null, $ignoreReleasePlannerTests = $true)
{
  if (!$lang -or !$pkg -or !$verMajorMinor) {
    Write-Host "Cannot create or update because one of lang, pkg or verMajorMinor aren't set. [$lang|$($pkg.Package)|$verMajorMinor]"
    return
  }
  $pkgName = $pkg.Package
  $pkgDisplayName = $pkg.DisplayName
  $pkgType = $pkg.Type
  $pkgNewLibrary = $pkg.New
  $pkgRepoPath = $pkg.RepoPath
  $serviceName = $pkg.ServiceName
  $title = $lang + " - " + $pkg.DisplayName + " - " + $verMajorMinor

  $fields = @()
  $fields += "`"Language=${lang}`""
  $fields += "`"Package=${pkgName}`""
  $fields += "`"PackageDisplayName=${pkgDisplayName}`""
  $fields += "`"PackageType=${pkgType}`""
  $fields += "`"PackageTypeNewLibrary=${pkgNewLibrary}`""
  $fields += "`"PackageVersionMajorMinor=${verMajorMinor}`""
  $fields += "`"ServiceName=${serviceName}`""
  $fields += "`"PackageRepoPath=${pkgRepoPath}`""

  if ($extraFields) {
    $fields += $extraFields
  }

  if ($existingItem)
  {
    $changedField = $null

    if ($lang -ne $existingItem.fields["Custom.Language"]) { $changedField = "Custom.Language" }
    if ($pkgName -ne $existingItem.fields["Custom.Package"]) { $changedField = "Custom.Package" }
    if ($verMajorMinor -ne $existingItem.fields["Custom.PackageVersionMajorMinor"]) { $changedField = "Custom.PackageVersionMajorMinor" }
    if ($pkgDisplayName -ne $existingItem.fields["Custom.PackageDisplayName"]) { $changedField = "Custom.PackageDisplayName" }
    if ($pkgType -ne [string]$existingItem.fields["Custom.PackageType"]) { $changedField = "Custom.PackageType" }
    if ($pkgNewLibrary -ne $existingItem.fields["Custom.PackageTypeNewLibrary"]) { $changedField = "Custom.PackageTypeNewLibrary" }
    if ($pkgRepoPath -ne $existingItem.fields["Custom.PackageRepoPath"]) { $changedField = "Custom.PackageRepoPath" }
    if ($serviceName -ne $existingItem.fields["Custom.ServiceName"]) { $changedField = "Custom.ServiceName" }
    if ($title -ne $existingItem.fields["System.Title"]) { $changedField = "System.Title" }

    if ($changedField) {
      Write-Host "At least field $changedField ($($existingItem.fields[$changedField])) changed so updating."
    }

    if ($changedField) {
      $beforeState = $existingItem.fields["System.State"]

      # Need to set to New to be able to update
      $existingItem = UpdateWorkItem -id $existingItem.id -fields $fields -title $title -state "New" -assignedTo $assignedTo -outputCommand $outputCommand
      Write-Host "[$($existingItem.id)]$lang - $pkgName($verMajorMinor) - Updated"

      if ($beforeState -ne $existingItem.fields['System.State']) {
        Write-Verbose "Resetting state for [$($existingItem.id)] from '$($existingItem.fields['System.State'])' to '$beforeState'"
        $existingItem = UpdateWorkItem $existingItem.id -state $beforeState -outputCommand $outputCommand
      }
    }

    $newparentItem = FindOrCreatePackageGroupParent $serviceName $pkgDisplayName -outputCommand $false -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests
    UpdateWorkItemParent $existingItem $newParentItem -outputCommand $outputCommand
    return $existingItem
  }

  $parentItem = FindOrCreatePackageGroupParent $serviceName $pkgDisplayName -outputCommand $false -tag $tag -ignoreReleasePlannerTests $ignoreReleasePlannerTests
  Write-Host "Found product work item [$($parentItem.id)]. Creating package work item."
  $workItem = CreateWorkItem $title "Package" "Release" "Release" $fields $assignedTo $parentItem.id -outputCommand $outputCommand -relatedId $relatedId -tag $tag
  Write-Host "[$($workItem.id)]$lang - $pkgName($verMajorMinor) - Created"
  return $workItem
}

function FindOrCreatePackageGroupParent($serviceName, $packageDisplayName, $outputCommand = $true, $ignoreReleasePlannerTests = $true, $tag = $null)
{
  $existingItem = FindParentWorkItem $serviceName $packageDisplayName -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests -tag $tag
  if ($existingItem) {
    Write-Verbose "Found existing product work item [$($existingItem.id)]"
    $newparentItem = FindOrCreateServiceParent $serviceName -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests -tag $tag
    UpdateWorkItemParent $existingItem $newParentItem
    return $existingItem
  }

  $fields = @()
  $fields += "`"PackageDisplayName=${packageDisplayName}`""
  $fields += "`"ServiceName=${serviceName}`""
  $fields += "`"Custom.EpicType=Product`""
  $serviceParentItem = FindOrCreateServiceParent $serviceName -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests -tag $tag
  $workItem = CreateWorkItem $packageDisplayName "Epic" "Release" "Release" $fields $null $serviceParentItem.id -tag $tag

  $localKey = BuildHashKey $serviceName $packageDisplayName
  Write-Host "[$($workItem.id)]$localKey - Created Parent"
  $parentWorkItems[$localKey] = $workItem
  return $workItem
}

function FindOrCreateServiceParent($serviceName, $outputCommand = $true, $ignoreReleasePlannerTests = $true, $tag = $null)
{
  $serviceParent = FindParentWorkItem $serviceName -packageDisplayName $null -outputCommand $outputCommand -ignoreReleasePlannerTests $ignoreReleasePlannerTests -tag $tag
  if ($serviceParent) {
    Write-Verbose "Found existing service work item [$($serviceParent.id)]"
    return $serviceParent
  }

  $fields = @()
  $fields += "`"PackageDisplayName=`""
  $fields += "`"ServiceName=${serviceName}`""
  $fields += "`"Custom.EpicType=Service`""
  $parentId = $null
  $workItem = CreateWorkItem $serviceName "Epic" "Release" "Release" $fields $null $parentId -outputCommand $outputCommand -tag $tag

  $localKey = BuildHashKey $serviceName
  Write-Host "[$($workItem.id)]$localKey - Created service work item"
  $parentWorkItems[$localKey] = $workItem
  return $workItem
}

function ParseVersionSetFromMDField([string]$field)
{
  $MDTableRegex = "\|\s*(?<t>\S*)\s*\|\s*(?<v>\S*)\s*\|\s*(?<d>\S*)\s*\|"
  $versionSet = @{}
  $tableMatches = [Regex]::Matches($field, $MDTableRegex)

  foreach ($match in $tableMatches)
  {
    if ($match.Groups["t"].Value -eq "Type" -or $match.Groups["t"].Value -eq "-") {
      continue
    }
    $version = New-Object PSObject -Property @{
      Type = $match.Groups["t"].Value
      Version = $match.Groups["v"].Value
      Date = $match.Groups["d"].Value
    }
    if (!$versionSet.ContainsKey($version.Version)) {
      $versionSet[$version.Version] = $version
    }
  }
  return $versionSet
}

function GetTextVersionFields($versionList, $pkgWorkItem)
{
  $betaVersions = $gaVersions = $patchVersions = ""
  foreach ($v in $versionList) {
    $vstr = "$($v.Version),$($v.Date)"
    if ($v.Type -eq "Beta") {
      if ($betaVersions.Length + $vstr.Length -lt 255) {
        if ($betaVersions.Length -gt 0) { $betaVersions += "|" }
        $betaVersions += $vstr
      }
    }
    elseif ($v.Type -eq "GA") {
      if ($gaVersions.Length + $vstr.Length -lt 255) {
        if ($gaVersions.Length -gt 0) { $gaVersions += "|" }
        $gaVersions += $vstr
      }
    }
    elseif ($v.Type -eq "Patch") {
      if ($patchVersions.Length + $vstr.Length -lt 255) {
        if ($patchVersions.Length -gt 0) { $patchVersions += "|" }
        $patchVersions += $vstr
      }
    }
  }

  $fieldUpdates = @()
  if ("$($pkgWorkItem.fields["Custom.PackageBetaVersions"])" -ne $betaVersions)
  {
    $fieldUpdates += @"
{
  "op": "replace",
  "path": "/fields/PackageBetaVersions",
  "value": "$betaVersions"
}
"@
  }

  if ("$($pkgWorkItem.fields["Custom.PackageGAVersion"])" -ne $gaVersions)
  {
    $fieldUpdates += @"
{
  "op": "replace",
  "path": "/fields/PackageGAVersion",
  "value": "$gaVersions"
}
"@
  }

  if ("$($pkgWorkItem.fields["Custom.PackagePatchVersions"])" -ne $patchVersions)
  {
    $fieldUpdates += @"
{
  "op": "replace",
  "path": "/fields/PackagePatchVersions",
  "value": "$patchVersions"
}
"@
  }
  return ,$fieldUpdates
}

function GetMDVersionValue($versionlist)
{
  $mdVersions = ""
  $mdFormat = "| {0} | {1} | {2} |`n"

  $htmlVersions = ""
  $htmlFormat = @"
<tr>
<td>{0}</td>
<td>{1}</td>
<td>{2}</td>
</tr>

"@

  foreach ($version in $versionList) {
    $mdVersions += ($mdFormat -f $version.Type, $version.Version, $version.Date)
    $htmlVersions += ($htmlFormat -f $version.Type, $version.Version, $version.Date)
  }

  $htmlTemplate = @"
<div style='display:none;width:0;height:0;overflow:hidden;position:absolute;font-size:0;' id=__md>| Type | Version | Date |
| - | - | - |
mdVersions
</div><style id=__mdStyle>
.rendered-markdown img {
cursor:pointer;
}

.rendered-markdown h1, .rendered-markdown h2, .rendered-markdown h3, .rendered-markdown h4, .rendered-markdown h5, .rendered-markdown h6 {
color:#007acc;
font-weight:400;
}

.rendered-markdown h1 {
border-bottom:1px solid #e6e6e6;
font-size:26px;
font-weight:600;
margin-bottom:20px;
}

.rendered-markdown h2 {
font-size:18px;
border-bottom:1px solid #e6e6e6;
font-weight:600;
color:#303030;
margin-bottom:10px;
margin-top:20px;
}

.rendered-markdown h3 {
font-size:16px;
font-weight:600;
margin-bottom:10px;
}

.rendered-markdown h4 {
font-size:14px;
margin-bottom:10px;
}

.rendered-markdown h5 {
font-size:12px;
margin-bottom:10px;
}

.rendered-markdown h6 {
font-size:12px;
font-weight:300;
margin-bottom:10px;
}

.rendered-markdown.metaitem {
font-size:12px;
padding-top:15px;
}

.rendered-markdown.metavalue {
font-size:12px;
padding-left:4px;
}

.rendered-markdown.metavalue>img {
height:32px;
width:32px;
margin-bottom:3px;
padding-left:1px;
}

.rendered-markdown li.metavaluelink {
list-style-type:disc;
list-style-position:inside;
}

.rendered-markdown li.metavalue>a {
border:none;
padding:0;
display:inline;
}

.rendered-markdown li.metavalue>a:hover {
background-color:inherit;
text-decoration:underline;
}

.rendered-markdown code, .rendered-markdown pre, .rendered-markdown samp {
font-family:Monaco,Menlo,Consolas,'Droid Sans Mono','Inconsolata','Courier New',monospace;
}

.rendered-markdown code {
color:#333;
background-color:#f8f8f8;
border:1px solid #ccc;
border-radius:3px;
padding:2px 4px;
font-size:90%;
line-height:2;
white-space:nowrap;
}

.rendered-markdown pre {
color:#333;
background-color:#f8f8f8;
border:1px solid #ccc;
display:block;
padding:6px;
font-size:13px;
word-break:break-all;
word-wrap:break-word;
}

.rendered-markdown pre code {
padding:0;
font-size:inherit;
color:inherit;
white-space:pre-wrap;
background-color:transparent;
line-height:1.428571429;
border:none;
}

.rendered-markdown.pre-scrollable {
max-height:340px;
overflow-y:scroll;
}

.rendered-markdown table {
border-collapse:collapse;
}

.rendered-markdown table {
width:auto;
}

.rendered-markdown table, .rendered-markdown th, .rendered-markdown td {
border:1px solid #ccc;
padding:4px;
}

.rendered-markdown th {
font-weight:bold;
background-color:#f8f8f8;
}
</style><div class=rendered-markdown><table>
<thead>
<tr>
<th>Type</th>
<th>Version</th>
<th>Date</th>
</tr>
</thead>
<tbody>htmlVersions</tbody>
</table>
</div>
"@ -replace "'", '\"'

  return $htmlTemplate.Replace("mdVersions", $mdVersions).Replace("htmlVersions", "`n$htmlVersions");
}

function UpdatePackageVersions($pkgWorkItem, $plannedVersions, $shippedVersions)
{
  # Create the planned and shipped versions, adding the new ones if any
  $updatePlanned = $false
  $plannedVersionSet = ParseVersionSetFromMDField $pkgWorkItem.fields["Custom.PlannedPackages"]
  foreach ($version in $plannedVersions)
  {
    if (!$plannedVersionSet.ContainsKey($version.Version))
    {
      $plannedVersionSet[$version.Version] = $version
      $updatePlanned = $true
    }
    else
    {
      # Lets check to see if someone wanted to update a date
      $existingVersion = $plannedVersionSet[$version.Version]
      if ($existingVersion.Date -ne $version.Date) {
        $existingVersion.Date = $version.Date
        $updatePlanned = $true
      }
    }
  }

  $updateShipped = $false
  $shippedVersionSet = ParseVersionSetFromMDField $pkgWorkItem.fields["Custom.ShippedPackages"]
  foreach ($version in $shippedVersions)
  {
    if (!$shippedVersionSet.ContainsKey($version.Version))
    {
      $shippedVersionSet[$version.Version] = $version
      $updateShipped = $true
    }
    else
    {
      # Check for any date update, general case would from be previous Unknown to date
      if ($shippedVersionSet[$version.Version].Date -ne $version.Date)
      {
        $shippedVersionSet[$version.Version] = $version
        $updateShipped = $true
      }
    }
  }

  $versionSet = @{}
  foreach ($version in $shippedVersionSet.Keys)
  {
    if (!$versionSet.ContainsKey($version))
    {
      $versionSet[$version] = $shippedVersionSet[$version]
    }
  }

  foreach ($version in @($plannedVersionSet.Keys))
  {
    if (!$versionSet.ContainsKey($version))
    {
      $versionSet[$version] = $plannedVersionSet[$version]
    }
    else
    {
      # Looks like we shipped this version so remove it from the planned set
      $plannedVersionSet.Remove($version)
      $updatePlanned = $true
    }
  }

  $fieldUpdates = @()
  if ($updatePlanned)
  {
    $plannedPackages = GetMDVersionValue ($plannedVersionSet.Values | Sort-Object {$_.Date -as [DateTime]}, Version -Descending)
    $fieldUpdates += @"
{
  "op": "replace",
  "path": "/fields/Planned Packages",
  "value": "$plannedPackages"
}
"@
  }

  if ($updateShipped)
  {
    $newShippedVersions = $shippedVersionSet.Values | Sort-Object {$_.Date -as [DateTime]}, Version -Descending
    $shippedPackages = GetMDVersionValue $newShippedVersions
    $fieldUpdates += @"
{
  "op": "replace",
  "path": "/fields/Shipped Packages",
  "value": "$shippedPackages"
}
"@

    # If we shipped a version after we set "In Release" state then reset the state to "Next Release Unknown"
    if ($pkgWorkItem.fields["System.State"] -eq "In Release")
    {
      $lastShippedDate = $newShippedVersions[0].Date -as [DateTime]
      $markedInReleaseDate = ([DateTime]$pkgWorkItem.fields["Microsoft.VSTS.Common.StateChangeDate"])

      # We just shipped so lets set the state to "Next Release Unknown"
      if ($lastShippedDate -and $markedInReleaseDate -le $lastShippedDate)
      {
        $fieldUpdates += @'
{
  "op": "replace",
  "path": "/fields/State",
  "value": "Next Release Unknown"
}
'@
      }
    }
  }

  # Full merged version set
  $versionList = $versionSet.Values | Sort-Object {$_.Date -as [DateTime]}, Version -Descending

  $versionFieldUpdates = GetTextVersionFields $versionList $pkgWorkItem
  if ($versionFieldUpdates.Count -gt 0)
  {
    $fieldUpdates += $versionFieldUpdates
  }

  # If no version files to update do nothing
  if ($fieldUpdates.Count -eq 0) {
    return $pkgWorkItem
  }

  $versionsForDebug = ($versionList | Foreach-Object { $_.Version }) -join ","
  $id = $pkgWorkItem.id
  $loggingString = "[$($pkgWorkItem.id)]"
  $loggingString += "$($pkgWorkItem.fields['Custom.Language'])"
  $loggingString += " - $($pkgWorkItem.fields['Custom.Package'])"
  $loggingString += "($($pkgWorkItem.fields['Custom.PackageVersionMajorMinor']))"
  $loggingString += " - Updating versions $versionsForDebug"
  Write-Host $loggingString

  $body = "[" + ($fieldUpdates -join ',') + "]"

  $response = Invoke-RestMethod -Method PATCH `
    -Uri "https://dev.azure.com/azure-sdk/_apis/wit/workitems/${id}?api-version=6.0" `
    -Headers (Get-DevOpsRestHeaders) -Body $body -ContentType "application/json-patch+json" | ConvertTo-Json -Depth 10 | ConvertFrom-Json -AsHashTable
  return $response
}

function UpdateValidationStatus($pkgvalidationDetails, $BuildDefinition, $PipelineUrl)
{
    $pkgName = $pkgValidationDetails.Name
    $versionString = $pkgValidationDetails.Version

    $parsedNewVersion = [AzureEngSemanticVersion]::new($versionString)
    $versionMajorMinor = "" + $parsedNewVersion.Major + "." + $parsedNewVersion.Minor
    $workItem = FindPackageWorkItem -lang $LanguageDisplayName -packageName $pkgName -version $versionMajorMinor -includeClosed $true -outputCommand $false

    if (!$workItem)
    {
        Write-Host"No work item found for package [$pkgName]."
        return $false
    }

    $changeLogStatus = $pkgValidationDetails.ChangeLogValidation.Status
    $changeLogDetails  = $pkgValidationDetails.ChangeLogValidation.Message
    $apiReviewStatus = $pkgValidationDetails.APIReviewValidation.Status
    $apiReviewDetails = $pkgValidationDetails.APIReviewValidation.Message
    $packageNameStatus = $pkgValidationDetails.PackageNameValidation.Status
    $packageNameDetails = $pkgValidationDetails.PackageNameValidation.Message

    $fields = @()
    $fields += "`"PackageVersion=${versionString}`""
    $fields += "`"ChangeLogStatus=${changeLogStatus}`""
    $fields += "`"ChangeLogValidationDetails=${changeLogDetails}`""
    $fields += "`"APIReviewStatus=${apiReviewStatus}`""
    $fields += "`"APIReviewStatusDetails=${apiReviewDetails}`""
    $fields += "`"PackageNameApprovalStatus=${packageNameStatus}`""
    $fields += "`"PackageNameApprovalDetails=${packageNameDetails}`""
    if ($BuildDefinition) {
        $fields += "`"PipelineDefinition=$BuildDefinition`""
    }
    if ($PipelineUrl) {
        $fields += "`"LatestPipelineRun=$PipelineUrl`""
    }

    $workItem = UpdateWorkItem -id $workItem.id -fields $fields
    Write-Host "[$($workItem.id)]$LanguageDisplayName - $pkgName($versionMajorMinor) - Updated"
    return $true
}

function Get-LanguageDevOpsName($LanguageShort)
{
    switch ($LanguageShort.ToLower()) 
    {
        "net" { return "Dotnet" }
        "js" { return "JavaScript" }
        "java" { return "Java" }
        "go" { return "Go" }
        "python" { return "Python" }
        default { return $null }
    }
}

function Get-ReleasePlanForPackage($packageName)
{
    $devopsFieldLanguage = Get-LanguageDevOpsName -LanguageShort $LanguageShort
    if (!$devopsFieldLanguage)
    {
        Write-Host "Unsupported language to check release plans, language [$LanguageShort]"
        return $null
    }

    $prStatusFieldName = "SDKPullRequestStatusFor$($devopsFieldLanguage)"
    $packageNameFieldName = "$($devopsFieldLanguage) Package Name"
    $fields = @()
    $fields += "System.ID"
    $fields += "System.State"
    $fields += "System.AssignedTo"
    $fields += "System.Parent"
    $fields += "System.Tags"

    $fieldList = ($fields | ForEach-Object { "[$_]"}) -join ", "
    $query = "SELECT ${fieldList} FROM WorkItems WHERE [Work Item Type] = 'Release Plan' AND [${packageNameFieldName}] = '${packageName}'"
    $query += " AND [${prStatusFieldName}] = 'merged'"
    $query += " AND [System.State] IN ('In Progress')"
    $query += " AND [System.Tags] NOT CONTAINS 'Release Planner App Test'"
    $workItems = Invoke-Query $fields $query
    return $workItems
}

function Update-ReleaseStatusInReleasePlan($releasePlanWorkItemId, $status, $version)
{  
    $devopsFieldLanguage = Get-LanguageDevOpsName -LanguageShort $LanguageShort
    if (!$devopsFieldLanguage)
    {
        Write-Host "Unsupported language to check release plans, language [$LanguageShort]"
        return $null
    }

    $fields = @()
    $fields += "`"ReleaseStatusFor$($devopsFieldLanguage)=$status`""
    $fields += "`"ReleasedVersionFor$($devopsFieldLanguage)=$version`""

    Write-Host "Updating Release Plan [$releasePlanWorkItemId] with status [$status] for language [$LanguageShort]."
    $workItem = UpdateWorkItem -id $releasePlanWorkItemId -fields $fields
    Write-Host "Updated release status for [$LanguageShort] in Release Plan [$releasePlanWorkItemId]"
}

function Update-PullRequestInReleasePlan($releasePlanWorkItemId, $pullRequestUrl, $status, $languageName)
{
    $devopsFieldLanguage = Get-LanguageDevOpsName -LanguageShort $languageName
    if (!$devopsFieldLanguage)
    {
        Write-Host "Unsupported language to update release plan, language [$languageName]"
        return $null
    }

    $fields = @()
    if ($pullRequestUrl)
    {
        $fields += "`"SDKPullRequestFor$($devopsFieldLanguage)=$pullRequestUrl`""
    }
    $fields += "`"SDKPullRequestStatusFor$($devopsFieldLanguage)=$status`""

    Write-Host "Updating release plan [$releasePlanWorkItemId] with pull request details for language [$languageName]."
    $workItem = UpdateWorkItem -id $releasePlanWorkItemId -fields $fields
    Write-Host "Updated pull request details for [$languageName] in release plan [$releasePlanWorkItemId]"
}

function Get-ReleasePlan-Link($releasePlanWorkItemId)
{
  $fields = @()
  $fields += "System.Id"
  $fields += "System.Title"
  $fields += "Custom.ReleasePlanLink"
  $fields += "Custom.ReleasePlanSubmittedby"

  $fieldList = ($fields | ForEach-Object { "[$_]"}) -join ", "
  $query = "SELECT ${fieldList} FROM WorkItems WHERE [System.Id] = $releasePlanWorkItemId"
  $workItem = Invoke-Query $fields $query
  if (!$workItem)
  {
      Write-Host "Release plan with ID $releasePlanWorkItemId not found."
      return $null
  }
  return $workItem["fields"]
}

function Get-ReleasePlansForCPEXAttestation()
{
  $fields = @()
  $fields += "Custom.ProductServiceTreeID"
  $fields += "Custom.ReleasePlanType"
  $fields += "Custom.ProductType"
  $fields += "Custom.DataScope"
  $fields += "Custom.MgmtScope"

  $fieldList = ($fields | ForEach-Object { "[$_]"}) -join ", "
  $query = "SELECT ${fieldList} FROM WorkItems WHERE [System.WorkItemType] = 'Release Plan' AND [System.State] = 'Finished'"
  $query += " AND [Custom.AttestationStatus] IN ('', 'Pending')"
  $query += " AND [System.Tags] NOT CONTAINS 'Release Planner App Test'"
  $query += " AND [System.Tags] NOT CONTAINS 'Release Planner Test App'"

  $workItems = Invoke-Query $fields $query
  return $workItems
}

function Get-TriagesForCPEXAttestation()
{
  $fields = @()
  $fields += "Custom.ProductServiceTreeID"
  $fields += "Custom.ProductType"
  $fields += "Custom.DataScope"
  $fields += "Custom.MgmtScope"

  $fieldList = ($fields | ForEach-Object { "[$_]"}) -join ", "
  $query = "SELECT ${fieldList} FROM WorkItems WHERE [System.WorkItemType] = 'Triage' AND [System.State] IN ('Completed', 'New', 'Triage updated')"
  $query += " AND [Custom.DataplaneAttestationStatus] IN ('', 'Pending')"
  $query += " AND [Custom.ManagementPlaneAttestationStatus] IN ('', 'Pending')"
  $query += " AND [System.Tags] NOT CONTAINS 'Release Planner App Test'"
  $query += " AND [System.Tags] NOT CONTAINS 'Release Planner Test App'"

  $workItems = Invoke-Query $fields $query
  return $workItems  
}

function Update-AttestationStatusInReleasePlan($id, $status)
{
  $fields = @()
  $fields += "Custom.AttestationStatus=${status}"

  $workItem = UpdateWorkItem -id $id -fields $fields
  return $true
}

function Update-AttestationStatusInTriage($id, $dataStatus, $mgmtStatus)
{
  $fields = @()
  $fields += "Custom.DataplaneAttestationStatus=${dataStatus}"
  $fields += "Custom.ManagementPlaneAttestationStatus=${mgmtStatus}"

  $workItem = UpdateWorkItem -id $id -fields $fields
  return $true
}