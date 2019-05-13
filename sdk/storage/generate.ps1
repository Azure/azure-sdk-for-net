pushd $PSScriptRoot/Swagger/Generator
npm install
popd

autorest $PSScriptRoot/Swagger/Blobs/readme.md --use=$PSScriptRoot/Swagger/Generator/ --verbose
autorest $PSScriptRoot/Swagger/Files/readme.md --use=$PSScriptRoot/Swagger/Generator/ --verbose
autorest $PSScriptRoot/Swagger/Queues/readme.md --use=$PSScriptRoot/Swagger/Generator/ --verbose
