# ToString

## Considerations
- Most useful / main pain points
- Following guidance from BCL team and .NET team members
- Applied to TA and FR
- No added logic into ToString. Plain and simple.

## General Guidance
- Can the type be parsed? -> Add ToString
- Will it be helpfull for debugging to differentiate instances? -> Add ToString. If there are undesirded side effects use [DebuggerDisplay]
- Format should be human readable. Not intended for parsing. `<Property name>:<value>, <Property name>:<value>`.

## Specific Guidance 
### When to consider adding ToString
- For `Clients` expose `endpoint`.
- For return types for methods exposed in the `Client`.
- Only expose the most important properties. Focus here is to differentiate instances.
- For types that are going to be stored in Collections.
- For types that expose data with indexes.
- For types that contain collections as properties, consider displaying as `# <Property name>:<value.Count>`.

### When not to consider adding ToString
- Optional types
- Error/Warnign types
- Collections

## Actions
- Add ToString proposal changes to the upcoming UX Study and see if it helps/gets noticed
- Share proposal with other 2 people and refine