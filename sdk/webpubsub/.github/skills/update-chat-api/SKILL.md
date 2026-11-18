---
name: update-chat-api
description: "Use when: updating, exporting, refreshing, or validating the public API baseline for Azure.Messaging.WebPubSub.Chat after a public API change."
---

# Update Web PubSub Chat API

Use this skill whenever a public API change in `Azure.Messaging.WebPubSub.Chat` requires updating its API baseline files.

## Steps

1. From `Azure.Messaging.WebPubSub.Chat`, run:

   ```powershell
   dotnet build /t:ExportApi
   ```

2. Review the updated API baseline files under `api/`:
   - `Azure.Messaging.WebPubSub.Chat.netstandard2.0.cs`
   - `Azure.Messaging.WebPubSub.Chat.net8.0.cs`
   - `Azure.Messaging.WebPubSub.Chat.net10.0.cs`

3. Confirm the diff contains only the intended public API changes.

## Notes

- Run this after every public API addition, removal, or signature change.
- Do not manually edit generated API baseline files; regenerate them with the build target.