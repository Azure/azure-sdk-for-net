# TODO: how to update registry path

Set-Location -Path ..\..\..\..\

docker build -f './sdk/eventhub/Azure.Messaging.EventHubs\stress\Dockerfile' -t 'netehtest:latest' .

Set-Location -Path .\sdk\eventhub\Azure.Messaging.EventHubs\stress\

docker run 'netehtest:latest'