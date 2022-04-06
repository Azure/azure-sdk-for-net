# TODO: NEED TO UPDATE CONTAINER PUSH

Set-Location -Path ..\..\..\..\

az acr login --name stresstestregistry

docker build -f './sdk/eventhub/Azure.Messaging.EventHubs\stress\Dockerfile' -t '<registry path>:latest' .

docker push '<registry path>:latest'

Set-Location -Path .\sdk\eventhub\Azure.Messaging.EventHubs\stress\