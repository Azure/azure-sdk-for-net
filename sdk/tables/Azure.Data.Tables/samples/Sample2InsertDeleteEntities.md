# Inserting and Deleting Entities
This sample demonstrates how to insert and delete entities. You will have needed to create a table.

## Getting a `TableClient`
To get a reference to the `TableClient`, invoke `GetTableClient` from the `TableServiceClient` with the table name.

```C# Snippet:Sample2GetTableClient
```

## Inserting an Entity
Create the entity in the form of a `Dictionary<string, object>` that includes the partition and row key as entries. The keys should be `PartitionKey` and `RowKey` respectively.

To insert the entity, invoke `Insert` from the `TableClient` and pass in the newly created entity.

```C# Snippet:Sample2InsertEntity
```

## Deleting an Entity
To delete an entity, invoke `Delete` from the `TableClient` and pass in the partition and row key of the entity.

```C# Snippet:Sample2DeleteEntity
```