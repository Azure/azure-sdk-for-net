# Running Start-AutoRestCodeGeneration will overwrite the files present in SdkGenerationDirectory based on AutoRestCodeGenerationFlags
# As ARM has multiple tag packages, it is safer to first Generate the files in a different directory 
# and copy these new set of files to the main Generated folder. This way exisiting files will not be deleted.

# Generate package with resources tag
Start-AutoRestCodeGeneration -ResourceProvider "security/resource-manager" -SdkRepoRootPath "$PSScriptRoot\..\..\..\.." -AutoRestVersion "v2" -SdkGenerationDirectory "$PSScriptRoot\Generated\Resources"