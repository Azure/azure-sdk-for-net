# Basic test, some generate.ps1s explicitly provide the Sdk repo root directory
Import-Module "$PSScriptRoot\..\..\..\..\..\AutoRestCodeGenerationModule.psm1"
$p = [System.IO.Path]::GetTempPath()
$genDir = "$p\test6"
if(Test-Path -Path $genDir)
{
	Remove-Item $genDir -Force -Recurse
}
md $genDir
Start-AutoRestCodeGeneration -ResourceProvider "compute/resource-manager" -AutoRestVersion "latest" -SdkRepoRootPath $genDir