$ErrorActionPreference = 'Stop'
Set-StrictMode -Version 1
$exitCode=0

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

# helper to turn PSCustomObject into a list of key/value pairs
function Get-ObjectMembers {
    [CmdletBinding()]
    Param(
        [Parameter(Mandatory = $True, ValueFromPipeline = $True)]
        [PSCustomObject]$obj
    )
    $obj | Get-Member -MemberType NoteProperty | ForEach-Object {
        $key = $_.Name
        [PSCustomObject]@{Key = $key; Value = $obj."$key" }
    }
}

try {
    # For pipeline
    #$Response = Invoke-WebRequest -URI https://api.github.com/repos/${env:Build.Repository.Name}/pulls/${env:System.PullRequest.PullRequestId}/files

    $Response = Invoke-WebRequest -URI https://api.github.com/repos/Azure/azure-sdk-for-net/pulls/16267/files
    $changeList = $Response.Content | ConvertFrom-Json
    $rpMapping = Get-Content "./eng/scripts/RPMapping.json" | ConvertFrom-Json
    $mataPath = @()
    $folderName = @()
    $rpIndex = @()

    $changeList | ForEach-Object {
        $fileName = $_.filename
        if ($fileName -match 'eng/mgmt/mgmtmetadata') {
            $mataPath += $fileName
        }
    }

    if ($mataPath.Length -eq 0) {
        $changeList | ForEach-Object {
            $fileName = $_.filename
            if ($fileName -match 'sdk/') {
                $name = $fileName.substring(4, (($fileName.indexof('/Microsoft') - 4)))
                If ($folderName -notcontains $name) {
                    $folderName += $name
                }
            }
        }
        foreach ($item in $folderName) {
            $rpMapping | Get-ObjectMembers | ForEach-Object {
                $value = $_.Value
                if ($value.PSObject.Properties.Name -eq $item) {
                    $rpName = $_.Key
                    If ($rpIndex -notcontains $rpName) {
                        $rpIndex += $rpName
                    }
                }   
            }
        }
        $rpIndex | ForEach-Object {
            $path = "eng/mgmt/mgmtmetadata/$_" + "_resource-manager.txt"
            $mataPath += $path
        }
    }

    $mataPath | ForEach-Object {
        $metaData = Get-Content $mataPath
        $commit = ''
        $readme = ''
        [string]$path = Get-Location
        $metaData | % {
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

        Invoke-Block {
            & npm install -g @autorest/autorest
        }
        
        Invoke-Block {
            & autorest $readme --csharp --version=v2 --reflect-api-versions --csharp-sdks-folder=$path
        }

        # prevent warning related to EOL differences which triggers an exception for some reason
        & git add -A
        $diffResult=@()
        $diffResult = git -c core.safecrlf=false diff HEAD --name-only --ignore-space-at-eol
        if($diffResult.Length -gt 1){
            $exitCode ++
        }
        if(($diffResult.Length -eq 1) -And ($diffResult[0] -match 'SdkInfo_')){
            $content = git -c core.safecrlf=false diff HEAD --ignore-space-at-eol $result[0]
            $content[0..($content.Length-1)] | ForEach-Object {
                if($_.StartsWith('+')){
                    $exitCode ++
                    break
                }
            }
        }

        if ($exitCode -ne 0) {
            $status = git status -s | Out-String
            $status = $status -replace "`n", "`n    "
            LogError "Generated code is not up to date. You may need to run eng\scripts\Update-Snippets.ps1 or sdk\storage\generate.ps1 or eng\scripts\Export-API.ps1"
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
