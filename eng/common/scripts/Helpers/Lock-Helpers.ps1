function FileLockEnter([string]$FilePath) {
    $FilePath = Resolve-Path $FilePath
    while (Test-Path -Path $FilePath) {
        Start-Sleep -Seconds 5
    }

    try {
        New-item -Path $FilePath
    }
    catch {
        # This means another process already create this lock file, so try to acquire the lock again.
        FileLockEnter($FilePath)
    }
}

function FileLockExit([string]$FilePath) {
    $FilePath = Resolve-Path $FilePath
    Remove-Item $FilePath -Force 
}