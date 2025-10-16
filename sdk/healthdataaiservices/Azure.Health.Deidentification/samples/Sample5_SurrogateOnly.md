# Surrogate Only De-identification

This sample demonstrates how to skip tagging and only surrogate user-defined PHI entities in input text. 

## Build Request and Call Function

```C# Snippet:AzHealthDeidSample5_SurrogateOnly
DeidentificationContent content = new("Hello, John!");
content.OperationType = DeidentificationOperationType.SurrogateOnly;
content.TaggedEntities = new TaggedPhiEntities(
    new SimplePhiEntity[]
    {
        new SimplePhiEntity(PhiCategory.Patient, 7, 4)
    });

Response<DeidentificationResult> result = client.DeidentifyText(content);
string outputString = result.Value.OutputText;
Console.WriteLine(outputString); // Hello, Tom!
```
