#Start-AutoRestCodeGeneration -ResourceProvider "graphrbac/data-plane" -AutoRestVersion "latest"
Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider "graphrbac/resource-manager" -AutoRestVersion "latest" -LocalConfigFilePath "C:\code\azure-rest-api-specs\specification\graphrbac\data-plane\readme.md" -SdkDirectory "c:\graph\azure-sdk-for-net\src\SDKs\Graph.Rbac\Graph.Rbac\Generated"
