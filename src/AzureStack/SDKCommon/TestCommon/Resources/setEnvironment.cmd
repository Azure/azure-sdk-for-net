@echo off 

set SubscriptionId=<FILL>
set AADTenant=<FILL>
set UserId=<FILL>
set Password=fillIn
rem Playback or Record
set HttpRecorderMode=Playback
set AADTokenAudienceUri=https://adminmanagement.<URI>/<GUID>
set AADAuthEndpoint=https://login.windows.net/
set BaseUri=https://adminmanagement.<URI>

set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SubscriptionId%;AADTenant=%AADTenant%;UserId=%UserId%;Password=%Password%;HttpRecorderMode=%HttpRecorderMode%;AADTokenAudienceUri=%AADTokenAudienceUri%;BaseUri=%BaseUri%;AADAuthEndpoint=%AADAuthEndpoint%;
set AZURE_TEST_MODE=%HttpRecorderMode%