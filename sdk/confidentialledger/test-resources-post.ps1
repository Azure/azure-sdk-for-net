# Confidential Ledger resources can take up to 60 seconds to resolve in DNS after being newly provisioned.
Write-Host 'Waiting 60 seconds to let the new resource propagate to DNS'
Start-Sleep -Seconds 60
