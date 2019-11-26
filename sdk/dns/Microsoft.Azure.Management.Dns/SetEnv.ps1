Param(
    [parameter(Mandatory=$true)]
    [string] $SubscriptionId,
    [parameter(Mandatory=$true)]
    [string] $ServicePrincipal ,
    [parameter(Mandatory=$false)]
    [string] $ServicePrincipalSecret,
    [parameter(Mandatory=$false)]
    [string] $TenantId = "",
    [parameter(Mandatory=$false)]
    [string] $Environment = "Prod" # Prod for arm prod , DOGFOOD for DOGFOOD
)

$OverrideTenant = "24c154bb-0619-4338-b30a-6aad6370ee14";

if($TenantId -ne "")
{
    $OverrideTenant = $TenantId;
}

$env:AZURE_TEST_MODE="Record";
[string] $str = "SubscriptionId="+$SubscriptionId+";Environment="+$Environment+";ServicePrincipal="+$ServicePrincipal+";ServicePrincipalSecret="+$ServicePrincipalSecret ;
if ($Environment -ine "Prod")
{
    $str+=";AADTenant="+$OverrideTenant;
}

$env:TEST_CSM_ORGID_AUTHENTICATION=$str;

