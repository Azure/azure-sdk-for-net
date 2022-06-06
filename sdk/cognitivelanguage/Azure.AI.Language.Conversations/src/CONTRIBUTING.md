# Contributing to Azure.AI.Language.Conversations

The `Azure.AI.Language.Conversations` project is a mixed data-plane generated (DPG) project with high-level client (HLC) models.

## Regenerating code

Until DPG for C# supports generating models - which should retain the same public API as HLC models - contributors will need to do some manual work to generate and move models.

1. Change _autorest.md_ to generate a generation 1 convenience client:

   ``` diff
   -  data-plane: true
   +  generation1-convenience-client: true
   ```

2. In the project directory run:

   ```bash
   dotnet build -t:GenerateCode
   ```

3. Move the _Generated/Models_ directory to _Models/Generated_ to avoid being overwritten later.

4. Revert the changes made to _autorest.md_.

5. Re-run the code generation command from step 2.
