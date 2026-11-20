import "@azure-tools/typespec-client-generator-core";

using Azure.ClientGenerator.Core;

@@clientName(Type.Union.Discriminated.Extends.ExplicitDiscriminator.PetBase, "ExplicitPet");
@@clientName(Type.Union.Discriminated.Extends.ExplicitDiscriminator.Cat, "ExplicitCat");
@@clientName(Type.Union.Discriminated.Extends.ExplicitDiscriminator.Dog, "ExplicitDog");

@@clientName(Type.Union.Discriminated.Extends.InjectedDiscriminator.PetBase, "InjectedPet");
@@clientName(Type.Union.Discriminated.Extends.InjectedDiscriminator.Cat, "InjectedCat");
@@clientName(Type.Union.Discriminated.Extends.InjectedDiscriminator.Dog, "InjectedDog");

@@clientName(Type.Union.Discriminated.Extends.CustomDiscriminator.PetBase, "CustomPet");
@@clientName(Type.Union.Discriminated.Extends.CustomDiscriminator.Cat, "CustomCat");
@@clientName(Type.Union.Discriminated.Extends.CustomDiscriminator.Dog, "CustomDog");

@@clientName(Type.Union.Discriminated.Extends.EnumDiscriminator.PetBase, "EnumPet");
@@clientName(Type.Union.Discriminated.Extends.EnumDiscriminator.Cat, "EnumCat");
@@clientName(Type.Union.Discriminated.Extends.EnumDiscriminator.Dog, "EnumDog");

@@clientName(Type.Union.Discriminated.Extends.Recursive.PetBase, "RecursivePet");
@@clientName(Type.Union.Discriminated.Extends.Recursive.Cat, "RecursiveCat");
@@clientName(Type.Union.Discriminated.Extends.Recursive.Dog, "RecursiveDog");
