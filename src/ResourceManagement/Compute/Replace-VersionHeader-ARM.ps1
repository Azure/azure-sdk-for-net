<# 

$baseFolder = '.\Compute.Tests\SessionRecords';

Replace-VersionHeader -baseFolder $baseFolder -oldHeader '2015-06-15' -newHeader '2016-03-30' -component 'Compute';

Replace-VersionHeader -baseFolder $baseFolder -oldHeader '2014-12-01-preview' -newHeader '2015-05-01-preview' -component 'Storage';

Replace-VersionHeader -baseFolder $baseFolder -oldHeader '2015-05-01-preview' -newHeader '2015-06-15' -component 'Network';

#>

function Replace-VersionHeader
{    
    param([string] $baseFolder, [string] $oldHeader, [string] $newHeader, [string] $component = $null)

    $rpNameMatch = "*Microsoft.$component*";
    $clientNameMatch = "*Microsoft.Azure.Management.$component.$component*Client*";

    $jsonFiles = dir $baseFolder -Recurse -Filter '*.js*';
    
    foreach ($file in $jsonFiles)
    {
        Write-Verbose $file;

        $filePath = $file.FullName;
        $text = Get-Content -Path $filePath;
        $i = 0;
        foreach ($line in $text)
        {
            if ((($line -like '*"RequestUri":*') -or ($line -like '*operations*')) -and ($line -like $rpNameMatch))
            {
                # Replace RequestUri
                if ($component.ToLower() -eq 'network')
                {
                    $line = $line -replace 'microsoft.network', 'Microsoft.Network';
                }

                $text[$i] = $line -replace $oldHeader, $newHeader;
            }
            elseif ($line -like '*"EncodedRequestUri":*')
            {
                # Replace EncodedRequestUri
                $startIndex = $line.IndexOf('": "') + 4;
                $endIndex = $line.LastIndexOf('",');

                $encoded = $line.Substring($startIndex, $endIndex - $startIndex);
                $b = [System.Convert]::FromBase64String($encoded);
                $decoded = [System.Text.Encoding]::UTF8.GetString($b);

                if ($decoded -like $rpNameMatch)
                {
                    if ($component.ToLower() -eq 'network')
                    {
                        $decoded = $decoded -replace 'microsoft.network', 'Microsoft.Network';
                    }

                    $str = $decoded -replace $oldHeader, $newHeader;
                    $b = [System.Text.Encoding]::UTF8.GetBytes($str);
                    $encoded = [System.Convert]::ToBase64String($b);
                    $text[$i] = '      "EncodedRequestUri": "' + $encoded + '",';
                }
            }
            elseif ($line -like "*/Microsoft.${component}/*?api-version=$oldHeader*")
            {
                $text[$i] = $line -replace $oldHeader, $newHeader;
            }
            elseif ($component.ToLower() -eq 'compute')
            {
                # Replace Others
                if ($line -like '*status*startTime*')
                {
                    $text[$i] = $line -replace '"ResponseBody": "{\\r\\n  \\"id\\":', '"ResponseBody": "{\r\n  \"operationId\":';
                }
                elseif (($line -like '*x-ms-version*') -and ($text[$i + 1] -like "*$oldHeader*") -and ($text[$i + 4] -like $clientNameMatch))
                {
                    $text[$i] = "";
                }
                elseif (($line -like "*$oldHeader*") -and ($text[$i + 3] -like $clientNameMatch))
                {
                    $text[$i] = "";
                }
                elseif (($line -like '*],*') -and ($text[$i - 1] -eq "") -and ($text[$i + 2] -like $clientNameMatch))
                {
                    $text[$i] = "";
                }
            }
            elseif ($component.ToLower() -eq 'network')
            {
                # Replace Others
                if ($line -like '*status*startTime*')
                {
                    # $text[$i] = $line -replace '"ResponseBody": "{\\r\\n  \\"id\\":', '"ResponseBody": "{\r\n  \"operationId\":';
                }
                elseif (($line -like '*x-ms-version*') -and ($text[$i + 1] -like "*$oldHeader*") -and ($text[$i + 4] -like $clientNameMatch))
                {
                    # $text[$i] = "";
                }
                elseif (($line -like "*$oldHeader*") -and ($text[$i + 3] -like $clientNameMatch))
                {
                    $text[$i] = $line -replace $oldHeader, $newHeader;
                }
                elseif (($line -like '*],*') -and ($text[$i - 1] -eq "") -and ($text[$i + 2] -like $clientNameMatch))
                {
                    # $text[$i] = "";
                }
            }

            $i++;
        }

        Set-Content -Path $filePath -Value $text;
    }
}
