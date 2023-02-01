FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env 

# Copy in engineering system needed to build
COPY ./eng/ /app/eng/
COPY ./tools/ /app/tools/
COPY ./*.proj /app/
COPY ./Directory.Build.props/ /app/
COPY ./Directory.Build.targets/ /app/
COPY ./NuGet.Config/ /app/

# Copy in Service Bus Source Code
COPY ./sdk/servicebus/Azure.Messaging.ServiceBus/ /app/sdk/eventhub/Azure.Messaging.ServiceBus/

# Copy in Core Source Code
COPY ./sdk/core/ /app/sdk/core/

# Run restore and build, copy the .dll files over so they can used in the running container
WORKDIR /app
RUN dotnet build './sdk/eventhub/Azure.Messaging.ServiceBus/stress/src/' --configuration Release

# Copy in the dll files to be ready to run
FROM build-env as publish
WORKDIR /app
COPY --from=build-env /app/artifacts/bin/Azure.Messaging.ServiceBus.Stress/Release/net7.0/ /app/artifacts/bin/Azure.Messaging.ServiceBus.Stress/Release/net7.0/

WORKDIR /app/artifacts/bin/Azure.Messaging.ServiceBus.Stress/Release/net7.0

# The default is running just the "SendReceiveTest"
ENTRYPOINT ["dotnet Azure.Messaging.ServiceBus.Stress.dll", "--test"]
CMD ["SendRec"]