$ErrorActionPreference = 'Stop'
$Env:NODE_OPTIONS = "--max-old-space-size=8192"
Set-StrictMode -Version 1
$exitCode = 0

[string[]] $errors = @()

function LogError([string]$message) {
    if ($env:TF_BUILD) {
        Write-Host "##vso[task.logissue type=error]$message"
    }
    Write-Host -f Red "error: $message"
    $script:errors += $message
}

function Invoke-Block([scriptblock]$cmd) {
    $cmd | Out-String | Write-Verbose
    & $cmd

    # Need to check both of these cases for errors as they represent different items
    # - $?: did the powershell script block throw an error
    # - $lastexitcode: did a windows command executed by the script block end in error
    if ((-not $?) -or ($lastexitcode -ne 0)) {
        if ($error -ne $null) {
            Write-Warning $error[0]
        }
        throw "Command failed to execute: $cmd"
    }
}

function Find-Mapping([string]$path) {
    $fileContent = Get-Content $path
    $name = ''
    foreach ($item in $fileContent) {
        if (($item -match '\$\(csharp-sdks-folder\)')) {
            $matchResult = $item -match "\/([^/]+)\/"
            $name = $matches[0].Substring(1, $matches[0].Length - 2)
            if (($name -ne '') -and ($name -notmatch "\$")) {
                break
            }
        }
    }
    return $name
}

try {
    Write-Output "======== Start Code Validation ========"
    # Get RP Mapping
    Write-Output "Start RP mapping "
    $RPMapping = [ordered]@{ }
    $readmePath = ''
    git clone https://github.com/Azure/azure-rest-api-specs.git ../azure-rest-api-specs
    $folderNames = Get-ChildItem ../azure-rest-api-specs/specification
    $folderNames | ForEach-Object {
        $folderName = ''
        $readmePath = "../azure-rest-api-specs/specification/$($_.Name)/resource-manager/readme.csharp.md"
        if (Test-Path $readmePath) {
            $folderName = Find-Mapping $readmePath
        }
        if (($folderName -eq '') -or ($folderName -match "\$")) {
            $readmePath = "../azure-rest-api-specs/specification/$($_.Name)/resource-manager/readme.md"
            if (Test-Path $readmePath) {
                $folderName = Find-Mapping $readmePath
            }
        }
        if (($folderName -notmatch "\$") -and (!$RPMapping.Contains($folderName)) -and ($folderName -ne '')) {
            $RPMapping += @{ $folderName = "$($_.Name)" }
        }
    }

    # Get Metadata file path
    Write-Output "Get changed RP metadata file path"
    $Response = Invoke-WebRequest -URI https://api.github.com/repos/$Env:REPOSITORY_NAME/pulls/$Env:PULLREQUEST_ID/files
    $changeList = $Response.Content | ConvertFrom-Json
    if ($Response.RelationLink.Count -ne 0) {
        $lastLink = $Response.RelationLink.Get_Item('last')
        $lastPage = $lastLink.Substring($lastLink.indexof("=") + 1)
        for ($i = 2; $i -le $lastPage; $i++) {
            $Response = Invoke-WebRequest -URI https://api.github.com/repos/$Env:REPOSITORY_NAME/pulls/$Env:PULLREQUEST_ID/files?page=$i
            $changeList += $Response.Content | ConvertFrom-Json
        }
    }
    $mataPath = @()
    $rpIndex = @()
    $folderName = @()
    $changeList | ForEach-Object {
        $fileName = $_.filename
        if ($fileName -match 'eng/mgmt/mgmtmetadata') {
            $mataPath += $fileName
        }
    }
    $changeList | ForEach-Object {
        $fileName = $_.filename
        if ($fileName -match 'sdk/') {
            $name = $fileName.substring(4, (($fileName.indexof('/Microsoft') - 4)))
            If ($folderName -notcontains $name) {
                $folderName += $name
            }
        }
    }
    Write-Output "Changed RP list"
    foreach ($item in $folderName) {
        $rpName = $RPMapping.Get_Item($item)
        if ($rpName) {
            If ($rpIndex -notcontains $rpName) {
                Write-Output $rpName
                $rpIndex += $rpName
            }
        }
        else {
            LogError "Can't get proper RP name with folder $item `n 
            Please edit the readme.md or readme.csharp.md file under https://github.com/Azure/azure-rest-api-specs/tree/master/specification/<RP_Name>/resource-manager"
        } 
    }
    $rpIndex | ForEach-Object {
        $path = "eng/mgmt/mgmtmetadata/$_" + "_resource-manager.txt"
        if ($mataPath -notcontains $path) {
            $mataPath += $path
        }
    }

    # Install AutoRest    
    Invoke-Block {
        & npm install -g autorest
    }

    # Invoke AutoRest
    Write-Output "Start code-gen"
    foreach ($metaData in $mataPath) {
        $metaDataContent = ''
        try {
            $metaDataContent = Get-Content $metaData
        }
        catch {
            LogError "Can't find path $metaData, you may need to re-run sdk\<RP_Name>\generate.ps1"
        }

        if ( $metaDataContent -ne '') {
            $commit = ''
            $readme = ''
            [string]$path = Get-Location
            $metaDataContent | ForEach-Object {
                if ($_ -match 'Commit') {
                    $commit = $_.substring($_.length - 40, 40)
                }
                if ($_ -match 'cmd.exe') {
                    $_ -match 'https:[\S]*readme.md'
                    $readme = $matches[0]
                }
            }
            $readme = $readme -replace "blob/[\S]*/specification", "blob/$commit/specification"
            $path = ($path -replace "\\", "/") + "/sdk"

            if ($readme -eq '') {
                LogError "MetaData $metaData content not correct, you may need to re-run sdk\<RP_Name>\generate.ps1"
            }
            else {
                Write-Output "Ready to execute: autorest $readme --csharp --version=v2 --reflect-api-versions --csharp-sdks-folder=$path --use:@microsoft.azure/autorest.csharp@2.3.90"
                Invoke-Block {
                    & autorest $readme --csharp --version=v2 --reflect-api-versions --csharp-sdks-folder=$path --use:@microsoft.azure/autorest.csharp@2.3.90 
                }
            }
        }
    }
    
    # prevent warning related to EOL differences which triggers an exception for some reason
    Write-Output "Start git diff"
    & git add -A
    $diffResult = @()
    $diffResult += git -c core.safecrlf=false diff HEAD --name-only --ignore-space-at-eol

    foreach ($item in $diffResult) {
        if ($item -notmatch 'SdkInfo_') {
            $exitCode ++
        }
        else {
            $changeContent = @()
            $content = git -c core.safecrlf=false diff -U0 HEAD --ignore-space-at-eol $diffResult[0]
            $content[4..($content.Length - 1)] | ForEach-Object {
                if ($_.StartsWith('+') -or $_.StartsWith('-')) {
                    $changeContent += $_
                }
            }
            if ($changeContent.Length -ne 11) {
                $exitCode ++
            }
    
            # metaDataContent doesn't contains 'AutoRestCmdExecuted' part since it can't be verified
            $metaDataContent = @('-      // BEGIN: Code Generation Metadata Section',
                '-      public static readonly String AutoRestVersion = "v2";',
                '-      public static readonly String AutoRestBootStrapperVersion = "autorest@2.0.4413";',
                '-      public static readonly String GithubForkName = "Azure";',
                '-      public static readonly String GithubBranchName = "master";',
                '-      public static readonly String GithubCommidId = "{0}";'.Replace('{0}', $commit),
                '-      public static readonly String CodeGenerationErrors = "";',
                '-      public static readonly String GithubRepoName = "azure-rest-api-specs";',
                '-      // END: Code Generation Metadata Section'
            )
            foreach ($metaString in $metaDataContent) {
                if ($metaString -notin $changeContent) {
                    Write-Output "Diff in" $metaString
                    $exitCode ++
                    break
                }
            }
        }
    }
    
    if ($exitCode -ne 0) {
        Write-Output "Git Diff file is:" 
        $diffResult | ForEach-Object {
            Write-Output $_
        }
        LogError "Generated code is manually altered, you may need to re-run sdk\<RP_Name>\generate.ps1"
    }
}
finally {
    Write-Host ""
    Write-Host "Summary:"
    Write-Host ""
    Write-Host "   $($errors.Length) error(s)"
    Write-Host ""

    foreach ($err in $errors) {
        Write-Host -f Red "error : $err"
    }

    if ($errors) {
        exit 1
    }
}
