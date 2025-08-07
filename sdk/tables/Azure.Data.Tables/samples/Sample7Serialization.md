# Customizing serialization

This sample demonstrates the approaches available for customizing model serialization.

## Ignoring and renaming model properties for serialization

Decorating a model property with the `[IgnoreDataMember]` attribute will ignore it on serialization and the `[DataMember(Name = "some_new_name")]` will rename the property.
Below is an example model class utilizing these attributes.

```C# Snippet:TablesSample7ModelPropertiesClass
// Define a strongly typed entity by implementing the ITableEntity interface.
public class CustomSerializationEntity : ITableEntity
{
    public string Product { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    [IgnoreDataMember] public string IgnoreMe { get; set; }

    [DataMember(Name = "rename_me")] public string RenameMe { get; set; }
}
```

After defining our custom model, let's use it and inspect how it transforms the properties.

```C# Snippet:TablesSample7ModelProperties
    // Construct a new TableClient using a TokenCredential.
    var client = new TableClient(
        new Uri(storageUri),
        tableName,
        new DefaultAzureCredential());

    // Create the table if it doesn't already exist.
    client.CreateIfNotExists();

    // Create a new entity with our customization attributes.
    var entity = new CustomSerializationEntity
    {
        PartitionKey = "CustomInventory",
        RowKey = "special stock",
        Product = "Fancy Marker",
        Price = 1.00,
        Quantity = 42,
        IgnoreMe = "nothing to see here",
        RenameMe = "This property will be saved to the table as 'rename_me'"
    };

    // Add the entity to the table. It will be serialized according to our customizations.
    await client.AddEntityAsync(entity);

    // Fetch the entity as a TableEntity so that we can verify that things were serialized as expected.
    var fetchedEntity = await client.GetEntityAsync<TableEntity>(entity.PartitionKey, entity.RowKey);

    // Print each property name to the console.
    foreach (string propertyName in fetchedEntity.Value.Keys)
    {
        Console.WriteLine(propertyName);
    }
    /*
    Console output:

    odata.etag
    PartitionKey
    RowKey
    Timestamp
    Product
    Price
    Quantity
    rename_me
    */
}
```
