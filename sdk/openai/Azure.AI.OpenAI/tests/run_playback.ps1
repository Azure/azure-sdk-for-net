& dotnet test `
    --no-build `
    --filter "(TestCategory!=Live)" `
    --logger "console;verbosity=normal" `
    -e AOAI_SUPPRESS_TRAFFIC_DUMP="true" `
    -e AZURE_TEST_MODE="Playback"