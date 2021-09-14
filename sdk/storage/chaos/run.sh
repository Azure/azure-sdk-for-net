set -x

pwsh /generate-test-config.ps1

export AZURE_TEST_MODE=Live

export AZURE_LIVE_TEST_SERVICE_VERSIONS=V2019_07_07

export $(grep 'APPINSIGHTS_INSTRUMENTATIONKEY' $ENV_FILE | xargs)

count=$1

echo "Number of test runs $count"

kubectl annotate networkchaos network-loss-kasobol-test experiment.chaos-mesh.org/pause-
kubectl annotate networkchaos network-corruption-kasobol-test experiment.chaos-mesh.org/pause-

initial_sleep=$2

echo "Sleeping for $initial_sleep"

sleep $initial_sleep

for i in $(seq $count); do
    echo "Starting run number $i"

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

    echo "Finished run number $i"
done

sleep 1h