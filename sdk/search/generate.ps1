#
# Generate Azure.Search.Documents
#
Push-Location $PSScriptRoot/Azure.Search.Documents/src/

# We're doing a copy instead of a reference until we can merge them together
# because AutoRest doesn't play well with two remote swagger files.  (We only
# warn on failure so offline regeneration plays nicely for those of us coding
# on the bus.)
Write-Output "Copying latest swagger files..."
Invoke-WebRequest https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchindex.json `
    -OutFile ./swagger/searchindex.json `
    -ErrorAction Continue
Invoke-WebRequest https://raw.githubusercontent.com/Azure/azure-rest-api-specs/master/specification/search/data-plane/Azure.Search/preview/2019-05-06-preview/searchservice.json `
    -OutFile ./swagger/searchservice.json `
    -ErrorAction Continue

Write-Output "Generating Azure.Search.Documents..."
dotnet msbuild /t:GenerateCode

Pop-Location
