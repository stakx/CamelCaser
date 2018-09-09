# CamelCaser

A small .NET library for converting identifiers to "camelCase".

```csharp
partial interface ICamelCaser { }

nameof(ICamelCaser).ToLowerCamelCase();
// => "camelCaser"
```


## What could this be useful for?

The main purpose behind this library is to be able to automatically derive suitable variable names from type names e.g. in Reflection-based tools. The usual .NET conventions state that variable names should be in "camelCase", while type names should be in "PascalCase".

While this conversion is a no-brainer for humans, it's actually made more complicated than one might realise at first by several .NET naming conventions:

 * For interface types whose name starts with an `I`, that `I` should be dropped: `IFruitPicker` &rarr; `fruitPicker` (not `iFruitPicker`!)

 * When there are several initial upper-case characters, all but the last of them should be lower-cased: `IDESettings` &rarr; `ideSettings` (not `idesettings`, nor `idesEttings`!)

 * &hellip; but not if all characters are in upper-case: `IDE` &rarr; `ide` (not `idE`!)

This library takes care of that transformation, so that you don't have to.


## How do I use it?

By importing the `CamelCaser` namespace, the following extension method becomes available:

* **`string.ToLowerCamelCase()`**:  
  Converts the original string to "camelCase" according to the rules shown above.


## But it doesn't lower-case \<some string\> correctly!

If you think you've found a bug, please raise an [issue](https://github.com/stakx/CamelCaser/issues) so it can be looked into. (Make sure to mention the string that doesn't get formatted as expected, along with your expectation of how it should have been formatted.)
