
function DisplayHelp
{
  <#
    .SYNOPSIS
      Displays the usage help text.

    .DESCRIPTION
      Displays the help text for usage.

    .OUTPUTS
      Help text for usage to the console window.
  #>

  $indent = "    "

  Write-Host "`n"
  Write-Host "Event Hubs Live Test Environment Setup"
  Write-Host ""
  Write-Host "$($indent)This script handles creation and configuration of needed resources within an Azure subscription"
  Write-Host "$($indent)for use with the Event Hubs client library Live test suite."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output a set of environment variables with sensitive information which"
  Write-Host "$($indent)are used for testing.  When running Live tests, please be sure to have these environment variables available,"
  Write-Host "$($indent)either within Visual Studio or command line environment."
  Write-Host ""
  Write-Host "$($indent)NOTE: Some of these values, such as the client secret, are difficult to recover; please copy them and keep in a"
  Write-Host "$($indent)safe place."
  Write-Host ""
  Write-Host ""
  Write-Host "$($indent)Available Parameters:"
  Write-Host ""
  Write-Host "$($indent)-Help`t`t`tDisplays this message."
  Write-Host ""

  Write-Host "$($indent)-SubscriptionName`t`tRequired.  The name of the Azure subscription to be used for"
  Write-Host "$($indent)`t`t`t`trunning the Live tests."
  Write-Host ""
    
  Write-Host "$($indent)-ResourceGroupName`t`tRequired.  The name of the Azure Resource Group that will contain the resources"
  Write-Host "$($indent)`t`t`t`tused for the tests.  This will be created if it does not exist."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will"
  Write-Host "$($indent)`t`t`t`tbe created to manage the Event Hub instances dynamically for the tests.  This"
  Write-Host "$($indent)`t`t`t`tprincipal must not already exist."
  Write-Host ""

  Write-Host "$($indent)-AzureRegion`t`tThe Azure region that resources should be created in.  This value should be"
  Write-Host "$($indent)`t`t`t`tthe name of the region, in lowercase, with no spaces.  For example: southcentralus"
  Write-Host ""
  Write-Host "$($indent)`t`t`t`tDefault: South Central US (southcentralus)"
  Write-Host ""  
}

function DisplayIdentityHelp
{
  <#
    .SYNOPSIS
      Displays the usage help text.

    .DESCRIPTION
      Displays the help text for usage.

    .OUTPUTS
      Help text for usage to the console window.
  #>

  $indent = "    "

  Write-Host "`n"
  Write-Host "Creation of the Resources to Run Identity Samples"
  Write-Host ""
  Write-Host "$($indent)This script handles creation of the principal and the resources needed to run identity samples."
  Write-Host ""
  Write-Host "$($indent)It tries to retrieve an Azure Event Hubs Namespace, an Azure Event Hub and a service principal"
  Write-Host "$($indent)using the names passed in as arguments. It attempts the creation of a resource when not found."
  Write-Host ""
  Write-Host "$($indent)It assigns the 'Azure Event Hubs Data Owner' role to the created namespace."
  Write-Host ""
  Write-Host "$($indent)Upon completion, the script will output the principal's sensitive information."
  Write-Host ""
  Write-Host "$($indent)NOTE: Some of these values, such as the client secret, are difficult to recover; please copy them and keep in a"
  Write-Host "$($indent)safe place."
  Write-Host ""
  Write-Host ""
  Write-Host "$($indent)Available Parameters:"
  Write-Host ""
  Write-Host "$($indent)-Help`t`t`tDisplays this message."
  Write-Host ""

  Write-Host "$($indent)-SubscriptionName`t`tRequired.  The name of the Azure subscription used."
  Write-Host ""

  Write-Host "$($indent)-ResourceGroupName`t`tRequired.  The name of the Azure Resource Group that contains the resources."
  Write-Host ""

  Write-Host "$($indent)-NamespaceName`t`tRequired.  The name of the Azure Event Hubs Namespace."
  Write-Host ""

  Write-Host "$($indent)-EventHubName`t`tRequired.  The name of the Azure Event Hub."
  Write-Host ""

  Write-Host "$($indent)-ServicePrincipalName`tRequired.  The name to use for the service principal that will be created."
  Write-Host ""

  Write-Host "$($indent)-AzureRegion`t`tThe Azure region that resources should be created in.  This value should be"
  Write-Host "$($indent)`t`t`t`tthe name of the region, in lowercase, with no spaces.  For example: southcentralus"
  Write-Host ""
  Write-Host "$($indent)`t`t`t`tDefault: South Central US (southcentralus)"
  Write-Host ""  
}
