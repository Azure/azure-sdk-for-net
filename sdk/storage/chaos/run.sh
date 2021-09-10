set -x

pwsh /generate-test-config.ps1

export AZURE_TEST_MODE=Live

export AZURE_LIVE_TEST_SERVICE_VERSIONS=V2019_07_07

export $(grep 'APPINSIGHTS_INSTRUMENTATIONKEY' $ENV_FILE | xargs)

count=220
for i in $(seq $count); do
    UUID=$(cat /proc/sys/kernel/random/uuid)
    export AZURE_STORAGE_TEST_RUN_ID=$UUID

    NOW=$(date -u +"%Y-%m-%dT%H:%M:%SZ")
    export AZURE_STORAGE_TEST_RUN_START_TIME=$NOW

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
done

sleep 1h