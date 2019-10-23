
The SetSwaggerTestEnvironment.ps1 script will set the environment variables that are required to Create/Update/Running the swagger tests in the SDK repo.

Sample:
.\SetSwaggerTestEnvironment.ps1 -Mode Record -SubscriptionId 00000000-0000-0000-0000-000000000000 -aadclientid 00000000-0000-0000-0000-000000000000 -ApplicationSecret <app_secret> -aadtenant 00000000-0000-0000-0000-000000000000 -Environment Prod