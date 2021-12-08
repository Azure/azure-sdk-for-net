# Generated code configuration

Run `dotnet build /t:GenerateTest` to generate code.

``` yaml

output-folder: $(this-folder)/Generated

testmodeler:
  mock:
    disabled-examples:
      - Update the short term retention policy for the database.
      - Get the short term retention policy for the database.
      - Update the short term retention policy for the database.
      - Create failover group
      - Delete failover group
      - Planned failover of a failover group
      - Forced failover of a failover group allowing data loss
      - Get failover group
      - Update failover group
      - Create failover group
      - Delete failover group
      - Planned failover of a failover group
      - Forced failover of a failover group allowing data loss
      - Get failover group
      - Create or update a target group with all properties.
      - Delete a target group.
      - Get a target group.
      - Creates or updates a database's vulnerability assessment rule baseline.
      - Removes a database's vulnerability assessment rule baseline.
      - Gets a database's vulnerability assessment rule baseline.
      - Creates or updates a database's vulnerability assessment rule baseline.
      - Removes a database's vulnerability assessment rule baseline.
      - Gets a database's vulnerability assessment rule baseline.
      - Create job execution.
      - List job step target executions
      - Cancel a job execution.
      - Get a job execution.
      - Create server trust group
      - Drop server trust group
      - Get server trust group
      - Create or update a target group with minimal properties.
      - List of server advisors
      - List of server recommended actions for all advisors
      - List of database advisors
      - List of database recommended actions for all advisors

require: ../src/autorest.md

```
