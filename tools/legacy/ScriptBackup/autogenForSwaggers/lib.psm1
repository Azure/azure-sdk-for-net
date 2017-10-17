function Remove-All {
    param([string]$path)

    If (Test-Path $path){
	    Remove-Item $path -Recurse -Force
    }
}

function New-Dir {
    param([string]$path)

    New-Item -Path $path -ItemType Directory | Out-Null
}

function Clear-Dir {
    param([string]$path)

    Remove-All -path $path
    New-Dir -path $path
}

function Set-Default {
    param([psobject] $object, [string] $member, $value)

    if (-Not ($object | Get-Member -Name $member))
    {
        $object | Add-Member -type NoteProperty -name $member -value $value
    }
}

function Update-SdkInfo {
    param([psobject] $info, [string] $commit)

    # isArm
    Set-Default -object $info -member isArm -value $info.name.StartsWith("arm-")

    # isComposite
    $isComposite = $info.sources | Where-Object {$_.StartsWith("composite") }
    Set-Default -object $info -member isComposite -value $isComposite

    # dotNet
    $dotNet = New-Object -TypeName PSObject
    Set-Default -object $info -member dotNet -value $dotNet
    $dotNet = $info.dotNet

    # dotNet.ft
    Set-Default -object $dotNet -member ft -value 0

    # dotNet.name
    $dotNetName = $info.name.Split("/")[0]
    $dotNetName = If ($info.isArm) { $dotNetName.SubString(4) } Else { $dotNetName }
    $dotNetNameArray = $dotNetName.Split("-") | ForEach-Object {$_.SubString(0, 1).ToUpper() + $_.SubString(1)}
    Set-Default -object $dotNet -member name -value ([string]::Join(".", $dotNetNameArray))

    # dotNet.folder
    Set-Default -object $dotNet -member folder -value $dotNet.name

    # dotNet.output
    $prefix = If ($info.isArm) { "Management." } Else { "dataPlane\Microsoft.Azure." }
    Set-Default -object $dotNet -member output -value "$prefix$($dotNet.name)\Generated"

    # dotNet.test
    $test = "$($dotNet.name).Tests"
    Set-Default -object $dotNet -member test -value "$test\$test.csproj"

    # dotNet.namespace
    $prefix = If ($info.isArm) { "Management." } Else { "" }
    Set-Default -object $dotNet -member namespace -value "Microsoft.Azure.$prefix$($dotNet.name)"

    # dotNet.commit
    Set-Default -object $dotNet -member commit -value $commit
}

function Read-SdkInfoList {
    param([string] $project, [string] $sdkInfo, [string] $commit)

    $array = Get-Content $sdkInfo | Out-String | ConvertFrom-Json
    $array = $array | Where-Object { $_.name -like $project }

    if (-Not $array)
    {
        throw "unknown project $project"
    }

    $array | ForEach-Object { Update-SdkInfo $_ $commit }

    return $array
}

function Get-DotNetPath {
    param([string] $sdkDir, [psobject]$dotNet, [string]$folder)

    Join-Path $sdkDir "src\SDKs\$($dotNet.folder)\$folder"
}

function Get-SourcePath {
    param([string] $specs, [psobject]$info, [string]$source)

    if (Is-Url -specs $specs) {
        "$specs/$($info.name)/$source"
    } else {
        Join-Path (Join-Path $specs $info.name) $source
    }
}

function CallAutoRest {
    param([psobject] $info, [bool] $jsonRpc, [string] $title, [string[]] $inputList)

    $dotNet = $info.dotNet

    $autoRestExe = "autorest"
    $lang = if ($jsonRpc) { "jsonrpcclient" } else { "csharp" }
    $r = @(
        "--$lang.azure-arm",
        "--namespace=$($dotNet.namespace)",
        "--output-folder=$output",
        "--license-header=MICROSOFT_MIT",
        "--payload-flattening-threshold=$($dotNet.ft)"
    )

    if ($title) {
        $r += "--override-info.title=$title"
    }

    $inputList | ForEach-Object {
        $input = Get-SourcePath -specs $specs -info $info -source $_
        $r += "--input-file=$input"
    }

    $r
    & $autoRestExe $r
    if (-Not $?) {
        Write-Error "generation errors"
        exit $LASTEXITCODE
    }
}

function Generate-Sdk {
    param([string] $specs, [psobject] $info, [string] $sdkDir, [bool] $jsonRpc)

    $dotNet = $info.dotNet

    $info

    "Generating SDK..."

    "AutoRest: $($dotNet.autorest)"
    if ($dotNet.autorest) {
        # get a specific version of AutoRest
        $index = $dotNet.autorest.IndexOf('.')
        $package = $dotNet.autorest.SubString(0, $index)
        $version = $dotNet.autorest.SubString($index + 1)
        $packages = Join-Path $sdkDir "packages"
        $autoRestExe = Join-Path $packages "$($dotNet.autorest)\tools\AutoRest.exe"
        $r = @(
            "install",
            $package,
            "-Version",
            $version,
            "-o",
            $packages
        )
        if ($version.Contains("-"))
        {
            $r += "-Source"
            $r += "https://www.myget.org/F/autorest/api/v2"
        }
        $r
        $tools = Join-Path $sdkDir "tools\nuget.exe"
        & $tools $r
        if (-Not $?) {
            Write-Error "autorest restore errors"
            exit $LASTEXITCODE
        }
    } else {
        $autoRestExe = "autorest"
    }

    $commit = if ($dotNet.commit) { $dotNet.commit } else { "master" }

    $isUrl = Is-Url -specs $specs
    "Commit: $commit"
    if ($isUrl) {
        $specs = $specs.Replace('https://github.com/', 'https://raw.githubusercontent.com/')
        $specs = "$specs/$commit"
    }

    "Clear $output"
    $output = Get-DotNetPath -sdkDir $sdkDir -dotNet $dotNet -folder $dotNet.output
    Clear-Dir -path $output

    $title = $dotNet.client
    if ($dotNet.autorest) {
        if ($jsonRpc) {
            Write-Error "JSON RPC is not supported for $($info.name)"
            exit -1
        }
        # Run AutoRest for all sources.
        $info.sources | ForEach-Object {
            $modeler = if ($info.isComposite) { "CompositeSwagger" } else { "Swagger" }
            $input = Get-SourcePath -specs $specs -info $info -source $_
            $r = @(
                "-Modeler",
                $modeler,
                "-CodeGenerator",
                "Azure.CSharp",
                "-Namespace",
                $dotNet.namespace,
                "-outputDirectory",
                $output,
                "-Header",
                "MICROSOFT_MIT",
                "-ft",
                $dotNet.ft,
                "-Input",
                $input
            )
            if ($title) {
                $r += "-name"
                $r += $title
            }
            $r
            & $autoRestExe $r
            if (-Not $?) {
                Write-Error "generation errors"
                exit $LASTEXITCODE
            }
        }
    } elseif ($info.isLegacy) {
        # Run AutoRest for all sources.
        $info.sources | ForEach-Object {
            CallAutoRest -info $info -inputList @( $_ ) -jsonRpc $jsonRpc -title $title
        }
    } else {
        $inputList = @()
        if ($info.isComposite) {
            $info.sources | ForEach-Object {
                $compositeDir = Split-Path -Path $_ -Parent
                $compositeInput = Get-SourcePath -specs $specs -info $info -source $_
                $compositeStr = if (Is-Url -specs $specs) {
                    $web = New-Object Net.WebClient
                    $web.DownloadString($compositeInput)
                } else {
                    Get-Content $compositeInput | Out-String
                }
                $composite = $compositeStr | ConvertFrom-Json
                $composite.documents | ForEach-Object {
                    $inputList += "$compositeDir/$_"
                }
                if(-Not $title) {
                    $title = $composite.info.title
                }
            }
        } else {
            $info.sources | ForEach-Object {
                $inputList += $_
            }
        }
        CallAutoRest -info $info -inputList $inputList -jsonRpc $jsonRpc -title $title
    }
}

function Build-Project {
    param([string] $project, [string] $sdkDir)

    $p = Join-Path (Join-Path (Get-Location) $sdkDir) "tools/autogenForSwaggers/jsonrpc.targets"
    $p = [System.IO.Path]::GetFullPath($p)

    "Restoring test project NuGet packages..."
    dotnet restore $project
    dotnet restore $project -s "https://ci.appveyor.com/nuget/rest-client-runtime-test-net-p-lft6230b45rt" /p:CustomAfterMicrosoftCommonTargets=$p

    "& dotnet build $project /p:CustomAfterMicrosoftCommonTargets=$p"
    & dotnet build $project /p:CustomAfterMicrosoftCommonTargets=$p
    if (-Not $?) {
        Write-Error "build errors"
        exit $LASTEXITCODE
    }
}

function Get-DotNetTest {
    param([string] $sdkDir, [psobject] $dotNet)

    Get-DotNetPath -sdkDir $sdkDir -dotNet $dotNet -folder $dotNet.test
}

function Get-DotNetTestList {
    param([string] $sdkDir, [psobject] $infoList)

    return $infoList | ForEach-Object { Get-DotNetTest -sdkDir $sdkDir -dotNet $_.dotNet } | Get-Unique
}

function Is-Url {
    param([string] $specs)

    return $specs.StartsWith("http")
}

function Get-SdkInfoPath {
    param([string] $sdkDir, [string] $fileName = "sdkinfo.json")

    Join-Path (Join-Path $sdkDir "tools\autogenForSwaggers") $fileName
}

function Get-SdkInfoLockPath {
    param([string] $sdkDir)

    Get-SdkInfoPath -sdkDir $sdkDir -fileName "sdkinfo.lock.json"
}

function GenerateAndBuild {
    param([string] $project, [string] $specs, [string] $sdkDir, [bool] $jsonRpc)

    $sdkInfoLock = Get-SdkInfoLockPath -sdkDir $sdkDir

    $infoList = Read-SdkInfoList -project $project -sdkInfo $sdkInfoLock

    $infoList | ForEach-Object {
        Generate-Sdk -sdkDir $sdkDir -specs $specs -info $_ -jsonRpc $jsonRpc
    }

    $testProjectList = Get-DotNetTestList -sdkDir $sdkDir -infoList $infoList

    $testProjectList | ForEach-Object { Build-Project -sdkDir $sdkDir -project $_ }
}

function TestSdk {
    param([string] $project, [string] $sdkDir)

    $sdkInfoLock = Get-SdkInfoLockPath -sdkDir $sdkDir

    $infoList = Read-SdkInfoList -project $project -sdkInfo $sdkInfoLock

    $testProjectList = Get-DotNetTestList -sdkDir $sdkDir -infoList $infoList

    $testProjectList | ForEach-Object {
        "Testing $_"
        dotnet test -l trx $_
        if (-Not $?)
        {
            Write-Error "test errors"
            exit $LASTEXITCODE
        }
    }
}

function UpdateSdkInfo {
    param([string] $specs, [string] $sdkDir)

    $commit = if (Is-Url -specs $specs) {
        $line = git ls-remote $specs master
        $line.Split("`t")[0]
    } else {
        $location = Get-Location
        Set-Location $specs
        git rev-parse HEAD
        Set-Location $location
    }

    $sdkinfo = Read-SdkInfoList -project "*" -sdkInfo (Get-SdkInfoPath $sdkDir) -commit $commit

    $sdkInfo | ConvertTo-Json | Out-File (Get-SdkInfoLockPath $sdkDir) -Encoding "UTF8"
}

Export-ModuleMember -Function Read-SdkInfoList
Export-ModuleMember -Function Generate-Sdk
Export-ModuleMember -Function Build-Project
Export-ModuleMember -Function Get-DotNetTestList
Export-ModuleMember -Function Is-Url
Export-ModuleMember -Function GenerateAndBuild
Export-ModuleMember -Function Get-SdkInfoPath
Export-ModuleMember -Function Get-SdkInfoLockPath
Export-ModuleMember -Function TestSdk
Export-ModuleMember -Function UpdateSdkInfo