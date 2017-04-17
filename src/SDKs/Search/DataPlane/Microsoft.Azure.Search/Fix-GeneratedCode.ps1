# Use this file sparingly. Every modification we make in here, we potentially have to replicate for every target language.
function Replace-InFile($filePath, $oldText, $newText)
{
    (Get-Content $filePath).Replace($oldText, $newText) | Set-Content $filePath
}

$generatedFolder = ".\GeneratedSearchIndex"

# Make all Proxy types internal so we can version them freely.
Replace-InFile $generatedFolder\IDocumentsProxyOperations.cs "public partial interface IDocumentsProxyOperations" "internal partial interface IDocumentsProxyOperations"

# Change the public property on ISearchIndexClient and SearchIndexClient to refer to our public interface instead of the internal one.
Replace-InFile $generatedFolder\ISearchIndexClient.cs "DocumentsProxy" "Documents"
Replace-InFile $generatedFolder\SearchIndexClient.cs "DocumentsProxy" "Documents"
