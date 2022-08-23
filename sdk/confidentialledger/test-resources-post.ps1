# Confidential Ledger resources can take a few minutes to resolve in DNS after being newly provisioned.
Write-Host 'Waiting to let the new resource propagate to DNS'
Start-Sleep -Seconds 180
