@echo off 

set SubscriptionId=e9135de0-bab2-4a11-a6f3-eacafe8f53c6
set AADTenant=d669642b-89ec-466e-af2c-2ceab9fef685
set UserId=ciserviceadmin@msazurestack.onmicrosoft.com
set Password=fillIn
rem Playback or Record
set HttpRecorderMode=Playback
set AADTokenAudienceUri=https://adminmanagement.azurestackci04.onmicrosoft.com/a344046f-81f2-4fb8-8ecf-c0040cebaaf3
set AADAuthEndpoint=https://login.windows.net/
set BaseUri=https://adminmanagement.local.azurestack.external

set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SubscriptionId%;AADTenant=%AADTenant%;UserId=%UserId%;Password=%Password%;HttpRecorderMode=%HttpRecorderMode%;AADTokenAudienceUri=%AADTokenAudienceUri%;BaseUri=%BaseUri%;AADAuthEndpoint=%AADAuthEndpoint%;
set AZURE_TEST_MODE=%HttpRecorderMode%