pushd $PSScriptRoot/Azure.Storage.Common/swagger/Generator/
npm install
popd

autorest $PSScriptRoot/Azure.Storage.Blobs/swagger/readme.md  --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose
autorest $PSScriptRoot/Azure.Storage.Files/swagger/readme.md  --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose
autorest $PSScriptRoot/Azure.Storage.Queues/swagger/readme.md --use=$PSScriptRoot/Azure.Storage.Common/swagger/Generator/ --verbose
