# Define variables
$ComputerName = $env:COMPUTERNAME
$LogicalCPU = 0
$PhysicalCPU = 0
$HyperThreading = 0
$Core = 0
# Get the Processor information from the WMI object
$Proc = [object[]]$(get-WMIObject Win32_Processor -ComputerName $ComputerName)
 
#Perform the calculations
$Core = $Proc.count
$LogicalCPU = $($Proc | measure-object -Property NumberOfLogicalProcessors -sum).Sum
$PhysicalCPU = $($Proc | measure-object -Property NumberOfCores -sum).Sum
$HyperThreading = $($LogicalCPU -gt $PhysicalCPU)
#Build the object
# $Hash = @{
#    LogicalCPU  = $LogicalCPU
#    PhysicalCPU = $PhysicalCPU
#    CoreNr      = $Core
#    HyperThreading = $($LogicalCPU -gt $PhysicalCPU)
#}

# Set NumThreads to the number of cores your CPU has.
# If your CPU has HyperThreading, use the full thread count.
# If ($HyperThreading) {$NumThreads = (Get-Process|Select-Object -ExpandProperty Threads).Count}

$NumThreads = $LogicalCPU
ForEach ($loop in 1..$NumThreads) {
    Start-Job -ScriptBlock {
        [float]$result = 1
        while ($true) {
            [float]$x = get-random -Minimum 1 -Maximum 999999999
            $result = $result * $x
        }
    }
}
