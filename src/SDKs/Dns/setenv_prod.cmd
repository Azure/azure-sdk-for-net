set SUBSCRIPTIONID=%1
set TOKEN=%2
set AZURE_TEST_MODE=Record
set TEST_CSM_ORGID_AUTHENTICATION=SubscriptionId=%SUBSCRIPTIONID%;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/;GraphUri=https://graph.windows.net/;RawToken=%TOKEN%
