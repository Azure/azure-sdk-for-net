foreach($volume in Get-Volume) {
    if($null -ne $volume.DriveLetter) {
       $entry = [ordered]@{
        "name"= "agent_disk_size_bytes";
        "value"= $volume.Size;
        "timestamp"= [DateTimeOffset]::UtcNow;
        "labels"= [ordered]@{
          "driveLetter"= $volume.DriveLetter;
          "fileSystemLabel"= $volume.FileSystemLabel;
          "fileSystemType"= $volume.FileSystemType;
        }
      }

      Write-Output "logmetric: $($entry | ConvertTo-Json -Compress)"

      $entry = [ordered]@{
        "name"= "agent_disk_remaining_bytes";
        "value"= $volume.SizeRemaining;
        "timestamp"= [DateTimeOffset]::UtcNow;
        "labels"= [ordered]@{
          "driveLetter"= $volume.DriveLetter;
          "fileSystemLabel"= $volume.FileSystemLabel;
          "fileSystemType"= $volume.FileSystemType;
        }
      }

      Write-Output "logmetric: $($entry | ConvertTo-Json -Compress)"
    }
}