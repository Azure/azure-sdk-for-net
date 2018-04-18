@echo off 

set ServicePrincipal=ad07bae5-97d8-4a11-84ae-a7d496285dba
set ServicePrincipalSecret=User@123
set SubscriptionId=8827b0fb-6039-47eb-a7e8-35ca9d2a7a00
set AADTenant=5308332c-26e2-4fdb-9beb-e883a706bc08

rem Playback or Record
set HttpRecorderMode=Record
set AADTokenAudienceUri=https://adminmanagement.azurestackci06.onmicrosoft.com/259aebc2-145d-4404-bd71-30f040120b04
set AADAuthEndpoint=https://login.windows.net/
set BaseUri=https://adminmanagement.local.azurestack.external
set ManagementResource=https://adminmanagement.azurestackci06.onmicrosoft.com/259aebc2-145d-4404-bd71-30f040120b04

set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SubscriptionId%;AADTenant=%AADTenant%;HttpRecorderMode=%HttpRecorderMode%;AADTokenAudienceUri=%AADTokenAudienceUri%;BaseUri=%BaseUri%;AADAuthEndpoint=%AADAuthEndpoint%;ServicePrincipal=%ServicePrincipal%;password=%ServicePrincipalSecret%;ManagementResource=%ManagementResource%;password=%ServicePrincipalSecret%
set AZURE_TEST_MODE=%HttpRecorderMode%