function Replace-StringBetweenTags()
{
    param(
        [Parameter(Mandatory = $true)]
        [string]$content,

        [Parameter(Mandatory = $true)]
        [string]$startTag,

        [Parameter(Mandatory = $true)]
        [AllowEmptyString()]
        [string]$endTag,

        [Parameter(Mandatory = $true)]
        [AllowEmptyString()]
        [string]$newContent,

        [Parameter(Mandatory = $false)]
        [bool]$encoded = $false
    )

    if ([string]::IsNullOrEmpty($content) -or [string]::IsNullOrEmpty($newContent))
    {
        return $content;
    }

    if (-not $encoded)
    {
        if ((-not $content.Contains($startTag)) -or (-not $content.Contains($endTag)))
        {
            return $content;
        }

        $startIndex = $content.IndexOf($startTag);
        $endIndex = $content.LastIndexOf($endTag);

        if ($startIndex -le $endIndex)
        {
            $result = $content.Substring(0, $startIndex) + ($startTag + $newContent) + $content.Substring($endIndex, $content.Length - $endIndex);
            return $result;
        }
    
        return $content;
    }
    else
    {
        $encodedKeyword = '"EncodedRequestUri": "';
        $encodedLineSuffix = '",';
        $trimmedContent = $content.Trim();

        if ($trimmedContent.StartsWith($encodedKeyword) -and $trimmedContent.EndsWith($encodedLineSuffix))
        {
            $encodedContent = $trimmedContent.Substring($encodedKeyword.Length);
            $encodedContent = $encodedContent.Substring(0, $encodedContent.Length - $encodedLineSuffix.Length);
        }
        else
        {
            return $content;
        }

        $decodedContent = [System.Text.Encoding]::UTF8.GetString([System.Convert]::FromBase64String($encodedContent));

        if ((-not $decodedContent.Contains($startTag)) -or (-not $decodedContent.Contains($endTag)))
        {
            return $content;
        }

        $startIndex = $decodedContent.IndexOf($startTag);

        if ([string]::IsNullOrEmpty($endTag))
        {
            $endIndex = $decodedContent.Length;
        }
        else
        {
            $endIndex = $decodedContent.LastIndexOf($endTag);
        }

        if ($startIndex -le $endIndex)
        {
            $newDecodedContent = $decodedContent.Substring(0, $startIndex) + ($startTag + $newContent) + $decodedContent.Substring($endIndex, $decodedContent.Length - $endIndex);

            $decodedBytes = [System.Text.Encoding]::UTF8.GetBytes($newDecodedContent);
            $reEncodedContent =[Convert]::ToBase64String($decodedBytes);
            $paddingSpaces = '      ';
            $reEncodedContent = $paddingSpaces + $encodedKeyword + $reEncodedContent + $encodedLineSuffix;

            $st = Write-Verbose ("--------------------------------------------");
            $st = Write-Verbose ("Search Content:");
            $st = Write-Verbose ("`$encodedContent = '" + $encodedContent + "'");
            $st = Write-Verbose ("`$decodedContent = '" + $decodedContent + "'");
            $st = Write-Verbose ("`$startTag = '" + $startTag + "'");
            $st = Write-Verbose ("`$endTag = '" + $endTag + "'");
            $st = Write-Verbose ("`$startIndex = " + $startIndex);
            $st = Write-Verbose ("`$endIndex = " + $endIndex);
            $st = Write-Verbose ("`$newDecodedContent = " + $newDecodedContent);
            $st = Write-Verbose ("`$reEncodedContent = " + $reEncodedContent);
            $st = Write-Verbose ("--------------------------------------------");

            return $reEncodedContent;
        }
        else
        {
            return $content;
        }
    }
}

function Mock-FileContent()
{
    param(
        [Parameter(Mandatory = $true)]
        [string]$filePath,

        [Parameter(Mandatory = $true)]
        [string]$startTag,

        [Parameter(Mandatory = $true)]
        [AllowEmptyString()]
        [string]$endTag,

        [Parameter(Mandatory = $true)]
        [AllowEmptyString()]
        [string]$newContent,

        [Parameter(Mandatory = $false)]
        [bool]$encoded = $false
    )

    if (Test-Path $filePath)
    {
        $st = Write-Verbose ("============================================");
        $st = Write-Verbose ("Parameters:");
        $st = Write-Verbose ("`$filePath   = '" + $filePath + "'");
        $st = Write-Verbose ("`$startTag   = '" + $startTag + "'");
        $st = Write-Verbose ("`$endTag     = '" + $endTag + "'");
        $st = Write-Verbose ("`$newContent = '" + $newContent + "'");
        $st = Write-Verbose ("`$encoded    = '" + $encoded + "'");
        $st = Write-Verbose ("============================================");

        $lines = Get-Content -Path $filePath;
        $newLines = @();

        foreach ($line in $lines)
        {
            $newLine = Replace-StringBetweenTags $line $startTag $endTag $newContent $encoded;
            $newLines += $newLine;
        }

        $st = Set-Content -Path $filePath -Value $newLines;
        $st = Write-Verbose ('Finished.');
    }
    else
    {
        $st = Write-Verbose ('The record file does not exist: ' + $filePath);
        $st = Write-Verbose ('Exit');
    }
}

$scriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition;
$recordFolder = '\SessionRecords\Microsoft.WindowsAzure.Management.Compute.Testing.VirtualMachineReproTests'

# Min Max DateTime Test
$minMaxDateTestRecordFile = $scriptRoot + $recordFolder + '\CanCreateVMAndGetDeploymentWithMaxDate.json';
Mock-FileContent $minMaxDateTestRecordFile '<CreatedTime>' '</CreatedTime>' '0001-01-01T00:00:00Z';
Mock-FileContent $minMaxDateTestRecordFile '<LastModifiedTime>' '</LastModifiedTime>' '9999-12-31T23:59:59Z';

# Deployment Event Test
$deploymentEventTestRecordFile = $scriptRoot + $recordFolder + '\CanUpdateVMInputEndpoints.json';
Mock-FileContent $deploymentEventTestRecordFile '/events?' '",' 'starttime=2015-01-10T08:00:00.0000000Z&endtime=2015-01-20T08:00:00.0000000Z';
Mock-FileContent $deploymentEventTestRecordFile '/events?' '' 'starttime=2015-01-10T08%3A00%3A00.0000000Z&endtime=2015-01-20T08%3A00%3A00.0000000Z' $true;
