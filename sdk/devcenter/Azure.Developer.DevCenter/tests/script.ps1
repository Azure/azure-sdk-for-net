param (
    [string]$folderPath
)

# Define the regular expression pattern to find GUIDs in the "users/" path
$findPattern = "users/[\w-]+"

# Replace "users/" with "users/meme" and keep the rest of the path intact
$replaceText = {
    param($match)
    return $match.Value -replace 'users/', 'users/meme'
}

# Define a function to replace text in a file
function Replace-TextInFile {
    param (
        [string]$filePath
    )

    try {
        # Read the content of the file
        $fileContent = Get-Content -Path $filePath -Raw

        # Perform the replacement using regular expressions
        $newContent = [regex]::Replace($fileContent, $findPattern, $replaceText)

        # Write the modified content back to the file
        $newContent | Set-Content -Path $filePath
    }
    catch {
        Write-Host "Error processing file: $filePath"
        Write-Host $_.Exception.Message
    }
}

# Recursively iterate over files and folders
Get-ChildItem -Path $folderPath -File -Recurse | ForEach-Object {
    Replace-TextInFile -filePath $_.FullName
}

Write-Host "Text replacement complete."

