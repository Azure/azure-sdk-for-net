param([string] $project = '*', [string] $sdkDir = "..\..")

Import-Module "./lib.psm1"

TestSdk -project $project -sdkDir $sdkDir
