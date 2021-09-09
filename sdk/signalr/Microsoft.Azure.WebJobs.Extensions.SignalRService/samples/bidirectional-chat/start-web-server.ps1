Get-Command live-server | Out-Null
If (! $?) {
    # if last command fails, that means live-server not installed.
    Write-Information "Start to install live-server:" 
    npm install --global live-server
}
live-server ./content/index.html
