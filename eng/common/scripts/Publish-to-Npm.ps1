param (
  $pathToArtifacts,
  $accessLevel,
  $tag,
  $additionalTag="",
  $registry,
  $npmToken,
  $filterArg="",
  $basicDeployment=$false,
  $devopsFeed=$false,
  $skipDiff=$false,
  $packagesToPublishPath,
  $addTag=$false
)

function replaceText($oldText,$newText,$filePath){
    $content = Get-Content -Path $filePath -Raw
    $newContent = $content -replace $oldText,$newText
    if ($newContent -ne $content)
    {
        Set-Content -Path $filePath -Value $newContent -NoNewLine
        Write-Host "replaceText [$oldText] [$newText] [$filePath]"
    }
}

function updateContents($dirName, $version){
    foreach ($md in $(dir $dirName -r -i *.md)){
        replaceText "https://github.com/Azure/azure-sdk-for-js/tree/[^/]*" "" $md.Fullname
    }
    foreach ($file in $(dir $dirName -r -i *.js,*.ts,*.json)){
        replaceText $version "VERSION_REMOVED" $file.Fullname
    }
}

function extractPackage($package) {
    $packageDir = Split-Path $package
    $extractPackageDir = Join-Path $packageDir $package.BaseName
    $devDir = "${extractPackageDir}-toPublishDev"
    $lastDevDirTgz = "${extractPackageDir}-lastDevTgz"
    $lastDevDir = "${extractPackageDir}-lastDev"
    New-Item -ItemType "directory" -Path $devDir | out-null
    pushd $devDir
    tar -xzf $package.FullName
    $json = Get-Content "./package/package.json" | Out-String | ConvertFrom-Json
    $name = $json.name
    $devVersion = $json.version
    popd
    $publish = $true
    if (($tag -eq "dev") -and (-not $skipDiff))
    {
        mkdir $lastDevDirTgz
        pushd $lastDevDirTgz
        #npm pack downloads targz from npm
        npm pack $name@dev | out-null
        if($LastExitCode -eq 0){
            $q = dir $lastDevDirTgz -r -i *.tgz
            popd
            New-Item -ItemType "directory" -Path $lastDevDir | out-null
            pushd $lastDevDir
            tar -xzf $q.Fullname
            $lastDevJson = Get-Content "./package/package.json" | Out-String | ConvertFrom-Json
            $lastDevVersion = $lastDevJson.version
            popd
            updateContents $devDir $devVersion
            updateContents $lastDevDir $lastDevVersion
            $publish = containsProductCodeDiff $devDir $lastDevDir
        }
    }

    return new-object PSObject -Property @{
        Project = $json;
        TarGz = $package;
        Publish = $publish
    }
}

function containsProductCodeDiff($currentDevPackage,$lastDevPackage) {
    $diffFile = "Change.diff"
    git diff --output=$diffFile --exit-code $lastDevPackage $currentDevPackage
    Write-Host "Exit code for git diff = $LastExitCode"
    if($LastExitCode -ne 0) {
        Write-Host "There were differences in the two packages - saved in $diffFile"
        Write-Host "Contents of $diffFile"
        Get-Content -Path $diffFile | % { Write-Host $_ }
        return $true
    }
    return $false
}

$ErrorActionPreference = "Stop"
$PSNativeCommandUseErrorActionPreference = $true

try {
    $regAuth=$registry.replace("https:","")
    $filterPackageList= $filterArg -split "," | % { return $_.trim() }
    $packageList = @()
    #We need to run the npm pack before we set NPM_TOKEN in npmrc so that the npmrc file is in default (empty) state
    foreach ($p in $(dir $pathToArtifacts -r -i *.tgz)) {
        foreach($filterItem in $filterPackageList) {
            if($p.BaseName.contains($filterItem)) {
                $packageList += extractPackage $p
            }
        }
    }

    $publishToNpm = $false
    if (!$basicDeployment) {
        if ($registry -eq 'https://registry.npmjs.org/') {
            $publishToNpm = $true
            if ($npmToken) {
                $env:NPM_TOKEN=$npmToken
                npm config set $regAuth`:_authToken=`$`{NPM_TOKEN`}
            }
        }
        else {
            Write-Host "Choosing Private Devops Feed Deployment"
            $npmReg = $regAuth.replace("registry/","");
            $env:NPM_TOKEN=$npmToken
            npm config set $regAuth`:username=azure-sdk
            npm config set $regAuth`:_password=`$`{NPM_TOKEN`}
            npm config set $regAuth`:email=not_set
            npm config set $npmReg`:username=azure-sdk
            npm config set $npmReg`:_password=`$`{NPM_TOKEN`}
            npm config set $npmReg`:email=not_set
      }
    }
    else {
        Write-Host "Choosing BasicAuth Deployment"
        npm config set $regAuth`:username=pat_will_be_used
        npm config set $regAuth`:_password=$npmToken
        npm config set $regAuth`:email=not_set
    }

    foreach ($p in $packageList) {
        if($p.Publish -and !$publishToNpm) {
            # Publishing to private feed
            if ($tag) {
                Write-Host "npm publish $($p.TarGz) --access=$accessLevel --registry=$registry --always-auth=true --tag=$tag"
                npm publish $p.TarGz --access=$accessLevel --registry=$registry --always-auth=true --tag=$tag
            }
            else {
                Write-Host "Tag is empty"
                Write-Host "npm publish $($p.TarGz) --access=$accessLevel --registry=$registry --always-auth=true"
                npm publish $p.TarGz --access=$accessLevel --registry=$registry --always-auth=true
            }
            
            if ($LastExitCode -ne 0) {
                Write-Host "npm publish failed with exit code $LastExitCode"
                exit 1
            }
            $addTagCheck = 0
            if (($additionalTag) -and ($additionalTag -ne $tag)) {
                $nameAndVersion = $p.Project.name + "@" + $p.Project.version
                Write-Host "npm dist-tag add $($nameAndVersion) $additionalTag"
                npm dist-tag add $nameAndVersion $additionalTag
                $addTagCheck = $LastExitCode
            }
            if ($addTagCheck -ne 0) {
                Write-Host "npm dist-tag add failed with exit code $addTagCheck"
                exit 1
            }
        }
        elseif ($addTag -and $publishToNpm) {
            $nameAndVersion = $p.Project.name + "@" + $p.Project.version
            if ($tag) {
                Write-Host "Adding tag for package"
                Write-Host "npm dist-tag add $nameAndVersion $tag"
                npm dist-tag add $nameAndVersion $tag
            }
            if (![string]::IsNullOrWhitespace($additionalTag) -and ($additionalTag -ne $tag)) {
                Write-Host "Tag: '$tag'"
                Write-Host "Additional tag: '$additionalTag'"
                Write-Host "Adding additional tag for package"
                Write-Host "npm dist-tag add $nameAndVersion $additionalTag"
                npm dist-tag add $nameAndVersion $additionalTag
            }
        }
        else {
            Write-Host "Skipping package publish $($p.TarGz)"
        }
    }
}
finally
{
    npm config delete $regAuth`:_authToken
    npm config delete $regAuth`:_password
    npm config delete $regAuth`:email
    npm config delete $regAuth`:username
    $env:NPM_TOKEN=""
}
