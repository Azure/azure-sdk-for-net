Param(
    [parameter(Mandatory=$true)]
    [string] $SubscriptionId,
    [parameter(Mandatory=$true)]
    [string] $ServicePrincipal ,
    [parameter(Mandatory=$false)]
    [string] $ServicePrincipalSecret,
    [parameter(Mandatory=$false)]
    [string] $Environment = "Prod" # Prod for arm prod , DOGFOOD for DOGFOOD
)

$NonProdTenant = "24c154bb-0619-4338-b30a-6aad6370ee14";

$env:AZURE_TEST_MODE="Record";
$str = "SubscriptionId="+$SubscriptionId+";Environment="+$Environment+";ServicePrincipal="+$ServicePrincipal+";ServicePrincipalSecret="+$ServicePrincipalSecret ;
if ($Environment -ine "Prod")
{
    $str+= ";AADTenant="+$NonProdTenant;
}

$env:TEST_CSM_ORGID_AUTHENTICATION=$str;

