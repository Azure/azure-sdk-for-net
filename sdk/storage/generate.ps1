pushd $PSScriptRoot/Azure.Storage.Common/swagger/Generator/
npm install

cd $PSScriptRoot/Azure.Storage.Blobs/swagger/
npx autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

cd $PSScriptRoot/Azure.Storage.Files.Shares/swagger/
npx autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

cd $PSScriptRoot/Azure.Storage.Queues/swagger/
npx autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

cd $PSScriptRoot/Azure.Storage.Files.DataLake/swagger/
npx autorest --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose

popd
