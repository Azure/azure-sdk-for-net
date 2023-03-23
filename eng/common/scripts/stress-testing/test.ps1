
function determineRetryTests ([ref] $val, [ref]$val2) {
    $val.value += 1
    $val2.value += 2
    Write-Host "val $($val.value)"
    Write-Host "val $($val2.value)"
}

$v = 0
$v2 = 0
determineRetryTests ([ref]$v) ([ref]$v2)

Write-host "v $v"
Write-Host "v2 $v2"


