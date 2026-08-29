[![](https://img.shields.io/nuget/v/soenneker.extensions.arrays.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.strings/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.strings/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.arrays.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.strings/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.strings/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Arrays.Strings

A collection of helpful string array extension methods.

## Installation

```bash
dotnet add package Soenneker.Extensions.Arrays.Strings
```

## Quick start

```csharp
using Soenneker.Extensions.Arrays.Strings;
```

Import the namespace, then call the extension methods directly on the matching value.

## Common operations

- `ContainsAPart()` - Determines whether any element in the specified array contains the given substring, using the specified string comparison option.
- `ParseArguments()` - Parses an array of command-line arguments into a dictionary of key-value pairs.
