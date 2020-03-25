pushd $PSScriptRoot/Azure.Storage.Common/swagger/Generator/
npm install

cd $PSScriptRoot/Azure.Storage.Blobs/swagger/
autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

cd $PSScriptRoot/Azure.Storage.Files/swagger/
autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

cd $PSScriptRoot/Azure.Storage.Queues/swagger/
autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

popd
