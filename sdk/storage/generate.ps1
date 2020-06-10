pushd $PSScriptRoot/Azure.Storage.Common/swagger/Generator/
npm install
npm install -g autorest@beta

cd $PSScriptRoot/Azure.Storage.Blobs/swagger/
autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

#cd $PSScriptRoot/Azure.Storage.Blobs.Batch/swagger/
#autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

#cd $PSScriptRoot/Azure.Storage.Files.Shares/swagger/
#autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

#cd $PSScriptRoot/Azure.Storage.Queues/swagger/
#autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

#cd $PSScriptRoot/Azure.Storage.Files.DataLake/swagger/
#autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

popd
