# right version of dotnet?
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env 

# Copy in engineering system needed to build
COPY /sdk/eventhub/Azure.Messaging.EventHubs/ /app/sdk/eventhub/Azure.Messaging.EventHubs/
COPY /eng /app/eng
COPY /tools /app/tools
COPY ./*.proj /app
COPY ./Directory.Build.props /app
COPY ./Directory.Build.targets /app
COPY ./NuGet.Config /app
COPY ./sdk/eventhub/Azure.Messaging.EventHubs.Shared /app/sdk/eventhub/Azure.Messaging.EventHubs.Shared
COPY ./sdk/core /app/sdk/core

# Run restore and build, copy the .dll files over so they can used in the running container
WORKDIR /app
RUN dotnet restore './sdk/eventhub/Azure.Messaging.EventHubs/stress/src/'
RUN dotnet build './sdk/eventhub/Azure.Messaging.EventHubs/stress/src/'
COPY /artifacts/bin/Azure.Messaging.EventHubs.Stress/Debug /app/bin/Debug

# Copy in the dll files to be ready to run
FROM build-env as publish
WORKDIR /app
COPY --from=build-env /app/artifacts/bin/Azure.Messaging.EventHubs.Stress/Debug /app/artifacts/bin/Azure.Messaging.EventHubs.Stress/Debug
COPY --from=build-env /app/sdk/eventhub/Azure.Messaging.EventHubs.Shared /app/sdk/evethub/Azure.Messaging.EventHubs.Shared
COPY --from=build-env /app/sdk/eventhub/Azure.Messaging.EventHubs/stress /app/sdk/eventhub/Azure.Messaging.EventHubs/stress

WORKDIR /app/artifacts/bin/Azure.Messaging.EventHubs.Stress/Debug/net6.0