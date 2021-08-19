set -x

pwsh /generate-test-config.ps1

export AZURE_TEST_MODE=Live

export AZURE_LIVE_TEST_SERVICE_VERSIONS=V2019_07_07

export $(grep 'APPINSIGHTS_INSTRUMENTATIONKEY' $ENV_FILE | xargs)

dotnet test /azure-sdk-for-net/eng/service.proj \
    --filter "(TestCategory!=Manually) & (TestCategory!=NonChaos)" \
    --framework net5.0 \
    --logger "trx;LogFileName=net5.0.trx" \
    --logger:"console;verbosity=normal" \
    /p:SDKType=all \
    /p:ServiceDirectory=storage \
    /p:Project=Azure.Storage.* \
    /p:IncludeSrc=false \
    /p:IncludeSamples=false \
    /p:IncludePerf=false \
    /p:IncludeStress=false \
    /p:RunApiCompat=false \
    /p:InheritDocEnabled=false \
    /p:Configuration=Debug \
    /p:CollectCoverage=false \
    /p:UseProjectReferenceToAzureClients=false


sleep 1h