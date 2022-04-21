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
    
    Write-Host "Check PR associate"
    Write-Host "REPOSITORY_NAME: Azure/azure-sdk-for-net"
	$Env:REPOSITORY_NAME = 'Azure/azure-sdk-for-net'
	$Env:PULLREQUEST_ID = 28319
	
    Write-Host "PULLREQUEST_ID: 28319"
    if (($null -eq $Env:REPOSITORY_NAME) -or ($null -eq $Env:PULLREQUEST_ID) -or ($Env:REPOSITORY_NAME -eq "") -or ($Env:PULLREQUEST_ID -eq "") -or ($Env:PULLREQUEST_ID -match 'PullRequestNumber')) {
        Write-Host "There is no PR associate with this run, skip the code check." -ForegroundColor red -BackgroundColor white
        break
    }

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
        if ($fileName -match '(?<!sdk)/eng/mgmt/mgmtmetadata') {
            $mataPath += $fileName
        }
    }
    $changeList | ForEach-Object {
        $fileName = $_.filename
        if ($fileName -match 'sdk/' -and $fileName -match '/Microsoft.Azure.Management') {
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

    # Running autorest first time to avoid C# version conflict
    & autorest https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/common-types/resource-management/v2/types.json --csharp --version=v2 --reflect-api-versions --csharp-sdks-folder=../temp

    # Invoke AutoRest
    Write-Output "Start code-gen"
    $commandList = @()
    foreach ($metaData in $mataPath) {
        $metaDataContent = ''
        try {
            $metaDataContent = Get-Content $metaData
        }
        catch {
            LogError "Can't find path $metaData, you may need to re-run sdk\<RP_Name>\generate.ps1"
        }

        if (-not [string]::IsNullOrWhiteSpace($metaDataContent)) {
            $commit = @()
            $csharpVersion = @()
            $cmds = @()
            [string]$path = Get-Location
            $path = ($path -replace "\\", "/") + "/sdk"

            $metaDataContent | ForEach-Object {
                if ($_ -match 'Commit') {
                    $commit += $_.substring($_.length - 40, 40)
                }
                if ($_ -match 'cmd.exe') {
                    $cmds += $_
                }
                if ($_ -match 'Autorest CSharp Version') {
                    $version = $_.substring(25)
                    if ([System.Version]$version -ge [System.Version]"2.3.82") {
                        $csharpVersion += $version
                    }
                    else {
                        LogError "Validation failed, csharp extension minimal version is 2.3.82, your current version is $version, please use another version"
                        $exitCode ++
                        break
                    }
                }
            }

            if ($csharpVersion.length -eq 0) {
                Write-Host "Start-AutoRestCodeGeneration command is not updated, please sync the latest code and run command: `msbuild mgmt.proj /t:Util /p:UtilityName=InstallPsModules` to get update" -ForegroundColor red -BackgroundColor white
                for ($i = 0; $i -lt $cmds.Count; $i++) {
                    $csharpVersion += "2.3.82"  
                }
            }

            if (($cmds.length -eq 0) -or ($commit.length -eq 0) -or ($csharpVersion.length -eq 0) -or ($cmds.length -ne $commit.length) -or ($commit.length -ne $csharpVersion.length) -or (($commit -eq $commit[0]).Count -ne $commit.Count)) {
                LogError "MetaData $metaData content not correct, you may need to re-run sdk\<RP_Name>\generate.ps1"
                LogError "Make sure you have installed the latest `Start-AutoRestCodeGeneration` module, run command: `msbuild mgmt.proj /t:Util /p:UtilityName=InstallPsModules` to get update"
                break
            }
            else {
                for ($i = 0; $i -lt $cmds.Count; $i++) {
                    $command = "autorest" + $cmds[$i].substring(23)
                    $command = $command -replace "\\", "/"
                    $command = $command -replace "blob/[\S]*/specification", ("blob/" + $commit[$i] + "/specification")
                    $command = $command -replace "--csharp-sdks-folder\=(.*)sdk[\s]*", "--csharp-sdks-folder=$path "
                    $cmds[$i] = $command + " --use:@microsoft.azure/autorest.csharp@" + $csharpVersion[$i]
                }
               $commandList += $cmds
            }
        }
    }

    foreach ($command in $commandList) {
        Try {
            Write-Output "Executing AutoRest command"
            Write-Output $command
            Invoke-Block {
                Invoke-Expression $command
            }
        }
        Catch [System.Exception] {
            LogError $_.Exception.ToString()
            throw [System.Exception] "AutoRest code generation for metadata failed. you may need to re-run sdk\<RP_Name>\generate.ps1"
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
    }
    
    if ($exitCode -ne 0) {
        Write-Output "Git Diff file is:" 
        $diffResult | ForEach-Object {
            Write-Output $_
        }
        Write-Output "Git Diff detail: "
        git -c core.safecrlf=false diff HEAD --ignore-space-at-eol
        Write-Host "============================"
        LogError "Discrepancy detected between generated code in PR and reference generation. Please note, the files in the Generated folder should not be modified OR adding/excluding files. You may need to re-run sdk<RP_Name>\generate.ps1."
        Write-Host "============================"
        Write-Host "For reference, we are using following commands for the code check: " -ForegroundColor red -BackgroundColor white
        $commandList | ForEach-Object {
            Write-Host $_ -ForegroundColor red -BackgroundColor white
        }
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
