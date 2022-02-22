$ScriptDir = Split-Path -Parent $MyInvocation.MyCommand.Path

autorest $ScriptDir\autorest-resources.md

Remove-Item –path $ScriptDir\..\src\PsuedoGenerated\Resources\Models\CreatedByType.cs
Remove-Item –path $ScriptDir\..\src\PsuedoGenerated\Resources\Extensions\ -recurse

Compare-Object (Get-Content $ScriptDir\..\src\PsuedoGenerated\Resources\ResourceLinkContainer.cs) (Get-Content $ScriptDir\..\src\Custom\Resources\ResourceLinkContainer.cs)
Remove-Item –path $ScriptDir\..\src\PsuedoGenerated\Resources\ResourceLinkContainer.cs
