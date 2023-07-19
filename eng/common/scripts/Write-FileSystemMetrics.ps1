$drives = [IO.DriveInfo]::GetDrives() | Where-Object { $_.TotalSize -gt 0 -and $_.DriveType -eq 'Fixed' -and $null -ne $_.Name }

foreach($drive in $drives) {
    $entry = [ordered]@{
      "name"= "agent_driveinfo_size_bytes";
      "value"= $drive.TotalSize;
      "timestamp"= [DateTimeOffset]::UtcNow;
      "labels"= [ordered]@{
        "name"= $drive.Name;
        "volumeLabel"= $drive.VolumeLabel;
        "driveType"= $drive.DriveType.ToString();
        "driveFormat"= $drive.DriveFormat;
      }
    }

    Write-Output "logmetric: $($entry | ConvertTo-Json -Compress)"

    $entry = [ordered]@{
      "name"= "agent_driveinfo_available_bytes";
      "value"= $drive.AvailableFreeSpace;
      "timestamp"= [DateTimeOffset]::UtcNow;
      "labels"= [ordered]@{
        "name"= $drive.Name;
        "volumeLabel"= $drive.VolumeLabel;
        "driveType"= $drive.DriveType.ToString();
        "driveFormat"= $drive.DriveFormat;
      }
    }

    Write-Output "logmetric: $($entry | ConvertTo-Json -Compress)"
}