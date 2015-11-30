
//  Microsoft (R) .NET Framework IL Disassembler.  Version 4.0.30319.1
//  Copyright (c) Microsoft Corporation.  All rights reserved.



// Metadata version: v4.0.30319
.assembly extern mscorlib
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern System.Core
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 4:0:0:0
}
.assembly extern Newtonsoft.Json
{
  .publickeytoken = (30 AD 4F E6 B2 A6 AE ED )                         // 0.O.....
  .ver 4:5:0:0
}
.assembly extern mscorlib as mscorlib_4
{
  .publickeytoken = (B7 7A 5C 56 19 34 E0 89 )                         // .z\V.4..
  .ver 2:0:0:0
}
.assembly Avro
{
  .custom instance void [mscorlib]System.Reflection.AssemblyTrademarkAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.ComVisibleAttribute::.ctor(bool) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.InteropServices.GuidAttribute::.ctor(string) = ( 01 00 24 36 39 38 34 65 35 36 65 2D 62 36 37 66   // ..$6984e56e-b67f
                                                                                                  2D 34 34 63 31 2D 39 61 61 66 2D 30 34 38 33 63   // -44c1-9aaf-0483c
                                                                                                  37 35 38 39 36 34 32 00 00 )                      // 7589642..
  .custom instance void [mscorlib]System.Reflection.AssemblyCopyrightAttribute::.ctor(string) = ( 01 00 18 43 6F 70 79 72 69 67 68 74 20 C2 A9 20   // ...Copyright .. 
                                                                                                  41 70 61 63 68 65 20 32 30 31 30 00 00 )          // Apache 2010..
  .custom instance void [mscorlib]System.Runtime.CompilerServices.RuntimeCompatibilityAttribute::.ctor() = ( 01 00 01 00 54 02 16 57 72 61 70 4E 6F 6E 45 78   // ....T..WrapNonEx
                                                                                                             63 65 70 74 69 6F 6E 54 68 72 6F 77 73 01 )       // ceptionThrows.
  .custom instance void [mscorlib]System.Reflection.AssemblyCompanyAttribute::.ctor(string) = ( 01 00 06 41 70 61 63 68 65 00 00 )                // ...Apache..
  .custom instance void [mscorlib]System.Reflection.AssemblyFileVersionAttribute::.ctor(string) = ( 01 00 07 30 2E 39 2E 30 2E 30 00 00 )             // ...0.9.0.0..
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilationRelaxationsAttribute::.ctor(int32) = ( 01 00 08 00 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Runtime.Versioning.TargetFrameworkAttribute::.ctor(string) = ( 01 00 1A 2E 4E 45 54 46 72 61 6D 65 77 6F 72 6B   // ....NETFramework
                                                                                                        2C 56 65 72 73 69 6F 6E 3D 76 34 2E 30 01 00 54   // ,Version=v4.0..T
                                                                                                        0E 14 46 72 61 6D 65 77 6F 72 6B 44 69 73 70 6C   // ..FrameworkDispl
                                                                                                        61 79 4E 61 6D 65 10 2E 4E 45 54 20 46 72 61 6D   // ayName..NET Fram
                                                                                                        65 77 6F 72 6B 20 34 )                            // ework 4
  .custom instance void [mscorlib]System.Reflection.AssemblyProductAttribute::.ctor(string) = ( 01 00 04 41 76 72 6F 00 00 )                      // ...Avro..
  .custom instance void [mscorlib]System.Reflection.AssemblyTitleAttribute::.ctor(string) = ( 01 00 04 41 76 72 6F 00 00 )                      // ...Avro..
  .custom instance void [mscorlib]System.Reflection.AssemblyDescriptionAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .custom instance void [mscorlib]System.Reflection.AssemblyConfigurationAttribute::.ctor(string) = ( 01 00 00 00 00 ) 
  .hash algorithm 0x00008004
  .ver 0:9:0:0
}
.module Avro.dll
// MVID: {859830F3-9354-43B7-8D29-EB194D637810}
.imagebase 0x10000000
.file alignment 0x00000200
.stackreserve 0x00100000
.subsystem 0x0003       // WINDOWS_CUI
.corflags 0x00000001    //  ILONLY
// Image base: 0x0000000002690000


// =============== CLASS MEMBERS DECLARATION ===================

.class public auto ansi beforefieldinit Avro.AvroException
       extends [mscorlib]System.Exception
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void [mscorlib]System.Exception::.ctor(string)
    IL_0007:  ret
  } // end of method AvroException::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s,
                               class [mscorlib]System.Exception inner) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void [mscorlib]System.Exception::.ctor(string,
                                                                         class [mscorlib]System.Exception)
    IL_0008:  ret
  } // end of method AvroException::.ctor

} // end of class Avro.AvroException

.class public auto ansi beforefieldinit Avro.AvroRuntimeException
       extends Avro.AvroException
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.AvroException::.ctor(string)
    IL_0007:  ret
  } // end of method AvroRuntimeException::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s,
                               class [mscorlib]System.Exception inner) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.AvroException::.ctor(string,
                                                                 class [mscorlib]System.Exception)
    IL_0008:  ret
  } // end of method AvroRuntimeException::.ctor

} // end of class Avro.AvroRuntimeException

.class public auto ansi beforefieldinit Avro.CodeGen
       extends [mscorlib]System.Object
{
  .field family class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace> namespaceLookup
  .field private class [System]System.CodeDom.CodeCompileUnit '<CompileUnit>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> '<Schemas>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> '<Protocols>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [System]System.CodeDom.CodeCompileUnit 
          get_CompileUnit() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::'<CompileUnit>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGen::get_CompileUnit

  .method private hidebysig specialname instance void 
          set_CompileUnit(class [System]System.CodeDom.CodeCompileUnit 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::'<CompileUnit>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGen::set_CompileUnit

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 
          get_Schemas() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.CodeGen::'<Schemas>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGen::get_Schemas

  .method private hidebysig specialname instance void 
          set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.CodeGen::'<Schemas>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGen::set_Schemas

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> 
          get_Protocols() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> Avro.CodeGen::'<Protocols>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGen::get_Protocols

  .method private hidebysig specialname instance void 
          set_Protocols(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> Avro.CodeGen::'<Protocols>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGen::set_Protocols

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       45 (0x2d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       class [mscorlib]System.StringComparer [mscorlib]System.StringComparer::get_Ordinal()
    IL_0006:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace>::.ctor(class [mscorlib]System.Collections.Generic.IEqualityComparer`1<!0>)
    IL_000b:  stfld      class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace> Avro.CodeGen::namespaceLookup
    IL_0010:  ldarg.0
    IL_0011:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0016:  ldarg.0
    IL_0017:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::.ctor()
    IL_001c:  call       instance void Avro.CodeGen::set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
    IL_0021:  ldarg.0
    IL_0022:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Protocol>::.ctor()
    IL_0027:  call       instance void Avro.CodeGen::set_Protocols(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol>)
    IL_002c:  ret
  } // end of method CodeGen::.ctor

  .method public hidebysig newslot virtual 
          instance void  AddProtocol(class Avro.Protocol protocol) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> Avro.CodeGen::get_Protocols()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance void class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Protocol>::Add(!0)
    IL_000c:  ret
  } // end of method CodeGen::AddProtocol

  .method public hidebysig newslot virtual 
          instance void  AddSchema(class Avro.Schema schema) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.CodeGen::get_Schemas()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance void class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::Add(!0)
    IL_000c:  ret
  } // end of method CodeGen::AddSchema

  .method family hidebysig newslot virtual 
          instance class [System]System.CodeDom.CodeNamespace 
          addNamespace(string name) cil managed
  {
    // Code size       133 (0x85)
    .maxstack  3
    .locals init (class [System]System.CodeDom.CodeNamespace V_0,
             class [System]System.CodeDom.CodeNamespaceImport V_1,
             class [System]System.CodeDom.CodeNamespaceImport[] V_2,
             int32 V_3)
    IL_0000:  ldarg.1
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0018

    IL_0008:  ldstr      "name"
    IL_000d:  ldstr      "name cannot be null."
    IL_0012:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0017:  throw

    IL_0018:  ldnull
    IL_0019:  stloc.0
    IL_001a:  ldarg.0
    IL_001b:  ldfld      class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace> Avro.CodeGen::namespaceLookup
    IL_0020:  ldarg.1
    IL_0021:  ldloca.s   V_0
    IL_0023:  callvirt   instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace>::TryGetValue(!0,
                                                                                                                                                               !1&)
    IL_0028:  brtrue.s   IL_0083

    IL_002a:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_002f:  ldarg.1
    IL_0030:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_0035:  newobj     instance void [System]System.CodeDom.CodeNamespace::.ctor(string)
    IL_003a:  stloc.0
    IL_003b:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0040:  callvirt   instance class [System]System.CodeDom.CodeNamespaceImport[] Avro.CodeGenUtil::get_NamespaceImports()
    IL_0045:  stloc.2
    IL_0046:  ldc.i4.0
    IL_0047:  stloc.3
    IL_0048:  br.s       IL_005e

    IL_004a:  ldloc.2
    IL_004b:  ldloc.3
    IL_004c:  ldelem.ref
    IL_004d:  stloc.1
    IL_004e:  ldloc.0
    IL_004f:  callvirt   instance class [System]System.CodeDom.CodeNamespaceImportCollection [System]System.CodeDom.CodeNamespace::get_Imports()
    IL_0054:  ldloc.1
    IL_0055:  callvirt   instance void [System]System.CodeDom.CodeNamespaceImportCollection::Add(class [System]System.CodeDom.CodeNamespaceImport)
    IL_005a:  ldloc.3
    IL_005b:  ldc.i4.1
    IL_005c:  add
    IL_005d:  stloc.3
    IL_005e:  ldloc.3
    IL_005f:  ldloc.2
    IL_0060:  ldlen
    IL_0061:  conv.i4
    IL_0062:  blt.s      IL_004a

    IL_0064:  ldarg.0
    IL_0065:  call       instance class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::get_CompileUnit()
    IL_006a:  callvirt   instance class [System]System.CodeDom.CodeNamespaceCollection [System]System.CodeDom.CodeCompileUnit::get_Namespaces()
    IL_006f:  ldloc.0
    IL_0070:  callvirt   instance int32 [System]System.CodeDom.CodeNamespaceCollection::Add(class [System]System.CodeDom.CodeNamespace)
    IL_0075:  pop
    IL_0076:  ldarg.0
    IL_0077:  ldfld      class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace> Avro.CodeGen::namespaceLookup
    IL_007c:  ldarg.1
    IL_007d:  ldloc.0
    IL_007e:  callvirt   instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [System]System.CodeDom.CodeNamespace>::Add(!0,
                                                                                                                                                       !1)
    IL_0083:  ldloc.0
    IL_0084:  ret
  } // end of method CodeGen::addNamespace

  .method public hidebysig newslot virtual 
          instance class [System]System.CodeDom.CodeCompileUnit 
          GenerateCode() cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void [System]System.CodeDom.CodeCompileUnit::.ctor()
    IL_0006:  call       instance void Avro.CodeGen::set_CompileUnit(class [System]System.CodeDom.CodeCompileUnit)
    IL_000b:  ldarg.0
    IL_000c:  callvirt   instance void Avro.CodeGen::processSchemas()
    IL_0011:  ldarg.0
    IL_0012:  callvirt   instance void Avro.CodeGen::processProtocols()
    IL_0017:  ldarg.0
    IL_0018:  call       instance class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::get_CompileUnit()
    IL_001d:  ret
  } // end of method CodeGen::GenerateCode

  .method family hidebysig newslot virtual 
          instance void  processSchemas() cil managed
  {
    // Code size       251 (0xfb)
    .maxstack  2
    .locals init (class Avro.Schema V_0,
             class Avro.SchemaNames V_1,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema> V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_3,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>> V_4,
             valuetype Avro.Schema/Type V_5)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.CodeGen::get_Schemas()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_000b:  stloc.3
    .try
    {
      IL_000c:  br         IL_00e3

      IL_0011:  ldloc.3
      IL_0012:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0017:  stloc.0
      IL_0018:  ldarg.0
      IL_0019:  ldloc.0
      IL_001a:  callvirt   instance class Avro.SchemaNames Avro.CodeGen::generateNames(class Avro.Schema)
      IL_001f:  stloc.1
      IL_0020:  ldloc.1
      IL_0021:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>> Avro.SchemaNames::GetEnumerator()
      IL_0026:  stloc.s    V_4
      .try
      {
        IL_0028:  br         IL_00c9

        IL_002d:  ldloc.s    V_4
        IL_002f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>>::get_Current()
        IL_0034:  stloc.2
        IL_0035:  ldloca.s   V_2
        IL_0037:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_003c:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
        IL_0041:  stloc.s    V_5
        IL_0043:  ldloc.s    V_5
        IL_0045:  ldc.i4.8
        IL_0046:  sub
        IL_0047:  switch     ( 
                              IL_0088,
                              IL_006a,
                              IL_00a8,
                              IL_00a8,
                              IL_00a8,
                              IL_0079,
                              IL_0098)
        IL_0068:  br.s       IL_00a8

        IL_006a:  ldarg.0
        IL_006b:  ldloca.s   V_2
        IL_006d:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0072:  callvirt   instance void Avro.CodeGen::processEnum(class Avro.Schema)
        IL_0077:  br.s       IL_00c9

        IL_0079:  ldarg.0
        IL_007a:  ldloca.s   V_2
        IL_007c:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0081:  callvirt   instance void Avro.CodeGen::processFixed(class Avro.Schema)
        IL_0086:  br.s       IL_00c9

        IL_0088:  ldarg.0
        IL_0089:  ldloca.s   V_2
        IL_008b:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0090:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclaration Avro.CodeGen::processRecord(class Avro.Schema)
        IL_0095:  pop
        IL_0096:  br.s       IL_00c9

        IL_0098:  ldarg.0
        IL_0099:  ldloca.s   V_2
        IL_009b:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_00a0:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclaration Avro.CodeGen::processRecord(class Avro.Schema)
        IL_00a5:  pop
        IL_00a6:  br.s       IL_00c9

        IL_00a8:  ldstr      "Names in schema should only be of type NamedSchema"
        + ", type found "
        IL_00ad:  ldloca.s   V_2
        IL_00af:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_00b4:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
        IL_00b9:  box        Avro.Schema/Type
        IL_00be:  call       string [mscorlib]System.String::Concat(object,
                                                                    object)
        IL_00c3:  newobj     instance void Avro.CodeGenException::.ctor(string)
        IL_00c8:  throw

        IL_00c9:  ldloc.s    V_4
        IL_00cb:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_00d0:  brtrue     IL_002d

        IL_00d5:  leave.s    IL_00e3

      }  // end .try
      finally
      {
        IL_00d7:  ldloc.s    V_4
        IL_00d9:  brfalse.s  IL_00e2

        IL_00db:  ldloc.s    V_4
        IL_00dd:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_00e2:  endfinally
      }  // end handler
      IL_00e3:  ldloc.3
      IL_00e4:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00e9:  brtrue     IL_0011

      IL_00ee:  leave.s    IL_00fa

    }  // end .try
    finally
    {
      IL_00f0:  ldloc.3
      IL_00f1:  brfalse.s  IL_00f9

      IL_00f3:  ldloc.3
      IL_00f4:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00f9:  endfinally
    }  // end handler
    IL_00fa:  ret
  } // end of method CodeGen::processSchemas

  .method family hidebysig newslot virtual 
          instance void  processProtocols() cil managed
  {
    // Code size       251 (0xfb)
    .maxstack  2
    .locals init (class Avro.Protocol V_0,
             class Avro.SchemaNames V_1,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema> V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Protocol> V_3,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>> V_4,
             valuetype Avro.Schema/Type V_5)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> Avro.CodeGen::get_Protocols()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Protocol>::GetEnumerator()
    IL_000b:  stloc.3
    .try
    {
      IL_000c:  br         IL_00e3

      IL_0011:  ldloc.3
      IL_0012:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Protocol>::get_Current()
      IL_0017:  stloc.0
      IL_0018:  ldarg.0
      IL_0019:  ldloc.0
      IL_001a:  callvirt   instance class Avro.SchemaNames Avro.CodeGen::generateNames(class Avro.Protocol)
      IL_001f:  stloc.1
      IL_0020:  ldloc.1
      IL_0021:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>> Avro.SchemaNames::GetEnumerator()
      IL_0026:  stloc.s    V_4
      .try
      {
        IL_0028:  br         IL_00c9

        IL_002d:  ldloc.s    V_4
        IL_002f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>>::get_Current()
        IL_0034:  stloc.2
        IL_0035:  ldloca.s   V_2
        IL_0037:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_003c:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
        IL_0041:  stloc.s    V_5
        IL_0043:  ldloc.s    V_5
        IL_0045:  ldc.i4.8
        IL_0046:  sub
        IL_0047:  switch     ( 
                              IL_0088,
                              IL_006a,
                              IL_00a8,
                              IL_00a8,
                              IL_00a8,
                              IL_0079,
                              IL_0098)
        IL_0068:  br.s       IL_00a8

        IL_006a:  ldarg.0
        IL_006b:  ldloca.s   V_2
        IL_006d:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0072:  callvirt   instance void Avro.CodeGen::processEnum(class Avro.Schema)
        IL_0077:  br.s       IL_00c9

        IL_0079:  ldarg.0
        IL_007a:  ldloca.s   V_2
        IL_007c:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0081:  callvirt   instance void Avro.CodeGen::processFixed(class Avro.Schema)
        IL_0086:  br.s       IL_00c9

        IL_0088:  ldarg.0
        IL_0089:  ldloca.s   V_2
        IL_008b:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_0090:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclaration Avro.CodeGen::processRecord(class Avro.Schema)
        IL_0095:  pop
        IL_0096:  br.s       IL_00c9

        IL_0098:  ldarg.0
        IL_0099:  ldloca.s   V_2
        IL_009b:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_00a0:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclaration Avro.CodeGen::processRecord(class Avro.Schema)
        IL_00a5:  pop
        IL_00a6:  br.s       IL_00c9

        IL_00a8:  ldstr      "Names in protocol should only be of type NamedSche"
        + "ma, type found "
        IL_00ad:  ldloca.s   V_2
        IL_00af:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>::get_Value()
        IL_00b4:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
        IL_00b9:  box        Avro.Schema/Type
        IL_00be:  call       string [mscorlib]System.String::Concat(object,
                                                                    object)
        IL_00c3:  newobj     instance void Avro.CodeGenException::.ctor(string)
        IL_00c8:  throw

        IL_00c9:  ldloc.s    V_4
        IL_00cb:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_00d0:  brtrue     IL_002d

        IL_00d5:  leave.s    IL_00e3

      }  // end .try
      finally
      {
        IL_00d7:  ldloc.s    V_4
        IL_00d9:  brfalse.s  IL_00e2

        IL_00db:  ldloc.s    V_4
        IL_00dd:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_00e2:  endfinally
      }  // end handler
      IL_00e3:  ldloc.3
      IL_00e4:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00e9:  brtrue     IL_0011

      IL_00ee:  leave.s    IL_00fa

    }  // end .try
    finally
    {
      IL_00f0:  ldloc.3
      IL_00f1:  brfalse.s  IL_00f9

      IL_00f3:  ldloc.3
      IL_00f4:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00f9:  endfinally
    }  // end handler
    IL_00fa:  ret
  } // end of method CodeGen::processProtocols

  .method family hidebysig newslot virtual 
          instance class Avro.SchemaNames 
          generateNames(class Avro.Protocol protocol) cil managed
  {
    // Code size       57 (0x39)
    .maxstack  3
    .locals init (class Avro.SchemaNames V_0,
             class Avro.Schema V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_2)
    IL_0000:  newobj     instance void Avro.SchemaNames::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_000c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0011:  stloc.2
    .try
    {
      IL_0012:  br.s       IL_0023

      IL_0014:  ldloc.2
      IL_0015:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_001a:  stloc.1
      IL_001b:  ldarg.0
      IL_001c:  ldloc.1
      IL_001d:  ldloc.0
      IL_001e:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                               class Avro.SchemaNames)
      IL_0023:  ldloc.2
      IL_0024:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0029:  brtrue.s   IL_0014

      IL_002b:  leave.s    IL_0037

    }  // end .try
    finally
    {
      IL_002d:  ldloc.2
      IL_002e:  brfalse.s  IL_0036

      IL_0030:  ldloc.2
      IL_0031:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0036:  endfinally
    }  // end handler
    IL_0037:  ldloc.0
    IL_0038:  ret
  } // end of method CodeGen::generateNames

  .method family hidebysig newslot virtual 
          instance class Avro.SchemaNames 
          generateNames(class Avro.Schema schema) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  3
    .locals init (class Avro.SchemaNames V_0)
    IL_0000:  newobj     instance void Avro.SchemaNames::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  ldloc.0
    IL_0009:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                             class Avro.SchemaNames)
    IL_000e:  ldloc.0
    IL_000f:  ret
  } // end of method CodeGen::generateNames

  .method family hidebysig newslot virtual 
          instance void  addName(class Avro.Schema schema,
                                 class Avro.SchemaNames names) cil managed
  {
    // Code size       367 (0x16f)
    .maxstack  3
    .locals init (class Avro.NamedSchema V_0,
             class Avro.RecordSchema V_1,
             class Avro.Field V_2,
             class Avro.ArraySchema V_3,
             class Avro.MapSchema V_4,
             class Avro.UnionSchema V_5,
             class Avro.Schema V_6,
             valuetype Avro.Schema/Type V_7,
             valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field> V_8,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_9,
             object[] V_10)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.NamedSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brfalse.s  IL_0019

    IL_000a:  ldarg.2
    IL_000b:  ldloc.0
    IL_000c:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0011:  callvirt   instance bool Avro.SchemaNames::Contains(class Avro.SchemaName)
    IL_0016:  brfalse.s  IL_0019

    IL_0018:  ret

    IL_0019:  ldarg.1
    IL_001a:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_001f:  stloc.s    V_7
    IL_0021:  ldloc.s    V_7
    IL_0023:  switch     ( 
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_016e,
                          IL_0072,
                          IL_0069,
                          IL_00c1,
                          IL_00d6,
                          IL_00ed,
                          IL_0069,
                          IL_0072)
    IL_0064:  br         IL_012e

    IL_0069:  ldarg.2
    IL_006a:  ldloc.0
    IL_006b:  callvirt   instance bool Avro.SchemaNames::Add(class Avro.NamedSchema)
    IL_0070:  pop
    IL_0071:  ret

    IL_0072:  ldarg.1
    IL_0073:  isinst     Avro.RecordSchema
    IL_0078:  stloc.1
    IL_0079:  ldarg.2
    IL_007a:  ldloc.1
    IL_007b:  callvirt   instance bool Avro.SchemaNames::Add(class Avro.NamedSchema)
    IL_0080:  pop
    IL_0081:  ldloc.1
    IL_0082:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0087:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::GetEnumerator()
    IL_008c:  stloc.s    V_8
    .try
    {
      IL_008e:  br.s       IL_00a5

      IL_0090:  ldloca.s   V_8
      IL_0092:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::get_Current()
      IL_0097:  stloc.2
      IL_0098:  ldarg.0
      IL_0099:  ldloc.2
      IL_009a:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_009f:  ldarg.2
      IL_00a0:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                               class Avro.SchemaNames)
      IL_00a5:  ldloca.s   V_8
      IL_00a7:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::MoveNext()
      IL_00ac:  brtrue.s   IL_0090

      IL_00ae:  leave      IL_016e

    }  // end .try
    finally
    {
      IL_00b3:  ldloca.s   V_8
      IL_00b5:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>
      IL_00bb:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c0:  endfinally
    }  // end handler
    IL_00c1:  ldarg.1
    IL_00c2:  isinst     Avro.ArraySchema
    IL_00c7:  stloc.3
    IL_00c8:  ldarg.0
    IL_00c9:  ldloc.3
    IL_00ca:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_00cf:  ldarg.2
    IL_00d0:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                             class Avro.SchemaNames)
    IL_00d5:  ret

    IL_00d6:  ldarg.1
    IL_00d7:  isinst     Avro.MapSchema
    IL_00dc:  stloc.s    V_4
    IL_00de:  ldarg.0
    IL_00df:  ldloc.s    V_4
    IL_00e1:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_00e6:  ldarg.2
    IL_00e7:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                             class Avro.SchemaNames)
    IL_00ec:  ret

    IL_00ed:  ldarg.1
    IL_00ee:  isinst     Avro.UnionSchema
    IL_00f3:  stloc.s    V_5
    IL_00f5:  ldloc.s    V_5
    IL_00f7:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_00fc:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0101:  stloc.s    V_9
    .try
    {
      IL_0103:  br.s       IL_0117

      IL_0105:  ldloc.s    V_9
      IL_0107:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_010c:  stloc.s    V_6
      IL_010e:  ldarg.0
      IL_010f:  ldloc.s    V_6
      IL_0111:  ldarg.2
      IL_0112:  callvirt   instance void Avro.CodeGen::addName(class Avro.Schema,
                                                               class Avro.SchemaNames)
      IL_0117:  ldloc.s    V_9
      IL_0119:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_011e:  brtrue.s   IL_0105

      IL_0120:  leave.s    IL_016e

    }  // end .try
    finally
    {
      IL_0122:  ldloc.s    V_9
      IL_0124:  brfalse.s  IL_012d

      IL_0126:  ldloc.s    V_9
      IL_0128:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_012d:  endfinally
    }  // end handler
    IL_012e:  ldc.i4.4
    IL_012f:  newarr     [mscorlib]System.Object
    IL_0134:  stloc.s    V_10
    IL_0136:  ldloc.s    V_10
    IL_0138:  ldc.i4.0
    IL_0139:  ldstr      "Unable to add name for "
    IL_013e:  stelem.ref
    IL_013f:  ldloc.s    V_10
    IL_0141:  ldc.i4.1
    IL_0142:  ldarg.1
    IL_0143:  callvirt   instance string Avro.Schema::get_Name()
    IL_0148:  stelem.ref
    IL_0149:  ldloc.s    V_10
    IL_014b:  ldc.i4.2
    IL_014c:  ldstr      " type "
    IL_0151:  stelem.ref
    IL_0152:  ldloc.s    V_10
    IL_0154:  ldc.i4.3
    IL_0155:  ldarg.1
    IL_0156:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_015b:  box        Avro.Schema/Type
    IL_0160:  stelem.ref
    IL_0161:  ldloc.s    V_10
    IL_0163:  call       string [mscorlib]System.String::Concat(object[])
    IL_0168:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_016d:  throw

    IL_016e:  ret
  } // end of method CodeGen::addName

  .method family hidebysig newslot virtual 
          instance void  processFixed(class Avro.Schema schema) cil managed
  {
    // Code size       400 (0x190)
    .maxstack  4
    .locals init (class Avro.FixedSchema V_0,
             class [System]System.CodeDom.CodeTypeDeclaration V_1,
             string V_2,
             class [System]System.CodeDom.CodeTypeReference V_3,
             class [System]System.CodeDom.CodeMemberField V_4,
             class [System]System.CodeDom.CodeMemberProperty V_5,
             class [System]System.CodeDom.CodeConstructor V_6,
             string V_7,
             class [System]System.CodeDom.CodeNamespace V_8)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.FixedSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Unable to cast schema into a fixed"
    IL_000f:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0014:  throw

    IL_0015:  newobj     instance void [System]System.CodeDom.CodeTypeDeclaration::.ctor()
    IL_001a:  stloc.1
    IL_001b:  ldloc.1
    IL_001c:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0021:  ldloc.0
    IL_0022:  callvirt   instance string Avro.Schema::get_Name()
    IL_0027:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_002c:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
    IL_0031:  ldloc.1
    IL_0032:  ldc.i4.1
    IL_0033:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclaration::set_IsClass(bool)
    IL_0038:  ldloc.1
    IL_0039:  ldc.i4.1
    IL_003a:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclaration::set_IsPartial(bool)
    IL_003f:  ldloc.1
    IL_0040:  ldc.i4     0x6000
    IL_0045:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_004a:  ldloc.1
    IL_004b:  callvirt   instance class [System]System.CodeDom.CodeTypeReferenceCollection [System]System.CodeDom.CodeTypeDeclaration::get_BaseTypes()
    IL_0050:  ldstr      "SpecificFixed"
    IL_0055:  callvirt   instance void [System]System.CodeDom.CodeTypeReferenceCollection::Add(string)
    IL_005a:  ldarg.0
    IL_005b:  ldarg.1
    IL_005c:  ldloc.1
    IL_005d:  ldc.i4.1
    IL_005e:  callvirt   instance void Avro.CodeGen::createSchemaField(class Avro.Schema,
                                                                       class [System]System.CodeDom.CodeTypeDeclaration,
                                                                       bool)
    IL_0063:  ldstr      "fixedSize"
    IL_0068:  stloc.2
    IL_0069:  ldtoken    [mscorlib]System.UInt32
    IL_006e:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0073:  newobj     instance void [System]System.CodeDom.CodeTypeReference::.ctor(class [mscorlib]System.Type)
    IL_0078:  stloc.3
    IL_0079:  ldloc.3
    IL_007a:  ldloc.2
    IL_007b:  newobj     instance void [System]System.CodeDom.CodeMemberField::.ctor(class [System]System.CodeDom.CodeTypeReference,
                                                                                     string)
    IL_0080:  stloc.s    V_4
    IL_0082:  ldloc.s    V_4
    IL_0084:  ldc.i4     0x5003
    IL_0089:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_008e:  ldloc.s    V_4
    IL_0090:  ldloc.0
    IL_0091:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0096:  box        [mscorlib]System.Int32
    IL_009b:  newobj     instance void [System]System.CodeDom.CodePrimitiveExpression::.ctor(object)
    IL_00a0:  callvirt   instance void [System]System.CodeDom.CodeMemberField::set_InitExpression(class [System]System.CodeDom.CodeExpression)
    IL_00a5:  ldloc.1
    IL_00a6:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_00ab:  ldloc.s    V_4
    IL_00ad:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_00b2:  pop
    IL_00b3:  newobj     instance void [System]System.CodeDom.CodeThisReferenceExpression::.ctor()
    IL_00b8:  ldloc.2
    IL_00b9:  newobj     instance void [System]System.CodeDom.CodeFieldReferenceExpression::.ctor(class [System]System.CodeDom.CodeExpression,
                                                                                                  string)
    IL_00be:  pop
    IL_00bf:  newobj     instance void [System]System.CodeDom.CodeMemberProperty::.ctor()
    IL_00c4:  stloc.s    V_5
    IL_00c6:  ldloc.s    V_5
    IL_00c8:  ldc.i4     0x6003
    IL_00cd:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_00d2:  ldloc.s    V_5
    IL_00d4:  ldstr      "FixedSize"
    IL_00d9:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
    IL_00de:  ldloc.s    V_5
    IL_00e0:  ldloc.3
    IL_00e1:  callvirt   instance void [System]System.CodeDom.CodeMemberProperty::set_Type(class [System]System.CodeDom.CodeTypeReference)
    IL_00e6:  ldloc.s    V_5
    IL_00e8:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberProperty::get_GetStatements()
    IL_00ed:  ldarg.1
    IL_00ee:  callvirt   instance string Avro.Schema::get_Name()
    IL_00f3:  ldstr      "."
    IL_00f8:  ldloc.2
    IL_00f9:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_00fe:  newobj     instance void [System]System.CodeDom.CodeTypeReferenceExpression::.ctor(string)
    IL_0103:  newobj     instance void [System]System.CodeDom.CodeMethodReturnStatement::.ctor(class [System]System.CodeDom.CodeExpression)
    IL_0108:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeStatement)
    IL_010d:  pop
    IL_010e:  ldloc.1
    IL_010f:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_0114:  ldloc.s    V_5
    IL_0116:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_011b:  pop
    IL_011c:  newobj     instance void [System]System.CodeDom.CodeConstructor::.ctor()
    IL_0121:  stloc.s    V_6
    IL_0123:  ldloc.s    V_6
    IL_0125:  ldc.i4     0x6000
    IL_012a:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_012f:  ldloc.s    V_6
    IL_0131:  callvirt   instance class [System]System.CodeDom.CodeExpressionCollection [System]System.CodeDom.CodeConstructor::get_BaseConstructorArgs()
    IL_0136:  ldloc.2
    IL_0137:  newobj     instance void [System]System.CodeDom.CodeVariableReferenceExpression::.ctor(string)
    IL_013c:  callvirt   instance int32 [System]System.CodeDom.CodeExpressionCollection::Add(class [System]System.CodeDom.CodeExpression)
    IL_0141:  pop
    IL_0142:  ldloc.1
    IL_0143:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_0148:  ldloc.s    V_6
    IL_014a:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_014f:  pop
    IL_0150:  ldloc.0
    IL_0151:  callvirt   instance string Avro.NamedSchema::get_Namespace()
    IL_0156:  stloc.s    V_7
    IL_0158:  ldloc.s    V_7
    IL_015a:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_015f:  brfalse.s  IL_0177

    IL_0161:  ldstr      "Namespace required for enum schema "
    IL_0166:  ldloc.0
    IL_0167:  callvirt   instance string Avro.Schema::get_Name()
    IL_016c:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0171:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0176:  throw

    IL_0177:  ldarg.0
    IL_0178:  ldloc.s    V_7
    IL_017a:  callvirt   instance class [System]System.CodeDom.CodeNamespace Avro.CodeGen::addNamespace(string)
    IL_017f:  stloc.s    V_8
    IL_0181:  ldloc.s    V_8
    IL_0183:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
    IL_0188:  ldloc.1
    IL_0189:  callvirt   instance int32 [System]System.CodeDom.CodeTypeDeclarationCollection::Add(class [System]System.CodeDom.CodeTypeDeclaration)
    IL_018e:  pop
    IL_018f:  ret
  } // end of method CodeGen::processFixed

  .method family hidebysig newslot virtual 
          instance void  processEnum(class Avro.Schema schema) cil managed
  {
    // Code size       241 (0xf1)
    .maxstack  3
    .locals init (class Avro.EnumSchema V_0,
             class [System]System.CodeDom.CodeTypeDeclaration V_1,
             string V_2,
             class [System]System.CodeDom.CodeMemberField V_3,
             string V_4,
             class [System]System.CodeDom.CodeNamespace V_5,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_6)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.EnumSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Unable to cast schema into an enum"
    IL_000f:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0014:  throw

    IL_0015:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_001a:  ldloc.0
    IL_001b:  callvirt   instance string Avro.Schema::get_Name()
    IL_0020:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_0025:  newobj     instance void [System]System.CodeDom.CodeTypeDeclaration::.ctor(string)
    IL_002a:  stloc.1
    IL_002b:  ldloc.1
    IL_002c:  ldc.i4.1
    IL_002d:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclaration::set_IsEnum(bool)
    IL_0032:  ldloc.1
    IL_0033:  ldc.i4     0x6000
    IL_0038:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_003d:  ldloc.0
    IL_003e:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0043:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_0048:  stloc.s    V_6
    .try
    {
      IL_004a:  br.s       IL_009a

      IL_004c:  ldloc.s    V_6
      IL_004e:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
      IL_0053:  stloc.2
      IL_0054:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
      IL_0059:  callvirt   instance class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.CodeGenUtil::get_ReservedKeywords()
      IL_005e:  ldloc.2
      IL_005f:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Contains(!0)
      IL_0064:  brfalse.s  IL_007c

      IL_0066:  ldstr      "Enum symbol "
      IL_006b:  ldloc.2
      IL_006c:  ldstr      " is a C# reserved keyword"
      IL_0071:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0076:  newobj     instance void Avro.CodeGenException::.ctor(string)
      IL_007b:  throw

      IL_007c:  ldtoken    [mscorlib]System.Int32
      IL_0081:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_0086:  ldloc.2
      IL_0087:  newobj     instance void [System]System.CodeDom.CodeMemberField::.ctor(class [mscorlib]System.Type,
                                                                                       string)
      IL_008c:  stloc.3
      IL_008d:  ldloc.1
      IL_008e:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
      IL_0093:  ldloc.3
      IL_0094:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
      IL_0099:  pop
      IL_009a:  ldloc.s    V_6
      IL_009c:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00a1:  brtrue.s   IL_004c

      IL_00a3:  leave.s    IL_00b1

    }  // end .try
    finally
    {
      IL_00a5:  ldloc.s    V_6
      IL_00a7:  brfalse.s  IL_00b0

      IL_00a9:  ldloc.s    V_6
      IL_00ab:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00b0:  endfinally
    }  // end handler
    IL_00b1:  ldloc.0
    IL_00b2:  callvirt   instance string Avro.NamedSchema::get_Namespace()
    IL_00b7:  stloc.s    V_4
    IL_00b9:  ldloc.s    V_4
    IL_00bb:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_00c0:  brfalse.s  IL_00d8

    IL_00c2:  ldstr      "Namespace required for enum schema "
    IL_00c7:  ldloc.0
    IL_00c8:  callvirt   instance string Avro.Schema::get_Name()
    IL_00cd:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_00d2:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_00d7:  throw

    IL_00d8:  ldarg.0
    IL_00d9:  ldloc.s    V_4
    IL_00db:  callvirt   instance class [System]System.CodeDom.CodeNamespace Avro.CodeGen::addNamespace(string)
    IL_00e0:  stloc.s    V_5
    IL_00e2:  ldloc.s    V_5
    IL_00e4:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
    IL_00e9:  ldloc.1
    IL_00ea:  callvirt   instance int32 [System]System.CodeDom.CodeTypeDeclarationCollection::Add(class [System]System.CodeDom.CodeTypeDeclaration)
    IL_00ef:  pop
    IL_00f0:  ret
  } // end of method CodeGen::processEnum

  .method family hidebysig newslot virtual 
          instance class [System]System.CodeDom.CodeTypeDeclaration 
          processRecord(class Avro.Schema schema) cil managed
  {
    // Code size       1059 (0x423)
    .maxstack  4
    .locals init (class Avro.RecordSchema V_0,
             class [System]System.CodeDom.CodeTypeDeclaration V_1,
             class [System]System.CodeDom.CodeMemberMethod V_2,
             class [mscorlib]System.Text.StringBuilder V_3,
             class [System]System.CodeDom.CodeMemberMethod V_4,
             class [mscorlib]System.Text.StringBuilder V_5,
             class Avro.Field V_6,
             bool V_7,
             string V_8,
             class [System]System.CodeDom.CodeTypeReference V_9,
             string V_10,
             class [System]System.CodeDom.CodeMemberField V_11,
             class [System]System.CodeDom.CodeCommentStatement V_12,
             class [System]System.CodeDom.CodeFieldReferenceExpression V_13,
             string V_14,
             class [System]System.CodeDom.CodeMemberProperty V_15,
             string V_16,
             class [System]System.CodeDom.CodeSnippetExpression V_17,
             class [System]System.CodeDom.CodeSnippetExpression V_18,
             string V_19,
             class [System]System.CodeDom.CodeNamespace V_20,
             valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field> V_21)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.RecordSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Unable to cast schema into a record"
    IL_000f:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0014:  throw

    IL_0015:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_001a:  ldloc.0
    IL_001b:  callvirt   instance string Avro.Schema::get_Name()
    IL_0020:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_0025:  newobj     instance void [System]System.CodeDom.CodeTypeDeclaration::.ctor(string)
    IL_002a:  stloc.1
    IL_002b:  ldloc.1
    IL_002c:  callvirt   instance class [System]System.CodeDom.CodeTypeReferenceCollection [System]System.CodeDom.CodeTypeDeclaration::get_BaseTypes()
    IL_0031:  ldstr      "ISpecificRecord"
    IL_0036:  callvirt   instance void [System]System.CodeDom.CodeTypeReferenceCollection::Add(string)
    IL_003b:  ldloc.1
    IL_003c:  ldc.i4     0x6000
    IL_0041:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_0046:  ldloc.1
    IL_0047:  ldc.i4.1
    IL_0048:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclaration::set_IsClass(bool)
    IL_004d:  ldloc.1
    IL_004e:  ldc.i4.1
    IL_004f:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclaration::set_IsPartial(bool)
    IL_0054:  ldarg.0
    IL_0055:  ldarg.1
    IL_0056:  ldloc.1
    IL_0057:  ldc.i4.0
    IL_0058:  callvirt   instance void Avro.CodeGen::createSchemaField(class Avro.Schema,
                                                                       class [System]System.CodeDom.CodeTypeDeclaration,
                                                                       bool)
    IL_005d:  newobj     instance void [System]System.CodeDom.CodeMemberMethod::.ctor()
    IL_0062:  stloc.2
    IL_0063:  ldloc.2
    IL_0064:  ldstr      "Get"
    IL_0069:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
    IL_006e:  ldloc.2
    IL_006f:  ldc.i4     0x6000
    IL_0074:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_0079:  ldloc.2
    IL_007a:  ldstr      "System.Object"
    IL_007f:  newobj     instance void [System]System.CodeDom.CodeTypeReference::.ctor(string)
    IL_0084:  callvirt   instance void [System]System.CodeDom.CodeMemberMethod::set_ReturnType(class [System]System.CodeDom.CodeTypeReference)
    IL_0089:  ldloc.2
    IL_008a:  callvirt   instance class [System]System.CodeDom.CodeParameterDeclarationExpressionCollection [System]System.CodeDom.CodeMemberMethod::get_Parameters()
    IL_008f:  ldtoken    [mscorlib]System.Int32
    IL_0094:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0099:  ldstr      "fieldPos"
    IL_009e:  newobj     instance void [System]System.CodeDom.CodeParameterDeclarationExpression::.ctor(class [mscorlib]System.Type,
                                                                                                        string)
    IL_00a3:  callvirt   instance int32 [System]System.CodeDom.CodeParameterDeclarationExpressionCollection::Add(class [System]System.CodeDom.CodeParameterDeclarationExpression)
    IL_00a8:  pop
    IL_00a9:  ldstr      "switch (fieldPos)\n\t\t\t{\n"
    IL_00ae:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor(string)
    IL_00b3:  stloc.3
    IL_00b4:  newobj     instance void [System]System.CodeDom.CodeMemberMethod::.ctor()
    IL_00b9:  stloc.s    V_4
    IL_00bb:  ldloc.s    V_4
    IL_00bd:  ldstr      "Put"
    IL_00c2:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
    IL_00c7:  ldloc.s    V_4
    IL_00c9:  ldc.i4     0x6000
    IL_00ce:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_00d3:  ldloc.s    V_4
    IL_00d5:  ldtoken    [mscorlib]System.Void
    IL_00da:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00df:  newobj     instance void [System]System.CodeDom.CodeTypeReference::.ctor(class [mscorlib]System.Type)
    IL_00e4:  callvirt   instance void [System]System.CodeDom.CodeMemberMethod::set_ReturnType(class [System]System.CodeDom.CodeTypeReference)
    IL_00e9:  ldloc.s    V_4
    IL_00eb:  callvirt   instance class [System]System.CodeDom.CodeParameterDeclarationExpressionCollection [System]System.CodeDom.CodeMemberMethod::get_Parameters()
    IL_00f0:  ldtoken    [mscorlib]System.Int32
    IL_00f5:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00fa:  ldstr      "fieldPos"
    IL_00ff:  newobj     instance void [System]System.CodeDom.CodeParameterDeclarationExpression::.ctor(class [mscorlib]System.Type,
                                                                                                        string)
    IL_0104:  callvirt   instance int32 [System]System.CodeDom.CodeParameterDeclarationExpressionCollection::Add(class [System]System.CodeDom.CodeParameterDeclarationExpression)
    IL_0109:  pop
    IL_010a:  ldloc.s    V_4
    IL_010c:  callvirt   instance class [System]System.CodeDom.CodeParameterDeclarationExpressionCollection [System]System.CodeDom.CodeMemberMethod::get_Parameters()
    IL_0111:  ldstr      "System.Object"
    IL_0116:  ldstr      "fieldValue"
    IL_011b:  newobj     instance void [System]System.CodeDom.CodeParameterDeclarationExpression::.ctor(string,
                                                                                                        string)
    IL_0120:  callvirt   instance int32 [System]System.CodeDom.CodeParameterDeclarationExpressionCollection::Add(class [System]System.CodeDom.CodeParameterDeclarationExpression)
    IL_0125:  pop
    IL_0126:  ldstr      "switch (fieldPos)\n\t\t\t{\n"
    IL_012b:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor(string)
    IL_0130:  stloc.s    V_5
    IL_0132:  ldloc.0
    IL_0133:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0138:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::GetEnumerator()
    IL_013d:  stloc.s    V_21
    .try
    {
      IL_013f:  br         IL_035a

      IL_0144:  ldloca.s   V_21
      IL_0146:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::get_Current()
      IL_014b:  stloc.s    V_6
      IL_014d:  ldc.i4.0
      IL_014e:  stloc.s    V_7
      IL_0150:  ldloc.s    V_6
      IL_0152:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_0157:  ldc.i4.0
      IL_0158:  ldloca.s   V_7
      IL_015a:  call       string Avro.CodeGen::getType(class Avro.Schema,
                                                        bool,
                                                        bool&)
      IL_015f:  stloc.s    V_8
      IL_0161:  ldloc.s    V_8
      IL_0163:  newobj     instance void [System]System.CodeDom.CodeTypeReference::.ctor(string)
      IL_0168:  stloc.s    V_9
      IL_016a:  ldstr      "_"
      IL_016f:  ldloc.s    V_6
      IL_0171:  ldfld      string Avro.Field::Name
      IL_0176:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_017b:  stloc.s    V_10
      IL_017d:  ldloc.s    V_9
      IL_017f:  ldloc.s    V_10
      IL_0181:  newobj     instance void [System]System.CodeDom.CodeMemberField::.ctor(class [System]System.CodeDom.CodeTypeReference,
                                                                                       string)
      IL_0186:  stloc.s    V_11
      IL_0188:  ldloc.s    V_11
      IL_018a:  ldc.i4     0x5000
      IL_018f:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
      IL_0194:  ldnull
      IL_0195:  stloc.s    V_12
      IL_0197:  ldloc.s    V_6
      IL_0199:  callvirt   instance string Avro.Field::get_Documentation()
      IL_019e:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
      IL_01a3:  brtrue.s   IL_01c7

      IL_01a5:  ldarg.0
      IL_01a6:  ldloc.s    V_6
      IL_01a8:  callvirt   instance string Avro.Field::get_Documentation()
      IL_01ad:  callvirt   instance class [System]System.CodeDom.CodeCommentStatement Avro.CodeGen::createDocComment(string)
      IL_01b2:  stloc.s    V_12
      IL_01b4:  ldloc.s    V_12
      IL_01b6:  brfalse.s  IL_01c7

      IL_01b8:  ldloc.s    V_11
      IL_01ba:  callvirt   instance class [System]System.CodeDom.CodeCommentStatementCollection [System]System.CodeDom.CodeTypeMember::get_Comments()
      IL_01bf:  ldloc.s    V_12
      IL_01c1:  callvirt   instance int32 [System]System.CodeDom.CodeCommentStatementCollection::Add(class [System]System.CodeDom.CodeCommentStatement)
      IL_01c6:  pop
      IL_01c7:  ldloc.1
      IL_01c8:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
      IL_01cd:  ldloc.s    V_11
      IL_01cf:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
      IL_01d4:  pop
      IL_01d5:  newobj     instance void [System]System.CodeDom.CodeThisReferenceExpression::.ctor()
      IL_01da:  ldloc.s    V_10
      IL_01dc:  newobj     instance void [System]System.CodeDom.CodeFieldReferenceExpression::.ctor(class [System]System.CodeDom.CodeExpression,
                                                                                                    string)
      IL_01e1:  stloc.s    V_13
      IL_01e3:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
      IL_01e8:  ldloc.s    V_6
      IL_01ea:  ldfld      string Avro.Field::Name
      IL_01ef:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
      IL_01f4:  stloc.s    V_14
      IL_01f6:  newobj     instance void [System]System.CodeDom.CodeMemberProperty::.ctor()
      IL_01fb:  stloc.s    V_15
      IL_01fd:  ldloc.s    V_15
      IL_01ff:  ldc.i4     0x6002
      IL_0204:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
      IL_0209:  ldloc.s    V_15
      IL_020b:  ldloc.s    V_14
      IL_020d:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
      IL_0212:  ldloc.s    V_15
      IL_0214:  ldloc.s    V_9
      IL_0216:  callvirt   instance void [System]System.CodeDom.CodeMemberProperty::set_Type(class [System]System.CodeDom.CodeTypeReference)
      IL_021b:  ldloc.s    V_15
      IL_021d:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberProperty::get_GetStatements()
      IL_0222:  ldloc.s    V_13
      IL_0224:  newobj     instance void [System]System.CodeDom.CodeMethodReturnStatement::.ctor(class [System]System.CodeDom.CodeExpression)
      IL_0229:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeStatement)
      IL_022e:  pop
      IL_022f:  ldloc.s    V_15
      IL_0231:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberProperty::get_SetStatements()
      IL_0236:  ldloc.s    V_13
      IL_0238:  newobj     instance void [System]System.CodeDom.CodePropertySetValueReferenceExpression::.ctor()
      IL_023d:  newobj     instance void [System]System.CodeDom.CodeAssignStatement::.ctor(class [System]System.CodeDom.CodeExpression,
                                                                                           class [System]System.CodeDom.CodeExpression)
      IL_0242:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeStatement)
      IL_0247:  pop
      IL_0248:  ldloc.s    V_12
      IL_024a:  brfalse.s  IL_025b

      IL_024c:  ldloc.s    V_15
      IL_024e:  callvirt   instance class [System]System.CodeDom.CodeCommentStatementCollection [System]System.CodeDom.CodeTypeMember::get_Comments()
      IL_0253:  ldloc.s    V_12
      IL_0255:  callvirt   instance int32 [System]System.CodeDom.CodeCommentStatementCollection::Add(class [System]System.CodeDom.CodeCommentStatement)
      IL_025a:  pop
      IL_025b:  ldloc.1
      IL_025c:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
      IL_0261:  ldloc.s    V_15
      IL_0263:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
      IL_0268:  pop
      IL_0269:  ldloc.3
      IL_026a:  ldstr      "\t\t\tcase "
      IL_026f:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0274:  pop
      IL_0275:  ldloc.3
      IL_0276:  ldloc.s    V_6
      IL_0278:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_027d:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(int32)
      IL_0282:  pop
      IL_0283:  ldloc.3
      IL_0284:  ldstr      ": return this."
      IL_0289:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_028e:  pop
      IL_028f:  ldloc.3
      IL_0290:  ldloc.s    V_14
      IL_0292:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0297:  pop
      IL_0298:  ldloc.3
      IL_0299:  ldstr      ";\n"
      IL_029e:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02a3:  pop
      IL_02a4:  ldloc.s    V_5
      IL_02a6:  ldstr      "\t\t\tcase "
      IL_02ab:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02b0:  pop
      IL_02b1:  ldloc.s    V_5
      IL_02b3:  ldloc.s    V_6
      IL_02b5:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_02ba:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(int32)
      IL_02bf:  pop
      IL_02c0:  ldloc.s    V_5
      IL_02c2:  ldstr      ": this."
      IL_02c7:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02cc:  pop
      IL_02cd:  ldloc.s    V_5
      IL_02cf:  ldloc.s    V_14
      IL_02d1:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02d6:  pop
      IL_02d7:  ldloc.s    V_7
      IL_02d9:  brfalse.s  IL_0336

      IL_02db:  ldloc.s    V_5
      IL_02dd:  ldstr      " = fieldValue == null \? ("
      IL_02e2:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02e7:  pop
      IL_02e8:  ldloc.s    V_5
      IL_02ea:  ldloc.s    V_8
      IL_02ec:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02f1:  pop
      IL_02f2:  ldloc.s    V_5
      IL_02f4:  ldstr      ")null : ("
      IL_02f9:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02fe:  pop
      IL_02ff:  ldloc.s    V_8
      IL_0301:  ldc.i4.0
      IL_0302:  ldc.i4.s   16
      IL_0304:  callvirt   instance string [mscorlib]System.String::Remove(int32,
                                                                           int32)
      IL_0309:  stloc.s    V_16
      IL_030b:  ldloc.s    V_16
      IL_030d:  ldloc.s    V_16
      IL_030f:  callvirt   instance int32 [mscorlib]System.String::get_Length()
      IL_0314:  ldc.i4.1
      IL_0315:  sub
      IL_0316:  callvirt   instance string [mscorlib]System.String::Remove(int32)
      IL_031b:  stloc.s    V_16
      IL_031d:  ldloc.s    V_5
      IL_031f:  ldloc.s    V_16
      IL_0321:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0326:  pop
      IL_0327:  ldloc.s    V_5
      IL_0329:  ldstr      ")fieldValue; break;\n"
      IL_032e:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0333:  pop
      IL_0334:  br.s       IL_035a

      IL_0336:  ldloc.s    V_5
      IL_0338:  ldstr      " = ("
      IL_033d:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0342:  pop
      IL_0343:  ldloc.s    V_5
      IL_0345:  ldloc.s    V_8
      IL_0347:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_034c:  pop
      IL_034d:  ldloc.s    V_5
      IL_034f:  ldstr      ")fieldValue; break;\n"
      IL_0354:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0359:  pop
      IL_035a:  ldloca.s   V_21
      IL_035c:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::MoveNext()
      IL_0361:  brtrue     IL_0144

      IL_0366:  leave.s    IL_0376

    }  // end .try
    finally
    {
      IL_0368:  ldloca.s   V_21
      IL_036a:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>
      IL_0370:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0375:  endfinally
    }  // end handler
    IL_0376:  ldloc.3
    IL_0377:  ldstr      "\t\t\tdefault: throw new AvroRuntimeException(\"Bad in"
    + "dex \" + fieldPos + \" in Get()\");\n\t\t\t}"
    IL_037c:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0381:  pop
    IL_0382:  ldloc.3
    IL_0383:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0388:  newobj     instance void [System]System.CodeDom.CodeSnippetExpression::.ctor(string)
    IL_038d:  stloc.s    V_17
    IL_038f:  ldloc.2
    IL_0390:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberMethod::get_Statements()
    IL_0395:  ldloc.s    V_17
    IL_0397:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeExpression)
    IL_039c:  pop
    IL_039d:  ldloc.1
    IL_039e:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_03a3:  ldloc.2
    IL_03a4:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_03a9:  pop
    IL_03aa:  ldloc.s    V_5
    IL_03ac:  ldstr      "\t\t\tdefault: throw new AvroRuntimeException(\"Bad in"
    + "dex \" + fieldPos + \" in Put()\");\n\t\t\t}"
    IL_03b1:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_03b6:  pop
    IL_03b7:  ldloc.s    V_5
    IL_03b9:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_03be:  newobj     instance void [System]System.CodeDom.CodeSnippetExpression::.ctor(string)
    IL_03c3:  stloc.s    V_18
    IL_03c5:  ldloc.s    V_4
    IL_03c7:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberMethod::get_Statements()
    IL_03cc:  ldloc.s    V_18
    IL_03ce:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeExpression)
    IL_03d3:  pop
    IL_03d4:  ldloc.1
    IL_03d5:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_03da:  ldloc.s    V_4
    IL_03dc:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_03e1:  pop
    IL_03e2:  ldloc.0
    IL_03e3:  callvirt   instance string Avro.NamedSchema::get_Namespace()
    IL_03e8:  stloc.s    V_19
    IL_03ea:  ldloc.s    V_19
    IL_03ec:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_03f1:  brfalse.s  IL_0409

    IL_03f3:  ldstr      "Namespace required for record schema "
    IL_03f8:  ldloc.0
    IL_03f9:  callvirt   instance string Avro.Schema::get_Name()
    IL_03fe:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0403:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0408:  throw

    IL_0409:  ldarg.0
    IL_040a:  ldloc.s    V_19
    IL_040c:  callvirt   instance class [System]System.CodeDom.CodeNamespace Avro.CodeGen::addNamespace(string)
    IL_0411:  stloc.s    V_20
    IL_0413:  ldloc.s    V_20
    IL_0415:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
    IL_041a:  ldloc.1
    IL_041b:  callvirt   instance int32 [System]System.CodeDom.CodeTypeDeclarationCollection::Add(class [System]System.CodeDom.CodeTypeDeclaration)
    IL_0420:  pop
    IL_0421:  ldloc.1
    IL_0422:  ret
  } // end of method CodeGen::processRecord

  .method assembly hidebysig static string 
          getType(class Avro.Schema schema,
                  bool nullible,
                  bool& nullibleEnum) cil managed
  {
    // Code size       570 (0x23a)
    .maxstack  4
    .locals init (class Avro.NamedSchema V_0,
             class Avro.ArraySchema V_1,
             class Avro.MapSchema V_2,
             class Avro.UnionSchema V_3,
             class Avro.Schema V_4,
             valuetype Avro.Schema/Type V_5,
             object[] V_6)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  stloc.s    V_5
    IL_0008:  ldloc.s    V_5
    IL_000a:  switch     ( 
                          IL_0050,
                          IL_0056,
                          IL_006f,
                          IL_0088,
                          IL_00a1,
                          IL_00ba,
                          IL_00d3,
                          IL_00e3,
                          IL_013f,
                          IL_00f3,
                          IL_0165,
                          IL_0197,
                          IL_01c9,
                          IL_013f,
                          IL_013f)
    IL_004b:  br         IL_01fa

    IL_0050:  ldstr      "System.Object"
    IL_0055:  ret

    IL_0056:  ldarg.1
    IL_0057:  brfalse.s  IL_005f

    IL_0059:  ldstr      "System.Nullable<bool>"
    IL_005e:  ret

    IL_005f:  ldtoken    [mscorlib]System.Boolean
    IL_0064:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0069:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_006e:  ret

    IL_006f:  ldarg.1
    IL_0070:  brfalse.s  IL_0078

    IL_0072:  ldstr      "System.Nullable<int>"
    IL_0077:  ret

    IL_0078:  ldtoken    [mscorlib]System.Int32
    IL_007d:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0082:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0087:  ret

    IL_0088:  ldarg.1
    IL_0089:  brfalse.s  IL_0091

    IL_008b:  ldstr      "System.Nullable<long>"
    IL_0090:  ret

    IL_0091:  ldtoken    [mscorlib]System.Int64
    IL_0096:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_009b:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00a0:  ret

    IL_00a1:  ldarg.1
    IL_00a2:  brfalse.s  IL_00aa

    IL_00a4:  ldstr      "System.Nullable<float>"
    IL_00a9:  ret

    IL_00aa:  ldtoken    [mscorlib]System.Single
    IL_00af:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00b4:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00b9:  ret

    IL_00ba:  ldarg.1
    IL_00bb:  brfalse.s  IL_00c3

    IL_00bd:  ldstr      "System.Nullable<double>"
    IL_00c2:  ret

    IL_00c3:  ldtoken    [mscorlib]System.Double
    IL_00c8:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00cd:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00d2:  ret

    IL_00d3:  ldtoken    uint8[]
    IL_00d8:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00dd:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00e2:  ret

    IL_00e3:  ldtoken    [mscorlib]System.String
    IL_00e8:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00ed:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00f2:  ret

    IL_00f3:  ldarg.0
    IL_00f4:  isinst     Avro.NamedSchema
    IL_00f9:  stloc.0
    IL_00fa:  ldloc.0
    IL_00fb:  brtrue.s   IL_0108

    IL_00fd:  ldstr      "Unable to cast schema into a named schema"
    IL_0102:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0107:  throw

    IL_0108:  ldarg.1
    IL_0109:  brfalse.s  IL_012e

    IL_010b:  ldarg.2
    IL_010c:  ldc.i4.1
    IL_010d:  stind.i1
    IL_010e:  ldstr      "System.Nullable<"
    IL_0113:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0118:  ldloc.0
    IL_0119:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_011e:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_0123:  ldstr      ">"
    IL_0128:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_012d:  ret

    IL_012e:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0133:  ldloc.0
    IL_0134:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_0139:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_013e:  ret

    IL_013f:  ldarg.0
    IL_0140:  isinst     Avro.NamedSchema
    IL_0145:  stloc.0
    IL_0146:  ldloc.0
    IL_0147:  brtrue.s   IL_0154

    IL_0149:  ldstr      "Unable to cast schema into a named schema"
    IL_014e:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0153:  throw

    IL_0154:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0159:  ldloc.0
    IL_015a:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_015f:  callvirt   instance string Avro.CodeGenUtil::Mangle(string)
    IL_0164:  ret

    IL_0165:  ldarg.0
    IL_0166:  isinst     Avro.ArraySchema
    IL_016b:  stloc.1
    IL_016c:  ldloc.1
    IL_016d:  brtrue.s   IL_017a

    IL_016f:  ldstr      "Unable to cast schema into an array schema"
    IL_0174:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0179:  throw

    IL_017a:  ldstr      "IList<"
    IL_017f:  ldloc.1
    IL_0180:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0185:  ldc.i4.0
    IL_0186:  ldarg.2
    IL_0187:  call       string Avro.CodeGen::getType(class Avro.Schema,
                                                      bool,
                                                      bool&)
    IL_018c:  ldstr      ">"
    IL_0191:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0196:  ret

    IL_0197:  ldarg.0
    IL_0198:  isinst     Avro.MapSchema
    IL_019d:  stloc.2
    IL_019e:  ldloc.2
    IL_019f:  brtrue.s   IL_01ac

    IL_01a1:  ldstr      "Unable to cast schema into a map schema"
    IL_01a6:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_01ab:  throw

    IL_01ac:  ldstr      "IDictionary<string,"
    IL_01b1:  ldloc.2
    IL_01b2:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_01b7:  ldc.i4.0
    IL_01b8:  ldarg.2
    IL_01b9:  call       string Avro.CodeGen::getType(class Avro.Schema,
                                                      bool,
                                                      bool&)
    IL_01be:  ldstr      ">"
    IL_01c3:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_01c8:  ret

    IL_01c9:  ldarg.0
    IL_01ca:  isinst     Avro.UnionSchema
    IL_01cf:  stloc.3
    IL_01d0:  ldloc.3
    IL_01d1:  brtrue.s   IL_01de

    IL_01d3:  ldstr      "Unable to cast schema into a union schema"
    IL_01d8:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_01dd:  throw

    IL_01de:  ldloc.3
    IL_01df:  call       class Avro.Schema Avro.CodeGen::getNullableType(class Avro.UnionSchema)
    IL_01e4:  stloc.s    V_4
    IL_01e6:  ldloc.s    V_4
    IL_01e8:  brtrue.s   IL_01f0

    IL_01ea:  ldstr      "System.Object"
    IL_01ef:  ret

    IL_01f0:  ldloc.s    V_4
    IL_01f2:  ldc.i4.1
    IL_01f3:  ldarg.2
    IL_01f4:  call       string Avro.CodeGen::getType(class Avro.Schema,
                                                      bool,
                                                      bool&)
    IL_01f9:  ret

    IL_01fa:  ldc.i4.4
    IL_01fb:  newarr     [mscorlib]System.Object
    IL_0200:  stloc.s    V_6
    IL_0202:  ldloc.s    V_6
    IL_0204:  ldc.i4.0
    IL_0205:  ldstr      "Unable to generate CodeTypeReference for "
    IL_020a:  stelem.ref
    IL_020b:  ldloc.s    V_6
    IL_020d:  ldc.i4.1
    IL_020e:  ldarg.0
    IL_020f:  callvirt   instance string Avro.Schema::get_Name()
    IL_0214:  stelem.ref
    IL_0215:  ldloc.s    V_6
    IL_0217:  ldc.i4.2
    IL_0218:  ldstr      " type "
    IL_021d:  stelem.ref
    IL_021e:  ldloc.s    V_6
    IL_0220:  ldc.i4.3
    IL_0221:  ldarg.0
    IL_0222:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0227:  box        Avro.Schema/Type
    IL_022c:  stelem.ref
    IL_022d:  ldloc.s    V_6
    IL_022f:  call       string [mscorlib]System.String::Concat(object[])
    IL_0234:  newobj     instance void Avro.CodeGenException::.ctor(string)
    IL_0239:  throw
  } // end of method CodeGen::getType

  .method public hidebysig static class Avro.Schema 
          getNullableType(class Avro.UnionSchema schema) cil managed
  {
    // Code size       75 (0x4b)
    .maxstack  2
    .locals init (class Avro.Schema V_0,
             bool V_1,
             class Avro.Schema V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_3)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldarg.0
    IL_0003:  callvirt   instance int32 Avro.UnionSchema::get_Count()
    IL_0008:  ldc.i4.2
    IL_0009:  bne.un.s   IL_0049

    IL_000b:  ldc.i4.0
    IL_000c:  stloc.1
    IL_000d:  ldarg.0
    IL_000e:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_0013:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0018:  stloc.3
    .try
    {
      IL_0019:  br.s       IL_0030

      IL_001b:  ldloc.3
      IL_001c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0021:  stloc.2
      IL_0022:  ldloc.2
      IL_0023:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
      IL_0028:  brtrue.s   IL_002e

      IL_002a:  ldc.i4.1
      IL_002b:  stloc.1
      IL_002c:  br.s       IL_0030

      IL_002e:  ldloc.2
      IL_002f:  stloc.0
      IL_0030:  ldloc.3
      IL_0031:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0036:  brtrue.s   IL_001b

      IL_0038:  leave.s    IL_0044

    }  // end .try
    finally
    {
      IL_003a:  ldloc.3
      IL_003b:  brfalse.s  IL_0043

      IL_003d:  ldloc.3
      IL_003e:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0043:  endfinally
    }  // end handler
    IL_0044:  ldloc.1
    IL_0045:  brtrue.s   IL_0049

    IL_0047:  ldnull
    IL_0048:  stloc.0
    IL_0049:  ldloc.0
    IL_004a:  ret
  } // end of method CodeGen::getNullableType

  .method family hidebysig newslot virtual 
          instance void  createSchemaField(class Avro.Schema schema,
                                           class [System]System.CodeDom.CodeTypeDeclaration ctd,
                                           bool overrideFlag) cil managed
  {
    // Code size       228 (0xe4)
    .maxstack  4
    .locals init (class [System]System.CodeDom.CodeTypeReference V_0,
             string V_1,
             class [System]System.CodeDom.CodeMemberField V_2,
             class [System]System.CodeDom.CodePrimitiveExpression V_3,
             class [System]System.CodeDom.CodeMethodInvokeExpression V_4,
             class [System]System.CodeDom.CodeMemberProperty V_5,
             class [System]System.CodeDom.CodeExpression[] V_6)
    IL_0000:  ldstr      "Schema"
    IL_0005:  newobj     instance void [System]System.CodeDom.CodeTypeReference::.ctor(string)
    IL_000a:  stloc.0
    IL_000b:  ldstr      "_SCHEMA"
    IL_0010:  stloc.1
    IL_0011:  ldloc.0
    IL_0012:  ldloc.1
    IL_0013:  newobj     instance void [System]System.CodeDom.CodeMemberField::.ctor(class [System]System.CodeDom.CodeTypeReference,
                                                                                     string)
    IL_0018:  stloc.2
    IL_0019:  ldloc.2
    IL_001a:  ldc.i4     0x5003
    IL_001f:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_0024:  ldarg.1
    IL_0025:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_002a:  newobj     instance void [System]System.CodeDom.CodePrimitiveExpression::.ctor(object)
    IL_002f:  stloc.3
    IL_0030:  ldtoken    Avro.Schema
    IL_0035:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_003a:  newobj     instance void [System]System.CodeDom.CodeTypeReferenceExpression::.ctor(class [mscorlib]System.Type)
    IL_003f:  ldstr      "Parse"
    IL_0044:  newobj     instance void [System]System.CodeDom.CodeMethodReferenceExpression::.ctor(class [System]System.CodeDom.CodeExpression,
                                                                                                   string)
    IL_0049:  ldc.i4.1
    IL_004a:  newarr     [System]System.CodeDom.CodeExpression
    IL_004f:  stloc.s    V_6
    IL_0051:  ldloc.s    V_6
    IL_0053:  ldc.i4.0
    IL_0054:  ldloc.3
    IL_0055:  stelem.ref
    IL_0056:  ldloc.s    V_6
    IL_0058:  newobj     instance void [System]System.CodeDom.CodeMethodInvokeExpression::.ctor(class [System]System.CodeDom.CodeMethodReferenceExpression,
                                                                                                class [System]System.CodeDom.CodeExpression[])
    IL_005d:  stloc.s    V_4
    IL_005f:  ldloc.2
    IL_0060:  ldloc.s    V_4
    IL_0062:  callvirt   instance void [System]System.CodeDom.CodeMemberField::set_InitExpression(class [System]System.CodeDom.CodeExpression)
    IL_0067:  ldarg.2
    IL_0068:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_006d:  ldloc.2
    IL_006e:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_0073:  pop
    IL_0074:  newobj     instance void [System]System.CodeDom.CodeMemberProperty::.ctor()
    IL_0079:  stloc.s    V_5
    IL_007b:  ldloc.s    V_5
    IL_007d:  ldc.i4     0x6000
    IL_0082:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_0087:  ldarg.3
    IL_0088:  brfalse.s  IL_0099

    IL_008a:  ldloc.s    V_5
    IL_008c:  dup
    IL_008d:  callvirt   instance valuetype [System]System.CodeDom.MemberAttributes [System]System.CodeDom.CodeTypeMember::get_Attributes()
    IL_0092:  ldc.i4.4
    IL_0093:  or
    IL_0094:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Attributes(valuetype [System]System.CodeDom.MemberAttributes)
    IL_0099:  ldloc.s    V_5
    IL_009b:  ldstr      "Schema"
    IL_00a0:  callvirt   instance void [System]System.CodeDom.CodeTypeMember::set_Name(string)
    IL_00a5:  ldloc.s    V_5
    IL_00a7:  ldloc.0
    IL_00a8:  callvirt   instance void [System]System.CodeDom.CodeMemberProperty::set_Type(class [System]System.CodeDom.CodeTypeReference)
    IL_00ad:  ldloc.s    V_5
    IL_00af:  callvirt   instance class [System]System.CodeDom.CodeStatementCollection [System]System.CodeDom.CodeMemberProperty::get_GetStatements()
    IL_00b4:  ldarg.2
    IL_00b5:  callvirt   instance string [System]System.CodeDom.CodeTypeMember::get_Name()
    IL_00ba:  ldstr      "."
    IL_00bf:  ldloc.1
    IL_00c0:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_00c5:  newobj     instance void [System]System.CodeDom.CodeTypeReferenceExpression::.ctor(string)
    IL_00ca:  newobj     instance void [System]System.CodeDom.CodeMethodReturnStatement::.ctor(class [System]System.CodeDom.CodeExpression)
    IL_00cf:  callvirt   instance int32 [System]System.CodeDom.CodeStatementCollection::Add(class [System]System.CodeDom.CodeStatement)
    IL_00d4:  pop
    IL_00d5:  ldarg.2
    IL_00d6:  callvirt   instance class [System]System.CodeDom.CodeTypeMemberCollection [System]System.CodeDom.CodeTypeDeclaration::get_Members()
    IL_00db:  ldloc.s    V_5
    IL_00dd:  callvirt   instance int32 [System]System.CodeDom.CodeTypeMemberCollection::Add(class [System]System.CodeDom.CodeTypeMember)
    IL_00e2:  pop
    IL_00e3:  ret
  } // end of method CodeGen::createSchemaField

  .method family hidebysig newslot virtual 
          instance class [System]System.CodeDom.CodeCommentStatement 
          createDocComment(string comment) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  2
    .locals init (string V_0)
    IL_0000:  ldstr      "<summary>\r\n {0}\r\n </summary>"
    IL_0005:  ldarg.1
    IL_0006:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  ldc.i4.1
    IL_000e:  newobj     instance void [System]System.CodeDom.CodeCommentStatement::.ctor(string,
                                                                                          bool)
    IL_0013:  ret
  } // end of method CodeGen::createDocComment

  .method public hidebysig newslot virtual 
          instance void  WriteCompileUnit(string outputFile) cil managed
  {
    // Code size       75 (0x4b)
    .maxstack  4
    .locals init (class [System]Microsoft.CSharp.CSharpCodeProvider V_0,
             class [System]System.CodeDom.Compiler.CodeGeneratorOptions V_1,
             class [mscorlib]System.IO.StreamWriter V_2)
    IL_0000:  newobj     instance void [System]Microsoft.CSharp.CSharpCodeProvider::.ctor()
    IL_0005:  stloc.0
    IL_0006:  newobj     instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::.ctor()
    IL_000b:  stloc.1
    IL_000c:  ldloc.1
    IL_000d:  ldstr      "C"
    IL_0012:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_BracingStyle(string)
    IL_0017:  ldloc.1
    IL_0018:  ldstr      "\t"
    IL_001d:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_IndentString(string)
    IL_0022:  ldloc.1
    IL_0023:  ldc.i4.0
    IL_0024:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_BlankLinesBetweenMembers(bool)
    IL_0029:  ldarg.1
    IL_002a:  newobj     instance void [mscorlib]System.IO.StreamWriter::.ctor(string)
    IL_002f:  stloc.2
    .try
    {
      IL_0030:  ldloc.0
      IL_0031:  ldarg.0
      IL_0032:  call       instance class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::get_CompileUnit()
      IL_0037:  ldloc.2
      IL_0038:  ldloc.1
      IL_0039:  callvirt   instance void [System]System.CodeDom.Compiler.CodeDomProvider::GenerateCodeFromCompileUnit(class [System]System.CodeDom.CodeCompileUnit,
                                                                                                                      class [mscorlib]System.IO.TextWriter,
                                                                                                                      class [System]System.CodeDom.Compiler.CodeGeneratorOptions)
      IL_003e:  leave.s    IL_004a

    }  // end .try
    finally
    {
      IL_0040:  ldloc.2
      IL_0041:  brfalse.s  IL_0049

      IL_0043:  ldloc.2
      IL_0044:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0049:  endfinally
    }  // end handler
    IL_004a:  ret
  } // end of method CodeGen::WriteCompileUnit

  .method public hidebysig newslot virtual 
          instance void  WriteTypes(string outputdir) cil managed
  {
    // Code size       364 (0x16c)
    .maxstack  5
    .locals init (class [System]Microsoft.CSharp.CSharpCodeProvider V_0,
             class [System]System.CodeDom.Compiler.CodeGeneratorOptions V_1,
             class [System]System.CodeDom.CodeNamespaceCollection V_2,
             int32 V_3,
             class [System]System.CodeDom.CodeNamespace V_4,
             string V_5,
             class [System]System.CodeDom.CodeNamespace V_6,
             class [System]System.CodeDom.CodeNamespaceImport V_7,
             class [System]System.CodeDom.CodeTypeDeclarationCollection V_8,
             int32 V_9,
             class [System]System.CodeDom.CodeTypeDeclaration V_10,
             string V_11,
             class [mscorlib]System.IO.StreamWriter V_12,
             class [System]System.CodeDom.CodeNamespaceImport[] V_13,
             int32 V_14)
    IL_0000:  newobj     instance void [System]Microsoft.CSharp.CSharpCodeProvider::.ctor()
    IL_0005:  stloc.0
    IL_0006:  newobj     instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::.ctor()
    IL_000b:  stloc.1
    IL_000c:  ldloc.1
    IL_000d:  ldstr      "C"
    IL_0012:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_BracingStyle(string)
    IL_0017:  ldloc.1
    IL_0018:  ldstr      "\t"
    IL_001d:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_IndentString(string)
    IL_0022:  ldloc.1
    IL_0023:  ldc.i4.0
    IL_0024:  callvirt   instance void [System]System.CodeDom.Compiler.CodeGeneratorOptions::set_BlankLinesBetweenMembers(bool)
    IL_0029:  ldarg.0
    IL_002a:  call       instance class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::get_CompileUnit()
    IL_002f:  callvirt   instance class [System]System.CodeDom.CodeNamespaceCollection [System]System.CodeDom.CodeCompileUnit::get_Namespaces()
    IL_0034:  stloc.2
    IL_0035:  ldc.i4.0
    IL_0036:  stloc.3
    IL_0037:  br         IL_015f

    IL_003c:  ldloc.2
    IL_003d:  ldloc.3
    IL_003e:  callvirt   instance class [System]System.CodeDom.CodeNamespace [System]System.CodeDom.CodeNamespaceCollection::get_Item(int32)
    IL_0043:  stloc.s    V_4
    IL_0045:  ldarg.1
    IL_0046:  ldstr      "\\"
    IL_004b:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_0050:  ldloc.s    V_4
    IL_0052:  callvirt   instance string [System]System.CodeDom.CodeNamespace::get_Name()
    IL_0057:  callvirt   instance string Avro.CodeGenUtil::UnMangle(string)
    IL_005c:  ldc.i4.s   46
    IL_005e:  ldc.i4.s   92
    IL_0060:  callvirt   instance string [mscorlib]System.String::Replace(char,
                                                                          char)
    IL_0065:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_006a:  stloc.s    V_5
    IL_006c:  ldloc.s    V_5
    IL_006e:  call       class [mscorlib]System.IO.DirectoryInfo [mscorlib]System.IO.Directory::CreateDirectory(string)
    IL_0073:  pop
    IL_0074:  ldloc.s    V_4
    IL_0076:  callvirt   instance string [System]System.CodeDom.CodeNamespace::get_Name()
    IL_007b:  newobj     instance void [System]System.CodeDom.CodeNamespace::.ctor(string)
    IL_0080:  stloc.s    V_6
    IL_0082:  ldloc.s    V_6
    IL_0084:  callvirt   instance class [System]System.CodeDom.CodeCommentStatementCollection [System]System.CodeDom.CodeNamespace::get_Comments()
    IL_0089:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_008e:  callvirt   instance class [System]System.CodeDom.CodeCommentStatement Avro.CodeGenUtil::get_FileComment()
    IL_0093:  callvirt   instance int32 [System]System.CodeDom.CodeCommentStatementCollection::Add(class [System]System.CodeDom.CodeCommentStatement)
    IL_0098:  pop
    IL_0099:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_009e:  callvirt   instance class [System]System.CodeDom.CodeNamespaceImport[] Avro.CodeGenUtil::get_NamespaceImports()
    IL_00a3:  stloc.s    V_13
    IL_00a5:  ldc.i4.0
    IL_00a6:  stloc.s    V_14
    IL_00a8:  br.s       IL_00c5

    IL_00aa:  ldloc.s    V_13
    IL_00ac:  ldloc.s    V_14
    IL_00ae:  ldelem.ref
    IL_00af:  stloc.s    V_7
    IL_00b1:  ldloc.s    V_6
    IL_00b3:  callvirt   instance class [System]System.CodeDom.CodeNamespaceImportCollection [System]System.CodeDom.CodeNamespace::get_Imports()
    IL_00b8:  ldloc.s    V_7
    IL_00ba:  callvirt   instance void [System]System.CodeDom.CodeNamespaceImportCollection::Add(class [System]System.CodeDom.CodeNamespaceImport)
    IL_00bf:  ldloc.s    V_14
    IL_00c1:  ldc.i4.1
    IL_00c2:  add
    IL_00c3:  stloc.s    V_14
    IL_00c5:  ldloc.s    V_14
    IL_00c7:  ldloc.s    V_13
    IL_00c9:  ldlen
    IL_00ca:  conv.i4
    IL_00cb:  blt.s      IL_00aa

    IL_00cd:  ldloc.s    V_4
    IL_00cf:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
    IL_00d4:  stloc.s    V_8
    IL_00d6:  ldc.i4.0
    IL_00d7:  stloc.s    V_9
    IL_00d9:  br.s       IL_0150

    IL_00db:  ldloc.s    V_8
    IL_00dd:  ldloc.s    V_9
    IL_00df:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclaration [System]System.CodeDom.CodeTypeDeclarationCollection::get_Item(int32)
    IL_00e4:  stloc.s    V_10
    IL_00e6:  ldloc.s    V_5
    IL_00e8:  ldstr      "\\"
    IL_00ed:  call       class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
    IL_00f2:  ldloc.s    V_10
    IL_00f4:  callvirt   instance string [System]System.CodeDom.CodeTypeMember::get_Name()
    IL_00f9:  callvirt   instance string Avro.CodeGenUtil::UnMangle(string)
    IL_00fe:  ldstr      ".cs"
    IL_0103:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string,
                                                                string)
    IL_0108:  stloc.s    V_11
    IL_010a:  ldloc.s    V_11
    IL_010c:  ldc.i4.0
    IL_010d:  newobj     instance void [mscorlib]System.IO.StreamWriter::.ctor(string,
                                                                               bool)
    IL_0112:  stloc.s    V_12
    .try
    {
      IL_0114:  ldloc.s    V_6
      IL_0116:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
      IL_011b:  ldloc.s    V_10
      IL_011d:  callvirt   instance int32 [System]System.CodeDom.CodeTypeDeclarationCollection::Add(class [System]System.CodeDom.CodeTypeDeclaration)
      IL_0122:  pop
      IL_0123:  ldloc.0
      IL_0124:  ldloc.s    V_6
      IL_0126:  ldloc.s    V_12
      IL_0128:  ldloc.1
      IL_0129:  callvirt   instance void [System]System.CodeDom.Compiler.CodeDomProvider::GenerateCodeFromNamespace(class [System]System.CodeDom.CodeNamespace,
                                                                                                                    class [mscorlib]System.IO.TextWriter,
                                                                                                                    class [System]System.CodeDom.Compiler.CodeGeneratorOptions)
      IL_012e:  ldloc.s    V_6
      IL_0130:  callvirt   instance class [System]System.CodeDom.CodeTypeDeclarationCollection [System]System.CodeDom.CodeNamespace::get_Types()
      IL_0135:  ldloc.s    V_10
      IL_0137:  callvirt   instance void [System]System.CodeDom.CodeTypeDeclarationCollection::Remove(class [System]System.CodeDom.CodeTypeDeclaration)
      IL_013c:  leave.s    IL_014a

    }  // end .try
    finally
    {
      IL_013e:  ldloc.s    V_12
      IL_0140:  brfalse.s  IL_0149

      IL_0142:  ldloc.s    V_12
      IL_0144:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0149:  endfinally
    }  // end handler
    IL_014a:  ldloc.s    V_9
    IL_014c:  ldc.i4.1
    IL_014d:  add
    IL_014e:  stloc.s    V_9
    IL_0150:  ldloc.s    V_9
    IL_0152:  ldloc.s    V_8
    IL_0154:  callvirt   instance int32 [mscorlib]System.Collections.CollectionBase::get_Count()
    IL_0159:  blt.s      IL_00db

    IL_015b:  ldloc.3
    IL_015c:  ldc.i4.1
    IL_015d:  add
    IL_015e:  stloc.3
    IL_015f:  ldloc.3
    IL_0160:  ldloc.2
    IL_0161:  callvirt   instance int32 [mscorlib]System.Collections.CollectionBase::get_Count()
    IL_0166:  blt        IL_003c

    IL_016b:  ret
  } // end of method CodeGen::WriteTypes

  .property instance class [System]System.CodeDom.CodeCompileUnit
          CompileUnit()
  {
    .get instance class [System]System.CodeDom.CodeCompileUnit Avro.CodeGen::get_CompileUnit()
    .set instance void Avro.CodeGen::set_CompileUnit(class [System]System.CodeDom.CodeCompileUnit)
  } // end of property CodeGen::CompileUnit
  .property instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>
          Schemas()
  {
    .get instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.CodeGen::get_Schemas()
    .set instance void Avro.CodeGen::set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
  } // end of property CodeGen::Schemas
  .property instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol>
          Protocols()
  {
    .get instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol> Avro.CodeGen::get_Protocols()
    .set instance void Avro.CodeGen::set_Protocols(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Protocol>)
  } // end of property CodeGen::Protocols
} // end of class Avro.CodeGen

.class private auto ansi beforefieldinit Avro.CodeGenException
       extends Avro.AvroException
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.AvroException::.ctor(string)
    IL_0007:  ret
  } // end of method CodeGenException::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s,
                               class [mscorlib]System.Exception inner) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.AvroException::.ctor(string,
                                                                 class [mscorlib]System.Exception)
    IL_0008:  ret
  } // end of method CodeGenException::.ctor

} // end of class Avro.CodeGenException

.class public auto ansi sealed beforefieldinit Avro.CodeGenUtil
       extends [mscorlib]System.Object
{
  .field private static literal char At = char(0x0040)
  .field private static literal char Dot = char(0x002E)
  .field public static literal string Object = "System.Object"
  .field private static initonly class Avro.CodeGenUtil 'instance'
  .field private class [System]System.CodeDom.CodeNamespaceImport[] '<NamespaceImports>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [System]System.CodeDom.CodeCommentStatement '<FileComment>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [System.Core]System.Collections.Generic.HashSet`1<string> '<ReservedKeywords>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname static 
          class Avro.CodeGenUtil  get_Instance() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldsfld     class Avro.CodeGenUtil Avro.CodeGenUtil::'instance'
    IL_0005:  ret
  } // end of method CodeGenUtil::get_Instance

  .method public hidebysig specialname instance class [System]System.CodeDom.CodeNamespaceImport[] 
          get_NamespaceImports() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.CodeDom.CodeNamespaceImport[] Avro.CodeGenUtil::'<NamespaceImports>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGenUtil::get_NamespaceImports

  .method private hidebysig specialname instance void 
          set_NamespaceImports(class [System]System.CodeDom.CodeNamespaceImport[] 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [System]System.CodeDom.CodeNamespaceImport[] Avro.CodeGenUtil::'<NamespaceImports>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGenUtil::set_NamespaceImports

  .method public hidebysig specialname instance class [System]System.CodeDom.CodeCommentStatement 
          get_FileComment() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System]System.CodeDom.CodeCommentStatement Avro.CodeGenUtil::'<FileComment>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGenUtil::get_FileComment

  .method private hidebysig specialname instance void 
          set_FileComment(class [System]System.CodeDom.CodeCommentStatement 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [System]System.CodeDom.CodeCommentStatement Avro.CodeGenUtil::'<FileComment>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGenUtil::set_FileComment

  .method public hidebysig specialname instance class [System.Core]System.Collections.Generic.HashSet`1<string> 
          get_ReservedKeywords() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.CodeGenUtil::'<ReservedKeywords>k__BackingField'
    IL_0006:  ret
  } // end of method CodeGenUtil::get_ReservedKeywords

  .method private hidebysig specialname instance void 
          set_ReservedKeywords(class [System.Core]System.Collections.Generic.HashSet`1<string> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.CodeGenUtil::'<ReservedKeywords>k__BackingField'
    IL_0007:  ret
  } // end of method CodeGenUtil::set_ReservedKeywords

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       1126 (0x466)
    .maxstack  4
    .locals init (class [System.Core]System.Collections.Generic.HashSet`1<string> V_0,
             class [System]System.CodeDom.CodeNamespaceImport[] V_1,
             object[] V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldc.i4.5
    IL_0008:  newarr     [System]System.CodeDom.CodeNamespaceImport
    IL_000d:  stloc.1
    IL_000e:  ldloc.1
    IL_000f:  ldc.i4.0
    IL_0010:  ldstr      "System"
    IL_0015:  newobj     instance void [System]System.CodeDom.CodeNamespaceImport::.ctor(string)
    IL_001a:  stelem.ref
    IL_001b:  ldloc.1
    IL_001c:  ldc.i4.1
    IL_001d:  ldstr      "System.Collections.Generic"
    IL_0022:  newobj     instance void [System]System.CodeDom.CodeNamespaceImport::.ctor(string)
    IL_0027:  stelem.ref
    IL_0028:  ldloc.1
    IL_0029:  ldc.i4.2
    IL_002a:  ldstr      "System.Text"
    IL_002f:  newobj     instance void [System]System.CodeDom.CodeNamespaceImport::.ctor(string)
    IL_0034:  stelem.ref
    IL_0035:  ldloc.1
    IL_0036:  ldc.i4.3
    IL_0037:  ldstr      "Avro"
    IL_003c:  newobj     instance void [System]System.CodeDom.CodeNamespaceImport::.ctor(string)
    IL_0041:  stelem.ref
    IL_0042:  ldloc.1
    IL_0043:  ldc.i4.4
    IL_0044:  ldstr      "Avro.Specific"
    IL_0049:  newobj     instance void [System]System.CodeDom.CodeNamespaceImport::.ctor(string)
    IL_004e:  stelem.ref
    IL_004f:  ldloc.1
    IL_0050:  call       instance void Avro.CodeGenUtil::set_NamespaceImports(class [System]System.CodeDom.CodeNamespaceImport[])
    IL_0055:  ldarg.0
    IL_0056:  ldc.i4.5
    IL_0057:  newarr     [mscorlib]System.Object
    IL_005c:  stloc.2
    IL_005d:  ldloc.2
    IL_005e:  ldc.i4.0
    IL_005f:  ldstr      "--------------------------------------------------"
    + "----------------------------\n <auto-generated>\n    Generated by "
    IL_0064:  stelem.ref
    IL_0065:  ldloc.2
    IL_0066:  ldc.i4.1
    IL_0067:  call       class [mscorlib]System.AppDomain [mscorlib]System.AppDomain::get_CurrentDomain()
    IL_006c:  callvirt   instance string [mscorlib]System.AppDomain::get_FriendlyName()
    IL_0071:  stelem.ref
    IL_0072:  ldloc.2
    IL_0073:  ldc.i4.2
    IL_0074:  ldstr      ", version "
    IL_0079:  stelem.ref
    IL_007a:  ldloc.2
    IL_007b:  ldc.i4.3
    IL_007c:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::GetExecutingAssembly()
    IL_0081:  callvirt   instance class [mscorlib]System.Reflection.AssemblyName [mscorlib]System.Reflection.Assembly::GetName()
    IL_0086:  callvirt   instance class [mscorlib]System.Version [mscorlib]System.Reflection.AssemblyName::get_Version()
    IL_008b:  stelem.ref
    IL_008c:  ldloc.2
    IL_008d:  ldc.i4.4
    IL_008e:  ldstr      "\n    Changes to this file may cause incorrect beha"
    + "vior and will be lost if code\n    is regenerated\n </auto-generated>\n --"
    + "-----------------------------------------------------------------------"
    + "-----"
    IL_0093:  stelem.ref
    IL_0094:  ldloc.2
    IL_0095:  call       string [mscorlib]System.String::Concat(object[])
    IL_009a:  newobj     instance void [System]System.CodeDom.CodeCommentStatement::.ctor(string)
    IL_009f:  call       instance void Avro.CodeGenUtil::set_FileComment(class [System]System.CodeDom.CodeCommentStatement)
    IL_00a4:  ldarg.0
    IL_00a5:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<string>::.ctor()
    IL_00aa:  stloc.0
    IL_00ab:  ldloc.0
    IL_00ac:  ldstr      "abstract"
    IL_00b1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00b6:  pop
    IL_00b7:  ldloc.0
    IL_00b8:  ldstr      "as"
    IL_00bd:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00c2:  pop
    IL_00c3:  ldloc.0
    IL_00c4:  ldstr      "base"
    IL_00c9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00ce:  pop
    IL_00cf:  ldloc.0
    IL_00d0:  ldstr      "bool"
    IL_00d5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00da:  pop
    IL_00db:  ldloc.0
    IL_00dc:  ldstr      "break"
    IL_00e1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00e6:  pop
    IL_00e7:  ldloc.0
    IL_00e8:  ldstr      "byte"
    IL_00ed:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00f2:  pop
    IL_00f3:  ldloc.0
    IL_00f4:  ldstr      "case"
    IL_00f9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_00fe:  pop
    IL_00ff:  ldloc.0
    IL_0100:  ldstr      "catch"
    IL_0105:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_010a:  pop
    IL_010b:  ldloc.0
    IL_010c:  ldstr      "char"
    IL_0111:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0116:  pop
    IL_0117:  ldloc.0
    IL_0118:  ldstr      "checked"
    IL_011d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0122:  pop
    IL_0123:  ldloc.0
    IL_0124:  ldstr      "class"
    IL_0129:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_012e:  pop
    IL_012f:  ldloc.0
    IL_0130:  ldstr      "const"
    IL_0135:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_013a:  pop
    IL_013b:  ldloc.0
    IL_013c:  ldstr      "continue"
    IL_0141:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0146:  pop
    IL_0147:  ldloc.0
    IL_0148:  ldstr      "decimal"
    IL_014d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0152:  pop
    IL_0153:  ldloc.0
    IL_0154:  ldstr      "default"
    IL_0159:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_015e:  pop
    IL_015f:  ldloc.0
    IL_0160:  ldstr      "delegate"
    IL_0165:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_016a:  pop
    IL_016b:  ldloc.0
    IL_016c:  ldstr      "do"
    IL_0171:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0176:  pop
    IL_0177:  ldloc.0
    IL_0178:  ldstr      "double"
    IL_017d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0182:  pop
    IL_0183:  ldloc.0
    IL_0184:  ldstr      "else"
    IL_0189:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_018e:  pop
    IL_018f:  ldloc.0
    IL_0190:  ldstr      "enum"
    IL_0195:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_019a:  pop
    IL_019b:  ldloc.0
    IL_019c:  ldstr      "event"
    IL_01a1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01a6:  pop
    IL_01a7:  ldloc.0
    IL_01a8:  ldstr      "explicit"
    IL_01ad:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01b2:  pop
    IL_01b3:  ldloc.0
    IL_01b4:  ldstr      "extern"
    IL_01b9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01be:  pop
    IL_01bf:  ldloc.0
    IL_01c0:  ldstr      "false"
    IL_01c5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01ca:  pop
    IL_01cb:  ldloc.0
    IL_01cc:  ldstr      "finally"
    IL_01d1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01d6:  pop
    IL_01d7:  ldloc.0
    IL_01d8:  ldstr      "fixed"
    IL_01dd:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01e2:  pop
    IL_01e3:  ldloc.0
    IL_01e4:  ldstr      "float"
    IL_01e9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01ee:  pop
    IL_01ef:  ldloc.0
    IL_01f0:  ldstr      "for"
    IL_01f5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_01fa:  pop
    IL_01fb:  ldloc.0
    IL_01fc:  ldstr      "foreach"
    IL_0201:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0206:  pop
    IL_0207:  ldloc.0
    IL_0208:  ldstr      "goto"
    IL_020d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0212:  pop
    IL_0213:  ldloc.0
    IL_0214:  ldstr      "if"
    IL_0219:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_021e:  pop
    IL_021f:  ldloc.0
    IL_0220:  ldstr      "implicit"
    IL_0225:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_022a:  pop
    IL_022b:  ldloc.0
    IL_022c:  ldstr      "in"
    IL_0231:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0236:  pop
    IL_0237:  ldloc.0
    IL_0238:  ldstr      "int"
    IL_023d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0242:  pop
    IL_0243:  ldloc.0
    IL_0244:  ldstr      "interface"
    IL_0249:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_024e:  pop
    IL_024f:  ldloc.0
    IL_0250:  ldstr      "internal"
    IL_0255:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_025a:  pop
    IL_025b:  ldloc.0
    IL_025c:  ldstr      "is"
    IL_0261:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0266:  pop
    IL_0267:  ldloc.0
    IL_0268:  ldstr      "lock"
    IL_026d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0272:  pop
    IL_0273:  ldloc.0
    IL_0274:  ldstr      "long"
    IL_0279:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_027e:  pop
    IL_027f:  ldloc.0
    IL_0280:  ldstr      "namespace"
    IL_0285:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_028a:  pop
    IL_028b:  ldloc.0
    IL_028c:  ldstr      "new"
    IL_0291:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0296:  pop
    IL_0297:  ldloc.0
    IL_0298:  ldstr      "null"
    IL_029d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02a2:  pop
    IL_02a3:  ldloc.0
    IL_02a4:  ldstr      "object"
    IL_02a9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02ae:  pop
    IL_02af:  ldloc.0
    IL_02b0:  ldstr      "operator"
    IL_02b5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02ba:  pop
    IL_02bb:  ldloc.0
    IL_02bc:  ldstr      "out"
    IL_02c1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02c6:  pop
    IL_02c7:  ldloc.0
    IL_02c8:  ldstr      "override"
    IL_02cd:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02d2:  pop
    IL_02d3:  ldloc.0
    IL_02d4:  ldstr      "params"
    IL_02d9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02de:  pop
    IL_02df:  ldloc.0
    IL_02e0:  ldstr      "private"
    IL_02e5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02ea:  pop
    IL_02eb:  ldloc.0
    IL_02ec:  ldstr      "protected"
    IL_02f1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_02f6:  pop
    IL_02f7:  ldloc.0
    IL_02f8:  ldstr      "public"
    IL_02fd:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0302:  pop
    IL_0303:  ldloc.0
    IL_0304:  ldstr      "readonly"
    IL_0309:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_030e:  pop
    IL_030f:  ldloc.0
    IL_0310:  ldstr      "ref"
    IL_0315:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_031a:  pop
    IL_031b:  ldloc.0
    IL_031c:  ldstr      "return"
    IL_0321:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0326:  pop
    IL_0327:  ldloc.0
    IL_0328:  ldstr      "sbyte"
    IL_032d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0332:  pop
    IL_0333:  ldloc.0
    IL_0334:  ldstr      "sealed"
    IL_0339:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_033e:  pop
    IL_033f:  ldloc.0
    IL_0340:  ldstr      "short"
    IL_0345:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_034a:  pop
    IL_034b:  ldloc.0
    IL_034c:  ldstr      "sizeof"
    IL_0351:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0356:  pop
    IL_0357:  ldloc.0
    IL_0358:  ldstr      "stackalloc"
    IL_035d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0362:  pop
    IL_0363:  ldloc.0
    IL_0364:  ldstr      "static"
    IL_0369:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_036e:  pop
    IL_036f:  ldloc.0
    IL_0370:  ldstr      "string"
    IL_0375:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_037a:  pop
    IL_037b:  ldloc.0
    IL_037c:  ldstr      "struct"
    IL_0381:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0386:  pop
    IL_0387:  ldloc.0
    IL_0388:  ldstr      "switch"
    IL_038d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0392:  pop
    IL_0393:  ldloc.0
    IL_0394:  ldstr      "this"
    IL_0399:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_039e:  pop
    IL_039f:  ldloc.0
    IL_03a0:  ldstr      "throw"
    IL_03a5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03aa:  pop
    IL_03ab:  ldloc.0
    IL_03ac:  ldstr      "true"
    IL_03b1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03b6:  pop
    IL_03b7:  ldloc.0
    IL_03b8:  ldstr      "try"
    IL_03bd:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03c2:  pop
    IL_03c3:  ldloc.0
    IL_03c4:  ldstr      "typeof"
    IL_03c9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03ce:  pop
    IL_03cf:  ldloc.0
    IL_03d0:  ldstr      "uint"
    IL_03d5:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03da:  pop
    IL_03db:  ldloc.0
    IL_03dc:  ldstr      "ulong"
    IL_03e1:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03e6:  pop
    IL_03e7:  ldloc.0
    IL_03e8:  ldstr      "unchecked"
    IL_03ed:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03f2:  pop
    IL_03f3:  ldloc.0
    IL_03f4:  ldstr      "unsafe"
    IL_03f9:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_03fe:  pop
    IL_03ff:  ldloc.0
    IL_0400:  ldstr      "ushort"
    IL_0405:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_040a:  pop
    IL_040b:  ldloc.0
    IL_040c:  ldstr      "using"
    IL_0411:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0416:  pop
    IL_0417:  ldloc.0
    IL_0418:  ldstr      "virtual"
    IL_041d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0422:  pop
    IL_0423:  ldloc.0
    IL_0424:  ldstr      "void"
    IL_0429:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_042e:  pop
    IL_042f:  ldloc.0
    IL_0430:  ldstr      "volatile"
    IL_0435:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_043a:  pop
    IL_043b:  ldloc.0
    IL_043c:  ldstr      "while"
    IL_0441:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0446:  pop
    IL_0447:  ldloc.0
    IL_0448:  ldstr      "value"
    IL_044d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0452:  pop
    IL_0453:  ldloc.0
    IL_0454:  ldstr      "partial"
    IL_0459:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_045e:  pop
    IL_045f:  ldloc.0
    IL_0460:  call       instance void Avro.CodeGenUtil::set_ReservedKeywords(class [System.Core]System.Collections.Generic.HashSet`1<string>)
    IL_0465:  ret
  } // end of method CodeGenUtil::.ctor

  .method public hidebysig instance string 
          Mangle(string name) cil managed
  {
    // Code size       107 (0x6b)
    .maxstack  4
    .locals init (class [mscorlib]System.Text.StringBuilder V_0,
             string[] V_1,
             int32 V_2,
             char[] V_3)
    IL_0000:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldarg.1
    IL_0007:  ldc.i4.1
    IL_0008:  newarr     [mscorlib]System.Char
    IL_000d:  stloc.3
    IL_000e:  ldloc.3
    IL_000f:  ldc.i4.0
    IL_0010:  ldc.i4.s   46
    IL_0012:  stelem.i2
    IL_0013:  ldloc.3
    IL_0014:  callvirt   instance string[] [mscorlib]System.String::Split(char[])
    IL_0019:  stloc.1
    IL_001a:  ldc.i4.0
    IL_001b:  stloc.2
    IL_001c:  br.s       IL_004e

    IL_001e:  ldarg.0
    IL_001f:  call       instance class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.CodeGenUtil::get_ReservedKeywords()
    IL_0024:  ldloc.1
    IL_0025:  ldloc.2
    IL_0026:  ldelem.ref
    IL_0027:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Contains(!0)
    IL_002c:  brfalse.s  IL_0037

    IL_002e:  ldloc.0
    IL_002f:  ldc.i4.s   64
    IL_0031:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(char)
    IL_0036:  pop
    IL_0037:  ldloc.0
    IL_0038:  ldloc.1
    IL_0039:  ldloc.2
    IL_003a:  ldelem.ref
    IL_003b:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0040:  pop
    IL_0041:  ldloc.0
    IL_0042:  ldc.i4.s   46
    IL_0044:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(char)
    IL_0049:  pop
    IL_004a:  ldloc.2
    IL_004b:  ldc.i4.1
    IL_004c:  add
    IL_004d:  stloc.2
    IL_004e:  ldloc.2
    IL_004f:  ldloc.1
    IL_0050:  ldlen
    IL_0051:  conv.i4
    IL_0052:  blt.s      IL_001e

    IL_0054:  ldloc.0
    IL_0055:  ldloc.0
    IL_0056:  callvirt   instance int32 [mscorlib]System.Text.StringBuilder::get_Length()
    IL_005b:  ldc.i4.1
    IL_005c:  sub
    IL_005d:  ldc.i4.1
    IL_005e:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Remove(int32,
                                                                                                                        int32)
    IL_0063:  pop
    IL_0064:  ldloc.0
    IL_0065:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_006a:  ret
  } // end of method CodeGenUtil::Mangle

  .method public hidebysig instance string 
          UnMangle(string name) cil managed
  {
    // Code size       61 (0x3d)
    .maxstack  3
    .locals init (class [mscorlib]System.Text.StringBuilder V_0,
             int32 V_1)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0006:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor(int32)
    IL_000b:  stloc.0
    IL_000c:  ldc.i4.0
    IL_000d:  stloc.1
    IL_000e:  br.s       IL_002d

    IL_0010:  ldarg.1
    IL_0011:  ldloc.1
    IL_0012:  callvirt   instance char [mscorlib]System.String::get_Chars(int32)
    IL_0017:  ldc.i4.s   64
    IL_0019:  beq.s      IL_0029

    IL_001b:  ldloc.0
    IL_001c:  ldarg.1
    IL_001d:  ldloc.1
    IL_001e:  callvirt   instance char [mscorlib]System.String::get_Chars(int32)
    IL_0023:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(char)
    IL_0028:  pop
    IL_0029:  ldloc.1
    IL_002a:  ldc.i4.1
    IL_002b:  add
    IL_002c:  stloc.1
    IL_002d:  ldloc.1
    IL_002e:  ldarg.1
    IL_002f:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0034:  blt.s      IL_0010

    IL_0036:  ldloc.0
    IL_0037:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_003c:  ret
  } // end of method CodeGenUtil::UnMangle

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void Avro.CodeGenUtil::.ctor()
    IL_0005:  stsfld     class Avro.CodeGenUtil Avro.CodeGenUtil::'instance'
    IL_000a:  ret
  } // end of method CodeGenUtil::.cctor

  .property class Avro.CodeGenUtil Instance()
  {
    .get class Avro.CodeGenUtil Avro.CodeGenUtil::get_Instance()
  } // end of property CodeGenUtil::Instance
  .property instance class [System]System.CodeDom.CodeNamespaceImport[]
          NamespaceImports()
  {
    .get instance class [System]System.CodeDom.CodeNamespaceImport[] Avro.CodeGenUtil::get_NamespaceImports()
    .set instance void Avro.CodeGenUtil::set_NamespaceImports(class [System]System.CodeDom.CodeNamespaceImport[])
  } // end of property CodeGenUtil::NamespaceImports
  .property instance class [System]System.CodeDom.CodeCommentStatement
          FileComment()
  {
    .get instance class [System]System.CodeDom.CodeCommentStatement Avro.CodeGenUtil::get_FileComment()
    .set instance void Avro.CodeGenUtil::set_FileComment(class [System]System.CodeDom.CodeCommentStatement)
  } // end of property CodeGenUtil::FileComment
  .property instance class [System.Core]System.Collections.Generic.HashSet`1<string>
          ReservedKeywords()
  {
    .get instance class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.CodeGenUtil::get_ReservedKeywords()
    .set instance void Avro.CodeGenUtil::set_ReservedKeywords(class [System.Core]System.Collections.Generic.HashSet`1<string>)
  } // end of property CodeGenUtil::ReservedKeywords
} // end of class Avro.CodeGenUtil

.class public abstract auto ansi beforefieldinit Avro.File.Codec
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public Type
         extends [mscorlib]System.Enum
  {
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype Avro.File.Codec/Type Deflate = int32(0x00000000)
    .field public static literal valuetype Avro.File.Codec/Type Null = int32(0x00000001)
  } // end of class Type

  .method public hidebysig newslot abstract virtual 
          instance uint8[]  Compress(uint8[] uncompressedData) cil managed
  {
  } // end of method Codec::Compress

  .method public hidebysig newslot abstract virtual 
          instance uint8[]  Decompress(uint8[] compressedData) cil managed
  {
  } // end of method Codec::Decompress

  .method public hidebysig newslot abstract virtual 
          instance class [mscorlib]System.IO.Stream 
          Compress(class [mscorlib]System.IO.Stream uncompressedStream) cil managed
  {
  } // end of method Codec::Compress

  .method public hidebysig newslot abstract virtual 
          instance string  GetName() cil managed
  {
  } // end of method Codec::GetName

  .method public hidebysig abstract virtual 
          instance bool  Equals(object other) cil managed
  {
  } // end of method Codec::Equals

  .method public hidebysig abstract virtual 
          instance int32  GetHashCode() cil managed
  {
  } // end of method Codec::GetHashCode

  .method public hidebysig static class Avro.File.Codec 
          CreateCodec(valuetype Avro.File.Codec/Type codecType) cil managed
  {
    // Code size       18 (0x12)
    .maxstack  2
    .locals init (valuetype Avro.File.Codec/Type V_0)
    IL_0000:  ldarg.0
    IL_0001:  stloc.0
    IL_0002:  ldloc.0
    IL_0003:  ldc.i4.0
    IL_0004:  bne.un.s   IL_000c

    IL_0006:  newobj     instance void Avro.File.DeflateCodec::.ctor()
    IL_000b:  ret

    IL_000c:  newobj     instance void Avro.File.NullCodec::.ctor()
    IL_0011:  ret
  } // end of method Codec::CreateCodec

  .method public hidebysig static class Avro.File.Codec 
          CreateCodecFromString(string codecType) cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  2
    .locals init (string V_0)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.0
    IL_0003:  brfalse.s  IL_0018

    IL_0005:  ldloc.0
    IL_0006:  ldstr      "deflate"
    IL_000b:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0010:  brfalse.s  IL_0018

    IL_0012:  newobj     instance void Avro.File.DeflateCodec::.ctor()
    IL_0017:  ret

    IL_0018:  newobj     instance void Avro.File.NullCodec::.ctor()
    IL_001d:  ret
  } // end of method Codec::CreateCodecFromString

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance string Avro.File.Codec::GetName()
    IL_0006:  ret
  } // end of method Codec::ToString

  .method family hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method Codec::.ctor

} // end of class Avro.File.Codec

.class public auto ansi beforefieldinit Avro.File.DataBlock
       extends [mscorlib]System.Object
{
  .field private uint8[] '<Data>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private int64 '<NumberOfEntries>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private int64 '<BlockSize>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance uint8[] 
          get_Data() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8[] Avro.File.DataBlock::'<Data>k__BackingField'
    IL_0006:  ret
  } // end of method DataBlock::get_Data

  .method public hidebysig specialname instance void 
          set_Data(uint8[] 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      uint8[] Avro.File.DataBlock::'<Data>k__BackingField'
    IL_0007:  ret
  } // end of method DataBlock::set_Data

  .method public hidebysig specialname instance int64 
          get_NumberOfEntries() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int64 Avro.File.DataBlock::'<NumberOfEntries>k__BackingField'
    IL_0006:  ret
  } // end of method DataBlock::get_NumberOfEntries

  .method public hidebysig specialname instance void 
          set_NumberOfEntries(int64 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int64 Avro.File.DataBlock::'<NumberOfEntries>k__BackingField'
    IL_0007:  ret
  } // end of method DataBlock::set_NumberOfEntries

  .method public hidebysig specialname instance int64 
          get_BlockSize() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int64 Avro.File.DataBlock::'<BlockSize>k__BackingField'
    IL_0006:  ret
  } // end of method DataBlock::get_BlockSize

  .method public hidebysig specialname instance void 
          set_BlockSize(int64 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int64 Avro.File.DataBlock::'<BlockSize>k__BackingField'
    IL_0007:  ret
  } // end of method DataBlock::set_BlockSize

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(int64 numberOfEntries,
                               int64 blockSize) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  call       instance void Avro.File.DataBlock::set_NumberOfEntries(int64)
    IL_000d:  ldarg.0
    IL_000e:  ldarg.2
    IL_000f:  call       instance void Avro.File.DataBlock::set_BlockSize(int64)
    IL_0014:  ldarg.0
    IL_0015:  ldarg.2
    IL_0016:  conv.ovf.i
    IL_0017:  newarr     [mscorlib]System.Byte
    IL_001c:  call       instance void Avro.File.DataBlock::set_Data(uint8[])
    IL_0021:  ret
  } // end of method DataBlock::.ctor

  .method assembly hidebysig instance class [mscorlib]System.IO.Stream 
          GetDataAsStream() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance uint8[] Avro.File.DataBlock::get_Data()
    IL_0006:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor(uint8[])
    IL_000b:  ret
  } // end of method DataBlock::GetDataAsStream

  .property instance uint8[] Data()
  {
    .set instance void Avro.File.DataBlock::set_Data(uint8[])
    .get instance uint8[] Avro.File.DataBlock::get_Data()
  } // end of property DataBlock::Data
  .property instance int64 NumberOfEntries()
  {
    .get instance int64 Avro.File.DataBlock::get_NumberOfEntries()
    .set instance void Avro.File.DataBlock::set_NumberOfEntries(int64)
  } // end of property DataBlock::NumberOfEntries
  .property instance int64 BlockSize()
  {
    .get instance int64 Avro.File.DataBlock::get_BlockSize()
    .set instance void Avro.File.DataBlock::set_BlockSize(int64)
  } // end of property DataBlock::BlockSize
} // end of class Avro.File.DataBlock

.class public auto ansi beforefieldinit Avro.File.DataFileConstants
       extends [mscorlib]System.Object
{
  .field public static literal string MetaDataSync = "avro.sync"
  .field public static literal string MetaDataCodec = "avro.codec"
  .field public static literal string MetaDataSchema = "avro.schema"
  .field public static literal string NullCodec = "null"
  .field public static literal string DeflateCodec = "deflate"
  .field public static literal string MetaDataReserved = "avro"
  .field public static literal int32 Version = int32(0x00000001)
  .field public static literal int32 NullCodecHash = int32(0x00000002)
  .field public static literal int32 DeflateCodecHash = int32(0x00000000)
  .field public static literal int32 SyncSize = int32(0x00000010)
  .field public static literal int32 DefaultSyncInterval = int32(0x00003E80)
  .field public static uint8[] Magic
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method DataFileConstants::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldc.i4.4
    IL_0001:  newarr     [mscorlib]System.Byte
    IL_0006:  dup
    IL_0007:  ldtoken    field int32 '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'::'$$method0x600027d-1'
    IL_000c:  call       void [mscorlib]System.Runtime.CompilerServices.RuntimeHelpers::InitializeArray(class [mscorlib]System.Array,
                                                                                                        valuetype [mscorlib]System.RuntimeFieldHandle)
    IL_0011:  stsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_0016:  ret
  } // end of method DataFileConstants::.cctor

} // end of class Avro.File.DataFileConstants

.class interface public abstract auto ansi Avro.File.IFileReader`1<T>
       implements class [mscorlib]System.Collections.Generic.IEnumerable`1<!T>,
                  [mscorlib]System.Collections.IEnumerable,
                  class [mscorlib]System.Collections.Generic.IEnumerator`1<!T>,
                  [mscorlib]System.IDisposable,
                  [mscorlib]System.Collections.IEnumerator
{
  .method public hidebysig newslot abstract virtual 
          instance class Avro.File.Header 
          GetHeader() cil managed
  {
  } // end of method IFileReader`1::GetHeader

  .method public hidebysig newslot abstract virtual 
          instance class Avro.Schema  GetSchema() cil managed
  {
  } // end of method IFileReader`1::GetSchema

  .method public hidebysig newslot abstract virtual 
          instance class [mscorlib]System.Collections.Generic.ICollection`1<string> 
          GetMetaKeys() cil managed
  {
  } // end of method IFileReader`1::GetMetaKeys

  .method public hidebysig newslot abstract virtual 
          instance uint8[]  GetMeta(string key) cil managed
  {
  } // end of method IFileReader`1::GetMeta

  .method public hidebysig newslot abstract virtual 
          instance int64  GetMetaLong(string key) cil managed
  {
  } // end of method IFileReader`1::GetMetaLong

  .method public hidebysig newslot abstract virtual 
          instance string  GetMetaString(string key) cil managed
  {
  } // end of method IFileReader`1::GetMetaString

  .method public hidebysig newslot abstract virtual 
          instance bool  PastSync(int64 position) cil managed
  {
  } // end of method IFileReader`1::PastSync

  .method public hidebysig newslot abstract virtual 
          instance int64  PreviousSync() cil managed
  {
  } // end of method IFileReader`1::PreviousSync

  .method public hidebysig newslot abstract virtual 
          instance void  Seek(int64 position) cil managed
  {
  } // end of method IFileReader`1::Seek

  .method public hidebysig newslot abstract virtual 
          instance void  Sync(int64 position) cil managed
  {
  } // end of method IFileReader`1::Sync

  .method public hidebysig newslot abstract virtual 
          instance int64  Tell() cil managed
  {
  } // end of method IFileReader`1::Tell

} // end of class Avro.File.IFileReader`1

.class public auto ansi beforefieldinit Avro.File.DataFileReader`1<T>
       extends [mscorlib]System.Object
       implements class Avro.File.IFileReader`1<!T>,
                  class [mscorlib]System.Collections.Generic.IEnumerable`1<!T>,
                  [mscorlib]System.Collections.IEnumerable,
                  class [mscorlib]System.Collections.Generic.IEnumerator`1<!T>,
                  [mscorlib]System.IDisposable,
                  [mscorlib]System.Collections.IEnumerator
{
  .field private class Avro.Generic.DatumReader`1<!T> _reader
  .field private class Avro.IO.Decoder _decoder
  .field private class Avro.IO.Decoder _datumDecoder
  .field private class Avro.File.Header _header
  .field private class Avro.File.Codec _codec
  .field private class Avro.File.DataBlock _currentBlock
  .field private int64 _blockRemaining
  .field private int64 _blockCount
  .field private int64 _blockSize
  .field private bool _availableBlock
  .field private uint8[] _syncBuffer
  .field private int64 _blockStart
  .field private class [mscorlib]System.IO.Stream _stream
  .method public hidebysig static class Avro.File.IFileReader`1<!T> 
          OpenReader(string path) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.3
    IL_0002:  newobj     instance void [mscorlib]System.IO.FileStream::.ctor(string,
                                                                             valuetype [mscorlib]System.IO.FileMode)
    IL_0007:  call       class Avro.File.IFileReader`1<!0> class Avro.File.DataFileReader`1<!T>::OpenReader(class [mscorlib]System.IO.Stream)
    IL_000c:  ret
  } // end of method DataFileReader`1::OpenReader

  .method public hidebysig static class Avro.File.IFileReader`1<!T> 
          OpenReader(class [mscorlib]System.IO.Stream inStream) cil managed
  {
    // Code size       134 (0x86)
    .maxstack  5
    .locals init (uint8[] V_0,
             int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance bool [mscorlib]System.IO.Stream::get_CanSeek()
    IL_0006:  brtrue.s   IL_0013

    IL_0008:  ldstr      "Not a valid input stream - must be seekable!"
    IL_000d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ldarg.0
    IL_0014:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Length()
    IL_0019:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_001e:  ldlen
    IL_001f:  conv.i4
    IL_0020:  conv.i8
    IL_0021:  bge.s      IL_002e

    IL_0023:  ldstr      "Not an Avro data file"
    IL_0028:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_002d:  throw

    IL_002e:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_0033:  ldlen
    IL_0034:  conv.i4
    IL_0035:  newarr     [mscorlib]System.Byte
    IL_003a:  stloc.0
    IL_003b:  ldarg.0
    IL_003c:  ldc.i4.0
    IL_003d:  conv.i8
    IL_003e:  ldc.i4.0
    IL_003f:  callvirt   instance int64 [mscorlib]System.IO.Stream::Seek(int64,
                                                                         valuetype [mscorlib]System.IO.SeekOrigin)
    IL_0044:  pop
    IL_0045:  ldc.i4.0
    IL_0046:  stloc.1
    IL_0047:  br.s       IL_0057

    IL_0049:  ldarg.0
    IL_004a:  ldloc.0
    IL_004b:  ldloc.1
    IL_004c:  ldloc.0
    IL_004d:  ldlen
    IL_004e:  conv.i4
    IL_004f:  ldloc.1
    IL_0050:  sub
    IL_0051:  callvirt   instance int32 [mscorlib]System.IO.Stream::Read(uint8[],
                                                                         int32,
                                                                         int32)
    IL_0056:  stloc.1
    IL_0057:  ldloc.1
    IL_0058:  ldloc.0
    IL_0059:  ldlen
    IL_005a:  conv.i4
    IL_005b:  blt.s      IL_0049

    IL_005d:  ldarg.0
    IL_005e:  ldc.i4.0
    IL_005f:  conv.i8
    IL_0060:  ldc.i4.0
    IL_0061:  callvirt   instance int64 [mscorlib]System.IO.Stream::Seek(int64,
                                                                         valuetype [mscorlib]System.IO.SeekOrigin)
    IL_0066:  pop
    IL_0067:  ldloc.0
    IL_0068:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_006d:  call       bool [System.Core]System.Linq.Enumerable::SequenceEqual<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                        class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0072:  brfalse.s  IL_007b

    IL_0074:  ldarg.0
    IL_0075:  newobj     instance void class Avro.File.DataFileReader`1<!T>::.ctor(class [mscorlib]System.IO.Stream)
    IL_007a:  ret

    IL_007b:  ldstr      "Not an Avro data file"
    IL_0080:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0085:  throw
  } // end of method DataFileReader`1::OpenReader

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(string path) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.2
    IL_0003:  newobj     instance void [mscorlib]System.IO.FileStream::.ctor(string,
                                                                             valuetype [mscorlib]System.IO.FileMode)
    IL_0008:  call       instance void class Avro.File.DataFileReader`1<!T>::.ctor(class [mscorlib]System.IO.Stream)
    IL_000d:  ret
  } // end of method DataFileReader`1::.ctor

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.IO.Stream 'stream') cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  call       instance void class Avro.File.DataFileReader`1<!T>::Init(class [mscorlib]System.IO.Stream)
    IL_000d:  ldarg.0
    IL_000e:  call       instance void class Avro.File.DataFileReader`1<!T>::BlockFinished()
    IL_0013:  ret
  } // end of method DataFileReader`1::.ctor

  .method public hidebysig newslot virtual final 
          instance class Avro.File.Header 
          GetHeader() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0006:  ret
  } // end of method DataFileReader`1::GetHeader

  .method public hidebysig newslot virtual final 
          instance class Avro.Schema  GetSchema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0006:  callvirt   instance class Avro.Schema Avro.File.Header::get_Schema()
    IL_000b:  ret
  } // end of method DataFileReader`1::GetSchema

  .method public hidebysig newslot virtual final 
          instance class [mscorlib]System.Collections.Generic.ICollection`1<string> 
          GetMetaKeys() cil managed
  {
    // Code size       17 (0x11)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::get_MetaData()
    IL_000b:  callvirt   instance class [mscorlib]System.Collections.Generic.ICollection`1<!0> class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>::get_Keys()
    IL_0010:  ret
  } // end of method DataFileReader`1::GetMetaKeys

  .method public hidebysig newslot virtual final 
          instance uint8[]  GetMeta(string key) cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  2
    .locals init (uint8[] V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
      IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::get_MetaData()
      IL_000b:  ldarg.1
      IL_000c:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>::get_Item(!0)
      IL_0011:  stloc.0
      IL_0012:  leave.s    IL_0019

    }  // end .try
    catch [mscorlib]System.Collections.Generic.KeyNotFoundException 
    {
      IL_0014:  pop
      IL_0015:  ldnull
      IL_0016:  stloc.0
      IL_0017:  leave.s    IL_0019

    }  // end handler
    IL_0019:  ldloc.0
    IL_001a:  ret
  } // end of method DataFileReader`1::GetMeta

  .method public hidebysig newslot virtual final 
          instance int64  GetMetaLong(string key) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance uint8[] class Avro.File.DataFileReader`1<!T>::GetMeta(string)
    IL_0007:  ldc.i4.0
    IL_0008:  call       int64 [mscorlib]System.BitConverter::ToInt64(uint8[],
                                                                      int32)
    IL_000d:  ret
  } // end of method DataFileReader`1::GetMetaLong

  .method public hidebysig newslot virtual final 
          instance string  GetMetaString(string key) cil managed
  {
    // Code size       48 (0x30)
    .maxstack  2
    .locals init (uint8[] V_0,
             class [mscorlib]System.Exception V_1,
             string V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance uint8[] class Avro.File.DataFileReader`1<!T>::GetMeta(string)
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  brtrue.s   IL_000d

    IL_000b:  ldnull
    IL_000c:  ret

    .try
    {
      IL_000d:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
      IL_0012:  ldloc.0
      IL_0013:  callvirt   instance string [mscorlib]System.Text.Encoding::GetString(uint8[])
      IL_0018:  stloc.2
      IL_0019:  leave.s    IL_002e

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_001b:  stloc.1
      IL_001c:  ldstr      "Error fetching meta data for key: {0}"
      IL_0021:  ldarg.1
      IL_0022:  call       string [mscorlib]System.String::Format(string,
                                                                  object)
      IL_0027:  ldloc.1
      IL_0028:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_002d:  throw

    }  // end handler
    IL_002e:  ldloc.2
    IL_002f:  ret
  } // end of method DataFileReader`1::GetMetaString

  .method public hidebysig newslot virtual final 
          instance void  Seek(int64 position) cil managed
  {
    // Code size       52 (0x34)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
    IL_000c:  ldarg.0
    IL_000d:  ldarg.0
    IL_000e:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0013:  newobj     instance void Avro.IO.BinaryDecoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_0018:  stfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_001d:  ldarg.0
    IL_001e:  ldnull
    IL_001f:  stfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_datumDecoder
    IL_0024:  ldarg.0
    IL_0025:  ldc.i4.0
    IL_0026:  conv.i8
    IL_0027:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
    IL_002c:  ldarg.0
    IL_002d:  ldarg.1
    IL_002e:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0033:  ret
  } // end of method DataFileReader`1::Seek

  .method public hidebysig newslot virtual final 
          instance void  Sync(int64 position) cil managed
  {
    // Code size       137 (0x89)
    .maxstack  3
    .locals init (bool V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void class Avro.File.DataFileReader`1<!T>::Seek(int64)
    IL_0007:  ldarg.1
    IL_0008:  ldc.i4.0
    IL_0009:  conv.i8
    IL_000a:  bne.un.s   IL_0026

    IL_000c:  ldarg.0
    IL_000d:  ldstr      "avro.sync"
    IL_0012:  call       instance uint8[] class Avro.File.DataFileReader`1<!T>::GetMeta(string)
    IL_0017:  brfalse.s  IL_0026

    IL_0019:  ldarg.0
    IL_001a:  ldarg.0
    IL_001b:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0020:  call       instance void class Avro.File.DataFileReader`1<!T>::Init(class [mscorlib]System.IO.Stream)
    IL_0025:  ret

    .try
    {
      IL_0026:  ldc.i4.0
      IL_0027:  stloc.0
      IL_0028:  ldarg.0
      IL_0029:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
      IL_002e:  ldarg.0
      IL_002f:  ldfld      uint8[] class Avro.File.DataFileReader`1<!T>::_syncBuffer
      IL_0034:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
      IL_0039:  ldarg.0
      IL_003a:  ldfld      uint8[] class Avro.File.DataFileReader`1<!T>::_syncBuffer
      IL_003f:  ldarg.0
      IL_0040:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
      IL_0045:  callvirt   instance uint8[] Avro.File.Header::get_SyncData()
      IL_004a:  call       bool [System.Core]System.Linq.Enumerable::SequenceEqual<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                          class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_004f:  brfalse.s  IL_0055

      IL_0051:  ldc.i4.1
      IL_0052:  stloc.0
      IL_0053:  br.s       IL_006f

      IL_0055:  ldarg.0
      IL_0056:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
      IL_005b:  ldarg.0
      IL_005c:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
      IL_0061:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
      IL_0066:  ldc.i4.s   15
      IL_0068:  conv.i8
      IL_0069:  sub
      IL_006a:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_006f:  ldloc.0
      IL_0070:  brfalse.s  IL_0028

      IL_0072:  leave.s    IL_0077

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0074:  pop
      IL_0075:  leave.s    IL_0077

    }  // end handler
    IL_0077:  ldarg.0
    IL_0078:  ldarg.0
    IL_0079:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_007e:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_0083:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0088:  ret
  } // end of method DataFileReader`1::Sync

  .method public hidebysig newslot virtual final 
          instance bool  PastSync(int64 position) cil managed
  {
    // Code size       38 (0x26)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0006:  ldarg.1
    IL_0007:  ldc.i4.s   16
    IL_0009:  conv.i8
    IL_000a:  add
    IL_000b:  bge.s      IL_0024

    IL_000d:  ldarg.0
    IL_000e:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0013:  ldarg.0
    IL_0014:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0019:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Length()
    IL_001e:  clt
    IL_0020:  ldc.i4.0
    IL_0021:  ceq
    IL_0023:  ret

    IL_0024:  ldc.i4.1
    IL_0025:  ret
  } // end of method DataFileReader`1::PastSync

  .method public hidebysig newslot virtual final 
          instance int64  PreviousSync() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0006:  ret
  } // end of method DataFileReader`1::PreviousSync

  .method public hidebysig newslot virtual final 
          instance int64  Tell() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0006:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_000b:  ret
  } // end of method DataFileReader`1::Tell

  .method public hidebysig newslot virtual final 
          instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!T> 
          GetEnumerator() cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ret
  } // end of method DataFileReader`1::GetEnumerator

  .method private hidebysig newslot virtual final 
          instance class [mscorlib]System.Collections.IEnumerator 
          System.Collections.IEnumerable.GetEnumerator() cil managed
  {
    .override [mscorlib]System.Collections.IEnumerable::GetEnumerator
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ret
  } // end of method DataFileReader`1::System.Collections.IEnumerable.GetEnumerator

  .method public hidebysig newslot specialname virtual final 
          instance !T  get_Current() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance !0 class Avro.File.DataFileReader`1<!T>::Next()
    IL_0006:  ret
  } // end of method DataFileReader`1::get_Current

  .method private hidebysig newslot specialname virtual final 
          instance object  System.Collections.IEnumerator.get_Current() cil managed
  {
    .override [mscorlib]System.Collections.IEnumerator::get_Current
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance !0 class Avro.File.DataFileReader`1<!T>::get_Current()
    IL_0006:  box        !T
    IL_000b:  ret
  } // end of method DataFileReader`1::System.Collections.IEnumerator.get_Current

  .method public hidebysig newslot virtual final 
          instance bool  MoveNext() cil managed
  {
    // Code size       127 (0x7f)
    .maxstack  3
    .locals init (class [mscorlib]System.Exception V_0,
             bool V_1)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_0006:  ldc.i4.0
      IL_0007:  conv.i8
      IL_0008:  bne.un.s   IL_005b

      IL_000a:  ldarg.0
      IL_000b:  call       instance bool class Avro.File.DataFileReader`1<!T>::HasNextBlock()
      IL_0010:  brfalse.s  IL_005b

      IL_0012:  ldarg.0
      IL_0013:  ldarg.0
      IL_0014:  ldarg.0
      IL_0015:  ldfld      class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::_currentBlock
      IL_001a:  call       instance class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::NextRawBlock(class Avro.File.DataBlock)
      IL_001f:  stfld      class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::_currentBlock
      IL_0024:  ldarg.0
      IL_0025:  ldfld      class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::_currentBlock
      IL_002a:  ldarg.0
      IL_002b:  ldfld      class Avro.File.Codec class Avro.File.DataFileReader`1<!T>::_codec
      IL_0030:  ldarg.0
      IL_0031:  ldfld      class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::_currentBlock
      IL_0036:  callvirt   instance uint8[] Avro.File.DataBlock::get_Data()
      IL_003b:  callvirt   instance uint8[] Avro.File.Codec::Decompress(uint8[])
      IL_0040:  callvirt   instance void Avro.File.DataBlock::set_Data(uint8[])
      IL_0045:  ldarg.0
      IL_0046:  ldarg.0
      IL_0047:  ldfld      class Avro.File.DataBlock class Avro.File.DataFileReader`1<!T>::_currentBlock
      IL_004c:  callvirt   instance class [mscorlib]System.IO.Stream Avro.File.DataBlock::GetDataAsStream()
      IL_0051:  newobj     instance void Avro.IO.BinaryDecoder::.ctor(class [mscorlib]System.IO.Stream)
      IL_0056:  stfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_datumDecoder
      IL_005b:  ldarg.0
      IL_005c:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_0061:  ldc.i4.0
      IL_0062:  conv.i8
      IL_0063:  ceq
      IL_0065:  ldc.i4.0
      IL_0066:  ceq
      IL_0068:  stloc.1
      IL_0069:  leave.s    IL_007d

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_006b:  stloc.0
      IL_006c:  ldstr      "Error fetching next object from block: {0}"
      IL_0071:  ldloc.0
      IL_0072:  call       string [mscorlib]System.String::Format(string,
                                                                  object)
      IL_0077:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
      IL_007c:  throw

    }  // end handler
    IL_007d:  ldloc.1
    IL_007e:  ret
  } // end of method DataFileReader`1::MoveNext

  .method public hidebysig newslot virtual final 
          instance void  Reset() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method DataFileReader`1::Reset

  .method public hidebysig newslot virtual final 
          instance void  Dispose() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method DataFileReader`1::Dispose

  .method private hidebysig instance void 
          Init(class [mscorlib]System.IO.Stream 'stream') cil managed
  {
    // Code size       275 (0x113)
    .maxstack  3
    .locals init (uint8[] V_0,
             class [mscorlib]System.Exception V_1,
             int64 V_2,
             int64 V_3,
             string V_4,
             uint8[] V_5)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0007:  ldarg.0
    IL_0008:  newobj     instance void Avro.File.Header::.ctor()
    IL_000d:  stfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0012:  ldarg.0
    IL_0013:  ldarg.1
    IL_0014:  newobj     instance void Avro.IO.BinaryDecoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_0019:  stfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_001e:  ldarg.0
    IL_001f:  ldc.i4.s   16
    IL_0021:  newarr     [mscorlib]System.Byte
    IL_0026:  stfld      uint8[] class Avro.File.DataFileReader`1<!T>::_syncBuffer
    IL_002b:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_0030:  ldlen
    IL_0031:  conv.i4
    IL_0032:  newarr     [mscorlib]System.Byte
    IL_0037:  stloc.0
    .try
    {
      IL_0038:  ldarg.0
      IL_0039:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
      IL_003e:  ldloc.0
      IL_003f:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
      IL_0044:  leave.s    IL_0053

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0046:  stloc.1
      IL_0047:  ldstr      "Not a valid data file!"
      IL_004c:  ldloc.1
      IL_004d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_0052:  throw

    }  // end handler
    IL_0053:  ldloc.0
    IL_0054:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_0059:  call       bool [System.Core]System.Linq.Enumerable::SequenceEqual<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                        class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_005e:  brtrue.s   IL_006b

    IL_0060:  ldstr      "Not a valid data file!"
    IL_0065:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_006a:  throw

    IL_006b:  ldarg.0
    IL_006c:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_0071:  callvirt   instance int64 Avro.IO.Decoder::ReadMapStart()
    IL_0076:  stloc.2
    IL_0077:  ldloc.2
    IL_0078:  ldc.i4.0
    IL_0079:  conv.i8
    IL_007a:  ble.s      IL_00c9

    IL_007c:  ldc.i4.0
    IL_007d:  conv.i8
    IL_007e:  stloc.3
    IL_007f:  br.s       IL_00b4

    IL_0081:  ldarg.0
    IL_0082:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_0087:  callvirt   instance string Avro.IO.Decoder::ReadString()
    IL_008c:  stloc.s    V_4
    IL_008e:  ldarg.0
    IL_008f:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_0094:  callvirt   instance uint8[] Avro.IO.Decoder::ReadBytes()
    IL_0099:  stloc.s    V_5
    IL_009b:  ldarg.0
    IL_009c:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_00a1:  callvirt   instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::get_MetaData()
    IL_00a6:  ldloc.s    V_4
    IL_00a8:  ldloc.s    V_5
    IL_00aa:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>::Add(!0,
                                                                                                                     !1)
    IL_00af:  ldloc.3
    IL_00b0:  ldc.i4.1
    IL_00b1:  conv.i8
    IL_00b2:  add
    IL_00b3:  stloc.3
    IL_00b4:  ldloc.3
    IL_00b5:  ldloc.2
    IL_00b6:  blt.s      IL_0081

    IL_00b8:  ldarg.0
    IL_00b9:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_00be:  callvirt   instance int64 Avro.IO.Decoder::ReadMapNext()
    IL_00c3:  dup
    IL_00c4:  stloc.2
    IL_00c5:  ldc.i4.0
    IL_00c6:  conv.i8
    IL_00c7:  bne.un.s   IL_007c

    IL_00c9:  ldarg.0
    IL_00ca:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_00cf:  ldarg.0
    IL_00d0:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_00d5:  callvirt   instance uint8[] Avro.File.Header::get_SyncData()
    IL_00da:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
    IL_00df:  ldarg.0
    IL_00e0:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_00e5:  ldarg.0
    IL_00e6:  ldstr      "avro.schema"
    IL_00eb:  call       instance string class Avro.File.DataFileReader`1<!T>::GetMetaString(string)
    IL_00f0:  call       class Avro.Schema Avro.Schema::Parse(string)
    IL_00f5:  callvirt   instance void Avro.File.Header::set_Schema(class Avro.Schema)
    IL_00fa:  ldarg.0
    IL_00fb:  ldarg.0
    IL_00fc:  call       instance class Avro.Generic.DatumReader`1<!0> class Avro.File.DataFileReader`1<!T>::GetReaderFromSchema()
    IL_0101:  stfld      class Avro.Generic.DatumReader`1<!0> class Avro.File.DataFileReader`1<!T>::_reader
    IL_0106:  ldarg.0
    IL_0107:  ldarg.0
    IL_0108:  call       instance class Avro.File.Codec class Avro.File.DataFileReader`1<!T>::ResolveCodec()
    IL_010d:  stfld      class Avro.File.Codec class Avro.File.DataFileReader`1<!T>::_codec
    IL_0112:  ret
  } // end of method DataFileReader`1::Init

  .method private hidebysig instance class Avro.Generic.DatumReader`1<!T> 
          GetReaderFromSchema() cil managed
  {
    // Code size       91 (0x5b)
    .maxstack  2
    .locals init (class Avro.Generic.DatumReader`1<!T> V_0,
             class [mscorlib]System.Type V_1)
    IL_0000:  ldnull
    IL_0001:  stloc.0
    IL_0002:  ldtoken    !T
    IL_0007:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000c:  stloc.1
    IL_000d:  ldtoken    Avro.Specific.ISpecificRecord
    IL_0012:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0017:  ldloc.1
    IL_0018:  callvirt   instance bool [mscorlib]System.Type::IsAssignableFrom(class [mscorlib]System.Type)
    IL_001d:  brfalse.s  IL_003d

    IL_001f:  ldarg.0
    IL_0020:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0025:  callvirt   instance class Avro.Schema Avro.File.Header::get_Schema()
    IL_002a:  ldarg.0
    IL_002b:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0030:  callvirt   instance class Avro.Schema Avro.File.Header::get_Schema()
    IL_0035:  newobj     instance void class Avro.Specific.SpecificReader`1<!T>::.ctor(class Avro.Schema,
                                                                                       class Avro.Schema)
    IL_003a:  stloc.0
    IL_003b:  br.s       IL_0059

    IL_003d:  ldarg.0
    IL_003e:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_0043:  callvirt   instance class Avro.Schema Avro.File.Header::get_Schema()
    IL_0048:  ldarg.0
    IL_0049:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_004e:  callvirt   instance class Avro.Schema Avro.File.Header::get_Schema()
    IL_0053:  newobj     instance void class Avro.Generic.GenericReader`1<!T>::.ctor(class Avro.Schema,
                                                                                     class Avro.Schema)
    IL_0058:  stloc.0
    IL_0059:  ldloc.0
    IL_005a:  ret
  } // end of method DataFileReader`1::GetReaderFromSchema

  .method private hidebysig instance class Avro.File.Codec 
          ResolveCodec() cil managed
  {
    // Code size       17 (0x11)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "avro.codec"
    IL_0006:  call       instance string class Avro.File.DataFileReader`1<!T>::GetMetaString(string)
    IL_000b:  call       class Avro.File.Codec Avro.File.Codec::CreateCodecFromString(string)
    IL_0010:  ret
  } // end of method DataFileReader`1::ResolveCodec

  .method private hidebysig instance !T  Next() cil managed
  {
    // Code size       16 (0x10)
    .maxstack  2
    .locals init (!T V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldloca.s   V_0
    IL_0003:  initobj    !T
    IL_0009:  ldloc.0
    IL_000a:  call       instance !0 class Avro.File.DataFileReader`1<!T>::Next(!0)
    IL_000f:  ret
  } // end of method DataFileReader`1::Next

  .method private hidebysig instance !T  Next(!T reuse) cil managed
  {
    // Code size       90 (0x5a)
    .maxstack  3
    .locals init (!T V_0,
             class [mscorlib]System.Exception V_1,
             !T V_2,
             int64 V_3)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  call       instance bool class Avro.File.DataFileReader`1<!T>::MoveNext()
      IL_0006:  brtrue.s   IL_0013

      IL_0008:  ldstr      "No more datum objects remaining in block!"
      IL_000d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
      IL_0012:  throw

      IL_0013:  ldarg.0
      IL_0014:  ldfld      class Avro.Generic.DatumReader`1<!0> class Avro.File.DataFileReader`1<!T>::_reader
      IL_0019:  ldarg.1
      IL_001a:  ldarg.0
      IL_001b:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_datumDecoder
      IL_0020:  callvirt   instance !0 class Avro.Generic.DatumReader`1<!T>::Read(!0,
                                                                                  class Avro.IO.Decoder)
      IL_0025:  stloc.0
      IL_0026:  ldarg.0
      IL_0027:  dup
      IL_0028:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_002d:  ldc.i4.1
      IL_002e:  conv.i8
      IL_002f:  sub
      IL_0030:  dup
      IL_0031:  stloc.3
      IL_0032:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_0037:  ldloc.3
      IL_0038:  ldc.i4.0
      IL_0039:  conv.i8
      IL_003a:  bne.un.s   IL_0042

      IL_003c:  ldarg.0
      IL_003d:  call       instance void class Avro.File.DataFileReader`1<!T>::BlockFinished()
      IL_0042:  ldloc.0
      IL_0043:  stloc.2
      IL_0044:  leave.s    IL_0058

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0046:  stloc.1
      IL_0047:  ldstr      "Error fetching next object from block: {0}"
      IL_004c:  ldloc.1
      IL_004d:  call       string [mscorlib]System.String::Format(string,
                                                                  object)
      IL_0052:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
      IL_0057:  throw

    }  // end handler
    IL_0058:  ldloc.2
    IL_0059:  ret
  } // end of method DataFileReader`1::Next

  .method private hidebysig instance void 
          BlockFinished() cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.0
    IL_0002:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0007:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_000c:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockStart
    IL_0011:  ret
  } // end of method DataFileReader`1::BlockFinished

  .method private hidebysig instance class Avro.File.DataBlock 
          NextRawBlock(class Avro.File.DataBlock reuse) cil managed
  {
    // Code size       170 (0xaa)
    .maxstack  4
    IL_0000:  ldarg.0
    IL_0001:  call       instance bool class Avro.File.DataFileReader`1<!T>::HasNextBlock()
    IL_0006:  brtrue.s   IL_0013

    IL_0008:  ldstr      "No data remaining in block!"
    IL_000d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ldarg.1
    IL_0014:  brfalse.s  IL_0027

    IL_0016:  ldarg.1
    IL_0017:  callvirt   instance uint8[] Avro.File.DataBlock::get_Data()
    IL_001c:  ldlen
    IL_001d:  conv.i4
    IL_001e:  conv.i8
    IL_001f:  ldarg.0
    IL_0020:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
    IL_0025:  bge.s      IL_003c

    IL_0027:  ldarg.0
    IL_0028:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
    IL_002d:  ldarg.0
    IL_002e:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
    IL_0033:  newobj     instance void Avro.File.DataBlock::.ctor(int64,
                                                                  int64)
    IL_0038:  starg.s    reuse
    IL_003a:  br.s       IL_0054

    IL_003c:  ldarg.1
    IL_003d:  ldarg.0
    IL_003e:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
    IL_0043:  callvirt   instance void Avro.File.DataBlock::set_NumberOfEntries(int64)
    IL_0048:  ldarg.1
    IL_0049:  ldarg.0
    IL_004a:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
    IL_004f:  callvirt   instance void Avro.File.DataBlock::set_BlockSize(int64)
    IL_0054:  ldarg.0
    IL_0055:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_005a:  ldarg.1
    IL_005b:  callvirt   instance uint8[] Avro.File.DataBlock::get_Data()
    IL_0060:  ldc.i4.0
    IL_0061:  ldarg.1
    IL_0062:  callvirt   instance int64 Avro.File.DataBlock::get_BlockSize()
    IL_0067:  conv.i4
    IL_0068:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[],
                                                                  int32,
                                                                  int32)
    IL_006d:  ldarg.0
    IL_006e:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
    IL_0073:  ldarg.0
    IL_0074:  ldfld      uint8[] class Avro.File.DataFileReader`1<!T>::_syncBuffer
    IL_0079:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
    IL_007e:  ldarg.0
    IL_007f:  ldfld      uint8[] class Avro.File.DataFileReader`1<!T>::_syncBuffer
    IL_0084:  ldarg.0
    IL_0085:  ldfld      class Avro.File.Header class Avro.File.DataFileReader`1<!T>::_header
    IL_008a:  callvirt   instance uint8[] Avro.File.Header::get_SyncData()
    IL_008f:  call       bool [System.Core]System.Linq.Enumerable::SequenceEqual<uint8>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>,
                                                                                        class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
    IL_0094:  brtrue.s   IL_00a1

    IL_0096:  ldstr      "Invalid sync!"
    IL_009b:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_00a0:  throw

    IL_00a1:  ldarg.0
    IL_00a2:  ldc.i4.0
    IL_00a3:  stfld      bool class Avro.File.DataFileReader`1<!T>::_availableBlock
    IL_00a8:  ldarg.1
    IL_00a9:  ret
  } // end of method DataFileReader`1::NextRawBlock

  .method private hidebysig instance bool 
          DataLeft() cil managed
  {
    // Code size       44 (0x2c)
    .maxstack  2
    .locals init (int64 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0006:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0012:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_0017:  ldc.i4.m1
    IL_0018:  beq.s      IL_0028

    IL_001a:  ldarg.0
    IL_001b:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileReader`1<!T>::_stream
    IL_0020:  ldloc.0
    IL_0021:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
    IL_0026:  br.s       IL_002a

    IL_0028:  ldc.i4.0
    IL_0029:  ret

    IL_002a:  ldc.i4.1
    IL_002b:  ret
  } // end of method DataFileReader`1::DataLeft

  .method private hidebysig instance bool 
          HasNextBlock() cil managed
  {
    // Code size       155 (0x9b)
    .maxstack  2
    .locals init (class [mscorlib]System.Exception V_0,
             bool V_1)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldfld      bool class Avro.File.DataFileReader`1<!T>::_availableBlock
      IL_0006:  brfalse.s  IL_000f

      IL_0008:  ldc.i4.1
      IL_0009:  stloc.1
      IL_000a:  leave      IL_0099

      IL_000f:  ldarg.0
      IL_0010:  call       instance bool class Avro.File.DataFileReader`1<!T>::DataLeft()
      IL_0015:  brtrue.s   IL_001b

      IL_0017:  ldc.i4.0
      IL_0018:  stloc.1
      IL_0019:  leave.s    IL_0099

      IL_001b:  ldarg.0
      IL_001c:  ldarg.0
      IL_001d:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
      IL_0022:  callvirt   instance int64 Avro.IO.Decoder::ReadLong()
      IL_0027:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_002c:  ldarg.0
      IL_002d:  ldarg.0
      IL_002e:  ldfld      class Avro.IO.Decoder class Avro.File.DataFileReader`1<!T>::_decoder
      IL_0033:  callvirt   instance int64 Avro.IO.Decoder::ReadLong()
      IL_0038:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
      IL_003d:  ldarg.0
      IL_003e:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
      IL_0043:  ldc.i4     0x7fffffff
      IL_0048:  conv.i8
      IL_0049:  bgt.s      IL_0055

      IL_004b:  ldarg.0
      IL_004c:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
      IL_0051:  ldc.i4.0
      IL_0052:  conv.i8
      IL_0053:  bge.s      IL_0070

      IL_0055:  ldstr      "Block size invalid or too large for this implement"
      + "ation: "
      IL_005a:  ldarg.0
      IL_005b:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockSize
      IL_0060:  box        [mscorlib]System.Int64
      IL_0065:  call       string [mscorlib]System.String::Concat(object,
                                                                  object)
      IL_006a:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
      IL_006f:  throw

      IL_0070:  ldarg.0
      IL_0071:  ldarg.0
      IL_0072:  ldfld      int64 class Avro.File.DataFileReader`1<!T>::_blockRemaining
      IL_0077:  stfld      int64 class Avro.File.DataFileReader`1<!T>::_blockCount
      IL_007c:  ldarg.0
      IL_007d:  ldc.i4.1
      IL_007e:  stfld      bool class Avro.File.DataFileReader`1<!T>::_availableBlock
      IL_0083:  ldc.i4.1
      IL_0084:  stloc.1
      IL_0085:  leave.s    IL_0099

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0087:  stloc.0
      IL_0088:  ldstr      "Error ascertaining if data has next block: {0}"
      IL_008d:  ldloc.0
      IL_008e:  call       string [mscorlib]System.String::Format(string,
                                                                  object)
      IL_0093:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
      IL_0098:  throw

    }  // end handler
    IL_0099:  ldloc.1
    IL_009a:  ret
  } // end of method DataFileReader`1::HasNextBlock

  .property instance !T Current()
  {
    .get instance !T Avro.File.DataFileReader`1::get_Current()
  } // end of property DataFileReader`1::Current
  .property instance object System.Collections.IEnumerator.Current()
  {
    .get instance object Avro.File.DataFileReader`1::System.Collections.IEnumerator.get_Current()
  } // end of property DataFileReader`1::System.Collections.IEnumerator.Current
} // end of class Avro.File.DataFileReader`1

.class interface public abstract auto ansi Avro.File.IFileWriter`1<T>
{
  .method public hidebysig newslot abstract virtual 
          instance void  Append(!T datum) cil managed
  {
  } // end of method IFileWriter`1::Append

  .method public hidebysig newslot abstract virtual 
          instance void  Close() cil managed
  {
  } // end of method IFileWriter`1::Close

  .method public hidebysig newslot abstract virtual 
          instance void  Flush() cil managed
  {
  } // end of method IFileWriter`1::Flush

  .method public hidebysig newslot abstract virtual 
          instance bool  IsReservedMeta(string key) cil managed
  {
  } // end of method IFileWriter`1::IsReservedMeta

  .method public hidebysig newslot abstract virtual 
          instance void  SetMeta(string key,
                                 uint8[] 'value') cil managed
  {
  } // end of method IFileWriter`1::SetMeta

  .method public hidebysig newslot abstract virtual 
          instance void  SetMeta(string key,
                                 int64 'value') cil managed
  {
  } // end of method IFileWriter`1::SetMeta

  .method public hidebysig newslot abstract virtual 
          instance void  SetMeta(string key,
                                 string 'value') cil managed
  {
  } // end of method IFileWriter`1::SetMeta

  .method public hidebysig newslot abstract virtual 
          instance void  SetSyncInterval(int32 syncInterval) cil managed
  {
  } // end of method IFileWriter`1::SetSyncInterval

  .method public hidebysig newslot abstract virtual 
          instance int64  Sync() cil managed
  {
  } // end of method IFileWriter`1::Sync

  .method public hidebysig newslot abstract virtual 
          instance void  WriteHeader() cil managed
  {
  } // end of method IFileWriter`1::WriteHeader

} // end of class Avro.File.IFileWriter`1

.class public auto ansi beforefieldinit Avro.File.DataFileWriter`1<T>
       extends [mscorlib]System.Object
       implements class Avro.File.IFileWriter`1<!T>
{
  .field private class Avro.Schema _schema
  .field private class Avro.File.Codec _codec
  .field private class [mscorlib]System.IO.Stream _stream
  .field private class [mscorlib]System.IO.MemoryStream _blockStream
  .field private class Avro.IO.Encoder _encoder
  .field private class Avro.IO.Encoder _blockEncoder
  .field private class Avro.Generic.DatumWriter`1<!T> _writer
  .field private uint8[] _syncData
  .field private bool _isOpen
  .field private int32 _blockCount
  .field private int32 _syncInterval
  .field private class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> _metaData
  .method public hidebysig static class Avro.File.IFileWriter`1<!T> 
          OpenWriter(class Avro.Generic.DatumWriter`1<!T> writer,
                     string path) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.2
    IL_0003:  newobj     instance void [mscorlib]System.IO.FileStream::.ctor(string,
                                                                             valuetype [mscorlib]System.IO.FileMode)
    IL_0008:  ldc.i4.1
    IL_0009:  call       class Avro.File.Codec Avro.File.Codec::CreateCodec(valuetype Avro.File.Codec/Type)
    IL_000e:  call       class Avro.File.IFileWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::OpenWriter(class Avro.Generic.DatumWriter`1<!0>,
                                                                                                            class [mscorlib]System.IO.Stream,
                                                                                                            class Avro.File.Codec)
    IL_0013:  ret
  } // end of method DataFileWriter`1::OpenWriter

  .method public hidebysig static class Avro.File.IFileWriter`1<!T> 
          OpenWriter(class Avro.Generic.DatumWriter`1<!T> writer,
                     class [mscorlib]System.IO.Stream outStream) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.1
    IL_0003:  call       class Avro.File.Codec Avro.File.Codec::CreateCodec(valuetype Avro.File.Codec/Type)
    IL_0008:  call       class Avro.File.IFileWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::OpenWriter(class Avro.Generic.DatumWriter`1<!0>,
                                                                                                            class [mscorlib]System.IO.Stream,
                                                                                                            class Avro.File.Codec)
    IL_000d:  ret
  } // end of method DataFileWriter`1::OpenWriter

  .method public hidebysig static class Avro.File.IFileWriter`1<!T> 
          OpenWriter(class Avro.Generic.DatumWriter`1<!T> writer,
                     string path,
                     class Avro.File.Codec codec) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.2
    IL_0003:  newobj     instance void [mscorlib]System.IO.FileStream::.ctor(string,
                                                                             valuetype [mscorlib]System.IO.FileMode)
    IL_0008:  ldarg.2
    IL_0009:  call       class Avro.File.IFileWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::OpenWriter(class Avro.Generic.DatumWriter`1<!0>,
                                                                                                            class [mscorlib]System.IO.Stream,
                                                                                                            class Avro.File.Codec)
    IL_000e:  ret
  } // end of method DataFileWriter`1::OpenWriter

  .method public hidebysig static class Avro.File.IFileWriter`1<!T> 
          OpenWriter(class Avro.Generic.DatumWriter`1<!T> writer,
                     class [mscorlib]System.IO.Stream outStream,
                     class Avro.File.Codec codec) cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class Avro.File.DataFileWriter`1<!T>::.ctor(class Avro.Generic.DatumWriter`1<!0>)
    IL_0006:  ldarg.0
    IL_0007:  callvirt   instance class Avro.Schema class Avro.Generic.DatumWriter`1<!T>::get_Schema()
    IL_000c:  ldarg.1
    IL_000d:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_0012:  ldarg.2
    IL_0013:  call       instance class Avro.File.IFileWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::Create(class Avro.Schema,
                                                                                                                 class [mscorlib]System.IO.Stream,
                                                                                                                 class [mscorlib]System.IO.MemoryStream,
                                                                                                                 class Avro.File.Codec)
    IL_0018:  ret
  } // end of method DataFileWriter`1::OpenWriter

  .method public hidebysig static class Avro.File.IFileWriter`1<!T> 
          OpenWriter(class Avro.Generic.DatumWriter`1<!T> writer,
                     class [mscorlib]System.IO.Stream outStream,
                     class Avro.File.Codec codec,
                     class [mscorlib]System.IO.MemoryStream blockStream) cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class Avro.File.DataFileWriter`1<!T>::.ctor(class Avro.Generic.DatumWriter`1<!0>)
    IL_0006:  ldarg.0
    IL_0007:  callvirt   instance class Avro.Schema class Avro.Generic.DatumWriter`1<!T>::get_Schema()
    IL_000c:  ldarg.1
    IL_000d:  ldarg.3
    IL_000e:  ldarg.2
    IL_000f:  call       instance class Avro.File.IFileWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::Create(class Avro.Schema,
                                                                                                                 class [mscorlib]System.IO.Stream,
                                                                                                                 class [mscorlib]System.IO.MemoryStream,
                                                                                                                 class Avro.File.Codec)
    IL_0014:  ret
  } // end of method DataFileWriter`1::OpenWriter

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Generic.DatumWriter`1<!T> writer) cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class Avro.Generic.DatumWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::_writer
    IL_000d:  ldarg.0
    IL_000e:  ldc.i4     0x3e80
    IL_0013:  stfld      int32 class Avro.File.DataFileWriter`1<!T>::_syncInterval
    IL_0018:  ret
  } // end of method DataFileWriter`1::.ctor

  .method public hidebysig newslot virtual final 
          instance bool  IsReservedMeta(string key) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldstr      "avro"
    IL_0006:  callvirt   instance bool [mscorlib]System.String::StartsWith(string)
    IL_000b:  ret
  } // end of method DataFileWriter`1::IsReservedMeta

  .method public hidebysig newslot virtual final 
          instance void  SetMeta(string key,
                                 uint8[] 'value') cil managed
  {
    // Code size       40 (0x28)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance bool class Avro.File.DataFileWriter`1<!T>::IsReservedMeta(string)
    IL_0007:  brfalse.s  IL_001a

    IL_0009:  ldstr      "Cannot set reserved meta key: "
    IL_000e:  ldarg.1
    IL_000f:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0014:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0019:  throw

    IL_001a:  ldarg.0
    IL_001b:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> class Avro.File.DataFileWriter`1<!T>::_metaData
    IL_0020:  ldarg.1
    IL_0021:  ldarg.2
    IL_0022:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>::Add(!0,
                                                                                                                     !1)
    IL_0027:  ret
  } // end of method DataFileWriter`1::SetMeta

  .method public hidebysig newslot virtual final 
          instance void  SetMeta(string key,
                                 int64 'value') cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  4
    .locals init (class [mscorlib]System.Exception V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  ldarg.0
      IL_0003:  ldarg.2
      IL_0004:  call       instance uint8[] class Avro.File.DataFileWriter`1<!T>::GetByteValue(int64)
      IL_0009:  call       instance void class Avro.File.DataFileWriter`1<!T>::SetMeta(string,
                                                                                       uint8[])
      IL_000e:  leave.s    IL_001e

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0010:  stloc.0
      IL_0011:  ldloc.0
      IL_0012:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_0017:  ldloc.0
      IL_0018:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_001d:  throw

    }  // end handler
    IL_001e:  ret
  } // end of method DataFileWriter`1::SetMeta

  .method public hidebysig newslot virtual final 
          instance void  SetMeta(string key,
                                 string 'value') cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  4
    .locals init (class [mscorlib]System.Exception V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  ldarg.0
      IL_0003:  ldarg.2
      IL_0004:  call       instance uint8[] class Avro.File.DataFileWriter`1<!T>::GetByteValue(string)
      IL_0009:  call       instance void class Avro.File.DataFileWriter`1<!T>::SetMeta(string,
                                                                                       uint8[])
      IL_000e:  leave.s    IL_001e

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0010:  stloc.0
      IL_0011:  ldloc.0
      IL_0012:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_0017:  ldloc.0
      IL_0018:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_001d:  throw

    }  // end handler
    IL_001e:  ret
  } // end of method DataFileWriter`1::SetMeta

  .method public hidebysig newslot virtual final 
          instance void  SetSyncInterval(int32 syncInterval) cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldc.i4.s   32
    IL_0003:  blt.s      IL_000d

    IL_0005:  ldarg.1
    IL_0006:  ldc.i4     0x40000000
    IL_000b:  ble.s      IL_0023

    IL_000d:  ldstr      "Invalid sync interval value: "
    IL_0012:  ldarg.1
    IL_0013:  box        [mscorlib]System.Int32
    IL_0018:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_001d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0022:  throw

    IL_0023:  ldarg.0
    IL_0024:  ldarg.1
    IL_0025:  stfld      int32 class Avro.File.DataFileWriter`1<!T>::_syncInterval
    IL_002a:  ret
  } // end of method DataFileWriter`1::SetSyncInterval

  .method public hidebysig newslot virtual final 
          instance void  Append(!T datum) cil managed
  {
    // Code size       84 (0x54)
    .maxstack  3
    .locals init (int64 V_0,
             class [mscorlib]System.Exception V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class Avro.File.DataFileWriter`1<!T>::AssertOpen()
    IL_0006:  ldarg.0
    IL_0007:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_000c:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_0011:  stloc.0
    .try
    {
      IL_0012:  ldarg.0
      IL_0013:  ldfld      class Avro.Generic.DatumWriter`1<!0> class Avro.File.DataFileWriter`1<!T>::_writer
      IL_0018:  ldarg.1
      IL_0019:  ldarg.0
      IL_001a:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_blockEncoder
      IL_001f:  callvirt   instance void class Avro.Generic.DatumWriter`1<!T>::Write(!0,
                                                                                     class Avro.IO.Encoder)
      IL_0024:  leave.s    IL_003f

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0026:  stloc.1
      IL_0027:  ldarg.0
      IL_0028:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
      IL_002d:  ldloc.0
      IL_002e:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_0033:  ldstr      "Error appending datum to writer"
      IL_0038:  ldloc.1
      IL_0039:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_003e:  throw

    }  // end handler
    IL_003f:  ldarg.0
    IL_0040:  dup
    IL_0041:  ldfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_0046:  ldc.i4.1
    IL_0047:  add
    IL_0048:  stfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_004d:  ldarg.0
    IL_004e:  call       instance void class Avro.File.DataFileWriter`1<!T>::WriteIfBlockFull()
    IL_0053:  ret
  } // end of method DataFileWriter`1::Append

  .method public hidebysig newslot virtual final 
          instance void  Flush() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 class Avro.File.DataFileWriter`1<!T>::Sync()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method DataFileWriter`1::Flush

  .method public hidebysig newslot virtual final 
          instance int64  Sync() cil managed
  {
    // Code size       24 (0x18)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class Avro.File.DataFileWriter`1<!T>::AssertOpen()
    IL_0006:  ldarg.0
    IL_0007:  call       instance void class Avro.File.DataFileWriter`1<!T>::WriteBlock()
    IL_000c:  ldarg.0
    IL_000d:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileWriter`1<!T>::_stream
    IL_0012:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_0017:  ret
  } // end of method DataFileWriter`1::Sync

  .method public hidebysig newslot virtual final 
          instance void  Close() cil managed
  {
    // Code size       36 (0x24)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class Avro.File.DataFileWriter`1<!T>::Flush()
    IL_0006:  ldarg.0
    IL_0007:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileWriter`1<!T>::_stream
    IL_000c:  callvirt   instance void [mscorlib]System.IO.Stream::Flush()
    IL_0011:  ldarg.0
    IL_0012:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileWriter`1<!T>::_stream
    IL_0017:  callvirt   instance void [mscorlib]System.IO.Stream::Close()
    IL_001c:  ldarg.0
    IL_001d:  ldc.i4.0
    IL_001e:  stfld      bool class Avro.File.DataFileWriter`1<!T>::_isOpen
    IL_0023:  ret
  } // end of method DataFileWriter`1::Close

  .method public hidebysig newslot virtual final 
          instance void  WriteHeader() cil managed
  {
    // Code size       29 (0x1d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0006:  ldsfld     uint8[] Avro.File.DataFileConstants::Magic
    IL_000b:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0010:  ldarg.0
    IL_0011:  call       instance void class Avro.File.DataFileWriter`1<!T>::WriteMetaData()
    IL_0016:  ldarg.0
    IL_0017:  call       instance void class Avro.File.DataFileWriter`1<!T>::WriteSyncData()
    IL_001c:  ret
  } // end of method DataFileWriter`1::WriteHeader

  .method private hidebysig instance void 
          Init() cil managed
  {
    // Code size       69 (0x45)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  stfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_0007:  ldarg.0
    IL_0008:  ldarg.0
    IL_0009:  ldfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileWriter`1<!T>::_stream
    IL_000e:  newobj     instance void Avro.IO.BinaryEncoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_0013:  stfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0018:  ldarg.0
    IL_0019:  ldarg.0
    IL_001a:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_001f:  newobj     instance void Avro.IO.BinaryEncoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_0024:  stfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_blockEncoder
    IL_0029:  ldarg.0
    IL_002a:  ldfld      class Avro.File.Codec class Avro.File.DataFileWriter`1<!T>::_codec
    IL_002f:  brtrue.s   IL_003d

    IL_0031:  ldarg.0
    IL_0032:  ldc.i4.1
    IL_0033:  call       class Avro.File.Codec Avro.File.Codec::CreateCodec(valuetype Avro.File.Codec/Type)
    IL_0038:  stfld      class Avro.File.Codec class Avro.File.DataFileWriter`1<!T>::_codec
    IL_003d:  ldarg.0
    IL_003e:  ldc.i4.1
    IL_003f:  stfld      bool class Avro.File.DataFileWriter`1<!T>::_isOpen
    IL_0044:  ret
  } // end of method DataFileWriter`1::Init

  .method private hidebysig instance void 
          AssertOpen() cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool class Avro.File.DataFileWriter`1<!T>::_isOpen
    IL_0006:  brtrue.s   IL_0013

    IL_0008:  ldstr      "Cannot complete operation: avro file/stream not open"
    IL_000d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ret
  } // end of method DataFileWriter`1::AssertOpen

  .method private hidebysig instance void 
          AssertNotOpen() cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      bool class Avro.File.DataFileWriter`1<!T>::_isOpen
    IL_0006:  brfalse.s  IL_0013

    IL_0008:  ldstr      "Cannot complete operation: avro file/stream alread"
    + "y open"
    IL_000d:  newobj     instance void Avro.AvroRuntimeException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ret
  } // end of method DataFileWriter`1::AssertNotOpen

  .method private hidebysig instance class Avro.File.IFileWriter`1<!T> 
          Create(class Avro.Schema schema,
                 class [mscorlib]System.IO.Stream outStream,
                 class [mscorlib]System.IO.MemoryStream blockStream,
                 class Avro.File.Codec codec) cil managed
  {
    // Code size       98 (0x62)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class Avro.File.DataFileWriter`1<!T>::AssertNotOpen()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.s    codec
    IL_0009:  stfld      class Avro.File.Codec class Avro.File.DataFileWriter`1<!T>::_codec
    IL_000e:  ldarg.0
    IL_000f:  ldarg.2
    IL_0010:  stfld      class [mscorlib]System.IO.Stream class Avro.File.DataFileWriter`1<!T>::_stream
    IL_0015:  ldarg.0
    IL_0016:  ldarg.3
    IL_0017:  stfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_001c:  ldarg.0
    IL_001d:  ldarg.1
    IL_001e:  stfld      class Avro.Schema class Avro.File.DataFileWriter`1<!T>::_schema
    IL_0023:  ldarg.0
    IL_0024:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,uint8[]>::.ctor()
    IL_0029:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> class Avro.File.DataFileWriter`1<!T>::_metaData
    IL_002e:  ldarg.0
    IL_002f:  ldstr      "avro.codec"
    IL_0034:  ldarg.0
    IL_0035:  ldfld      class Avro.File.Codec class Avro.File.DataFileWriter`1<!T>::_codec
    IL_003a:  callvirt   instance string Avro.File.Codec::GetName()
    IL_003f:  call       instance void class Avro.File.DataFileWriter`1<!T>::SetMetaInternal(string,
                                                                                             string)
    IL_0044:  ldarg.0
    IL_0045:  ldstr      "avro.schema"
    IL_004a:  ldarg.0
    IL_004b:  ldfld      class Avro.Schema class Avro.File.DataFileWriter`1<!T>::_schema
    IL_0050:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0055:  call       instance void class Avro.File.DataFileWriter`1<!T>::SetMetaInternal(string,
                                                                                             string)
    IL_005a:  ldarg.0
    IL_005b:  call       instance void class Avro.File.DataFileWriter`1<!T>::Init()
    IL_0060:  ldarg.0
    IL_0061:  ret
  } // end of method DataFileWriter`1::Create

  .method private hidebysig instance void 
          WriteMetaData() cil managed
  {
    // Code size       119 (0x77)
    .maxstack  2
    .locals init (int32 V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]> V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class Avro.File.DataFileWriter`1<!T>::GenerateSyncData()
    IL_0006:  ldarg.0
    IL_0007:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> class Avro.File.DataFileWriter`1<!T>::_metaData
    IL_000c:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>>::get_Count()
    IL_0011:  stloc.0
    IL_0012:  ldarg.0
    IL_0013:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0018:  ldloc.0
    IL_0019:  callvirt   instance void Avro.IO.Encoder::WriteInt(int32)
    IL_001e:  ldarg.0
    IL_001f:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> class Avro.File.DataFileWriter`1<!T>::_metaData
    IL_0024:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>>::GetEnumerator()
    IL_0029:  stloc.2
    .try
    {
      IL_002a:  br.s       IL_0057

      IL_002c:  ldloc.2
      IL_002d:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>>::get_Current()
      IL_0032:  stloc.1
      IL_0033:  ldarg.0
      IL_0034:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
      IL_0039:  ldloca.s   V_1
      IL_003b:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>::get_Key()
      IL_0040:  callvirt   instance void Avro.IO.Encoder::WriteString(string)
      IL_0045:  ldarg.0
      IL_0046:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
      IL_004b:  ldloca.s   V_1
      IL_004d:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,uint8[]>::get_Value()
      IL_0052:  callvirt   instance void Avro.IO.Encoder::WriteBytes(uint8[])
      IL_0057:  ldloc.2
      IL_0058:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_005d:  brtrue.s   IL_002c

      IL_005f:  leave.s    IL_006b

    }  // end .try
    finally
    {
      IL_0061:  ldloc.2
      IL_0062:  brfalse.s  IL_006a

      IL_0064:  ldloc.2
      IL_0065:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_006a:  endfinally
    }  // end handler
    IL_006b:  ldarg.0
    IL_006c:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0071:  callvirt   instance void Avro.IO.Encoder::WriteMapEnd()
    IL_0076:  ret
  } // end of method DataFileWriter`1::WriteMetaData

  .method private hidebysig instance void 
          WriteIfBlockFull() cil managed
  {
    // Code size       22 (0x16)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 class Avro.File.DataFileWriter`1<!T>::BufferInUse()
    IL_0006:  ldarg.0
    IL_0007:  ldfld      int32 class Avro.File.DataFileWriter`1<!T>::_syncInterval
    IL_000c:  conv.i8
    IL_000d:  blt.s      IL_0015

    IL_000f:  ldarg.0
    IL_0010:  call       instance void class Avro.File.DataFileWriter`1<!T>::WriteBlock()
    IL_0015:  ret
  } // end of method DataFileWriter`1::WriteIfBlockFull

  .method private hidebysig instance int64 
          BufferInUse() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_0006:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Position()
    IL_000b:  ret
  } // end of method DataFileWriter`1::BufferInUse

  .method private hidebysig instance void 
          WriteBlock() cil managed
  {
    // Code size       94 (0x5e)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_0006:  ldc.i4.0
    IL_0007:  bgt.s      IL_000a

    IL_0009:  ret

    IL_000a:  ldarg.0
    IL_000b:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0010:  ldarg.0
    IL_0011:  ldfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_0016:  conv.i8
    IL_0017:  callvirt   instance void Avro.IO.Encoder::WriteLong(int64)
    IL_001c:  ldarg.0
    IL_001d:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0022:  ldarg.0
    IL_0023:  ldfld      class Avro.File.Codec class Avro.File.DataFileWriter`1<!T>::_codec
    IL_0028:  ldarg.0
    IL_0029:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_002e:  callvirt   instance class [mscorlib]System.IO.Stream Avro.File.Codec::Compress(class [mscorlib]System.IO.Stream)
    IL_0033:  callvirt   instance void Avro.IO.Encoder::WriteStream(class [mscorlib]System.IO.Stream)
    IL_0038:  ldarg.0
    IL_0039:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_003e:  ldarg.0
    IL_003f:  ldfld      uint8[] class Avro.File.DataFileWriter`1<!T>::_syncData
    IL_0044:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0049:  ldarg.0
    IL_004a:  ldc.i4.0
    IL_004b:  stfld      int32 class Avro.File.DataFileWriter`1<!T>::_blockCount
    IL_0050:  ldarg.0
    IL_0051:  ldfld      class [mscorlib]System.IO.MemoryStream class Avro.File.DataFileWriter`1<!T>::_blockStream
    IL_0056:  ldc.i4.0
    IL_0057:  conv.i8
    IL_0058:  callvirt   instance void [mscorlib]System.IO.Stream::SetLength(int64)
    IL_005d:  ret
  } // end of method DataFileWriter`1::WriteBlock

  .method private hidebysig instance void 
          WriteSyncData() cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.IO.Encoder class Avro.File.DataFileWriter`1<!T>::_encoder
    IL_0006:  ldarg.0
    IL_0007:  ldfld      uint8[] class Avro.File.DataFileWriter`1<!T>::_syncData
    IL_000c:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0011:  ret
  } // end of method DataFileWriter`1::WriteSyncData

  .method private hidebysig instance void 
          GenerateSyncData() cil managed
  {
    // Code size       32 (0x20)
    .maxstack  2
    .locals init (class [mscorlib]System.Random V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   16
    IL_0003:  newarr     [mscorlib]System.Byte
    IL_0008:  stfld      uint8[] class Avro.File.DataFileWriter`1<!T>::_syncData
    IL_000d:  newobj     instance void [mscorlib]System.Random::.ctor()
    IL_0012:  stloc.0
    IL_0013:  ldloc.0
    IL_0014:  ldarg.0
    IL_0015:  ldfld      uint8[] class Avro.File.DataFileWriter`1<!T>::_syncData
    IL_001a:  callvirt   instance void [mscorlib]System.Random::NextBytes(uint8[])
    IL_001f:  ret
  } // end of method DataFileWriter`1::GenerateSyncData

  .method private hidebysig instance void 
          SetMetaInternal(string key,
                          uint8[] 'value') cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> class Avro.File.DataFileWriter`1<!T>::_metaData
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>::Add(!0,
                                                                                                                     !1)
    IL_000d:  ret
  } // end of method DataFileWriter`1::SetMetaInternal

  .method private hidebysig instance void 
          SetMetaInternal(string key,
                          string 'value') cil managed
  {
    // Code size       37 (0x25)
    .maxstack  4
    .locals init (class [mscorlib]System.Exception V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  ldarg.0
      IL_0003:  ldarg.2
      IL_0004:  call       instance uint8[] class Avro.File.DataFileWriter`1<!T>::GetByteValue(string)
      IL_0009:  call       instance void class Avro.File.DataFileWriter`1<!T>::SetMetaInternal(string,
                                                                                               uint8[])
      IL_000e:  leave.s    IL_0024

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0010:  stloc.0
      IL_0011:  ldstr      "Error setting internal meta data for key: {0} valu"
      + "e: {1}"
      IL_0016:  ldarg.1
      IL_0017:  ldarg.2
      IL_0018:  call       string [mscorlib]System.String::Format(string,
                                                                  object,
                                                                  object)
      IL_001d:  ldloc.0
      IL_001e:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_0023:  throw

    }  // end handler
    IL_0024:  ret
  } // end of method DataFileWriter`1::SetMetaInternal

  .method private hidebysig instance uint8[] 
          GetByteValue(string 'value') cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
    IL_0005:  ldarg.1
    IL_0006:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_000b:  ret
  } // end of method DataFileWriter`1::GetByteValue

  .method private hidebysig instance uint8[] 
          GetByteValue(int64 'value') cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  call       uint8[] [mscorlib]System.BitConverter::GetBytes(int64)
    IL_0006:  ret
  } // end of method DataFileWriter`1::GetByteValue

} // end of class Avro.File.DataFileWriter`1

.class public auto ansi beforefieldinit Avro.File.DeflateCodec
       extends Avro.File.Codec
{
  .field private initonly class [mscorlib]System.IO.MemoryStream _buffer
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_0006:  call       instance void Avro.File.DeflateCodec::.ctor(class [mscorlib]System.IO.MemoryStream)
    IL_000b:  ret
  } // end of method DeflateCodec::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.IO.MemoryStream buffer) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Avro.File.Codec::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  dup
    IL_0009:  brtrue.s   IL_0011

    IL_000b:  pop
    IL_000c:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_0011:  stfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_0016:  ret
  } // end of method DeflateCodec::.ctor

  .method public hidebysig virtual instance class [mscorlib]System.IO.Stream 
          Compress(class [mscorlib]System.IO.Stream uncompressedStream) cil managed
  {
    // Code size       74 (0x4a)
    .maxstack  3
    .locals init (class [System]System.IO.Compression.DeflateStream V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_0006:  ldc.i4.0
    IL_0007:  conv.i8
    IL_0008:  callvirt   instance void [mscorlib]System.IO.Stream::SetLength(int64)
    IL_000d:  ldarg.0
    IL_000e:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_0013:  ldc.i4.1
    IL_0014:  ldc.i4.1
    IL_0015:  newobj     instance void [System]System.IO.Compression.DeflateStream::.ctor(class [mscorlib]System.IO.Stream,
                                                                                          valuetype [System]System.IO.Compression.CompressionMode,
                                                                                          bool)
    IL_001a:  stloc.0
    .try
    {
      IL_001b:  ldarg.1
      IL_001c:  ldc.i4.0
      IL_001d:  conv.i8
      IL_001e:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_0023:  ldarg.1
      IL_0024:  ldloc.0
      IL_0025:  callvirt   instance void [mscorlib]System.IO.Stream::CopyTo(class [mscorlib]System.IO.Stream)
      IL_002a:  leave.s    IL_0036

    }  // end .try
    finally
    {
      IL_002c:  ldloc.0
      IL_002d:  brfalse.s  IL_0035

      IL_002f:  ldloc.0
      IL_0030:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0035:  endfinally
    }  // end handler
    IL_0036:  ldarg.0
    IL_0037:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_003c:  ldc.i4.0
    IL_003d:  conv.i8
    IL_003e:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
    IL_0043:  ldarg.0
    IL_0044:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_0049:  ret
  } // end of method DeflateCodec::Compress

  .method public hidebysig virtual instance uint8[] 
          Compress(uint8[] uncompressedData) cil managed
  {
    // Code size       64 (0x40)
    .maxstack  2
    .locals init (class [mscorlib]System.IO.MemoryStream V_0,
             class [System]System.IO.Compression.DeflateStream V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_0006:  ldc.i4.0
    IL_0007:  conv.i8
    IL_0008:  callvirt   instance void [mscorlib]System.IO.Stream::SetLength(int64)
    IL_000d:  ldarg.1
    IL_000e:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor(uint8[])
    IL_0013:  stloc.0
    IL_0014:  ldarg.0
    IL_0015:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_001a:  ldc.i4.1
    IL_001b:  newobj     instance void [System]System.IO.Compression.DeflateStream::.ctor(class [mscorlib]System.IO.Stream,
                                                                                          valuetype [System]System.IO.Compression.CompressionMode)
    IL_0020:  stloc.1
    .try
    {
      IL_0021:  ldloc.0
      IL_0022:  ldloc.1
      IL_0023:  callvirt   instance void [mscorlib]System.IO.Stream::CopyTo(class [mscorlib]System.IO.Stream)
      IL_0028:  leave.s    IL_0034

    }  // end .try
    finally
    {
      IL_002a:  ldloc.1
      IL_002b:  brfalse.s  IL_0033

      IL_002d:  ldloc.1
      IL_002e:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0033:  endfinally
    }  // end handler
    IL_0034:  ldarg.0
    IL_0035:  ldfld      class [mscorlib]System.IO.MemoryStream Avro.File.DeflateCodec::_buffer
    IL_003a:  callvirt   instance uint8[] [mscorlib]System.IO.MemoryStream::ToArray()
    IL_003f:  ret
  } // end of method DeflateCodec::Compress

  .method public hidebysig virtual instance uint8[] 
          Decompress(uint8[] compressedData) cil managed
  {
    // Code size       47 (0x2f)
    .maxstack  2
    .locals init (class [mscorlib]System.IO.MemoryStream V_0,
             class [mscorlib]System.IO.MemoryStream V_1,
             class [System]System.IO.Compression.DeflateStream V_2)
    IL_0000:  ldarg.1
    IL_0001:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor(uint8[])
    IL_0006:  stloc.0
    IL_0007:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_000c:  stloc.1
    IL_000d:  ldloc.0
    IL_000e:  ldc.i4.0
    IL_000f:  newobj     instance void [System]System.IO.Compression.DeflateStream::.ctor(class [mscorlib]System.IO.Stream,
                                                                                          valuetype [System]System.IO.Compression.CompressionMode)
    IL_0014:  stloc.2
    .try
    {
      IL_0015:  ldloc.2
      IL_0016:  ldloc.1
      IL_0017:  callvirt   instance void [mscorlib]System.IO.Stream::CopyTo(class [mscorlib]System.IO.Stream)
      IL_001c:  leave.s    IL_0028

    }  // end .try
    finally
    {
      IL_001e:  ldloc.2
      IL_001f:  brfalse.s  IL_0027

      IL_0021:  ldloc.2
      IL_0022:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0027:  endfinally
    }  // end handler
    IL_0028:  ldloc.1
    IL_0029:  callvirt   instance uint8[] [mscorlib]System.IO.MemoryStream::ToArray()
    IL_002e:  ret
  } // end of method DeflateCodec::Decompress

  .method public hidebysig virtual instance string 
          GetName() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldstr      "deflate"
    IL_0005:  ret
  } // end of method DeflateCodec::GetName

  .method public hidebysig virtual instance bool 
          Equals(object other) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.0
    IL_0007:  call       instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_000c:  callvirt   instance string [mscorlib]System.Reflection.MemberInfo::get_Name()
    IL_0011:  ldarg.1
    IL_0012:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_0017:  callvirt   instance string [mscorlib]System.Reflection.MemberInfo::get_Name()
    IL_001c:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0021:  ret
  } // end of method DeflateCodec::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.0
    IL_0001:  ret
  } // end of method DeflateCodec::GetHashCode

} // end of class Avro.File.DeflateCodec

.class public auto ansi beforefieldinit Avro.File.Header
       extends [mscorlib]System.Object
{
  .field private class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> _metaData
  .field private uint8[] _syncData
  .field private class Avro.Schema '<Schema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> 
          get_MetaData() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::_metaData
    IL_0006:  ret
  } // end of method Header::get_MetaData

  .method public hidebysig specialname instance uint8[] 
          get_SyncData() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8[] Avro.File.Header::_syncData
    IL_0006:  ret
  } // end of method Header::get_SyncData

  .method public hidebysig specialname instance class Avro.Schema 
          get_Schema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.File.Header::'<Schema>k__BackingField'
    IL_0006:  ret
  } // end of method Header::get_Schema

  .method public hidebysig specialname instance void 
          set_Schema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.File.Header::'<Schema>k__BackingField'
    IL_0007:  ret
  } // end of method Header::set_Schema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,uint8[]>::.ctor()
    IL_000c:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::_metaData
    IL_0011:  ldarg.0
    IL_0012:  ldc.i4.s   16
    IL_0014:  newarr     [mscorlib]System.Byte
    IL_0019:  stfld      uint8[] Avro.File.Header::_syncData
    IL_001e:  ret
  } // end of method Header::.ctor

  .property instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]>
          MetaData()
  {
    .get instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,uint8[]> Avro.File.Header::get_MetaData()
  } // end of property Header::MetaData
  .property instance uint8[] SyncData()
  {
    .get instance uint8[] Avro.File.Header::get_SyncData()
  } // end of property Header::SyncData
  .property instance class Avro.Schema Schema()
  {
    .get instance class Avro.Schema Avro.File.Header::get_Schema()
    .set instance void Avro.File.Header::set_Schema(class Avro.Schema)
  } // end of property Header::Schema
} // end of class Avro.File.Header

.class public auto ansi beforefieldinit Avro.File.NullCodec
       extends Avro.File.Codec
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Avro.File.Codec::.ctor()
    IL_0006:  ret
  } // end of method NullCodec::.ctor

  .method public hidebysig virtual instance class [mscorlib]System.IO.Stream 
          Compress(class [mscorlib]System.IO.Stream uncompressedStream) cil managed
  {
    // Code size       10 (0xa)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldc.i4.0
    IL_0002:  conv.i8
    IL_0003:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
    IL_0008:  ldarg.1
    IL_0009:  ret
  } // end of method NullCodec::Compress

  .method public hidebysig virtual instance uint8[] 
          Compress(uint8[] uncompressedData) cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ret
  } // end of method NullCodec::Compress

  .method public hidebysig virtual instance uint8[] 
          Decompress(uint8[] compressedData) cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ret
  } // end of method NullCodec::Decompress

  .method public hidebysig virtual instance string 
          GetName() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldstr      "null"
    IL_0005:  ret
  } // end of method NullCodec::GetName

  .method public hidebysig virtual instance bool 
          Equals(object other) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.0
    IL_0007:  call       instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_000c:  callvirt   instance string [mscorlib]System.Reflection.MemberInfo::get_Name()
    IL_0011:  ldarg.1
    IL_0012:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_0017:  callvirt   instance string [mscorlib]System.Reflection.MemberInfo::get_Name()
    IL_001c:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0021:  ret
  } // end of method NullCodec::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.2
    IL_0001:  ret
  } // end of method NullCodec::GetHashCode

} // end of class Avro.File.NullCodec

.class interface public abstract auto ansi Avro.Generic.DatumReader`1<T>
{
  .method public hidebysig newslot specialname abstract virtual 
          instance class Avro.Schema  get_ReaderSchema() cil managed
  {
  } // end of method DatumReader`1::get_ReaderSchema

  .method public hidebysig newslot specialname abstract virtual 
          instance class Avro.Schema  get_WriterSchema() cil managed
  {
  } // end of method DatumReader`1::get_WriterSchema

  .method public hidebysig newslot abstract virtual 
          instance !T  Read(!T reuse,
                            class Avro.IO.Decoder decoder) cil managed
  {
  } // end of method DatumReader`1::Read

  .property instance class Avro.Schema ReaderSchema()
  {
    .get instance class Avro.Schema Avro.Generic.DatumReader`1::get_ReaderSchema()
  } // end of property DatumReader`1::ReaderSchema
  .property instance class Avro.Schema WriterSchema()
  {
    .get instance class Avro.Schema Avro.Generic.DatumReader`1::get_WriterSchema()
  } // end of property DatumReader`1::WriterSchema
} // end of class Avro.Generic.DatumReader`1

.class interface public abstract auto ansi Avro.Generic.DatumWriter`1<T>
{
  .method public hidebysig newslot specialname abstract virtual 
          instance class Avro.Schema  get_Schema() cil managed
  {
  } // end of method DatumWriter`1::get_Schema

  .method public hidebysig newslot abstract virtual 
          instance void  Write(!T datum,
                               class Avro.IO.Encoder encoder) cil managed
  {
  } // end of method DatumWriter`1::Write

  .property instance class Avro.Schema Schema()
  {
    .get instance class Avro.Schema Avro.Generic.DatumWriter`1::get_Schema()
  } // end of property DatumWriter`1::Schema
} // end of class Avro.Generic.DatumWriter`1

.class public auto ansi beforefieldinit Avro.Generic.GenericEnum
       extends [mscorlib]System.Object
{
  .field private string 'value'
  .field private class Avro.EnumSchema '<Schema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.EnumSchema 
          get_Schema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.EnumSchema Avro.Generic.GenericEnum::'<Schema>k__BackingField'
    IL_0006:  ret
  } // end of method GenericEnum::get_Schema

  .method private hidebysig specialname instance void 
          set_Schema(class Avro.EnumSchema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.EnumSchema Avro.Generic.GenericEnum::'<Schema>k__BackingField'
    IL_0007:  ret
  } // end of method GenericEnum::set_Schema

  .method public hidebysig specialname instance string 
          get_Value() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Generic.GenericEnum::'value'
    IL_0006:  ret
  } // end of method GenericEnum::get_Value

  .method public hidebysig specialname instance void 
          set_Value(string 'value') cil managed
  {
    // Code size       78 (0x4e)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool Avro.EnumSchema::Contains(string)
    IL_000c:  brtrue.s   IL_0046

    IL_000e:  ldc.i4.5
    IL_000f:  newarr     [mscorlib]System.Object
    IL_0014:  stloc.0
    IL_0015:  ldloc.0
    IL_0016:  ldc.i4.0
    IL_0017:  ldstr      "Unknown value for enum: "
    IL_001c:  stelem.ref
    IL_001d:  ldloc.0
    IL_001e:  ldc.i4.1
    IL_001f:  ldarg.1
    IL_0020:  stelem.ref
    IL_0021:  ldloc.0
    IL_0022:  ldc.i4.2
    IL_0023:  ldstr      "("
    IL_0028:  stelem.ref
    IL_0029:  ldloc.0
    IL_002a:  ldc.i4.3
    IL_002b:  ldarg.0
    IL_002c:  call       instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_0031:  stelem.ref
    IL_0032:  ldloc.0
    IL_0033:  ldc.i4.4
    IL_0034:  ldstr      ")"
    IL_0039:  stelem.ref
    IL_003a:  ldloc.0
    IL_003b:  call       string [mscorlib]System.String::Concat(object[])
    IL_0040:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0045:  throw

    IL_0046:  ldarg.0
    IL_0047:  ldarg.1
    IL_0048:  stfld      string Avro.Generic.GenericEnum::'value'
    IL_004d:  ret
  } // end of method GenericEnum::set_Value

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.EnumSchema schema,
                               string 'value') cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  call       instance void Avro.Generic.GenericEnum::set_Schema(class Avro.EnumSchema)
    IL_000d:  ldarg.0
    IL_000e:  ldarg.2
    IL_000f:  call       instance void Avro.Generic.GenericEnum::set_Value(string)
    IL_0014:  ret
  } // end of method GenericEnum::.ctor

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       42 (0x2a)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0011

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.Generic.GenericEnum
    IL_000f:  brtrue.s   IL_0013

    IL_0011:  ldc.i4.0
    IL_0012:  ret

    IL_0013:  ldarg.0
    IL_0014:  call       instance string Avro.Generic.GenericEnum::get_Value()
    IL_0019:  ldarg.1
    IL_001a:  isinst     Avro.Generic.GenericEnum
    IL_001f:  callvirt   instance string Avro.Generic.GenericEnum::get_Value()
    IL_0024:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_0029:  ret
  } // end of method GenericEnum::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldc.i4.s   17
    IL_0002:  ldarg.0
    IL_0003:  call       instance string Avro.Generic.GenericEnum::get_Value()
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ret
  } // end of method GenericEnum::GetHashCode

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       48 (0x30)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldc.i4.4
    IL_0001:  newarr     [mscorlib]System.Object
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  ldstr      "Schema: "
    IL_000e:  stelem.ref
    IL_000f:  ldloc.0
    IL_0010:  ldc.i4.1
    IL_0011:  ldarg.0
    IL_0012:  call       instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_0017:  stelem.ref
    IL_0018:  ldloc.0
    IL_0019:  ldc.i4.2
    IL_001a:  ldstr      ", value: "
    IL_001f:  stelem.ref
    IL_0020:  ldloc.0
    IL_0021:  ldc.i4.3
    IL_0022:  ldarg.0
    IL_0023:  call       instance string Avro.Generic.GenericEnum::get_Value()
    IL_0028:  stelem.ref
    IL_0029:  ldloc.0
    IL_002a:  call       string [mscorlib]System.String::Concat(object[])
    IL_002f:  ret
  } // end of method GenericEnum::ToString

  .property instance class Avro.EnumSchema
          Schema()
  {
    .get instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    .set instance void Avro.Generic.GenericEnum::set_Schema(class Avro.EnumSchema)
  } // end of property GenericEnum::Schema
  .property instance string Value()
  {
    .set instance void Avro.Generic.GenericEnum::set_Value(string)
    .get instance string Avro.Generic.GenericEnum::get_Value()
  } // end of property GenericEnum::Value
} // end of class Avro.Generic.GenericEnum

.class public auto ansi beforefieldinit Avro.Generic.GenericFixed
       extends [mscorlib]System.Object
{
  .field family initonly uint8[] 'value'
  .field private class Avro.FixedSchema schema
  .method public hidebysig specialname instance class Avro.FixedSchema 
          get_Schema() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.FixedSchema Avro.Generic.GenericFixed::schema
    IL_0006:  ret
  } // end of method GenericFixed::get_Schema

  .method public hidebysig specialname instance void 
          set_Schema(class Avro.FixedSchema 'value') cil managed
  {
    // Code size       136 (0x88)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  brtrue.s   IL_001e

    IL_0003:  ldstr      "Schema "
    IL_0008:  ldarg.1
    IL_0009:  callvirt   instance string Avro.Schema::get_Name()
    IL_000e:  ldstr      " in set is not FixedSchema"
    IL_0013:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0018:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001d:  throw

    IL_001e:  ldarg.1
    IL_001f:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0024:  ldarg.0
    IL_0025:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_002a:  ldlen
    IL_002b:  conv.i4
    IL_002c:  beq.s      IL_0080

    IL_002e:  ldc.i4.6
    IL_002f:  newarr     [mscorlib]System.Object
    IL_0034:  stloc.0
    IL_0035:  ldloc.0
    IL_0036:  ldc.i4.0
    IL_0037:  ldstr      "Schema "
    IL_003c:  stelem.ref
    IL_003d:  ldloc.0
    IL_003e:  ldc.i4.1
    IL_003f:  ldarg.1
    IL_0040:  callvirt   instance string Avro.Schema::get_Name()
    IL_0045:  stelem.ref
    IL_0046:  ldloc.0
    IL_0047:  ldc.i4.2
    IL_0048:  ldstr      " Size "
    IL_004d:  stelem.ref
    IL_004e:  ldloc.0
    IL_004f:  ldc.i4.3
    IL_0050:  ldarg.1
    IL_0051:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0056:  box        [mscorlib]System.Int32
    IL_005b:  stelem.ref
    IL_005c:  ldloc.0
    IL_005d:  ldc.i4.4
    IL_005e:  ldstr      "is not equal to bytes length "
    IL_0063:  stelem.ref
    IL_0064:  ldloc.0
    IL_0065:  ldc.i4.5
    IL_0066:  ldarg.0
    IL_0067:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_006c:  ldlen
    IL_006d:  conv.i4
    IL_006e:  box        [mscorlib]System.Int32
    IL_0073:  stelem.ref
    IL_0074:  ldloc.0
    IL_0075:  call       string [mscorlib]System.String::Concat(object[])
    IL_007a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_007f:  throw

    IL_0080:  ldarg.0
    IL_0081:  ldarg.1
    IL_0082:  stfld      class Avro.FixedSchema Avro.Generic.GenericFixed::schema
    IL_0087:  ret
  } // end of method GenericFixed::set_Schema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.FixedSchema schema) cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_000d:  newarr     [mscorlib]System.Byte
    IL_0012:  stfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0017:  ldarg.0
    IL_0018:  ldarg.1
    IL_0019:  call       instance void Avro.Generic.GenericFixed::set_Schema(class Avro.FixedSchema)
    IL_001e:  ret
  } // end of method GenericFixed::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.FixedSchema schema,
                               uint8[] 'value') cil managed
  {
    // Code size       38 (0x26)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_000d:  newarr     [mscorlib]System.Byte
    IL_0012:  stfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0017:  ldarg.0
    IL_0018:  ldarg.1
    IL_0019:  call       instance void Avro.Generic.GenericFixed::set_Schema(class Avro.FixedSchema)
    IL_001e:  ldarg.0
    IL_001f:  ldarg.2
    IL_0020:  call       instance void Avro.Generic.GenericFixed::set_Value(uint8[])
    IL_0025:  ret
  } // end of method GenericFixed::.ctor

  .method family hidebysig specialname rtspecialname 
          instance void  .ctor(uint32 size) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  conv.u
    IL_0009:  newarr     [mscorlib]System.Byte
    IL_000e:  stfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0013:  ret
  } // end of method GenericFixed::.ctor

  .method public hidebysig specialname instance uint8[] 
          get_Value() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0006:  ret
  } // end of method GenericFixed::get_Value

  .method public hidebysig specialname instance void 
          set_Value(uint8[] 'value') cil managed
  {
    // Code size       92 (0x5c)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldlen
    IL_0002:  conv.i4
    IL_0003:  ldarg.0
    IL_0004:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0009:  ldlen
    IL_000a:  conv.i4
    IL_000b:  bne.un.s   IL_001d

    IL_000d:  ldarg.1
    IL_000e:  ldarg.0
    IL_000f:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0014:  ldarg.1
    IL_0015:  ldlen
    IL_0016:  conv.i4
    IL_0017:  call       void [mscorlib]System.Array::Copy(class [mscorlib]System.Array,
                                                           class [mscorlib]System.Array,
                                                           int32)
    IL_001c:  ret

    IL_001d:  ldc.i4.5
    IL_001e:  newarr     [mscorlib]System.Object
    IL_0023:  stloc.0
    IL_0024:  ldloc.0
    IL_0025:  ldc.i4.0
    IL_0026:  ldstr      "Invalid length for fixed: "
    IL_002b:  stelem.ref
    IL_002c:  ldloc.0
    IL_002d:  ldc.i4.1
    IL_002e:  ldarg.1
    IL_002f:  ldlen
    IL_0030:  conv.i4
    IL_0031:  box        [mscorlib]System.Int32
    IL_0036:  stelem.ref
    IL_0037:  ldloc.0
    IL_0038:  ldc.i4.2
    IL_0039:  ldstr      ", ("
    IL_003e:  stelem.ref
    IL_003f:  ldloc.0
    IL_0040:  ldc.i4.3
    IL_0041:  ldarg.0
    IL_0042:  call       instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_0047:  stelem.ref
    IL_0048:  ldloc.0
    IL_0049:  ldc.i4.4
    IL_004a:  ldstr      ")"
    IL_004f:  stelem.ref
    IL_0050:  ldloc.0
    IL_0051:  call       string [mscorlib]System.String::Concat(object[])
    IL_0056:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_005b:  throw
  } // end of method GenericFixed::set_Value

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       86 (0x56)
    .maxstack  3
    .locals init (class Avro.Generic.GenericFixed V_0,
             int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0054

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.Generic.GenericFixed
    IL_000f:  brfalse.s  IL_0054

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.Generic.GenericFixed
    IL_0017:  stloc.0
    IL_0018:  ldloc.0
    IL_0019:  callvirt   instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_001e:  ldarg.0
    IL_001f:  call       instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_0054

    IL_002b:  ldc.i4.0
    IL_002c:  stloc.1
    IL_002d:  br.s       IL_0047

    IL_002f:  ldarg.0
    IL_0030:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0035:  ldloc.1
    IL_0036:  ldelem.u1
    IL_0037:  ldloc.0
    IL_0038:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_003d:  ldloc.1
    IL_003e:  ldelem.u1
    IL_003f:  beq.s      IL_0043

    IL_0041:  ldc.i4.0
    IL_0042:  ret

    IL_0043:  ldloc.1
    IL_0044:  ldc.i4.1
    IL_0045:  add
    IL_0046:  stloc.1
    IL_0047:  ldloc.1
    IL_0048:  ldarg.0
    IL_0049:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_004e:  ldlen
    IL_004f:  conv.i4
    IL_0050:  blt.s      IL_002f

    IL_0052:  ldc.i4.1
    IL_0053:  ret

    IL_0054:  ldc.i4.0
    IL_0055:  ret
  } // end of method GenericFixed::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       46 (0x2e)
    .maxstack  3
    .locals init (int32 V_0,
             uint8 V_1,
             uint8[] V_2,
             int32 V_3)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_0006:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  ldfld      uint8[] Avro.Generic.GenericFixed::'value'
    IL_0012:  stloc.2
    IL_0013:  ldc.i4.0
    IL_0014:  stloc.3
    IL_0015:  br.s       IL_0026

    IL_0017:  ldloc.2
    IL_0018:  ldloc.3
    IL_0019:  ldelem.u1
    IL_001a:  stloc.1
    IL_001b:  ldloc.0
    IL_001c:  ldc.i4.s   23
    IL_001e:  ldloc.1
    IL_001f:  mul
    IL_0020:  add
    IL_0021:  stloc.0
    IL_0022:  ldloc.3
    IL_0023:  ldc.i4.1
    IL_0024:  add
    IL_0025:  stloc.3
    IL_0026:  ldloc.3
    IL_0027:  ldloc.2
    IL_0028:  ldlen
    IL_0029:  conv.i4
    IL_002a:  blt.s      IL_0017

    IL_002c:  ldloc.0
    IL_002d:  ret
  } // end of method GenericFixed::GetHashCode

  .property instance class Avro.FixedSchema
          Schema()
  {
    .get instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    .set instance void Avro.Generic.GenericFixed::set_Schema(class Avro.FixedSchema)
  } // end of property GenericFixed::Schema
  .property instance uint8[] Value()
  {
    .get instance uint8[] Avro.Generic.GenericFixed::get_Value()
    .set instance void Avro.Generic.GenericFixed::set_Value(uint8[])
  } // end of property GenericFixed::Value
} // end of class Avro.Generic.GenericFixed

.class public auto ansi sealed Avro.Generic.Reader`1<T>
       extends [mscorlib]System.MulticastDelegate
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(object 'object',
                               native int 'method') runtime managed
  {
  } // end of method Reader`1::.ctor

  .method public hidebysig newslot virtual 
          instance !T  Invoke() runtime managed
  {
  } // end of method Reader`1::Invoke

  .method public hidebysig newslot virtual 
          instance class [mscorlib]System.IAsyncResult 
          BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                      object 'object') runtime managed
  {
  } // end of method Reader`1::BeginInvoke

  .method public hidebysig newslot virtual 
          instance !T  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
  {
  } // end of method Reader`1::EndInvoke

} // end of class Avro.Generic.Reader`1

.class public auto ansi sealed beforefieldinit Avro.Generic.GenericReader`1<T>
       extends [mscorlib]System.Object
       implements class Avro.Generic.DatumReader`1<!T>
{
  .field private initonly class Avro.Generic.DefaultReader reader
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema writerSchema,
                               class Avro.Schema readerSchema) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  newobj     instance void Avro.Generic.DefaultReader::.ctor(class Avro.Schema,
                                                                         class Avro.Schema)
    IL_0008:  call       instance void class Avro.Generic.GenericReader`1<!T>::.ctor(class Avro.Generic.DefaultReader)
    IL_000d:  ret
  } // end of method GenericReader`1::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Generic.DefaultReader reader) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class Avro.Generic.DefaultReader class Avro.Generic.GenericReader`1<!T>::reader
    IL_000d:  ret
  } // end of method GenericReader`1::.ctor

  .method public hidebysig newslot specialname virtual final 
          instance class Avro.Schema  get_WriterSchema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Generic.DefaultReader class Avro.Generic.GenericReader`1<!T>::reader
    IL_0006:  callvirt   instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_000b:  ret
  } // end of method GenericReader`1::get_WriterSchema

  .method public hidebysig newslot specialname virtual final 
          instance class Avro.Schema  get_ReaderSchema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Generic.DefaultReader class Avro.Generic.GenericReader`1<!T>::reader
    IL_0006:  callvirt   instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_000b:  ret
  } // end of method GenericReader`1::get_ReaderSchema

  .method public hidebysig newslot virtual final 
          instance !T  Read(!T reuse,
                            class Avro.IO.Decoder d) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Generic.DefaultReader class Avro.Generic.GenericReader`1<!T>::reader
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance !!0 Avro.Generic.DefaultReader::Read<!T>(!!0,
                                                                           class Avro.IO.Decoder)
    IL_000d:  ret
  } // end of method GenericReader`1::Read

  .property instance class Avro.Schema WriterSchema()
  {
    .get instance class Avro.Schema Avro.Generic.GenericReader`1::get_WriterSchema()
  } // end of property GenericReader`1::WriterSchema
  .property instance class Avro.Schema ReaderSchema()
  {
    .get instance class Avro.Schema Avro.Generic.GenericReader`1::get_ReaderSchema()
  } // end of property GenericReader`1::ReaderSchema
} // end of class Avro.Generic.GenericReader`1

.class public auto ansi beforefieldinit Avro.Generic.DefaultReader
       extends [mscorlib]System.Object
{
  .field private class Avro.Schema '<ReaderSchema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.Schema '<WriterSchema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.Schema 
          get_ReaderSchema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.Generic.DefaultReader::'<ReaderSchema>k__BackingField'
    IL_0006:  ret
  } // end of method DefaultReader::get_ReaderSchema

  .method private hidebysig specialname instance void 
          set_ReaderSchema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.Generic.DefaultReader::'<ReaderSchema>k__BackingField'
    IL_0007:  ret
  } // end of method DefaultReader::set_ReaderSchema

  .method public hidebysig specialname instance class Avro.Schema 
          get_WriterSchema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.Generic.DefaultReader::'<WriterSchema>k__BackingField'
    IL_0006:  ret
  } // end of method DefaultReader::get_WriterSchema

  .method private hidebysig specialname instance void 
          set_WriterSchema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.Generic.DefaultReader::'<WriterSchema>k__BackingField'
    IL_0007:  ret
  } // end of method DefaultReader::set_WriterSchema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema writerSchema,
                               class Avro.Schema readerSchema) cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.2
    IL_0008:  call       instance void Avro.Generic.DefaultReader::set_ReaderSchema(class Avro.Schema)
    IL_000d:  ldarg.0
    IL_000e:  ldarg.1
    IL_000f:  call       instance void Avro.Generic.DefaultReader::set_WriterSchema(class Avro.Schema)
    IL_0014:  ret
  } // end of method DefaultReader::.ctor

  .method public hidebysig instance !!T  Read<T>(!!T reuse,
                                                 class Avro.IO.Decoder decoder) cil managed
  {
    // Code size       103 (0x67)
    .maxstack  5
    .locals init (object[] V_0)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_0006:  ldarg.0
    IL_0007:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_000c:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
    IL_0011:  brtrue.s   IL_0048

    IL_0013:  ldc.i4.4
    IL_0014:  newarr     [mscorlib]System.Object
    IL_0019:  stloc.0
    IL_001a:  ldloc.0
    IL_001b:  ldc.i4.0
    IL_001c:  ldstr      "Schema mismatch. Reader: "
    IL_0021:  stelem.ref
    IL_0022:  ldloc.0
    IL_0023:  ldc.i4.1
    IL_0024:  ldarg.0
    IL_0025:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_002a:  stelem.ref
    IL_002b:  ldloc.0
    IL_002c:  ldc.i4.2
    IL_002d:  ldstr      ", writer: "
    IL_0032:  stelem.ref
    IL_0033:  ldloc.0
    IL_0034:  ldc.i4.3
    IL_0035:  ldarg.0
    IL_0036:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_003b:  stelem.ref
    IL_003c:  ldloc.0
    IL_003d:  call       string [mscorlib]System.String::Concat(object[])
    IL_0042:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0047:  throw

    IL_0048:  ldarg.0
    IL_0049:  ldarg.1
    IL_004a:  box        !!T
    IL_004f:  ldarg.0
    IL_0050:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_0055:  ldarg.0
    IL_0056:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_005b:  ldarg.2
    IL_005c:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0061:  unbox.any  !!T
    IL_0066:  ret
  } // end of method DefaultReader::Read

  .method public hidebysig instance object 
          Read(object reuse,
               class Avro.Schema writerSchema,
               class Avro.Schema readerSchema,
               class Avro.IO.Decoder d) cil managed
  {
    // Code size       583 (0x247)
    .maxstack  5
    .locals init (int32 V_0,
             int64 V_1,
             float32 V_2,
             valuetype Avro.Schema/Type V_3,
             valuetype Avro.Schema/Type V_4,
             valuetype Avro.Schema/Type V_5,
             valuetype Avro.Schema/Type V_6)
    IL_0000:  ldarg.3
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldc.i4.s   12
    IL_0008:  bne.un.s   IL_0022

    IL_000a:  ldarg.2
    IL_000b:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0010:  ldc.i4.s   12
    IL_0012:  beq.s      IL_0022

    IL_0014:  ldarg.3
    IL_0015:  isinst     Avro.UnionSchema
    IL_001a:  ldarg.2
    IL_001b:  call       class Avro.Schema Avro.Generic.DefaultReader::findBranch(class Avro.UnionSchema,
                                                                                  class Avro.Schema)
    IL_0020:  starg.s    readerSchema
    IL_0022:  ldarg.2
    IL_0023:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0028:  stloc.3
    IL_0029:  ldloc.3
    IL_002a:  switch     ( 
                          IL_006c,
                          IL_0076,
                          IL_0097,
                          IL_00f1,
                          IL_013f,
                          IL_0177,
                          IL_01b4,
                          IL_0198,
                          IL_01d0,
                          IL_01e1,
                          IL_0203,
                          IL_0214,
                          IL_0225,
                          IL_01f2)
    IL_0067:  br         IL_0236

    IL_006c:  ldarg.0
    IL_006d:  ldarg.3
    IL_006e:  ldarg.s    d
    IL_0070:  callvirt   instance object Avro.Generic.DefaultReader::ReadNull(class Avro.Schema,
                                                                              class Avro.IO.Decoder)
    IL_0075:  ret

    IL_0076:  ldarg.0
    IL_0077:  ldarg.2
    IL_0078:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_007d:  ldarg.3
    IL_007e:  ldarg.s    d
    IL_0080:  dup
    IL_0081:  ldvirtftn  instance bool Avro.IO.Decoder::ReadBoolean()
    IL_0087:  newobj     instance void class Avro.Generic.Reader`1<bool>::.ctor(object,
                                                                                native int)
    IL_008c:  call       instance !!0 Avro.Generic.DefaultReader::Read<bool>(valuetype Avro.Schema/Type,
                                                                             class Avro.Schema,
                                                                             class Avro.Generic.Reader`1<!!0>)
    IL_0091:  box        [mscorlib]System.Boolean
    IL_0096:  ret

    IL_0097:  ldarg.0
    IL_0098:  ldarg.2
    IL_0099:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_009e:  ldarg.3
    IL_009f:  ldarg.s    d
    IL_00a1:  dup
    IL_00a2:  ldvirtftn  instance int32 Avro.IO.Decoder::ReadInt()
    IL_00a8:  newobj     instance void class Avro.Generic.Reader`1<int32>::.ctor(object,
                                                                                 native int)
    IL_00ad:  call       instance !!0 Avro.Generic.DefaultReader::Read<int32>(valuetype Avro.Schema/Type,
                                                                              class Avro.Schema,
                                                                              class Avro.Generic.Reader`1<!!0>)
    IL_00b2:  stloc.0
    IL_00b3:  ldarg.3
    IL_00b4:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00b9:  stloc.s    V_4
    IL_00bb:  ldloc.s    V_4
    IL_00bd:  ldc.i4.3
    IL_00be:  sub
    IL_00bf:  switch     ( 
                          IL_00d2,
                          IL_00da,
                          IL_00e2)
    IL_00d0:  br.s       IL_00ea

    IL_00d2:  ldloc.0
    IL_00d3:  conv.i8
    IL_00d4:  box        [mscorlib]System.Int64
    IL_00d9:  ret

    IL_00da:  ldloc.0
    IL_00db:  conv.r4
    IL_00dc:  box        [mscorlib]System.Single
    IL_00e1:  ret

    IL_00e2:  ldloc.0
    IL_00e3:  conv.r8
    IL_00e4:  box        [mscorlib]System.Double
    IL_00e9:  ret

    IL_00ea:  ldloc.0
    IL_00eb:  box        [mscorlib]System.Int32
    IL_00f0:  ret

    IL_00f1:  ldarg.0
    IL_00f2:  ldarg.2
    IL_00f3:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00f8:  ldarg.3
    IL_00f9:  ldarg.s    d
    IL_00fb:  dup
    IL_00fc:  ldvirtftn  instance int64 Avro.IO.Decoder::ReadLong()
    IL_0102:  newobj     instance void class Avro.Generic.Reader`1<int64>::.ctor(object,
                                                                                 native int)
    IL_0107:  call       instance !!0 Avro.Generic.DefaultReader::Read<int64>(valuetype Avro.Schema/Type,
                                                                              class Avro.Schema,
                                                                              class Avro.Generic.Reader`1<!!0>)
    IL_010c:  stloc.1
    IL_010d:  ldarg.3
    IL_010e:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0113:  stloc.s    V_5
    IL_0115:  ldloc.s    V_5
    IL_0117:  ldc.i4.4
    IL_0118:  sub
    IL_0119:  switch     ( 
                          IL_0128,
                          IL_0130)
    IL_0126:  br.s       IL_0138

    IL_0128:  ldloc.1
    IL_0129:  conv.r4
    IL_012a:  box        [mscorlib]System.Single
    IL_012f:  ret

    IL_0130:  ldloc.1
    IL_0131:  conv.r8
    IL_0132:  box        [mscorlib]System.Double
    IL_0137:  ret

    IL_0138:  ldloc.1
    IL_0139:  box        [mscorlib]System.Int64
    IL_013e:  ret

    IL_013f:  ldarg.0
    IL_0140:  ldarg.2
    IL_0141:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0146:  ldarg.3
    IL_0147:  ldarg.s    d
    IL_0149:  dup
    IL_014a:  ldvirtftn  instance float32 Avro.IO.Decoder::ReadFloat()
    IL_0150:  newobj     instance void class Avro.Generic.Reader`1<float32>::.ctor(object,
                                                                                   native int)
    IL_0155:  call       instance !!0 Avro.Generic.DefaultReader::Read<float32>(valuetype Avro.Schema/Type,
                                                                                class Avro.Schema,
                                                                                class Avro.Generic.Reader`1<!!0>)
    IL_015a:  stloc.2
    IL_015b:  ldarg.3
    IL_015c:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0161:  stloc.s    V_6
    IL_0163:  ldloc.s    V_6
    IL_0165:  ldc.i4.5
    IL_0166:  bne.un.s   IL_0170

    IL_0168:  ldloc.2
    IL_0169:  conv.r8
    IL_016a:  box        [mscorlib]System.Double
    IL_016f:  ret

    IL_0170:  ldloc.2
    IL_0171:  box        [mscorlib]System.Single
    IL_0176:  ret

    IL_0177:  ldarg.0
    IL_0178:  ldarg.2
    IL_0179:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_017e:  ldarg.3
    IL_017f:  ldarg.s    d
    IL_0181:  dup
    IL_0182:  ldvirtftn  instance float64 Avro.IO.Decoder::ReadDouble()
    IL_0188:  newobj     instance void class Avro.Generic.Reader`1<float64>::.ctor(object,
                                                                                   native int)
    IL_018d:  call       instance !!0 Avro.Generic.DefaultReader::Read<float64>(valuetype Avro.Schema/Type,
                                                                                class Avro.Schema,
                                                                                class Avro.Generic.Reader`1<!!0>)
    IL_0192:  box        [mscorlib]System.Double
    IL_0197:  ret

    IL_0198:  ldarg.0
    IL_0199:  ldarg.2
    IL_019a:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_019f:  ldarg.3
    IL_01a0:  ldarg.s    d
    IL_01a2:  dup
    IL_01a3:  ldvirtftn  instance string Avro.IO.Decoder::ReadString()
    IL_01a9:  newobj     instance void class Avro.Generic.Reader`1<string>::.ctor(object,
                                                                                  native int)
    IL_01ae:  call       instance !!0 Avro.Generic.DefaultReader::Read<string>(valuetype Avro.Schema/Type,
                                                                               class Avro.Schema,
                                                                               class Avro.Generic.Reader`1<!!0>)
    IL_01b3:  ret

    IL_01b4:  ldarg.0
    IL_01b5:  ldarg.2
    IL_01b6:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_01bb:  ldarg.3
    IL_01bc:  ldarg.s    d
    IL_01be:  dup
    IL_01bf:  ldvirtftn  instance uint8[] Avro.IO.Decoder::ReadBytes()
    IL_01c5:  newobj     instance void class Avro.Generic.Reader`1<uint8[]>::.ctor(object,
                                                                                   native int)
    IL_01ca:  call       instance !!0 Avro.Generic.DefaultReader::Read<uint8[]>(valuetype Avro.Schema/Type,
                                                                                class Avro.Schema,
                                                                                class Avro.Generic.Reader`1<!!0>)
    IL_01cf:  ret

    IL_01d0:  ldarg.0
    IL_01d1:  ldarg.1
    IL_01d2:  ldarg.2
    IL_01d3:  castclass  Avro.RecordSchema
    IL_01d8:  ldarg.3
    IL_01d9:  ldarg.s    d
    IL_01db:  callvirt   instance object Avro.Generic.DefaultReader::ReadRecord(object,
                                                                                class Avro.RecordSchema,
                                                                                class Avro.Schema,
                                                                                class Avro.IO.Decoder)
    IL_01e0:  ret

    IL_01e1:  ldarg.0
    IL_01e2:  ldarg.1
    IL_01e3:  ldarg.2
    IL_01e4:  castclass  Avro.EnumSchema
    IL_01e9:  ldarg.3
    IL_01ea:  ldarg.s    d
    IL_01ec:  callvirt   instance object Avro.Generic.DefaultReader::ReadEnum(object,
                                                                              class Avro.EnumSchema,
                                                                              class Avro.Schema,
                                                                              class Avro.IO.Decoder)
    IL_01f1:  ret

    IL_01f2:  ldarg.0
    IL_01f3:  ldarg.1
    IL_01f4:  ldarg.2
    IL_01f5:  castclass  Avro.FixedSchema
    IL_01fa:  ldarg.3
    IL_01fb:  ldarg.s    d
    IL_01fd:  callvirt   instance object Avro.Generic.DefaultReader::ReadFixed(object,
                                                                               class Avro.FixedSchema,
                                                                               class Avro.Schema,
                                                                               class Avro.IO.Decoder)
    IL_0202:  ret

    IL_0203:  ldarg.0
    IL_0204:  ldarg.1
    IL_0205:  ldarg.2
    IL_0206:  castclass  Avro.ArraySchema
    IL_020b:  ldarg.3
    IL_020c:  ldarg.s    d
    IL_020e:  callvirt   instance object Avro.Generic.DefaultReader::ReadArray(object,
                                                                               class Avro.ArraySchema,
                                                                               class Avro.Schema,
                                                                               class Avro.IO.Decoder)
    IL_0213:  ret

    IL_0214:  ldarg.0
    IL_0215:  ldarg.1
    IL_0216:  ldarg.2
    IL_0217:  castclass  Avro.MapSchema
    IL_021c:  ldarg.3
    IL_021d:  ldarg.s    d
    IL_021f:  callvirt   instance object Avro.Generic.DefaultReader::ReadMap(object,
                                                                             class Avro.MapSchema,
                                                                             class Avro.Schema,
                                                                             class Avro.IO.Decoder)
    IL_0224:  ret

    IL_0225:  ldarg.0
    IL_0226:  ldarg.1
    IL_0227:  ldarg.2
    IL_0228:  castclass  Avro.UnionSchema
    IL_022d:  ldarg.3
    IL_022e:  ldarg.s    d
    IL_0230:  callvirt   instance object Avro.Generic.DefaultReader::ReadUnion(object,
                                                                               class Avro.UnionSchema,
                                                                               class Avro.Schema,
                                                                               class Avro.IO.Decoder)
    IL_0235:  ret

    IL_0236:  ldstr      "Unknown schema type: "
    IL_023b:  ldarg.2
    IL_023c:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0241:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0246:  throw
  } // end of method DefaultReader::Read

  .method family hidebysig newslot virtual 
          instance object  ReadNull(class Avro.Schema readerSchema,
                                    class Avro.IO.Decoder d) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.2
    IL_0001:  callvirt   instance void Avro.IO.Decoder::ReadNull()
    IL_0006:  ldnull
    IL_0007:  ret
  } // end of method DefaultReader::ReadNull

  .method family hidebysig instance !!S  Read<S>(valuetype Avro.Schema/Type tag,
                                                 class Avro.Schema readerSchema,
                                                 class Avro.Generic.Reader`1<!!S> reader) cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.3
    IL_0001:  callvirt   instance !0 class Avro.Generic.Reader`1<!!S>::Invoke()
    IL_0006:  ret
  } // end of method DefaultReader::Read

  .method family hidebysig newslot virtual 
          instance object  ReadRecord(object reuse,
                                      class Avro.RecordSchema writerSchema,
                                      class Avro.Schema readerSchema,
                                      class Avro.IO.Decoder dec) cil managed
  {
    // Code size       402 (0x192)
    .maxstack  9
    .locals init (class Avro.RecordSchema V_0,
             object V_1,
             class Avro.Field V_2,
             class Avro.Field V_3,
             object V_4,
             class [mscorlib]System.Exception V_5,
             class [mscorlib]System.IO.MemoryStream V_6,
             class Avro.IO.BinaryEncoder V_7,
             class Avro.IO.BinaryDecoder V_8,
             class Avro.Field V_9,
             object V_10,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_11,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_12)
    IL_0000:  ldarg.3
    IL_0001:  castclass  Avro.RecordSchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance object Avro.Generic.DefaultReader::CreateRecord(object,
                                                                                  class Avro.RecordSchema)
    IL_000f:  stloc.1
    IL_0010:  ldarg.2
    IL_0011:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_0016:  stloc.s    V_11
    .try
    {
      IL_0018:  br         IL_00a8

      IL_001d:  ldloc.s    V_11
      IL_001f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_0024:  stloc.2
      .try
      {
        IL_0025:  ldloc.0
        IL_0026:  ldloc.2
        IL_0027:  ldfld      string Avro.Field::Name
        IL_002c:  ldloca.s   V_3
        IL_002e:  callvirt   instance bool Avro.RecordSchema::TryGetFieldAlias(string,
                                                                               class Avro.Field&)
        IL_0033:  brfalse.s  IL_0079

        IL_0035:  ldnull
        IL_0036:  stloc.s    V_4
        IL_0038:  ldarg.0
        IL_0039:  ldloc.1
        IL_003a:  ldloc.2
        IL_003b:  ldfld      string Avro.Field::Name
        IL_0040:  ldloc.3
        IL_0041:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_0046:  ldloca.s   V_4
        IL_0048:  callvirt   instance bool Avro.Generic.DefaultReader::TryGetField(object,
                                                                                   string,
                                                                                   int32,
                                                                                   object&)
        IL_004d:  pop
        IL_004e:  ldarg.0
        IL_004f:  ldloc.1
        IL_0050:  ldloc.2
        IL_0051:  ldfld      string Avro.Field::Name
        IL_0056:  ldloc.3
        IL_0057:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_005c:  ldarg.0
        IL_005d:  ldloc.s    V_4
        IL_005f:  ldloc.2
        IL_0060:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_0065:  ldloc.3
        IL_0066:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_006b:  ldarg.s    dec
        IL_006d:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                              class Avro.Schema,
                                                                              class Avro.Schema,
                                                                              class Avro.IO.Decoder)
        IL_0072:  callvirt   instance void Avro.Generic.DefaultReader::AddField(object,
                                                                                string,
                                                                                int32,
                                                                                object)
        IL_0077:  br.s       IL_0087

        IL_0079:  ldarg.0
        IL_007a:  ldloc.2
        IL_007b:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_0080:  ldarg.s    dec
        IL_0082:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                            class Avro.IO.Decoder)
        IL_0087:  leave.s    IL_00a8

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0089:  stloc.s    V_5
        IL_008b:  ldloc.s    V_5
        IL_008d:  callvirt   instance string [mscorlib]System.Exception::get_Message()
        IL_0092:  ldstr      " in field "
        IL_0097:  ldloc.2
        IL_0098:  ldfld      string Avro.Field::Name
        IL_009d:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_00a2:  newobj     instance void Avro.AvroException::.ctor(string)
        IL_00a7:  throw

      }  // end handler
      IL_00a8:  ldloc.s    V_11
      IL_00aa:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00af:  brtrue     IL_001d

      IL_00b4:  leave.s    IL_00c2

    }  // end .try
    finally
    {
      IL_00b6:  ldloc.s    V_11
      IL_00b8:  brfalse.s  IL_00c1

      IL_00ba:  ldloc.s    V_11
      IL_00bc:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c1:  endfinally
    }  // end handler
    IL_00c2:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_00c7:  stloc.s    V_6
    IL_00c9:  ldloc.s    V_6
    IL_00cb:  newobj     instance void Avro.IO.BinaryEncoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_00d0:  stloc.s    V_7
    IL_00d2:  ldloc.s    V_6
    IL_00d4:  newobj     instance void Avro.IO.BinaryDecoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_00d9:  stloc.s    V_8
    IL_00db:  ldloc.0
    IL_00dc:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_00e1:  stloc.s    V_12
    .try
    {
      IL_00e3:  br         IL_0176

      IL_00e8:  ldloc.s    V_12
      IL_00ea:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_00ef:  stloc.s    V_9
      IL_00f1:  ldarg.2
      IL_00f2:  ldloc.s    V_9
      IL_00f4:  ldfld      string Avro.Field::Name
      IL_00f9:  callvirt   instance bool Avro.RecordSchema::Contains(string)
      IL_00fe:  brtrue.s   IL_0176

      IL_0100:  ldloc.s    V_6
      IL_0102:  ldc.i4.0
      IL_0103:  conv.i8
      IL_0104:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_0109:  ldloc.s    V_7
      IL_010b:  ldloc.s    V_9
      IL_010d:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_0112:  ldloc.s    V_9
      IL_0114:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
      IL_0119:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                     class Avro.Schema,
                                                                     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_011e:  ldloc.s    V_6
      IL_0120:  callvirt   instance void [mscorlib]System.IO.Stream::Flush()
      IL_0125:  ldloc.s    V_6
      IL_0127:  ldc.i4.0
      IL_0128:  conv.i8
      IL_0129:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_012e:  ldnull
      IL_012f:  stloc.s    V_10
      IL_0131:  ldarg.0
      IL_0132:  ldloc.1
      IL_0133:  ldloc.s    V_9
      IL_0135:  ldfld      string Avro.Field::Name
      IL_013a:  ldloc.s    V_9
      IL_013c:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_0141:  ldloca.s   V_10
      IL_0143:  callvirt   instance bool Avro.Generic.DefaultReader::TryGetField(object,
                                                                                 string,
                                                                                 int32,
                                                                                 object&)
      IL_0148:  pop
      IL_0149:  ldarg.0
      IL_014a:  ldloc.1
      IL_014b:  ldloc.s    V_9
      IL_014d:  ldfld      string Avro.Field::Name
      IL_0152:  ldloc.s    V_9
      IL_0154:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_0159:  ldarg.0
      IL_015a:  ldloc.s    V_10
      IL_015c:  ldloc.s    V_9
      IL_015e:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_0163:  ldloc.s    V_9
      IL_0165:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_016a:  ldloc.s    V_8
      IL_016c:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                            class Avro.Schema,
                                                                            class Avro.Schema,
                                                                            class Avro.IO.Decoder)
      IL_0171:  callvirt   instance void Avro.Generic.DefaultReader::AddField(object,
                                                                              string,
                                                                              int32,
                                                                              object)
      IL_0176:  ldloc.s    V_12
      IL_0178:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_017d:  brtrue     IL_00e8

      IL_0182:  leave.s    IL_0190

    }  // end .try
    finally
    {
      IL_0184:  ldloc.s    V_12
      IL_0186:  brfalse.s  IL_018f

      IL_0188:  ldloc.s    V_12
      IL_018a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_018f:  endfinally
    }  // end handler
    IL_0190:  ldloc.1
    IL_0191:  ret
  } // end of method DefaultReader::ReadRecord

  .method family hidebysig newslot virtual 
          instance object  CreateRecord(object reuse,
                                        class Avro.RecordSchema readerSchema) cil managed
  {
    // Code size       47 (0x2f)
    .maxstack  2
    .locals init (class Avro.Generic.GenericRecord V_0)
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_0026

    IL_0003:  ldarg.1
    IL_0004:  isinst     Avro.Generic.GenericRecord
    IL_0009:  brfalse.s  IL_0026

    IL_000b:  ldarg.1
    IL_000c:  isinst     Avro.Generic.GenericRecord
    IL_0011:  callvirt   instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_0016:  ldarg.2
    IL_0017:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001c:  brfalse.s  IL_0026

    IL_001e:  ldarg.1
    IL_001f:  isinst     Avro.Generic.GenericRecord
    IL_0024:  br.s       IL_002c

    IL_0026:  ldarg.2
    IL_0027:  newobj     instance void Avro.Generic.GenericRecord::.ctor(class Avro.RecordSchema)
    IL_002c:  stloc.0
    IL_002d:  ldloc.0
    IL_002e:  ret
  } // end of method DefaultReader::CreateRecord

  .method family hidebysig newslot virtual 
          instance bool  TryGetField(object 'record',
                                     string fieldName,
                                     int32 fieldPos,
                                     [out] object& 'value') cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.Generic.GenericRecord
    IL_0006:  ldarg.2
    IL_0007:  ldarg.s    'value'
    IL_0009:  callvirt   instance bool Avro.Generic.GenericRecord::TryGetValue(string,
                                                                               object&)
    IL_000e:  ret
  } // end of method DefaultReader::TryGetField

  .method family hidebysig newslot virtual 
          instance void  AddField(object 'record',
                                  string fieldName,
                                  int32 fieldPos,
                                  object fieldValue) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.Generic.GenericRecord
    IL_0006:  ldarg.2
    IL_0007:  ldarg.s    fieldValue
    IL_0009:  callvirt   instance void Avro.Generic.GenericRecord::Add(string,
                                                                       object)
    IL_000e:  ret
  } // end of method DefaultReader::AddField

  .method family hidebysig newslot virtual 
          instance object  ReadEnum(object reuse,
                                    class Avro.EnumSchema writerSchema,
                                    class Avro.Schema readerSchema,
                                    class Avro.IO.Decoder d) cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.3
    IL_0003:  isinst     Avro.EnumSchema
    IL_0008:  ldarg.2
    IL_0009:  ldarg.s    d
    IL_000b:  callvirt   instance int32 Avro.IO.Decoder::ReadEnum()
    IL_0010:  callvirt   instance string Avro.EnumSchema::get_Item(int32)
    IL_0015:  callvirt   instance object Avro.Generic.DefaultReader::CreateEnum(object,
                                                                                class Avro.EnumSchema,
                                                                                string)
    IL_001a:  ret
  } // end of method DefaultReader::ReadEnum

  .method family hidebysig newslot virtual 
          instance object  CreateEnum(object reuse,
                                      class Avro.EnumSchema es,
                                      string symbol) cil managed
  {
    // Code size       46 (0x2e)
    .maxstack  2
    .locals init (class Avro.Generic.GenericEnum V_0)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.Generic.GenericEnum
    IL_0006:  brfalse.s  IL_0026

    IL_0008:  ldarg.1
    IL_0009:  isinst     Avro.Generic.GenericEnum
    IL_000e:  stloc.0
    IL_000f:  ldloc.0
    IL_0010:  callvirt   instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_0015:  ldarg.2
    IL_0016:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001b:  brfalse.s  IL_0026

    IL_001d:  ldloc.0
    IL_001e:  ldarg.3
    IL_001f:  callvirt   instance void Avro.Generic.GenericEnum::set_Value(string)
    IL_0024:  ldloc.0
    IL_0025:  ret

    IL_0026:  ldarg.2
    IL_0027:  ldarg.3
    IL_0028:  newobj     instance void Avro.Generic.GenericEnum::.ctor(class Avro.EnumSchema,
                                                                       string)
    IL_002d:  ret
  } // end of method DefaultReader::CreateEnum

  .method family hidebysig newslot virtual 
          instance object  ReadArray(object reuse,
                                     class Avro.ArraySchema writerSchema,
                                     class Avro.Schema readerSchema,
                                     class Avro.IO.Decoder d) cil managed
  {
    // Code size       141 (0x8d)
    .maxstack  8
    .locals init (class Avro.ArraySchema V_0,
             object V_1,
             int32 V_2,
             int32 V_3,
             int32 V_4)
    IL_0000:  ldarg.3
    IL_0001:  castclass  Avro.ArraySchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance object Avro.Generic.DefaultReader::CreateArray(object,
                                                                                 class Avro.ArraySchema)
    IL_000f:  stloc.1
    IL_0010:  ldc.i4.0
    IL_0011:  stloc.2
    IL_0012:  ldarg.s    d
    IL_0014:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayStart()
    IL_0019:  conv.i4
    IL_001a:  stloc.3
    IL_001b:  br.s       IL_0075

    IL_001d:  ldarg.0
    IL_001e:  ldloc.1
    IL_001f:  callvirt   instance int32 Avro.Generic.DefaultReader::GetArraySize(object)
    IL_0024:  ldloc.2
    IL_0025:  ldloc.3
    IL_0026:  add
    IL_0027:  bge.s      IL_0034

    IL_0029:  ldarg.0
    IL_002a:  ldloca.s   V_1
    IL_002c:  ldloc.2
    IL_002d:  ldloc.3
    IL_002e:  add
    IL_002f:  callvirt   instance void Avro.Generic.DefaultReader::ResizeArray(object&,
                                                                               int32)
    IL_0034:  ldc.i4.0
    IL_0035:  stloc.s    V_4
    IL_0037:  br.s       IL_0067

    IL_0039:  ldarg.0
    IL_003a:  ldloc.1
    IL_003b:  ldloc.2
    IL_003c:  ldarg.0
    IL_003d:  ldarg.0
    IL_003e:  ldloc.1
    IL_003f:  ldloc.2
    IL_0040:  callvirt   instance object Avro.Generic.DefaultReader::GetArrayElement(object,
                                                                                     int32)
    IL_0045:  ldarg.2
    IL_0046:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_004b:  ldloc.0
    IL_004c:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0051:  ldarg.s    d
    IL_0053:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0058:  callvirt   instance void Avro.Generic.DefaultReader::SetArrayElement(object,
                                                                                   int32,
                                                                                   object)
    IL_005d:  ldloc.s    V_4
    IL_005f:  ldc.i4.1
    IL_0060:  add
    IL_0061:  stloc.s    V_4
    IL_0063:  ldloc.2
    IL_0064:  ldc.i4.1
    IL_0065:  add
    IL_0066:  stloc.2
    IL_0067:  ldloc.s    V_4
    IL_0069:  ldloc.3
    IL_006a:  blt.s      IL_0039

    IL_006c:  ldarg.s    d
    IL_006e:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayNext()
    IL_0073:  conv.i4
    IL_0074:  stloc.3
    IL_0075:  ldloc.3
    IL_0076:  brtrue.s   IL_001d

    IL_0078:  ldarg.0
    IL_0079:  ldloc.1
    IL_007a:  callvirt   instance int32 Avro.Generic.DefaultReader::GetArraySize(object)
    IL_007f:  ldloc.2
    IL_0080:  beq.s      IL_008b

    IL_0082:  ldarg.0
    IL_0083:  ldloca.s   V_1
    IL_0085:  ldloc.2
    IL_0086:  callvirt   instance void Avro.Generic.DefaultReader::ResizeArray(object&,
                                                                               int32)
    IL_008b:  ldloc.1
    IL_008c:  ret
  } // end of method DefaultReader::ReadArray

  .method family hidebysig newslot virtual 
          instance object  CreateArray(object reuse,
                                       class Avro.ArraySchema rs) cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.1
    IL_0004:  isinst     object[]
    IL_0009:  brtrue.s   IL_0012

    IL_000b:  ldc.i4.0
    IL_000c:  newarr     [mscorlib]System.Object
    IL_0011:  ret

    IL_0012:  ldarg.1
    IL_0013:  castclass  object[]
    IL_0018:  ret
  } // end of method DefaultReader::CreateArray

  .method family hidebysig newslot virtual 
          instance int32  GetArraySize(object 'array') cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     object[]
    IL_0006:  ldlen
    IL_0007:  conv.i4
    IL_0008:  ret
  } // end of method DefaultReader::GetArraySize

  .method family hidebysig newslot virtual 
          instance void  ResizeArray(object& 'array',
                                     int32 n) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  2
    .locals init (object[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldind.ref
    IL_0002:  isinst     object[]
    IL_0007:  stloc.0
    IL_0008:  ldloca.s   V_0
    IL_000a:  ldarg.2
    IL_000b:  call       void [mscorlib]System.Array::Resize<object>(!!0[]&,
                                                                     int32)
    IL_0010:  ldarg.1
    IL_0011:  ldloc.0
    IL_0012:  stind.ref
    IL_0013:  ret
  } // end of method DefaultReader::ResizeArray

  .method family hidebysig newslot virtual 
          instance void  SetArrayElement(object 'array',
                                         int32 index,
                                         object 'value') cil managed
  {
    // Code size       12 (0xc)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  isinst     object[]
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldarg.2
    IL_0009:  ldarg.3
    IL_000a:  stelem.ref
    IL_000b:  ret
  } // end of method DefaultReader::SetArrayElement

  .method family hidebysig newslot virtual 
          instance object  GetArrayElement(object 'array',
                                           int32 index) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     object[]
    IL_0006:  ldarg.2
    IL_0007:  ldelem.ref
    IL_0008:  ret
  } // end of method DefaultReader::GetArrayElement

  .method family hidebysig newslot virtual 
          instance object  ReadMap(object reuse,
                                   class Avro.MapSchema writerSchema,
                                   class Avro.Schema readerSchema,
                                   class Avro.IO.Decoder d) cil managed
  {
    // Code size       92 (0x5c)
    .maxstack  8
    .locals init (class Avro.MapSchema V_0,
             object V_1,
             int32 V_2,
             int32 V_3,
             string V_4)
    IL_0000:  ldarg.3
    IL_0001:  castclass  Avro.MapSchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance object Avro.Generic.DefaultReader::CreateMap(object,
                                                                               class Avro.MapSchema)
    IL_000f:  stloc.1
    IL_0010:  ldarg.s    d
    IL_0012:  callvirt   instance int64 Avro.IO.Decoder::ReadMapStart()
    IL_0017:  conv.i4
    IL_0018:  stloc.2
    IL_0019:  br.s       IL_0057

    IL_001b:  ldc.i4.0
    IL_001c:  stloc.3
    IL_001d:  br.s       IL_004a

    IL_001f:  ldarg.s    d
    IL_0021:  callvirt   instance string Avro.IO.Decoder::ReadString()
    IL_0026:  stloc.s    V_4
    IL_0028:  ldarg.0
    IL_0029:  ldloc.1
    IL_002a:  ldloc.s    V_4
    IL_002c:  ldarg.0
    IL_002d:  ldnull
    IL_002e:  ldarg.2
    IL_002f:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0034:  ldloc.0
    IL_0035:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_003a:  ldarg.s    d
    IL_003c:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0041:  callvirt   instance void Avro.Generic.DefaultReader::AddMapEntry(object,
                                                                               string,
                                                                               object)
    IL_0046:  ldloc.3
    IL_0047:  ldc.i4.1
    IL_0048:  add
    IL_0049:  stloc.3
    IL_004a:  ldloc.3
    IL_004b:  ldloc.2
    IL_004c:  blt.s      IL_001f

    IL_004e:  ldarg.s    d
    IL_0050:  callvirt   instance int64 Avro.IO.Decoder::ReadMapNext()
    IL_0055:  conv.i4
    IL_0056:  stloc.2
    IL_0057:  ldloc.2
    IL_0058:  brtrue.s   IL_001b

    IL_005a:  ldloc.1
    IL_005b:  ret
  } // end of method DefaultReader::ReadMap

  .method family hidebysig newslot virtual 
          instance object  CreateMap(object reuse,
                                     class Avro.MapSchema ms) cil managed
  {
    // Code size       32 (0x20)
    .maxstack  1
    .locals init (class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> V_0)
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_001a

    IL_0003:  ldarg.1
    IL_0004:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0009:  brfalse.s  IL_001a

    IL_000b:  ldarg.1
    IL_000c:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0011:  stloc.0
    IL_0012:  ldloc.0
    IL_0013:  callvirt   instance void class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::Clear()
    IL_0018:  ldloc.0
    IL_0019:  ret

    IL_001a:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,object>::.ctor()
    IL_001f:  ret
  } // end of method DefaultReader::CreateMap

  .method family hidebysig newslot virtual 
          instance void  AddMapEntry(object map,
                                     string key,
                                     object 'value') cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0006:  ldarg.2
    IL_0007:  ldarg.3
    IL_0008:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>::Add(!0,
                                                                                                                    !1)
    IL_000d:  ret
  } // end of method DefaultReader::AddMapEntry

  .method family hidebysig newslot virtual 
          instance object  ReadUnion(object reuse,
                                     class Avro.UnionSchema writerSchema,
                                     class Avro.Schema readerSchema,
                                     class Avro.IO.Decoder d) cil managed
  {
    // Code size       114 (0x72)
    .maxstack  5
    .locals init (int32 V_0,
             class Avro.Schema V_1,
             object[] V_2)
    IL_0000:  ldarg.s    d
    IL_0002:  callvirt   instance int32 Avro.IO.Decoder::ReadUnionIndex()
    IL_0007:  stloc.0
    IL_0008:  ldarg.2
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_000f:  stloc.1
    IL_0010:  ldarg.3
    IL_0011:  isinst     Avro.UnionSchema
    IL_0016:  brfalse.s  IL_0028

    IL_0018:  ldarg.3
    IL_0019:  isinst     Avro.UnionSchema
    IL_001e:  ldloc.1
    IL_001f:  call       class Avro.Schema Avro.Generic.DefaultReader::findBranch(class Avro.UnionSchema,
                                                                                  class Avro.Schema)
    IL_0024:  starg.s    readerSchema
    IL_0026:  br.s       IL_0066

    IL_0028:  ldarg.3
    IL_0029:  ldloc.1
    IL_002a:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
    IL_002f:  brtrue.s   IL_0066

    IL_0031:  ldc.i4.4
    IL_0032:  newarr     [mscorlib]System.Object
    IL_0037:  stloc.2
    IL_0038:  ldloc.2
    IL_0039:  ldc.i4.0
    IL_003a:  ldstr      "Schema mismatch. Reader: "
    IL_003f:  stelem.ref
    IL_0040:  ldloc.2
    IL_0041:  ldc.i4.1
    IL_0042:  ldarg.0
    IL_0043:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_0048:  stelem.ref
    IL_0049:  ldloc.2
    IL_004a:  ldc.i4.2
    IL_004b:  ldstr      ", writer: "
    IL_0050:  stelem.ref
    IL_0051:  ldloc.2
    IL_0052:  ldc.i4.3
    IL_0053:  ldarg.0
    IL_0054:  call       instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_0059:  stelem.ref
    IL_005a:  ldloc.2
    IL_005b:  call       string [mscorlib]System.String::Concat(object[])
    IL_0060:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0065:  throw

    IL_0066:  ldarg.0
    IL_0067:  ldarg.1
    IL_0068:  ldloc.1
    IL_0069:  ldarg.3
    IL_006a:  ldarg.s    d
    IL_006c:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0071:  ret
  } // end of method DefaultReader::ReadUnion

  .method family hidebysig newslot virtual 
          instance object  ReadFixed(object reuse,
                                     class Avro.FixedSchema writerSchema,
                                     class Avro.Schema readerSchema,
                                     class Avro.IO.Decoder d) cil managed
  {
    // Code size       91 (0x5b)
    .maxstack  3
    .locals init (class Avro.FixedSchema V_0,
             object V_1,
             uint8[] V_2,
             object[] V_3)
    IL_0000:  ldarg.3
    IL_0001:  castclass  Avro.FixedSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_000d:  ldarg.2
    IL_000e:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0013:  beq.s      IL_0040

    IL_0015:  ldc.i4.4
    IL_0016:  newarr     [mscorlib]System.Object
    IL_001b:  stloc.3
    IL_001c:  ldloc.3
    IL_001d:  ldc.i4.0
    IL_001e:  ldstr      "Size mismatch between reader and writer fixed sche"
    + "mas. Writer: "
    IL_0023:  stelem.ref
    IL_0024:  ldloc.3
    IL_0025:  ldc.i4.1
    IL_0026:  ldarg.2
    IL_0027:  stelem.ref
    IL_0028:  ldloc.3
    IL_0029:  ldc.i4.2
    IL_002a:  ldstr      ", reader: "
    IL_002f:  stelem.ref
    IL_0030:  ldloc.3
    IL_0031:  ldc.i4.3
    IL_0032:  ldarg.3
    IL_0033:  stelem.ref
    IL_0034:  ldloc.3
    IL_0035:  call       string [mscorlib]System.String::Concat(object[])
    IL_003a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_003f:  throw

    IL_0040:  ldarg.0
    IL_0041:  ldarg.1
    IL_0042:  ldloc.0
    IL_0043:  callvirt   instance object Avro.Generic.DefaultReader::CreateFixed(object,
                                                                                 class Avro.FixedSchema)
    IL_0048:  stloc.1
    IL_0049:  ldarg.0
    IL_004a:  ldloc.1
    IL_004b:  callvirt   instance uint8[] Avro.Generic.DefaultReader::GetFixedBuffer(object)
    IL_0050:  stloc.2
    IL_0051:  ldarg.s    d
    IL_0053:  ldloc.2
    IL_0054:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
    IL_0059:  ldloc.1
    IL_005a:  ret
  } // end of method DefaultReader::ReadFixed

  .method family hidebysig newslot virtual 
          instance object  CreateFixed(object reuse,
                                       class Avro.FixedSchema rs) cil managed
  {
    // Code size       44 (0x2c)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_001e

    IL_0003:  ldarg.1
    IL_0004:  isinst     Avro.Generic.GenericFixed
    IL_0009:  brfalse.s  IL_001e

    IL_000b:  ldarg.1
    IL_000c:  isinst     Avro.Generic.GenericFixed
    IL_0011:  callvirt   instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_0016:  ldarg.2
    IL_0017:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001c:  brtrue.s   IL_0025

    IL_001e:  ldarg.2
    IL_001f:  newobj     instance void Avro.Generic.GenericFixed::.ctor(class Avro.FixedSchema)
    IL_0024:  ret

    IL_0025:  ldarg.1
    IL_0026:  castclass  Avro.Generic.GenericFixed
    IL_002b:  ret
  } // end of method DefaultReader::CreateFixed

  .method family hidebysig newslot virtual 
          instance uint8[]  GetFixedBuffer(object f) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.Generic.GenericFixed
    IL_0006:  callvirt   instance uint8[] Avro.Generic.GenericFixed::get_Value()
    IL_000b:  ret
  } // end of method DefaultReader::GetFixedBuffer

  .method family hidebysig newslot virtual 
          instance void  Skip(class Avro.Schema writerSchema,
                              class Avro.IO.Decoder d) cil managed
  {
    // Code size       390 (0x186)
    .maxstack  3
    .locals init (class Avro.Field V_0,
             class Avro.Schema V_1,
             int64 V_2,
             int64 V_3,
             class Avro.Schema V_4,
             int64 V_5,
             int64 V_6,
             valuetype Avro.Schema/Type V_7,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_8)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  stloc.s    V_7
    IL_0008:  ldloc.s    V_7
    IL_000a:  switch     ( 
                          IL_004c,
                          IL_0053,
                          IL_005a,
                          IL_0061,
                          IL_0068,
                          IL_006f,
                          IL_007d,
                          IL_0076,
                          IL_0084,
                          IL_00c2,
                          IL_00db,
                          IL_0113,
                          IL_015b,
                          IL_00c9)
    IL_0047:  br         IL_0174

    IL_004c:  ldarg.2
    IL_004d:  callvirt   instance void Avro.IO.Decoder::SkipNull()
    IL_0052:  ret

    IL_0053:  ldarg.2
    IL_0054:  callvirt   instance void Avro.IO.Decoder::SkipBoolean()
    IL_0059:  ret

    IL_005a:  ldarg.2
    IL_005b:  callvirt   instance void Avro.IO.Decoder::SkipInt()
    IL_0060:  ret

    IL_0061:  ldarg.2
    IL_0062:  callvirt   instance void Avro.IO.Decoder::SkipLong()
    IL_0067:  ret

    IL_0068:  ldarg.2
    IL_0069:  callvirt   instance void Avro.IO.Decoder::SkipFloat()
    IL_006e:  ret

    IL_006f:  ldarg.2
    IL_0070:  callvirt   instance void Avro.IO.Decoder::SkipDouble()
    IL_0075:  ret

    IL_0076:  ldarg.2
    IL_0077:  callvirt   instance void Avro.IO.Decoder::SkipString()
    IL_007c:  ret

    IL_007d:  ldarg.2
    IL_007e:  callvirt   instance void Avro.IO.Decoder::SkipBytes()
    IL_0083:  ret

    IL_0084:  ldarg.1
    IL_0085:  isinst     Avro.RecordSchema
    IL_008a:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_008f:  stloc.s    V_8
    .try
    {
      IL_0091:  br.s       IL_00a8

      IL_0093:  ldloc.s    V_8
      IL_0095:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_009a:  stloc.0
      IL_009b:  ldarg.0
      IL_009c:  ldloc.0
      IL_009d:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_00a2:  ldarg.2
      IL_00a3:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                          class Avro.IO.Decoder)
      IL_00a8:  ldloc.s    V_8
      IL_00aa:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00af:  brtrue.s   IL_0093

      IL_00b1:  leave      IL_0185

    }  // end .try
    finally
    {
      IL_00b6:  ldloc.s    V_8
      IL_00b8:  brfalse.s  IL_00c1

      IL_00ba:  ldloc.s    V_8
      IL_00bc:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c1:  endfinally
    }  // end handler
    IL_00c2:  ldarg.2
    IL_00c3:  callvirt   instance void Avro.IO.Decoder::SkipEnum()
    IL_00c8:  ret

    IL_00c9:  ldarg.2
    IL_00ca:  ldarg.1
    IL_00cb:  isinst     Avro.FixedSchema
    IL_00d0:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_00d5:  callvirt   instance void Avro.IO.Decoder::SkipFixed(int32)
    IL_00da:  ret

    IL_00db:  ldarg.1
    IL_00dc:  isinst     Avro.ArraySchema
    IL_00e1:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_00e6:  stloc.1
    IL_00e7:  ldarg.2
    IL_00e8:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayStart()
    IL_00ed:  stloc.2
    IL_00ee:  br.s       IL_010d

    IL_00f0:  ldc.i4.0
    IL_00f1:  conv.i8
    IL_00f2:  stloc.3
    IL_00f3:  br.s       IL_0102

    IL_00f5:  ldarg.0
    IL_00f6:  ldloc.1
    IL_00f7:  ldarg.2
    IL_00f8:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                        class Avro.IO.Decoder)
    IL_00fd:  ldloc.3
    IL_00fe:  ldc.i4.1
    IL_00ff:  conv.i8
    IL_0100:  add
    IL_0101:  stloc.3
    IL_0102:  ldloc.3
    IL_0103:  ldloc.2
    IL_0104:  blt.s      IL_00f5

    IL_0106:  ldarg.2
    IL_0107:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayNext()
    IL_010c:  stloc.2
    IL_010d:  ldloc.2
    IL_010e:  ldc.i4.0
    IL_010f:  conv.i8
    IL_0110:  bne.un.s   IL_00f0

    IL_0112:  ret

    IL_0113:  ldarg.1
    IL_0114:  isinst     Avro.MapSchema
    IL_0119:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_011e:  stloc.s    V_4
    IL_0120:  ldarg.2
    IL_0121:  callvirt   instance int64 Avro.IO.Decoder::ReadMapStart()
    IL_0126:  stloc.s    V_5
    IL_0128:  br.s       IL_0154

    IL_012a:  ldc.i4.0
    IL_012b:  conv.i8
    IL_012c:  stloc.s    V_6
    IL_012e:  br.s       IL_0146

    IL_0130:  ldarg.2
    IL_0131:  callvirt   instance void Avro.IO.Decoder::SkipString()
    IL_0136:  ldarg.0
    IL_0137:  ldloc.s    V_4
    IL_0139:  ldarg.2
    IL_013a:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                        class Avro.IO.Decoder)
    IL_013f:  ldloc.s    V_6
    IL_0141:  ldc.i4.1
    IL_0142:  conv.i8
    IL_0143:  add
    IL_0144:  stloc.s    V_6
    IL_0146:  ldloc.s    V_6
    IL_0148:  ldloc.s    V_5
    IL_014a:  blt.s      IL_0130

    IL_014c:  ldarg.2
    IL_014d:  callvirt   instance int64 Avro.IO.Decoder::ReadMapNext()
    IL_0152:  stloc.s    V_5
    IL_0154:  ldloc.s    V_5
    IL_0156:  ldc.i4.0
    IL_0157:  conv.i8
    IL_0158:  bne.un.s   IL_012a

    IL_015a:  ret

    IL_015b:  ldarg.0
    IL_015c:  ldarg.1
    IL_015d:  isinst     Avro.UnionSchema
    IL_0162:  ldarg.2
    IL_0163:  callvirt   instance int32 Avro.IO.Decoder::ReadUnionIndex()
    IL_0168:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_016d:  ldarg.2
    IL_016e:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                        class Avro.IO.Decoder)
    IL_0173:  ret

    IL_0174:  ldstr      "Unknown schema type: "
    IL_0179:  ldarg.1
    IL_017a:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_017f:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0184:  throw

    IL_0185:  ret
  } // end of method DefaultReader::Skip

  .method family hidebysig static class Avro.Schema 
          findBranch(class Avro.UnionSchema us,
                     class Avro.Schema s) cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  3
    .locals init (int32 V_0,
             object[] V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance int32 Avro.UnionSchema::MatchingBranch(class Avro.Schema)
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  ldc.i4.0
    IL_000a:  blt.s      IL_0014

    IL_000c:  ldarg.0
    IL_000d:  ldloc.0
    IL_000e:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_0013:  ret

    IL_0014:  ldc.i4.4
    IL_0015:  newarr     [mscorlib]System.Object
    IL_001a:  stloc.1
    IL_001b:  ldloc.1
    IL_001c:  ldc.i4.0
    IL_001d:  ldstr      "No matching schema for "
    IL_0022:  stelem.ref
    IL_0023:  ldloc.1
    IL_0024:  ldc.i4.1
    IL_0025:  ldarg.1
    IL_0026:  stelem.ref
    IL_0027:  ldloc.1
    IL_0028:  ldc.i4.2
    IL_0029:  ldstr      " in "
    IL_002e:  stelem.ref
    IL_002f:  ldloc.1
    IL_0030:  ldc.i4.3
    IL_0031:  ldarg.0
    IL_0032:  stelem.ref
    IL_0033:  ldloc.1
    IL_0034:  call       string [mscorlib]System.String::Concat(object[])
    IL_0039:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_003e:  throw
  } // end of method DefaultReader::findBranch

  .property instance class Avro.Schema ReaderSchema()
  {
    .get instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    .set instance void Avro.Generic.DefaultReader::set_ReaderSchema(class Avro.Schema)
  } // end of property DefaultReader::ReaderSchema
  .property instance class Avro.Schema WriterSchema()
  {
    .get instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    .set instance void Avro.Generic.DefaultReader::set_WriterSchema(class Avro.Schema)
  } // end of property DefaultReader::WriterSchema
} // end of class Avro.Generic.DefaultReader

.class public auto ansi beforefieldinit Avro.Generic.GenericRecord
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = ( 01 00 04 49 74 65 6D 00 00 )                      // ...Item..
  .field private class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> contents
  .field private class Avro.RecordSchema '<Schema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.RecordSchema 
          get_Schema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.RecordSchema Avro.Generic.GenericRecord::'<Schema>k__BackingField'
    IL_0006:  ret
  } // end of method GenericRecord::get_Schema

  .method private hidebysig specialname instance void 
          set_Schema(class Avro.RecordSchema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.RecordSchema Avro.Generic.GenericRecord::'<Schema>k__BackingField'
    IL_0007:  ret
  } // end of method GenericRecord::set_Schema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.RecordSchema schema) cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,object>::.ctor()
    IL_0006:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_000b:  ldarg.0
    IL_000c:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0011:  ldarg.0
    IL_0012:  ldarg.1
    IL_0013:  call       instance void Avro.Generic.GenericRecord::set_Schema(class Avro.RecordSchema)
    IL_0018:  ret
  } // end of method GenericRecord::.ctor

  .method public hidebysig specialname instance object 
          get_Item(string fieldName) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>::get_Item(!0)
    IL_000c:  ret
  } // end of method GenericRecord::get_Item

  .method public hidebysig instance void 
          Add(string fieldName,
              object fieldValue) cil managed
  {
    // Code size       45 (0x2d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool Avro.RecordSchema::Contains(string)
    IL_000c:  brfalse.s  IL_001c

    IL_000e:  ldarg.0
    IL_000f:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0014:  ldarg.1
    IL_0015:  ldarg.2
    IL_0016:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>::set_Item(!0,
                                                                                                                         !1)
    IL_001b:  ret

    IL_001c:  ldstr      "No such field: "
    IL_0021:  ldarg.1
    IL_0022:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0027:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_002c:  throw
  } // end of method GenericRecord::Add

  .method public hidebysig instance bool 
          TryGetValue(string fieldName,
                      [out] object& result) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>::TryGetValue(!0,
                                                                                                                            !1&)
    IL_000d:  ret
  } // end of method GenericRecord::TryGetValue

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       65 (0x41)
    .maxstack  2
    .locals init (class Avro.Generic.GenericRecord V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_003f

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.Generic.GenericRecord
    IL_000f:  brfalse.s  IL_003f

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.Generic.GenericRecord
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_003d

    IL_002b:  ldarg.0
    IL_002c:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0031:  ldloc.0
    IL_0032:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0037:  call       bool Avro.Generic.GenericRecord::areEqual(class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>,
                                                                   class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>)
    IL_003c:  ret

    IL_003d:  ldc.i4.0
    IL_003e:  ret

    IL_003f:  ldc.i4.0
    IL_0040:  ret
  } // end of method GenericRecord::Equals

  .method private hidebysig static bool  areEqual(class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> d1,
                                                  class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> d2) cil managed
  {
    // Code size       96 (0x60)
    .maxstack  3
    .locals init (valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object> V_0,
             object V_1,
             bool V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>> V_3)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Count()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Count()
    IL_000c:  bne.un.s   IL_005c

    IL_000e:  ldarg.0
    IL_000f:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::GetEnumerator()
    IL_0014:  stloc.3
    .try
    {
      IL_0015:  br.s       IL_0046

      IL_0017:  ldloc.3
      IL_0018:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Current()
      IL_001d:  stloc.0
      IL_001e:  ldarg.1
      IL_001f:  ldloca.s   V_0
      IL_0021:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Key()
      IL_0026:  ldloca.s   V_1
      IL_0028:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>::TryGetValue(!0,
                                                                                                                              !1&)
      IL_002d:  brtrue.s   IL_0033

      IL_002f:  ldc.i4.0
      IL_0030:  stloc.2
      IL_0031:  leave.s    IL_005e

      IL_0033:  ldloc.1
      IL_0034:  ldloca.s   V_0
      IL_0036:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Value()
      IL_003b:  call       bool Avro.Generic.GenericRecord::areEqual(object,
                                                                     object)
      IL_0040:  brtrue.s   IL_0046

      IL_0042:  ldc.i4.0
      IL_0043:  stloc.2
      IL_0044:  leave.s    IL_005e

      IL_0046:  ldloc.3
      IL_0047:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_004c:  brtrue.s   IL_0017

      IL_004e:  leave.s    IL_005a

    }  // end .try
    finally
    {
      IL_0050:  ldloc.3
      IL_0051:  brfalse.s  IL_0059

      IL_0053:  ldloc.3
      IL_0054:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0059:  endfinally
    }  // end handler
    IL_005a:  ldc.i4.1
    IL_005b:  ret

    IL_005c:  ldc.i4.0
    IL_005d:  ret

    IL_005e:  ldloc.2
    IL_005f:  ret
  } // end of method GenericRecord::areEqual

  .method private hidebysig static bool  areEqual(object o1,
                                                  object o2) cil managed
  {
    // Code size       93 (0x5d)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0008

    IL_0003:  ldarg.1
    IL_0004:  ldnull
    IL_0005:  ceq
    IL_0007:  ret

    IL_0008:  ldarg.1
    IL_0009:  brtrue.s   IL_000d

    IL_000b:  ldc.i4.0
    IL_000c:  ret

    IL_000d:  ldarg.0
    IL_000e:  isinst     [mscorlib]System.Array
    IL_0013:  brfalse.s  IL_0031

    IL_0015:  ldarg.1
    IL_0016:  isinst     [mscorlib]System.Array
    IL_001b:  brtrue.s   IL_001f

    IL_001d:  ldc.i4.0
    IL_001e:  ret

    IL_001f:  ldarg.0
    IL_0020:  isinst     [mscorlib]System.Array
    IL_0025:  ldarg.0
    IL_0026:  isinst     [mscorlib]System.Array
    IL_002b:  call       bool Avro.Generic.GenericRecord::areEqual(class [mscorlib]System.Array,
                                                                   class [mscorlib]System.Array)
    IL_0030:  ret

    IL_0031:  ldarg.0
    IL_0032:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0037:  brfalse.s  IL_0055

    IL_0039:  ldarg.1
    IL_003a:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_003f:  brtrue.s   IL_0043

    IL_0041:  ldc.i4.0
    IL_0042:  ret

    IL_0043:  ldarg.0
    IL_0044:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0049:  ldarg.0
    IL_004a:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_004f:  call       bool Avro.Generic.GenericRecord::areEqual(class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>,
                                                                   class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>)
    IL_0054:  ret

    IL_0055:  ldarg.0
    IL_0056:  ldarg.1
    IL_0057:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_005c:  ret
  } // end of method GenericRecord::areEqual

  .method private hidebysig static bool  areEqual(class [mscorlib]System.Array a1,
                                                  class [mscorlib]System.Array a2) cil managed
  {
    // Code size       58 (0x3a)
    .maxstack  3
    .locals init (int32 V_0)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance int32 [mscorlib]System.Array::get_Length()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance int32 [mscorlib]System.Array::get_Length()
    IL_000c:  beq.s      IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldc.i4.0
    IL_0011:  stloc.0
    IL_0012:  br.s       IL_002f

    IL_0014:  ldarg.0
    IL_0015:  ldloc.0
    IL_0016:  callvirt   instance object [mscorlib]System.Array::GetValue(int32)
    IL_001b:  ldarg.1
    IL_001c:  ldloc.0
    IL_001d:  callvirt   instance object [mscorlib]System.Array::GetValue(int32)
    IL_0022:  call       bool Avro.Generic.GenericRecord::areEqual(object,
                                                                   object)
    IL_0027:  brtrue.s   IL_002b

    IL_0029:  ldc.i4.0
    IL_002a:  ret

    IL_002b:  ldloc.0
    IL_002c:  ldc.i4.1
    IL_002d:  add
    IL_002e:  stloc.0
    IL_002f:  ldloc.0
    IL_0030:  ldarg.0
    IL_0031:  callvirt   instance int32 [mscorlib]System.Array::get_Length()
    IL_0036:  blt.s      IL_0014

    IL_0038:  ldc.i4.1
    IL_0039:  ret
  } // end of method GenericRecord::areEqual

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldc.i4.s   31
    IL_0002:  ldarg.0
    IL_0003:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ret
  } // end of method GenericRecord::GetHashCode

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       167 (0xa7)
    .maxstack  2
    .locals init (class [mscorlib]System.Text.StringBuilder V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object> V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>> V_2)
    IL_0000:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldstr      "Schema: "
    IL_000c:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0011:  pop
    IL_0012:  ldloc.0
    IL_0013:  ldarg.0
    IL_0014:  call       instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_0019:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(object)
    IL_001e:  pop
    IL_001f:  ldloc.0
    IL_0020:  ldstr      ", contents: "
    IL_0025:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_002a:  pop
    IL_002b:  ldloc.0
    IL_002c:  ldstr      "{ "
    IL_0031:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0036:  pop
    IL_0037:  ldarg.0
    IL_0038:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> Avro.Generic.GenericRecord::contents
    IL_003d:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::GetEnumerator()
    IL_0042:  stloc.2
    .try
    {
      IL_0043:  br.s       IL_0080

      IL_0045:  ldloc.2
      IL_0046:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Current()
      IL_004b:  stloc.1
      IL_004c:  ldloc.0
      IL_004d:  ldloca.s   V_1
      IL_004f:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Key()
      IL_0054:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0059:  pop
      IL_005a:  ldloc.0
      IL_005b:  ldstr      ": "
      IL_0060:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0065:  pop
      IL_0066:  ldloc.0
      IL_0067:  ldloca.s   V_1
      IL_0069:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Value()
      IL_006e:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(object)
      IL_0073:  pop
      IL_0074:  ldloc.0
      IL_0075:  ldstr      ", "
      IL_007a:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_007f:  pop
      IL_0080:  ldloc.2
      IL_0081:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0086:  brtrue.s   IL_0045

      IL_0088:  leave.s    IL_0094

    }  // end .try
    finally
    {
      IL_008a:  ldloc.2
      IL_008b:  brfalse.s  IL_0093

      IL_008d:  ldloc.2
      IL_008e:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0093:  endfinally
    }  // end handler
    IL_0094:  ldloc.0
    IL_0095:  ldstr      "}"
    IL_009a:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_009f:  pop
    IL_00a0:  ldloc.0
    IL_00a1:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00a6:  ret
  } // end of method GenericRecord::ToString

  .property instance class Avro.RecordSchema
          Schema()
  {
    .get instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    .set instance void Avro.Generic.GenericRecord::set_Schema(class Avro.RecordSchema)
  } // end of property GenericRecord::Schema
  .property instance object Item(string)
  {
    .get instance object Avro.Generic.GenericRecord::get_Item(string)
  } // end of property GenericRecord::Item
} // end of class Avro.Generic.GenericRecord

.class public auto ansi sealed Avro.Generic.Writer`1<T>
       extends [mscorlib]System.MulticastDelegate
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(object 'object',
                               native int 'method') runtime managed
  {
  } // end of method Writer`1::.ctor

  .method public hidebysig newslot virtual 
          instance void  Invoke(!T t) runtime managed
  {
  } // end of method Writer`1::Invoke

  .method public hidebysig newslot virtual 
          instance class [mscorlib]System.IAsyncResult 
          BeginInvoke(!T t,
                      class [mscorlib]System.AsyncCallback callback,
                      object 'object') runtime managed
  {
  } // end of method Writer`1::BeginInvoke

  .method public hidebysig newslot virtual 
          instance void  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
  {
  } // end of method Writer`1::EndInvoke

} // end of class Avro.Generic.Writer`1

.class public auto ansi beforefieldinit Avro.Generic.GenericWriter`1<T>
       extends [mscorlib]System.Object
       implements class Avro.Generic.DatumWriter`1<!T>
{
  .field private initonly class Avro.Generic.DefaultWriter writer
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema schema) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  newobj     instance void Avro.Generic.DefaultWriter::.ctor(class Avro.Schema)
    IL_0007:  call       instance void class Avro.Generic.GenericWriter`1<!T>::.ctor(class Avro.Generic.DefaultWriter)
    IL_000c:  ret
  } // end of method GenericWriter`1::.ctor

  .method public hidebysig newslot specialname virtual final 
          instance class Avro.Schema  get_Schema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Generic.DefaultWriter class Avro.Generic.GenericWriter`1<!T>::writer
    IL_0006:  callvirt   instance class Avro.Schema Avro.Generic.DefaultWriter::get_Schema()
    IL_000b:  ret
  } // end of method GenericWriter`1::get_Schema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Generic.DefaultWriter writer) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class Avro.Generic.DefaultWriter class Avro.Generic.GenericWriter`1<!T>::writer
    IL_000d:  ret
  } // end of method GenericWriter`1::.ctor

  .method public hidebysig newslot virtual final 
          instance void  Write(!T 'value',
                               class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Generic.DefaultWriter class Avro.Generic.GenericWriter`1<!T>::writer
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance void Avro.Generic.DefaultWriter::Write<!T>(!!0,
                                                                             class Avro.IO.Encoder)
    IL_000d:  ret
  } // end of method GenericWriter`1::Write

  .property instance class Avro.Schema Schema()
  {
    .get instance class Avro.Schema Avro.Generic.GenericWriter`1::get_Schema()
  } // end of property GenericWriter`1::Schema
} // end of class Avro.Generic.GenericWriter`1

.class public auto ansi beforefieldinit Avro.Generic.DefaultWriter
       extends [mscorlib]System.Object
{
  .field private class Avro.Schema '<Schema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.Schema 
          get_Schema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.Generic.DefaultWriter::'<Schema>k__BackingField'
    IL_0006:  ret
  } // end of method DefaultWriter::get_Schema

  .method private hidebysig specialname instance void 
          set_Schema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.Generic.DefaultWriter::'<Schema>k__BackingField'
    IL_0007:  ret
  } // end of method DefaultWriter::set_Schema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema schema) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  call       instance void Avro.Generic.DefaultWriter::set_Schema(class Avro.Schema)
    IL_000d:  ret
  } // end of method DefaultWriter::.ctor

  .method public hidebysig instance void 
          Write<T>(!!T 'value',
                   class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.0
    IL_0002:  call       instance class Avro.Schema Avro.Generic.DefaultWriter::get_Schema()
    IL_0007:  ldarg.1
    IL_0008:  box        !!T
    IL_000d:  ldarg.2
    IL_000e:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                         object,
                                                                         class Avro.IO.Encoder)
    IL_0013:  ret
  } // end of method DefaultWriter::Write

  .method public hidebysig newslot virtual 
          instance void  Write(class Avro.Schema schema,
                               object 'value',
                               class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       371 (0x173)
    .maxstack  5
    .locals init (valuetype Avro.Schema/Type V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  switch     ( 
                          IL_004a,
                          IL_0053,
                          IL_006e,
                          IL_0089,
                          IL_00a4,
                          IL_00bf,
                          IL_00f5,
                          IL_00da,
                          IL_0110,
                          IL_011f,
                          IL_013d,
                          IL_014c,
                          IL_015b,
                          IL_012e)
    IL_0045:  br         IL_016a

    IL_004a:  ldarg.0
    IL_004b:  ldarg.2
    IL_004c:  ldarg.3
    IL_004d:  callvirt   instance void Avro.Generic.DefaultWriter::WriteNull(object,
                                                                             class Avro.IO.Encoder)
    IL_0052:  ret

    IL_0053:  ldarg.0
    IL_0054:  ldarg.2
    IL_0055:  ldarg.1
    IL_0056:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_005b:  ldarg.3
    IL_005c:  dup
    IL_005d:  ldvirtftn  instance void Avro.IO.Encoder::WriteBoolean(bool)
    IL_0063:  newobj     instance void class Avro.Generic.Writer`1<bool>::.ctor(object,
                                                                                native int)
    IL_0068:  callvirt   instance void Avro.Generic.DefaultWriter::Write<bool>(object,
                                                                               valuetype Avro.Schema/Type,
                                                                               class Avro.Generic.Writer`1<!!0>)
    IL_006d:  ret

    IL_006e:  ldarg.0
    IL_006f:  ldarg.2
    IL_0070:  ldarg.1
    IL_0071:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0076:  ldarg.3
    IL_0077:  dup
    IL_0078:  ldvirtftn  instance void Avro.IO.Encoder::WriteInt(int32)
    IL_007e:  newobj     instance void class Avro.Generic.Writer`1<int32>::.ctor(object,
                                                                                 native int)
    IL_0083:  callvirt   instance void Avro.Generic.DefaultWriter::Write<int32>(object,
                                                                                valuetype Avro.Schema/Type,
                                                                                class Avro.Generic.Writer`1<!!0>)
    IL_0088:  ret

    IL_0089:  ldarg.0
    IL_008a:  ldarg.2
    IL_008b:  ldarg.1
    IL_008c:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0091:  ldarg.3
    IL_0092:  dup
    IL_0093:  ldvirtftn  instance void Avro.IO.Encoder::WriteLong(int64)
    IL_0099:  newobj     instance void class Avro.Generic.Writer`1<int64>::.ctor(object,
                                                                                 native int)
    IL_009e:  callvirt   instance void Avro.Generic.DefaultWriter::Write<int64>(object,
                                                                                valuetype Avro.Schema/Type,
                                                                                class Avro.Generic.Writer`1<!!0>)
    IL_00a3:  ret

    IL_00a4:  ldarg.0
    IL_00a5:  ldarg.2
    IL_00a6:  ldarg.1
    IL_00a7:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00ac:  ldarg.3
    IL_00ad:  dup
    IL_00ae:  ldvirtftn  instance void Avro.IO.Encoder::WriteFloat(float32)
    IL_00b4:  newobj     instance void class Avro.Generic.Writer`1<float32>::.ctor(object,
                                                                                   native int)
    IL_00b9:  callvirt   instance void Avro.Generic.DefaultWriter::Write<float32>(object,
                                                                                  valuetype Avro.Schema/Type,
                                                                                  class Avro.Generic.Writer`1<!!0>)
    IL_00be:  ret

    IL_00bf:  ldarg.0
    IL_00c0:  ldarg.2
    IL_00c1:  ldarg.1
    IL_00c2:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00c7:  ldarg.3
    IL_00c8:  dup
    IL_00c9:  ldvirtftn  instance void Avro.IO.Encoder::WriteDouble(float64)
    IL_00cf:  newobj     instance void class Avro.Generic.Writer`1<float64>::.ctor(object,
                                                                                   native int)
    IL_00d4:  callvirt   instance void Avro.Generic.DefaultWriter::Write<float64>(object,
                                                                                  valuetype Avro.Schema/Type,
                                                                                  class Avro.Generic.Writer`1<!!0>)
    IL_00d9:  ret

    IL_00da:  ldarg.0
    IL_00db:  ldarg.2
    IL_00dc:  ldarg.1
    IL_00dd:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00e2:  ldarg.3
    IL_00e3:  dup
    IL_00e4:  ldvirtftn  instance void Avro.IO.Encoder::WriteString(string)
    IL_00ea:  newobj     instance void class Avro.Generic.Writer`1<string>::.ctor(object,
                                                                                  native int)
    IL_00ef:  callvirt   instance void Avro.Generic.DefaultWriter::Write<string>(object,
                                                                                 valuetype Avro.Schema/Type,
                                                                                 class Avro.Generic.Writer`1<!!0>)
    IL_00f4:  ret

    IL_00f5:  ldarg.0
    IL_00f6:  ldarg.2
    IL_00f7:  ldarg.1
    IL_00f8:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00fd:  ldarg.3
    IL_00fe:  dup
    IL_00ff:  ldvirtftn  instance void Avro.IO.Encoder::WriteBytes(uint8[])
    IL_0105:  newobj     instance void class Avro.Generic.Writer`1<uint8[]>::.ctor(object,
                                                                                   native int)
    IL_010a:  callvirt   instance void Avro.Generic.DefaultWriter::Write<uint8[]>(object,
                                                                                  valuetype Avro.Schema/Type,
                                                                                  class Avro.Generic.Writer`1<!!0>)
    IL_010f:  ret

    IL_0110:  ldarg.0
    IL_0111:  ldarg.1
    IL_0112:  isinst     Avro.RecordSchema
    IL_0117:  ldarg.2
    IL_0118:  ldarg.3
    IL_0119:  callvirt   instance void Avro.Generic.DefaultWriter::WriteRecord(class Avro.RecordSchema,
                                                                               object,
                                                                               class Avro.IO.Encoder)
    IL_011e:  ret

    IL_011f:  ldarg.0
    IL_0120:  ldarg.1
    IL_0121:  isinst     Avro.EnumSchema
    IL_0126:  ldarg.2
    IL_0127:  ldarg.3
    IL_0128:  callvirt   instance void Avro.Generic.DefaultWriter::WriteEnum(class Avro.EnumSchema,
                                                                             object,
                                                                             class Avro.IO.Encoder)
    IL_012d:  ret

    IL_012e:  ldarg.0
    IL_012f:  ldarg.1
    IL_0130:  isinst     Avro.FixedSchema
    IL_0135:  ldarg.2
    IL_0136:  ldarg.3
    IL_0137:  callvirt   instance void Avro.Generic.DefaultWriter::WriteFixed(class Avro.FixedSchema,
                                                                              object,
                                                                              class Avro.IO.Encoder)
    IL_013c:  ret

    IL_013d:  ldarg.0
    IL_013e:  ldarg.1
    IL_013f:  isinst     Avro.ArraySchema
    IL_0144:  ldarg.2
    IL_0145:  ldarg.3
    IL_0146:  callvirt   instance void Avro.Generic.DefaultWriter::WriteArray(class Avro.ArraySchema,
                                                                              object,
                                                                              class Avro.IO.Encoder)
    IL_014b:  ret

    IL_014c:  ldarg.0
    IL_014d:  ldarg.1
    IL_014e:  isinst     Avro.MapSchema
    IL_0153:  ldarg.2
    IL_0154:  ldarg.3
    IL_0155:  callvirt   instance void Avro.Generic.DefaultWriter::WriteMap(class Avro.MapSchema,
                                                                            object,
                                                                            class Avro.IO.Encoder)
    IL_015a:  ret

    IL_015b:  ldarg.0
    IL_015c:  ldarg.1
    IL_015d:  isinst     Avro.UnionSchema
    IL_0162:  ldarg.2
    IL_0163:  ldarg.3
    IL_0164:  callvirt   instance void Avro.Generic.DefaultWriter::WriteUnion(class Avro.UnionSchema,
                                                                              object,
                                                                              class Avro.IO.Encoder)
    IL_0169:  ret

    IL_016a:  ldarg.0
    IL_016b:  ldarg.1
    IL_016c:  ldarg.2
    IL_016d:  call       instance void Avro.Generic.DefaultWriter::'error'(class Avro.Schema,
                                                                           object)
    IL_0172:  ret
  } // end of method DefaultWriter::Write

  .method family hidebysig newslot virtual 
          instance void  WriteNull(object 'value',
                                   class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       22 (0x16)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_0015

    IL_0003:  ldarg.0
    IL_0004:  ldarg.1
    IL_0005:  ldstr      "null"
    IL_000a:  ldstr      "null"
    IL_000f:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_0014:  throw

    IL_0015:  ret
  } // end of method DefaultWriter::WriteNull

  .method family hidebysig newslot virtual 
          instance void  Write<S>(object 'value',
                                  valuetype Avro.Schema/Type tag,
                                  class Avro.Generic.Writer`1<!!S> writer) cil managed
  {
    // Code size       55 (0x37)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     !!S
    IL_0006:  brtrue.s   IL_002a

    IL_0008:  ldarg.0
    IL_0009:  ldarg.1
    IL_000a:  ldarg.2
    IL_000b:  box        Avro.Schema/Type
    IL_0010:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0015:  ldtoken    !!S
    IL_001a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001f:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0024:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_0029:  throw

    IL_002a:  ldarg.3
    IL_002b:  ldarg.1
    IL_002c:  unbox.any  !!S
    IL_0031:  callvirt   instance void class Avro.Generic.Writer`1<!!S>::Invoke(!0)
    IL_0036:  ret
  } // end of method DefaultWriter::Write

  .method family hidebysig newslot virtual 
          instance void  WriteRecord(class Avro.RecordSchema schema,
                                     object 'value',
                                     class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       110 (0x6e)
    .maxstack  4
    .locals init (class Avro.Field V_0,
             object V_1,
             class [mscorlib]System.Exception V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_3)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  callvirt   instance void Avro.Generic.DefaultWriter::EnsureRecordObject(class Avro.RecordSchema,
                                                                                      object)
    IL_0008:  ldarg.1
    IL_0009:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_000e:  stloc.3
    .try
    {
      IL_000f:  br.s       IL_0059

      IL_0011:  ldloc.3
      IL_0012:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_0017:  stloc.0
      .try
      {
        IL_0018:  ldarg.0
        IL_0019:  ldarg.2
        IL_001a:  ldloc.0
        IL_001b:  ldfld      string Avro.Field::Name
        IL_0020:  ldloc.0
        IL_0021:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_0026:  callvirt   instance object Avro.Generic.DefaultWriter::GetField(object,
                                                                                  string,
                                                                                  int32)
        IL_002b:  stloc.1
        IL_002c:  ldarg.0
        IL_002d:  ldloc.0
        IL_002e:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_0033:  ldloc.1
        IL_0034:  ldarg.3
        IL_0035:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                             object,
                                                                             class Avro.IO.Encoder)
        IL_003a:  leave.s    IL_0059

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_003c:  stloc.2
        IL_003d:  ldloc.2
        IL_003e:  callvirt   instance string [mscorlib]System.Exception::get_Message()
        IL_0043:  ldstr      " in field "
        IL_0048:  ldloc.0
        IL_0049:  ldfld      string Avro.Field::Name
        IL_004e:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_0053:  newobj     instance void Avro.AvroException::.ctor(string)
        IL_0058:  throw

      }  // end handler
      IL_0059:  ldloc.3
      IL_005a:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_005f:  brtrue.s   IL_0011

      IL_0061:  leave.s    IL_006d

    }  // end .try
    finally
    {
      IL_0063:  ldloc.3
      IL_0064:  brfalse.s  IL_006c

      IL_0066:  ldloc.3
      IL_0067:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_006c:  endfinally
    }  // end handler
    IL_006d:  ret
  } // end of method DefaultWriter::WriteRecord

  .method family hidebysig newslot virtual 
          instance void  EnsureRecordObject(class Avro.RecordSchema s,
                                            object 'value') cil managed
  {
    // Code size       49 (0x31)
    .maxstack  8
    IL_0000:  ldarg.2
    IL_0001:  brfalse.s  IL_001e

    IL_0003:  ldarg.2
    IL_0004:  isinst     Avro.Generic.GenericRecord
    IL_0009:  brfalse.s  IL_001e

    IL_000b:  ldarg.2
    IL_000c:  isinst     Avro.Generic.GenericRecord
    IL_0011:  callvirt   instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_0016:  ldarg.1
    IL_0017:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001c:  brtrue.s   IL_0030

    IL_001e:  ldarg.0
    IL_001f:  ldarg.2
    IL_0020:  ldstr      "record"
    IL_0025:  ldstr      "GenericRecord"
    IL_002a:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_002f:  throw

    IL_0030:  ret
  } // end of method DefaultWriter::EnsureRecordObject

  .method family hidebysig newslot virtual 
          instance object  GetField(object 'value',
                                    string fieldName,
                                    int32 fieldPos) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  2
    .locals init (class Avro.Generic.GenericRecord V_0)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.Generic.GenericRecord
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldarg.2
    IL_0009:  callvirt   instance object Avro.Generic.GenericRecord::get_Item(string)
    IL_000e:  ret
  } // end of method DefaultWriter::GetField

  .method family hidebysig newslot virtual 
          instance void  WriteEnum(class Avro.EnumSchema es,
                                   object 'value',
                                   class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       72 (0x48)
    .maxstack  4
    IL_0000:  ldarg.2
    IL_0001:  brfalse.s  IL_001e

    IL_0003:  ldarg.2
    IL_0004:  isinst     Avro.Generic.GenericEnum
    IL_0009:  brfalse.s  IL_001e

    IL_000b:  ldarg.2
    IL_000c:  isinst     Avro.Generic.GenericEnum
    IL_0011:  callvirt   instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_0016:  ldarg.1
    IL_0017:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001c:  brtrue.s   IL_0030

    IL_001e:  ldarg.0
    IL_001f:  ldarg.2
    IL_0020:  ldstr      "enum"
    IL_0025:  ldstr      "GenericEnum"
    IL_002a:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_002f:  throw

    IL_0030:  ldarg.3
    IL_0031:  ldarg.1
    IL_0032:  ldarg.2
    IL_0033:  isinst     Avro.Generic.GenericEnum
    IL_0038:  callvirt   instance string Avro.Generic.GenericEnum::get_Value()
    IL_003d:  callvirt   instance int32 Avro.EnumSchema::Ordinal(string)
    IL_0042:  callvirt   instance void Avro.IO.Encoder::WriteEnum(int32)
    IL_0047:  ret
  } // end of method DefaultWriter::WriteEnum

  .method family hidebysig newslot virtual 
          instance void  WriteArray(class Avro.ArraySchema schema,
                                    object 'value',
                                    class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       76 (0x4c)
    .maxstack  5
    .locals init (int64 V_0,
             int64 V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.2
    IL_0002:  callvirt   instance void Avro.Generic.DefaultWriter::EnsureArrayObject(object)
    IL_0007:  ldarg.0
    IL_0008:  ldarg.2
    IL_0009:  callvirt   instance int64 Avro.Generic.DefaultWriter::GetArrayLength(object)
    IL_000e:  stloc.0
    IL_000f:  ldarg.3
    IL_0010:  callvirt   instance void Avro.IO.Encoder::WriteArrayStart()
    IL_0015:  ldarg.3
    IL_0016:  ldloc.0
    IL_0017:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_001c:  ldc.i4.0
    IL_001d:  conv.i8
    IL_001e:  stloc.1
    IL_001f:  br.s       IL_0041

    IL_0021:  ldarg.3
    IL_0022:  callvirt   instance void Avro.IO.Encoder::StartItem()
    IL_0027:  ldarg.0
    IL_0028:  ldarg.1
    IL_0029:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_002e:  ldarg.0
    IL_002f:  ldarg.2
    IL_0030:  ldloc.1
    IL_0031:  callvirt   instance object Avro.Generic.DefaultWriter::GetArrayElement(object,
                                                                                     int64)
    IL_0036:  ldarg.3
    IL_0037:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                         object,
                                                                         class Avro.IO.Encoder)
    IL_003c:  ldloc.1
    IL_003d:  ldc.i4.1
    IL_003e:  conv.i8
    IL_003f:  add
    IL_0040:  stloc.1
    IL_0041:  ldloc.1
    IL_0042:  ldloc.0
    IL_0043:  blt.s      IL_0021

    IL_0045:  ldarg.3
    IL_0046:  callvirt   instance void Avro.IO.Encoder::WriteArrayEnd()
    IL_004b:  ret
  } // end of method DefaultWriter::WriteArray

  .method family hidebysig newslot virtual 
          instance void  EnsureArrayObject(object 'value') cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.1
    IL_0004:  isinst     [mscorlib]System.Array
    IL_0009:  brtrue.s   IL_001d

    IL_000b:  ldarg.0
    IL_000c:  ldarg.1
    IL_000d:  ldstr      "array"
    IL_0012:  ldstr      "Array"
    IL_0017:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_001c:  throw

    IL_001d:  ret
  } // end of method DefaultWriter::EnsureArrayObject

  .method family hidebysig newslot virtual 
          instance int64  GetArrayLength(object 'value') cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     [mscorlib]System.Array
    IL_0006:  callvirt   instance int32 [mscorlib]System.Array::get_Length()
    IL_000b:  conv.i8
    IL_000c:  ret
  } // end of method DefaultWriter::GetArrayLength

  .method family hidebysig newslot virtual 
          instance object  GetArrayElement(object 'value',
                                           int64 index) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     [mscorlib]System.Array
    IL_0006:  ldarg.2
    IL_0007:  callvirt   instance object [mscorlib]System.Array::GetValue(int64)
    IL_000c:  ret
  } // end of method DefaultWriter::GetArrayElement

  .method family hidebysig newslot virtual 
          instance void  WriteMap(class Avro.MapSchema schema,
                                  object 'value',
                                  class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       121 (0x79)
    .maxstack  4
    .locals init (class [mscorlib]System.Collections.Generic.IDictionary`2<string,object> V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object> V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>> V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.2
    IL_0002:  callvirt   instance void Avro.Generic.DefaultWriter::EnsureMapObject(object)
    IL_0007:  ldarg.2
    IL_0008:  castclass  class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_000d:  stloc.0
    IL_000e:  ldarg.3
    IL_000f:  callvirt   instance void Avro.IO.Encoder::WriteMapStart()
    IL_0014:  ldarg.3
    IL_0015:  ldarg.0
    IL_0016:  ldarg.2
    IL_0017:  callvirt   instance int64 Avro.Generic.DefaultWriter::GetMapSize(object)
    IL_001c:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_0021:  ldarg.0
    IL_0022:  ldloc.0
    IL_0023:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>> Avro.Generic.DefaultWriter::GetMapValues(object)
    IL_0028:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::GetEnumerator()
    IL_002d:  stloc.2
    .try
    {
      IL_002e:  br.s       IL_005e

      IL_0030:  ldloc.2
      IL_0031:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Current()
      IL_0036:  stloc.1
      IL_0037:  ldarg.3
      IL_0038:  callvirt   instance void Avro.IO.Encoder::StartItem()
      IL_003d:  ldarg.3
      IL_003e:  ldloca.s   V_1
      IL_0040:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Key()
      IL_0045:  callvirt   instance void Avro.IO.Encoder::WriteString(string)
      IL_004a:  ldarg.0
      IL_004b:  ldarg.1
      IL_004c:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
      IL_0051:  ldloca.s   V_1
      IL_0053:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>::get_Value()
      IL_0058:  ldarg.3
      IL_0059:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                           object,
                                                                           class Avro.IO.Encoder)
      IL_005e:  ldloc.2
      IL_005f:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0064:  brtrue.s   IL_0030

      IL_0066:  leave.s    IL_0072

    }  // end .try
    finally
    {
      IL_0068:  ldloc.2
      IL_0069:  brfalse.s  IL_0071

      IL_006b:  ldloc.2
      IL_006c:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0071:  endfinally
    }  // end handler
    IL_0072:  ldarg.3
    IL_0073:  callvirt   instance void Avro.IO.Encoder::WriteMapEnd()
    IL_0078:  ret
  } // end of method DefaultWriter::WriteMap

  .method family hidebysig newslot virtual 
          instance void  EnsureMapObject(object 'value') cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.1
    IL_0004:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0009:  brtrue.s   IL_001d

    IL_000b:  ldarg.0
    IL_000c:  ldarg.1
    IL_000d:  ldstr      "map"
    IL_0012:  ldstr      "IDictionary<string, object>"
    IL_0017:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_001c:  throw

    IL_001d:  ret
  } // end of method DefaultWriter::EnsureMapObject

  .method family hidebysig newslot virtual 
          instance int64  GetMapSize(object 'value') cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>>::get_Count()
    IL_000b:  conv.i8
    IL_000c:  ret
  } // end of method DefaultWriter::GetMapSize

  .method family hidebysig newslot virtual 
          instance class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,object>> 
          GetMapValues(object 'value') cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0006:  ret
  } // end of method DefaultWriter::GetMapValues

  .method family hidebysig newslot virtual 
          instance void  WriteUnion(class Avro.UnionSchema us,
                                    object 'value',
                                    class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       32 (0x20)
    .maxstack  4
    .locals init (int32 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  callvirt   instance int32 Avro.Generic.DefaultWriter::ResolveUnion(class Avro.UnionSchema,
                                                                                 object)
    IL_0008:  stloc.0
    IL_0009:  ldarg.3
    IL_000a:  ldloc.0
    IL_000b:  callvirt   instance void Avro.IO.Encoder::WriteUnionIndex(int32)
    IL_0010:  ldarg.0
    IL_0011:  ldarg.1
    IL_0012:  ldloc.0
    IL_0013:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_0018:  ldarg.2
    IL_0019:  ldarg.3
    IL_001a:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                         object,
                                                                         class Avro.IO.Encoder)
    IL_001f:  ret
  } // end of method DefaultWriter::WriteUnion

  .method family hidebysig newslot virtual 
          instance int32  ResolveUnion(class Avro.UnionSchema us,
                                       object obj) cil managed
  {
    // Code size       83 (0x53)
    .maxstack  3
    .locals init (int32 V_0,
             object[] V_1)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  br.s       IL_001a

    IL_0004:  ldarg.0
    IL_0005:  ldarg.1
    IL_0006:  ldloc.0
    IL_0007:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_000c:  ldarg.2
    IL_000d:  callvirt   instance bool Avro.Generic.DefaultWriter::Matches(class Avro.Schema,
                                                                           object)
    IL_0012:  brfalse.s  IL_0016

    IL_0014:  ldloc.0
    IL_0015:  ret

    IL_0016:  ldloc.0
    IL_0017:  ldc.i4.1
    IL_0018:  add
    IL_0019:  stloc.0
    IL_001a:  ldloc.0
    IL_001b:  ldarg.1
    IL_001c:  callvirt   instance int32 Avro.UnionSchema::get_Count()
    IL_0021:  blt.s      IL_0004

    IL_0023:  ldc.i4.4
    IL_0024:  newarr     [mscorlib]System.Object
    IL_0029:  stloc.1
    IL_002a:  ldloc.1
    IL_002b:  ldc.i4.0
    IL_002c:  ldstr      "Cannot find a match for "
    IL_0031:  stelem.ref
    IL_0032:  ldloc.1
    IL_0033:  ldc.i4.1
    IL_0034:  ldarg.2
    IL_0035:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_003a:  stelem.ref
    IL_003b:  ldloc.1
    IL_003c:  ldc.i4.2
    IL_003d:  ldstr      " in "
    IL_0042:  stelem.ref
    IL_0043:  ldloc.1
    IL_0044:  ldc.i4.3
    IL_0045:  ldarg.1
    IL_0046:  stelem.ref
    IL_0047:  ldloc.1
    IL_0048:  call       string [mscorlib]System.String::Concat(object[])
    IL_004d:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0052:  throw
  } // end of method DefaultWriter::ResolveUnion

  .method family hidebysig newslot virtual 
          instance void  WriteFixed(class Avro.FixedSchema es,
                                    object 'value',
                                    class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       68 (0x44)
    .maxstack  4
    .locals init (class Avro.Generic.GenericFixed V_0)
    IL_0000:  ldarg.2
    IL_0001:  brfalse.s  IL_001e

    IL_0003:  ldarg.2
    IL_0004:  isinst     Avro.Generic.GenericFixed
    IL_0009:  brfalse.s  IL_001e

    IL_000b:  ldarg.2
    IL_000c:  isinst     Avro.Generic.GenericFixed
    IL_0011:  callvirt   instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_0016:  ldarg.1
    IL_0017:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_001c:  brtrue.s   IL_0030

    IL_001e:  ldarg.0
    IL_001f:  ldarg.2
    IL_0020:  ldstr      "fixed"
    IL_0025:  ldstr      "GenericFixed"
    IL_002a:  call       instance class Avro.AvroException Avro.Generic.DefaultWriter::TypeMismatch(object,
                                                                                                    string,
                                                                                                    string)
    IL_002f:  throw

    IL_0030:  ldarg.2
    IL_0031:  castclass  Avro.Generic.GenericFixed
    IL_0036:  stloc.0
    IL_0037:  ldarg.3
    IL_0038:  ldloc.0
    IL_0039:  callvirt   instance uint8[] Avro.Generic.GenericFixed::get_Value()
    IL_003e:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0043:  ret
  } // end of method DefaultWriter::WriteFixed

  .method family hidebysig instance class Avro.AvroException 
          TypeMismatch(object obj,
                       string schemaType,
                       string 'type') cil managed
  {
    // Code size       67 (0x43)
    .maxstack  3
    .locals init (string[] V_0)
    IL_0000:  ldc.i4.5
    IL_0001:  newarr     [mscorlib]System.String
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  ldarg.3
    IL_000a:  stelem.ref
    IL_000b:  ldloc.0
    IL_000c:  ldc.i4.1
    IL_000d:  ldstr      " required to write against "
    IL_0012:  stelem.ref
    IL_0013:  ldloc.0
    IL_0014:  ldc.i4.2
    IL_0015:  ldarg.2
    IL_0016:  stelem.ref
    IL_0017:  ldloc.0
    IL_0018:  ldc.i4.3
    IL_0019:  ldstr      " schema but found "
    IL_001e:  stelem.ref
    IL_001f:  ldloc.0
    IL_0020:  ldc.i4.4
    IL_0021:  ldarg.1
    IL_0022:  brfalse.s  IL_0031

    IL_0024:  ldarg.1
    IL_0025:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_002a:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_002f:  br.s       IL_0036

    IL_0031:  ldstr      "null"
    IL_0036:  stelem.ref
    IL_0037:  ldloc.0
    IL_0038:  call       string [mscorlib]System.String::Concat(string[])
    IL_003d:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0042:  ret
  } // end of method DefaultWriter::TypeMismatch

  .method private hidebysig instance void 
          'error'(class Avro.Schema schema,
                  object 'value') cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldc.i4.4
    IL_0001:  newarr     [mscorlib]System.Object
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  ldstr      "Not a "
    IL_000e:  stelem.ref
    IL_000f:  ldloc.0
    IL_0010:  ldc.i4.1
    IL_0011:  ldarg.1
    IL_0012:  stelem.ref
    IL_0013:  ldloc.0
    IL_0014:  ldc.i4.2
    IL_0015:  ldstr      ": "
    IL_001a:  stelem.ref
    IL_001b:  ldloc.0
    IL_001c:  ldc.i4.3
    IL_001d:  ldarg.2
    IL_001e:  stelem.ref
    IL_001f:  ldloc.0
    IL_0020:  call       string [mscorlib]System.String::Concat(object[])
    IL_0025:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_002a:  throw
  } // end of method DefaultWriter::'error'

  .method family hidebysig newslot virtual 
          instance bool  Matches(class Avro.Schema sc,
                                 object obj) cil managed
  {
    // Code size       353 (0x161)
    .maxstack  2
    .locals init (valuetype Avro.Schema/Type V_0)
    IL_0000:  ldarg.2
    IL_0001:  brtrue.s   IL_000d

    IL_0003:  ldarg.1
    IL_0004:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0009:  brfalse.s  IL_000d

    IL_000b:  ldc.i4.0
    IL_000c:  ret

    IL_000d:  ldarg.1
    IL_000e:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0013:  stloc.0
    IL_0014:  ldloc.0
    IL_0015:  switch     ( 
                          IL_0057,
                          IL_005c,
                          IL_0066,
                          IL_0070,
                          IL_007a,
                          IL_0084,
                          IL_008e,
                          IL_0098,
                          IL_00a2,
                          IL_00cd,
                          IL_00f8,
                          IL_010f,
                          IL_0119,
                          IL_011b)
    IL_0052:  br         IL_0146

    IL_0057:  ldarg.2
    IL_0058:  ldnull
    IL_0059:  ceq
    IL_005b:  ret

    IL_005c:  ldarg.2
    IL_005d:  isinst     [mscorlib]System.Boolean
    IL_0062:  ldnull
    IL_0063:  cgt.un
    IL_0065:  ret

    IL_0066:  ldarg.2
    IL_0067:  isinst     [mscorlib]System.Int32
    IL_006c:  ldnull
    IL_006d:  cgt.un
    IL_006f:  ret

    IL_0070:  ldarg.2
    IL_0071:  isinst     [mscorlib]System.Int64
    IL_0076:  ldnull
    IL_0077:  cgt.un
    IL_0079:  ret

    IL_007a:  ldarg.2
    IL_007b:  isinst     [mscorlib]System.Single
    IL_0080:  ldnull
    IL_0081:  cgt.un
    IL_0083:  ret

    IL_0084:  ldarg.2
    IL_0085:  isinst     [mscorlib]System.Double
    IL_008a:  ldnull
    IL_008b:  cgt.un
    IL_008d:  ret

    IL_008e:  ldarg.2
    IL_008f:  isinst     uint8[]
    IL_0094:  ldnull
    IL_0095:  cgt.un
    IL_0097:  ret

    IL_0098:  ldarg.2
    IL_0099:  isinst     [mscorlib]System.String
    IL_009e:  ldnull
    IL_009f:  cgt.un
    IL_00a1:  ret

    IL_00a2:  ldarg.2
    IL_00a3:  isinst     Avro.Generic.GenericRecord
    IL_00a8:  brfalse.s  IL_00cb

    IL_00aa:  ldarg.2
    IL_00ab:  isinst     Avro.Generic.GenericRecord
    IL_00b0:  callvirt   instance class Avro.RecordSchema Avro.Generic.GenericRecord::get_Schema()
    IL_00b5:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00ba:  ldarg.1
    IL_00bb:  isinst     Avro.RecordSchema
    IL_00c0:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00c5:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_00ca:  ret

    IL_00cb:  ldc.i4.0
    IL_00cc:  ret

    IL_00cd:  ldarg.2
    IL_00ce:  isinst     Avro.Generic.GenericEnum
    IL_00d3:  brfalse.s  IL_00f6

    IL_00d5:  ldarg.2
    IL_00d6:  isinst     Avro.Generic.GenericEnum
    IL_00db:  callvirt   instance class Avro.EnumSchema Avro.Generic.GenericEnum::get_Schema()
    IL_00e0:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00e5:  ldarg.1
    IL_00e6:  isinst     Avro.EnumSchema
    IL_00eb:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00f0:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_00f5:  ret

    IL_00f6:  ldc.i4.0
    IL_00f7:  ret

    IL_00f8:  ldarg.2
    IL_00f9:  isinst     [mscorlib]System.Array
    IL_00fe:  brfalse.s  IL_010d

    IL_0100:  ldarg.2
    IL_0101:  isinst     uint8[]
    IL_0106:  ldnull
    IL_0107:  cgt.un
    IL_0109:  ldc.i4.0
    IL_010a:  ceq
    IL_010c:  ret

    IL_010d:  ldc.i4.0
    IL_010e:  ret

    IL_010f:  ldarg.2
    IL_0110:  isinst     class [mscorlib]System.Collections.Generic.IDictionary`2<string,object>
    IL_0115:  ldnull
    IL_0116:  cgt.un
    IL_0118:  ret

    IL_0119:  ldc.i4.0
    IL_011a:  ret

    IL_011b:  ldarg.2
    IL_011c:  isinst     Avro.Generic.GenericFixed
    IL_0121:  brfalse.s  IL_0144

    IL_0123:  ldarg.2
    IL_0124:  isinst     Avro.Generic.GenericFixed
    IL_0129:  callvirt   instance class Avro.FixedSchema Avro.Generic.GenericFixed::get_Schema()
    IL_012e:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0133:  ldarg.1
    IL_0134:  isinst     Avro.FixedSchema
    IL_0139:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_013e:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0143:  ret

    IL_0144:  ldc.i4.0
    IL_0145:  ret

    IL_0146:  ldstr      "Unknown schema type: "
    IL_014b:  ldarg.1
    IL_014c:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0151:  box        Avro.Schema/Type
    IL_0156:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_015b:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0160:  throw
  } // end of method DefaultWriter::Matches

  .property instance class Avro.Schema Schema()
  {
    .set instance void Avro.Generic.DefaultWriter::set_Schema(class Avro.Schema)
    .get instance class Avro.Schema Avro.Generic.DefaultWriter::get_Schema()
  } // end of property DefaultWriter::Schema
} // end of class Avro.Generic.DefaultWriter

.class interface public abstract auto ansi Avro.IO.Decoder
{
  .method public hidebysig newslot abstract virtual 
          instance void  ReadNull() cil managed
  {
  } // end of method Decoder::ReadNull

  .method public hidebysig newslot abstract virtual 
          instance bool  ReadBoolean() cil managed
  {
  } // end of method Decoder::ReadBoolean

  .method public hidebysig newslot abstract virtual 
          instance int32  ReadInt() cil managed
  {
  } // end of method Decoder::ReadInt

  .method public hidebysig newslot abstract virtual 
          instance int64  ReadLong() cil managed
  {
  } // end of method Decoder::ReadLong

  .method public hidebysig newslot abstract virtual 
          instance float32  ReadFloat() cil managed
  {
  } // end of method Decoder::ReadFloat

  .method public hidebysig newslot abstract virtual 
          instance float64  ReadDouble() cil managed
  {
  } // end of method Decoder::ReadDouble

  .method public hidebysig newslot abstract virtual 
          instance uint8[]  ReadBytes() cil managed
  {
  } // end of method Decoder::ReadBytes

  .method public hidebysig newslot abstract virtual 
          instance string  ReadString() cil managed
  {
  } // end of method Decoder::ReadString

  .method public hidebysig newslot abstract virtual 
          instance int32  ReadEnum() cil managed
  {
  } // end of method Decoder::ReadEnum

  .method public hidebysig newslot abstract virtual 
          instance int64  ReadArrayStart() cil managed
  {
  } // end of method Decoder::ReadArrayStart

  .method public hidebysig newslot abstract virtual 
          instance int64  ReadArrayNext() cil managed
  {
  } // end of method Decoder::ReadArrayNext

  .method public hidebysig newslot abstract virtual 
          instance int64  ReadMapStart() cil managed
  {
  } // end of method Decoder::ReadMapStart

  .method public hidebysig newslot abstract virtual 
          instance int64  ReadMapNext() cil managed
  {
  } // end of method Decoder::ReadMapNext

  .method public hidebysig newslot abstract virtual 
          instance int32  ReadUnionIndex() cil managed
  {
  } // end of method Decoder::ReadUnionIndex

  .method public hidebysig newslot abstract virtual 
          instance void  ReadFixed(uint8[] buffer) cil managed
  {
  } // end of method Decoder::ReadFixed

  .method public hidebysig newslot abstract virtual 
          instance void  ReadFixed(uint8[] buffer,
                                   int32 start,
                                   int32 length) cil managed
  {
  } // end of method Decoder::ReadFixed

  .method public hidebysig newslot abstract virtual 
          instance void  SkipNull() cil managed
  {
  } // end of method Decoder::SkipNull

  .method public hidebysig newslot abstract virtual 
          instance void  SkipBoolean() cil managed
  {
  } // end of method Decoder::SkipBoolean

  .method public hidebysig newslot abstract virtual 
          instance void  SkipInt() cil managed
  {
  } // end of method Decoder::SkipInt

  .method public hidebysig newslot abstract virtual 
          instance void  SkipLong() cil managed
  {
  } // end of method Decoder::SkipLong

  .method public hidebysig newslot abstract virtual 
          instance void  SkipFloat() cil managed
  {
  } // end of method Decoder::SkipFloat

  .method public hidebysig newslot abstract virtual 
          instance void  SkipDouble() cil managed
  {
  } // end of method Decoder::SkipDouble

  .method public hidebysig newslot abstract virtual 
          instance void  SkipBytes() cil managed
  {
  } // end of method Decoder::SkipBytes

  .method public hidebysig newslot abstract virtual 
          instance void  SkipString() cil managed
  {
  } // end of method Decoder::SkipString

  .method public hidebysig newslot abstract virtual 
          instance void  SkipEnum() cil managed
  {
  } // end of method Decoder::SkipEnum

  .method public hidebysig newslot abstract virtual 
          instance void  SkipUnionIndex() cil managed
  {
  } // end of method Decoder::SkipUnionIndex

  .method public hidebysig newslot abstract virtual 
          instance void  SkipFixed(int32 len) cil managed
  {
  } // end of method Decoder::SkipFixed

} // end of class Avro.IO.Decoder

.class public auto ansi beforefieldinit Avro.IO.BinaryDecoder
       extends [mscorlib]System.Object
       implements Avro.IO.Decoder
{
  .field private initonly class [mscorlib]System.IO.Stream 'stream'
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.IO.Stream 'stream') cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_000d:  ret
  } // end of method BinaryDecoder::.ctor

  .method public hidebysig newslot virtual final 
          instance void  ReadNull() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method BinaryDecoder::ReadNull

  .method public hidebysig newslot virtual final 
          instance bool  ReadBoolean() cil managed
  {
    // Code size       40 (0x28)
    .maxstack  2
    .locals init (uint8 V_0)
    IL_0000:  ldarg.0
    IL_0001:  call       instance uint8 Avro.IO.BinaryDecoder::read()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_000c

    IL_000a:  ldc.i4.0
    IL_000b:  ret

    IL_000c:  ldloc.0
    IL_000d:  ldc.i4.1
    IL_000e:  bne.un.s   IL_0012

    IL_0010:  ldc.i4.1
    IL_0011:  ret

    IL_0012:  ldstr      "Not a boolean value in the stream: "
    IL_0017:  ldloc.0
    IL_0018:  box        [mscorlib]System.Byte
    IL_001d:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0022:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0027:  throw
  } // end of method BinaryDecoder::ReadBoolean

  .method public hidebysig newslot virtual final 
          instance int32  ReadInt() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0006:  conv.i4
    IL_0007:  ret
  } // end of method BinaryDecoder::ReadInt

  .method public hidebysig newslot virtual final 
          instance int64  ReadLong() cil managed
  {
    // Code size       74 (0x4a)
    .maxstack  4
    .locals init (uint8 V_0,
             uint64 V_1,
             int32 V_2,
             int64 V_3)
    IL_0000:  ldarg.0
    IL_0001:  call       instance uint8 Avro.IO.BinaryDecoder::read()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  conv.u8
    IL_0009:  ldc.i4.s   127
    IL_000b:  conv.i8
    IL_000c:  and
    IL_000d:  stloc.1
    IL_000e:  ldc.i4.7
    IL_000f:  stloc.2
    IL_0010:  br.s       IL_002b

    IL_0012:  ldarg.0
    IL_0013:  call       instance uint8 Avro.IO.BinaryDecoder::read()
    IL_0018:  stloc.0
    IL_0019:  ldloc.1
    IL_001a:  ldloc.0
    IL_001b:  conv.u8
    IL_001c:  ldc.i4.s   127
    IL_001e:  conv.i8
    IL_001f:  and
    IL_0020:  ldloc.2
    IL_0021:  ldc.i4.s   63
    IL_0023:  and
    IL_0024:  shl
    IL_0025:  or
    IL_0026:  stloc.1
    IL_0027:  ldloc.2
    IL_0028:  ldc.i4.7
    IL_0029:  add
    IL_002a:  stloc.2
    IL_002b:  ldloc.0
    IL_002c:  ldc.i4     0x80
    IL_0031:  and
    IL_0032:  brtrue.s   IL_0012

    IL_0034:  ldloc.1
    IL_0035:  stloc.3
    IL_0036:  ldloc.3
    IL_0037:  ldc.i4.1
    IL_0038:  conv.i8
    IL_0039:  and
    IL_003a:  neg
    IL_003b:  ldloc.3
    IL_003c:  ldc.i4.1
    IL_003d:  shr
    IL_003e:  ldc.i8     0x7fffffffffffffff
    IL_0047:  and
    IL_0048:  xor
    IL_0049:  ret
  } // end of method BinaryDecoder::ReadLong

  .method public hidebysig newslot virtual final 
          instance float32  ReadFloat() cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  2
    .locals init (uint8[] V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  conv.i8
    IL_0003:  call       instance uint8[] Avro.IO.BinaryDecoder::read(int64)
    IL_0008:  stloc.0
    IL_0009:  ldsfld     bool [mscorlib]System.BitConverter::IsLittleEndian
    IL_000e:  brtrue.s   IL_0016

    IL_0010:  ldloc.0
    IL_0011:  call       void [mscorlib]System.Array::Reverse(class [mscorlib]System.Array)
    IL_0016:  ldloc.0
    IL_0017:  ldc.i4.0
    IL_0018:  call       float32 [mscorlib]System.BitConverter::ToSingle(uint8[],
                                                                         int32)
    IL_001d:  ret
  } // end of method BinaryDecoder::ReadFloat

  .method public hidebysig newslot virtual final 
          instance float64  ReadDouble() cil managed
  {
    // Code size       187 (0xbb)
    .maxstack  3
    .locals init (int64 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0006:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_000b:  conv.i8
    IL_000c:  ldc.i4     0xff
    IL_0011:  conv.i8
    IL_0012:  and
    IL_0013:  ldarg.0
    IL_0014:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0019:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_001e:  conv.i8
    IL_001f:  ldc.i4     0xff
    IL_0024:  conv.i8
    IL_0025:  and
    IL_0026:  ldc.i4.8
    IL_0027:  shl
    IL_0028:  or
    IL_0029:  ldarg.0
    IL_002a:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_002f:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_0034:  conv.i8
    IL_0035:  ldc.i4     0xff
    IL_003a:  conv.i8
    IL_003b:  and
    IL_003c:  ldc.i4.s   16
    IL_003e:  shl
    IL_003f:  or
    IL_0040:  ldarg.0
    IL_0041:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0046:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_004b:  conv.i8
    IL_004c:  ldc.i4     0xff
    IL_0051:  conv.i8
    IL_0052:  and
    IL_0053:  ldc.i4.s   24
    IL_0055:  shl
    IL_0056:  or
    IL_0057:  ldarg.0
    IL_0058:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_005d:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_0062:  conv.i8
    IL_0063:  ldc.i4     0xff
    IL_0068:  conv.i8
    IL_0069:  and
    IL_006a:  ldc.i4.s   32
    IL_006c:  shl
    IL_006d:  or
    IL_006e:  ldarg.0
    IL_006f:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0074:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_0079:  conv.i8
    IL_007a:  ldc.i4     0xff
    IL_007f:  conv.i8
    IL_0080:  and
    IL_0081:  ldc.i4.s   40
    IL_0083:  shl
    IL_0084:  or
    IL_0085:  ldarg.0
    IL_0086:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_008b:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_0090:  conv.i8
    IL_0091:  ldc.i4     0xff
    IL_0096:  conv.i8
    IL_0097:  and
    IL_0098:  ldc.i4.s   48
    IL_009a:  shl
    IL_009b:  or
    IL_009c:  ldarg.0
    IL_009d:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_00a2:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_00a7:  conv.i8
    IL_00a8:  ldc.i4     0xff
    IL_00ad:  conv.i8
    IL_00ae:  and
    IL_00af:  ldc.i4.s   56
    IL_00b1:  shl
    IL_00b2:  or
    IL_00b3:  stloc.0
    IL_00b4:  ldloc.0
    IL_00b5:  call       float64 [mscorlib]System.BitConverter::Int64BitsToDouble(int64)
    IL_00ba:  ret
  } // end of method BinaryDecoder::ReadDouble

  .method public hidebysig newslot virtual final 
          instance uint8[]  ReadBytes() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.0
    IL_0002:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0007:  call       instance uint8[] Avro.IO.BinaryDecoder::read(int64)
    IL_000c:  ret
  } // end of method BinaryDecoder::ReadBytes

  .method public hidebysig newslot virtual final 
          instance string  ReadString() cil managed
  {
    // Code size       33 (0x21)
    .maxstack  2
    .locals init (int32 V_0,
             uint8[] V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       instance int32 Avro.IO.BinaryDecoder::ReadInt()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  newarr     [mscorlib]System.Byte
    IL_000d:  stloc.1
    IL_000e:  ldarg.0
    IL_000f:  ldloc.1
    IL_0010:  call       instance void Avro.IO.BinaryDecoder::ReadFixed(uint8[])
    IL_0015:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
    IL_001a:  ldloc.1
    IL_001b:  callvirt   instance string [mscorlib]System.Text.Encoding::GetString(uint8[])
    IL_0020:  ret
  } // end of method BinaryDecoder::ReadString

  .method public hidebysig newslot virtual final 
          instance int32  ReadEnum() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int32 Avro.IO.BinaryDecoder::ReadInt()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadEnum

  .method public hidebysig newslot virtual final 
          instance int64  ReadArrayStart() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::doReadItemCount()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadArrayStart

  .method public hidebysig newslot virtual final 
          instance int64  ReadArrayNext() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::doReadItemCount()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadArrayNext

  .method public hidebysig newslot virtual final 
          instance int64  ReadMapStart() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::doReadItemCount()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadMapStart

  .method public hidebysig newslot virtual final 
          instance int64  ReadMapNext() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::doReadItemCount()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadMapNext

  .method public hidebysig newslot virtual final 
          instance int32  ReadUnionIndex() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int32 Avro.IO.BinaryDecoder::ReadInt()
    IL_0006:  ret
  } // end of method BinaryDecoder::ReadUnionIndex

  .method public hidebysig newslot virtual final 
          instance void  ReadFixed(uint8[] buffer) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.0
    IL_0003:  ldarg.1
    IL_0004:  ldlen
    IL_0005:  conv.i4
    IL_0006:  call       instance void Avro.IO.BinaryDecoder::ReadFixed(uint8[],
                                                                        int32,
                                                                        int32)
    IL_000b:  ret
  } // end of method BinaryDecoder::ReadFixed

  .method public hidebysig newslot virtual final 
          instance void  ReadFixed(uint8[] buffer,
                                   int32 start,
                                   int32 length) cil managed
  {
    // Code size       10 (0xa)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance void Avro.IO.BinaryDecoder::Read(uint8[],
                                                                   int32,
                                                                   int32)
    IL_0009:  ret
  } // end of method BinaryDecoder::ReadFixed

  .method public hidebysig newslot virtual final 
          instance void  SkipNull() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Avro.IO.BinaryDecoder::ReadNull()
    IL_0006:  ret
  } // end of method BinaryDecoder::SkipNull

  .method public hidebysig newslot virtual final 
          instance void  SkipBoolean() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance bool Avro.IO.BinaryDecoder::ReadBoolean()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipBoolean

  .method public hidebysig newslot virtual final 
          instance void  SkipInt() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int32 Avro.IO.BinaryDecoder::ReadInt()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipInt

  .method public hidebysig newslot virtual final 
          instance void  SkipLong() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipLong

  .method public hidebysig newslot virtual final 
          instance void  SkipFloat() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.4
    IL_0002:  call       instance void Avro.IO.BinaryDecoder::Skip(int32)
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipFloat

  .method public hidebysig newslot virtual final 
          instance void  SkipDouble() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.8
    IL_0002:  call       instance void Avro.IO.BinaryDecoder::Skip(int32)
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipDouble

  .method public hidebysig newslot virtual final 
          instance void  SkipBytes() cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.0
    IL_0002:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0007:  call       instance void Avro.IO.BinaryDecoder::Skip(int64)
    IL_000c:  ret
  } // end of method BinaryDecoder::SkipBytes

  .method public hidebysig newslot virtual final 
          instance void  SkipString() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void Avro.IO.BinaryDecoder::SkipBytes()
    IL_0006:  ret
  } // end of method BinaryDecoder::SkipString

  .method public hidebysig newslot virtual final 
          instance void  SkipEnum() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipEnum

  .method public hidebysig newslot virtual final 
          instance void  SkipUnionIndex() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0006:  pop
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipUnionIndex

  .method public hidebysig newslot virtual final 
          instance void  SkipFixed(int32 len) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.IO.BinaryDecoder::Skip(int32)
    IL_0007:  ret
  } // end of method BinaryDecoder::SkipFixed

  .method private hidebysig instance uint8[] 
          read(int64 p) cil managed
  {
    // Code size       21 (0x15)
    .maxstack  4
    .locals init (uint8[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  conv.ovf.i
    IL_0002:  newarr     [mscorlib]System.Byte
    IL_0007:  stloc.0
    IL_0008:  ldarg.0
    IL_0009:  ldloc.0
    IL_000a:  ldc.i4.0
    IL_000b:  ldloc.0
    IL_000c:  ldlen
    IL_000d:  conv.i4
    IL_000e:  call       instance void Avro.IO.BinaryDecoder::Read(uint8[],
                                                                   int32,
                                                                   int32)
    IL_0013:  ldloc.0
    IL_0014:  ret
  } // end of method BinaryDecoder::read

  .method private hidebysig static float32 
          intBitsToFloat(int32 'value') cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       uint8[] [mscorlib]System.BitConverter::GetBytes(int32)
    IL_0006:  ldc.i4.0
    IL_0007:  call       float32 [mscorlib]System.BitConverter::ToSingle(uint8[],
                                                                         int32)
    IL_000c:  ret
  } // end of method BinaryDecoder::intBitsToFloat

  .method private hidebysig instance uint8 
          read() cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0006:  callvirt   instance int32 [mscorlib]System.IO.Stream::ReadByte()
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  ldc.i4.0
    IL_000e:  blt.s      IL_0013

    IL_0010:  ldloc.0
    IL_0011:  conv.u1
    IL_0012:  ret

    IL_0013:  ldstr      "End of stream reached"
    IL_0018:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001d:  throw
  } // end of method BinaryDecoder::read

  .method private hidebysig instance void 
          Read(uint8[] buffer,
               int32 start,
               int32 len) cil managed
  {
    // Code size       47 (0x2f)
    .maxstack  4
    .locals init (int32 V_0)
    IL_0000:  br.s       IL_002a

    IL_0002:  ldarg.0
    IL_0003:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0008:  ldarg.1
    IL_0009:  ldarg.2
    IL_000a:  ldarg.3
    IL_000b:  callvirt   instance int32 [mscorlib]System.IO.Stream::Read(uint8[],
                                                                         int32,
                                                                         int32)
    IL_0010:  stloc.0
    IL_0011:  ldloc.0
    IL_0012:  ldc.i4.0
    IL_0013:  bgt.s      IL_0020

    IL_0015:  ldstr      "End of stream reached"
    IL_001a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001f:  throw

    IL_0020:  ldarg.2
    IL_0021:  ldloc.0
    IL_0022:  add
    IL_0023:  starg.s    start
    IL_0025:  ldarg.3
    IL_0026:  ldloc.0
    IL_0027:  sub
    IL_0028:  starg.s    len
    IL_002a:  ldarg.3
    IL_002b:  ldc.i4.0
    IL_002c:  bgt.s      IL_0002

    IL_002e:  ret
  } // end of method BinaryDecoder::Read

  .method private hidebysig instance int64 
          doReadItemCount() cil managed
  {
    // Code size       24 (0x18)
    .maxstack  2
    .locals init (int64 V_0)
    IL_0000:  ldarg.0
    IL_0001:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  ldc.i4.0
    IL_0009:  conv.i8
    IL_000a:  bge.s      IL_0016

    IL_000c:  ldarg.0
    IL_000d:  call       instance int64 Avro.IO.BinaryDecoder::ReadLong()
    IL_0012:  pop
    IL_0013:  ldloc.0
    IL_0014:  neg
    IL_0015:  stloc.0
    IL_0016:  ldloc.0
    IL_0017:  ret
  } // end of method BinaryDecoder::doReadItemCount

  .method private hidebysig instance void 
          Skip(int32 p) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0006:  ldarg.1
    IL_0007:  conv.i8
    IL_0008:  ldc.i4.1
    IL_0009:  callvirt   instance int64 [mscorlib]System.IO.Stream::Seek(int64,
                                                                         valuetype [mscorlib]System.IO.SeekOrigin)
    IL_000e:  pop
    IL_000f:  ret
  } // end of method BinaryDecoder::Skip

  .method private hidebysig instance void 
          Skip(int64 p) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryDecoder::'stream'
    IL_0006:  ldarg.1
    IL_0007:  ldc.i4.1
    IL_0008:  callvirt   instance int64 [mscorlib]System.IO.Stream::Seek(int64,
                                                                         valuetype [mscorlib]System.IO.SeekOrigin)
    IL_000d:  pop
    IL_000e:  ret
  } // end of method BinaryDecoder::Skip

  .method assembly hidebysig instance void 
          skip(int64 block_size) cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  newobj     instance void [mscorlib]System.NotImplementedException::.ctor()
    IL_0005:  throw
  } // end of method BinaryDecoder::skip

} // end of class Avro.IO.BinaryDecoder

.class interface public abstract auto ansi Avro.IO.Encoder
{
  .method public hidebysig newslot abstract virtual 
          instance void  WriteNull() cil managed
  {
  } // end of method Encoder::WriteNull

  .method public hidebysig newslot abstract virtual 
          instance void  WriteBoolean(bool 'value') cil managed
  {
  } // end of method Encoder::WriteBoolean

  .method public hidebysig newslot abstract virtual 
          instance void  WriteInt(int32 'value') cil managed
  {
  } // end of method Encoder::WriteInt

  .method public hidebysig newslot abstract virtual 
          instance void  WriteLong(int64 'value') cil managed
  {
  } // end of method Encoder::WriteLong

  .method public hidebysig newslot abstract virtual 
          instance void  WriteFloat(float32 'value') cil managed
  {
  } // end of method Encoder::WriteFloat

  .method public hidebysig newslot abstract virtual 
          instance void  WriteDouble(float64 'value') cil managed
  {
  } // end of method Encoder::WriteDouble

  .method public hidebysig newslot abstract virtual 
          instance void  WriteBytes(uint8[] 'value') cil managed
  {
  } // end of method Encoder::WriteBytes

  .method public hidebysig newslot abstract virtual 
          instance void  WriteStream(class [mscorlib]System.IO.Stream 'value') cil managed
  {
  } // end of method Encoder::WriteStream

  .method public hidebysig newslot abstract virtual 
          instance void  WriteString(string 'value') cil managed
  {
  } // end of method Encoder::WriteString

  .method public hidebysig newslot abstract virtual 
          instance void  WriteEnum(int32 'value') cil managed
  {
  } // end of method Encoder::WriteEnum

  .method public hidebysig newslot abstract virtual 
          instance void  SetItemCount(int64 'value') cil managed
  {
  } // end of method Encoder::SetItemCount

  .method public hidebysig newslot abstract virtual 
          instance void  StartItem() cil managed
  {
  } // end of method Encoder::StartItem

  .method public hidebysig newslot abstract virtual 
          instance void  WriteArrayStart() cil managed
  {
  } // end of method Encoder::WriteArrayStart

  .method public hidebysig newslot abstract virtual 
          instance void  WriteArrayEnd() cil managed
  {
  } // end of method Encoder::WriteArrayEnd

  .method public hidebysig newslot abstract virtual 
          instance void  WriteMapStart() cil managed
  {
  } // end of method Encoder::WriteMapStart

  .method public hidebysig newslot abstract virtual 
          instance void  WriteMapEnd() cil managed
  {
  } // end of method Encoder::WriteMapEnd

  .method public hidebysig newslot abstract virtual 
          instance void  WriteUnionIndex(int32 'value') cil managed
  {
  } // end of method Encoder::WriteUnionIndex

  .method public hidebysig newslot abstract virtual 
          instance void  WriteFixed(uint8[] data) cil managed
  {
  } // end of method Encoder::WriteFixed

  .method public hidebysig newslot abstract virtual 
          instance void  WriteFixed(uint8[] data,
                                    int32 start,
                                    int32 len) cil managed
  {
  } // end of method Encoder::WriteFixed

} // end of class Avro.IO.Encoder

.class public auto ansi beforefieldinit Avro.IO.BinaryEncoder
       extends [mscorlib]System.Object
       implements Avro.IO.Encoder
{
  .field private initonly class [mscorlib]System.IO.Stream _stream
  .field private initonly class [mscorlib]System.IO.MemoryStream _memStream
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldnull
    IL_0002:  call       instance void Avro.IO.BinaryEncoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_0007:  ret
  } // end of method BinaryEncoder::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.IO.Stream 'stream') cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryEncoder::_stream
    IL_000d:  ldarg.0
    IL_000e:  ldarg.1
    IL_000f:  isinst     [mscorlib]System.IO.MemoryStream
    IL_0014:  stfld      class [mscorlib]System.IO.MemoryStream Avro.IO.BinaryEncoder::_memStream
    IL_0019:  ret
  } // end of method BinaryEncoder::.ctor

  .method public hidebysig newslot virtual final 
          instance void  WriteNull() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method BinaryEncoder::WriteNull

  .method public hidebysig newslot virtual final 
          instance void  WriteBoolean(bool b) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  brtrue.s   IL_0007

    IL_0004:  ldc.i4.0
    IL_0005:  br.s       IL_0008

    IL_0007:  ldc.i4.1
    IL_0008:  conv.u1
    IL_0009:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_000e:  ret
  } // end of method BinaryEncoder::WriteBoolean

  .method public hidebysig newslot virtual final 
          instance void  WriteInt(int32 'value') cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  conv.i8
    IL_0003:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_0008:  ret
  } // end of method BinaryEncoder::WriteInt

  .method public hidebysig newslot virtual final 
          instance void  WriteLong(int64 'value') cil managed
  {
    // Code size       52 (0x34)
    .maxstack  3
    .locals init (uint64 V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldc.i4.1
    IL_0002:  shl
    IL_0003:  ldarg.1
    IL_0004:  ldc.i4.s   63
    IL_0006:  shr
    IL_0007:  xor
    IL_0008:  stloc.0
    IL_0009:  br.s       IL_0022

    IL_000b:  ldarg.0
    IL_000c:  ldloc.0
    IL_000d:  ldc.i4.s   127
    IL_000f:  conv.i8
    IL_0010:  and
    IL_0011:  ldc.i4     0x80
    IL_0016:  conv.i8
    IL_0017:  or
    IL_0018:  conv.u1
    IL_0019:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_001e:  ldloc.0
    IL_001f:  ldc.i4.7
    IL_0020:  shr.un
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldc.i4.s   -128
    IL_0025:  conv.i8
    IL_0026:  and
    IL_0027:  ldc.i4.0
    IL_0028:  conv.i8
    IL_0029:  bne.un.s   IL_000b

    IL_002b:  ldarg.0
    IL_002c:  ldloc.0
    IL_002d:  conv.u1
    IL_002e:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0033:  ret
  } // end of method BinaryEncoder::WriteLong

  .method public hidebysig newslot virtual final 
          instance void  WriteFloat(float32 'value') cil managed
  {
    // Code size       28 (0x1c)
    .maxstack  2
    .locals init (uint8[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  call       uint8[] [mscorlib]System.BitConverter::GetBytes(float32)
    IL_0006:  stloc.0
    IL_0007:  ldsfld     bool [mscorlib]System.BitConverter::IsLittleEndian
    IL_000c:  brtrue.s   IL_0014

    IL_000e:  ldloc.0
    IL_000f:  call       void [mscorlib]System.Array::Reverse(class [mscorlib]System.Array)
    IL_0014:  ldarg.0
    IL_0015:  ldloc.0
    IL_0016:  call       instance void Avro.IO.BinaryEncoder::writeBytes(uint8[])
    IL_001b:  ret
  } // end of method BinaryEncoder::WriteFloat

  .method public hidebysig newslot virtual final 
          instance void  WriteDouble(float64 'value') cil managed
  {
    // Code size       148 (0x94)
    .maxstack  3
    .locals init (int64 V_0)
    IL_0000:  ldarg.1
    IL_0001:  call       int64 [mscorlib]System.BitConverter::DoubleToInt64Bits(float64)
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  ldloc.0
    IL_0009:  ldc.i4     0xff
    IL_000e:  conv.i8
    IL_000f:  and
    IL_0010:  conv.u1
    IL_0011:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0016:  ldarg.0
    IL_0017:  ldloc.0
    IL_0018:  ldc.i4.8
    IL_0019:  shr
    IL_001a:  ldc.i4     0xff
    IL_001f:  conv.i8
    IL_0020:  and
    IL_0021:  conv.u1
    IL_0022:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0027:  ldarg.0
    IL_0028:  ldloc.0
    IL_0029:  ldc.i4.s   16
    IL_002b:  shr
    IL_002c:  ldc.i4     0xff
    IL_0031:  conv.i8
    IL_0032:  and
    IL_0033:  conv.u1
    IL_0034:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0039:  ldarg.0
    IL_003a:  ldloc.0
    IL_003b:  ldc.i4.s   24
    IL_003d:  shr
    IL_003e:  ldc.i4     0xff
    IL_0043:  conv.i8
    IL_0044:  and
    IL_0045:  conv.u1
    IL_0046:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_004b:  ldarg.0
    IL_004c:  ldloc.0
    IL_004d:  ldc.i4.s   32
    IL_004f:  shr
    IL_0050:  ldc.i4     0xff
    IL_0055:  conv.i8
    IL_0056:  and
    IL_0057:  conv.u1
    IL_0058:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_005d:  ldarg.0
    IL_005e:  ldloc.0
    IL_005f:  ldc.i4.s   40
    IL_0061:  shr
    IL_0062:  ldc.i4     0xff
    IL_0067:  conv.i8
    IL_0068:  and
    IL_0069:  conv.u1
    IL_006a:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_006f:  ldarg.0
    IL_0070:  ldloc.0
    IL_0071:  ldc.i4.s   48
    IL_0073:  shr
    IL_0074:  ldc.i4     0xff
    IL_0079:  conv.i8
    IL_007a:  and
    IL_007b:  conv.u1
    IL_007c:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0081:  ldarg.0
    IL_0082:  ldloc.0
    IL_0083:  ldc.i4.s   56
    IL_0085:  shr
    IL_0086:  ldc.i4     0xff
    IL_008b:  conv.i8
    IL_008c:  and
    IL_008d:  conv.u1
    IL_008e:  call       instance void Avro.IO.BinaryEncoder::writeByte(uint8)
    IL_0093:  ret
  } // end of method BinaryEncoder::WriteDouble

  .method public hidebysig newslot virtual final 
          instance void  WriteBytes(uint8[] 'value') cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldlen
    IL_0003:  conv.i4
    IL_0004:  conv.i8
    IL_0005:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_000a:  ldarg.0
    IL_000b:  ldarg.1
    IL_000c:  call       instance void Avro.IO.BinaryEncoder::writeBytes(uint8[])
    IL_0011:  ret
  } // end of method BinaryEncoder::WriteBytes

  .method public hidebysig newslot virtual final 
          instance void  WriteStream(class [mscorlib]System.IO.Stream byteStream) cil managed
  {
    // Code size       25 (0x19)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance int64 [mscorlib]System.IO.Stream::get_Length()
    IL_0007:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_000c:  ldarg.1
    IL_000d:  ldarg.0
    IL_000e:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryEncoder::_stream
    IL_0013:  callvirt   instance void [mscorlib]System.IO.Stream::CopyTo(class [mscorlib]System.IO.Stream)
    IL_0018:  ret
  } // end of method BinaryEncoder::WriteStream

  .method public hidebysig newslot virtual final 
          instance void  WriteString(string 'value') cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_000c:  call       instance void Avro.IO.BinaryEncoder::WriteBytes(uint8[])
    IL_0011:  ret
  } // end of method BinaryEncoder::WriteString

  .method public hidebysig newslot virtual final 
          instance void  WriteEnum(int32 'value') cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  conv.i8
    IL_0003:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_0008:  ret
  } // end of method BinaryEncoder::WriteEnum

  .method public hidebysig newslot virtual final 
          instance void  StartItem() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method BinaryEncoder::StartItem

  .method public hidebysig newslot virtual final 
          instance void  SetItemCount(int64 'value') cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldc.i4.0
    IL_0002:  conv.i8
    IL_0003:  ble.s      IL_000c

    IL_0005:  ldarg.0
    IL_0006:  ldarg.1
    IL_0007:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_000c:  ret
  } // end of method BinaryEncoder::SetItemCount

  .method public hidebysig newslot virtual final 
          instance void  WriteArrayStart() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method BinaryEncoder::WriteArrayStart

  .method public hidebysig newslot virtual final 
          instance void  WriteArrayEnd() cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  conv.i8
    IL_0003:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_0008:  ret
  } // end of method BinaryEncoder::WriteArrayEnd

  .method public hidebysig newslot virtual final 
          instance void  WriteMapStart() cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method BinaryEncoder::WriteMapStart

  .method public hidebysig newslot virtual final 
          instance void  WriteMapEnd() cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.0
    IL_0002:  conv.i8
    IL_0003:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_0008:  ret
  } // end of method BinaryEncoder::WriteMapEnd

  .method public hidebysig newslot virtual final 
          instance void  WriteUnionIndex(int32 'value') cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  conv.i8
    IL_0003:  call       instance void Avro.IO.BinaryEncoder::WriteLong(int64)
    IL_0008:  ret
  } // end of method BinaryEncoder::WriteUnionIndex

  .method public hidebysig newslot virtual final 
          instance void  WriteFixed(uint8[] data) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldc.i4.0
    IL_0003:  ldarg.1
    IL_0004:  ldlen
    IL_0005:  conv.i4
    IL_0006:  call       instance void Avro.IO.BinaryEncoder::WriteFixed(uint8[],
                                                                         int32,
                                                                         int32)
    IL_000b:  ret
  } // end of method BinaryEncoder::WriteFixed

  .method public hidebysig newslot virtual final 
          instance void  WriteFixed(uint8[] data,
                                    int32 start,
                                    int32 len) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryEncoder::_stream
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  ldarg.3
    IL_0009:  callvirt   instance void [mscorlib]System.IO.Stream::Write(uint8[],
                                                                         int32,
                                                                         int32)
    IL_000e:  ret
  } // end of method BinaryEncoder::WriteFixed

  .method private hidebysig instance void 
          writeBytes(uint8[] bytes) cil managed
  {
    // Code size       17 (0x11)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryEncoder::_stream
    IL_0006:  ldarg.1
    IL_0007:  ldc.i4.0
    IL_0008:  ldarg.1
    IL_0009:  ldlen
    IL_000a:  conv.i4
    IL_000b:  callvirt   instance void [mscorlib]System.IO.Stream::Write(uint8[],
                                                                         int32,
                                                                         int32)
    IL_0010:  ret
  } // end of method BinaryEncoder::writeBytes

  .method private hidebysig instance void 
          writeByte(uint8 b) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.IO.Stream Avro.IO.BinaryEncoder::_stream
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance void [mscorlib]System.IO.Stream::WriteByte(uint8)
    IL_000c:  ret
  } // end of method BinaryEncoder::writeByte

} // end of class Avro.IO.BinaryEncoder

.class private abstract auto ansi sealed beforefieldinit Avro.IO.Resolver
       extends [mscorlib]System.Object
{
  .method public hidebysig static void  EncodeDefaultValue(class Avro.IO.Encoder enc,
                                                           class Avro.Schema schema,
                                                           class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok) cil managed
  {
    // Code size       1260 (0x4ec)
    .maxstack  3
    .locals init (class [mscorlib]System.Text.Encoding V_0,
             int32 V_1,
             uint8[] V_2,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray V_3,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_4,
             class Avro.RecordSchema V_5,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject V_6,
             class Avro.Field V_7,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_8,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_9,
             valuetype Avro.Schema/Type V_10,
             object[] V_11,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_12,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_13,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>> V_14)
    IL_0000:  ldarg.2
    IL_0001:  brtrue.s   IL_0004

    IL_0003:  ret

    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000a:  stloc.s    V_10
    IL_000c:  ldloc.s    V_10
    IL_000e:  switch     ( 
                          IL_02b6,
                          IL_0054,
                          IL_0086,
                          IL_00bc,
                          IL_00f2,
                          IL_0124,
                          IL_0176,
                          IL_0249,
                          IL_036a,
                          IL_027a,
                          IL_02e2,
                          IL_0413,
                          IL_04b0,
                          IL_01b8,
                          IL_036a)
    IL_004f:  br         IL_04d0

    IL_0054:  ldarg.2
    IL_0055:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_005a:  ldc.i4.s   9
    IL_005c:  beq.s      IL_0079

    IL_005e:  ldstr      "Default boolean value "
    IL_0063:  ldarg.2
    IL_0064:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0069:  ldstr      " is invalid, expected is json boolean."
    IL_006e:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0073:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0078:  throw

    IL_0079:  ldarg.0
    IL_007a:  ldarg.2
    IL_007b:  call       bool [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0080:  callvirt   instance void Avro.IO.Encoder::WriteBoolean(bool)
    IL_0085:  ret

    IL_0086:  ldarg.2
    IL_0087:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_008c:  ldc.i4.6
    IL_008d:  beq.s      IL_00aa

    IL_008f:  ldstr      "Default int value "
    IL_0094:  ldarg.2
    IL_0095:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_009a:  ldstr      " is invalid, expected is json integer."
    IL_009f:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_00a4:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_00a9:  throw

    IL_00aa:  ldarg.0
    IL_00ab:  ldarg.2
    IL_00ac:  call       int32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_00b1:  call       int32 [mscorlib]System.Convert::ToInt32(int32)
    IL_00b6:  callvirt   instance void Avro.IO.Encoder::WriteInt(int32)
    IL_00bb:  ret

    IL_00bc:  ldarg.2
    IL_00bd:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_00c2:  ldc.i4.6
    IL_00c3:  beq.s      IL_00e0

    IL_00c5:  ldstr      "Default long value "
    IL_00ca:  ldarg.2
    IL_00cb:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00d0:  ldstr      " is invalid, expected is json integer."
    IL_00d5:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_00da:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_00df:  throw

    IL_00e0:  ldarg.0
    IL_00e1:  ldarg.2
    IL_00e2:  call       int64 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_00e7:  call       int64 [mscorlib]System.Convert::ToInt64(int64)
    IL_00ec:  callvirt   instance void Avro.IO.Encoder::WriteLong(int64)
    IL_00f1:  ret

    IL_00f2:  ldarg.2
    IL_00f3:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_00f8:  ldc.i4.7
    IL_00f9:  beq.s      IL_0116

    IL_00fb:  ldstr      "Default float value "
    IL_0100:  ldarg.2
    IL_0101:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0106:  ldstr      " is invalid, expected is json number."
    IL_010b:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0110:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0115:  throw

    IL_0116:  ldarg.0
    IL_0117:  ldarg.2
    IL_0118:  call       float32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_011d:  conv.r4
    IL_011e:  callvirt   instance void Avro.IO.Encoder::WriteFloat(float32)
    IL_0123:  ret

    IL_0124:  ldarg.2
    IL_0125:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_012a:  ldc.i4.6
    IL_012b:  bne.un.s   IL_013f

    IL_012d:  ldarg.0
    IL_012e:  ldarg.2
    IL_012f:  call       int32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0134:  call       float64 [mscorlib]System.Convert::ToDouble(int32)
    IL_0139:  callvirt   instance void Avro.IO.Encoder::WriteDouble(float64)
    IL_013e:  ret

    IL_013f:  ldarg.2
    IL_0140:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0145:  ldc.i4.7
    IL_0146:  bne.un.s   IL_015b

    IL_0148:  ldarg.0
    IL_0149:  ldarg.2
    IL_014a:  call       float32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_014f:  conv.r4
    IL_0150:  call       float64 [mscorlib]System.Convert::ToDouble(float32)
    IL_0155:  callvirt   instance void Avro.IO.Encoder::WriteDouble(float64)
    IL_015a:  ret

    IL_015b:  ldstr      "Default double value "
    IL_0160:  ldarg.2
    IL_0161:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0166:  ldstr      " is invalid, expected is json number."
    IL_016b:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0170:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0175:  throw

    IL_0176:  ldarg.2
    IL_0177:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_017c:  ldc.i4.8
    IL_017d:  beq.s      IL_019a

    IL_017f:  ldstr      "Default bytes value "
    IL_0184:  ldarg.2
    IL_0185:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_018a:  ldstr      " is invalid, expected is json string."
    IL_018f:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0194:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0199:  throw

    IL_019a:  ldstr      "iso-8859-1"
    IL_019f:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::GetEncoding(string)
    IL_01a4:  stloc.0
    IL_01a5:  ldarg.0
    IL_01a6:  ldloc.0
    IL_01a7:  ldarg.2
    IL_01a8:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_01ad:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_01b2:  callvirt   instance void Avro.IO.Encoder::WriteBytes(uint8[])
    IL_01b7:  ret

    IL_01b8:  ldarg.2
    IL_01b9:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_01be:  ldc.i4.8
    IL_01bf:  beq.s      IL_01dc

    IL_01c1:  ldstr      "Default fixed value "
    IL_01c6:  ldarg.2
    IL_01c7:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_01cc:  ldstr      " is invalid, expected is json string."
    IL_01d1:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_01d6:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_01db:  throw

    IL_01dc:  ldstr      "iso-8859-1"
    IL_01e1:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::GetEncoding(string)
    IL_01e6:  stloc.0
    IL_01e7:  ldarg.1
    IL_01e8:  isinst     Avro.FixedSchema
    IL_01ed:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_01f2:  stloc.1
    IL_01f3:  ldloc.0
    IL_01f4:  ldarg.2
    IL_01f5:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_01fa:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_01ff:  stloc.2
    IL_0200:  ldloc.2
    IL_0201:  ldlen
    IL_0202:  conv.i4
    IL_0203:  ldloc.1
    IL_0204:  beq.s      IL_0241

    IL_0206:  ldc.i4.4
    IL_0207:  newarr     [mscorlib]System.Object
    IL_020c:  stloc.s    V_11
    IL_020e:  ldloc.s    V_11
    IL_0210:  ldc.i4.0
    IL_0211:  ldstr      "Default fixed value "
    IL_0216:  stelem.ref
    IL_0217:  ldloc.s    V_11
    IL_0219:  ldc.i4.1
    IL_021a:  ldarg.2
    IL_021b:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0220:  stelem.ref
    IL_0221:  ldloc.s    V_11
    IL_0223:  ldc.i4.2
    IL_0224:  ldstr      " is not of expected length "
    IL_0229:  stelem.ref
    IL_022a:  ldloc.s    V_11
    IL_022c:  ldc.i4.3
    IL_022d:  ldloc.1
    IL_022e:  box        [mscorlib]System.Int32
    IL_0233:  stelem.ref
    IL_0234:  ldloc.s    V_11
    IL_0236:  call       string [mscorlib]System.String::Concat(object[])
    IL_023b:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0240:  throw

    IL_0241:  ldarg.0
    IL_0242:  ldloc.2
    IL_0243:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0248:  ret

    IL_0249:  ldarg.2
    IL_024a:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_024f:  ldc.i4.8
    IL_0250:  beq.s      IL_026d

    IL_0252:  ldstr      "Default string value "
    IL_0257:  ldarg.2
    IL_0258:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_025d:  ldstr      " is invalid, expected is json string."
    IL_0262:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0267:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_026c:  throw

    IL_026d:  ldarg.0
    IL_026e:  ldarg.2
    IL_026f:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0274:  callvirt   instance void Avro.IO.Encoder::WriteString(string)
    IL_0279:  ret

    IL_027a:  ldarg.2
    IL_027b:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0280:  ldc.i4.8
    IL_0281:  beq.s      IL_029e

    IL_0283:  ldstr      "Default enum value "
    IL_0288:  ldarg.2
    IL_0289:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_028e:  ldstr      " is invalid, expected is json string."
    IL_0293:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0298:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_029d:  throw

    IL_029e:  ldarg.0
    IL_029f:  ldarg.1
    IL_02a0:  isinst     Avro.EnumSchema
    IL_02a5:  ldarg.2
    IL_02a6:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_02ab:  callvirt   instance int32 Avro.EnumSchema::Ordinal(string)
    IL_02b0:  callvirt   instance void Avro.IO.Encoder::WriteEnum(int32)
    IL_02b5:  ret

    IL_02b6:  ldarg.2
    IL_02b7:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_02bc:  ldc.i4.s   10
    IL_02be:  beq.s      IL_02db

    IL_02c0:  ldstr      "Default null value "
    IL_02c5:  ldarg.2
    IL_02c6:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_02cb:  ldstr      " is invalid, expected is json null."
    IL_02d0:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_02d5:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_02da:  throw

    IL_02db:  ldarg.0
    IL_02dc:  callvirt   instance void Avro.IO.Encoder::WriteNull()
    IL_02e1:  ret

    IL_02e2:  ldarg.2
    IL_02e3:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_02e8:  ldc.i4.2
    IL_02e9:  beq.s      IL_0306

    IL_02eb:  ldstr      "Default array value "
    IL_02f0:  ldarg.2
    IL_02f1:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_02f6:  ldstr      " is invalid, expected is json array."
    IL_02fb:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0300:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0305:  throw

    IL_0306:  ldarg.2
    IL_0307:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_030c:  stloc.3
    IL_030d:  ldarg.0
    IL_030e:  callvirt   instance void Avro.IO.Encoder::WriteArrayStart()
    IL_0313:  ldarg.0
    IL_0314:  ldloc.3
    IL_0315:  callvirt   instance int32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JContainer::get_Count()
    IL_031a:  conv.i8
    IL_031b:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_0320:  ldloc.3
    IL_0321:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0326:  stloc.s    V_12
    .try
    {
      IL_0328:  br.s       IL_034c

      IL_032a:  ldloc.s    V_12
      IL_032c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_0331:  stloc.s    V_4
      IL_0333:  ldarg.0
      IL_0334:  callvirt   instance void Avro.IO.Encoder::StartItem()
      IL_0339:  ldarg.0
      IL_033a:  ldarg.1
      IL_033b:  isinst     Avro.ArraySchema
      IL_0340:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
      IL_0345:  ldloc.s    V_4
      IL_0347:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                     class Avro.Schema,
                                                                     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_034c:  ldloc.s    V_12
      IL_034e:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0353:  brtrue.s   IL_032a

      IL_0355:  leave.s    IL_0363

    }  // end .try
    finally
    {
      IL_0357:  ldloc.s    V_12
      IL_0359:  brfalse.s  IL_0362

      IL_035b:  ldloc.s    V_12
      IL_035d:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0362:  endfinally
    }  // end handler
    IL_0363:  ldarg.0
    IL_0364:  callvirt   instance void Avro.IO.Encoder::WriteArrayEnd()
    IL_0369:  ret

    IL_036a:  ldarg.2
    IL_036b:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0370:  ldc.i4.1
    IL_0371:  beq.s      IL_038e

    IL_0373:  ldstr      "Default record value "
    IL_0378:  ldarg.2
    IL_0379:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_037e:  ldstr      " is invalid, expected is json object."
    IL_0383:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0388:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_038d:  throw

    IL_038e:  ldarg.1
    IL_038f:  isinst     Avro.RecordSchema
    IL_0394:  stloc.s    V_5
    IL_0396:  ldarg.2
    IL_0397:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_039c:  stloc.s    V_6
    IL_039e:  ldloc.s    V_5
    IL_03a0:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_03a5:  stloc.s    V_13
    .try
    {
      IL_03a7:  br.s       IL_03f9

      IL_03a9:  ldloc.s    V_13
      IL_03ab:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_03b0:  stloc.s    V_7
      IL_03b2:  ldloc.s    V_6
      IL_03b4:  ldloc.s    V_7
      IL_03b6:  ldfld      string Avro.Field::Name
      IL_03bb:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::get_Item(string)
      IL_03c0:  stloc.s    V_8
      IL_03c2:  ldloc.s    V_8
      IL_03c4:  brtrue.s   IL_03cf

      IL_03c6:  ldloc.s    V_7
      IL_03c8:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
      IL_03cd:  stloc.s    V_8
      IL_03cf:  ldloc.s    V_8
      IL_03d1:  brtrue.s   IL_03ea

      IL_03d3:  ldstr      "No default value for field "
      IL_03d8:  ldloc.s    V_7
      IL_03da:  ldfld      string Avro.Field::Name
      IL_03df:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_03e4:  newobj     instance void Avro.AvroException::.ctor(string)
      IL_03e9:  throw

      IL_03ea:  ldarg.0
      IL_03eb:  ldloc.s    V_7
      IL_03ed:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_03f2:  ldloc.s    V_8
      IL_03f4:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                     class Avro.Schema,
                                                                     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_03f9:  ldloc.s    V_13
      IL_03fb:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0400:  brtrue.s   IL_03a9

      IL_0402:  leave      IL_04eb

    }  // end .try
    finally
    {
      IL_0407:  ldloc.s    V_13
      IL_0409:  brfalse.s  IL_0412

      IL_040b:  ldloc.s    V_13
      IL_040d:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0412:  endfinally
    }  // end handler
    IL_0413:  ldarg.2
    IL_0414:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0419:  ldc.i4.1
    IL_041a:  beq.s      IL_0437

    IL_041c:  ldstr      "Default map value "
    IL_0421:  ldarg.2
    IL_0422:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0427:  ldstr      " is invalid, expected is json object."
    IL_042c:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0431:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0436:  throw

    IL_0437:  ldarg.2
    IL_0438:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_043d:  stloc.s    V_6
    IL_043f:  ldarg.0
    IL_0440:  callvirt   instance void Avro.IO.Encoder::WriteMapStart()
    IL_0445:  ldarg.0
    IL_0446:  ldloc.s    V_6
    IL_0448:  callvirt   instance int32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JContainer::get_Count()
    IL_044d:  conv.i8
    IL_044e:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_0453:  ldloc.s    V_6
    IL_0455:  callvirt   instance class [mscorlib_4]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib_4]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>> [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::GetEnumerator()
    IL_045a:  stloc.s    V_14
    .try
    {
      IL_045c:  br.s       IL_0492

      IL_045e:  ldloc.s    V_14
      IL_0460:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>>::get_Current()
      IL_0465:  stloc.s    V_9
      IL_0467:  ldarg.0
      IL_0468:  callvirt   instance void Avro.IO.Encoder::StartItem()
      IL_046d:  ldarg.0
      IL_046e:  ldloca.s   V_9
      IL_0470:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Key()
      IL_0475:  callvirt   instance void Avro.IO.Encoder::WriteString(string)
      IL_047a:  ldarg.0
      IL_047b:  ldarg.1
      IL_047c:  isinst     Avro.MapSchema
      IL_0481:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
      IL_0486:  ldloca.s   V_9
      IL_0488:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Value()
      IL_048d:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                     class Avro.Schema,
                                                                     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_0492:  ldloc.s    V_14
      IL_0494:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0499:  brtrue.s   IL_045e

      IL_049b:  leave.s    IL_04a9

    }  // end .try
    finally
    {
      IL_049d:  ldloc.s    V_14
      IL_049f:  brfalse.s  IL_04a8

      IL_04a1:  ldloc.s    V_14
      IL_04a3:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_04a8:  endfinally
    }  // end handler
    IL_04a9:  ldarg.0
    IL_04aa:  callvirt   instance void Avro.IO.Encoder::WriteMapEnd()
    IL_04af:  ret

    IL_04b0:  ldarg.0
    IL_04b1:  ldc.i4.0
    IL_04b2:  callvirt   instance void Avro.IO.Encoder::WriteUnionIndex(int32)
    IL_04b7:  ldarg.0
    IL_04b8:  ldarg.1
    IL_04b9:  isinst     Avro.UnionSchema
    IL_04be:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_04c3:  ldc.i4.0
    IL_04c4:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>::get_Item(int32)
    IL_04c9:  ldarg.2
    IL_04ca:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                   class Avro.Schema,
                                                                   class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_04cf:  ret

    IL_04d0:  ldstr      "Unsupported schema type "
    IL_04d5:  ldarg.1
    IL_04d6:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_04db:  box        Avro.Schema/Type
    IL_04e0:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_04e5:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_04ea:  throw

    IL_04eb:  ret
  } // end of method Resolver::EncodeDefaultValue

} // end of class Avro.IO.Resolver

.class public auto ansi beforefieldinit Avro.Message
       extends [mscorlib]System.Object
{
  .field private string '<Name>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<Doc>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.RecordSchema '<Request>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.Schema '<Response>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.UnionSchema '<Error>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private valuetype [mscorlib]System.Nullable`1<bool> '<Oneway>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance string 
          get_Name() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Message::'<Name>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Name

  .method public hidebysig specialname instance void 
          set_Name(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Message::'<Name>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Name

  .method public hidebysig specialname instance string 
          get_Doc() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Message::'<Doc>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Doc

  .method public hidebysig specialname instance void 
          set_Doc(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Message::'<Doc>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Doc

  .method public hidebysig specialname instance class Avro.RecordSchema 
          get_Request() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.RecordSchema Avro.Message::'<Request>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Request

  .method public hidebysig specialname instance void 
          set_Request(class Avro.RecordSchema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.RecordSchema Avro.Message::'<Request>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Request

  .method public hidebysig specialname instance class Avro.Schema 
          get_Response() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.Message::'<Response>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Response

  .method public hidebysig specialname instance void 
          set_Response(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.Message::'<Response>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Response

  .method public hidebysig specialname instance class Avro.UnionSchema 
          get_Error() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.UnionSchema Avro.Message::'<Error>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Error

  .method public hidebysig specialname instance void 
          set_Error(class Avro.UnionSchema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.UnionSchema Avro.Message::'<Error>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Error

  .method public hidebysig specialname instance valuetype [mscorlib]System.Nullable`1<bool> 
          get_Oneway() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [mscorlib]System.Nullable`1<bool> Avro.Message::'<Oneway>k__BackingField'
    IL_0006:  ret
  } // end of method Message::get_Oneway

  .method public hidebysig specialname instance void 
          set_Oneway(valuetype [mscorlib]System.Nullable`1<bool> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype [mscorlib]System.Nullable`1<bool> Avro.Message::'<Oneway>k__BackingField'
    IL_0007:  ret
  } // end of method Message::set_Oneway

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string name,
                               string doc,
                               class Avro.RecordSchema 'request',
                               class Avro.Schema response,
                               class Avro.UnionSchema 'error',
                               valuetype [mscorlib]System.Nullable`1<bool> oneway) cil managed
  {
    // Code size       76 (0x4c)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.1
    IL_0007:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000c:  brfalse.s  IL_001e

    IL_000e:  ldstr      "name"
    IL_0013:  ldstr      "name cannot be null."
    IL_0018:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_001d:  throw

    IL_001e:  ldarg.0
    IL_001f:  ldarg.3
    IL_0020:  call       instance void Avro.Message::set_Request(class Avro.RecordSchema)
    IL_0025:  ldarg.0
    IL_0026:  ldarg.s    response
    IL_0028:  call       instance void Avro.Message::set_Response(class Avro.Schema)
    IL_002d:  ldarg.0
    IL_002e:  ldarg.s    'error'
    IL_0030:  call       instance void Avro.Message::set_Error(class Avro.UnionSchema)
    IL_0035:  ldarg.0
    IL_0036:  ldarg.1
    IL_0037:  call       instance void Avro.Message::set_Name(string)
    IL_003c:  ldarg.0
    IL_003d:  ldarg.2
    IL_003e:  call       instance void Avro.Message::set_Doc(string)
    IL_0043:  ldarg.0
    IL_0044:  ldarg.s    oneway
    IL_0046:  call       instance void Avro.Message::set_Oneway(valuetype [mscorlib]System.Nullable`1<bool>)
    IL_004b:  ret
  } // end of method Message::.ctor

  .method assembly hidebysig static class Avro.Message 
          Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty jmessage,
                class Avro.SchemaNames names,
                string encspace) cil managed
  {
    // Code size       184 (0xb8)
    .maxstack  6
    .locals init (string V_0,
             string V_1,
             valuetype [mscorlib]System.Nullable`1<bool> V_2,
             class Avro.PropertyMap V_3,
             class Avro.RecordSchema V_4,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_5,
             class Avro.Schema V_6,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_7,
             class Avro.UnionSchema V_8,
             class Avro.Schema V_9)
    IL_0000:  ldarg.0
    IL_0001:  callvirt   instance string [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Name()
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_000d:  ldstr      "doc"
    IL_0012:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0017:  stloc.1
    IL_0018:  ldarg.0
    IL_0019:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_001e:  ldstr      "one-way"
    IL_0023:  call       valuetype [mscorlib]System.Nullable`1<bool> Avro.JsonHelper::GetOptionalBoolean(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                                         string)
    IL_0028:  stloc.2
    IL_0029:  ldarg.0
    IL_002a:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_002f:  call       class Avro.PropertyMap Avro.Schema::GetProperties(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0034:  stloc.3
    IL_0035:  ldc.i4.8
    IL_0036:  ldarg.0
    IL_0037:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_003c:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_0041:  ldloc.3
    IL_0042:  ldarg.1
    IL_0043:  ldarg.2
    IL_0044:  call       class Avro.RecordSchema Avro.RecordSchema::NewInstance(valuetype Avro.Schema/Type,
                                                                                class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                class Avro.PropertyMap,
                                                                                class Avro.SchemaNames,
                                                                                string)
    IL_0049:  stloc.s    V_4
    IL_004b:  ldarg.0
    IL_004c:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_0051:  ldstr      "response"
    IL_0056:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_005b:  stloc.s    V_5
    IL_005d:  ldloc.s    V_5
    IL_005f:  ldarg.1
    IL_0060:  ldarg.2
    IL_0061:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_0066:  stloc.s    V_6
    IL_0068:  ldarg.0
    IL_0069:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
    IL_006e:  ldstr      "errors"
    IL_0073:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0078:  stloc.s    V_7
    IL_007a:  ldnull
    IL_007b:  stloc.s    V_8
    IL_007d:  ldloc.s    V_7
    IL_007f:  brfalse.s  IL_00a9

    IL_0081:  ldloc.s    V_7
    IL_0083:  ldarg.1
    IL_0084:  ldarg.2
    IL_0085:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_008a:  stloc.s    V_9
    IL_008c:  ldloc.s    V_9
    IL_008e:  isinst     Avro.UnionSchema
    IL_0093:  brtrue.s   IL_00a0

    IL_0095:  ldstr      ""
    IL_009a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_009f:  throw

    IL_00a0:  ldloc.s    V_9
    IL_00a2:  isinst     Avro.UnionSchema
    IL_00a7:  stloc.s    V_8
    IL_00a9:  ldloc.0
    IL_00aa:  ldloc.1
    IL_00ab:  ldloc.s    V_4
    IL_00ad:  ldloc.s    V_6
    IL_00af:  ldloc.s    V_8
    IL_00b1:  ldloc.2
    IL_00b2:  newobj     instance void Avro.Message::.ctor(string,
                                                           string,
                                                           class Avro.RecordSchema,
                                                           class Avro.Schema,
                                                           class Avro.UnionSchema,
                                                           valuetype [mscorlib]System.Nullable`1<bool>)
    IL_00b7:  ret
  } // end of method Message::Parse

  .method assembly hidebysig instance void 
          writeJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       157 (0x9d)
    .maxstack  4
    .locals init (valuetype [mscorlib]System.Nullable`1<bool> V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0006:  ldarg.1
    IL_0007:  ldstr      "doc"
    IL_000c:  ldarg.0
    IL_000d:  call       instance string Avro.Message::get_Doc()
    IL_0012:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0017:  ldarg.0
    IL_0018:  call       instance class Avro.RecordSchema Avro.Message::get_Request()
    IL_001d:  brfalse.s  IL_002d

    IL_001f:  ldarg.0
    IL_0020:  call       instance class Avro.RecordSchema Avro.Message::get_Request()
    IL_0025:  ldarg.1
    IL_0026:  ldarg.2
    IL_0027:  ldnull
    IL_0028:  callvirt   instance void Avro.Schema::WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                    class Avro.SchemaNames,
                                                                    string)
    IL_002d:  ldarg.0
    IL_002e:  call       instance class Avro.Schema Avro.Message::get_Response()
    IL_0033:  brfalse.s  IL_004e

    IL_0035:  ldarg.1
    IL_0036:  ldstr      "response"
    IL_003b:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0040:  ldarg.0
    IL_0041:  call       instance class Avro.Schema Avro.Message::get_Response()
    IL_0046:  ldarg.1
    IL_0047:  ldarg.2
    IL_0048:  ldarg.3
    IL_0049:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_004e:  ldarg.0
    IL_004f:  call       instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_0054:  brfalse.s  IL_006f

    IL_0056:  ldarg.1
    IL_0057:  ldstr      "errors"
    IL_005c:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0061:  ldarg.0
    IL_0062:  call       instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_0067:  ldarg.1
    IL_0068:  ldarg.2
    IL_0069:  ldarg.3
    IL_006a:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_006f:  ldarg.0
    IL_0070:  call       instance valuetype [mscorlib]System.Nullable`1<bool> Avro.Message::get_Oneway()
    IL_0075:  stloc.0
    IL_0076:  ldloca.s   V_0
    IL_0078:  call       instance bool valuetype [mscorlib]System.Nullable`1<bool>::get_HasValue()
    IL_007d:  brfalse.s  IL_0096

    IL_007f:  ldarg.1
    IL_0080:  ldstr      "one-way"
    IL_0085:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_008a:  ldarg.1
    IL_008b:  ldarg.0
    IL_008c:  call       instance valuetype [mscorlib]System.Nullable`1<bool> Avro.Message::get_Oneway()
    IL_0091:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(valuetype [mscorlib_4]System.Nullable`1<bool>)
    IL_0096:  ldarg.1
    IL_0097:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_009c:  ret
  } // end of method Message::writeJson

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       100 (0x64)
    .maxstack  2
    .locals init (class Avro.Message V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  isinst     Avro.Message
    IL_000c:  brtrue.s   IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.Message
    IL_0016:  stloc.0
    IL_0017:  ldarg.0
    IL_0018:  call       instance string Avro.Message::get_Name()
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance string Avro.Message::get_Name()
    IL_0023:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_0028:  brfalse.s  IL_0062

    IL_002a:  ldarg.0
    IL_002b:  call       instance class Avro.RecordSchema Avro.Message::get_Request()
    IL_0030:  ldloc.0
    IL_0031:  callvirt   instance class Avro.RecordSchema Avro.Message::get_Request()
    IL_0036:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_003b:  brfalse.s  IL_0062

    IL_003d:  ldarg.0
    IL_003e:  call       instance class Avro.Schema Avro.Message::get_Response()
    IL_0043:  ldloc.0
    IL_0044:  callvirt   instance class Avro.Schema Avro.Message::get_Response()
    IL_0049:  call       bool Avro.Message::areEqual(object,
                                                     object)
    IL_004e:  brfalse.s  IL_0062

    IL_0050:  ldarg.0
    IL_0051:  call       instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_0056:  ldloc.0
    IL_0057:  callvirt   instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_005c:  call       bool Avro.Message::areEqual(object,
                                                     object)
    IL_0061:  ret

    IL_0062:  ldc.i4.0
    IL_0063:  ret
  } // end of method Message::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       70 (0x46)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.Message::get_Name()
    IL_0006:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000b:  ldarg.0
    IL_000c:  call       instance class Avro.RecordSchema Avro.Message::get_Request()
    IL_0011:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0016:  add
    IL_0017:  ldarg.0
    IL_0018:  call       instance class Avro.Schema Avro.Message::get_Response()
    IL_001d:  brfalse.s  IL_002c

    IL_001f:  ldarg.0
    IL_0020:  call       instance class Avro.Schema Avro.Message::get_Response()
    IL_0025:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_002a:  br.s       IL_002d

    IL_002c:  ldc.i4.0
    IL_002d:  add
    IL_002e:  ldarg.0
    IL_002f:  call       instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_0034:  brfalse.s  IL_0043

    IL_0036:  ldarg.0
    IL_0037:  call       instance class Avro.UnionSchema Avro.Message::get_Error()
    IL_003c:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0041:  br.s       IL_0044

    IL_0043:  ldc.i4.0
    IL_0044:  add
    IL_0045:  ret
  } // end of method Message::GetHashCode

  .method family hidebysig static bool  areEqual(object o1,
                                                 object o2) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.0
    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_000a:  ret

    IL_000b:  ldarg.1
    IL_000c:  ldnull
    IL_000d:  ceq
    IL_000f:  ret
  } // end of method Message::areEqual

  .property instance string Name()
  {
    .get instance string Avro.Message::get_Name()
    .set instance void Avro.Message::set_Name(string)
  } // end of property Message::Name
  .property instance string Doc()
  {
    .get instance string Avro.Message::get_Doc()
    .set instance void Avro.Message::set_Doc(string)
  } // end of property Message::Doc
  .property instance class Avro.RecordSchema
          Request()
  {
    .get instance class Avro.RecordSchema Avro.Message::get_Request()
    .set instance void Avro.Message::set_Request(class Avro.RecordSchema)
  } // end of property Message::Request
  .property instance class Avro.Schema Response()
  {
    .set instance void Avro.Message::set_Response(class Avro.Schema)
    .get instance class Avro.Schema Avro.Message::get_Response()
  } // end of property Message::Response
  .property instance class Avro.UnionSchema
          Error()
  {
    .get instance class Avro.UnionSchema Avro.Message::get_Error()
    .set instance void Avro.Message::set_Error(class Avro.UnionSchema)
  } // end of property Message::Error
  .property instance valuetype [mscorlib]System.Nullable`1<bool>
          Oneway()
  {
    .set instance void Avro.Message::set_Oneway(valuetype [mscorlib]System.Nullable`1<bool>)
    .get instance valuetype [mscorlib]System.Nullable`1<bool> Avro.Message::get_Oneway()
  } // end of property Message::Oneway
} // end of class Avro.Message

.class public auto ansi beforefieldinit Avro.Protocol
       extends [mscorlib]System.Object
{
  .field private uint8[] md5
  .field private string '<Name>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<Namespace>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<Doc>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> '<Types>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> '<Messages>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance string 
          get_Name() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Protocol::'<Name>k__BackingField'
    IL_0006:  ret
  } // end of method Protocol::get_Name

  .method public hidebysig specialname instance void 
          set_Name(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Protocol::'<Name>k__BackingField'
    IL_0007:  ret
  } // end of method Protocol::set_Name

  .method public hidebysig specialname instance string 
          get_Namespace() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Protocol::'<Namespace>k__BackingField'
    IL_0006:  ret
  } // end of method Protocol::get_Namespace

  .method public hidebysig specialname instance void 
          set_Namespace(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Protocol::'<Namespace>k__BackingField'
    IL_0007:  ret
  } // end of method Protocol::set_Namespace

  .method public hidebysig specialname instance string 
          get_Doc() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Protocol::'<Doc>k__BackingField'
    IL_0006:  ret
  } // end of method Protocol::get_Doc

  .method public hidebysig specialname instance void 
          set_Doc(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Protocol::'<Doc>k__BackingField'
    IL_0007:  ret
  } // end of method Protocol::set_Doc

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 
          get_Types() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::'<Types>k__BackingField'
    IL_0006:  ret
  } // end of method Protocol::get_Types

  .method public hidebysig specialname instance void 
          set_Types(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::'<Types>k__BackingField'
    IL_0007:  ret
  } // end of method Protocol::set_Types

  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> 
          get_Messages() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::'<Messages>k__BackingField'
    IL_0006:  ret
  } // end of method Protocol::get_Messages

  .method public hidebysig specialname instance void 
          set_Messages(class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::'<Messages>k__BackingField'
    IL_0007:  ret
  } // end of method Protocol::set_Messages

  .method public hidebysig specialname instance uint8[] 
          get_MD5() cil managed
  {
    // Code size       62 (0x3e)
    .maxstack  4
    .locals init (class [mscorlib]System.Exception V_0)
    .try
    {
      IL_0000:  ldarg.0
      IL_0001:  ldfld      uint8[] Avro.Protocol::md5
      IL_0006:  brtrue.s   IL_0028

      IL_0008:  ldarg.0
      IL_0009:  call       class [mscorlib]System.Security.Cryptography.MD5 [mscorlib]System.Security.Cryptography.MD5::Create()
      IL_000e:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
      IL_0013:  ldarg.0
      IL_0014:  callvirt   instance string [mscorlib]System.Object::ToString()
      IL_0019:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
      IL_001e:  callvirt   instance uint8[] [mscorlib]System.Security.Cryptography.HashAlgorithm::ComputeHash(uint8[])
      IL_0023:  stfld      uint8[] Avro.Protocol::md5
      IL_0028:  leave.s    IL_0037

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_002a:  stloc.0
      IL_002b:  ldstr      "MD5 get exception"
      IL_0030:  ldloc.0
      IL_0031:  newobj     instance void Avro.AvroRuntimeException::.ctor(string,
                                                                          class [mscorlib]System.Exception)
      IL_0036:  throw

    }  // end handler
    IL_0037:  ldarg.0
    IL_0038:  ldfld      uint8[] Avro.Protocol::md5
    IL_003d:  ret
  } // end of method Protocol::get_MD5

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string name,
                               string space,
                               string doc,
                               class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema> types,
                               class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> messages) cil managed
  {
    // Code size       118 (0x76)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.1
    IL_0007:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000c:  brfalse.s  IL_001e

    IL_000e:  ldstr      "name"
    IL_0013:  ldstr      "name cannot be null."
    IL_0018:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_001d:  throw

    IL_001e:  ldarg.s    types
    IL_0020:  brtrue.s   IL_0032

    IL_0022:  ldstr      "types"
    IL_0027:  ldstr      "types cannot be null."
    IL_002c:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0031:  throw

    IL_0032:  ldarg.s    messages
    IL_0034:  brtrue.s   IL_0046

    IL_0036:  ldstr      "messages"
    IL_003b:  ldstr      "messages cannot be null."
    IL_0040:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0045:  throw

    IL_0046:  ldarg.0
    IL_0047:  ldarg.1
    IL_0048:  call       instance void Avro.Protocol::set_Name(string)
    IL_004d:  ldarg.0
    IL_004e:  ldarg.2
    IL_004f:  call       instance void Avro.Protocol::set_Namespace(string)
    IL_0054:  ldarg.0
    IL_0055:  ldarg.3
    IL_0056:  call       instance void Avro.Protocol::set_Doc(string)
    IL_005b:  ldarg.0
    IL_005c:  ldarg.s    types
    IL_005e:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::.ctor(class [mscorlib]System.Collections.Generic.IEnumerable`1<!0>)
    IL_0063:  call       instance void Avro.Protocol::set_Types(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
    IL_0068:  ldarg.0
    IL_0069:  ldarg.s    messages
    IL_006b:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Message>::.ctor(class [mscorlib]System.Collections.Generic.IDictionary`2<!0,!1>)
    IL_0070:  call       instance void Avro.Protocol::set_Messages(class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>)
    IL_0075:  ret
  } // end of method Protocol::.ctor

  .method public hidebysig static class Avro.Protocol 
          Parse(string jstring) cil managed
  {
    // Code size       61 (0x3d)
    .maxstack  2
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0,
             class [mscorlib]System.Exception V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0018

    IL_0008:  ldstr      "json"
    IL_000d:  ldstr      "json cannot be null."
    IL_0012:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0017:  throw

    IL_0018:  ldnull
    IL_0019:  stloc.0
    .try
    {
      IL_001a:  ldarg.0
      IL_001b:  call       class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::Parse(string)
      IL_0020:  stloc.0
      IL_0021:  leave.s    IL_0036

    }  // end .try
    catch [mscorlib]System.Exception 
    {
      IL_0023:  stloc.1
      IL_0024:  ldstr      "Invalid JSON format: "
      IL_0029:  ldarg.0
      IL_002a:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_002f:  ldloc.1
      IL_0030:  newobj     instance void Avro.ProtocolParseException::.ctor(string,
                                                                            class [mscorlib]System.Exception)
      IL_0035:  throw

    }  // end handler
    IL_0036:  ldloc.0
    IL_0037:  call       class Avro.Protocol Avro.Protocol::Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_003c:  ret
  } // end of method Protocol::Parse

  .method private hidebysig static class Avro.Protocol 
          Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok) cil managed
  {
    // Code size       246 (0xf6)
    .maxstack  5
    .locals init (string V_0,
             string V_1,
             string V_2,
             class Avro.SchemaNames V_3,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_4,
             class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema> V_5,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_6,
             class Avro.Schema V_7,
             class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Message> V_8,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_9,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty V_10,
             class Avro.Message V_11,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_12,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_13)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "protocol"
    IL_0006:  call       string Avro.JsonHelper::GetRequiredString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  ldstr      "namespace"
    IL_0012:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0017:  stloc.1
    IL_0018:  ldarg.0
    IL_0019:  ldstr      "doc"
    IL_001e:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0023:  stloc.2
    IL_0024:  newobj     instance void Avro.SchemaNames::.ctor()
    IL_0029:  stloc.3
    IL_002a:  ldarg.0
    IL_002b:  ldstr      "types"
    IL_0030:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0035:  stloc.s    V_4
    IL_0037:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::.ctor()
    IL_003c:  stloc.s    V_5
    IL_003e:  ldloc.s    V_4
    IL_0040:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_0045:  brfalse.s  IL_0086

    IL_0047:  ldloc.s    V_4
    IL_0049:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_004e:  stloc.s    V_12
    .try
    {
      IL_0050:  br.s       IL_006f

      IL_0052:  ldloc.s    V_12
      IL_0054:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_0059:  stloc.s    V_6
      IL_005b:  ldloc.s    V_6
      IL_005d:  ldloc.3
      IL_005e:  ldloc.1
      IL_005f:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                    class Avro.SchemaNames,
                                                                    string)
      IL_0064:  stloc.s    V_7
      IL_0066:  ldloc.s    V_5
      IL_0068:  ldloc.s    V_7
      IL_006a:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::Add(!0)
      IL_006f:  ldloc.s    V_12
      IL_0071:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0076:  brtrue.s   IL_0052

      IL_0078:  leave.s    IL_0086

    }  // end .try
    finally
    {
      IL_007a:  ldloc.s    V_12
      IL_007c:  brfalse.s  IL_0085

      IL_007e:  ldloc.s    V_12
      IL_0080:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0085:  endfinally
    }  // end handler
    IL_0086:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Message>::.ctor()
    IL_008b:  stloc.s    V_8
    IL_008d:  ldarg.0
    IL_008e:  ldstr      "messages"
    IL_0093:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0098:  stloc.s    V_9
    IL_009a:  ldloc.s    V_9
    IL_009c:  brfalse.s  IL_00e9

    IL_009e:  ldloc.s    V_9
    IL_00a0:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_00a5:  stloc.s    V_13
    .try
    {
      IL_00a7:  br.s       IL_00d2

      IL_00a9:  ldloc.s    V_13
      IL_00ab:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_00b0:  castclass  [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty
      IL_00b5:  stloc.s    V_10
      IL_00b7:  ldloc.s    V_10
      IL_00b9:  ldloc.3
      IL_00ba:  ldloc.1
      IL_00bb:  call       class Avro.Message Avro.Message::Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty,
                                                                  class Avro.SchemaNames,
                                                                  string)
      IL_00c0:  stloc.s    V_11
      IL_00c2:  ldloc.s    V_8
      IL_00c4:  ldloc.s    V_11
      IL_00c6:  callvirt   instance string Avro.Message::get_Name()
      IL_00cb:  ldloc.s    V_11
      IL_00cd:  callvirt   instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Message>::Add(!0,
                                                                                                                                 !1)
      IL_00d2:  ldloc.s    V_13
      IL_00d4:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00d9:  brtrue.s   IL_00a9

      IL_00db:  leave.s    IL_00e9

    }  // end .try
    finally
    {
      IL_00dd:  ldloc.s    V_13
      IL_00df:  brfalse.s  IL_00e8

      IL_00e1:  ldloc.s    V_13
      IL_00e3:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00e8:  endfinally
    }  // end handler
    IL_00e9:  ldloc.0
    IL_00ea:  ldloc.1
    IL_00eb:  ldloc.2
    IL_00ec:  ldloc.s    V_5
    IL_00ee:  ldloc.s    V_8
    IL_00f0:  newobj     instance void Avro.Protocol::.ctor(string,
                                                            string,
                                                            string,
                                                            class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>,
                                                            class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>)
    IL_00f5:  ret
  } // end of method Protocol::Parse

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       62 (0x3e)
    .maxstack  3
    .locals init (class [mscorlib]System.IO.StringWriter V_0,
             class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter V_1,
             string V_2)
    IL_0000:  newobj     instance void [mscorlib]System.IO.StringWriter::.ctor()
    IL_0005:  stloc.0
    .try
    {
      IL_0006:  ldloc.0
      IL_0007:  newobj     instance void [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter::.ctor(class [mscorlib_4]System.IO.TextWriter)
      IL_000c:  stloc.1
      .try
      {
        IL_000d:  ldarg.0
        IL_000e:  ldloc.1
        IL_000f:  newobj     instance void Avro.SchemaNames::.ctor()
        IL_0014:  call       instance void Avro.Protocol::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                    class Avro.SchemaNames)
        IL_0019:  ldloc.1
        IL_001a:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::Flush()
        IL_001f:  ldloc.0
        IL_0020:  callvirt   instance string [mscorlib]System.Object::ToString()
        IL_0025:  stloc.2
        IL_0026:  leave.s    IL_003c

      }  // end .try
      finally
      {
        IL_0028:  ldloc.1
        IL_0029:  brfalse.s  IL_0031

        IL_002b:  ldloc.1
        IL_002c:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_0031:  endfinally
      }  // end handler
    }  // end .try
    finally
    {
      IL_0032:  ldloc.0
      IL_0033:  brfalse.s  IL_003b

      IL_0035:  ldloc.0
      IL_0036:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_003b:  endfinally
    }  // end handler
    IL_003c:  ldloc.2
    IL_003d:  ret
  } // end of method Protocol::ToString

  .method assembly hidebysig instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names) cil managed
  {
    // Code size       239 (0xef)
    .maxstack  4
    .locals init (class Avro.Schema V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message> V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>> V_3)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0006:  ldarg.1
    IL_0007:  ldstr      "protocol"
    IL_000c:  ldarg.0
    IL_000d:  call       instance string Avro.Protocol::get_Name()
    IL_0012:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0017:  ldarg.1
    IL_0018:  ldstr      "namespace"
    IL_001d:  ldarg.0
    IL_001e:  call       instance string Avro.Protocol::get_Namespace()
    IL_0023:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0028:  ldarg.1
    IL_0029:  ldstr      "doc"
    IL_002e:  ldarg.0
    IL_002f:  call       instance string Avro.Protocol::get_Doc()
    IL_0034:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0039:  ldarg.1
    IL_003a:  ldstr      "types"
    IL_003f:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0044:  ldarg.1
    IL_0045:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_004a:  ldarg.0
    IL_004b:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_0050:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0055:  stloc.2
    .try
    {
      IL_0056:  br.s       IL_006d

      IL_0058:  ldloc.2
      IL_0059:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_005e:  stloc.0
      IL_005f:  ldloc.0
      IL_0060:  ldarg.1
      IL_0061:  ldarg.2
      IL_0062:  ldarg.0
      IL_0063:  call       instance string Avro.Protocol::get_Namespace()
      IL_0068:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                class Avro.SchemaNames,
                                                                string)
      IL_006d:  ldloc.2
      IL_006e:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0073:  brtrue.s   IL_0058

      IL_0075:  leave.s    IL_0081

    }  // end .try
    finally
    {
      IL_0077:  ldloc.2
      IL_0078:  brfalse.s  IL_0080

      IL_007a:  ldloc.2
      IL_007b:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0080:  endfinally
    }  // end handler
    IL_0081:  ldarg.1
    IL_0082:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_0087:  ldarg.1
    IL_0088:  ldstr      "messages"
    IL_008d:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0092:  ldarg.1
    IL_0093:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0098:  ldarg.0
    IL_0099:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_009e:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::GetEnumerator()
    IL_00a3:  stloc.3
    .try
    {
      IL_00a4:  br.s       IL_00ce

      IL_00a6:  ldloc.3
      IL_00a7:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Current()
      IL_00ac:  stloc.1
      IL_00ad:  ldarg.1
      IL_00ae:  ldloca.s   V_1
      IL_00b0:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Key()
      IL_00b5:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
      IL_00ba:  ldloca.s   V_1
      IL_00bc:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Value()
      IL_00c1:  ldarg.1
      IL_00c2:  ldarg.2
      IL_00c3:  ldarg.0
      IL_00c4:  call       instance string Avro.Protocol::get_Namespace()
      IL_00c9:  callvirt   instance void Avro.Message::writeJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                 class Avro.SchemaNames,
                                                                 string)
      IL_00ce:  ldloc.3
      IL_00cf:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00d4:  brtrue.s   IL_00a6

      IL_00d6:  leave.s    IL_00e2

    }  // end .try
    finally
    {
      IL_00d8:  ldloc.3
      IL_00d9:  brfalse.s  IL_00e1

      IL_00db:  ldloc.3
      IL_00dc:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00e1:  endfinally
    }  // end handler
    IL_00e2:  ldarg.1
    IL_00e3:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_00e8:  ldarg.1
    IL_00e9:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_00ee:  ret
  } // end of method Protocol::WriteJson

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       90 (0x5a)
    .maxstack  2
    .locals init (class Avro.Protocol V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  isinst     Avro.Protocol
    IL_000c:  brtrue.s   IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.Protocol
    IL_0016:  stloc.0
    IL_0017:  ldarg.0
    IL_0018:  call       instance string Avro.Protocol::get_Name()
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance string Avro.Protocol::get_Name()
    IL_0023:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_0028:  brfalse.s  IL_0058

    IL_002a:  ldarg.0
    IL_002b:  call       instance string Avro.Protocol::get_Namespace()
    IL_0030:  ldloc.0
    IL_0031:  callvirt   instance string Avro.Protocol::get_Namespace()
    IL_0036:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_003b:  brfalse.s  IL_0058

    IL_003d:  ldarg.0
    IL_003e:  ldloc.0
    IL_003f:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_0044:  call       instance bool Avro.Protocol::TypesEquals(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
    IL_0049:  brfalse.s  IL_0058

    IL_004b:  ldarg.0
    IL_004c:  ldloc.0
    IL_004d:  callvirt   instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_0052:  call       instance bool Avro.Protocol::MessagesEquals(class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>)
    IL_0057:  ret

    IL_0058:  ldc.i4.0
    IL_0059:  ret
  } // end of method Protocol::Equals

  .method private hidebysig instance bool 
          TypesEquals(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> that) cil managed
  {
    // Code size       79 (0x4f)
    .maxstack  2
    .locals init (class Avro.Schema V_0,
             bool V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::get_Count()
    IL_000b:  ldarg.1
    IL_000c:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::get_Count()
    IL_0011:  beq.s      IL_0015

    IL_0013:  ldc.i4.0
    IL_0014:  ret

    IL_0015:  ldarg.0
    IL_0016:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_001b:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0020:  stloc.2
    .try
    {
      IL_0021:  br.s       IL_0037

      IL_0023:  ldloc.2
      IL_0024:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0029:  stloc.0
      IL_002a:  ldarg.1
      IL_002b:  ldloc.0
      IL_002c:  callvirt   instance bool class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::Contains(!0)
      IL_0031:  brtrue.s   IL_0037

      IL_0033:  ldc.i4.0
      IL_0034:  stloc.1
      IL_0035:  leave.s    IL_004d

      IL_0037:  ldloc.2
      IL_0038:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_003d:  brtrue.s   IL_0023

      IL_003f:  leave.s    IL_004b

    }  // end .try
    finally
    {
      IL_0041:  ldloc.2
      IL_0042:  brfalse.s  IL_004a

      IL_0044:  ldloc.2
      IL_0045:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_004a:  endfinally
    }  // end handler
    IL_004b:  ldc.i4.1
    IL_004c:  ret

    IL_004d:  ldloc.1
    IL_004e:  ret
  } // end of method Protocol::TypesEquals

  .method private hidebysig instance bool 
          MessagesEquals(class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> that) cil managed
  {
    // Code size       116 (0x74)
    .maxstack  3
    .locals init (valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message> V_0,
             bool V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Count()
    IL_000b:  ldarg.1
    IL_000c:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Count()
    IL_0011:  beq.s      IL_0015

    IL_0013:  ldc.i4.0
    IL_0014:  ret

    IL_0015:  ldarg.0
    IL_0016:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_001b:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::GetEnumerator()
    IL_0020:  stloc.2
    .try
    {
      IL_0021:  br.s       IL_005c

      IL_0023:  ldloc.2
      IL_0024:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Current()
      IL_0029:  stloc.0
      IL_002a:  ldarg.1
      IL_002b:  ldloca.s   V_0
      IL_002d:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Key()
      IL_0032:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>::ContainsKey(!0)
      IL_0037:  brtrue.s   IL_003d

      IL_0039:  ldc.i4.0
      IL_003a:  stloc.1
      IL_003b:  leave.s    IL_0072

      IL_003d:  ldloca.s   V_0
      IL_003f:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Value()
      IL_0044:  ldarg.1
      IL_0045:  ldloca.s   V_0
      IL_0047:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Key()
      IL_004c:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>::get_Item(!0)
      IL_0051:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
      IL_0056:  brtrue.s   IL_005c

      IL_0058:  ldc.i4.0
      IL_0059:  stloc.1
      IL_005a:  leave.s    IL_0072

      IL_005c:  ldloc.2
      IL_005d:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0062:  brtrue.s   IL_0023

      IL_0064:  leave.s    IL_0070

    }  // end .try
    finally
    {
      IL_0066:  ldloc.2
      IL_0067:  brfalse.s  IL_006f

      IL_0069:  ldloc.2
      IL_006a:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_006f:  endfinally
    }  // end handler
    IL_0070:  ldc.i4.1
    IL_0071:  ret

    IL_0072:  ldloc.1
    IL_0073:  ret
  } // end of method Protocol::MessagesEquals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       38 (0x26)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.Protocol::get_Name()
    IL_0006:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000b:  ldarg.0
    IL_000c:  call       instance string Avro.Protocol::get_Namespace()
    IL_0011:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0016:  add
    IL_0017:  ldarg.0
    IL_0018:  call       instance int32 Avro.Protocol::GetTypesHashCode()
    IL_001d:  add
    IL_001e:  ldarg.0
    IL_001f:  call       instance int32 Avro.Protocol::GetMessagesHashCode()
    IL_0024:  add
    IL_0025:  ret
  } // end of method Protocol::GetHashCode

  .method private hidebysig instance int32 
          GetTypesHashCode() cil managed
  {
    // Code size       64 (0x40)
    .maxstack  2
    .locals init (int32 V_0,
             class Avro.Schema V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::get_Count()
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
    IL_0012:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0017:  stloc.2
    .try
    {
      IL_0018:  br.s       IL_002a

      IL_001a:  ldloc.2
      IL_001b:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0020:  stloc.1
      IL_0021:  ldloc.0
      IL_0022:  ldloc.1
      IL_0023:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0028:  add
      IL_0029:  stloc.0
      IL_002a:  ldloc.2
      IL_002b:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0030:  brtrue.s   IL_001a

      IL_0032:  leave.s    IL_003e

    }  // end .try
    finally
    {
      IL_0034:  ldloc.2
      IL_0035:  brfalse.s  IL_003d

      IL_0037:  ldloc.2
      IL_0038:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_003d:  endfinally
    }  // end handler
    IL_003e:  ldloc.0
    IL_003f:  ret
  } // end of method Protocol::GetTypesHashCode

  .method private hidebysig instance int32 
          GetMessagesHashCode() cil managed
  {
    // Code size       83 (0x53)
    .maxstack  3
    .locals init (int32 V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message> V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Count()
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    IL_0012:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::GetEnumerator()
    IL_0017:  stloc.2
    .try
    {
      IL_0018:  br.s       IL_003d

      IL_001a:  ldloc.2
      IL_001b:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>>::get_Current()
      IL_0020:  stloc.1
      IL_0021:  ldloc.0
      IL_0022:  ldloca.s   V_1
      IL_0024:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Key()
      IL_0029:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_002e:  ldloca.s   V_1
      IL_0030:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,class Avro.Message>::get_Value()
      IL_0035:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_003a:  add
      IL_003b:  add
      IL_003c:  stloc.0
      IL_003d:  ldloc.2
      IL_003e:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0043:  brtrue.s   IL_001a

      IL_0045:  leave.s    IL_0051

    }  // end .try
    finally
    {
      IL_0047:  ldloc.2
      IL_0048:  brfalse.s  IL_0050

      IL_004a:  ldloc.2
      IL_004b:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0050:  endfinally
    }  // end handler
    IL_0051:  ldloc.0
    IL_0052:  ret
  } // end of method Protocol::GetMessagesHashCode

  .property instance string Name()
  {
    .set instance void Avro.Protocol::set_Name(string)
    .get instance string Avro.Protocol::get_Name()
  } // end of property Protocol::Name
  .property instance string Namespace()
  {
    .get instance string Avro.Protocol::get_Namespace()
    .set instance void Avro.Protocol::set_Namespace(string)
  } // end of property Protocol::Namespace
  .property instance string Doc()
  {
    .get instance string Avro.Protocol::get_Doc()
    .set instance void Avro.Protocol::set_Doc(string)
  } // end of property Protocol::Doc
  .property instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>
          Types()
  {
    .set instance void Avro.Protocol::set_Types(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
    .get instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.Protocol::get_Types()
  } // end of property Protocol::Types
  .property instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>
          Messages()
  {
    .get instance class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message> Avro.Protocol::get_Messages()
    .set instance void Avro.Protocol::set_Messages(class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Message>)
  } // end of property Protocol::Messages
  .property instance uint8[] MD5()
  {
    .get instance uint8[] Avro.Protocol::get_MD5()
  } // end of property Protocol::MD5
} // end of class Avro.Protocol

.class public auto ansi beforefieldinit Avro.ProtocolParseException
       extends Avro.AvroException
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.AvroException::.ctor(string)
    IL_0007:  ret
  } // end of method ProtocolParseException::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s,
                               class [mscorlib]System.Exception inner) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.AvroException::.ctor(string,
                                                                 class [mscorlib]System.Exception)
    IL_0008:  ret
  } // end of method ProtocolParseException::.ctor

} // end of class Avro.ProtocolParseException

.class public abstract auto ansi beforefieldinit Avro.Schema
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public Type
         extends [mscorlib]System.Enum
  {
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype Avro.Schema/Type Null = int32(0x00000000)
    .field public static literal valuetype Avro.Schema/Type Boolean = int32(0x00000001)
    .field public static literal valuetype Avro.Schema/Type Int = int32(0x00000002)
    .field public static literal valuetype Avro.Schema/Type Long = int32(0x00000003)
    .field public static literal valuetype Avro.Schema/Type Float = int32(0x00000004)
    .field public static literal valuetype Avro.Schema/Type Double = int32(0x00000005)
    .field public static literal valuetype Avro.Schema/Type Bytes = int32(0x00000006)
    .field public static literal valuetype Avro.Schema/Type String = int32(0x00000007)
    .field public static literal valuetype Avro.Schema/Type Record = int32(0x00000008)
    .field public static literal valuetype Avro.Schema/Type Enumeration = int32(0x00000009)
    .field public static literal valuetype Avro.Schema/Type Array = int32(0x0000000A)
    .field public static literal valuetype Avro.Schema/Type Map = int32(0x0000000B)
    .field public static literal valuetype Avro.Schema/Type Union = int32(0x0000000C)
    .field public static literal valuetype Avro.Schema/Type Fixed = int32(0x0000000D)
    .field public static literal valuetype Avro.Schema/Type Error = int32(0x0000000E)
  } // end of class Type

  .field private valuetype Avro.Schema/Type '<Tag>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.PropertyMap '<Props>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance valuetype Avro.Schema/Type 
          get_Tag() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype Avro.Schema/Type Avro.Schema::'<Tag>k__BackingField'
    IL_0006:  ret
  } // end of method Schema::get_Tag

  .method private hidebysig specialname instance void 
          set_Tag(valuetype Avro.Schema/Type 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype Avro.Schema/Type Avro.Schema::'<Tag>k__BackingField'
    IL_0007:  ret
  } // end of method Schema::set_Tag

  .method assembly hidebysig specialname 
          instance class Avro.PropertyMap 
          get_Props() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.PropertyMap Avro.Schema::'<Props>k__BackingField'
    IL_0006:  ret
  } // end of method Schema::get_Props

  .method private hidebysig specialname instance void 
          set_Props(class Avro.PropertyMap 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.PropertyMap Avro.Schema::'<Props>k__BackingField'
    IL_0007:  ret
  } // end of method Schema::set_Props

  .method family hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Avro.Schema/Type 'type',
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       21 (0x15)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  call       instance void Avro.Schema::set_Tag(valuetype Avro.Schema/Type)
    IL_000d:  ldarg.0
    IL_000e:  ldarg.2
    IL_000f:  call       instance void Avro.Schema::set_Props(class Avro.PropertyMap)
    IL_0014:  ret
  } // end of method Schema::.ctor

  .method public hidebysig newslot specialname abstract virtual 
          instance string  get_Name() cil managed
  {
  } // end of method Schema::get_Name

  .method assembly hidebysig static class Avro.Schema 
          ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       301 (0x12d)
    .maxstack  5
    .locals init (string V_0,
             class Avro.PrimitiveSchema V_1,
             class Avro.NamedSchema V_2,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject V_3,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_4,
             class Avro.PropertyMap V_5,
             string V_6,
             class Avro.Schema V_7)
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0013

    IL_0003:  ldstr      "j"
    IL_0008:  ldstr      "j cannot be null."
    IL_000d:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0012:  throw

    IL_0013:  ldarg.0
    IL_0014:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0019:  ldc.i4.8
    IL_001a:  bne.un.s   IL_0052

    IL_001c:  ldarg.0
    IL_001d:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0022:  stloc.0
    IL_0023:  ldloc.0
    IL_0024:  ldnull
    IL_0025:  call       class Avro.PrimitiveSchema Avro.PrimitiveSchema::NewInstance(string,
                                                                                      class Avro.PropertyMap)
    IL_002a:  stloc.1
    IL_002b:  ldloc.1
    IL_002c:  brfalse.s  IL_0030

    IL_002e:  ldloc.1
    IL_002f:  ret

    IL_0030:  ldnull
    IL_0031:  stloc.2
    IL_0032:  ldarg.1
    IL_0033:  ldloc.0
    IL_0034:  ldnull
    IL_0035:  ldarg.2
    IL_0036:  ldloca.s   V_2
    IL_0038:  callvirt   instance bool Avro.SchemaNames::TryGetValue(string,
                                                                     string,
                                                                     string,
                                                                     class Avro.NamedSchema&)
    IL_003d:  brfalse.s  IL_0041

    IL_003f:  ldloc.2
    IL_0040:  ret

    IL_0041:  ldstr      "Undefined name: "
    IL_0046:  ldloc.0
    IL_0047:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_004c:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0051:  throw

    IL_0052:  ldarg.0
    IL_0053:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_0058:  brfalse.s  IL_0069

    IL_005a:  ldarg.0
    IL_005b:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_0060:  ldnull
    IL_0061:  ldarg.1
    IL_0062:  ldarg.2
    IL_0063:  call       class Avro.UnionSchema Avro.UnionSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray,
                                                                              class Avro.PropertyMap,
                                                                              class Avro.SchemaNames,
                                                                              string)
    IL_0068:  ret

    IL_0069:  ldarg.0
    IL_006a:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_006f:  brfalse    IL_011c

    IL_0074:  ldarg.0
    IL_0075:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_007a:  stloc.3
    IL_007b:  ldloc.3
    IL_007c:  ldstr      "type"
    IL_0081:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::get_Item(string)
    IL_0086:  stloc.s    V_4
    IL_0088:  ldloc.s    V_4
    IL_008a:  brtrue.s   IL_0097

    IL_008c:  ldstr      "Property type is required"
    IL_0091:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0096:  throw

    IL_0097:  ldarg.0
    IL_0098:  call       class Avro.PropertyMap Avro.Schema::GetProperties(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_009d:  stloc.s    V_5
    IL_009f:  ldloc.s    V_4
    IL_00a1:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_00a6:  ldc.i4.8
    IL_00a7:  bne.un.s   IL_0101

    IL_00a9:  ldloc.s    V_4
    IL_00ab:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_00b0:  stloc.s    V_6
    IL_00b2:  ldloc.s    V_6
    IL_00b4:  ldstr      "array"
    IL_00b9:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_00be:  brfalse.s  IL_00cb

    IL_00c0:  ldarg.0
    IL_00c1:  ldloc.s    V_5
    IL_00c3:  ldarg.1
    IL_00c4:  ldarg.2
    IL_00c5:  call       class Avro.ArraySchema Avro.ArraySchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                              class Avro.PropertyMap,
                                                                              class Avro.SchemaNames,
                                                                              string)
    IL_00ca:  ret

    IL_00cb:  ldloc.s    V_6
    IL_00cd:  ldstr      "map"
    IL_00d2:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_00d7:  brfalse.s  IL_00e4

    IL_00d9:  ldarg.0
    IL_00da:  ldloc.s    V_5
    IL_00dc:  ldarg.1
    IL_00dd:  ldarg.2
    IL_00de:  call       class Avro.MapSchema Avro.MapSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                          class Avro.PropertyMap,
                                                                          class Avro.SchemaNames,
                                                                          string)
    IL_00e3:  ret

    IL_00e4:  ldloc.s    V_6
    IL_00e6:  ldloc.s    V_5
    IL_00e8:  call       class Avro.PrimitiveSchema Avro.PrimitiveSchema::NewInstance(string,
                                                                                      class Avro.PropertyMap)
    IL_00ed:  stloc.s    V_7
    IL_00ef:  ldloc.s    V_7
    IL_00f1:  brfalse.s  IL_00f6

    IL_00f3:  ldloc.s    V_7
    IL_00f5:  ret

    IL_00f6:  ldloc.3
    IL_00f7:  ldloc.s    V_5
    IL_00f9:  ldarg.1
    IL_00fa:  ldarg.2
    IL_00fb:  call       class Avro.NamedSchema Avro.NamedSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject,
                                                                              class Avro.PropertyMap,
                                                                              class Avro.SchemaNames,
                                                                              string)
    IL_0100:  ret

    IL_0101:  ldloc.s    V_4
    IL_0103:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0108:  ldc.i4.2
    IL_0109:  bne.un.s   IL_011c

    IL_010b:  ldloc.s    V_4
    IL_010d:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_0112:  ldloc.s    V_5
    IL_0114:  ldarg.1
    IL_0115:  ldarg.2
    IL_0116:  call       class Avro.UnionSchema Avro.UnionSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray,
                                                                              class Avro.PropertyMap,
                                                                              class Avro.SchemaNames,
                                                                              string)
    IL_011b:  ret

    IL_011c:  ldstr      "Invalid JSON for schema: "
    IL_0121:  ldarg.0
    IL_0122:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0127:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_012c:  throw
  } // end of method Schema::ParseJson

  .method public hidebysig static class Avro.Schema 
          Parse(string json) cil managed
  {
    // Code size       42 (0x2a)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0018

    IL_0008:  ldstr      "json"
    IL_000d:  ldstr      "json cannot be null."
    IL_0012:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0017:  throw

    IL_0018:  ldarg.0
    IL_0019:  callvirt   instance string [mscorlib]System.String::Trim()
    IL_001e:  newobj     instance void Avro.SchemaNames::.ctor()
    IL_0023:  ldnull
    IL_0024:  call       class Avro.Schema Avro.Schema::Parse(string,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_0029:  ret
  } // end of method Schema::Parse

  .method assembly hidebysig static class Avro.Schema 
          Parse(string json,
                class Avro.SchemaNames names,
                string encspace) cil managed
  {
    // Code size       103 (0x67)
    .maxstack  4
    .locals init (class Avro.Schema V_0,
             bool V_1,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JContainer V_2,
             class [Newtonsoft.Json]Newtonsoft.Json.JsonSerializationException V_3,
             class Avro.Schema V_4)
    IL_0000:  ldarg.0
    IL_0001:  ldnull
    IL_0002:  call       class Avro.PrimitiveSchema Avro.PrimitiveSchema::NewInstance(string,
                                                                                      class Avro.PropertyMap)
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  brfalse.s  IL_000d

    IL_000b:  ldloc.0
    IL_000c:  ret

    .try
    {
      IL_000d:  ldarg.0
      IL_000e:  ldstr      "["
      IL_0013:  callvirt   instance bool [mscorlib]System.String::StartsWith(string)
      IL_0018:  brfalse.s  IL_0027

      IL_001a:  ldarg.0
      IL_001b:  ldstr      "]"
      IL_0020:  callvirt   instance bool [mscorlib]System.String::EndsWith(string)
      IL_0025:  br.s       IL_0028

      IL_0027:  ldc.i4.0
      IL_0028:  stloc.1
      IL_0029:  ldloc.1
      IL_002a:  brtrue.s   IL_0034

      IL_002c:  ldarg.0
      IL_002d:  call       class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::Parse(string)
      IL_0032:  br.s       IL_003a

      IL_0034:  ldarg.0
      IL_0035:  call       class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray::Parse(string)
      IL_003a:  stloc.2
      IL_003b:  ldloc.2
      IL_003c:  ldarg.1
      IL_003d:  ldarg.2
      IL_003e:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                    class Avro.SchemaNames,
                                                                    string)
      IL_0043:  stloc.s    V_4
      IL_0045:  leave.s    IL_0064

    }  // end .try
    catch [Newtonsoft.Json]Newtonsoft.Json.JsonSerializationException 
    {
      IL_0047:  stloc.3
      IL_0048:  ldstr      "Could not parse. "
      IL_004d:  ldloc.3
      IL_004e:  callvirt   instance string [mscorlib]System.Exception::get_Message()
      IL_0053:  call       string [mscorlib]System.Environment::get_NewLine()
      IL_0058:  ldarg.0
      IL_0059:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string,
                                                                  string)
      IL_005e:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_0063:  throw

    }  // end handler
    IL_0064:  ldloc.s    V_4
    IL_0066:  ret
  } // end of method Schema::Parse

  .method assembly hidebysig static class Avro.PropertyMap 
          GetProperties(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok) cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  2
    .locals init (class Avro.PropertyMap V_0)
    IL_0000:  newobj     instance void Avro.PropertyMap::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldarg.0
    IL_0008:  callvirt   instance void Avro.PropertyMap::Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_000d:  ldloc.0
    IL_000e:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::get_Count()
    IL_0013:  ldc.i4.0
    IL_0014:  ble.s      IL_0018

    IL_0016:  ldloc.0
    IL_0017:  ret

    IL_0018:  ldnull
    IL_0019:  ret
  } // end of method Schema::GetProperties

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       88 (0x58)
    .maxstack  4
    .locals init (class [mscorlib]System.IO.StringWriter V_0,
             class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter V_1)
    IL_0000:  newobj     instance void [mscorlib]System.IO.StringWriter::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  newobj     instance void [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter::.ctor(class [mscorlib_4]System.IO.TextWriter)
    IL_000c:  stloc.1
    IL_000d:  ldarg.0
    IL_000e:  isinst     Avro.PrimitiveSchema
    IL_0013:  brtrue.s   IL_001d

    IL_0015:  ldarg.0
    IL_0016:  isinst     Avro.UnionSchema
    IL_001b:  brfalse.s  IL_002e

    IL_001d:  ldloc.1
    IL_001e:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0023:  ldloc.1
    IL_0024:  ldstr      "type"
    IL_0029:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_002e:  ldarg.0
    IL_002f:  ldloc.1
    IL_0030:  newobj     instance void Avro.SchemaNames::.ctor()
    IL_0035:  ldnull
    IL_0036:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_003b:  ldarg.0
    IL_003c:  isinst     Avro.PrimitiveSchema
    IL_0041:  brtrue.s   IL_004b

    IL_0043:  ldarg.0
    IL_0044:  isinst     Avro.UnionSchema
    IL_0049:  brfalse.s  IL_0051

    IL_004b:  ldloc.1
    IL_004c:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_0051:  ldloc.0
    IL_0052:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0057:  ret
  } // end of method Schema::ToString

  .method private hidebysig instance void 
          writeStartObject(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer) cil managed
  {
    // Code size       35 (0x23)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0006:  ldarg.1
    IL_0007:  ldstr      "type"
    IL_000c:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0011:  ldarg.1
    IL_0012:  ldarg.0
    IL_0013:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0018:  call       string Avro.Schema::GetTypeString(valuetype Avro.Schema/Type)
    IL_001d:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
    IL_0022:  ret
  } // end of method Schema::writeStartObject

  .method public hidebysig static string 
          GetTypeString(valuetype Avro.Schema/Type 'type') cil managed
  {
    // Code size       28 (0x1c)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   9
    IL_0003:  beq.s      IL_0016

    IL_0005:  ldarg.0
    IL_0006:  box        Avro.Schema/Type
    IL_000b:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0010:  callvirt   instance string [mscorlib]System.String::ToLower()
    IL_0015:  ret

    IL_0016:  ldstr      "enum"
    IL_001b:  ret
  } // end of method Schema::GetTypeString

  .method famorassem hidebysig newslot virtual 
          instance void  WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                                         class Avro.SchemaNames names,
                                         string encspace) cil managed
  {
    // Code size       1 (0x1)
    .maxstack  8
    IL_0000:  ret
  } // end of method Schema::WriteJsonFields

  .method famorassem hidebysig newslot virtual 
          instance void  WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                                   class Avro.SchemaNames names,
                                   string encspace) cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.Schema::writeStartObject(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter)
    IL_0007:  ldarg.0
    IL_0008:  ldarg.1
    IL_0009:  ldarg.2
    IL_000a:  ldarg.3
    IL_000b:  callvirt   instance void Avro.Schema::WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                    class Avro.SchemaNames,
                                                                    string)
    IL_0010:  ldarg.0
    IL_0011:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0016:  brfalse.s  IL_0024

    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_001e:  ldarg.1
    IL_001f:  callvirt   instance void Avro.PropertyMap::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter)
    IL_0024:  ldarg.1
    IL_0025:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_002a:  ret
  } // end of method Schema::WriteJson

  .method public hidebysig instance string 
          GetProperty(string key) cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  3
    .locals init (string V_0)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0006:  brtrue.s   IL_000a

    IL_0008:  ldnull
    IL_0009:  ret

    IL_000a:  ldarg.0
    IL_000b:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0010:  ldarg.1
    IL_0011:  ldloca.s   V_0
    IL_0013:  callvirt   instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::TryGetValue(!0,
                                                                                                                           !1&)
    IL_0018:  brtrue.s   IL_001c

    IL_001a:  ldnull
    IL_001b:  ret

    IL_001c:  ldloc.0
    IL_001d:  ret
  } // end of method Schema::GetProperty

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       29 (0x1d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  box        Avro.Schema/Type
    IL_000b:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0010:  ldarg.0
    IL_0011:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0016:  call       int32 Avro.Schema::getHashCode(object)
    IL_001b:  add
    IL_001c:  ret
  } // end of method Schema::GetHashCode

  .method public hidebysig newslot virtual 
          instance bool  CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000c:  ceq
    IL_000e:  ret
  } // end of method Schema::CanRead

  .method family hidebysig static bool  areEqual(object o1,
                                                 object o2) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.0
    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_000a:  ret

    IL_000b:  ldarg.1
    IL_000c:  ldnull
    IL_000d:  ceq
    IL_000f:  ret
  } // end of method Schema::areEqual

  .method family hidebysig static int32  getHashCode(object obj) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000a

    IL_0003:  ldarg.0
    IL_0004:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0009:  ret

    IL_000a:  ldc.i4.0
    IL_000b:  ret
  } // end of method Schema::getHashCode

  .property instance valuetype Avro.Schema/Type
          Tag()
  {
    .get instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    .set instance void Avro.Schema::set_Tag(valuetype Avro.Schema/Type)
  } // end of property Schema::Tag
  .property instance class Avro.PropertyMap
          Props()
  {
    .get instance class Avro.PropertyMap Avro.Schema::get_Props()
    .set instance void Avro.Schema::set_Props(class Avro.PropertyMap)
  } // end of property Schema::Props
  .property instance string Name()
  {
    .get instance string Avro.Schema::get_Name()
  } // end of property Schema::Name
} // end of class Avro.Schema

.class public abstract auto ansi beforefieldinit Avro.UnnamedSchema
       extends Avro.Schema
{
  .method family hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Avro.Schema/Type 'type',
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.Schema::.ctor(valuetype Avro.Schema/Type,
                                                          class Avro.PropertyMap)
    IL_0008:  ret
  } // end of method UnnamedSchema::.ctor

  .method public hidebysig specialname virtual 
          instance string  get_Name() cil managed
  {
    // Code size       22 (0x16)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  box        Avro.Schema/Type
    IL_000b:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0010:  callvirt   instance string [mscorlib]System.String::ToLower()
    IL_0015:  ret
  } // end of method UnnamedSchema::get_Name

  .property instance string Name()
  {
    .get instance string Avro.UnnamedSchema::get_Name()
  } // end of property UnnamedSchema::Name
} // end of class Avro.UnnamedSchema

.class public auto ansi beforefieldinit Avro.ArraySchema
       extends Avro.UnnamedSchema
{
  .field private class Avro.Schema '<ItemSchema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.Schema 
          get_ItemSchema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.ArraySchema::'<ItemSchema>k__BackingField'
    IL_0006:  ret
  } // end of method ArraySchema::get_ItemSchema

  .method public hidebysig specialname instance void 
          set_ItemSchema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.ArraySchema::'<ItemSchema>k__BackingField'
    IL_0007:  ret
  } // end of method ArraySchema::set_ItemSchema

  .method assembly hidebysig static class Avro.ArraySchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "items"
    IL_0006:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_001a

    IL_000f:  ldstr      "Array does not have 'items'"
    IL_0014:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0019:  throw

    IL_001a:  ldloc.0
    IL_001b:  ldarg.2
    IL_001c:  ldarg.3
    IL_001d:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_0022:  ldarg.1
    IL_0023:  newobj     instance void Avro.ArraySchema::.ctor(class Avro.Schema,
                                                               class Avro.PropertyMap)
    IL_0028:  ret
  } // end of method ArraySchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema items,
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   10
    IL_0003:  ldarg.2
    IL_0004:  call       instance void Avro.UnnamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                                 class Avro.PropertyMap)
    IL_0009:  ldarg.1
    IL_000a:  brtrue.s   IL_0017

    IL_000c:  ldstr      "items"
    IL_0011:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string)
    IL_0016:  throw

    IL_0017:  ldarg.0
    IL_0018:  ldarg.1
    IL_0019:  call       instance void Avro.ArraySchema::set_ItemSchema(class Avro.Schema)
    IL_001e:  ret
  } // end of method ArraySchema::.ctor

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldstr      "items"
    IL_0006:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_000b:  ldarg.0
    IL_000c:  call       instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0011:  ldarg.1
    IL_0012:  ldarg.2
    IL_0013:  ldarg.3
    IL_0014:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_0019:  ret
  } // end of method ArraySchema::WriteJsonFields

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       41 (0x29)
    .maxstack  2
    .locals init (class Avro.ArraySchema V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldarg.0
    IL_0007:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000c:  beq.s      IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.ArraySchema
    IL_0016:  stloc.0
    IL_0017:  ldarg.0
    IL_0018:  call       instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0023:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
    IL_0028:  ret
  } // end of method ArraySchema::CanRead

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  2
    .locals init (class Avro.ArraySchema V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_003d

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.ArraySchema
    IL_000f:  brfalse.s  IL_003d

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.ArraySchema
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_003d

    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0031:  ldarg.0
    IL_0032:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0037:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_003c:  ret

    IL_003d:  ldc.i4.0
    IL_003e:  ret
  } // end of method ArraySchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  8
    IL_0000:  ldc.i4.s   29
    IL_0002:  ldarg.0
    IL_0003:  call       instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ldarg.0
    IL_000f:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0014:  call       int32 Avro.Schema::getHashCode(object)
    IL_0019:  add
    IL_001a:  ret
  } // end of method ArraySchema::GetHashCode

  .property instance class Avro.Schema ItemSchema()
  {
    .get instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    .set instance void Avro.ArraySchema::set_ItemSchema(class Avro.Schema)
  } // end of property ArraySchema::ItemSchema
} // end of class Avro.ArraySchema

.class public auto ansi beforefieldinit Avro.AvroTypeException
       extends Avro.AvroException
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.AvroException::.ctor(string)
    IL_0007:  ret
  } // end of method AvroTypeException::.ctor

} // end of class Avro.AvroTypeException

.class public abstract auto ansi beforefieldinit Avro.NamedSchema
       extends Avro.Schema
{
  .field private initonly class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> aliases
  .field private class Avro.SchemaName '<SchemaName>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.SchemaName 
          get_SchemaName() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.SchemaName Avro.NamedSchema::'<SchemaName>k__BackingField'
    IL_0006:  ret
  } // end of method NamedSchema::get_SchemaName

  .method private hidebysig specialname instance void 
          set_SchemaName(class Avro.SchemaName 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.SchemaName Avro.NamedSchema::'<SchemaName>k__BackingField'
    IL_0007:  ret
  } // end of method NamedSchema::set_SchemaName

  .method public hidebysig specialname virtual 
          instance string  get_Name() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_000b:  ret
  } // end of method NamedSchema::get_Name

  .method public hidebysig specialname instance string 
          get_Namespace() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  callvirt   instance string Avro.SchemaName::get_Namespace()
    IL_000b:  ret
  } // end of method NamedSchema::get_Namespace

  .method public hidebysig specialname instance string 
          get_Fullname() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  callvirt   instance string Avro.SchemaName::get_Fullname()
    IL_000b:  ret
  } // end of method NamedSchema::get_Fullname

  .method assembly hidebysig static class Avro.NamedSchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject jo,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       131 (0x83)
    .maxstack  5
    .locals init (string V_0,
             class Avro.NamedSchema V_1,
             string V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "type"
    IL_0006:  call       string Avro.JsonHelper::GetRequiredString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  dup
    IL_000e:  stloc.2
    IL_000f:  brfalse.s  IL_0072

    IL_0011:  ldloc.2
    IL_0012:  ldstr      "fixed"
    IL_0017:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_001c:  brtrue.s   IL_0047

    IL_001e:  ldloc.2
    IL_001f:  ldstr      "enum"
    IL_0024:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0029:  brtrue.s   IL_0051

    IL_002b:  ldloc.2
    IL_002c:  ldstr      "record"
    IL_0031:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0036:  brtrue.s   IL_005b

    IL_0038:  ldloc.2
    IL_0039:  ldstr      "error"
    IL_003e:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0043:  brtrue.s   IL_0066

    IL_0045:  br.s       IL_0072

    IL_0047:  ldarg.0
    IL_0048:  ldarg.1
    IL_0049:  ldarg.2
    IL_004a:  ldarg.3
    IL_004b:  call       class Avro.FixedSchema Avro.FixedSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                              class Avro.PropertyMap,
                                                                              class Avro.SchemaNames,
                                                                              string)
    IL_0050:  ret

    IL_0051:  ldarg.0
    IL_0052:  ldarg.1
    IL_0053:  ldarg.2
    IL_0054:  ldarg.3
    IL_0055:  call       class Avro.EnumSchema Avro.EnumSchema::NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                            class Avro.PropertyMap,
                                                                            class Avro.SchemaNames,
                                                                            string)
    IL_005a:  ret

    IL_005b:  ldc.i4.8
    IL_005c:  ldarg.0
    IL_005d:  ldarg.1
    IL_005e:  ldarg.2
    IL_005f:  ldarg.3
    IL_0060:  call       class Avro.RecordSchema Avro.RecordSchema::NewInstance(valuetype Avro.Schema/Type,
                                                                                class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                class Avro.PropertyMap,
                                                                                class Avro.SchemaNames,
                                                                                string)
    IL_0065:  ret

    IL_0066:  ldc.i4.s   14
    IL_0068:  ldarg.0
    IL_0069:  ldarg.1
    IL_006a:  ldarg.2
    IL_006b:  ldarg.3
    IL_006c:  call       class Avro.RecordSchema Avro.RecordSchema::NewInstance(valuetype Avro.Schema/Type,
                                                                                class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                class Avro.PropertyMap,
                                                                                class Avro.SchemaNames,
                                                                                string)
    IL_0071:  ret

    IL_0072:  ldarg.2
    IL_0073:  ldloc.0
    IL_0074:  ldnull
    IL_0075:  ldarg.3
    IL_0076:  ldloca.s   V_1
    IL_0078:  callvirt   instance bool Avro.SchemaNames::TryGetValue(string,
                                                                     string,
                                                                     string,
                                                                     class Avro.NamedSchema&)
    IL_007d:  brfalse.s  IL_0081

    IL_007f:  ldloc.1
    IL_0080:  ret

    IL_0081:  ldnull
    IL_0082:  ret
  } // end of method NamedSchema::NewInstance

  .method family hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Avro.Schema/Type 'type',
                               class Avro.SchemaName name,
                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> aliases,
                               class Avro.PropertyMap props,
                               class Avro.SchemaNames names) cil managed
  {
    // Code size       65 (0x41)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.s    props
    IL_0004:  call       instance void Avro.Schema::.ctor(valuetype Avro.Schema/Type,
                                                          class Avro.PropertyMap)
    IL_0009:  ldarg.0
    IL_000a:  ldarg.2
    IL_000b:  call       instance void Avro.NamedSchema::set_SchemaName(class Avro.SchemaName)
    IL_0010:  ldarg.0
    IL_0011:  ldarg.3
    IL_0012:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::aliases
    IL_0017:  ldarg.2
    IL_0018:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_001d:  brfalse.s  IL_0040

    IL_001f:  ldarg.s    names
    IL_0021:  ldarg.2
    IL_0022:  ldarg.0
    IL_0023:  callvirt   instance bool Avro.SchemaNames::Add(class Avro.SchemaName,
                                                             class Avro.NamedSchema)
    IL_0028:  brtrue.s   IL_0040

    IL_002a:  ldstr      "Duplicate schema name "
    IL_002f:  ldarg.2
    IL_0030:  callvirt   instance string Avro.SchemaName::get_Fullname()
    IL_0035:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_003a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_003f:  throw

    IL_0040:  ret
  } // end of method NamedSchema::.ctor

  .method family hidebysig static class Avro.SchemaName 
          GetName(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                  string encspace) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  3
    .locals init (string V_0,
             string V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "name"
    IL_0006:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  ldstr      "namespace"
    IL_0012:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0017:  stloc.1
    IL_0018:  ldloc.0
    IL_0019:  ldloc.1
    IL_001a:  ldarg.1
    IL_001b:  newobj     instance void Avro.SchemaName::.ctor(string,
                                                              string,
                                                              string)
    IL_0020:  ret
  } // end of method NamedSchema::GetName

  .method family hidebysig static class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> 
          GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                     string space,
                     string encspace) cil managed
  {
    // Code size       120 (0x78)
    .maxstack  4
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0,
             class [mscorlib]System.Collections.Generic.List`1<class Avro.SchemaName> V_1,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_3)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "aliases"
    IL_0006:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_0011

    IL_000f:  ldnull
    IL_0010:  ret

    IL_0011:  ldloc.0
    IL_0012:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0017:  ldc.i4.2
    IL_0018:  beq.s      IL_0025

    IL_001a:  ldstr      "Aliases must be of format JSON array of strings"
    IL_001f:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0024:  throw

    IL_0025:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.SchemaName>::.ctor()
    IL_002a:  stloc.1
    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0031:  stloc.3
    .try
    {
      IL_0032:  br.s       IL_0062

      IL_0034:  ldloc.3
      IL_0035:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_003a:  stloc.2
      IL_003b:  ldloc.2
      IL_003c:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
      IL_0041:  ldc.i4.8
      IL_0042:  beq.s      IL_004f

      IL_0044:  ldstr      "Aliases must be of format JSON array of strings"
      IL_0049:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_004e:  throw

      IL_004f:  ldloc.1
      IL_0050:  ldloc.2
      IL_0051:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_0056:  ldarg.1
      IL_0057:  ldarg.2
      IL_0058:  newobj     instance void Avro.SchemaName::.ctor(string,
                                                                string,
                                                                string)
      IL_005d:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.SchemaName>::Add(!0)
      IL_0062:  ldloc.3
      IL_0063:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0068:  brtrue.s   IL_0034

      IL_006a:  leave.s    IL_0076

    }  // end .try
    finally
    {
      IL_006c:  ldloc.3
      IL_006d:  brfalse.s  IL_0075

      IL_006f:  ldloc.3
      IL_0070:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0075:  endfinally
    }  // end handler
    IL_0076:  ldloc.1
    IL_0077:  ret
  } // end of method NamedSchema::GetAliases

  .method family hidebysig instance bool 
          InAliases(class Avro.SchemaName name) cil managed
  {
    // Code size       66 (0x42)
    .maxstack  2
    .locals init (class Avro.SchemaName V_0,
             bool V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.SchemaName> V_2)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::aliases
    IL_0006:  brfalse.s  IL_003e

    IL_0008:  ldarg.0
    IL_0009:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::aliases
    IL_000e:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.SchemaName>::GetEnumerator()
    IL_0013:  stloc.2
    .try
    {
      IL_0014:  br.s       IL_002a

      IL_0016:  ldloc.2
      IL_0017:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.SchemaName>::get_Current()
      IL_001c:  stloc.0
      IL_001d:  ldarg.1
      IL_001e:  ldloc.0
      IL_001f:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
      IL_0024:  brfalse.s  IL_002a

      IL_0026:  ldc.i4.1
      IL_0027:  stloc.1
      IL_0028:  leave.s    IL_0040

      IL_002a:  ldloc.2
      IL_002b:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0030:  brtrue.s   IL_0016

      IL_0032:  leave.s    IL_003e

    }  // end .try
    finally
    {
      IL_0034:  ldloc.2
      IL_0035:  brfalse.s  IL_003d

      IL_0037:  ldloc.2
      IL_0038:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_003d:  endfinally
    }  // end handler
    IL_003e:  ldc.i4.0
    IL_003f:  ret

    IL_0040:  ldloc.1
    IL_0041:  ret
  } // end of method NamedSchema::InAliases

  .method famorassem hidebysig virtual instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       80 (0x50)
    .maxstack  4
    .locals init (class Avro.SchemaName V_0,
             string V_1)
    IL_0000:  ldarg.2
    IL_0001:  ldarg.0
    IL_0002:  callvirt   instance bool Avro.SchemaNames::Add(class Avro.NamedSchema)
    IL_0007:  brtrue.s   IL_0046

    IL_0009:  ldarg.0
    IL_000a:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_000f:  stloc.0
    IL_0010:  ldloc.0
    IL_0011:  callvirt   instance string Avro.SchemaName::get_Namespace()
    IL_0016:  ldarg.3
    IL_0017:  call       bool [mscorlib]System.String::op_Inequality(string,
                                                                     string)
    IL_001c:  brfalse.s  IL_0037

    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance string Avro.SchemaName::get_Namespace()
    IL_0024:  ldstr      "."
    IL_0029:  ldloc.0
    IL_002a:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_002f:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0034:  stloc.1
    IL_0035:  br.s       IL_003e

    IL_0037:  ldloc.0
    IL_0038:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_003d:  stloc.1
    IL_003e:  ldarg.1
    IL_003f:  ldloc.1
    IL_0040:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
    IL_0045:  ret

    IL_0046:  ldarg.0
    IL_0047:  ldarg.1
    IL_0048:  ldarg.2
    IL_0049:  ldarg.3
    IL_004a:  call       instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_004f:  ret
  } // end of method NamedSchema::WriteJson

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       133 (0x85)
    .maxstack  4
    .locals init (class Avro.SchemaName V_0,
             string V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.SchemaName> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  ldarg.3
    IL_0009:  callvirt   instance void Avro.SchemaName::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_000e:  ldarg.0
    IL_000f:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::aliases
    IL_0014:  brfalse.s  IL_0084

    IL_0016:  ldarg.1
    IL_0017:  ldstr      "aliases"
    IL_001c:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0021:  ldarg.1
    IL_0022:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_0027:  ldarg.0
    IL_0028:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::aliases
    IL_002d:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.SchemaName>::GetEnumerator()
    IL_0032:  stloc.2
    .try
    {
      IL_0033:  br.s       IL_006a

      IL_0035:  ldloc.2
      IL_0036:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.SchemaName>::get_Current()
      IL_003b:  stloc.0
      IL_003c:  ldloc.0
      IL_003d:  callvirt   instance string Avro.SchemaName::get_Space()
      IL_0042:  brtrue.s   IL_004c

      IL_0044:  ldloc.0
      IL_0045:  callvirt   instance string Avro.SchemaName::get_Name()
      IL_004a:  br.s       IL_0062

      IL_004c:  ldloc.0
      IL_004d:  callvirt   instance string Avro.SchemaName::get_Space()
      IL_0052:  ldstr      "."
      IL_0057:  ldloc.0
      IL_0058:  callvirt   instance string Avro.SchemaName::get_Name()
      IL_005d:  call       string [mscorlib]System.String::Concat(string,
                                                                  string,
                                                                  string)
      IL_0062:  stloc.1
      IL_0063:  ldarg.1
      IL_0064:  ldloc.1
      IL_0065:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
      IL_006a:  ldloc.2
      IL_006b:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0070:  brtrue.s   IL_0035

      IL_0072:  leave.s    IL_007e

    }  // end .try
    finally
    {
      IL_0074:  ldloc.2
      IL_0075:  brfalse.s  IL_007d

      IL_0077:  ldloc.2
      IL_0078:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_007d:  endfinally
    }  // end handler
    IL_007e:  ldarg.1
    IL_007f:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_0084:  ret
  } // end of method NamedSchema::WriteJsonFields

  .property instance class Avro.SchemaName
          SchemaName()
  {
    .set instance void Avro.NamedSchema::set_SchemaName(class Avro.SchemaName)
    .get instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
  } // end of property NamedSchema::SchemaName
  .property instance string Name()
  {
    .get instance string Avro.NamedSchema::get_Name()
  } // end of property NamedSchema::Name
  .property instance string Namespace()
  {
    .get instance string Avro.NamedSchema::get_Namespace()
  } // end of property NamedSchema::Namespace
  .property instance string Fullname()
  {
    .get instance string Avro.NamedSchema::get_Fullname()
  } // end of property NamedSchema::Fullname
} // end of class Avro.NamedSchema

.class public auto ansi beforefieldinit Avro.EnumSchema
       extends Avro.NamedSchema
{
  .custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = ( 01 00 04 49 74 65 6D 00 00 )                      // ...Item..
  .field private initonly class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> symbolMap
  .field private class [mscorlib]System.Collections.Generic.IList`1<string> '<Symbols>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IList`1<string> 
          get_Symbols() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::'<Symbols>k__BackingField'
    IL_0006:  ret
  } // end of method EnumSchema::get_Symbols

  .method private hidebysig specialname instance void 
          set_Symbols(class [mscorlib]System.Collections.Generic.IList`1<string> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::'<Symbols>k__BackingField'
    IL_0007:  ret
  } // end of method EnumSchema::set_Symbols

  .method public hidebysig specialname instance int32 
          get_Count() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<string>::get_Count()
    IL_000b:  ret
  } // end of method EnumSchema::get_Count

  .method assembly hidebysig static class Avro.EnumSchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       207 (0xcf)
    .maxstack  6
    .locals init (class Avro.SchemaName V_0,
             class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> V_1,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray V_2,
             class [mscorlib]System.Collections.Generic.List`1<string> V_3,
             class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> V_4,
             int32 V_5,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JValue V_6,
             string V_7,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_8)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.3
    IL_0002:  call       class Avro.SchemaName Avro.NamedSchema::GetName(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                         string)
    IL_0007:  stloc.0
    IL_0008:  ldarg.0
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance string Avro.SchemaName::get_Space()
    IL_000f:  ldloc.0
    IL_0010:  callvirt   instance string Avro.SchemaName::get_EncSpace()
    IL_0015:  call       class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                                                                string,
                                                                                                                                string)
    IL_001a:  stloc.1
    IL_001b:  ldarg.0
    IL_001c:  ldstr      "symbols"
    IL_0021:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0026:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray
    IL_002b:  stloc.2
    IL_002c:  ldloc.2
    IL_002d:  brtrue.s   IL_0040

    IL_002f:  ldstr      "Enum has no symbols: "
    IL_0034:  ldloc.0
    IL_0035:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_003a:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_003f:  throw

    IL_0040:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
    IL_0045:  stloc.3
    IL_0046:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::.ctor()
    IL_004b:  stloc.s    V_4
    IL_004d:  ldc.i4.0
    IL_004e:  stloc.s    V_5
    IL_0050:  ldloc.2
    IL_0051:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0056:  stloc.s    V_8
    .try
    {
      IL_0058:  br.s       IL_00ab

      IL_005a:  ldloc.s    V_8
      IL_005c:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_0061:  castclass  [Newtonsoft.Json]Newtonsoft.Json.Linq.JValue
      IL_0066:  stloc.s    V_6
      IL_0068:  ldloc.s    V_6
      IL_006a:  callvirt   instance object [Newtonsoft.Json]Newtonsoft.Json.Linq.JValue::get_Value()
      IL_006f:  castclass  [mscorlib]System.String
      IL_0074:  stloc.s    V_7
      IL_0076:  ldloc.s    V_4
      IL_0078:  ldloc.s    V_7
      IL_007a:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32>::ContainsKey(!0)
      IL_007f:  brfalse.s  IL_0093

      IL_0081:  ldstr      "Duplicate symbol: "
      IL_0086:  ldloc.s    V_7
      IL_0088:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_008d:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_0092:  throw

      IL_0093:  ldloc.s    V_4
      IL_0095:  ldloc.s    V_7
      IL_0097:  ldloc.s    V_5
      IL_0099:  dup
      IL_009a:  ldc.i4.1
      IL_009b:  add
      IL_009c:  stloc.s    V_5
      IL_009e:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32>::set_Item(!0,
                                                                                                                          !1)
      IL_00a3:  ldloc.3
      IL_00a4:  ldloc.s    V_7
      IL_00a6:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
      IL_00ab:  ldloc.s    V_8
      IL_00ad:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00b2:  brtrue.s   IL_005a

      IL_00b4:  leave.s    IL_00c2

    }  // end .try
    finally
    {
      IL_00b6:  ldloc.s    V_8
      IL_00b8:  brfalse.s  IL_00c1

      IL_00ba:  ldloc.s    V_8
      IL_00bc:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c1:  endfinally
    }  // end handler
    IL_00c2:  ldloc.0
    IL_00c3:  ldloc.1
    IL_00c4:  ldloc.3
    IL_00c5:  ldloc.s    V_4
    IL_00c7:  ldarg.1
    IL_00c8:  ldarg.2
    IL_00c9:  newobj     instance void Avro.EnumSchema::.ctor(class Avro.SchemaName,
                                                              class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                              class [mscorlib]System.Collections.Generic.List`1<string>,
                                                              class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32>,
                                                              class Avro.PropertyMap,
                                                              class Avro.SchemaNames)
    IL_00ce:  ret
  } // end of method EnumSchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.SchemaName name,
                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> aliases,
                               class [mscorlib]System.Collections.Generic.List`1<string> symbols,
                               class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> symbolMap,
                               class Avro.PropertyMap props,
                               class Avro.SchemaNames names) cil managed
  {
    // Code size       49 (0x31)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   9
    IL_0003:  ldarg.1
    IL_0004:  ldarg.2
    IL_0005:  ldarg.s    props
    IL_0007:  ldarg.s    names
    IL_0009:  call       instance void Avro.NamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                               class Avro.SchemaName,
                                                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                               class Avro.PropertyMap,
                                                               class Avro.SchemaNames)
    IL_000e:  ldarg.1
    IL_000f:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_0014:  brtrue.s   IL_0021

    IL_0016:  ldstr      "name cannot be null for enum schema."
    IL_001b:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0020:  throw

    IL_0021:  ldarg.0
    IL_0022:  ldarg.3
    IL_0023:  call       instance void Avro.EnumSchema::set_Symbols(class [mscorlib]System.Collections.Generic.IList`1<string>)
    IL_0028:  ldarg.0
    IL_0029:  ldarg.s    symbolMap
    IL_002b:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> Avro.EnumSchema::symbolMap
    IL_0030:  ret
  } // end of method EnumSchema::.ctor

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       81 (0x51)
    .maxstack  4
    .locals init (string V_0,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance void Avro.NamedSchema::WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                         class Avro.SchemaNames,
                                                                         string)
    IL_0009:  ldarg.1
    IL_000a:  ldstr      "symbols"
    IL_000f:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0014:  ldarg.1
    IL_0015:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_001a:  ldarg.0
    IL_001b:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0020:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_0025:  stloc.1
    .try
    {
      IL_0026:  br.s       IL_0036

      IL_0028:  ldloc.1
      IL_0029:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
      IL_002e:  stloc.0
      IL_002f:  ldarg.1
      IL_0030:  ldloc.0
      IL_0031:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
      IL_0036:  ldloc.1
      IL_0037:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_003c:  brtrue.s   IL_0028

      IL_003e:  leave.s    IL_004a

    }  // end .try
    finally
    {
      IL_0040:  ldloc.1
      IL_0041:  brfalse.s  IL_0049

      IL_0043:  ldloc.1
      IL_0044:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0049:  endfinally
    }  // end handler
    IL_004a:  ldarg.1
    IL_004b:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_0050:  ret
  } // end of method EnumSchema::WriteJsonFields

  .method public hidebysig instance int32 
          Ordinal(string symbol) cil managed
  {
    // Code size       35 (0x23)
    .maxstack  3
    .locals init (int32 V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> Avro.EnumSchema::symbolMap
    IL_0006:  ldarg.1
    IL_0007:  ldloca.s   V_0
    IL_0009:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32>::TryGetValue(!0,
                                                                                                                           !1&)
    IL_000e:  brfalse.s  IL_0012

    IL_0010:  ldloc.0
    IL_0011:  ret

    IL_0012:  ldstr      "No such symbol: "
    IL_0017:  ldarg.1
    IL_0018:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_001d:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0022:  throw
  } // end of method EnumSchema::Ordinal

  .method public hidebysig specialname instance string 
          get_Item(int32 index) cil managed
  {
    // Code size       90 (0x5a)
    .maxstack  3
    .locals init (object[] V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0007:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<string>::get_Count()
    IL_000c:  bge.s      IL_001b

    IL_000e:  ldarg.0
    IL_000f:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0014:  ldarg.1
    IL_0015:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<string>::get_Item(int32)
    IL_001a:  ret

    IL_001b:  ldc.i4.4
    IL_001c:  newarr     [mscorlib]System.Object
    IL_0021:  stloc.0
    IL_0022:  ldloc.0
    IL_0023:  ldc.i4.0
    IL_0024:  ldstr      "Enumeration out of range. Must be less than "
    IL_0029:  stelem.ref
    IL_002a:  ldloc.0
    IL_002b:  ldc.i4.1
    IL_002c:  ldarg.0
    IL_002d:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0032:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<string>::get_Count()
    IL_0037:  box        [mscorlib]System.Int32
    IL_003c:  stelem.ref
    IL_003d:  ldloc.0
    IL_003e:  ldc.i4.2
    IL_003f:  ldstr      ", but is "
    IL_0044:  stelem.ref
    IL_0045:  ldloc.0
    IL_0046:  ldc.i4.3
    IL_0047:  ldarg.1
    IL_0048:  box        [mscorlib]System.Int32
    IL_004d:  stelem.ref
    IL_004e:  ldloc.0
    IL_004f:  call       string [mscorlib]System.String::Concat(object[])
    IL_0054:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0059:  throw
  } // end of method EnumSchema::get_Item

  .method public hidebysig instance bool 
          Contains(string symbol) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32> Avro.EnumSchema::symbolMap
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,int32>::ContainsKey(!0)
    IL_000c:  ret
  } // end of method EnumSchema::Contains

  .method public hidebysig instance class [mscorlib]System.Collections.Generic.IEnumerator`1<string> 
          GetEnumerator() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_000b:  ret
  } // end of method EnumSchema::GetEnumerator

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       127 (0x7f)
    .maxstack  3
    .locals init (class Avro.EnumSchema V_0,
             int32 V_1)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_007d

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.EnumSchema
    IL_000f:  brfalse.s  IL_007d

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.EnumSchema
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_007d

    IL_002b:  ldarg.0
    IL_002c:  call       instance int32 Avro.EnumSchema::get_Count()
    IL_0031:  ldloc.0
    IL_0032:  callvirt   instance int32 Avro.EnumSchema::get_Count()
    IL_0037:  bne.un.s   IL_007d

    IL_0039:  ldc.i4.0
    IL_003a:  stloc.1
    IL_003b:  br.s       IL_0062

    IL_003d:  ldarg.0
    IL_003e:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_0043:  ldloc.1
    IL_0044:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<string>::get_Item(int32)
    IL_0049:  ldloc.0
    IL_004a:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_004f:  ldloc.1
    IL_0050:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<string>::get_Item(int32)
    IL_0055:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_005a:  brtrue.s   IL_005e

    IL_005c:  ldc.i4.0
    IL_005d:  ret

    IL_005e:  ldloc.1
    IL_005f:  ldc.i4.1
    IL_0060:  add
    IL_0061:  stloc.1
    IL_0062:  ldloc.1
    IL_0063:  ldarg.0
    IL_0064:  call       instance int32 Avro.EnumSchema::get_Count()
    IL_0069:  blt.s      IL_003d

    IL_006b:  ldloc.0
    IL_006c:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0071:  ldarg.0
    IL_0072:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0077:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_007c:  ret

    IL_007d:  ldc.i4.0
    IL_007e:  ret
  } // end of method EnumSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       79 (0x4f)
    .maxstack  3
    .locals init (int32 V_0,
             string V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000b:  ldarg.0
    IL_000c:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0011:  call       int32 Avro.Schema::getHashCode(object)
    IL_0016:  add
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_001e:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_0023:  stloc.2
    .try
    {
      IL_0024:  br.s       IL_0039

      IL_0026:  ldloc.2
      IL_0027:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
      IL_002c:  stloc.1
      IL_002d:  ldloc.0
      IL_002e:  ldc.i4.s   23
      IL_0030:  ldloc.1
      IL_0031:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0036:  mul
      IL_0037:  add
      IL_0038:  stloc.0
      IL_0039:  ldloc.2
      IL_003a:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_003f:  brtrue.s   IL_0026

      IL_0041:  leave.s    IL_004d

    }  // end .try
    finally
    {
      IL_0043:  ldloc.2
      IL_0044:  brfalse.s  IL_004c

      IL_0046:  ldloc.2
      IL_0047:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_004c:  endfinally
    }  // end handler
    IL_004d:  ldloc.0
    IL_004e:  ret
  } // end of method EnumSchema::GetHashCode

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       60 (0x3c)
    .maxstack  2
    .locals init (class Avro.EnumSchema V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldarg.0
    IL_0007:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000c:  beq.s      IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.EnumSchema
    IL_0016:  stloc.0
    IL_0017:  ldloc.0
    IL_0018:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_001d:  ldarg.0
    IL_001e:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0023:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0028:  brtrue.s   IL_003a

    IL_002a:  ldarg.0
    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0031:  call       instance bool Avro.NamedSchema::InAliases(class Avro.SchemaName)
    IL_0036:  brtrue.s   IL_003a

    IL_0038:  ldc.i4.0
    IL_0039:  ret

    IL_003a:  ldc.i4.1
    IL_003b:  ret
  } // end of method EnumSchema::CanRead

  .property instance class [mscorlib]System.Collections.Generic.IList`1<string>
          Symbols()
  {
    .get instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    .set instance void Avro.EnumSchema::set_Symbols(class [mscorlib]System.Collections.Generic.IList`1<string>)
  } // end of property EnumSchema::Symbols
  .property instance int32 Count()
  {
    .get instance int32 Avro.EnumSchema::get_Count()
  } // end of property EnumSchema::Count
  .property instance string Item(int32)
  {
    .get instance string Avro.EnumSchema::get_Item(int32)
  } // end of property EnumSchema::Item
} // end of class Avro.EnumSchema

.class public auto ansi beforefieldinit Avro.Field
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public SortOrder
         extends [mscorlib]System.Enum
  {
    .field public specialname rtspecialname int32 value__
    .field public static literal valuetype Avro.Field/SortOrder ascending = int32(0x00000000)
    .field public static literal valuetype Avro.Field/SortOrder descending = int32(0x00000001)
    .field public static literal valuetype Avro.Field/SortOrder ignore = int32(0x00000002)
  } // end of class SortOrder

  .field public initonly string Name
  .field public initonly class [mscorlib]System.Collections.Generic.IList`1<string> aliases
  .field private initonly class Avro.PropertyMap Props
  .field static assembly class [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenEqualityComparer JtokenEqual
  .field private int32 '<Pos>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<Documentation>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken '<DefaultValue>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> '<Ordering>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class Avro.Schema '<Schema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance int32 
          get_Pos() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Avro.Field::'<Pos>k__BackingField'
    IL_0006:  ret
  } // end of method Field::get_Pos

  .method private hidebysig specialname instance void 
          set_Pos(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Avro.Field::'<Pos>k__BackingField'
    IL_0007:  ret
  } // end of method Field::set_Pos

  .method public hidebysig specialname instance string 
          get_Documentation() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.Field::'<Documentation>k__BackingField'
    IL_0006:  ret
  } // end of method Field::get_Documentation

  .method private hidebysig specialname instance void 
          set_Documentation(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.Field::'<Documentation>k__BackingField'
    IL_0007:  ret
  } // end of method Field::set_Documentation

  .method public hidebysig specialname instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken 
          get_DefaultValue() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::'<DefaultValue>k__BackingField'
    IL_0006:  ret
  } // end of method Field::get_DefaultValue

  .method private hidebysig specialname instance void 
          set_DefaultValue(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::'<DefaultValue>k__BackingField'
    IL_0007:  ret
  } // end of method Field::set_DefaultValue

  .method public hidebysig specialname instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> 
          get_Ordering() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::'<Ordering>k__BackingField'
    IL_0006:  ret
  } // end of method Field::get_Ordering

  .method private hidebysig specialname instance void 
          set_Ordering(valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::'<Ordering>k__BackingField'
    IL_0007:  ret
  } // end of method Field::set_Ordering

  .method public hidebysig specialname instance class Avro.Schema 
          get_Schema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.Field::'<Schema>k__BackingField'
    IL_0006:  ret
  } // end of method Field::get_Schema

  .method private hidebysig specialname instance void 
          set_Schema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.Field::'<Schema>k__BackingField'
    IL_0007:  ret
  } // end of method Field::set_Schema

  .method assembly hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema schema,
                               string name,
                               class [mscorlib]System.Collections.Generic.IList`1<string> aliases,
                               int32 pos,
                               string doc,
                               class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken defaultValue,
                               valuetype Avro.Field/SortOrder sortorder,
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       116 (0x74)
    .maxstack  2
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.2
    IL_0007:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000c:  brfalse.s  IL_001e

    IL_000e:  ldstr      "name"
    IL_0013:  ldstr      "name cannot be null."
    IL_0018:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_001d:  throw

    IL_001e:  ldarg.1
    IL_001f:  brtrue.s   IL_0031

    IL_0021:  ldstr      "type"
    IL_0026:  ldstr      "type cannot be null."
    IL_002b:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0030:  throw

    IL_0031:  ldarg.0
    IL_0032:  ldarg.1
    IL_0033:  call       instance void Avro.Field::set_Schema(class Avro.Schema)
    IL_0038:  ldarg.0
    IL_0039:  ldarg.2
    IL_003a:  stfld      string Avro.Field::Name
    IL_003f:  ldarg.0
    IL_0040:  ldarg.3
    IL_0041:  stfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
    IL_0046:  ldarg.0
    IL_0047:  ldarg.s    pos
    IL_0049:  call       instance void Avro.Field::set_Pos(int32)
    IL_004e:  ldarg.0
    IL_004f:  ldarg.s    doc
    IL_0051:  call       instance void Avro.Field::set_Documentation(string)
    IL_0056:  ldarg.0
    IL_0057:  ldarg.s    defaultValue
    IL_0059:  call       instance void Avro.Field::set_DefaultValue(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_005e:  ldarg.0
    IL_005f:  ldarg.s    sortorder
    IL_0061:  newobj     instance void valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>::.ctor(!0)
    IL_0066:  call       instance void Avro.Field::set_Ordering(valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>)
    IL_006b:  ldarg.0
    IL_006c:  ldarg.s    props
    IL_006e:  stfld      class Avro.PropertyMap Avro.Field::Props
    IL_0073:  ret
  } // end of method Field::.ctor

  .method famorassem hidebysig instance void 
          writeJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       211 (0xd3)
    .maxstack  4
    .locals init (string V_0,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_1)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartObject()
    IL_0006:  ldarg.1
    IL_0007:  ldstr      "name"
    IL_000c:  ldarg.0
    IL_000d:  ldfld      string Avro.Field::Name
    IL_0012:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0017:  ldarg.1
    IL_0018:  ldstr      "doc"
    IL_001d:  ldarg.0
    IL_001e:  call       instance string Avro.Field::get_Documentation()
    IL_0023:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0028:  ldarg.0
    IL_0029:  call       instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
    IL_002e:  brfalse.s  IL_0048

    IL_0030:  ldarg.1
    IL_0031:  ldstr      "default"
    IL_0036:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_003b:  ldarg.0
    IL_003c:  call       instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
    IL_0041:  ldarg.1
    IL_0042:  ldnull
    IL_0043:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::WriteTo(class [Newtonsoft.Json]Newtonsoft.Json.JsonWriter,
                                                                                             class [Newtonsoft.Json]Newtonsoft.Json.JsonConverter[])
    IL_0048:  ldarg.0
    IL_0049:  call       instance class Avro.Schema Avro.Field::get_Schema()
    IL_004e:  brfalse.s  IL_0069

    IL_0050:  ldarg.1
    IL_0051:  ldstr      "type"
    IL_0056:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_005b:  ldarg.0
    IL_005c:  call       instance class Avro.Schema Avro.Field::get_Schema()
    IL_0061:  ldarg.1
    IL_0062:  ldarg.2
    IL_0063:  ldarg.3
    IL_0064:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_0069:  ldarg.0
    IL_006a:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_006f:  brfalse.s  IL_007d

    IL_0071:  ldarg.0
    IL_0072:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_0077:  ldarg.1
    IL_0078:  callvirt   instance void Avro.PropertyMap::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter)
    IL_007d:  ldarg.0
    IL_007e:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
    IL_0083:  brfalse.s  IL_00cc

    IL_0085:  ldarg.1
    IL_0086:  ldstr      "aliases"
    IL_008b:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0090:  ldarg.1
    IL_0091:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_0096:  ldarg.0
    IL_0097:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
    IL_009c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_00a1:  stloc.1
    .try
    {
      IL_00a2:  br.s       IL_00b2

      IL_00a4:  ldloc.1
      IL_00a5:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
      IL_00aa:  stloc.0
      IL_00ab:  ldarg.1
      IL_00ac:  ldloc.0
      IL_00ad:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
      IL_00b2:  ldloc.1
      IL_00b3:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00b8:  brtrue.s   IL_00a4

      IL_00ba:  leave.s    IL_00c6

    }  // end .try
    finally
    {
      IL_00bc:  ldloc.1
      IL_00bd:  brfalse.s  IL_00c5

      IL_00bf:  ldloc.1
      IL_00c0:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c5:  endfinally
    }  // end handler
    IL_00c6:  ldarg.1
    IL_00c7:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_00cc:  ldarg.1
    IL_00cd:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndObject()
    IL_00d2:  ret
  } // end of method Field::writeJson

  .method assembly hidebysig static class [mscorlib]System.Collections.Generic.IList`1<string> 
          GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok) cil managed
  {
    // Code size       113 (0x71)
    .maxstack  2
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0,
             class [mscorlib]System.Collections.Generic.List`1<string> V_1,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_3)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "aliases"
    IL_0006:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_0011

    IL_000f:  ldnull
    IL_0010:  ret

    IL_0011:  ldloc.0
    IL_0012:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0017:  ldc.i4.2
    IL_0018:  beq.s      IL_0025

    IL_001a:  ldstr      "Aliases must be of format JSON array of strings"
    IL_001f:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0024:  throw

    IL_0025:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
    IL_002a:  stloc.1
    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0031:  stloc.3
    .try
    {
      IL_0032:  br.s       IL_005b

      IL_0034:  ldloc.3
      IL_0035:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_003a:  stloc.2
      IL_003b:  ldloc.2
      IL_003c:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
      IL_0041:  ldc.i4.8
      IL_0042:  beq.s      IL_004f

      IL_0044:  ldstr      "Aliases must be of format JSON array of strings"
      IL_0049:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_004e:  throw

      IL_004f:  ldloc.1
      IL_0050:  ldloc.2
      IL_0051:  call       string [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_0056:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<string>::Add(!0)
      IL_005b:  ldloc.3
      IL_005c:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0061:  brtrue.s   IL_0034

      IL_0063:  leave.s    IL_006f

    }  // end .try
    finally
    {
      IL_0065:  ldloc.3
      IL_0066:  brfalse.s  IL_006e

      IL_0068:  ldloc.3
      IL_0069:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_006e:  endfinally
    }  // end handler
    IL_006f:  ldloc.1
    IL_0070:  ret
  } // end of method Field::GetAliases

  .method public hidebysig instance string 
          GetProperty(string key) cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  3
    .locals init (string V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_0006:  brtrue.s   IL_000a

    IL_0008:  ldnull
    IL_0009:  ret

    IL_000a:  ldarg.0
    IL_000b:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_0010:  ldarg.1
    IL_0011:  ldloca.s   V_0
    IL_0013:  callvirt   instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::TryGetValue(!0,
                                                                                                                           !1&)
    IL_0018:  brtrue.s   IL_001c

    IL_001a:  ldnull
    IL_001b:  ret

    IL_001c:  ldloc.0
    IL_001d:  ret
  } // end of method Field::GetProperty

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       176 (0xb0)
    .maxstack  3
    .locals init (class Avro.Field V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse    IL_00ae

    IL_000c:  ldarg.1
    IL_000d:  isinst     Avro.Field
    IL_0012:  brfalse    IL_00ae

    IL_0017:  ldarg.1
    IL_0018:  isinst     Avro.Field
    IL_001d:  stloc.0
    IL_001e:  ldloc.0
    IL_001f:  ldfld      string Avro.Field::Name
    IL_0024:  ldarg.0
    IL_0025:  ldfld      string Avro.Field::Name
    IL_002a:  call       bool Avro.Field::areEqual(object,
                                                   object)
    IL_002f:  brfalse.s  IL_00ac

    IL_0031:  ldloc.0
    IL_0032:  callvirt   instance int32 Avro.Field::get_Pos()
    IL_0037:  ldarg.0
    IL_0038:  call       instance int32 Avro.Field::get_Pos()
    IL_003d:  bne.un.s   IL_00ac

    IL_003f:  ldloc.0
    IL_0040:  callvirt   instance string Avro.Field::get_Documentation()
    IL_0045:  ldarg.0
    IL_0046:  call       instance string Avro.Field::get_Documentation()
    IL_004b:  call       bool Avro.Field::areEqual(object,
                                                   object)
    IL_0050:  brfalse.s  IL_00ac

    IL_0052:  ldloc.0
    IL_0053:  callvirt   instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::get_Ordering()
    IL_0058:  box        valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>
    IL_005d:  ldarg.0
    IL_005e:  call       instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::get_Ordering()
    IL_0063:  box        valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>
    IL_0068:  call       bool Avro.Field::areEqual(object,
                                                   object)
    IL_006d:  brfalse.s  IL_00ac

    IL_006f:  ldsfld     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenEqualityComparer Avro.Field::JtokenEqual
    IL_0074:  ldloc.0
    IL_0075:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
    IL_007a:  ldarg.0
    IL_007b:  call       instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
    IL_0080:  callvirt   instance bool [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenEqualityComparer::Equals(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                                            class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0085:  brfalse.s  IL_00ac

    IL_0087:  ldloc.0
    IL_0088:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
    IL_008d:  ldarg.0
    IL_008e:  call       instance class Avro.Schema Avro.Field::get_Schema()
    IL_0093:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0098:  brfalse.s  IL_00ac

    IL_009a:  ldloc.0
    IL_009b:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_00a0:  ldarg.0
    IL_00a1:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_00a6:  call       bool Avro.Field::areEqual(object,
                                                   object)
    IL_00ab:  ret

    IL_00ac:  ldc.i4.0
    IL_00ad:  ret

    IL_00ae:  ldc.i4.0
    IL_00af:  ret
  } // end of method Field::Equals

  .method private hidebysig static bool  areEqual(object o1,
                                                  object o2) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.0
    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_000a:  ret

    IL_000b:  ldarg.1
    IL_000c:  ldnull
    IL_000d:  ceq
    IL_000f:  ret
  } // end of method Field::areEqual

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       102 (0x66)
    .maxstack  3
    IL_0000:  ldc.i4.s   17
    IL_0002:  ldarg.0
    IL_0003:  ldfld      string Avro.Field::Name
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ldarg.0
    IL_000f:  call       instance int32 Avro.Field::get_Pos()
    IL_0014:  add
    IL_0015:  ldc.i4.s   19
    IL_0017:  ldarg.0
    IL_0018:  call       instance string Avro.Field::get_Documentation()
    IL_001d:  call       int32 Avro.Field::getHashCode(object)
    IL_0022:  mul
    IL_0023:  add
    IL_0024:  ldc.i4.s   23
    IL_0026:  ldarg.0
    IL_0027:  call       instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::get_Ordering()
    IL_002c:  box        valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>
    IL_0031:  call       int32 Avro.Field::getHashCode(object)
    IL_0036:  mul
    IL_0037:  add
    IL_0038:  ldc.i4.s   29
    IL_003a:  ldarg.0
    IL_003b:  call       instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
    IL_0040:  call       int32 Avro.Field::getHashCode(object)
    IL_0045:  mul
    IL_0046:  add
    IL_0047:  ldc.i4.s   31
    IL_0049:  ldarg.0
    IL_004a:  call       instance class Avro.Schema Avro.Field::get_Schema()
    IL_004f:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0054:  mul
    IL_0055:  add
    IL_0056:  ldc.i4.s   37
    IL_0058:  ldarg.0
    IL_0059:  ldfld      class Avro.PropertyMap Avro.Field::Props
    IL_005e:  call       int32 Avro.Field::getHashCode(object)
    IL_0063:  mul
    IL_0064:  add
    IL_0065:  ret
  } // end of method Field::GetHashCode

  .method private hidebysig static int32 
          getHashCode(object obj) cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000a

    IL_0003:  ldarg.0
    IL_0004:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0009:  ret

    IL_000a:  ldc.i4.0
    IL_000b:  ret
  } // end of method Field::getHashCode

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenEqualityComparer::.ctor()
    IL_0005:  stsfld     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenEqualityComparer Avro.Field::JtokenEqual
    IL_000a:  ret
  } // end of method Field::.cctor

  .property instance int32 Pos()
  {
    .get instance int32 Avro.Field::get_Pos()
    .set instance void Avro.Field::set_Pos(int32)
  } // end of property Field::Pos
  .property instance string Documentation()
  {
    .set instance void Avro.Field::set_Documentation(string)
    .get instance string Avro.Field::get_Documentation()
  } // end of property Field::Documentation
  .property instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken
          DefaultValue()
  {
    .set instance void Avro.Field::set_DefaultValue(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    .get instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
  } // end of property Field::DefaultValue
  .property instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>
          Ordering()
  {
    .get instance valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder> Avro.Field::get_Ordering()
    .set instance void Avro.Field::set_Ordering(valuetype [mscorlib]System.Nullable`1<valuetype Avro.Field/SortOrder>)
  } // end of property Field::Ordering
  .property instance class Avro.Schema Schema()
  {
    .set instance void Avro.Field::set_Schema(class Avro.Schema)
    .get instance class Avro.Schema Avro.Field::get_Schema()
  } // end of property Field::Schema
} // end of class Avro.Field

.class public auto ansi beforefieldinit Avro.FixedSchema
       extends Avro.NamedSchema
{
  .field private int32 '<Size>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance int32 
          get_Size() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      int32 Avro.FixedSchema::'<Size>k__BackingField'
    IL_0006:  ret
  } // end of method FixedSchema::get_Size

  .method public hidebysig specialname instance void 
          set_Size(int32 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      int32 Avro.FixedSchema::'<Size>k__BackingField'
    IL_0007:  ret
  } // end of method FixedSchema::set_Size

  .method assembly hidebysig static class Avro.FixedSchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       48 (0x30)
    .maxstack  5
    .locals init (class Avro.SchemaName V_0,
             class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.3
    IL_0002:  call       class Avro.SchemaName Avro.NamedSchema::GetName(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                         string)
    IL_0007:  stloc.0
    IL_0008:  ldarg.0
    IL_0009:  ldloc.0
    IL_000a:  callvirt   instance string Avro.SchemaName::get_Space()
    IL_000f:  ldloc.0
    IL_0010:  callvirt   instance string Avro.SchemaName::get_EncSpace()
    IL_0015:  call       class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                                                                string,
                                                                                                                                string)
    IL_001a:  stloc.1
    IL_001b:  ldloc.0
    IL_001c:  ldloc.1
    IL_001d:  ldarg.0
    IL_001e:  ldstr      "size"
    IL_0023:  call       int32 Avro.JsonHelper::GetRequiredInteger(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0028:  ldarg.1
    IL_0029:  ldarg.2
    IL_002a:  newobj     instance void Avro.FixedSchema::.ctor(class Avro.SchemaName,
                                                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                               int32,
                                                               class Avro.PropertyMap,
                                                               class Avro.SchemaNames)
    IL_002f:  ret
  } // end of method FixedSchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.SchemaName name,
                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> aliases,
                               int32 size,
                               class Avro.PropertyMap props,
                               class Avro.SchemaNames names) cil managed
  {
    // Code size       61 (0x3d)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   13
    IL_0003:  ldarg.1
    IL_0004:  ldarg.2
    IL_0005:  ldarg.s    props
    IL_0007:  ldarg.s    names
    IL_0009:  call       instance void Avro.NamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                               class Avro.SchemaName,
                                                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                               class Avro.PropertyMap,
                                                               class Avro.SchemaNames)
    IL_000e:  ldarg.1
    IL_000f:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_0014:  brtrue.s   IL_0021

    IL_0016:  ldstr      "name cannot be null for fixed schema."
    IL_001b:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0020:  throw

    IL_0021:  ldarg.3
    IL_0022:  ldc.i4.0
    IL_0023:  bgt.s      IL_0035

    IL_0025:  ldstr      "size"
    IL_002a:  ldstr      "size must be greater than zero."
    IL_002f:  newobj     instance void [mscorlib]System.ArgumentOutOfRangeException::.ctor(string,
                                                                                           string)
    IL_0034:  throw

    IL_0035:  ldarg.0
    IL_0036:  ldarg.3
    IL_0037:  call       instance void Avro.FixedSchema::set_Size(int32)
    IL_003c:  ret
  } // end of method FixedSchema::.ctor

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance void Avro.NamedSchema::WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                         class Avro.SchemaNames,
                                                                         string)
    IL_0009:  ldarg.1
    IL_000a:  ldstr      "size"
    IL_000f:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0014:  ldarg.1
    IL_0015:  ldarg.0
    IL_0016:  call       instance int32 Avro.FixedSchema::get_Size()
    IL_001b:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(int32)
    IL_0020:  ret
  } // end of method FixedSchema::WriteJsonFields

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       79 (0x4f)
    .maxstack  2
    .locals init (class Avro.FixedSchema V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_004d

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.FixedSchema
    IL_000f:  brfalse.s  IL_004d

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.FixedSchema
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_004b

    IL_002b:  ldarg.0
    IL_002c:  call       instance int32 Avro.FixedSchema::get_Size()
    IL_0031:  ldloc.0
    IL_0032:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0037:  bne.un.s   IL_004b

    IL_0039:  ldloc.0
    IL_003a:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_003f:  ldarg.0
    IL_0040:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0045:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_004a:  ret

    IL_004b:  ldc.i4.0
    IL_004c:  ret

    IL_004d:  ldc.i4.0
    IL_004e:  ret
  } // end of method FixedSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       37 (0x25)
    .maxstack  8
    IL_0000:  ldc.i4.s   53
    IL_0002:  ldarg.0
    IL_0003:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ldc.i4.s   47
    IL_0010:  ldarg.0
    IL_0011:  call       instance int32 Avro.FixedSchema::get_Size()
    IL_0016:  mul
    IL_0017:  add
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_001e:  call       int32 Avro.Schema::getHashCode(object)
    IL_0023:  add
    IL_0024:  ret
  } // end of method FixedSchema::GetHashCode

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       73 (0x49)
    .maxstack  2
    .locals init (class Avro.FixedSchema V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldarg.0
    IL_0007:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000c:  beq.s      IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.FixedSchema
    IL_0016:  stloc.0
    IL_0017:  ldloc.0
    IL_0018:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_001d:  ldarg.0
    IL_001e:  call       instance int32 Avro.FixedSchema::get_Size()
    IL_0023:  beq.s      IL_0027

    IL_0025:  ldc.i4.0
    IL_0026:  ret

    IL_0027:  ldloc.0
    IL_0028:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_002d:  ldarg.0
    IL_002e:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0033:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0038:  brfalse.s  IL_003c

    IL_003a:  ldc.i4.1
    IL_003b:  ret

    IL_003c:  ldarg.0
    IL_003d:  ldloc.0
    IL_003e:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0043:  call       instance bool Avro.NamedSchema::InAliases(class Avro.SchemaName)
    IL_0048:  ret
  } // end of method FixedSchema::CanRead

  .property instance int32 Size()
  {
    .get instance int32 Avro.FixedSchema::get_Size()
    .set instance void Avro.FixedSchema::set_Size(int32)
  } // end of property FixedSchema::Size
} // end of class Avro.FixedSchema

.class private auto ansi beforefieldinit Avro.JsonHelper
       extends [mscorlib]System.Object
{
  .method public hidebysig static string 
          GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                            string 'field') cil managed
  {
    // Code size       114 (0x72)
    .maxstack  4
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0,
             string V_1,
             char[] V_2)
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0013

    IL_0003:  ldstr      "jtok"
    IL_0008:  ldstr      "jtok cannot be null."
    IL_000d:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0012:  throw

    IL_0013:  ldarg.1
    IL_0014:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0019:  brfalse.s  IL_002b

    IL_001b:  ldstr      "field"
    IL_0020:  ldstr      "field cannot be null."
    IL_0025:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_002a:  throw

    IL_002b:  ldarg.0
    IL_002c:  ldarg.1
    IL_002d:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0032:  stloc.0
    IL_0033:  ldloc.0
    IL_0034:  brtrue.s   IL_0038

    IL_0036:  ldnull
    IL_0037:  ret

    IL_0038:  ldloc.0
    IL_0039:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_003e:  ldc.i4.8
    IL_003f:  bne.un.s   IL_005c

    IL_0041:  ldloc.0
    IL_0042:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0047:  stloc.1
    IL_0048:  ldloc.1
    IL_0049:  ldc.i4.1
    IL_004a:  newarr     [mscorlib]System.Char
    IL_004f:  stloc.2
    IL_0050:  ldloc.2
    IL_0051:  ldc.i4.0
    IL_0052:  ldc.i4.s   34
    IL_0054:  stelem.i2
    IL_0055:  ldloc.2
    IL_0056:  callvirt   instance string [mscorlib]System.String::Trim(char[])
    IL_005b:  ret

    IL_005c:  ldstr      "Field "
    IL_0061:  ldarg.1
    IL_0062:  ldstr      " is not a string"
    IL_0067:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_006c:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0071:  throw
  } // end of method JsonHelper::GetOptionalString

  .method public hidebysig static string 
          GetRequiredString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                            string 'field') cil managed
  {
    // Code size       36 (0x24)
    .maxstack  3
    .locals init (string V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0007:  stloc.0
    IL_0008:  ldloc.0
    IL_0009:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000e:  brfalse.s  IL_0022

    IL_0010:  ldstr      "No \"{0}\" JSON field: {1}"
    IL_0015:  ldarg.1
    IL_0016:  ldarg.0
    IL_0017:  call       string [mscorlib]System.String::Format(string,
                                                                object,
                                                                object)
    IL_001c:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0021:  throw

    IL_0022:  ldloc.0
    IL_0023:  ret
  } // end of method JsonHelper::GetRequiredString

  .method public hidebysig static int32  GetRequiredInteger(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                                                            string 'field') cil managed
  {
    // Code size       73 (0x49)
    .maxstack  3
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0)
    IL_0000:  ldarg.1
    IL_0001:  call       void Avro.JsonHelper::ensureValidFieldName(string)
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000d:  stloc.0
    IL_000e:  ldloc.0
    IL_000f:  brtrue.s   IL_0023

    IL_0011:  ldstr      "No \"{0}\" JSON field: {1}"
    IL_0016:  ldarg.1
    IL_0017:  ldarg.0
    IL_0018:  call       string [mscorlib]System.String::Format(string,
                                                                object,
                                                                object)
    IL_001d:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0022:  throw

    IL_0023:  ldloc.0
    IL_0024:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0029:  ldc.i4.6
    IL_002a:  bne.un.s   IL_0033

    IL_002c:  ldloc.0
    IL_002d:  call       int32 [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0032:  ret

    IL_0033:  ldstr      "Field "
    IL_0038:  ldarg.1
    IL_0039:  ldstr      " is not an integer"
    IL_003e:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0043:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0048:  throw
  } // end of method JsonHelper::GetRequiredInteger

  .method public hidebysig static valuetype [mscorlib]System.Nullable`1<bool> 
          GetOptionalBoolean(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                             string 'field') cil managed
  {
    // Code size       108 (0x6c)
    .maxstack  3
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0,
             valuetype [mscorlib]System.Nullable`1<bool> V_1)
    IL_0000:  ldarg.0
    IL_0001:  brtrue.s   IL_0013

    IL_0003:  ldstr      "jtok"
    IL_0008:  ldstr      "jtok cannot be null."
    IL_000d:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_0012:  throw

    IL_0013:  ldarg.1
    IL_0014:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0019:  brfalse.s  IL_002b

    IL_001b:  ldstr      "field"
    IL_0020:  ldstr      "field cannot be null."
    IL_0025:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_002a:  throw

    IL_002b:  ldarg.0
    IL_002c:  ldarg.1
    IL_002d:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0032:  stloc.0
    IL_0033:  ldloc.0
    IL_0034:  brtrue.s   IL_0040

    IL_0036:  ldloca.s   V_1
    IL_0038:  initobj    valuetype [mscorlib]System.Nullable`1<bool>
    IL_003e:  ldloc.1
    IL_003f:  ret

    IL_0040:  ldloc.0
    IL_0041:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0046:  ldc.i4.s   9
    IL_0048:  bne.un.s   IL_0056

    IL_004a:  ldloc.0
    IL_004b:  call       bool [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::op_Explicit(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0050:  newobj     instance void valuetype [mscorlib]System.Nullable`1<bool>::.ctor(!0)
    IL_0055:  ret

    IL_0056:  ldstr      "Field "
    IL_005b:  ldarg.1
    IL_005c:  ldstr      " is not a boolean"
    IL_0061:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0066:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_006b:  throw
  } // end of method JsonHelper::GetOptionalBoolean

  .method assembly hidebysig static void 
          writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                                string key,
                                string 'value') cil managed
  {
    // Code size       24 (0x18)
    .maxstack  8
    IL_0000:  ldarg.2
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0009

    IL_0008:  ret

    IL_0009:  ldarg.0
    IL_000a:  ldarg.1
    IL_000b:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0010:  ldarg.0
    IL_0011:  ldarg.2
    IL_0012:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
    IL_0017:  ret
  } // end of method JsonHelper::writeIfNotNullOrEmpty

  .method private hidebysig static void  ensureValidFieldName(string name) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0013

    IL_0008:  ldstr      "name"
    IL_000d:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ret
  } // end of method JsonHelper::ensureValidFieldName

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ret
  } // end of method JsonHelper::.ctor

} // end of class Avro.JsonHelper

.class public auto ansi beforefieldinit Avro.MapSchema
       extends Avro.UnnamedSchema
{
  .field private class Avro.Schema '<ValueSchema>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class Avro.Schema 
          get_ValueSchema() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Schema Avro.MapSchema::'<ValueSchema>k__BackingField'
    IL_0006:  ret
  } // end of method MapSchema::get_ValueSchema

  .method public hidebysig specialname instance void 
          set_ValueSchema(class Avro.Schema 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class Avro.Schema Avro.MapSchema::'<ValueSchema>k__BackingField'
    IL_0007:  ret
  } // end of method MapSchema::set_ValueSchema

  .method assembly hidebysig static class Avro.MapSchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       41 (0x29)
    .maxstack  3
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "values"
    IL_0006:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  brtrue.s   IL_001a

    IL_000f:  ldstr      "Map does not have 'values'"
    IL_0014:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0019:  throw

    IL_001a:  ldloc.0
    IL_001b:  ldarg.2
    IL_001c:  ldarg.3
    IL_001d:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_0022:  ldarg.1
    IL_0023:  newobj     instance void Avro.MapSchema::.ctor(class Avro.Schema,
                                                             class Avro.PropertyMap)
    IL_0028:  ret
  } // end of method MapSchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema valueSchema,
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       36 (0x24)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   11
    IL_0003:  ldarg.2
    IL_0004:  call       instance void Avro.UnnamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                                 class Avro.PropertyMap)
    IL_0009:  ldarg.1
    IL_000a:  brtrue.s   IL_001c

    IL_000c:  ldstr      "valueSchema"
    IL_0011:  ldstr      "valueSchema cannot be null."
    IL_0016:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string,
                                                                                     string)
    IL_001b:  throw

    IL_001c:  ldarg.0
    IL_001d:  ldarg.1
    IL_001e:  call       instance void Avro.MapSchema::set_ValueSchema(class Avro.Schema)
    IL_0023:  ret
  } // end of method MapSchema::.ctor

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldstr      "values"
    IL_0006:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_000b:  ldarg.0
    IL_000c:  call       instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0011:  ldarg.1
    IL_0012:  ldarg.2
    IL_0013:  ldarg.3
    IL_0014:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                              class Avro.SchemaNames,
                                                              string)
    IL_0019:  ret
  } // end of method MapSchema::WriteJsonFields

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       41 (0x29)
    .maxstack  2
    .locals init (class Avro.MapSchema V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldarg.0
    IL_0007:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000c:  beq.s      IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.1
    IL_0011:  isinst     Avro.MapSchema
    IL_0016:  stloc.0
    IL_0017:  ldarg.0
    IL_0018:  call       instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0023:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
    IL_0028:  ret
  } // end of method MapSchema::CanRead

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  2
    .locals init (class Avro.MapSchema V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_003d

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.MapSchema
    IL_000f:  brfalse.s  IL_003d

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.MapSchema
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0024:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_0029:  brfalse.s  IL_003d

    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0031:  ldarg.0
    IL_0032:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0037:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_003c:  ret

    IL_003d:  ldc.i4.0
    IL_003e:  ret
  } // end of method MapSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  8
    IL_0000:  ldc.i4.s   29
    IL_0002:  ldarg.0
    IL_0003:  call       instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0008:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000d:  mul
    IL_000e:  ldarg.0
    IL_000f:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0014:  call       int32 Avro.Schema::getHashCode(object)
    IL_0019:  add
    IL_001a:  ret
  } // end of method MapSchema::GetHashCode

  .property instance class Avro.Schema ValueSchema()
  {
    .get instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    .set instance void Avro.MapSchema::set_ValueSchema(class Avro.Schema)
  } // end of property MapSchema::ValueSchema
} // end of class Avro.MapSchema

.class public auto ansi sealed beforefieldinit Avro.PrimitiveSchema
       extends Avro.UnnamedSchema
{
  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Avro.Schema/Type 'type',
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.UnnamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                                 class Avro.PropertyMap)
    IL_0008:  ret
  } // end of method PrimitiveSchema::.ctor

  .method public hidebysig static class Avro.PrimitiveSchema 
          NewInstance(string 'type',
                      [opt] class Avro.PropertyMap props) cil managed
  {
    .param [2] = nullref
    // Code size       292 (0x124)
    .maxstack  4
    .locals init (string V_0,
             int32 V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "\""
    IL_0006:  callvirt   instance bool [mscorlib]System.String::StartsWith(string)
    IL_000b:  brfalse.s  IL_002b

    IL_000d:  ldarg.0
    IL_000e:  ldstr      "\""
    IL_0013:  callvirt   instance bool [mscorlib]System.String::EndsWith(string)
    IL_0018:  brfalse.s  IL_002b

    IL_001a:  ldarg.0
    IL_001b:  ldc.i4.1
    IL_001c:  ldarg.0
    IL_001d:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0022:  ldc.i4.2
    IL_0023:  sub
    IL_0024:  callvirt   instance string [mscorlib]System.String::Substring(int32,
                                                                            int32)
    IL_0029:  starg.s    'type'
    IL_002b:  ldarg.0
    IL_002c:  dup
    IL_002d:  stloc.0
    IL_002e:  brfalse    IL_0122

    IL_0033:  volatile.
    IL_0035:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32> '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'::'$$method0x6000203-1'
    IL_003a:  brtrue.s   IL_00a9

    IL_003c:  ldc.i4.8
    IL_003d:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::.ctor(int32)
    IL_0042:  dup
    IL_0043:  ldstr      "null"
    IL_0048:  ldc.i4.0
    IL_0049:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_004e:  dup
    IL_004f:  ldstr      "boolean"
    IL_0054:  ldc.i4.1
    IL_0055:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_005a:  dup
    IL_005b:  ldstr      "int"
    IL_0060:  ldc.i4.2
    IL_0061:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_0066:  dup
    IL_0067:  ldstr      "long"
    IL_006c:  ldc.i4.3
    IL_006d:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_0072:  dup
    IL_0073:  ldstr      "float"
    IL_0078:  ldc.i4.4
    IL_0079:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_007e:  dup
    IL_007f:  ldstr      "double"
    IL_0084:  ldc.i4.5
    IL_0085:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_008a:  dup
    IL_008b:  ldstr      "bytes"
    IL_0090:  ldc.i4.6
    IL_0091:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_0096:  dup
    IL_0097:  ldstr      "string"
    IL_009c:  ldc.i4.7
    IL_009d:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::Add(!0,
                                                                                                                  !1)
    IL_00a2:  volatile.
    IL_00a4:  stsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32> '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'::'$$method0x6000203-1'
    IL_00a9:  volatile.
    IL_00ab:  ldsfld     class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32> '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'::'$$method0x6000203-1'
    IL_00b0:  ldloc.0
    IL_00b1:  ldloca.s   V_1
    IL_00b3:  call       instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32>::TryGetValue(!0,
                                                                                                                          !1&)
    IL_00b8:  brfalse.s  IL_0122

    IL_00ba:  ldloc.1
    IL_00bb:  switch     ( 
                          IL_00e2,
                          IL_00ea,
                          IL_00f2,
                          IL_00fa,
                          IL_0102,
                          IL_010a,
                          IL_0112,
                          IL_011a)
    IL_00e0:  br.s       IL_0122

    IL_00e2:  ldc.i4.0
    IL_00e3:  ldarg.1
    IL_00e4:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_00e9:  ret

    IL_00ea:  ldc.i4.1
    IL_00eb:  ldarg.1
    IL_00ec:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_00f1:  ret

    IL_00f2:  ldc.i4.2
    IL_00f3:  ldarg.1
    IL_00f4:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_00f9:  ret

    IL_00fa:  ldc.i4.3
    IL_00fb:  ldarg.1
    IL_00fc:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_0101:  ret

    IL_0102:  ldc.i4.4
    IL_0103:  ldarg.1
    IL_0104:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_0109:  ret

    IL_010a:  ldc.i4.5
    IL_010b:  ldarg.1
    IL_010c:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_0111:  ret

    IL_0112:  ldc.i4.6
    IL_0113:  ldarg.1
    IL_0114:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_0119:  ret

    IL_011a:  ldc.i4.7
    IL_011b:  ldarg.1
    IL_011c:  newobj     instance void Avro.PrimitiveSchema::.ctor(valuetype Avro.Schema/Type,
                                                                   class Avro.PropertyMap)
    IL_0121:  ret

    IL_0122:  ldnull
    IL_0123:  ret
  } // end of method PrimitiveSchema::NewInstance

  .method famorassem hidebysig virtual instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter w,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  callvirt   instance string Avro.Schema::get_Name()
    IL_0007:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteValue(string)
    IL_000c:  ret
  } // end of method PrimitiveSchema::WriteJson

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       93 (0x5d)
    .maxstack  2
    .locals init (valuetype Avro.Schema/Type V_0,
             valuetype Avro.Schema/Type V_1)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.UnionSchema
    IL_0006:  brtrue.s   IL_0016

    IL_0008:  ldarg.0
    IL_0009:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_000e:  ldarg.1
    IL_000f:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0014:  bne.un.s   IL_0018

    IL_0016:  ldc.i4.1
    IL_0017:  ret

    IL_0018:  ldarg.1
    IL_0019:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_001e:  stloc.0
    IL_001f:  ldarg.0
    IL_0020:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0025:  stloc.1
    IL_0026:  ldloc.1
    IL_0027:  ldc.i4.3
    IL_0028:  sub
    IL_0029:  switch     ( 
                          IL_0056,
                          IL_004b,
                          IL_003c)
    IL_003a:  br.s       IL_005b

    IL_003c:  ldloc.0
    IL_003d:  ldc.i4.2
    IL_003e:  beq.s      IL_0049

    IL_0040:  ldloc.0
    IL_0041:  ldc.i4.3
    IL_0042:  beq.s      IL_0049

    IL_0044:  ldloc.0
    IL_0045:  ldc.i4.4
    IL_0046:  ceq
    IL_0048:  ret

    IL_0049:  ldc.i4.1
    IL_004a:  ret

    IL_004b:  ldloc.0
    IL_004c:  ldc.i4.2
    IL_004d:  beq.s      IL_0054

    IL_004f:  ldloc.0
    IL_0050:  ldc.i4.3
    IL_0051:  ceq
    IL_0053:  ret

    IL_0054:  ldc.i4.1
    IL_0055:  ret

    IL_0056:  ldloc.0
    IL_0057:  ldc.i4.2
    IL_0058:  ceq
    IL_005a:  ret

    IL_005b:  ldc.i4.0
    IL_005c:  ret
  } // end of method PrimitiveSchema::CanRead

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       58 (0x3a)
    .maxstack  2
    .locals init (class Avro.PrimitiveSchema V_0)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0038

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.PrimitiveSchema
    IL_000f:  brfalse.s  IL_0038

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.PrimitiveSchema
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0024:  bne.un.s   IL_0038

    IL_0026:  ldloc.0
    IL_0027:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_002c:  ldarg.0
    IL_002d:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0032:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_0037:  ret

    IL_0038:  ldc.i4.0
    IL_0039:  ret
  } // end of method PrimitiveSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       32 (0x20)
    .maxstack  8
    IL_0000:  ldc.i4.s   13
    IL_0002:  ldarg.0
    IL_0003:  call       instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0008:  box        Avro.Schema/Type
    IL_000d:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_0012:  mul
    IL_0013:  ldarg.0
    IL_0014:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0019:  call       int32 Avro.Schema::getHashCode(object)
    IL_001e:  add
    IL_001f:  ret
  } // end of method PrimitiveSchema::GetHashCode

} // end of class Avro.PrimitiveSchema

.class public auto ansi beforefieldinit Avro.PropertyMap
       extends class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>
{
  .field private static initonly class [System.Core]System.Collections.Generic.HashSet`1<string> ReservedProps
  .method public hidebysig instance void 
          Parse(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok) cil managed
  {
    // Code size       104 (0x68)
    .maxstack  3
    .locals init (class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject V_0,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty> V_2)
    IL_0000:  ldarg.1
    IL_0001:  isinst     [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance class [mscorlib_4]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty> [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject::Properties()
    IL_000d:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty>::GetEnumerator()
    IL_0012:  stloc.2
    .try
    {
      IL_0013:  br.s       IL_0053

      IL_0015:  ldloc.2
      IL_0016:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty>::get_Current()
      IL_001b:  stloc.1
      IL_001c:  ldsfld     class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.PropertyMap::ReservedProps
      IL_0021:  ldloc.1
      IL_0022:  callvirt   instance string [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Name()
      IL_0027:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Contains(!0)
      IL_002c:  brtrue.s   IL_0053

      IL_002e:  ldarg.0
      IL_002f:  ldloc.1
      IL_0030:  callvirt   instance string [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Name()
      IL_0035:  call       instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::ContainsKey(!0)
      IL_003a:  brtrue.s   IL_0053

      IL_003c:  ldarg.0
      IL_003d:  ldloc.1
      IL_003e:  callvirt   instance string [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Name()
      IL_0043:  ldloc.1
      IL_0044:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JProperty::get_Value()
      IL_0049:  callvirt   instance string [mscorlib]System.Object::ToString()
      IL_004e:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::Add(!0,
                                                                                                                     !1)
      IL_0053:  ldloc.2
      IL_0054:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0059:  brtrue.s   IL_0015

      IL_005b:  leave.s    IL_0067

    }  // end .try
    finally
    {
      IL_005d:  ldloc.2
      IL_005e:  brfalse.s  IL_0066

      IL_0060:  ldloc.2
      IL_0061:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0066:  endfinally
    }  // end handler
    IL_0067:  ret
  } // end of method PropertyMap::Parse

  .method public hidebysig instance void 
          Set(string key,
              string 'value') cil managed
  {
    // Code size       76 (0x4c)
    .maxstack  3
    .locals init (string V_0)
    IL_0000:  ldsfld     class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.PropertyMap::ReservedProps
    IL_0005:  ldarg.1
    IL_0006:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Contains(!0)
    IL_000b:  brfalse.s  IL_001e

    IL_000d:  ldstr      "Can't set reserved property: "
    IL_0012:  ldarg.1
    IL_0013:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0018:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001d:  throw

    IL_001e:  ldarg.0
    IL_001f:  ldarg.1
    IL_0020:  ldloca.s   V_0
    IL_0022:  call       instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::TryGetValue(!0,
                                                                                                                           !1&)
    IL_0027:  brfalse.s  IL_0043

    IL_0029:  ldloc.0
    IL_002a:  ldarg.2
    IL_002b:  callvirt   instance bool [mscorlib]System.String::Equals(string)
    IL_0030:  brtrue.s   IL_004b

    IL_0032:  ldstr      "Property cannot be overwritten: "
    IL_0037:  ldarg.1
    IL_0038:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_003d:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0042:  throw

    IL_0043:  ldarg.0
    IL_0044:  ldarg.1
    IL_0045:  ldarg.2
    IL_0046:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::Add(!0,
                                                                                                                   !1)
    IL_004b:  ret
  } // end of method PropertyMap::Set

  .method public hidebysig instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer) cil managed
  {
    // Code size       88 (0x58)
    .maxstack  2
    .locals init (valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string> V_0,
             valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string> V_1)
    IL_0000:  ldarg.0
    IL_0001:  call       instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::GetEnumerator()
    IL_0006:  stloc.1
    .try
    {
      IL_0007:  br.s       IL_003e

      IL_0009:  ldloca.s   V_1
      IL_000b:  call       instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0,!1> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::get_Current()
      IL_0010:  stloc.0
      IL_0011:  ldsfld     class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.PropertyMap::ReservedProps
      IL_0016:  ldloca.s   V_0
      IL_0018:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Key()
      IL_001d:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Contains(!0)
      IL_0022:  brtrue.s   IL_003e

      IL_0024:  ldarg.1
      IL_0025:  ldloca.s   V_0
      IL_0027:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Key()
      IL_002c:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
      IL_0031:  ldarg.1
      IL_0032:  ldloca.s   V_0
      IL_0034:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Value()
      IL_0039:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteRawValue(string)
      IL_003e:  ldloca.s   V_1
      IL_0040:  call       instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::MoveNext()
      IL_0045:  brtrue.s   IL_0009

      IL_0047:  leave.s    IL_0057

    }  // end .try
    finally
    {
      IL_0049:  ldloca.s   V_1
      IL_004b:  constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>
      IL_0051:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0056:  endfinally
    }  // end handler
    IL_0057:  ret
  } // end of method PropertyMap::WriteJson

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       138 (0x8a)
    .maxstack  3
    .locals init (class Avro.PropertyMap V_0,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string> V_1,
             bool V_2,
             valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string> V_3)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0086

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.PropertyMap
    IL_000f:  brfalse.s  IL_0086

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.PropertyMap
    IL_0017:  stloc.0
    IL_0018:  ldarg.0
    IL_0019:  call       instance int32 class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::get_Count()
    IL_001e:  ldloc.0
    IL_001f:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::get_Count()
    IL_0024:  beq.s      IL_0028

    IL_0026:  ldc.i4.0
    IL_0027:  ret

    IL_0028:  ldarg.0
    IL_0029:  call       instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::GetEnumerator()
    IL_002e:  stloc.3
    .try
    {
      IL_002f:  br.s       IL_006b

      IL_0031:  ldloca.s   V_3
      IL_0033:  call       instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0,!1> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::get_Current()
      IL_0038:  stloc.1
      IL_0039:  ldloc.0
      IL_003a:  ldloca.s   V_1
      IL_003c:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Key()
      IL_0041:  callvirt   instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::ContainsKey(!0)
      IL_0046:  brtrue.s   IL_004c

      IL_0048:  ldc.i4.0
      IL_0049:  stloc.2
      IL_004a:  leave.s    IL_0088

      IL_004c:  ldloca.s   V_1
      IL_004e:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Value()
      IL_0053:  ldloc.0
      IL_0054:  ldloca.s   V_1
      IL_0056:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Key()
      IL_005b:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::get_Item(!0)
      IL_0060:  callvirt   instance bool [mscorlib]System.String::Equals(string)
      IL_0065:  brtrue.s   IL_006b

      IL_0067:  ldc.i4.0
      IL_0068:  stloc.2
      IL_0069:  leave.s    IL_0088

      IL_006b:  ldloca.s   V_3
      IL_006d:  call       instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::MoveNext()
      IL_0072:  brtrue.s   IL_0031

      IL_0074:  leave.s    IL_0084

    }  // end .try
    finally
    {
      IL_0076:  ldloca.s   V_3
      IL_0078:  constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>
      IL_007e:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0083:  endfinally
    }  // end handler
    IL_0084:  ldc.i4.1
    IL_0085:  ret

    IL_0086:  ldc.i4.0
    IL_0087:  ret

    IL_0088:  ldloc.2
    IL_0089:  ret
  } // end of method PropertyMap::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       87 (0x57)
    .maxstack  5
    .locals init (int32 V_0,
             int32 V_1,
             valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string> V_2,
             valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string> V_3)
    IL_0000:  ldarg.0
    IL_0001:  call       instance int32 class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::get_Count()
    IL_0006:  stloc.0
    IL_0007:  ldc.i4.1
    IL_0008:  stloc.1
    IL_0009:  ldarg.0
    IL_000a:  call       instance valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<!0,!1> class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::GetEnumerator()
    IL_000f:  stloc.3
    .try
    {
      IL_0010:  br.s       IL_003c

      IL_0012:  ldloca.s   V_3
      IL_0014:  call       instance valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<!0,!1> valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::get_Current()
      IL_0019:  stloc.2
      IL_001a:  ldloc.0
      IL_001b:  ldloca.s   V_2
      IL_001d:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Key()
      IL_0022:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0027:  ldloca.s   V_2
      IL_0029:  call       instance !1 valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<string,string>::get_Value()
      IL_002e:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0033:  add
      IL_0034:  ldloc.1
      IL_0035:  dup
      IL_0036:  ldc.i4.1
      IL_0037:  add
      IL_0038:  stloc.1
      IL_0039:  mul
      IL_003a:  add
      IL_003b:  stloc.0
      IL_003c:  ldloca.s   V_3
      IL_003e:  call       instance bool valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>::MoveNext()
      IL_0043:  brtrue.s   IL_0012

      IL_0045:  leave.s    IL_0055

    }  // end .try
    finally
    {
      IL_0047:  ldloca.s   V_3
      IL_0049:  constrained. valuetype [mscorlib]System.Collections.Generic.Dictionary`2/Enumerator<string,string>
      IL_004f:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0054:  endfinally
    }  // end handler
    IL_0055:  ldloc.0
    IL_0056:  ret
  } // end of method PropertyMap::GetHashCode

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::.ctor()
    IL_0006:  ret
  } // end of method PropertyMap::.ctor

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       157 (0x9d)
    .maxstack  2
    .locals init (class [System.Core]System.Collections.Generic.HashSet`1<string> V_0)
    IL_0000:  newobj     instance void class [System.Core]System.Collections.Generic.HashSet`1<string>::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldstr      "type"
    IL_000c:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0011:  pop
    IL_0012:  ldloc.0
    IL_0013:  ldstr      "name"
    IL_0018:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_001d:  pop
    IL_001e:  ldloc.0
    IL_001f:  ldstr      "namespace"
    IL_0024:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0029:  pop
    IL_002a:  ldloc.0
    IL_002b:  ldstr      "fields"
    IL_0030:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0035:  pop
    IL_0036:  ldloc.0
    IL_0037:  ldstr      "items"
    IL_003c:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0041:  pop
    IL_0042:  ldloc.0
    IL_0043:  ldstr      "size"
    IL_0048:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_004d:  pop
    IL_004e:  ldloc.0
    IL_004f:  ldstr      "symbols"
    IL_0054:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0059:  pop
    IL_005a:  ldloc.0
    IL_005b:  ldstr      "values"
    IL_0060:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0065:  pop
    IL_0066:  ldloc.0
    IL_0067:  ldstr      "aliases"
    IL_006c:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0071:  pop
    IL_0072:  ldloc.0
    IL_0073:  ldstr      "order"
    IL_0078:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_007d:  pop
    IL_007e:  ldloc.0
    IL_007f:  ldstr      "doc"
    IL_0084:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0089:  pop
    IL_008a:  ldloc.0
    IL_008b:  ldstr      "default"
    IL_0090:  callvirt   instance bool class [System.Core]System.Collections.Generic.HashSet`1<string>::Add(!0)
    IL_0095:  pop
    IL_0096:  ldloc.0
    IL_0097:  stsfld     class [System.Core]System.Collections.Generic.HashSet`1<string> Avro.PropertyMap::ReservedProps
    IL_009c:  ret
  } // end of method PropertyMap::.cctor

} // end of class Avro.PropertyMap

.class private auto ansi sealed Avro.Function`1<T>
       extends [mscorlib]System.MulticastDelegate
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(object 'object',
                               native int 'method') runtime managed
  {
  } // end of method Function`1::.ctor

  .method public hidebysig newslot virtual 
          instance !T  Invoke() runtime managed
  {
  } // end of method Function`1::Invoke

  .method public hidebysig newslot virtual 
          instance class [mscorlib]System.IAsyncResult 
          BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                      object 'object') runtime managed
  {
  } // end of method Function`1::BeginInvoke

  .method public hidebysig newslot virtual 
          instance !T  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
  {
  } // end of method Function`1::EndInvoke

} // end of class Avro.Function`1

.class public auto ansi beforefieldinit Avro.RecordSchema
       extends Avro.NamedSchema
{
  .custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = ( 01 00 04 49 74 65 6D 00 00 )                      // ...Item..
  .class auto ansi nested private beforefieldinit RecordSchemaPair
         extends [mscorlib]System.Object
  {
    .field public initonly class Avro.RecordSchema first
    .field public initonly class Avro.RecordSchema second
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(class Avro.RecordSchema first,
                                 class Avro.RecordSchema second) cil managed
    {
      // Code size       21 (0x15)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ldarg.0
      IL_0007:  ldarg.1
      IL_0008:  stfld      class Avro.RecordSchema Avro.RecordSchema/RecordSchemaPair::first
      IL_000d:  ldarg.0
      IL_000e:  ldarg.2
      IL_000f:  stfld      class Avro.RecordSchema Avro.RecordSchema/RecordSchemaPair::second
      IL_0014:  ret
    } // end of method RecordSchemaPair::.ctor

  } // end of class RecordSchemaPair

  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClass3'
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public class Avro.RecordSchema that
    .field public class Avro.RecordSchema '<>4__this'
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c__DisplayClass3'::.ctor

    .method public hidebysig instance bool 
            '<Equals>b__1'() cil managed
    {
      // Code size       153 (0x99)
      .maxstack  3
      .locals init (int32 V_0)
      IL_0000:  ldarg.0
      IL_0001:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
      IL_0006:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
      IL_000b:  ldarg.0
      IL_000c:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
      IL_0011:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
      IL_0016:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
      IL_001b:  brfalse.s  IL_0097

      IL_001d:  ldarg.0
      IL_001e:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
      IL_0023:  call       instance int32 Avro.RecordSchema::get_Count()
      IL_0028:  ldarg.0
      IL_0029:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
      IL_002e:  callvirt   instance int32 Avro.RecordSchema::get_Count()
      IL_0033:  bne.un.s   IL_0097

      IL_0035:  ldc.i4.0
      IL_0036:  stloc.0
      IL_0037:  br.s       IL_0068

      IL_0039:  ldarg.0
      IL_003a:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
      IL_003f:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
      IL_0044:  ldloc.0
      IL_0045:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::get_Item(int32)
      IL_004a:  ldarg.0
      IL_004b:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
      IL_0050:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
      IL_0055:  ldloc.0
      IL_0056:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::get_Item(int32)
      IL_005b:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
      IL_0060:  brtrue.s   IL_0064

      IL_0062:  ldc.i4.0
      IL_0063:  ret

      IL_0064:  ldloc.0
      IL_0065:  ldc.i4.1
      IL_0066:  add
      IL_0067:  stloc.0
      IL_0068:  ldloc.0
      IL_0069:  ldarg.0
      IL_006a:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
      IL_006f:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
      IL_0074:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::get_Count()
      IL_0079:  blt.s      IL_0039

      IL_007b:  ldarg.0
      IL_007c:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
      IL_0081:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
      IL_0086:  ldarg.0
      IL_0087:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
      IL_008c:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
      IL_0091:  call       bool Avro.Schema::areEqual(object,
                                                      object)
      IL_0096:  ret

      IL_0097:  ldc.i4.0
      IL_0098:  ret
    } // end of method '<>c__DisplayClass3'::'<Equals>b__1'

  } // end of class '<>c__DisplayClass3'

  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClassb'
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public class Avro.RecordSchema that
    .field public class Avro.RecordSchema '<>4__this'
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c__DisplayClassb'::.ctor

    .method public hidebysig instance bool 
            '<CanRead>b__9'() cil managed
    {
      // Code size       239 (0xef)
      .maxstack  2
      .locals init (class Avro.Field V_0,
               class Avro.Field V_1,
               string V_2,
               bool V_3,
               class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_4,
               class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_5)
      IL_0000:  ldarg.0
      IL_0001:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
      IL_0006:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
      IL_000b:  ldarg.0
      IL_000c:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::'<>4__this'
      IL_0011:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
      IL_0016:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
      IL_001b:  brtrue.s   IL_0037

      IL_001d:  ldarg.0
      IL_001e:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::'<>4__this'
      IL_0023:  ldarg.0
      IL_0024:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
      IL_0029:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
      IL_002e:  call       instance bool Avro.NamedSchema::InAliases(class Avro.SchemaName)
      IL_0033:  brtrue.s   IL_0037

      IL_0035:  ldc.i4.0
      IL_0036:  ret

      IL_0037:  ldarg.0
      IL_0038:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::'<>4__this'
      IL_003d:  call       instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
      IL_0042:  stloc.s    V_4
      .try
      {
        IL_0044:  br         IL_00d1

        IL_0049:  ldloc.s    V_4
        IL_004b:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
        IL_0050:  stloc.0
        IL_0051:  ldarg.0
        IL_0052:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
        IL_0057:  ldloc.0
        IL_0058:  ldfld      string Avro.Field::Name
        IL_005d:  callvirt   instance class Avro.Field Avro.RecordSchema::get_Item(string)
        IL_0062:  stloc.1
        IL_0063:  ldloc.1
        IL_0064:  brtrue.s   IL_00ac

        IL_0066:  ldloc.0
        IL_0067:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
        IL_006c:  brfalse.s  IL_00ac

        IL_006e:  ldloc.0
        IL_006f:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
        IL_0074:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
        IL_0079:  stloc.s    V_5
        .try
        {
          IL_007b:  br.s       IL_0095

          IL_007d:  ldloc.s    V_5
          IL_007f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
          IL_0084:  stloc.2
          IL_0085:  ldarg.0
          IL_0086:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
          IL_008b:  ldloc.2
          IL_008c:  callvirt   instance class Avro.Field Avro.RecordSchema::get_Item(string)
          IL_0091:  stloc.1
          IL_0092:  ldloc.1
          IL_0093:  brtrue.s   IL_009e

          IL_0095:  ldloc.s    V_5
          IL_0097:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
          IL_009c:  brtrue.s   IL_007d

          IL_009e:  leave.s    IL_00ac

        }  // end .try
        finally
        {
          IL_00a0:  ldloc.s    V_5
          IL_00a2:  brfalse.s  IL_00ab

          IL_00a4:  ldloc.s    V_5
          IL_00a6:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
          IL_00ab:  endfinally
        }  // end handler
        IL_00ac:  ldloc.1
        IL_00ad:  brtrue.s   IL_00b7

        IL_00af:  ldloc.0
        IL_00b0:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
        IL_00b5:  brtrue.s   IL_00d1

        IL_00b7:  ldloc.1
        IL_00b8:  brfalse.s  IL_00cd

        IL_00ba:  ldloc.0
        IL_00bb:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_00c0:  ldloc.1
        IL_00c1:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_00c6:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
        IL_00cb:  brtrue.s   IL_00d1

        IL_00cd:  ldc.i4.0
        IL_00ce:  stloc.3
        IL_00cf:  leave.s    IL_00ed

        IL_00d1:  ldloc.s    V_4
        IL_00d3:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_00d8:  brtrue     IL_0049

        IL_00dd:  leave.s    IL_00eb

      }  // end .try
      finally
      {
        IL_00df:  ldloc.s    V_4
        IL_00e1:  brfalse.s  IL_00ea

        IL_00e3:  ldloc.s    V_4
        IL_00e5:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_00ea:  endfinally
      }  // end handler
      IL_00eb:  ldc.i4.1
      IL_00ec:  ret

      IL_00ed:  ldloc.3
      IL_00ee:  ret
    } // end of method '<>c__DisplayClassb'::'<CanRead>b__9'

  } // end of class '<>c__DisplayClassb'

  .class auto ansi sealed nested private beforefieldinit '<>c__DisplayClasse`1'<T>
         extends [mscorlib]System.Object
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field public class Avro.RecordSchema '<>4__this'
    .field public class Avro.RecordSchema that
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor() cil managed
    {
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  ret
    } // end of method '<>c__DisplayClasse`1'::.ctor

    .method public hidebysig instance bool 
            '<protect>b__d'(class Avro.RecordSchema/RecordSchemaPair rs) cil managed
    {
      // Code size       31 (0x1f)
      .maxstack  8
      IL_0000:  ldarg.1
      IL_0001:  ldfld      class Avro.RecordSchema Avro.RecordSchema/RecordSchemaPair::first
      IL_0006:  ldarg.0
      IL_0007:  ldfld      class Avro.RecordSchema class Avro.RecordSchema/'<>c__DisplayClasse`1'<!T>::'<>4__this'
      IL_000c:  bne.un.s   IL_001d

      IL_000e:  ldarg.1
      IL_000f:  ldfld      class Avro.RecordSchema Avro.RecordSchema/RecordSchemaPair::second
      IL_0014:  ldarg.0
      IL_0015:  ldfld      class Avro.RecordSchema class Avro.RecordSchema/'<>c__DisplayClasse`1'<!T>::that
      IL_001a:  ceq
      IL_001c:  ret

      IL_001d:  ldc.i4.0
      IL_001e:  ret
    } // end of method '<>c__DisplayClasse`1'::'<protect>b__d'

  } // end of class '<>c__DisplayClasse`1'

  .field private initonly class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> fieldLookup
  .field private initonly class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> fieldAliasLookup
  .field private bool 'request'
  .field private static class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> seen
  .custom instance void [mscorlib]System.ThreadStaticAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> '<Fields>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class Avro.Function`1<bool> 'CS$<>9__CachedAnonymousMethodDelegate2'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class Avro.Function`1<int32> 'CS$<>9__CachedAnonymousMethodDelegate7'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private static class Avro.Function`1<bool> 'CS$<>9__CachedAnonymousMethodDelegatea'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> 
          get_Fields() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::'<Fields>k__BackingField'
    IL_0006:  ret
  } // end of method RecordSchema::get_Fields

  .method private hidebysig specialname instance void 
          set_Fields(class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::'<Fields>k__BackingField'
    IL_0007:  ret
  } // end of method RecordSchema::set_Fields

  .method public hidebysig specialname instance int32 
          get_Count() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::get_Count()
    IL_000b:  ret
  } // end of method RecordSchema::get_Count

  .method assembly hidebysig static class Avro.RecordSchema 
          NewInstance(valuetype Avro.Schema/Type 'type',
                      class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jtok,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       331 (0x14b)
    .maxstack  9
    .locals init (bool V_0,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_1,
             class Avro.SchemaName V_2,
             class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> V_3,
             class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> V_4,
             class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field> V_5,
             class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field> V_6,
             class Avro.RecordSchema V_7,
             int32 V_8,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject V_9,
             string V_10,
             class Avro.Field V_11,
             string V_12,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_13,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_14)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  ldarg.1
    IL_0003:  ldstr      "fields"
    IL_0008:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_000d:  stloc.1
    IL_000e:  ldloc.1
    IL_000f:  brtrue.s   IL_0022

    IL_0011:  ldarg.1
    IL_0012:  ldstr      "request"
    IL_0017:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_001c:  stloc.1
    IL_001d:  ldloc.1
    IL_001e:  brfalse.s  IL_0022

    IL_0020:  ldc.i4.1
    IL_0021:  stloc.0
    IL_0022:  ldloc.1
    IL_0023:  brtrue.s   IL_0030

    IL_0025:  ldstr      "'fields' cannot be null for record"
    IL_002a:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_002f:  throw

    IL_0030:  ldloc.1
    IL_0031:  callvirt   instance valuetype [Newtonsoft.Json]Newtonsoft.Json.Linq.JTokenType [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Type()
    IL_0036:  ldc.i4.2
    IL_0037:  beq.s      IL_0044

    IL_0039:  ldstr      "'fields' not an array for record"
    IL_003e:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0043:  throw

    IL_0044:  ldarg.1
    IL_0045:  ldarg.s    encspace
    IL_0047:  call       class Avro.SchemaName Avro.NamedSchema::GetName(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                         string)
    IL_004c:  stloc.2
    IL_004d:  ldarg.1
    IL_004e:  ldloc.2
    IL_004f:  callvirt   instance string Avro.SchemaName::get_Space()
    IL_0054:  ldloc.2
    IL_0055:  callvirt   instance string Avro.SchemaName::get_EncSpace()
    IL_005a:  call       class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> Avro.NamedSchema::GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                                                                                string,
                                                                                                                                string)
    IL_005f:  stloc.3
    IL_0060:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::.ctor()
    IL_0065:  stloc.s    V_4
    IL_0067:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>::.ctor()
    IL_006c:  stloc.s    V_5
    IL_006e:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>::.ctor()
    IL_0073:  stloc.s    V_6
    IL_0075:  ldarg.0
    IL_0076:  ldloc.2
    IL_0077:  ldloc.3
    IL_0078:  ldarg.2
    IL_0079:  ldloc.s    V_4
    IL_007b:  ldloc.0
    IL_007c:  ldloc.s    V_5
    IL_007e:  ldloc.s    V_6
    IL_0080:  ldarg.3
    IL_0081:  newobj     instance void Avro.RecordSchema::.ctor(valuetype Avro.Schema/Type,
                                                                class Avro.SchemaName,
                                                                class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                                class Avro.PropertyMap,
                                                                class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>,
                                                                bool,
                                                                class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>,
                                                                class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>,
                                                                class Avro.SchemaNames)
    IL_0086:  stloc.s    V_7
    IL_0088:  ldc.i4.0
    IL_0089:  stloc.s    V_8
    IL_008b:  ldloc.1
    IL_008c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0091:  stloc.s    V_13
    .try
    {
      IL_0093:  br         IL_012e

      IL_0098:  ldloc.s    V_13
      IL_009a:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_009f:  castclass  [Newtonsoft.Json]Newtonsoft.Json.Linq.JObject
      IL_00a4:  stloc.s    V_9
      IL_00a6:  ldloc.s    V_9
      IL_00a8:  ldstr      "name"
      IL_00ad:  call       string Avro.JsonHelper::GetRequiredString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                     string)
      IL_00b2:  stloc.s    V_10
      IL_00b4:  ldloc.s    V_9
      IL_00b6:  ldloc.s    V_8
      IL_00b8:  dup
      IL_00b9:  ldc.i4.1
      IL_00ba:  add
      IL_00bb:  stloc.s    V_8
      IL_00bd:  ldarg.3
      IL_00be:  ldloc.2
      IL_00bf:  callvirt   instance string Avro.SchemaName::get_Namespace()
      IL_00c4:  call       class Avro.Field Avro.RecordSchema::createField(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                           int32,
                                                                           class Avro.SchemaNames,
                                                                           string)
      IL_00c9:  stloc.s    V_11
      IL_00cb:  ldloc.s    V_4
      IL_00cd:  ldloc.s    V_11
      IL_00cf:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::Add(!0)
      IL_00d4:  ldloc.s    V_5
      IL_00d6:  ldloc.s    V_10
      IL_00d8:  ldloc.s    V_11
      IL_00da:  call       void Avro.RecordSchema::addToFieldMap(class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>,
                                                                 string,
                                                                 class Avro.Field)
      IL_00df:  ldloc.s    V_6
      IL_00e1:  ldloc.s    V_10
      IL_00e3:  ldloc.s    V_11
      IL_00e5:  call       void Avro.RecordSchema::addToFieldMap(class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>,
                                                                 string,
                                                                 class Avro.Field)
      IL_00ea:  ldloc.s    V_11
      IL_00ec:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
      IL_00f1:  brfalse.s  IL_012e

      IL_00f3:  ldloc.s    V_11
      IL_00f5:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::aliases
      IL_00fa:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
      IL_00ff:  stloc.s    V_14
      .try
      {
        IL_0101:  br.s       IL_0117

        IL_0103:  ldloc.s    V_14
        IL_0105:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
        IL_010a:  stloc.s    V_12
        IL_010c:  ldloc.s    V_6
        IL_010e:  ldloc.s    V_12
        IL_0110:  ldloc.s    V_11
        IL_0112:  call       void Avro.RecordSchema::addToFieldMap(class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>,
                                                                   string,
                                                                   class Avro.Field)
        IL_0117:  ldloc.s    V_14
        IL_0119:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
        IL_011e:  brtrue.s   IL_0103

        IL_0120:  leave.s    IL_012e

      }  // end .try
      finally
      {
        IL_0122:  ldloc.s    V_14
        IL_0124:  brfalse.s  IL_012d

        IL_0126:  ldloc.s    V_14
        IL_0128:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
        IL_012d:  endfinally
      }  // end handler
      IL_012e:  ldloc.s    V_13
      IL_0130:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0135:  brtrue     IL_0098

      IL_013a:  leave.s    IL_0148

    }  // end .try
    finally
    {
      IL_013c:  ldloc.s    V_13
      IL_013e:  brfalse.s  IL_0147

      IL_0140:  ldloc.s    V_13
      IL_0142:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0147:  endfinally
    }  // end handler
    IL_0148:  ldloc.s    V_7
    IL_014a:  ret
  } // end of method RecordSchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(valuetype Avro.Schema/Type 'type',
                               class Avro.SchemaName name,
                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName> aliases,
                               class Avro.PropertyMap props,
                               class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> fields,
                               bool 'request',
                               class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> fieldMap,
                               class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> fieldAliasMap,
                               class Avro.SchemaNames names) cil managed
  {
    // Code size       69 (0x45)
    .maxstack  6
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  ldarg.s    props
    IL_0006:  ldarg.s    names
    IL_0008:  call       instance void Avro.NamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                               class Avro.SchemaName,
                                                               class [mscorlib]System.Collections.Generic.IList`1<class Avro.SchemaName>,
                                                               class Avro.PropertyMap,
                                                               class Avro.SchemaNames)
    IL_000d:  ldarg.s    'request'
    IL_000f:  brtrue.s   IL_0024

    IL_0011:  ldarg.2
    IL_0012:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_0017:  brtrue.s   IL_0024

    IL_0019:  ldstr      "name cannot be null for record schema."
    IL_001e:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_0023:  throw

    IL_0024:  ldarg.0
    IL_0025:  ldarg.s    fields
    IL_0027:  call       instance void Avro.RecordSchema::set_Fields(class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>)
    IL_002c:  ldarg.0
    IL_002d:  ldarg.s    'request'
    IL_002f:  stfld      bool Avro.RecordSchema::'request'
    IL_0034:  ldarg.0
    IL_0035:  ldarg.s    fieldMap
    IL_0037:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldLookup
    IL_003c:  ldarg.0
    IL_003d:  ldarg.s    fieldAliasMap
    IL_003f:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldAliasLookup
    IL_0044:  ret
  } // end of method RecordSchema::.ctor

  .method private hidebysig static class Avro.Field 
          createField(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken jfield,
                      int32 pos,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       155 (0x9b)
    .maxstack  8
    .locals init (string V_0,
             string V_1,
             string V_2,
             valuetype Avro.Field/SortOrder V_3,
             class [mscorlib]System.Collections.Generic.IList`1<string> V_4,
             class Avro.PropertyMap V_5,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_6,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_7,
             class Avro.Schema V_8)
    IL_0000:  ldarg.0
    IL_0001:  ldstr      "name"
    IL_0006:  call       string Avro.JsonHelper::GetRequiredString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  ldstr      "doc"
    IL_0012:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0017:  stloc.1
    IL_0018:  ldarg.0
    IL_0019:  ldstr      "order"
    IL_001e:  call       string Avro.JsonHelper::GetOptionalString(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                   string)
    IL_0023:  stloc.2
    IL_0024:  ldc.i4.2
    IL_0025:  stloc.3
    IL_0026:  ldloc.2
    IL_0027:  brfalse.s  IL_003f

    IL_0029:  ldtoken    Avro.Field/SortOrder
    IL_002e:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0033:  ldloc.2
    IL_0034:  call       object [mscorlib]System.Enum::Parse(class [mscorlib]System.Type,
                                                             string)
    IL_0039:  unbox.any  Avro.Field/SortOrder
    IL_003e:  stloc.3
    IL_003f:  ldarg.0
    IL_0040:  call       class [mscorlib]System.Collections.Generic.IList`1<string> Avro.Field::GetAliases(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_0045:  stloc.s    V_4
    IL_0047:  ldarg.0
    IL_0048:  call       class Avro.PropertyMap Avro.Schema::GetProperties(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
    IL_004d:  stloc.s    V_5
    IL_004f:  ldarg.0
    IL_0050:  ldstr      "default"
    IL_0055:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_005a:  stloc.s    V_6
    IL_005c:  ldarg.0
    IL_005d:  ldstr      "type"
    IL_0062:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken::get_Item(object)
    IL_0067:  stloc.s    V_7
    IL_0069:  ldloc.s    V_7
    IL_006b:  brtrue.s   IL_007e

    IL_006d:  ldstr      "'type' was not found for field: "
    IL_0072:  ldloc.0
    IL_0073:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0078:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_007d:  throw

    IL_007e:  ldloc.s    V_7
    IL_0080:  ldarg.2
    IL_0081:  ldarg.3
    IL_0082:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                  class Avro.SchemaNames,
                                                                  string)
    IL_0087:  stloc.s    V_8
    IL_0089:  ldloc.s    V_8
    IL_008b:  ldloc.0
    IL_008c:  ldloc.s    V_4
    IL_008e:  ldarg.1
    IL_008f:  ldloc.1
    IL_0090:  ldloc.s    V_6
    IL_0092:  ldloc.3
    IL_0093:  ldloc.s    V_5
    IL_0095:  newobj     instance void Avro.Field::.ctor(class Avro.Schema,
                                                         string,
                                                         class [mscorlib]System.Collections.Generic.IList`1<string>,
                                                         int32,
                                                         string,
                                                         class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                         valuetype Avro.Field/SortOrder,
                                                         class Avro.PropertyMap)
    IL_009a:  ret
  } // end of method RecordSchema::createField

  .method private hidebysig static void  addToFieldMap(class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field> map,
                                                       string name,
                                                       class Avro.Field 'field') cil managed
  {
    // Code size       40 (0x28)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  callvirt   instance bool class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>::ContainsKey(!0)
    IL_0007:  brfalse.s  IL_001f

    IL_0009:  ldstr      "field or alias "
    IL_000e:  ldarg.1
    IL_000f:  ldstr      " is a duplicate name"
    IL_0014:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0019:  newobj     instance void Avro.SchemaParseException::.ctor(string)
    IL_001e:  throw

    IL_001f:  ldarg.0
    IL_0020:  ldarg.1
    IL_0021:  ldarg.2
    IL_0022:  callvirt   instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class Avro.Field>::Add(!0,
                                                                                                                             !1)
    IL_0027:  ret
  } // end of method RecordSchema::addToFieldMap

  .method public hidebysig specialname instance class Avro.Field 
          get_Item(string name) cil managed
  {
    // Code size       39 (0x27)
    .maxstack  3
    .locals init (class Avro.Field V_0)
    IL_0000:  ldarg.1
    IL_0001:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0006:  brfalse.s  IL_0013

    IL_0008:  ldstr      "name"
    IL_000d:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ldarg.0
    IL_0014:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldLookup
    IL_0019:  ldarg.1
    IL_001a:  ldloca.s   V_0
    IL_001c:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>::TryGetValue(!0,
                                                                                                                                      !1&)
    IL_0021:  brtrue.s   IL_0025

    IL_0023:  ldnull
    IL_0024:  ret

    IL_0025:  ldloc.0
    IL_0026:  ret
  } // end of method RecordSchema::get_Item

  .method public hidebysig instance bool 
          Contains(string fieldName) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldLookup
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>::ContainsKey(!0)
    IL_000c:  ret
  } // end of method RecordSchema::Contains

  .method public hidebysig instance bool 
          TryGetField(string fieldName,
                      [out] class Avro.Field& 'field') cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldLookup
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>::TryGetValue(!0,
                                                                                                                                      !1&)
    IL_000d:  ret
  } // end of method RecordSchema::TryGetField

  .method public hidebysig instance bool 
          TryGetFieldAlias(string fieldName,
                           [out] class Avro.Field& 'field') cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field> Avro.RecordSchema::fieldAliasLookup
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,class Avro.Field>::TryGetValue(!0,
                                                                                                                                      !1&)
    IL_000d:  ret
  } // end of method RecordSchema::TryGetFieldAlias

  .method public hidebysig instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> 
          GetEnumerator() cil managed
  {
    // Code size       17 (0x11)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0006:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::GetEnumerator()
    IL_000b:  box        valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>
    IL_0010:  ret
  } // end of method RecordSchema::GetEnumerator

  .method famorassem hidebysig virtual instance void 
          WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                          class Avro.SchemaNames names,
                          string encspace) cil managed
  {
    // Code size       126 (0x7e)
    .maxstack  4
    .locals init (class Avro.Field V_0,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  ldarg.3
    IL_0004:  call       instance void Avro.NamedSchema::WriteJsonFields(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                         class Avro.SchemaNames,
                                                                         string)
    IL_0009:  ldarg.0
    IL_000a:  ldfld      bool Avro.RecordSchema::'request'
    IL_000f:  brfalse.s  IL_001e

    IL_0011:  ldarg.1
    IL_0012:  ldstr      "request"
    IL_0017:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_001c:  br.s       IL_0029

    IL_001e:  ldarg.1
    IL_001f:  ldstr      "fields"
    IL_0024:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WritePropertyName(string)
    IL_0029:  ldarg.1
    IL_002a:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_002f:  ldarg.0
    IL_0030:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0035:  brfalse.s  IL_0077

    IL_0037:  ldarg.0
    IL_0038:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_003d:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::get_Count()
    IL_0042:  ldc.i4.0
    IL_0043:  ble.s      IL_0077

    IL_0045:  ldarg.0
    IL_0046:  call       instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_004b:  stloc.1
    .try
    {
      IL_004c:  br.s       IL_0063

      IL_004e:  ldloc.1
      IL_004f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_0054:  stloc.0
      IL_0055:  ldloc.0
      IL_0056:  ldarg.1
      IL_0057:  ldarg.2
      IL_0058:  ldarg.0
      IL_0059:  call       instance string Avro.NamedSchema::get_Namespace()
      IL_005e:  callvirt   instance void Avro.Field::writeJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                               class Avro.SchemaNames,
                                                               string)
      IL_0063:  ldloc.1
      IL_0064:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0069:  brtrue.s   IL_004e

      IL_006b:  leave.s    IL_0077

    }  // end .try
    finally
    {
      IL_006d:  ldloc.1
      IL_006e:  brfalse.s  IL_0076

      IL_0070:  ldloc.1
      IL_0071:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0076:  endfinally
    }  // end handler
    IL_0077:  ldarg.1
    IL_0078:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_007d:  ret
  } // end of method RecordSchema::WriteJsonFields

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       98 (0x62)
    .maxstack  4
    .locals init (class Avro.RecordSchema/'<>c__DisplayClass3' V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0060

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.RecordSchema
    IL_000f:  brfalse.s  IL_0060

    IL_0011:  newobj     instance void Avro.RecordSchema/'<>c__DisplayClass3'::.ctor()
    IL_0016:  stloc.0
    IL_0017:  ldloc.0
    IL_0018:  ldarg.0
    IL_0019:  stfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::'<>4__this'
    IL_001e:  ldloc.0
    IL_001f:  ldarg.1
    IL_0020:  isinst     Avro.RecordSchema
    IL_0025:  stfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
    IL_002a:  ldarg.0
    IL_002b:  ldsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate2'
    IL_0030:  brtrue.s   IL_0043

    IL_0032:  ldnull
    IL_0033:  ldftn      bool Avro.RecordSchema::'<Equals>b__0'()
    IL_0039:  newobj     instance void class Avro.Function`1<bool>::.ctor(object,
                                                                          native int)
    IL_003e:  stsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate2'
    IL_0043:  ldsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate2'
    IL_0048:  ldloc.0
    IL_0049:  ldftn      instance bool Avro.RecordSchema/'<>c__DisplayClass3'::'<Equals>b__1'()
    IL_004f:  newobj     instance void class Avro.Function`1<bool>::.ctor(object,
                                                                          native int)
    IL_0054:  ldloc.0
    IL_0055:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClass3'::that
    IL_005a:  call       instance !!0 Avro.RecordSchema::protect<bool>(class Avro.Function`1<!!0>,
                                                                       class Avro.Function`1<!!0>,
                                                                       class Avro.RecordSchema)
    IL_005f:  ret

    IL_0060:  ldc.i4.0
    IL_0061:  ret
  } // end of method RecordSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       49 (0x31)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldsfld     class Avro.Function`1<int32> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate7'
    IL_0006:  brtrue.s   IL_0019

    IL_0008:  ldnull
    IL_0009:  ldftn      int32 Avro.RecordSchema::'<GetHashCode>b__5'()
    IL_000f:  newobj     instance void class Avro.Function`1<int32>::.ctor(object,
                                                                           native int)
    IL_0014:  stsfld     class Avro.Function`1<int32> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate7'
    IL_0019:  ldsfld     class Avro.Function`1<int32> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegate7'
    IL_001e:  ldarg.0
    IL_001f:  ldftn      instance int32 Avro.RecordSchema::'<GetHashCode>b__6'()
    IL_0025:  newobj     instance void class Avro.Function`1<int32>::.ctor(object,
                                                                           native int)
    IL_002a:  ldarg.0
    IL_002b:  call       instance !!0 Avro.RecordSchema::protect<int32>(class Avro.Function`1<!!0>,
                                                                        class Avro.Function`1<!!0>,
                                                                        class Avro.RecordSchema)
    IL_0030:  ret
  } // end of method RecordSchema::GetHashCode

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       90 (0x5a)
    .maxstack  4
    .locals init (class Avro.RecordSchema/'<>c__DisplayClassb' V_0,
             bool V_1)
    IL_0000:  newobj     instance void Avro.RecordSchema/'<>c__DisplayClassb'::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldarg.0
    IL_0008:  stfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::'<>4__this'
    IL_000d:  ldarg.1
    IL_000e:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0013:  ldc.i4.8
    IL_0014:  beq.s      IL_0018

    IL_0016:  ldc.i4.0
    IL_0017:  ret

    IL_0018:  ldloc.0
    IL_0019:  ldarg.1
    IL_001a:  isinst     Avro.RecordSchema
    IL_001f:  stfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
    IL_0024:  ldarg.0
    IL_0025:  ldsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegatea'
    IL_002a:  brtrue.s   IL_003d

    IL_002c:  ldnull
    IL_002d:  ldftn      bool Avro.RecordSchema::'<CanRead>b__8'()
    IL_0033:  newobj     instance void class Avro.Function`1<bool>::.ctor(object,
                                                                          native int)
    IL_0038:  stsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegatea'
    IL_003d:  ldsfld     class Avro.Function`1<bool> Avro.RecordSchema::'CS$<>9__CachedAnonymousMethodDelegatea'
    IL_0042:  ldloc.0
    IL_0043:  ldftn      instance bool Avro.RecordSchema/'<>c__DisplayClassb'::'<CanRead>b__9'()
    IL_0049:  newobj     instance void class Avro.Function`1<bool>::.ctor(object,
                                                                          native int)
    IL_004e:  ldloc.0
    IL_004f:  ldfld      class Avro.RecordSchema Avro.RecordSchema/'<>c__DisplayClassb'::that
    IL_0054:  call       instance !!0 Avro.RecordSchema::protect<bool>(class Avro.Function`1<!!0>,
                                                                       class Avro.Function`1<!!0>,
                                                                       class Avro.RecordSchema)
    IL_0059:  ret
  } // end of method RecordSchema::CanRead

  .method private hidebysig instance !!T 
          protect<T>(class Avro.Function`1<!!T> bypass,
                     class Avro.Function`1<!!T> main,
                     class Avro.RecordSchema that) cil managed
  {
    // Code size       118 (0x76)
    .maxstack  3
    .locals init (class Avro.RecordSchema/RecordSchemaPair V_0,
             class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T> V_1,
             !!T V_2)
    IL_0000:  newobj     instance void class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T>::.ctor()
    IL_0005:  stloc.1
    IL_0006:  ldloc.1
    IL_0007:  ldarg.3
    IL_0008:  stfld      class Avro.RecordSchema class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T>::that
    IL_000d:  ldloc.1
    IL_000e:  ldarg.0
    IL_000f:  stfld      class Avro.RecordSchema class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T>::'<>4__this'
    IL_0014:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> Avro.RecordSchema::seen
    IL_0019:  brtrue.s   IL_0027

    IL_001b:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair>::.ctor()
    IL_0020:  stsfld     class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> Avro.RecordSchema::seen
    IL_0025:  br.s       IL_0046

    IL_0027:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> Avro.RecordSchema::seen
    IL_002c:  ldloc.1
    IL_002d:  ldftn      instance bool class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T>::'<protect>b__d'(class Avro.RecordSchema/RecordSchemaPair)
    IL_0033:  newobj     instance void class [mscorlib]System.Predicate`1<class Avro.RecordSchema/RecordSchemaPair>::.ctor(object,
                                                                                                                           native int)
    IL_0038:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair>::Find(class [mscorlib]System.Predicate`1<!0>)
    IL_003d:  brfalse.s  IL_0046

    IL_003f:  ldarg.1
    IL_0040:  callvirt   instance !0 class Avro.Function`1<!!T>::Invoke()
    IL_0045:  ret

    IL_0046:  ldarg.0
    IL_0047:  ldloc.1
    IL_0048:  ldfld      class Avro.RecordSchema class Avro.RecordSchema/'<>c__DisplayClasse`1'<!!T>::that
    IL_004d:  newobj     instance void Avro.RecordSchema/RecordSchemaPair::.ctor(class Avro.RecordSchema,
                                                                                 class Avro.RecordSchema)
    IL_0052:  stloc.0
    IL_0053:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> Avro.RecordSchema::seen
    IL_0058:  ldloc.0
    IL_0059:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair>::Add(!0)
    .try
    {
      IL_005e:  ldarg.2
      IL_005f:  callvirt   instance !0 class Avro.Function`1<!!T>::Invoke()
      IL_0064:  stloc.2
      IL_0065:  leave.s    IL_0074

    }  // end .try
    finally
    {
      IL_0067:  ldsfld     class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair> Avro.RecordSchema::seen
      IL_006c:  ldloc.0
      IL_006d:  callvirt   instance bool class [mscorlib]System.Collections.Generic.List`1<class Avro.RecordSchema/RecordSchemaPair>::Remove(!0)
      IL_0072:  pop
      IL_0073:  endfinally
    }  // end handler
    IL_0074:  ldloc.2
    IL_0075:  ret
  } // end of method RecordSchema::protect

  .method private hidebysig static bool  '<Equals>b__0'() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.1
    IL_0001:  ret
  } // end of method RecordSchema::'<Equals>b__0'

  .method private hidebysig static int32 
          '<GetHashCode>b__5'() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.0
    IL_0001:  ret
  } // end of method RecordSchema::'<GetHashCode>b__5'

  .method private hidebysig instance int32 
          '<GetHashCode>b__6'() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       87 (0x57)
    .maxstack  3
    .locals init (int32 V_0,
             class Avro.Field V_1,
             valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field> V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_000b:  stloc.0
    IL_000c:  ldarg.0
    IL_000d:  call       instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_0012:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::GetEnumerator()
    IL_0017:  stloc.2
    .try
    {
      IL_0018:  br.s       IL_002e

      IL_001a:  ldloca.s   V_2
      IL_001c:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::get_Current()
      IL_0021:  stloc.1
      IL_0022:  ldloc.0
      IL_0023:  ldc.i4.s   29
      IL_0025:  ldloc.1
      IL_0026:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_002b:  mul
      IL_002c:  add
      IL_002d:  stloc.0
      IL_002e:  ldloca.s   V_2
      IL_0030:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::MoveNext()
      IL_0035:  brtrue.s   IL_001a

      IL_0037:  leave.s    IL_0047

    }  // end .try
    finally
    {
      IL_0039:  ldloca.s   V_2
      IL_003b:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>
      IL_0041:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0046:  endfinally
    }  // end handler
    IL_0047:  ldloc.0
    IL_0048:  ldarg.0
    IL_0049:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_004e:  call       int32 Avro.Schema::getHashCode(object)
    IL_0053:  add
    IL_0054:  stloc.0
    IL_0055:  ldloc.0
    IL_0056:  ret
  } // end of method RecordSchema::'<GetHashCode>b__6'

  .method private hidebysig static bool  '<CanRead>b__8'() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       2 (0x2)
    .maxstack  8
    IL_0000:  ldc.i4.1
    IL_0001:  ret
  } // end of method RecordSchema::'<CanRead>b__8'

  .property instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>
          Fields()
  {
    .get instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    .set instance void Avro.RecordSchema::set_Fields(class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>)
  } // end of property RecordSchema::Fields
  .property instance int32 Count()
  {
    .get instance int32 Avro.RecordSchema::get_Count()
  } // end of property RecordSchema::Count
  .property instance class Avro.Field Item(string)
  {
    .get instance class Avro.Field Avro.RecordSchema::get_Item(string)
  } // end of property RecordSchema::Item
} // end of class Avro.RecordSchema

.class public auto ansi beforefieldinit Avro.SchemaName
       extends [mscorlib]System.Object
{
  .field private string '<Name>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<Space>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field private string '<EncSpace>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance string 
          get_Name() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.SchemaName::'<Name>k__BackingField'
    IL_0006:  ret
  } // end of method SchemaName::get_Name

  .method private hidebysig specialname instance void 
          set_Name(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.SchemaName::'<Name>k__BackingField'
    IL_0007:  ret
  } // end of method SchemaName::set_Name

  .method public hidebysig specialname instance string 
          get_Space() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.SchemaName::'<Space>k__BackingField'
    IL_0006:  ret
  } // end of method SchemaName::get_Space

  .method private hidebysig specialname instance void 
          set_Space(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.SchemaName::'<Space>k__BackingField'
    IL_0007:  ret
  } // end of method SchemaName::set_Space

  .method public hidebysig specialname instance string 
          get_EncSpace() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      string Avro.SchemaName::'<EncSpace>k__BackingField'
    IL_0006:  ret
  } // end of method SchemaName::get_EncSpace

  .method private hidebysig specialname instance void 
          set_EncSpace(string 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      string Avro.SchemaName::'<EncSpace>k__BackingField'
    IL_0007:  ret
  } // end of method SchemaName::set_EncSpace

  .method public hidebysig specialname instance string 
          get_Fullname() cil managed
  {
    // Code size       43 (0x2b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.SchemaName::get_Namespace()
    IL_0006:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000b:  brtrue.s   IL_0024

    IL_000d:  ldarg.0
    IL_000e:  call       instance string Avro.SchemaName::get_Namespace()
    IL_0013:  ldstr      "."
    IL_0018:  ldarg.0
    IL_0019:  call       instance string Avro.SchemaName::get_Name()
    IL_001e:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0023:  ret

    IL_0024:  ldarg.0
    IL_0025:  call       instance string Avro.SchemaName::get_Name()
    IL_002a:  ret
  } // end of method SchemaName::get_Fullname

  .method public hidebysig specialname instance string 
          get_Namespace() cil managed
  {
    // Code size       27 (0x1b)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.SchemaName::get_Space()
    IL_0006:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000b:  brtrue.s   IL_0014

    IL_000d:  ldarg.0
    IL_000e:  call       instance string Avro.SchemaName::get_Space()
    IL_0013:  ret

    IL_0014:  ldarg.0
    IL_0015:  call       instance string Avro.SchemaName::get_EncSpace()
    IL_001a:  ret
  } // end of method SchemaName::get_Namespace

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string name,
                               string space,
                               string encspace) cil managed
  {
    // Code size       132 (0x84)
    .maxstack  6
    .locals init (string[] V_0,
             string V_1,
             char[] V_2)
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.1
    IL_0007:  brtrue.s   IL_0021

    IL_0009:  ldarg.0
    IL_000a:  ldarg.0
    IL_000b:  ldnull
    IL_000c:  dup
    IL_000d:  stloc.1
    IL_000e:  call       instance void Avro.SchemaName::set_Space(string)
    IL_0013:  ldloc.1
    IL_0014:  call       instance void Avro.SchemaName::set_Name(string)
    IL_0019:  ldarg.0
    IL_001a:  ldarg.3
    IL_001b:  call       instance void Avro.SchemaName::set_EncSpace(string)
    IL_0020:  ret

    IL_0021:  ldarg.1
    IL_0022:  ldstr      "."
    IL_0027:  callvirt   instance bool [mscorlib]System.String::Contains(string)
    IL_002c:  brtrue.s   IL_0044

    IL_002e:  ldarg.0
    IL_002f:  ldarg.2
    IL_0030:  call       instance void Avro.SchemaName::set_Space(string)
    IL_0035:  ldarg.0
    IL_0036:  ldarg.1
    IL_0037:  call       instance void Avro.SchemaName::set_Name(string)
    IL_003c:  ldarg.0
    IL_003d:  ldarg.3
    IL_003e:  call       instance void Avro.SchemaName::set_EncSpace(string)
    IL_0043:  ret

    IL_0044:  ldarg.1
    IL_0045:  ldc.i4.1
    IL_0046:  newarr     [mscorlib]System.Char
    IL_004b:  stloc.2
    IL_004c:  ldloc.2
    IL_004d:  ldc.i4.0
    IL_004e:  ldc.i4.s   46
    IL_0050:  stelem.i2
    IL_0051:  ldloc.2
    IL_0052:  callvirt   instance string[] [mscorlib]System.String::Split(char[])
    IL_0057:  stloc.0
    IL_0058:  ldarg.0
    IL_0059:  ldstr      "."
    IL_005e:  ldloc.0
    IL_005f:  ldc.i4.0
    IL_0060:  ldloc.0
    IL_0061:  ldlen
    IL_0062:  conv.i4
    IL_0063:  ldc.i4.1
    IL_0064:  sub
    IL_0065:  call       string [mscorlib]System.String::Join(string,
                                                              string[],
                                                              int32,
                                                              int32)
    IL_006a:  call       instance void Avro.SchemaName::set_Space(string)
    IL_006f:  ldarg.0
    IL_0070:  ldloc.0
    IL_0071:  ldloc.0
    IL_0072:  ldlen
    IL_0073:  conv.i4
    IL_0074:  ldc.i4.1
    IL_0075:  sub
    IL_0076:  ldelem.ref
    IL_0077:  call       instance void Avro.SchemaName::set_Name(string)
    IL_007c:  ldarg.0
    IL_007d:  ldarg.3
    IL_007e:  call       instance void Avro.SchemaName::set_EncSpace(string)
    IL_0083:  ret
  } // end of method SchemaName::.ctor

  .method public hidebysig virtual instance string 
          ToString() cil managed
  {
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.SchemaName::get_Fullname()
    IL_0006:  ret
  } // end of method SchemaName::ToString

  .method assembly hidebysig instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       87 (0x57)
    .maxstack  3
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.SchemaName::get_Name()
    IL_0006:  brfalse.s  IL_0056

    IL_0008:  ldarg.1
    IL_0009:  ldstr      "name"
    IL_000e:  ldarg.0
    IL_000f:  call       instance string Avro.SchemaName::get_Name()
    IL_0014:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0019:  ldarg.0
    IL_001a:  call       instance string Avro.SchemaName::get_Space()
    IL_001f:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0024:  brtrue.s   IL_0038

    IL_0026:  ldarg.1
    IL_0027:  ldstr      "namespace"
    IL_002c:  ldarg.0
    IL_002d:  call       instance string Avro.SchemaName::get_Space()
    IL_0032:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0037:  ret

    IL_0038:  ldarg.0
    IL_0039:  call       instance string Avro.SchemaName::get_EncSpace()
    IL_003e:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_0043:  brtrue.s   IL_0056

    IL_0045:  ldarg.1
    IL_0046:  ldstr      "namespace"
    IL_004b:  ldarg.0
    IL_004c:  call       instance string Avro.SchemaName::get_EncSpace()
    IL_0051:  call       void Avro.JsonHelper::writeIfNotNullOrEmpty(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                     string,
                                                                     string)
    IL_0056:  ret
  } // end of method SchemaName::WriteJson

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       65 (0x41)
    .maxstack  2
    .locals init (class Avro.SchemaName V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_003f

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.SchemaName
    IL_000f:  brfalse.s  IL_003f

    IL_0011:  ldarg.1
    IL_0012:  castclass  Avro.SchemaName
    IL_0017:  stloc.0
    IL_0018:  ldloc.0
    IL_0019:  callvirt   instance string Avro.SchemaName::get_Name()
    IL_001e:  ldarg.0
    IL_001f:  call       instance string Avro.SchemaName::get_Name()
    IL_0024:  call       bool Avro.SchemaName::areEqual(object,
                                                        object)
    IL_0029:  brfalse.s  IL_003d

    IL_002b:  ldloc.0
    IL_002c:  callvirt   instance string Avro.SchemaName::get_Namespace()
    IL_0031:  ldarg.0
    IL_0032:  call       instance string Avro.SchemaName::get_Namespace()
    IL_0037:  call       bool Avro.SchemaName::areEqual(object,
                                                        object)
    IL_003c:  ret

    IL_003d:  ldc.i4.0
    IL_003e:  ret

    IL_003f:  ldc.i4.0
    IL_0040:  ret
  } // end of method SchemaName::Equals

  .method private hidebysig static bool  areEqual(object obj1,
                                                  object obj2) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  brfalse.s  IL_000b

    IL_0003:  ldarg.0
    IL_0004:  ldarg.1
    IL_0005:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_000a:  ret

    IL_000b:  ldarg.1
    IL_000c:  ldnull
    IL_000d:  ceq
    IL_000f:  ret
  } // end of method SchemaName::areEqual

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       30 (0x1e)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance string Avro.SchemaName::get_Fullname()
    IL_0006:  call       bool [mscorlib]System.String::IsNullOrEmpty(string)
    IL_000b:  brtrue.s   IL_001c

    IL_000d:  ldc.i4.s   29
    IL_000f:  ldarg.0
    IL_0010:  call       instance string Avro.SchemaName::get_Fullname()
    IL_0015:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
    IL_001a:  mul
    IL_001b:  ret

    IL_001c:  ldc.i4.0
    IL_001d:  ret
  } // end of method SchemaName::GetHashCode

  .property instance string Name()
  {
    .get instance string Avro.SchemaName::get_Name()
    .set instance void Avro.SchemaName::set_Name(string)
  } // end of property SchemaName::Name
  .property instance string Space()
  {
    .get instance string Avro.SchemaName::get_Space()
    .set instance void Avro.SchemaName::set_Space(string)
  } // end of property SchemaName::Space
  .property instance string EncSpace()
  {
    .get instance string Avro.SchemaName::get_EncSpace()
    .set instance void Avro.SchemaName::set_EncSpace(string)
  } // end of property SchemaName::EncSpace
  .property instance string Fullname()
  {
    .get instance string Avro.SchemaName::get_Fullname()
  } // end of property SchemaName::Fullname
  .property instance string Namespace()
  {
    .get instance string Avro.SchemaName::get_Namespace()
  } // end of property SchemaName::Namespace
} // end of class Avro.SchemaName

.class public auto ansi beforefieldinit Avro.SchemaNames
       extends [mscorlib]System.Object
{
  .field private class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> '<Names>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> 
          get_Names() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::'<Names>k__BackingField'
    IL_0006:  ret
  } // end of method SchemaNames::get_Names

  .method private hidebysig specialname instance void 
          set_Names(class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::'<Names>k__BackingField'
    IL_0007:  ret
  } // end of method SchemaNames::set_Names

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<class Avro.SchemaName,class Avro.NamedSchema>::.ctor()
    IL_000c:  call       instance void Avro.SchemaNames::set_Names(class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>)
    IL_0011:  ret
  } // end of method SchemaNames::.ctor

  .method public hidebysig instance bool 
          Contains(class Avro.SchemaName name) cil managed
  {
    // Code size       18 (0x12)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>::ContainsKey(!0)
    IL_000c:  brfalse.s  IL_0010

    IL_000e:  ldc.i4.1
    IL_000f:  ret

    IL_0010:  ldc.i4.0
    IL_0011:  ret
  } // end of method SchemaNames::Contains

  .method public hidebysig instance bool 
          Add(class Avro.SchemaName name,
              class Avro.NamedSchema schema) cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>::ContainsKey(!0)
    IL_000c:  brfalse.s  IL_0010

    IL_000e:  ldc.i4.0
    IL_000f:  ret

    IL_0010:  ldarg.0
    IL_0011:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    IL_0016:  ldarg.1
    IL_0017:  ldarg.2
    IL_0018:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>::Add(!0,
                                                                                                                                                   !1)
    IL_001d:  ldc.i4.1
    IL_001e:  ret
  } // end of method SchemaNames::Add

  .method public hidebysig instance bool 
          Add(class Avro.NamedSchema schema) cil managed
  {
    // Code size       16 (0x10)
    .maxstack  3
    .locals init (class Avro.SchemaName V_0)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0006:  stloc.0
    IL_0007:  ldarg.0
    IL_0008:  ldloc.0
    IL_0009:  ldarg.1
    IL_000a:  call       instance bool Avro.SchemaNames::Add(class Avro.SchemaName,
                                                             class Avro.NamedSchema)
    IL_000f:  ret
  } // end of method SchemaNames::Add

  .method public hidebysig instance bool 
          TryGetValue(string name,
                      string space,
                      string encspace,
                      [out] class Avro.NamedSchema& schema) cil managed
  {
    // Code size       24 (0x18)
    .maxstack  3
    .locals init (class Avro.SchemaName V_0)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.2
    IL_0002:  ldarg.3
    IL_0003:  newobj     instance void Avro.SchemaName::.ctor(string,
                                                              string,
                                                              string)
    IL_0008:  stloc.0
    IL_0009:  ldarg.0
    IL_000a:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    IL_000f:  ldloc.0
    IL_0010:  ldarg.s    schema
    IL_0012:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>::TryGetValue(!0,
                                                                                                                                                           !1&)
    IL_0017:  ret
  } // end of method SchemaNames::TryGetValue

  .method public hidebysig instance class [mscorlib]System.Collections.Generic.IEnumerator`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>> 
          GetEnumerator() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    IL_0006:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<valuetype [mscorlib]System.Collections.Generic.KeyValuePair`2<class Avro.SchemaName,class Avro.NamedSchema>>::GetEnumerator()
    IL_000b:  ret
  } // end of method SchemaNames::GetEnumerator

  .property instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>
          Names()
  {
    .get instance class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema> Avro.SchemaNames::get_Names()
    .set instance void Avro.SchemaNames::set_Names(class [mscorlib]System.Collections.Generic.IDictionary`2<class Avro.SchemaName,class Avro.NamedSchema>)
  } // end of property SchemaNames::Names
} // end of class Avro.SchemaNames

.class public abstract auto ansi sealed beforefieldinit Avro.SchemaNormalization
       extends [mscorlib]System.Object
{
  .class abstract auto ansi sealed nested private Fp64
         extends [mscorlib]System.Object
  {
    .field private static initonly int64[] fpTable
    .method public hidebysig specialname static 
            int64[]  get_FpTable() cil managed
    {
      // Code size       6 (0x6)
      .maxstack  8
      IL_0000:  ldsfld     int64[] Avro.SchemaNormalization/Fp64::fpTable
      IL_0005:  ret
    } // end of method Fp64::get_FpTable

    .method private hidebysig specialname rtspecialname static 
            void  .cctor() cil managed
    {
      // Code size       73 (0x49)
      .maxstack  3
      .locals init (int32 V_0,
               int64 V_1,
               int32 V_2,
               int64 V_3)
      IL_0000:  ldc.i4     0x100
      IL_0005:  newarr     [mscorlib]System.Int64
      IL_000a:  stsfld     int64[] Avro.SchemaNormalization/Fp64::fpTable
      IL_000f:  ldc.i4.0
      IL_0010:  stloc.0
      IL_0011:  br.s       IL_0040

      IL_0013:  ldloc.0
      IL_0014:  conv.i8
      IL_0015:  stloc.1
      IL_0016:  ldc.i4.0
      IL_0017:  stloc.2
      IL_0018:  br.s       IL_0030

      IL_001a:  ldloc.1
      IL_001b:  ldc.i4.1
      IL_001c:  conv.i8
      IL_001d:  and
      IL_001e:  neg
      IL_001f:  stloc.3
      IL_0020:  ldloc.1
      IL_0021:  ldc.i4.1
      IL_0022:  shr.un
      IL_0023:  ldsfld     int64 Avro.SchemaNormalization::Empty64
      IL_0028:  ldloc.3
      IL_0029:  and
      IL_002a:  xor
      IL_002b:  stloc.1
      IL_002c:  ldloc.2
      IL_002d:  ldc.i4.1
      IL_002e:  add
      IL_002f:  stloc.2
      IL_0030:  ldloc.2
      IL_0031:  ldc.i4.8
      IL_0032:  blt.s      IL_001a

      IL_0034:  call       int64[] Avro.SchemaNormalization/Fp64::get_FpTable()
      IL_0039:  ldloc.0
      IL_003a:  ldloc.1
      IL_003b:  stelem.i8
      IL_003c:  ldloc.0
      IL_003d:  ldc.i4.1
      IL_003e:  add
      IL_003f:  stloc.0
      IL_0040:  ldloc.0
      IL_0041:  ldc.i4     0x100
      IL_0046:  blt.s      IL_0013

      IL_0048:  ret
    } // end of method Fp64::.cctor

    .property int64[] FpTable()
    {
      .get int64[] Avro.SchemaNormalization/Fp64::get_FpTable()
    } // end of property Fp64::FpTable
  } // end of class Fp64

  .field public static int64 Empty64
  .method public hidebysig static string 
          ToParsingForm(class Avro.Schema s) cil managed
  {
    // Code size       24 (0x18)
    .maxstack  3
    .locals init (class [mscorlib]System.Collections.Generic.IDictionary`2<string,string> V_0)
    IL_0000:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::.ctor()
    IL_0005:  stloc.0
    IL_0006:  ldloc.0
    IL_0007:  ldarg.0
    IL_0008:  newobj     instance void [mscorlib]System.Text.StringBuilder::.ctor()
    IL_000d:  call       class [mscorlib]System.Text.StringBuilder Avro.SchemaNormalization::Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>,
                                                                                                   class Avro.Schema,
                                                                                                   class [mscorlib]System.Text.StringBuilder)
    IL_0012:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0017:  ret
  } // end of method SchemaNormalization::ToParsingForm

  .method public hidebysig static uint8[] 
          Fingerprint(string fpName,
                      uint8[] data) cil managed
  {
    // Code size       134 (0x86)
    .maxstack  3
    .locals init (int64 V_0,
             uint8[] V_1,
             int32 V_2,
             class [mscorlib]System.Security.Cryptography.MD5 V_3,
             class [mscorlib]System.Security.Cryptography.SHA256 V_4,
             string V_5)
    IL_0000:  ldarg.0
    IL_0001:  dup
    IL_0002:  stloc.s    V_5
    IL_0004:  brfalse.s  IL_0075

    IL_0006:  ldloc.s    V_5
    IL_0008:  ldstr      "CRC-64-AVRO"
    IL_000d:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0012:  brtrue.s   IL_0032

    IL_0014:  ldloc.s    V_5
    IL_0016:  ldstr      "MD5"
    IL_001b:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_0020:  brtrue.s   IL_0057

    IL_0022:  ldloc.s    V_5
    IL_0024:  ldstr      "SHA-256"
    IL_0029:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_002e:  brtrue.s   IL_0065

    IL_0030:  br.s       IL_0075

    IL_0032:  ldarg.1
    IL_0033:  call       int64 Avro.SchemaNormalization::Fingerprint64(uint8[])
    IL_0038:  stloc.0
    IL_0039:  ldc.i4.8
    IL_003a:  newarr     [mscorlib]System.Byte
    IL_003f:  stloc.1
    IL_0040:  ldc.i4.0
    IL_0041:  stloc.2
    IL_0042:  br.s       IL_0051

    IL_0044:  ldloc.1
    IL_0045:  ldloc.2
    IL_0046:  ldloc.0
    IL_0047:  conv.u1
    IL_0048:  stelem.i1
    IL_0049:  ldloc.0
    IL_004a:  ldc.i4.8
    IL_004b:  shr
    IL_004c:  stloc.0
    IL_004d:  ldloc.2
    IL_004e:  ldc.i4.1
    IL_004f:  add
    IL_0050:  stloc.2
    IL_0051:  ldloc.2
    IL_0052:  ldc.i4.8
    IL_0053:  blt.s      IL_0044

    IL_0055:  ldloc.1
    IL_0056:  ret

    IL_0057:  call       class [mscorlib]System.Security.Cryptography.MD5 [mscorlib]System.Security.Cryptography.MD5::Create()
    IL_005c:  stloc.3
    IL_005d:  ldloc.3
    IL_005e:  ldarg.1
    IL_005f:  callvirt   instance uint8[] [mscorlib]System.Security.Cryptography.HashAlgorithm::ComputeHash(uint8[])
    IL_0064:  ret

    IL_0065:  call       class [mscorlib]System.Security.Cryptography.SHA256 [mscorlib]System.Security.Cryptography.SHA256::Create()
    IL_006a:  stloc.s    V_4
    IL_006c:  ldloc.s    V_4
    IL_006e:  ldarg.1
    IL_006f:  callvirt   instance uint8[] [mscorlib]System.Security.Cryptography.HashAlgorithm::ComputeHash(uint8[])
    IL_0074:  ret

    IL_0075:  ldstr      "Unsupported fingerprint computation algorithm ({0})"
    IL_007a:  ldarg.0
    IL_007b:  call       string [mscorlib]System.String::Format(string,
                                                                object)
    IL_0080:  newobj     instance void [mscorlib]System.ArgumentException::.ctor(string)
    IL_0085:  throw
  } // end of method SchemaNormalization::Fingerprint

  .method public hidebysig static uint8[] 
          ParsingFingerprint(string fpName,
                             class Avro.Schema s) cil managed
  {
    // Code size       23 (0x17)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
    IL_0006:  ldarg.1
    IL_0007:  call       string Avro.SchemaNormalization::ToParsingForm(class Avro.Schema)
    IL_000c:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_0011:  call       uint8[] Avro.SchemaNormalization::Fingerprint(string,
                                                                       uint8[])
    IL_0016:  ret
  } // end of method SchemaNormalization::ParsingFingerprint

  .method public hidebysig static int64  ParsingFingerprint64(class Avro.Schema s) cil managed
  {
    // Code size       22 (0x16)
    .maxstack  8
    IL_0000:  call       class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::get_UTF8()
    IL_0005:  ldarg.0
    IL_0006:  call       string Avro.SchemaNormalization::ToParsingForm(class Avro.Schema)
    IL_000b:  callvirt   instance uint8[] [mscorlib]System.Text.Encoding::GetBytes(string)
    IL_0010:  call       int64 Avro.SchemaNormalization::Fingerprint64(uint8[])
    IL_0015:  ret
  } // end of method SchemaNormalization::ParsingFingerprint64

  .method private hidebysig static int64 
          Fingerprint64(uint8[] data) cil managed
  {
    // Code size       50 (0x32)
    .maxstack  4
    .locals init (int64 V_0,
             uint8 V_1,
             uint8[] V_2,
             int32 V_3)
    IL_0000:  ldsfld     int64 Avro.SchemaNormalization::Empty64
    IL_0005:  stloc.0
    IL_0006:  ldarg.0
    IL_0007:  stloc.2
    IL_0008:  ldc.i4.0
    IL_0009:  stloc.3
    IL_000a:  br.s       IL_002a

    IL_000c:  ldloc.2
    IL_000d:  ldloc.3
    IL_000e:  ldelem.u1
    IL_000f:  stloc.1
    IL_0010:  ldloc.0
    IL_0011:  ldc.i4.8
    IL_0012:  shr.un
    IL_0013:  call       int64[] Avro.SchemaNormalization/Fp64::get_FpTable()
    IL_0018:  ldloc.0
    IL_0019:  ldloc.1
    IL_001a:  conv.u8
    IL_001b:  xor
    IL_001c:  conv.i4
    IL_001d:  ldc.i4     0xff
    IL_0022:  and
    IL_0023:  ldelem.i8
    IL_0024:  xor
    IL_0025:  stloc.0
    IL_0026:  ldloc.3
    IL_0027:  ldc.i4.1
    IL_0028:  add
    IL_0029:  stloc.3
    IL_002a:  ldloc.3
    IL_002b:  ldloc.2
    IL_002c:  ldlen
    IL_002d:  conv.i4
    IL_002e:  blt.s      IL_000c

    IL_0030:  ldloc.0
    IL_0031:  ret
  } // end of method SchemaNormalization::Fingerprint64

  .method private hidebysig static class [mscorlib]System.Text.StringBuilder 
          Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string> env,
                class Avro.Schema s,
                class [mscorlib]System.Text.StringBuilder o) cil managed
  {
    // Code size       807 (0x327)
    .maxstack  4
    .locals init (bool V_0,
             valuetype Avro.Schema/Type V_1,
             class Avro.UnionSchema V_2,
             class Avro.Schema V_3,
             class Avro.ArraySchema V_4,
             class Avro.MapSchema V_5,
             class Avro.NamedSchema V_6,
             string V_7,
             string V_8,
             class Avro.EnumSchema V_9,
             string V_10,
             class Avro.FixedSchema V_11,
             class Avro.RecordSchema V_12,
             class Avro.Field V_13,
             valuetype Avro.Schema/Type V_14,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_15,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<string> V_16,
             int32 V_17,
             valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field> V_18)
    IL_0000:  ldc.i4.1
    IL_0001:  stloc.0
    IL_0002:  ldarg.1
    IL_0003:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0008:  stloc.1
    IL_0009:  ldloc.1
    IL_000a:  stloc.s    V_14
    IL_000c:  ldloc.s    V_14
    IL_000e:  ldc.i4.8
    IL_000f:  sub
    IL_0010:  switch     ( 
                          IL_0110,
                          IL_0110,
                          IL_0095,
                          IL_0095,
                          IL_0032,
                          IL_0110)
    IL_002d:  br         IL_0306

    IL_0032:  ldarg.1
    IL_0033:  isinst     Avro.UnionSchema
    IL_0038:  stloc.2
    IL_0039:  ldarg.2
    IL_003a:  ldc.i4.s   91
    IL_003c:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(char)
    IL_0041:  pop
    IL_0042:  ldloc.2
    IL_0043:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_0048:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_004d:  stloc.s    V_15
    .try
    {
      IL_004f:  br.s       IL_0075

      IL_0051:  ldloc.s    V_15
      IL_0053:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0058:  stloc.3
      IL_0059:  ldloc.0
      IL_005a:  brtrue.s   IL_006a

      IL_005c:  ldarg.2
      IL_005d:  ldstr      ","
      IL_0062:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_0067:  pop
      IL_0068:  br.s       IL_006c

      IL_006a:  ldc.i4.0
      IL_006b:  stloc.0
      IL_006c:  ldarg.0
      IL_006d:  ldloc.3
      IL_006e:  ldarg.2
      IL_006f:  call       class [mscorlib]System.Text.StringBuilder Avro.SchemaNormalization::Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>,
                                                                                                     class Avro.Schema,
                                                                                                     class [mscorlib]System.Text.StringBuilder)
      IL_0074:  pop
      IL_0075:  ldloc.s    V_15
      IL_0077:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_007c:  brtrue.s   IL_0051

      IL_007e:  leave.s    IL_008c

    }  // end .try
    finally
    {
      IL_0080:  ldloc.s    V_15
      IL_0082:  brfalse.s  IL_008b

      IL_0084:  ldloc.s    V_15
      IL_0086:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_008b:  endfinally
    }  // end handler
    IL_008c:  ldarg.2
    IL_008d:  ldc.i4.s   93
    IL_008f:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(char)
    IL_0094:  ret

    IL_0095:  ldarg.2
    IL_0096:  ldstr      "{\"type\":\""
    IL_009b:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00a0:  ldarg.1
    IL_00a1:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_00a6:  call       string Avro.Schema::GetTypeString(valuetype Avro.Schema/Type)
    IL_00ab:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00b0:  ldstr      "\""
    IL_00b5:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00ba:  pop
    IL_00bb:  ldloc.1
    IL_00bc:  ldc.i4.s   10
    IL_00be:  bne.un.s   IL_00e3

    IL_00c0:  ldarg.1
    IL_00c1:  isinst     Avro.ArraySchema
    IL_00c6:  stloc.s    V_4
    IL_00c8:  ldarg.0
    IL_00c9:  ldloc.s    V_4
    IL_00cb:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_00d0:  ldarg.2
    IL_00d1:  ldstr      ",\"items\":"
    IL_00d6:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00db:  call       class [mscorlib]System.Text.StringBuilder Avro.SchemaNormalization::Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>,
                                                                                                   class Avro.Schema,
                                                                                                   class [mscorlib]System.Text.StringBuilder)
    IL_00e0:  pop
    IL_00e1:  br.s       IL_0104

    IL_00e3:  ldarg.1
    IL_00e4:  isinst     Avro.MapSchema
    IL_00e9:  stloc.s    V_5
    IL_00eb:  ldarg.0
    IL_00ec:  ldloc.s    V_5
    IL_00ee:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_00f3:  ldarg.2
    IL_00f4:  ldstr      ",\"values\":"
    IL_00f9:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_00fe:  call       class [mscorlib]System.Text.StringBuilder Avro.SchemaNormalization::Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>,
                                                                                                   class Avro.Schema,
                                                                                                   class [mscorlib]System.Text.StringBuilder)
    IL_0103:  pop
    IL_0104:  ldarg.2
    IL_0105:  ldstr      "}"
    IL_010a:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_010f:  ret

    IL_0110:  ldarg.1
    IL_0111:  isinst     Avro.NamedSchema
    IL_0116:  stloc.s    V_6
    IL_0118:  ldloc.s    V_6
    IL_011a:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_011f:  stloc.s    V_7
    IL_0121:  ldarg.0
    IL_0122:  ldloc.s    V_7
    IL_0124:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>::ContainsKey(!0)
    IL_0129:  brfalse.s  IL_013a

    IL_012b:  ldarg.2
    IL_012c:  ldarg.0
    IL_012d:  ldloc.s    V_7
    IL_012f:  callvirt   instance !1 class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>::get_Item(!0)
    IL_0134:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0139:  ret

    IL_013a:  ldstr      "\""
    IL_013f:  ldloc.s    V_7
    IL_0141:  ldstr      "\""
    IL_0146:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_014b:  stloc.s    V_8
    IL_014d:  ldarg.0
    IL_014e:  ldloc.s    V_7
    IL_0150:  ldloc.s    V_8
    IL_0152:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>::Add(!0,
                                                                                                                    !1)
    IL_0157:  ldarg.2
    IL_0158:  ldstr      "{\"name\":"
    IL_015d:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0162:  ldloc.s    V_8
    IL_0164:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0169:  pop
    IL_016a:  ldarg.2
    IL_016b:  ldstr      ",\"type\":\""
    IL_0170:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0175:  ldarg.1
    IL_0176:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_017b:  call       string Avro.Schema::GetTypeString(valuetype Avro.Schema/Type)
    IL_0180:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0185:  ldstr      "\""
    IL_018a:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_018f:  pop
    IL_0190:  ldloc.1
    IL_0191:  ldc.i4.s   9
    IL_0193:  bne.un     IL_021d

    IL_0198:  ldarg.1
    IL_0199:  isinst     Avro.EnumSchema
    IL_019e:  stloc.s    V_9
    IL_01a0:  ldarg.2
    IL_01a1:  ldstr      ",\"symbols\":["
    IL_01a6:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_01ab:  pop
    IL_01ac:  ldloc.s    V_9
    IL_01ae:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_01b3:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<string>::GetEnumerator()
    IL_01b8:  stloc.s    V_16
    .try
    {
      IL_01ba:  br.s       IL_01f5

      IL_01bc:  ldloc.s    V_16
      IL_01be:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<string>::get_Current()
      IL_01c3:  stloc.s    V_10
      IL_01c5:  ldloc.0
      IL_01c6:  brtrue.s   IL_01d6

      IL_01c8:  ldarg.2
      IL_01c9:  ldstr      ","
      IL_01ce:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_01d3:  pop
      IL_01d4:  br.s       IL_01d8

      IL_01d6:  ldc.i4.0
      IL_01d7:  stloc.0
      IL_01d8:  ldarg.2
      IL_01d9:  ldstr      "\""
      IL_01de:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_01e3:  ldloc.s    V_10
      IL_01e5:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_01ea:  ldstr      "\""
      IL_01ef:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_01f4:  pop
      IL_01f5:  ldloc.s    V_16
      IL_01f7:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_01fc:  brtrue.s   IL_01bc

      IL_01fe:  leave.s    IL_020c

    }  // end .try
    finally
    {
      IL_0200:  ldloc.s    V_16
      IL_0202:  brfalse.s  IL_020b

      IL_0204:  ldloc.s    V_16
      IL_0206:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_020b:  endfinally
    }  // end handler
    IL_020c:  ldarg.2
    IL_020d:  ldstr      "]"
    IL_0212:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0217:  pop
    IL_0218:  br         IL_02fa

    IL_021d:  ldloc.1
    IL_021e:  ldc.i4.s   13
    IL_0220:  bne.un.s   IL_0250

    IL_0222:  ldarg.1
    IL_0223:  isinst     Avro.FixedSchema
    IL_0228:  stloc.s    V_11
    IL_022a:  ldarg.2
    IL_022b:  ldstr      ",\"size\":"
    IL_0230:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0235:  ldloc.s    V_11
    IL_0237:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_023c:  stloc.s    V_17
    IL_023e:  ldloca.s   V_17
    IL_0240:  call       instance string [mscorlib]System.Int32::ToString()
    IL_0245:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_024a:  pop
    IL_024b:  br         IL_02fa

    IL_0250:  ldarg.1
    IL_0251:  isinst     Avro.RecordSchema
    IL_0256:  stloc.s    V_12
    IL_0258:  ldarg.2
    IL_0259:  ldstr      ",\"fields\":["
    IL_025e:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0263:  pop
    IL_0264:  ldloc.s    V_12
    IL_0266:  callvirt   instance class [mscorlib]System.Collections.Generic.List`1<class Avro.Field> Avro.RecordSchema::get_Fields()
    IL_026b:  callvirt   instance valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<!0> class [mscorlib]System.Collections.Generic.List`1<class Avro.Field>::GetEnumerator()
    IL_0270:  stloc.s    V_18
    .try
    {
      IL_0272:  br.s       IL_02d5

      IL_0274:  ldloca.s   V_18
      IL_0276:  call       instance !0 valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::get_Current()
      IL_027b:  stloc.s    V_13
      IL_027d:  ldloc.0
      IL_027e:  brtrue.s   IL_028e

      IL_0280:  ldarg.2
      IL_0281:  ldstr      ","
      IL_0286:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_028b:  pop
      IL_028c:  br.s       IL_0290

      IL_028e:  ldc.i4.0
      IL_028f:  stloc.0
      IL_0290:  ldarg.2
      IL_0291:  ldstr      "{\"name\":\""
      IL_0296:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_029b:  ldloc.s    V_13
      IL_029d:  ldfld      string Avro.Field::Name
      IL_02a2:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02a7:  ldstr      "\""
      IL_02ac:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02b1:  pop
      IL_02b2:  ldarg.0
      IL_02b3:  ldloc.s    V_13
      IL_02b5:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_02ba:  ldarg.2
      IL_02bb:  ldstr      ",\"type\":"
      IL_02c0:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02c5:  call       class [mscorlib]System.Text.StringBuilder Avro.SchemaNormalization::Build(class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>,
                                                                                                     class Avro.Schema,
                                                                                                     class [mscorlib]System.Text.StringBuilder)
      IL_02ca:  ldstr      "}"
      IL_02cf:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
      IL_02d4:  pop
      IL_02d5:  ldloca.s   V_18
      IL_02d7:  call       instance bool valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>::MoveNext()
      IL_02dc:  brtrue.s   IL_0274

      IL_02de:  leave.s    IL_02ee

    }  // end .try
    finally
    {
      IL_02e0:  ldloca.s   V_18
      IL_02e2:  constrained. valuetype [mscorlib]System.Collections.Generic.List`1/Enumerator<class Avro.Field>
      IL_02e8:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_02ed:  endfinally
    }  // end handler
    IL_02ee:  ldarg.2
    IL_02ef:  ldstr      "]"
    IL_02f4:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_02f9:  pop
    IL_02fa:  ldarg.2
    IL_02fb:  ldstr      "}"
    IL_0300:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0305:  ret

    IL_0306:  ldarg.2
    IL_0307:  ldstr      "\""
    IL_030c:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0311:  ldarg.1
    IL_0312:  callvirt   instance string Avro.Schema::get_Name()
    IL_0317:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_031c:  ldstr      "\""
    IL_0321:  callvirt   instance class [mscorlib]System.Text.StringBuilder [mscorlib]System.Text.StringBuilder::Append(string)
    IL_0326:  ret
  } // end of method SchemaNormalization::Build

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       15 (0xf)
    .maxstack  8
    IL_0000:  ldc.i8     0xc15d213aa4d7a795
    IL_0009:  stsfld     int64 Avro.SchemaNormalization::Empty64
    IL_000e:  ret
  } // end of method SchemaNormalization::.cctor

} // end of class Avro.SchemaNormalization

.class public auto ansi beforefieldinit Avro.SchemaParseException
       extends Avro.AvroException
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(string s) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.AvroException::.ctor(string)
    IL_0007:  ret
  } // end of method SchemaParseException::.ctor

} // end of class Avro.SchemaParseException

.class public auto ansi beforefieldinit Avro.UnionSchema
       extends Avro.UnnamedSchema
{
  .custom instance void [mscorlib]System.Reflection.DefaultMemberAttribute::.ctor(string) = ( 01 00 04 49 74 65 6D 00 00 )                      // ...Item..
  .field private class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> '<Schemas>k__BackingField'
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .method public hidebysig specialname instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 
          get_Schemas() cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       7 (0x7)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::'<Schemas>k__BackingField'
    IL_0006:  ret
  } // end of method UnionSchema::get_Schemas

  .method private hidebysig specialname instance void 
          set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> 'value') cil managed
  {
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  stfld      class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::'<Schemas>k__BackingField'
    IL_0007:  ret
  } // end of method UnionSchema::set_Schemas

  .method public hidebysig specialname instance int32 
          get_Count() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_0006:  callvirt   instance int32 class [mscorlib]System.Collections.Generic.ICollection`1<class Avro.Schema>::get_Count()
    IL_000b:  ret
  } // end of method UnionSchema::get_Count

  .method assembly hidebysig static class Avro.UnionSchema 
          NewInstance(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JArray jarr,
                      class Avro.PropertyMap props,
                      class Avro.SchemaNames names,
                      string encspace) cil managed
  {
    // Code size       148 (0x94)
    .maxstack  3
    .locals init (class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema> V_0,
             class [mscorlib]System.Collections.Generic.IDictionary`2<string,string> V_1,
             class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken V_2,
             class Avro.Schema V_3,
             string V_4,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken> V_5)
    IL_0000:  newobj     instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::.ctor()
    IL_0005:  stloc.0
    IL_0006:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,string>::.ctor()
    IL_000b:  stloc.1
    IL_000c:  ldarg.0
    IL_000d:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::GetEnumerator()
    IL_0012:  stloc.s    V_5
    .try
    {
      IL_0014:  br.s       IL_0075

      IL_0016:  ldloc.s    V_5
      IL_0018:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken>::get_Current()
      IL_001d:  stloc.2
      IL_001e:  ldloc.2
      IL_001f:  ldarg.2
      IL_0020:  ldarg.3
      IL_0021:  call       class Avro.Schema Avro.Schema::ParseJson(class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken,
                                                                    class Avro.SchemaNames,
                                                                    string)
      IL_0026:  stloc.3
      IL_0027:  ldloc.3
      IL_0028:  brtrue.s   IL_0040

      IL_002a:  ldstr      "Invalid JSON in union"
      IL_002f:  ldloc.2
      IL_0030:  callvirt   instance string [mscorlib]System.Object::ToString()
      IL_0035:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_003a:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_003f:  throw

      IL_0040:  ldloc.3
      IL_0041:  callvirt   instance string Avro.Schema::get_Name()
      IL_0046:  stloc.s    V_4
      IL_0048:  ldloc.1
      IL_0049:  ldloc.s    V_4
      IL_004b:  callvirt   instance bool class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>::ContainsKey(!0)
      IL_0050:  brfalse.s  IL_0064

      IL_0052:  ldstr      "Duplicate type in union: "
      IL_0057:  ldloc.s    V_4
      IL_0059:  call       string [mscorlib]System.String::Concat(string,
                                                                  string)
      IL_005e:  newobj     instance void Avro.SchemaParseException::.ctor(string)
      IL_0063:  throw

      IL_0064:  ldloc.1
      IL_0065:  ldloc.s    V_4
      IL_0067:  ldloc.s    V_4
      IL_0069:  callvirt   instance void class [mscorlib]System.Collections.Generic.IDictionary`2<string,string>::Add(!0,
                                                                                                                      !1)
      IL_006e:  ldloc.0
      IL_006f:  ldloc.3
      IL_0070:  callvirt   instance void class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>::Add(!0)
      IL_0075:  ldloc.s    V_5
      IL_0077:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_007c:  brtrue.s   IL_0016

      IL_007e:  leave.s    IL_008c

    }  // end .try
    finally
    {
      IL_0080:  ldloc.s    V_5
      IL_0082:  brfalse.s  IL_008b

      IL_0084:  ldloc.s    V_5
      IL_0086:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_008b:  endfinally
    }  // end handler
    IL_008c:  ldloc.0
    IL_008d:  ldarg.1
    IL_008e:  newobj     instance void Avro.UnionSchema::.ctor(class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema>,
                                                               class Avro.PropertyMap)
    IL_0093:  ret
  } // end of method UnionSchema::NewInstance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor(class [mscorlib]System.Collections.Generic.List`1<class Avro.Schema> schemas,
                               class Avro.PropertyMap props) cil managed
  {
    // Code size       31 (0x1f)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldc.i4.s   12
    IL_0003:  ldarg.2
    IL_0004:  call       instance void Avro.UnnamedSchema::.ctor(valuetype Avro.Schema/Type,
                                                                 class Avro.PropertyMap)
    IL_0009:  ldarg.1
    IL_000a:  brtrue.s   IL_0017

    IL_000c:  ldstr      "schemas"
    IL_0011:  newobj     instance void [mscorlib]System.ArgumentNullException::.ctor(string)
    IL_0016:  throw

    IL_0017:  ldarg.0
    IL_0018:  ldarg.1
    IL_0019:  call       instance void Avro.UnionSchema::set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
    IL_001e:  ret
  } // end of method UnionSchema::.ctor

  .method public hidebysig specialname instance class Avro.Schema 
          get_Item(int32 index) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_0006:  ldarg.1
    IL_0007:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>::get_Item(int32)
    IL_000c:  ret
  } // end of method UnionSchema::get_Item

  .method famorassem hidebysig virtual instance void 
          WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter writer,
                    class Avro.SchemaNames names,
                    string encspace) cil managed
  {
    // Code size       63 (0x3f)
    .maxstack  4
    .locals init (class Avro.Schema V_0,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_1)
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteStartArray()
    IL_0006:  ldarg.0
    IL_0007:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_000c:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_0011:  stloc.1
    .try
    {
      IL_0012:  br.s       IL_0024

      IL_0014:  ldloc.1
      IL_0015:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_001a:  stloc.0
      IL_001b:  ldloc.0
      IL_001c:  ldarg.1
      IL_001d:  ldarg.2
      IL_001e:  ldarg.3
      IL_001f:  callvirt   instance void Avro.Schema::WriteJson(class [Newtonsoft.Json]Newtonsoft.Json.JsonTextWriter,
                                                                class Avro.SchemaNames,
                                                                string)
      IL_0024:  ldloc.1
      IL_0025:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_002a:  brtrue.s   IL_0014

      IL_002c:  leave.s    IL_0038

    }  // end .try
    finally
    {
      IL_002e:  ldloc.1
      IL_002f:  brfalse.s  IL_0037

      IL_0031:  ldloc.1
      IL_0032:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0037:  endfinally
    }  // end handler
    IL_0038:  ldarg.1
    IL_0039:  callvirt   instance void [Newtonsoft.Json]Newtonsoft.Json.JsonWriter::WriteEndArray()
    IL_003e:  ret
  } // end of method UnionSchema::WriteJson

  .method public hidebysig instance int32 
          MatchingBranch(class Avro.Schema s) cil managed
  {
    // Code size       60 (0x3c)
    .maxstack  2
    .locals init (int32 V_0)
    IL_0000:  ldarg.1
    IL_0001:  isinst     Avro.UnionSchema
    IL_0006:  brfalse.s  IL_0013

    IL_0008:  ldstr      "Cannot find a match against union schema"
    IL_000d:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0012:  throw

    IL_0013:  ldc.i4.0
    IL_0014:  stloc.0
    IL_0015:  br.s       IL_0031

    IL_0017:  ldarg.0
    IL_0018:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>::get_Item(int32)
    IL_0023:  ldarg.1
    IL_0024:  callvirt   instance bool Avro.Schema::CanRead(class Avro.Schema)
    IL_0029:  brfalse.s  IL_002d

    IL_002b:  ldloc.0
    IL_002c:  ret

    IL_002d:  ldloc.0
    IL_002e:  ldc.i4.1
    IL_002f:  add
    IL_0030:  stloc.0
    IL_0031:  ldloc.0
    IL_0032:  ldarg.0
    IL_0033:  call       instance int32 Avro.UnionSchema::get_Count()
    IL_0038:  blt.s      IL_0017

    IL_003a:  ldc.i4.m1
    IL_003b:  ret
  } // end of method UnionSchema::MatchingBranch

  .method public hidebysig virtual instance bool 
          CanRead(class Avro.Schema writerSchema) cil managed
  {
    // Code size       26 (0x1a)
    .maxstack  8
    IL_0000:  ldarg.1
    IL_0001:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0006:  ldc.i4.s   12
    IL_0008:  beq.s      IL_0018

    IL_000a:  ldarg.0
    IL_000b:  ldarg.1
    IL_000c:  call       instance int32 Avro.UnionSchema::MatchingBranch(class Avro.Schema)
    IL_0011:  ldc.i4.0
    IL_0012:  clt
    IL_0014:  ldc.i4.0
    IL_0015:  ceq
    IL_0017:  ret

    IL_0018:  ldc.i4.1
    IL_0019:  ret
  } // end of method UnionSchema::CanRead

  .method public hidebysig virtual instance bool 
          Equals(object obj) cil managed
  {
    // Code size       98 (0x62)
    .maxstack  3
    .locals init (class Avro.UnionSchema V_0,
             int32 V_1)
    IL_0000:  ldarg.1
    IL_0001:  ldarg.0
    IL_0002:  bne.un.s   IL_0006

    IL_0004:  ldc.i4.1
    IL_0005:  ret

    IL_0006:  ldarg.1
    IL_0007:  brfalse.s  IL_0060

    IL_0009:  ldarg.1
    IL_000a:  isinst     Avro.UnionSchema
    IL_000f:  brfalse.s  IL_0060

    IL_0011:  ldarg.1
    IL_0012:  isinst     Avro.UnionSchema
    IL_0017:  stloc.0
    IL_0018:  ldloc.0
    IL_0019:  callvirt   instance int32 Avro.UnionSchema::get_Count()
    IL_001e:  ldarg.0
    IL_001f:  call       instance int32 Avro.UnionSchema::get_Count()
    IL_0024:  bne.un.s   IL_0060

    IL_0026:  ldc.i4.0
    IL_0027:  stloc.1
    IL_0028:  br.s       IL_0045

    IL_002a:  ldloc.0
    IL_002b:  ldloc.1
    IL_002c:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_0031:  ldarg.0
    IL_0032:  ldloc.1
    IL_0033:  call       instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_0038:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_003d:  brtrue.s   IL_0041

    IL_003f:  ldc.i4.0
    IL_0040:  ret

    IL_0041:  ldloc.1
    IL_0042:  ldc.i4.1
    IL_0043:  add
    IL_0044:  stloc.1
    IL_0045:  ldloc.1
    IL_0046:  ldarg.0
    IL_0047:  call       instance int32 Avro.UnionSchema::get_Count()
    IL_004c:  blt.s      IL_002a

    IL_004e:  ldloc.0
    IL_004f:  callvirt   instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_0054:  ldarg.0
    IL_0055:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_005a:  call       bool Avro.Schema::areEqual(object,
                                                    object)
    IL_005f:  ret

    IL_0060:  ldc.i4.0
    IL_0061:  ret
  } // end of method UnionSchema::Equals

  .method public hidebysig virtual instance int32 
          GetHashCode() cil managed
  {
    // Code size       72 (0x48)
    .maxstack  3
    .locals init (int32 V_0,
             class Avro.Schema V_1,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema> V_2)
    IL_0000:  ldc.i4.s   53
    IL_0002:  stloc.0
    IL_0003:  ldarg.0
    IL_0004:  call       instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    IL_0009:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<!0> class [mscorlib]System.Collections.Generic.IEnumerable`1<class Avro.Schema>::GetEnumerator()
    IL_000e:  stloc.2
    .try
    {
      IL_000f:  br.s       IL_0024

      IL_0011:  ldloc.2
      IL_0012:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Schema>::get_Current()
      IL_0017:  stloc.1
      IL_0018:  ldloc.0
      IL_0019:  ldc.i4.s   89
      IL_001b:  ldloc.1
      IL_001c:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0021:  mul
      IL_0022:  add
      IL_0023:  stloc.0
      IL_0024:  ldloc.2
      IL_0025:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_002a:  brtrue.s   IL_0011

      IL_002c:  leave.s    IL_0038

    }  // end .try
    finally
    {
      IL_002e:  ldloc.2
      IL_002f:  brfalse.s  IL_0037

      IL_0031:  ldloc.2
      IL_0032:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0037:  endfinally
    }  // end handler
    IL_0038:  ldloc.0
    IL_0039:  ldarg.0
    IL_003a:  call       instance class Avro.PropertyMap Avro.Schema::get_Props()
    IL_003f:  call       int32 Avro.Schema::getHashCode(object)
    IL_0044:  add
    IL_0045:  stloc.0
    IL_0046:  ldloc.0
    IL_0047:  ret
  } // end of method UnionSchema::GetHashCode

  .property instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>
          Schemas()
  {
    .get instance class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema> Avro.UnionSchema::get_Schemas()
    .set instance void Avro.UnionSchema::set_Schemas(class [mscorlib]System.Collections.Generic.IList`1<class Avro.Schema>)
  } // end of property UnionSchema::Schemas
  .property instance int32 Count()
  {
    .get instance int32 Avro.UnionSchema::get_Count()
  } // end of property UnionSchema::Count
  .property instance class Avro.Schema Item(int32)
  {
    .get instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
  } // end of property UnionSchema::Item
} // end of class Avro.UnionSchema

.class public auto ansi sealed beforefieldinit Avro.Specific.ObjectCreator
       extends [mscorlib]System.Object
{
  .class auto ansi sealed nested public CtorDelegate
         extends [mscorlib]System.MulticastDelegate
  {
    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(object 'object',
                                 native int 'method') runtime managed
    {
    } // end of method CtorDelegate::.ctor

    .method public hidebysig newslot virtual 
            instance object  Invoke() runtime managed
    {
    } // end of method CtorDelegate::Invoke

    .method public hidebysig newslot virtual 
            instance class [mscorlib]System.IAsyncResult 
            BeginInvoke(class [mscorlib]System.AsyncCallback callback,
                        object 'object') runtime managed
    {
    } // end of method CtorDelegate::BeginInvoke

    .method public hidebysig newslot virtual 
            instance object  EndInvoke(class [mscorlib]System.IAsyncResult result) runtime managed
    {
    } // end of method CtorDelegate::EndInvoke

  } // end of class CtorDelegate

  .class sequential ansi sealed nested public beforefieldinit NameCtorKey
         extends [mscorlib]System.ValueType
         implements class [mscorlib]System.IEquatable`1<valuetype Avro.Specific.ObjectCreator/NameCtorKey>
  {
    .field private string '<name>k__BackingField'
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .field private valuetype Avro.Schema/Type '<type>k__BackingField'
    .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
    .method public hidebysig specialname 
            instance string  get_name() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      string Avro.Specific.ObjectCreator/NameCtorKey::'<name>k__BackingField'
      IL_0006:  ret
    } // end of method NameCtorKey::get_name

    .method private hidebysig specialname 
            instance void  set_name(string 'value') cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       8 (0x8)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  stfld      string Avro.Specific.ObjectCreator/NameCtorKey::'<name>k__BackingField'
      IL_0007:  ret
    } // end of method NameCtorKey::set_name

    .method public hidebysig specialname 
            instance valuetype Avro.Schema/Type 
            get_type() cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       7 (0x7)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldfld      valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::'<type>k__BackingField'
      IL_0006:  ret
    } // end of method NameCtorKey::get_type

    .method private hidebysig specialname 
            instance void  set_type(valuetype Avro.Schema/Type 'value') cil managed
    {
      .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       8 (0x8)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  ldarg.1
      IL_0002:  stfld      valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::'<type>k__BackingField'
      IL_0007:  ret
    } // end of method NameCtorKey::set_type

    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(string value1,
                                 valuetype Avro.Schema/Type value2) cil managed
    {
      // Code size       22 (0x16)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  initobj    Avro.Specific.ObjectCreator/NameCtorKey
      IL_0007:  ldarg.0
      IL_0008:  ldarg.1
      IL_0009:  call       instance void Avro.Specific.ObjectCreator/NameCtorKey::set_name(string)
      IL_000e:  ldarg.0
      IL_000f:  ldarg.2
      IL_0010:  call       instance void Avro.Specific.ObjectCreator/NameCtorKey::set_type(valuetype Avro.Schema/Type)
      IL_0015:  ret
    } // end of method NameCtorKey::.ctor

    .method public hidebysig newslot virtual final 
            instance bool  Equals(valuetype Avro.Specific.ObjectCreator/NameCtorKey other) cil managed
    {
      // Code size       38 (0x26)
      .maxstack  8
      IL_0000:  ldarga.s   other
      IL_0002:  call       instance string Avro.Specific.ObjectCreator/NameCtorKey::get_name()
      IL_0007:  ldarg.0
      IL_0008:  call       instance string Avro.Specific.ObjectCreator/NameCtorKey::get_name()
      IL_000d:  call       bool [mscorlib]System.Object::Equals(object,
                                                                object)
      IL_0012:  brfalse.s  IL_0024

      IL_0014:  ldarga.s   other
      IL_0016:  call       instance valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::get_type()
      IL_001b:  ldarg.0
      IL_001c:  call       instance valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::get_type()
      IL_0021:  ceq
      IL_0023:  ret

      IL_0024:  ldc.i4.0
      IL_0025:  ret
    } // end of method NameCtorKey::Equals

    .method public hidebysig virtual instance bool 
            Equals(object obj) cil managed
    {
      // Code size       49 (0x31)
      .maxstack  8
      IL_0000:  ldnull
      IL_0001:  ldarg.1
      IL_0002:  call       bool [mscorlib]System.Object::ReferenceEquals(object,
                                                                         object)
      IL_0007:  brfalse.s  IL_000b

      IL_0009:  ldc.i4.0
      IL_000a:  ret

      IL_000b:  ldarg.1
      IL_000c:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
      IL_0011:  ldtoken    Avro.Specific.ObjectCreator/NameCtorKey
      IL_0016:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
      IL_001b:  call       bool [mscorlib]System.Type::op_Inequality(class [mscorlib]System.Type,
                                                                     class [mscorlib]System.Type)
      IL_0020:  brfalse.s  IL_0024

      IL_0022:  ldc.i4.0
      IL_0023:  ret

      IL_0024:  ldarg.0
      IL_0025:  ldarg.1
      IL_0026:  unbox.any  Avro.Specific.ObjectCreator/NameCtorKey
      IL_002b:  call       instance bool Avro.Specific.ObjectCreator/NameCtorKey::Equals(valuetype Avro.Specific.ObjectCreator/NameCtorKey)
      IL_0030:  ret
    } // end of method NameCtorKey::Equals

    .method public hidebysig virtual instance int32 
            GetHashCode() cil managed
    {
      // Code size       46 (0x2e)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance string Avro.Specific.ObjectCreator/NameCtorKey::get_name()
      IL_0006:  brtrue.s   IL_000b

      IL_0008:  ldc.i4.0
      IL_0009:  br.s       IL_0016

      IL_000b:  ldarg.0
      IL_000c:  call       instance string Avro.Specific.ObjectCreator/NameCtorKey::get_name()
      IL_0011:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_0016:  ldc.i4     0x18d
      IL_001b:  mul
      IL_001c:  ldarg.0
      IL_001d:  call       instance valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::get_type()
      IL_0022:  box        Avro.Schema/Type
      IL_0027:  callvirt   instance int32 [mscorlib]System.Object::GetHashCode()
      IL_002c:  xor
      IL_002d:  ret
    } // end of method NameCtorKey::GetHashCode

    .method public hidebysig specialname static 
            bool  op_Equality(valuetype Avro.Specific.ObjectCreator/NameCtorKey left,
                              valuetype Avro.Specific.ObjectCreator/NameCtorKey right) cil managed
    {
      // Code size       9 (0x9)
      .maxstack  8
      IL_0000:  ldarga.s   left
      IL_0002:  ldarg.1
      IL_0003:  call       instance bool Avro.Specific.ObjectCreator/NameCtorKey::Equals(valuetype Avro.Specific.ObjectCreator/NameCtorKey)
      IL_0008:  ret
    } // end of method NameCtorKey::op_Equality

    .method public hidebysig specialname static 
            bool  op_Inequality(valuetype Avro.Specific.ObjectCreator/NameCtorKey left,
                                valuetype Avro.Specific.ObjectCreator/NameCtorKey right) cil managed
    {
      // Code size       12 (0xc)
      .maxstack  8
      IL_0000:  ldarga.s   left
      IL_0002:  ldarg.1
      IL_0003:  call       instance bool Avro.Specific.ObjectCreator/NameCtorKey::Equals(valuetype Avro.Specific.ObjectCreator/NameCtorKey)
      IL_0008:  ldc.i4.0
      IL_0009:  ceq
      IL_000b:  ret
    } // end of method NameCtorKey::op_Inequality

    .property instance string name()
    {
      .get instance string Avro.Specific.ObjectCreator/NameCtorKey::get_name()
      .set instance void Avro.Specific.ObjectCreator/NameCtorKey::set_name(string)
    } // end of property NameCtorKey::name
    .property instance valuetype Avro.Schema/Type
            'type'()
    {
      .set instance void Avro.Specific.ObjectCreator/NameCtorKey::set_type(valuetype Avro.Schema/Type)
      .get instance valuetype Avro.Schema/Type Avro.Specific.ObjectCreator/NameCtorKey::get_type()
    } // end of property NameCtorKey::'type'
  } // end of class NameCtorKey

  .field private static initonly class Avro.Specific.ObjectCreator 'instance'
  .field private class [mscorlib]System.Type GenericMapType
  .field private class [mscorlib]System.Type GenericListType
  .field private class [mscorlib]System.Type GenericIListType
  .field private initonly class [mscorlib]System.Reflection.Assembly execAssembly
  .field private initonly class [mscorlib]System.Reflection.Assembly entryAssembly
  .field private initonly bool diffAssembly
  .field private initonly class [mscorlib]System.Type[] margs
  .field private initonly class [mscorlib]System.Type[] largs
  .field private class [mscorlib]System.Type ctorType
  .field private class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate> ctors
  .method public hidebysig specialname static 
          class Avro.Specific.ObjectCreator 
          get_Instance() cil managed
  {
    // Code size       6 (0x6)
    .maxstack  8
    IL_0000:  ldsfld     class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::'instance'
    IL_0005:  ret
  } // end of method ObjectCreator::get_Instance

  .method private hidebysig specialname rtspecialname 
          instance void  .ctor() cil managed
  {
    // Code size       217 (0xd9)
    .maxstack  4
    .locals init (class [mscorlib]System.Type[] V_0,
             class [mscorlib]System.Type[] V_1)
    IL_0000:  ldarg.0
    IL_0001:  ldtoken    [mscorlib]System.Collections.Generic.Dictionary`2
    IL_0006:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_000b:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericMapType
    IL_0010:  ldarg.0
    IL_0011:  ldtoken    [mscorlib]System.Collections.Generic.List`1
    IL_0016:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_001b:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericListType
    IL_0020:  ldarg.0
    IL_0021:  ldtoken    [mscorlib]System.Collections.Generic.IList`1
    IL_0026:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_002b:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericIListType
    IL_0030:  ldarg.0
    IL_0031:  ldtoken    Avro.Specific.ObjectCreator/CtorDelegate
    IL_0036:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_003b:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::ctorType
    IL_0040:  ldarg.0
    IL_0041:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0046:  ldarg.0
    IL_0047:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::GetExecutingAssembly()
    IL_004c:  stfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::execAssembly
    IL_0051:  ldarg.0
    IL_0052:  call       class [mscorlib]System.Reflection.Assembly [mscorlib]System.Reflection.Assembly::GetEntryAssembly()
    IL_0057:  stfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::entryAssembly
    IL_005c:  ldarg.0
    IL_005d:  ldfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::entryAssembly
    IL_0062:  ldnull
    IL_0063:  call       bool [mscorlib]System.Reflection.Assembly::op_Inequality(class [mscorlib]System.Reflection.Assembly,
                                                                                  class [mscorlib]System.Reflection.Assembly)
    IL_0068:  brfalse.s  IL_0084

    IL_006a:  ldarg.0
    IL_006b:  ldfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::execAssembly
    IL_0070:  ldarg.0
    IL_0071:  ldfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::entryAssembly
    IL_0076:  call       bool [mscorlib]System.Reflection.Assembly::op_Inequality(class [mscorlib]System.Reflection.Assembly,
                                                                                  class [mscorlib]System.Reflection.Assembly)
    IL_007b:  brfalse.s  IL_0084

    IL_007d:  ldarg.0
    IL_007e:  ldc.i4.1
    IL_007f:  stfld      bool Avro.Specific.ObjectCreator::diffAssembly
    IL_0084:  ldarg.0
    IL_0085:  ldtoken    [mscorlib]System.Collections.Generic.Dictionary`2
    IL_008a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_008f:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericMapType
    IL_0094:  ldarg.0
    IL_0095:  ldtoken    [mscorlib]System.Collections.Generic.List`1
    IL_009a:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_009f:  stfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericListType
    IL_00a4:  ldarg.0
    IL_00a5:  ldc.i4.2
    IL_00a6:  newarr     [mscorlib]System.Type
    IL_00ab:  stloc.0
    IL_00ac:  ldloc.0
    IL_00ad:  ldc.i4.0
    IL_00ae:  ldtoken    [mscorlib]System.String
    IL_00b3:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_00b8:  stelem.ref
    IL_00b9:  ldloc.0
    IL_00ba:  stfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::margs
    IL_00bf:  ldarg.0
    IL_00c0:  ldc.i4.1
    IL_00c1:  newarr     [mscorlib]System.Type
    IL_00c6:  stloc.1
    IL_00c7:  ldloc.1
    IL_00c8:  stfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::largs
    IL_00cd:  ldarg.0
    IL_00ce:  newobj     instance void class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate>::.ctor()
    IL_00d3:  stfld      class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate> Avro.Specific.ObjectCreator::ctors
    IL_00d8:  ret
  } // end of method ObjectCreator::.ctor

  .method public hidebysig instance class [mscorlib]System.Type 
          GetType(string name,
                  valuetype Avro.Schema/Type schemaType) cil managed
  {
    // Code size       462 (0x1ce)
    .maxstack  4
    .locals init (class [mscorlib]System.Type V_0,
             string V_1,
             class [mscorlib]System.Type[] V_2,
             int32 V_3,
             class [mscorlib]System.Reflection.Assembly[] V_4,
             class [mscorlib]System.Reflection.Assembly V_5,
             class [mscorlib]System.Type V_6,
             class [mscorlib]System.Reflection.Assembly[] V_7,
             int32 V_8,
             class [mscorlib]System.Type[] V_9,
             int32 V_10)
    IL_0000:  ldstr      "System.Collections.Generic.IList`1"
    IL_0005:  stloc.1
    IL_0006:  ldarg.1
    IL_0007:  ldstr      "Nullable"
    IL_000c:  ldstr      "Nullable`1"
    IL_0011:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                          string)
    IL_0016:  starg.s    name
    IL_0018:  ldarg.1
    IL_0019:  ldstr      "IList"
    IL_001e:  ldloc.1
    IL_001f:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                          string)
    IL_0024:  starg.s    name
    IL_0026:  ldarg.1
    IL_0027:  ldstr      "<"
    IL_002c:  ldstr      "["
    IL_0031:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                          string)
    IL_0036:  starg.s    name
    IL_0038:  ldarg.1
    IL_0039:  ldstr      ">"
    IL_003e:  ldstr      "]"
    IL_0043:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                          string)
    IL_0048:  starg.s    name
    IL_004a:  ldarg.1
    IL_004b:  ldstr      "@"
    IL_0050:  ldsfld     string [mscorlib]System.String::Empty
    IL_0055:  callvirt   instance string [mscorlib]System.String::Replace(string,
                                                                          string)
    IL_005a:  starg.s    name
    IL_005c:  ldarg.0
    IL_005d:  ldfld      bool Avro.Specific.ObjectCreator::diffAssembly
    IL_0062:  brfalse.s  IL_0083

    IL_0064:  ldarg.0
    IL_0065:  ldfld      class [mscorlib]System.Reflection.Assembly Avro.Specific.ObjectCreator::entryAssembly
    IL_006a:  ldarg.1
    IL_006b:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Reflection.Assembly::GetType(string)
    IL_0070:  stloc.0
    IL_0071:  ldloc.0
    IL_0072:  ldnull
    IL_0073:  call       bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type,
                                                                 class [mscorlib]System.Type)
    IL_0078:  brfalse.s  IL_008a

    IL_007a:  ldarg.1
    IL_007b:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetType(string)
    IL_0080:  stloc.0
    IL_0081:  br.s       IL_008a

    IL_0083:  ldarg.1
    IL_0084:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetType(string)
    IL_0089:  stloc.0
    IL_008a:  ldc.i4.0
    IL_008b:  stloc.3
    IL_008c:  ldloc.0
    IL_008d:  ldnull
    IL_008e:  call       bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type,
                                                                 class [mscorlib]System.Type)
    IL_0093:  brfalse    IL_0167

    IL_0098:  br.s       IL_00bd

    IL_009a:  ldarg.1
    IL_009b:  ldloc.1
    IL_009c:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_00a1:  ldc.i4.1
    IL_00a2:  add
    IL_00a3:  ldarg.1
    IL_00a4:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_00a9:  ldloc.1
    IL_00aa:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_00af:  sub
    IL_00b0:  ldc.i4.2
    IL_00b1:  sub
    IL_00b2:  callvirt   instance string [mscorlib]System.String::Substring(int32,
                                                                            int32)
    IL_00b7:  starg.s    name
    IL_00b9:  ldloc.3
    IL_00ba:  ldc.i4.1
    IL_00bb:  add
    IL_00bc:  stloc.3
    IL_00bd:  ldarg.1
    IL_00be:  ldloc.1
    IL_00bf:  callvirt   instance bool [mscorlib]System.String::StartsWith(string)
    IL_00c4:  brtrue.s   IL_009a

    IL_00c6:  call       class [mscorlib]System.AppDomain [mscorlib]System.AppDomain::get_CurrentDomain()
    IL_00cb:  callvirt   instance class [mscorlib]System.Reflection.Assembly[] [mscorlib]System.AppDomain::GetAssemblies()
    IL_00d0:  stloc.s    V_4
    IL_00d2:  ldloc.s    V_4
    IL_00d4:  stloc.s    V_7
    IL_00d6:  ldc.i4.0
    IL_00d7:  stloc.s    V_8
    IL_00d9:  br.s       IL_013e

    IL_00db:  ldloc.s    V_7
    IL_00dd:  ldloc.s    V_8
    IL_00df:  ldelem.ref
    IL_00e0:  stloc.s    V_5
    .try
    {
      IL_00e2:  ldloc.s    V_5
      IL_00e4:  callvirt   instance class [mscorlib]System.Type[] [mscorlib]System.Reflection.Assembly::GetExportedTypes()
      IL_00e9:  stloc.2
      IL_00ea:  leave.s    IL_00ef

    }  // end .try
    catch [mscorlib]System.Object 
    {
      IL_00ec:  pop
      IL_00ed:  leave.s    IL_0138

    }  // end handler
    IL_00ef:  ldloc.2
    IL_00f0:  stloc.s    V_9
    IL_00f2:  ldc.i4.0
    IL_00f3:  stloc.s    V_10
    IL_00f5:  br.s       IL_0127

    IL_00f7:  ldloc.s    V_9
    IL_00f9:  ldloc.s    V_10
    IL_00fb:  ldelem.ref
    IL_00fc:  stloc.s    V_6
    IL_00fe:  ldarg.1
    IL_00ff:  ldloc.s    V_6
    IL_0101:  callvirt   instance string [mscorlib]System.Reflection.MemberInfo::get_Name()
    IL_0106:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_010b:  brtrue.s   IL_011c

    IL_010d:  ldarg.1
    IL_010e:  ldloc.s    V_6
    IL_0110:  callvirt   instance string [mscorlib]System.Type::get_FullName()
    IL_0115:  call       bool [mscorlib]System.String::op_Equality(string,
                                                                   string)
    IL_011a:  brfalse.s  IL_0121

    IL_011c:  ldloc.s    V_6
    IL_011e:  stloc.0
    IL_011f:  br.s       IL_012f

    IL_0121:  ldloc.s    V_10
    IL_0123:  ldc.i4.1
    IL_0124:  add
    IL_0125:  stloc.s    V_10
    IL_0127:  ldloc.s    V_10
    IL_0129:  ldloc.s    V_9
    IL_012b:  ldlen
    IL_012c:  conv.i4
    IL_012d:  blt.s      IL_00f7

    IL_012f:  ldloc.0
    IL_0130:  ldnull
    IL_0131:  call       bool [mscorlib]System.Type::op_Inequality(class [mscorlib]System.Type,
                                                                   class [mscorlib]System.Type)
    IL_0136:  brtrue.s   IL_0167

    IL_0138:  ldloc.s    V_8
    IL_013a:  ldc.i4.1
    IL_013b:  add
    IL_013c:  stloc.s    V_8
    IL_013e:  ldloc.s    V_8
    IL_0140:  ldloc.s    V_7
    IL_0142:  ldlen
    IL_0143:  conv.i4
    IL_0144:  blt.s      IL_00db

    IL_0146:  br.s       IL_0167

    IL_0148:  ldarg.0
    IL_0149:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::largs
    IL_014e:  ldc.i4.0
    IL_014f:  ldloc.0
    IL_0150:  stelem.ref
    IL_0151:  ldarg.0
    IL_0152:  ldfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericIListType
    IL_0157:  ldarg.0
    IL_0158:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::largs
    IL_015d:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeGenericType(class [mscorlib]System.Type[])
    IL_0162:  stloc.0
    IL_0163:  ldloc.3
    IL_0164:  ldc.i4.1
    IL_0165:  sub
    IL_0166:  stloc.3
    IL_0167:  ldloc.3
    IL_0168:  ldc.i4.0
    IL_0169:  bgt.s      IL_0148

    IL_016b:  ldloc.0
    IL_016c:  ldnull
    IL_016d:  call       bool [mscorlib]System.Type::op_Equality(class [mscorlib]System.Type,
                                                                 class [mscorlib]System.Type)
    IL_0172:  brfalse.s  IL_018a

    IL_0174:  ldstr      "Unable to find type "
    IL_0179:  ldarg.1
    IL_017a:  ldstr      " in all loaded assemblies"
    IL_017f:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0184:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0189:  throw

    IL_018a:  ldarg.2
    IL_018b:  ldc.i4.s   11
    IL_018d:  bne.un.s   IL_01ac

    IL_018f:  ldarg.0
    IL_0190:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::margs
    IL_0195:  ldc.i4.1
    IL_0196:  ldloc.0
    IL_0197:  stelem.ref
    IL_0198:  ldarg.0
    IL_0199:  ldfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericMapType
    IL_019e:  ldarg.0
    IL_019f:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::margs
    IL_01a4:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeGenericType(class [mscorlib]System.Type[])
    IL_01a9:  stloc.0
    IL_01aa:  br.s       IL_01cc

    IL_01ac:  ldarg.2
    IL_01ad:  ldc.i4.s   10
    IL_01af:  bne.un.s   IL_01cc

    IL_01b1:  ldarg.0
    IL_01b2:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::largs
    IL_01b7:  ldc.i4.0
    IL_01b8:  ldloc.0
    IL_01b9:  stelem.ref
    IL_01ba:  ldarg.0
    IL_01bb:  ldfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::GenericListType
    IL_01c0:  ldarg.0
    IL_01c1:  ldfld      class [mscorlib]System.Type[] Avro.Specific.ObjectCreator::largs
    IL_01c6:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Type::MakeGenericType(class [mscorlib]System.Type[])
    IL_01cb:  stloc.0
    IL_01cc:  ldloc.0
    IL_01cd:  ret
  } // end of method ObjectCreator::GetType

  .method public hidebysig instance class Avro.Specific.ObjectCreator/CtorDelegate 
          GetConstructor(string name,
                         valuetype Avro.Schema/Type schemaType,
                         class [mscorlib]System.Type 'type') cil managed
  {
    // Code size       132 (0x84)
    .maxstack  5
    .locals init (class [mscorlib]System.Reflection.ConstructorInfo V_0,
             class [mscorlib]System.Reflection.Emit.DynamicMethod V_1,
             class [mscorlib]System.Reflection.Emit.ILGenerator V_2)
    IL_0000:  ldarg.3
    IL_0001:  ldsfld     class [mscorlib]System.Type[] [mscorlib]System.Type::EmptyTypes
    IL_0006:  callvirt   instance class [mscorlib]System.Reflection.ConstructorInfo [mscorlib]System.Type::GetConstructor(class [mscorlib]System.Type[])
    IL_000b:  stloc.0
    IL_000c:  ldloc.0
    IL_000d:  ldnull
    IL_000e:  call       bool [mscorlib]System.Reflection.ConstructorInfo::op_Equality(class [mscorlib]System.Reflection.ConstructorInfo,
                                                                                       class [mscorlib]System.Reflection.ConstructorInfo)
    IL_0013:  brfalse.s  IL_002b

    IL_0015:  ldstr      "Class "
    IL_001a:  ldarg.1
    IL_001b:  ldstr      " has no default constructor"
    IL_0020:  call       string [mscorlib]System.String::Concat(string,
                                                                string,
                                                                string)
    IL_0025:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_002a:  throw

    IL_002b:  ldstr      "DM$OBJ_FACTORY_"
    IL_0030:  ldarg.1
    IL_0031:  call       string [mscorlib]System.String::Concat(string,
                                                                string)
    IL_0036:  ldtoken    [mscorlib]System.Object
    IL_003b:  call       class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
    IL_0040:  ldnull
    IL_0041:  ldarg.3
    IL_0042:  ldc.i4.1
    IL_0043:  newobj     instance void [mscorlib]System.Reflection.Emit.DynamicMethod::.ctor(string,
                                                                                             class [mscorlib]System.Type,
                                                                                             class [mscorlib]System.Type[],
                                                                                             class [mscorlib]System.Type,
                                                                                             bool)
    IL_0048:  stloc.1
    IL_0049:  ldloc.1
    IL_004a:  callvirt   instance class [mscorlib]System.Reflection.Emit.ILGenerator [mscorlib]System.Reflection.Emit.DynamicMethod::GetILGenerator()
    IL_004f:  stloc.2
    IL_0050:  ldloc.2
    IL_0051:  ldsfld     valuetype [mscorlib]System.Reflection.Emit.OpCode [mscorlib]System.Reflection.Emit.OpCodes::Nop
    IL_0056:  callvirt   instance void [mscorlib]System.Reflection.Emit.ILGenerator::Emit(valuetype [mscorlib]System.Reflection.Emit.OpCode)
    IL_005b:  ldloc.2
    IL_005c:  ldsfld     valuetype [mscorlib]System.Reflection.Emit.OpCode [mscorlib]System.Reflection.Emit.OpCodes::Newobj
    IL_0061:  ldloc.0
    IL_0062:  callvirt   instance void [mscorlib]System.Reflection.Emit.ILGenerator::Emit(valuetype [mscorlib]System.Reflection.Emit.OpCode,
                                                                                          class [mscorlib]System.Reflection.ConstructorInfo)
    IL_0067:  ldloc.2
    IL_0068:  ldsfld     valuetype [mscorlib]System.Reflection.Emit.OpCode [mscorlib]System.Reflection.Emit.OpCodes::Ret
    IL_006d:  callvirt   instance void [mscorlib]System.Reflection.Emit.ILGenerator::Emit(valuetype [mscorlib]System.Reflection.Emit.OpCode)
    IL_0072:  ldloc.1
    IL_0073:  ldarg.0
    IL_0074:  ldfld      class [mscorlib]System.Type Avro.Specific.ObjectCreator::ctorType
    IL_0079:  callvirt   instance class [mscorlib]System.Delegate [mscorlib]System.Reflection.Emit.DynamicMethod::CreateDelegate(class [mscorlib]System.Type)
    IL_007e:  castclass  Avro.Specific.ObjectCreator/CtorDelegate
    IL_0083:  ret
  } // end of method ObjectCreator::GetConstructor

  .method public hidebysig instance object 
          New(string name,
              valuetype Avro.Schema/Type schemaType) cil managed
  {
    // Code size       65 (0x41)
    .maxstack  4
    .locals init (valuetype Avro.Specific.ObjectCreator/NameCtorKey V_0,
             class Avro.Specific.ObjectCreator/CtorDelegate V_1,
             class [mscorlib]System.Type V_2)
    IL_0000:  ldloca.s   V_0
    IL_0002:  ldarg.1
    IL_0003:  ldarg.2
    IL_0004:  call       instance void Avro.Specific.ObjectCreator/NameCtorKey::.ctor(string,
                                                                                      valuetype Avro.Schema/Type)
    IL_0009:  ldarg.0
    IL_000a:  ldfld      class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate> Avro.Specific.ObjectCreator::ctors
    IL_000f:  ldloc.0
    IL_0010:  ldloca.s   V_1
    IL_0012:  callvirt   instance bool class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate>::TryGetValue(!0,
                                                                                                                                                                                                                           !1&)
    IL_0017:  brtrue.s   IL_003a

    IL_0019:  ldarg.0
    IL_001a:  ldarg.1
    IL_001b:  ldarg.2
    IL_001c:  call       instance class [mscorlib]System.Type Avro.Specific.ObjectCreator::GetType(string,
                                                                                                   valuetype Avro.Schema/Type)
    IL_0021:  stloc.2
    IL_0022:  ldarg.0
    IL_0023:  ldarg.1
    IL_0024:  ldarg.2
    IL_0025:  ldloc.2
    IL_0026:  call       instance class Avro.Specific.ObjectCreator/CtorDelegate Avro.Specific.ObjectCreator::GetConstructor(string,
                                                                                                                             valuetype Avro.Schema/Type,
                                                                                                                             class [mscorlib]System.Type)
    IL_002b:  stloc.1
    IL_002c:  ldarg.0
    IL_002d:  ldfld      class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate> Avro.Specific.ObjectCreator::ctors
    IL_0032:  ldloc.0
    IL_0033:  ldloc.1
    IL_0034:  callvirt   instance bool class [mscorlib]System.Collections.Concurrent.ConcurrentDictionary`2<valuetype Avro.Specific.ObjectCreator/NameCtorKey,class Avro.Specific.ObjectCreator/CtorDelegate>::TryAdd(!0,
                                                                                                                                                                                                                      !1)
    IL_0039:  pop
    IL_003a:  ldloc.1
    IL_003b:  callvirt   instance object Avro.Specific.ObjectCreator/CtorDelegate::Invoke()
    IL_0040:  ret
  } // end of method ObjectCreator::New

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void Avro.Specific.ObjectCreator::.ctor()
    IL_0005:  stsfld     class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::'instance'
    IL_000a:  ret
  } // end of method ObjectCreator::.cctor

  .property class Avro.Specific.ObjectCreator
          Instance()
  {
    .get class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::get_Instance()
  } // end of property ObjectCreator::Instance
} // end of class Avro.Specific.ObjectCreator

.class public abstract auto ansi beforefieldinit Avro.Specific.SpecificFixed
       extends Avro.Generic.GenericFixed
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(uint32 size) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.Generic.GenericFixed::.ctor(uint32)
    IL_0007:  ret
  } // end of method SpecificFixed::.ctor

  .method public hidebysig newslot specialname abstract virtual 
          instance class Avro.Schema  get_Schema() cil managed
  {
  } // end of method SpecificFixed::get_Schema

  .property instance class Avro.Schema Schema()
  {
    .get instance class Avro.Schema Avro.Specific.SpecificFixed::get_Schema()
  } // end of property SpecificFixed::Schema
} // end of class Avro.Specific.SpecificFixed

.class public auto ansi beforefieldinit Avro.Specific.SpecificReader`1<T>
       extends [mscorlib]System.Object
       implements class Avro.Generic.DatumReader`1<!T>
{
  .field private initonly class Avro.Specific.SpecificDefaultReader reader
  .method public hidebysig newslot specialname virtual final 
          instance class Avro.Schema  get_WriterSchema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Specific.SpecificDefaultReader class Avro.Specific.SpecificReader`1<!T>::reader
    IL_0006:  callvirt   instance class Avro.Schema Avro.Generic.DefaultReader::get_WriterSchema()
    IL_000b:  ret
  } // end of method SpecificReader`1::get_WriterSchema

  .method public hidebysig newslot specialname virtual final 
          instance class Avro.Schema  get_ReaderSchema() cil managed
  {
    // Code size       12 (0xc)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Specific.SpecificDefaultReader class Avro.Specific.SpecificReader`1<!T>::reader
    IL_0006:  callvirt   instance class Avro.Schema Avro.Generic.DefaultReader::get_ReaderSchema()
    IL_000b:  ret
  } // end of method SpecificReader`1::get_ReaderSchema

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema writerSchema,
                               class Avro.Schema readerSchema) cil managed
  {
    // Code size       20 (0x14)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  ldarg.2
    IL_0009:  newobj     instance void Avro.Specific.SpecificDefaultReader::.ctor(class Avro.Schema,
                                                                                  class Avro.Schema)
    IL_000e:  stfld      class Avro.Specific.SpecificDefaultReader class Avro.Specific.SpecificReader`1<!T>::reader
    IL_0013:  ret
  } // end of method SpecificReader`1::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Specific.SpecificDefaultReader reader) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
    IL_0006:  ldarg.0
    IL_0007:  ldarg.1
    IL_0008:  stfld      class Avro.Specific.SpecificDefaultReader class Avro.Specific.SpecificReader`1<!T>::reader
    IL_000d:  ret
  } // end of method SpecificReader`1::.ctor

  .method public hidebysig newslot virtual final 
          instance !T  Read(!T reuse,
                            class Avro.IO.Decoder dec) cil managed
  {
    // Code size       14 (0xe)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldfld      class Avro.Specific.SpecificDefaultReader class Avro.Specific.SpecificReader`1<!T>::reader
    IL_0006:  ldarg.1
    IL_0007:  ldarg.2
    IL_0008:  callvirt   instance !!0 Avro.Generic.DefaultReader::Read<!T>(!!0,
                                                                           class Avro.IO.Decoder)
    IL_000d:  ret
  } // end of method SpecificReader`1::Read

  .property instance class Avro.Schema WriterSchema()
  {
    .get instance class Avro.Schema Avro.Specific.SpecificReader`1::get_WriterSchema()
  } // end of property SpecificReader`1::WriterSchema
  .property instance class Avro.Schema ReaderSchema()
  {
    .get instance class Avro.Schema Avro.Specific.SpecificReader`1::get_ReaderSchema()
  } // end of property SpecificReader`1::ReaderSchema
} // end of class Avro.Specific.SpecificReader`1

.class public auto ansi beforefieldinit Avro.Specific.SpecificDefaultReader
       extends Avro.Generic.DefaultReader
{
  .field private static class [mscorlib]System.Collections.Generic.IDictionary`2<string,class [mscorlib]System.Type> TypeName
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema writerSchema,
                               class Avro.Schema readerSchema) cil managed
  {
    // Code size       9 (0x9)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  ldarg.2
    IL_0003:  call       instance void Avro.Generic.DefaultReader::.ctor(class Avro.Schema,
                                                                         class Avro.Schema)
    IL_0008:  ret
  } // end of method SpecificDefaultReader::.ctor

  .method family hidebysig virtual instance object 
          ReadRecord(object reuse,
                     class Avro.RecordSchema writerSchema,
                     class Avro.Schema readerSchema,
                     class Avro.IO.Decoder dec) cil managed
  {
    // Code size       377 (0x179)
    .maxstack  7
    .locals init (class Avro.RecordSchema V_0,
             class Avro.Specific.ISpecificRecord V_1,
             object V_2,
             class Avro.Field V_3,
             class Avro.Field V_4,
             class [mscorlib]System.Exception V_5,
             class [mscorlib]System.IO.MemoryStream V_6,
             class Avro.IO.BinaryEncoder V_7,
             class Avro.IO.BinaryDecoder V_8,
             class Avro.Field V_9,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_10,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_11)
    IL_0000:  ldarg.3
    IL_0001:  castclass  Avro.RecordSchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.1
    IL_0008:  brtrue.s   IL_001d

    IL_000a:  call       class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::get_Instance()
    IL_000f:  ldloc.0
    IL_0010:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_0015:  ldc.i4.8
    IL_0016:  callvirt   instance object Avro.Specific.ObjectCreator::New(string,
                                                                          valuetype Avro.Schema/Type)
    IL_001b:  br.s       IL_001e

    IL_001d:  ldarg.1
    IL_001e:  isinst     Avro.Specific.ISpecificRecord
    IL_0023:  stloc.1
    IL_0024:  ldarg.2
    IL_0025:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_002a:  stloc.s    V_10
    .try
    {
      IL_002c:  br.s       IL_00a8

      IL_002e:  ldloc.s    V_10
      IL_0030:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_0035:  stloc.3
      .try
      {
        IL_0036:  ldloc.0
        IL_0037:  ldloc.3
        IL_0038:  ldfld      string Avro.Field::Name
        IL_003d:  ldloca.s   V_4
        IL_003f:  callvirt   instance bool Avro.RecordSchema::TryGetField(string,
                                                                          class Avro.Field&)
        IL_0044:  brfalse.s  IL_0079

        IL_0046:  ldloc.1
        IL_0047:  ldloc.s    V_4
        IL_0049:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_004e:  callvirt   instance object Avro.Specific.ISpecificRecord::Get(int32)
        IL_0053:  stloc.2
        IL_0054:  ldloc.1
        IL_0055:  ldloc.s    V_4
        IL_0057:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_005c:  ldarg.0
        IL_005d:  ldloc.2
        IL_005e:  ldloc.3
        IL_005f:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_0064:  ldloc.s    V_4
        IL_0066:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_006b:  ldarg.s    dec
        IL_006d:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                              class Avro.Schema,
                                                                              class Avro.Schema,
                                                                              class Avro.IO.Decoder)
        IL_0072:  callvirt   instance void Avro.Specific.ISpecificRecord::Put(int32,
                                                                              object)
        IL_0077:  br.s       IL_0087

        IL_0079:  ldarg.0
        IL_007a:  ldloc.3
        IL_007b:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_0080:  ldarg.s    dec
        IL_0082:  callvirt   instance void Avro.Generic.DefaultReader::Skip(class Avro.Schema,
                                                                            class Avro.IO.Decoder)
        IL_0087:  leave.s    IL_00a8

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0089:  stloc.s    V_5
        IL_008b:  ldloc.s    V_5
        IL_008d:  callvirt   instance string [mscorlib]System.Exception::get_Message()
        IL_0092:  ldstr      " in field "
        IL_0097:  ldloc.3
        IL_0098:  ldfld      string Avro.Field::Name
        IL_009d:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_00a2:  newobj     instance void Avro.AvroException::.ctor(string)
        IL_00a7:  throw

      }  // end handler
      IL_00a8:  ldloc.s    V_10
      IL_00aa:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_00af:  brtrue     IL_002e

      IL_00b4:  leave.s    IL_00c2

    }  // end .try
    finally
    {
      IL_00b6:  ldloc.s    V_10
      IL_00b8:  brfalse.s  IL_00c1

      IL_00ba:  ldloc.s    V_10
      IL_00bc:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_00c1:  endfinally
    }  // end handler
    IL_00c2:  newobj     instance void [mscorlib]System.IO.MemoryStream::.ctor()
    IL_00c7:  stloc.s    V_6
    IL_00c9:  ldloc.s    V_6
    IL_00cb:  newobj     instance void Avro.IO.BinaryEncoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_00d0:  stloc.s    V_7
    IL_00d2:  ldloc.s    V_6
    IL_00d4:  newobj     instance void Avro.IO.BinaryDecoder::.ctor(class [mscorlib]System.IO.Stream)
    IL_00d9:  stloc.s    V_8
    IL_00db:  ldloc.0
    IL_00dc:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_00e1:  stloc.s    V_11
    .try
    {
      IL_00e3:  br.s       IL_015d

      IL_00e5:  ldloc.s    V_11
      IL_00e7:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_00ec:  stloc.s    V_9
      IL_00ee:  ldarg.2
      IL_00ef:  ldloc.s    V_9
      IL_00f1:  ldfld      string Avro.Field::Name
      IL_00f6:  callvirt   instance bool Avro.RecordSchema::Contains(string)
      IL_00fb:  brtrue.s   IL_015d

      IL_00fd:  ldloc.s    V_6
      IL_00ff:  ldc.i4.0
      IL_0100:  conv.i8
      IL_0101:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_0106:  ldloc.s    V_7
      IL_0108:  ldloc.s    V_9
      IL_010a:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_010f:  ldloc.s    V_9
      IL_0111:  callvirt   instance class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken Avro.Field::get_DefaultValue()
      IL_0116:  call       void Avro.IO.Resolver::EncodeDefaultValue(class Avro.IO.Encoder,
                                                                     class Avro.Schema,
                                                                     class [Newtonsoft.Json]Newtonsoft.Json.Linq.JToken)
      IL_011b:  ldloc.s    V_6
      IL_011d:  callvirt   instance void [mscorlib]System.IO.Stream::Flush()
      IL_0122:  ldloc.s    V_6
      IL_0124:  ldc.i4.0
      IL_0125:  conv.i8
      IL_0126:  callvirt   instance void [mscorlib]System.IO.Stream::set_Position(int64)
      IL_012b:  ldloc.1
      IL_012c:  ldloc.s    V_9
      IL_012e:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_0133:  callvirt   instance object Avro.Specific.ISpecificRecord::Get(int32)
      IL_0138:  stloc.2
      IL_0139:  ldloc.1
      IL_013a:  ldloc.s    V_9
      IL_013c:  callvirt   instance int32 Avro.Field::get_Pos()
      IL_0141:  ldarg.0
      IL_0142:  ldloc.2
      IL_0143:  ldloc.s    V_9
      IL_0145:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_014a:  ldloc.s    V_9
      IL_014c:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
      IL_0151:  ldloc.s    V_8
      IL_0153:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                            class Avro.Schema,
                                                                            class Avro.Schema,
                                                                            class Avro.IO.Decoder)
      IL_0158:  callvirt   instance void Avro.Specific.ISpecificRecord::Put(int32,
                                                                            object)
      IL_015d:  ldloc.s    V_11
      IL_015f:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0164:  brtrue     IL_00e5

      IL_0169:  leave.s    IL_0177

    }  // end .try
    finally
    {
      IL_016b:  ldloc.s    V_11
      IL_016d:  brfalse.s  IL_0176

      IL_016f:  ldloc.s    V_11
      IL_0171:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0176:  endfinally
    }  // end handler
    IL_0177:  ldloc.1
    IL_0178:  ret
  } // end of method SpecificDefaultReader::ReadRecord

  .method family hidebysig virtual instance object 
          ReadFixed(object reuse,
                    class Avro.FixedSchema writerSchema,
                    class Avro.Schema readerSchema,
                    class Avro.IO.Decoder d) cil managed
  {
    // Code size       109 (0x6d)
    .maxstack  3
    .locals init (class Avro.FixedSchema V_0,
             class Avro.Specific.SpecificFixed V_1,
             object[] V_2)
    IL_0000:  ldarg.3
    IL_0001:  isinst     Avro.FixedSchema
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_000d:  ldarg.2
    IL_000e:  callvirt   instance int32 Avro.FixedSchema::get_Size()
    IL_0013:  beq.s      IL_0040

    IL_0015:  ldc.i4.4
    IL_0016:  newarr     [mscorlib]System.Object
    IL_001b:  stloc.2
    IL_001c:  ldloc.2
    IL_001d:  ldc.i4.0
    IL_001e:  ldstr      "Size mismatch between reader and writer fixed sche"
    + "mas. Writer: "
    IL_0023:  stelem.ref
    IL_0024:  ldloc.2
    IL_0025:  ldc.i4.1
    IL_0026:  ldarg.2
    IL_0027:  stelem.ref
    IL_0028:  ldloc.2
    IL_0029:  ldc.i4.2
    IL_002a:  ldstr      ", reader: "
    IL_002f:  stelem.ref
    IL_0030:  ldloc.2
    IL_0031:  ldc.i4.3
    IL_0032:  ldarg.3
    IL_0033:  stelem.ref
    IL_0034:  ldloc.2
    IL_0035:  call       string [mscorlib]System.String::Concat(object[])
    IL_003a:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_003f:  throw

    IL_0040:  ldarg.1
    IL_0041:  brtrue.s   IL_0057

    IL_0043:  call       class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::get_Instance()
    IL_0048:  ldloc.0
    IL_0049:  callvirt   instance string Avro.NamedSchema::get_Fullname()
    IL_004e:  ldc.i4.s   13
    IL_0050:  callvirt   instance object Avro.Specific.ObjectCreator::New(string,
                                                                          valuetype Avro.Schema/Type)
    IL_0055:  br.s       IL_0058

    IL_0057:  ldarg.1
    IL_0058:  isinst     Avro.Specific.SpecificFixed
    IL_005d:  stloc.1
    IL_005e:  ldarg.s    d
    IL_0060:  ldloc.1
    IL_0061:  callvirt   instance uint8[] Avro.Generic.GenericFixed::get_Value()
    IL_0066:  callvirt   instance void Avro.IO.Decoder::ReadFixed(uint8[])
    IL_006b:  ldloc.1
    IL_006c:  ret
  } // end of method SpecificDefaultReader::ReadFixed

  .method family hidebysig virtual instance object 
          ReadEnum(object reuse,
                   class Avro.EnumSchema writerSchema,
                   class Avro.Schema readerSchema,
                   class Avro.IO.Decoder dec) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.s    dec
    IL_0002:  callvirt   instance int32 Avro.IO.Decoder::ReadEnum()
    IL_0007:  box        [mscorlib]System.Int32
    IL_000c:  ret
  } // end of method SpecificDefaultReader::ReadEnum

  .method family hidebysig virtual instance object 
          ReadArray(object reuse,
                    class Avro.ArraySchema writerSchema,
                    class Avro.Schema readerSchema,
                    class Avro.IO.Decoder dec) cil managed
  {
    // Code size       139 (0x8b)
    .maxstack  6
    .locals init (class Avro.ArraySchema V_0,
             class [mscorlib]System.Collections.IList V_1,
             int32 V_2,
             int32 V_3,
             int32 V_4)
    IL_0000:  ldarg.3
    IL_0001:  isinst     Avro.ArraySchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.1
    IL_0008:  brfalse.s  IL_0027

    IL_000a:  ldarg.1
    IL_000b:  isinst     [mscorlib]System.Collections.IList
    IL_0010:  stloc.1
    IL_0011:  ldloc.1
    IL_0012:  brtrue.s   IL_001f

    IL_0014:  ldstr      "array object does not implement non-generic IList"
    IL_0019:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001e:  throw

    IL_001f:  ldloc.1
    IL_0020:  callvirt   instance void [mscorlib]System.Collections.IList::Clear()
    IL_0025:  br.s       IL_0040

    IL_0027:  call       class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::get_Instance()
    IL_002c:  ldarg.0
    IL_002d:  ldarg.3
    IL_002e:  callvirt   instance string Avro.Specific.SpecificDefaultReader::getTargetType(class Avro.Schema)
    IL_0033:  ldc.i4.s   10
    IL_0035:  callvirt   instance object Avro.Specific.ObjectCreator::New(string,
                                                                          valuetype Avro.Schema/Type)
    IL_003a:  isinst     [mscorlib]System.Collections.IList
    IL_003f:  stloc.1
    IL_0040:  ldc.i4.0
    IL_0041:  stloc.2
    IL_0042:  ldarg.s    dec
    IL_0044:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayStart()
    IL_0049:  conv.i4
    IL_004a:  stloc.3
    IL_004b:  br.s       IL_0086

    IL_004d:  ldc.i4.0
    IL_004e:  stloc.s    V_4
    IL_0050:  br.s       IL_0078

    IL_0052:  ldloc.1
    IL_0053:  ldarg.0
    IL_0054:  ldnull
    IL_0055:  ldarg.2
    IL_0056:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_005b:  ldloc.0
    IL_005c:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_0061:  ldarg.s    dec
    IL_0063:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0068:  callvirt   instance int32 [mscorlib]System.Collections.IList::Add(object)
    IL_006d:  pop
    IL_006e:  ldloc.s    V_4
    IL_0070:  ldc.i4.1
    IL_0071:  add
    IL_0072:  stloc.s    V_4
    IL_0074:  ldloc.2
    IL_0075:  ldc.i4.1
    IL_0076:  add
    IL_0077:  stloc.2
    IL_0078:  ldloc.s    V_4
    IL_007a:  ldloc.3
    IL_007b:  blt.s      IL_0052

    IL_007d:  ldarg.s    dec
    IL_007f:  callvirt   instance int64 Avro.IO.Decoder::ReadArrayNext()
    IL_0084:  conv.i4
    IL_0085:  stloc.3
    IL_0086:  ldloc.3
    IL_0087:  brtrue.s   IL_004d

    IL_0089:  ldloc.1
    IL_008a:  ret
  } // end of method SpecificDefaultReader::ReadArray

  .method family hidebysig virtual instance object 
          ReadMap(object reuse,
                  class Avro.MapSchema writerSchema,
                  class Avro.Schema readerSchema,
                  class Avro.IO.Decoder d) cil managed
  {
    // Code size       139 (0x8b)
    .maxstack  7
    .locals init (class Avro.MapSchema V_0,
             class [mscorlib]System.Collections.IDictionary V_1,
             int32 V_2,
             int32 V_3,
             string V_4)
    IL_0000:  ldarg.3
    IL_0001:  isinst     Avro.MapSchema
    IL_0006:  stloc.0
    IL_0007:  ldarg.1
    IL_0008:  brfalse.s  IL_0027

    IL_000a:  ldarg.1
    IL_000b:  isinst     [mscorlib]System.Collections.IDictionary
    IL_0010:  stloc.1
    IL_0011:  ldloc.1
    IL_0012:  brtrue.s   IL_001f

    IL_0014:  ldstr      "map object does not implement non-generic IList"
    IL_0019:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_001e:  throw

    IL_001f:  ldloc.1
    IL_0020:  callvirt   instance void [mscorlib]System.Collections.IDictionary::Clear()
    IL_0025:  br.s       IL_0040

    IL_0027:  call       class Avro.Specific.ObjectCreator Avro.Specific.ObjectCreator::get_Instance()
    IL_002c:  ldarg.0
    IL_002d:  ldarg.3
    IL_002e:  callvirt   instance string Avro.Specific.SpecificDefaultReader::getTargetType(class Avro.Schema)
    IL_0033:  ldc.i4.s   11
    IL_0035:  callvirt   instance object Avro.Specific.ObjectCreator::New(string,
                                                                          valuetype Avro.Schema/Type)
    IL_003a:  isinst     [mscorlib]System.Collections.IDictionary
    IL_003f:  stloc.1
    IL_0040:  ldarg.s    d
    IL_0042:  callvirt   instance int64 Avro.IO.Decoder::ReadMapStart()
    IL_0047:  conv.i4
    IL_0048:  stloc.2
    IL_0049:  br.s       IL_0086

    IL_004b:  ldc.i4.0
    IL_004c:  stloc.3
    IL_004d:  br.s       IL_0079

    IL_004f:  ldarg.s    d
    IL_0051:  callvirt   instance string Avro.IO.Decoder::ReadString()
    IL_0056:  stloc.s    V_4
    IL_0058:  ldloc.1
    IL_0059:  ldloc.s    V_4
    IL_005b:  ldarg.0
    IL_005c:  ldnull
    IL_005d:  ldarg.2
    IL_005e:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0063:  ldloc.0
    IL_0064:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
    IL_0069:  ldarg.s    d
    IL_006b:  call       instance object Avro.Generic.DefaultReader::Read(object,
                                                                          class Avro.Schema,
                                                                          class Avro.Schema,
                                                                          class Avro.IO.Decoder)
    IL_0070:  callvirt   instance void [mscorlib]System.Collections.IDictionary::set_Item(object,
                                                                                          object)
    IL_0075:  ldloc.3
    IL_0076:  ldc.i4.1
    IL_0077:  add
    IL_0078:  stloc.3
    IL_0079:  ldloc.3
    IL_007a:  ldloc.2
    IL_007b:  blt.s      IL_004f

    IL_007d:  ldarg.s    d
    IL_007f:  callvirt   instance int64 Avro.IO.Decoder::ReadMapNext()
    IL_0084:  conv.i4
    IL_0085:  stloc.2
    IL_0086:  ldloc.2
    IL_0087:  brtrue.s   IL_004b

    IL_0089:  ldloc.1
    IL_008a:  ret
  } // end of method SpecificDefaultReader::ReadMap

  .method family hidebysig newslot virtual 
          instance string  getTargetType(class Avro.Schema schema) cil managed
  {
    // Code size       85 (0x55)
    .maxstack  3
    .locals init (bool V_0,
             string V_1)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  ldarg.1
    IL_0003:  ldc.i4.0
    IL_0004:  ldloca.s   V_0
    IL_0006:  call       string Avro.CodeGen::getType(class Avro.Schema,
                                                      bool,
                                                      bool&)
    IL_000b:  stloc.1
    IL_000c:  ldarg.1
    IL_000d:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0012:  ldc.i4.s   10
    IL_0014:  bne.un.s   IL_0030

    IL_0016:  ldloc.1
    IL_0017:  ldc.i4.0
    IL_0018:  ldc.i4.6
    IL_0019:  callvirt   instance string [mscorlib]System.String::Remove(int32,
                                                                         int32)
    IL_001e:  stloc.1
    IL_001f:  ldloc.1
    IL_0020:  ldloc.1
    IL_0021:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_0026:  ldc.i4.1
    IL_0027:  sub
    IL_0028:  callvirt   instance string [mscorlib]System.String::Remove(int32)
    IL_002d:  stloc.1
    IL_002e:  br.s       IL_0053

    IL_0030:  ldarg.1
    IL_0031:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0036:  ldc.i4.s   11
    IL_0038:  bne.un.s   IL_0053

    IL_003a:  ldloc.1
    IL_003b:  ldc.i4.0
    IL_003c:  ldc.i4.s   19
    IL_003e:  callvirt   instance string [mscorlib]System.String::Remove(int32,
                                                                         int32)
    IL_0043:  stloc.1
    IL_0044:  ldloc.1
    IL_0045:  ldloc.1
    IL_0046:  callvirt   instance int32 [mscorlib]System.String::get_Length()
    IL_004b:  ldc.i4.1
    IL_004c:  sub
    IL_004d:  callvirt   instance string [mscorlib]System.String::Remove(int32)
    IL_0052:  stloc.1
    IL_0053:  ldloc.1
    IL_0054:  ret
  } // end of method SpecificDefaultReader::getTargetType

  .method private hidebysig specialname rtspecialname static 
          void  .cctor() cil managed
  {
    // Code size       11 (0xb)
    .maxstack  8
    IL_0000:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,class [mscorlib]System.Type>::.ctor()
    IL_0005:  stsfld     class [mscorlib]System.Collections.Generic.IDictionary`2<string,class [mscorlib]System.Type> Avro.Specific.SpecificDefaultReader::TypeName
    IL_000a:  ret
  } // end of method SpecificDefaultReader::.cctor

} // end of class Avro.Specific.SpecificDefaultReader

.class public auto ansi beforefieldinit Avro.Specific.SpecificWriter`1<T>
       extends class Avro.Generic.GenericWriter`1<!T>
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema schema) cil managed
  {
    // Code size       13 (0xd)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  newobj     instance void Avro.Specific.SpecificDefaultWriter::.ctor(class Avro.Schema)
    IL_0007:  call       instance void class Avro.Generic.GenericWriter`1<!T>::.ctor(class Avro.Generic.DefaultWriter)
    IL_000c:  ret
  } // end of method SpecificWriter`1::.ctor

  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Specific.SpecificDefaultWriter writer) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void class Avro.Generic.GenericWriter`1<!T>::.ctor(class Avro.Generic.DefaultWriter)
    IL_0007:  ret
  } // end of method SpecificWriter`1::.ctor

} // end of class Avro.Specific.SpecificWriter`1

.class public auto ansi beforefieldinit Avro.Specific.SpecificDefaultWriter
       extends Avro.Generic.DefaultWriter
{
  .method public hidebysig specialname rtspecialname 
          instance void  .ctor(class Avro.Schema schema) cil managed
  {
    // Code size       8 (0x8)
    .maxstack  8
    IL_0000:  ldarg.0
    IL_0001:  ldarg.1
    IL_0002:  call       instance void Avro.Generic.DefaultWriter::.ctor(class Avro.Schema)
    IL_0007:  ret
  } // end of method SpecificDefaultWriter::.ctor

  .method family hidebysig virtual instance void 
          WriteRecord(class Avro.RecordSchema schema,
                      object 'value',
                      class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       114 (0x72)
    .maxstack  4
    .locals init (class Avro.Specific.ISpecificRecord V_0,
             class Avro.Field V_1,
             class [mscorlib]System.Exception V_2,
             class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> V_3)
    IL_0000:  ldarg.2
    IL_0001:  isinst     Avro.Specific.ISpecificRecord
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Record object is not derived from ISpecificRecord"
    IL_000f:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0014:  throw

    IL_0015:  ldarg.1
    IL_0016:  callvirt   instance class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field> Avro.RecordSchema::GetEnumerator()
    IL_001b:  stloc.3
    .try
    {
      IL_001c:  br.s       IL_005d

      IL_001e:  ldloc.3
      IL_001f:  callvirt   instance !0 class [mscorlib]System.Collections.Generic.IEnumerator`1<class Avro.Field>::get_Current()
      IL_0024:  stloc.1
      .try
      {
        IL_0025:  ldarg.0
        IL_0026:  ldloc.1
        IL_0027:  callvirt   instance class Avro.Schema Avro.Field::get_Schema()
        IL_002c:  ldloc.0
        IL_002d:  ldloc.1
        IL_002e:  callvirt   instance int32 Avro.Field::get_Pos()
        IL_0033:  callvirt   instance object Avro.Specific.ISpecificRecord::Get(int32)
        IL_0038:  ldarg.3
        IL_0039:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                             object,
                                                                             class Avro.IO.Encoder)
        IL_003e:  leave.s    IL_005d

      }  // end .try
      catch [mscorlib]System.Exception 
      {
        IL_0040:  stloc.2
        IL_0041:  ldloc.2
        IL_0042:  callvirt   instance string [mscorlib]System.Exception::get_Message()
        IL_0047:  ldstr      " in field "
        IL_004c:  ldloc.1
        IL_004d:  ldfld      string Avro.Field::Name
        IL_0052:  call       string [mscorlib]System.String::Concat(string,
                                                                    string,
                                                                    string)
        IL_0057:  newobj     instance void Avro.AvroException::.ctor(string)
        IL_005c:  throw

      }  // end handler
      IL_005d:  ldloc.3
      IL_005e:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_0063:  brtrue.s   IL_001e

      IL_0065:  leave.s    IL_0071

    }  // end .try
    finally
    {
      IL_0067:  ldloc.3
      IL_0068:  brfalse.s  IL_0070

      IL_006a:  ldloc.3
      IL_006b:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0070:  endfinally
    }  // end handler
    IL_0071:  ret
  } // end of method SpecificDefaultWriter::WriteRecord

  .method family hidebysig virtual instance void 
          WriteFixed(class Avro.FixedSchema schema,
                     object 'value',
                     class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       34 (0x22)
    .maxstack  2
    .locals init (class Avro.Specific.SpecificFixed V_0)
    IL_0000:  ldarg.2
    IL_0001:  isinst     Avro.Specific.SpecificFixed
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Fixed object is not derived from SpecificFixed"
    IL_000f:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0014:  throw

    IL_0015:  ldarg.3
    IL_0016:  ldloc.0
    IL_0017:  callvirt   instance uint8[] Avro.Generic.GenericFixed::get_Value()
    IL_001c:  callvirt   instance void Avro.IO.Encoder::WriteFixed(uint8[])
    IL_0021:  ret
  } // end of method SpecificDefaultWriter::WriteFixed

  .method family hidebysig virtual instance void 
          WriteEnum(class Avro.EnumSchema schema,
                    object 'value',
                    class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       33 (0x21)
    .maxstack  8
    IL_0000:  ldarg.2
    IL_0001:  brtrue.s   IL_000e

    IL_0003:  ldstr      "value is null in SpecificDefaultWriter.WriteEnum"
    IL_0008:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_000d:  throw

    IL_000e:  ldarg.3
    IL_000f:  ldarg.1
    IL_0010:  ldarg.2
    IL_0011:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_0016:  callvirt   instance int32 Avro.EnumSchema::Ordinal(string)
    IL_001b:  callvirt   instance void Avro.IO.Encoder::WriteEnum(int32)
    IL_0020:  ret
  } // end of method SpecificDefaultWriter::WriteEnum

  .method family hidebysig virtual instance void 
          WriteArray(class Avro.ArraySchema schema,
                     object 'value',
                     class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       88 (0x58)
    .maxstack  4
    .locals init (class [mscorlib]System.Collections.IList V_0,
             int64 V_1,
             int32 V_2)
    IL_0000:  ldarg.2
    IL_0001:  isinst     [mscorlib]System.Collections.IList
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Array does not implement non-generic IList"
    IL_000f:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0014:  throw

    IL_0015:  ldloc.0
    IL_0016:  callvirt   instance int32 [mscorlib]System.Collections.ICollection::get_Count()
    IL_001b:  conv.i8
    IL_001c:  stloc.1
    IL_001d:  ldarg.3
    IL_001e:  callvirt   instance void Avro.IO.Encoder::WriteArrayStart()
    IL_0023:  ldarg.3
    IL_0024:  ldloc.1
    IL_0025:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_002a:  ldc.i4.0
    IL_002b:  stloc.2
    IL_002c:  br.s       IL_004c

    IL_002e:  ldarg.3
    IL_002f:  callvirt   instance void Avro.IO.Encoder::StartItem()
    IL_0034:  ldarg.0
    IL_0035:  ldarg.1
    IL_0036:  callvirt   instance class Avro.Schema Avro.ArraySchema::get_ItemSchema()
    IL_003b:  ldloc.0
    IL_003c:  ldloc.2
    IL_003d:  callvirt   instance object [mscorlib]System.Collections.IList::get_Item(int32)
    IL_0042:  ldarg.3
    IL_0043:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                         object,
                                                                         class Avro.IO.Encoder)
    IL_0048:  ldloc.2
    IL_0049:  ldc.i4.1
    IL_004a:  add
    IL_004b:  stloc.2
    IL_004c:  ldloc.2
    IL_004d:  conv.i8
    IL_004e:  ldloc.1
    IL_004f:  blt.s      IL_002e

    IL_0051:  ldarg.3
    IL_0052:  callvirt   instance void Avro.IO.Encoder::WriteArrayEnd()
    IL_0057:  ret
  } // end of method SpecificDefaultWriter::WriteArray

  .method family hidebysig virtual instance void 
          WriteMap(class Avro.MapSchema schema,
                   object 'value',
                   class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       139 (0x8b)
    .maxstack  4
    .locals init (class [mscorlib]System.Collections.IDictionary V_0,
             valuetype [mscorlib]System.Collections.DictionaryEntry V_1,
             class [mscorlib]System.Collections.IDictionaryEnumerator V_2,
             class [mscorlib]System.IDisposable V_3)
    IL_0000:  ldarg.2
    IL_0001:  isinst     [mscorlib]System.Collections.IDictionary
    IL_0006:  stloc.0
    IL_0007:  ldloc.0
    IL_0008:  brtrue.s   IL_0015

    IL_000a:  ldstr      "Map does not implement non-generic IDictionary"
    IL_000f:  newobj     instance void Avro.AvroTypeException::.ctor(string)
    IL_0014:  throw

    IL_0015:  ldarg.3
    IL_0016:  callvirt   instance void Avro.IO.Encoder::WriteArrayStart()
    IL_001b:  ldarg.3
    IL_001c:  ldloc.0
    IL_001d:  callvirt   instance int32 [mscorlib]System.Collections.ICollection::get_Count()
    IL_0022:  conv.i8
    IL_0023:  callvirt   instance void Avro.IO.Encoder::SetItemCount(int64)
    IL_0028:  ldloc.0
    IL_0029:  callvirt   instance class [mscorlib]System.Collections.IDictionaryEnumerator [mscorlib]System.Collections.IDictionary::GetEnumerator()
    IL_002e:  stloc.2
    .try
    {
      IL_002f:  br.s       IL_0069

      IL_0031:  ldloc.2
      IL_0032:  callvirt   instance object [mscorlib]System.Collections.IEnumerator::get_Current()
      IL_0037:  unbox.any  [mscorlib]System.Collections.DictionaryEntry
      IL_003c:  stloc.1
      IL_003d:  ldarg.3
      IL_003e:  callvirt   instance void Avro.IO.Encoder::StartItem()
      IL_0043:  ldarg.3
      IL_0044:  ldloca.s   V_1
      IL_0046:  call       instance object [mscorlib]System.Collections.DictionaryEntry::get_Key()
      IL_004b:  isinst     [mscorlib]System.String
      IL_0050:  callvirt   instance void Avro.IO.Encoder::WriteString(string)
      IL_0055:  ldarg.0
      IL_0056:  ldarg.1
      IL_0057:  callvirt   instance class Avro.Schema Avro.MapSchema::get_ValueSchema()
      IL_005c:  ldloca.s   V_1
      IL_005e:  call       instance object [mscorlib]System.Collections.DictionaryEntry::get_Value()
      IL_0063:  ldarg.3
      IL_0064:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                           object,
                                                                           class Avro.IO.Encoder)
      IL_0069:  ldloc.2
      IL_006a:  callvirt   instance bool [mscorlib]System.Collections.IEnumerator::MoveNext()
      IL_006f:  brtrue.s   IL_0031

      IL_0071:  leave.s    IL_0084

    }  // end .try
    finally
    {
      IL_0073:  ldloc.2
      IL_0074:  isinst     [mscorlib]System.IDisposable
      IL_0079:  stloc.3
      IL_007a:  ldloc.3
      IL_007b:  brfalse.s  IL_0083

      IL_007d:  ldloc.3
      IL_007e:  callvirt   instance void [mscorlib]System.IDisposable::Dispose()
      IL_0083:  endfinally
    }  // end handler
    IL_0084:  ldarg.3
    IL_0085:  callvirt   instance void Avro.IO.Encoder::WriteMapEnd()
    IL_008a:  ret
  } // end of method SpecificDefaultWriter::WriteMap

  .method family hidebysig virtual instance void 
          WriteUnion(class Avro.UnionSchema us,
                     object 'value',
                     class Avro.IO.Encoder encoder) cil managed
  {
    // Code size       104 (0x68)
    .maxstack  4
    .locals init (int32 V_0,
             object[] V_1)
    IL_0000:  ldc.i4.0
    IL_0001:  stloc.0
    IL_0002:  br.s       IL_002f

    IL_0004:  ldarg.0
    IL_0005:  ldarg.1
    IL_0006:  ldloc.0
    IL_0007:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_000c:  ldarg.2
    IL_000d:  callvirt   instance bool Avro.Generic.DefaultWriter::Matches(class Avro.Schema,
                                                                           object)
    IL_0012:  brfalse.s  IL_002b

    IL_0014:  ldarg.3
    IL_0015:  ldloc.0
    IL_0016:  callvirt   instance void Avro.IO.Encoder::WriteUnionIndex(int32)
    IL_001b:  ldarg.0
    IL_001c:  ldarg.1
    IL_001d:  ldloc.0
    IL_001e:  callvirt   instance class Avro.Schema Avro.UnionSchema::get_Item(int32)
    IL_0023:  ldarg.2
    IL_0024:  ldarg.3
    IL_0025:  callvirt   instance void Avro.Generic.DefaultWriter::Write(class Avro.Schema,
                                                                         object,
                                                                         class Avro.IO.Encoder)
    IL_002a:  ret

    IL_002b:  ldloc.0
    IL_002c:  ldc.i4.1
    IL_002d:  add
    IL_002e:  stloc.0
    IL_002f:  ldloc.0
    IL_0030:  ldarg.1
    IL_0031:  callvirt   instance int32 Avro.UnionSchema::get_Count()
    IL_0036:  blt.s      IL_0004

    IL_0038:  ldc.i4.4
    IL_0039:  newarr     [mscorlib]System.Object
    IL_003e:  stloc.1
    IL_003f:  ldloc.1
    IL_0040:  ldc.i4.0
    IL_0041:  ldstr      "Cannot find a match for "
    IL_0046:  stelem.ref
    IL_0047:  ldloc.1
    IL_0048:  ldc.i4.1
    IL_0049:  ldarg.2
    IL_004a:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_004f:  stelem.ref
    IL_0050:  ldloc.1
    IL_0051:  ldc.i4.2
    IL_0052:  ldstr      " in "
    IL_0057:  stelem.ref
    IL_0058:  ldloc.1
    IL_0059:  ldc.i4.3
    IL_005a:  ldarg.1
    IL_005b:  stelem.ref
    IL_005c:  ldloc.1
    IL_005d:  call       string [mscorlib]System.String::Concat(object[])
    IL_0062:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0067:  throw
  } // end of method SpecificDefaultWriter::WriteUnion

  .method family hidebysig virtual instance bool 
          Matches(class Avro.Schema sc,
                  object obj) cil managed
  {
    // Code size       345 (0x159)
    .maxstack  2
    .locals init (valuetype Avro.Schema/Type V_0)
    IL_0000:  ldarg.2
    IL_0001:  brtrue.s   IL_000d

    IL_0003:  ldarg.1
    IL_0004:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0009:  brfalse.s  IL_000d

    IL_000b:  ldc.i4.0
    IL_000c:  ret

    IL_000d:  ldarg.1
    IL_000e:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0013:  stloc.0
    IL_0014:  ldloc.0
    IL_0015:  switch     ( 
                          IL_0057,
                          IL_005c,
                          IL_0066,
                          IL_0070,
                          IL_007a,
                          IL_0084,
                          IL_008e,
                          IL_0098,
                          IL_00a2,
                          IL_00d2,
                          IL_00f8,
                          IL_0102,
                          IL_010c,
                          IL_010e)
    IL_0052:  br         IL_013e

    IL_0057:  ldarg.2
    IL_0058:  ldnull
    IL_0059:  ceq
    IL_005b:  ret

    IL_005c:  ldarg.2
    IL_005d:  isinst     [mscorlib]System.Boolean
    IL_0062:  ldnull
    IL_0063:  cgt.un
    IL_0065:  ret

    IL_0066:  ldarg.2
    IL_0067:  isinst     [mscorlib]System.Int32
    IL_006c:  ldnull
    IL_006d:  cgt.un
    IL_006f:  ret

    IL_0070:  ldarg.2
    IL_0071:  isinst     [mscorlib]System.Int64
    IL_0076:  ldnull
    IL_0077:  cgt.un
    IL_0079:  ret

    IL_007a:  ldarg.2
    IL_007b:  isinst     [mscorlib]System.Single
    IL_0080:  ldnull
    IL_0081:  cgt.un
    IL_0083:  ret

    IL_0084:  ldarg.2
    IL_0085:  isinst     [mscorlib]System.Double
    IL_008a:  ldnull
    IL_008b:  cgt.un
    IL_008d:  ret

    IL_008e:  ldarg.2
    IL_008f:  isinst     uint8[]
    IL_0094:  ldnull
    IL_0095:  cgt.un
    IL_0097:  ret

    IL_0098:  ldarg.2
    IL_0099:  isinst     [mscorlib]System.String
    IL_009e:  ldnull
    IL_009f:  cgt.un
    IL_00a1:  ret

    IL_00a2:  ldarg.2
    IL_00a3:  isinst     Avro.Specific.ISpecificRecord
    IL_00a8:  brfalse.s  IL_00d0

    IL_00aa:  ldarg.2
    IL_00ab:  isinst     Avro.Specific.ISpecificRecord
    IL_00b0:  callvirt   instance class Avro.Schema Avro.Specific.ISpecificRecord::get_Schema()
    IL_00b5:  isinst     Avro.RecordSchema
    IL_00ba:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00bf:  ldarg.1
    IL_00c0:  isinst     Avro.RecordSchema
    IL_00c5:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_00ca:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_00cf:  ret

    IL_00d0:  ldc.i4.0
    IL_00d1:  ret

    IL_00d2:  ldarg.2
    IL_00d3:  callvirt   instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
    IL_00d8:  callvirt   instance bool [mscorlib]System.Type::get_IsEnum()
    IL_00dd:  brfalse.s  IL_00f6

    IL_00df:  ldarg.1
    IL_00e0:  isinst     Avro.EnumSchema
    IL_00e5:  callvirt   instance class [mscorlib]System.Collections.Generic.IList`1<string> Avro.EnumSchema::get_Symbols()
    IL_00ea:  ldarg.2
    IL_00eb:  callvirt   instance string [mscorlib]System.Object::ToString()
    IL_00f0:  callvirt   instance bool class [mscorlib]System.Collections.Generic.ICollection`1<string>::Contains(!0)
    IL_00f5:  ret

    IL_00f6:  ldc.i4.0
    IL_00f7:  ret

    IL_00f8:  ldarg.2
    IL_00f9:  isinst     [mscorlib]System.Collections.IList
    IL_00fe:  ldnull
    IL_00ff:  cgt.un
    IL_0101:  ret

    IL_0102:  ldarg.2
    IL_0103:  isinst     [mscorlib]System.Collections.IDictionary
    IL_0108:  ldnull
    IL_0109:  cgt.un
    IL_010b:  ret

    IL_010c:  ldc.i4.0
    IL_010d:  ret

    IL_010e:  ldarg.2
    IL_010f:  isinst     Avro.Specific.SpecificFixed
    IL_0114:  brfalse.s  IL_013c

    IL_0116:  ldarg.2
    IL_0117:  isinst     Avro.Specific.SpecificFixed
    IL_011c:  callvirt   instance class Avro.Schema Avro.Specific.SpecificFixed::get_Schema()
    IL_0121:  isinst     Avro.FixedSchema
    IL_0126:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_012b:  ldarg.1
    IL_012c:  isinst     Avro.FixedSchema
    IL_0131:  callvirt   instance class Avro.SchemaName Avro.NamedSchema::get_SchemaName()
    IL_0136:  callvirt   instance bool [mscorlib]System.Object::Equals(object)
    IL_013b:  ret

    IL_013c:  ldc.i4.0
    IL_013d:  ret

    IL_013e:  ldstr      "Unknown schema type: "
    IL_0143:  ldarg.1
    IL_0144:  callvirt   instance valuetype Avro.Schema/Type Avro.Schema::get_Tag()
    IL_0149:  box        Avro.Schema/Type
    IL_014e:  call       string [mscorlib]System.String::Concat(object,
                                                                object)
    IL_0153:  newobj     instance void Avro.AvroException::.ctor(string)
    IL_0158:  throw
  } // end of method SpecificDefaultWriter::Matches

} // end of class Avro.Specific.SpecificDefaultWriter

.class interface public abstract auto ansi Avro.Specific.ISpecificRecord
{
  .method public hidebysig newslot specialname abstract virtual 
          instance class Avro.Schema  get_Schema() cil managed
  {
  } // end of method ISpecificRecord::get_Schema

  .method public hidebysig newslot abstract virtual 
          instance object  Get(int32 fieldPos) cil managed
  {
  } // end of method ISpecificRecord::Get

  .method public hidebysig newslot abstract virtual 
          instance void  Put(int32 fieldPos,
                             object fieldValue) cil managed
  {
  } // end of method ISpecificRecord::Put

  .property instance class Avro.Schema Schema()
  {
    .get instance class Avro.Schema Avro.Specific.ISpecificRecord::get_Schema()
  } // end of property ISpecificRecord::Schema
} // end of class Avro.Specific.ISpecificRecord

.class private auto ansi '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'
       extends [mscorlib]System.Object
{
  .custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = ( 01 00 00 00 ) 
  .field static assembly int32 '$$method0x600027d-1' at I_000038F8
  .field static assembly class [mscorlib]System.Collections.Generic.Dictionary`2<string,int32> '$$method0x6000203-1'
} // end of class '<PrivateImplementationDetails>{859830F3-9354-43B7-8D29-EB194D637810}'


// =============================================================

.data cil I_000038F8 = bytearray (
                 4F 62 6A 01)                                     // Obj.
// *********** DISASSEMBLY COMPLETE ***********************
// WARNING: Created Win32 resource file avro.res
