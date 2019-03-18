#Start-AutoRestCodeGeneration -ResourceProvider "graphrbac/data-plane" -AutoRestVersion "latest"
Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider "graphrbac/data-plane" -AutoRestVersion "latest" -LocalConfigFilePath "C:\code\azure-rest-api-specs\specification\graphrbac\data-plane\readme.md" -SdkDirectory "c:\graph\azure-sdk-for-net\src\SDKs\Graph.RBAC\Graph.RBAC\Generated"
