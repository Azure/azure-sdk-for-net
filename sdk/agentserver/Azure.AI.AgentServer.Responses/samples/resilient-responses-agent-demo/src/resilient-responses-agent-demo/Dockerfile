FROM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /src

# Copies the project, nuget.config, AND the staged package drop (./packages/, populated
# by ../../build.sh from sdk/agentserver/packages/). `dotnet restore` then resolves the
# preview Azure.AI.AgentServer.{Core,Responses} packages from the local feed configured in
# nuget.config, and everything else from nuget.org. This mirrors the Python demo's
# `COPY wheels/ ... && pip install /tmp/wheels/*.whl` flow.
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app
COPY --from=build /app .
EXPOSE 8088

# This is a demo image — enables the "crash" sentinel + __ECHO_*/__FAIL__/__TASKTRACE__
# routes in Program.cs. A production image would leave this off (default).
ENV DEMO_MODE=1

# Platform nanny worker handles restart on crash; we just run the agent.
ENTRYPOINT ["dotnet", "ResilientResponsesAgentDemo.dll"]
