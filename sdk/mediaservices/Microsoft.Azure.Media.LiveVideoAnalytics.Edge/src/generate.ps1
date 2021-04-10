[string] $PathToPrivateRepo = "<<LocalPathToPrivateRepo--LVA-Release-do-not-delete--branch>>Azure\azure-rest-api-specs-pr"

autorest.cmd $PathToPrivateRepo\specification\mediaservices\data-plane\readme.md --csharp --version=v2 --reflect-api-versions --csharp-sdks-folder=$PSScriptRoot\..\..\..