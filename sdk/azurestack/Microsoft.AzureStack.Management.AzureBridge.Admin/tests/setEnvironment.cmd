@echo off 

set ServicePrincipal=134d0d9b-9825-4129-b5bd-594d04383c8d
set ServicePrincipalSecret=User@123
set SubscriptionId=b7a57872-f429-4eb3-b26a-5108178380a5
set AADTenant=6ca57aaf-0074-498a-9c96-2b097515e8cb

rem Playback or Record
set HttpRecorderMode=Record
set AADTokenAudienceUri=https://adminmanagement.azurestackci08.onmicrosoft.com/96ed9507-2f9f-4ef5-b92f-53c14f0141ff
set AADAuthEndpoint=https://login.windows.net/
set BaseUri=https://adminmanagement.local.azurestack.external
set ManagementResource=https://adminmanagement.azurestackci08.onmicrosoft.com/96ed9507-2f9f-4ef5-b92f-53c14f0141ff

set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SubscriptionId%;AADTenant=%AADTenant%;HttpRecorderMode=%HttpRecorderMode%;AADTokenAudienceUri=%AADTokenAudienceUri%;BaseUri=%BaseUri%;AADAuthEndpoint=%AADAuthEndpoint%;ServicePrincipal=%ServicePrincipal%;password=%ServicePrincipalSecret%;ManagementResource=%ManagementResource%;password=%ServicePrincipalSecret%
set AZURE_TEST_MODE=%HttpRecorderMode%