# Publish first from the sample directory:
#   dotnet publish -c Release -o publish
FROM mcr.microsoft.com/dotnet/aspnet:10.0

WORKDIR /app
COPY publish/ .

ENV ASPNETCORE_URLS=http://+:8088
EXPOSE 8088

ENTRYPOINT ["dotnet", "VoiceBridgeEcho.dll"]
