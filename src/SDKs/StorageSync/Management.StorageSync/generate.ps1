Start-AutoRestCodeGeneration -ResourceProvider "storagesync/resource-manager" -AutoRestVersion "latest" 

#Following script would be used if need to generate code using local swagger specification.
#Start-AutoRestCodeGenerationWithLocalConfig -ResourceProvider "storagesync/resource-manager" -AutoRestVersion "latest" -LocalConfigFilePath "[Root]\azure-rest-api-specs\specification\storagesync\resource-manager\readme.md" -SdkDirectory "[Root]\azure-sdk-for-net\src\SDKs\StorageSync\Management.StorageSync\Generated"