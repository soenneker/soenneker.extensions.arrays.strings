[![](https://img.shields.io/nuget/v/soenneker.extensions.arrays.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.strings/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.strings/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.arrays.strings.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.arrays.strings/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.arrays.strings/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.arrays.strings/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Arrays.Strings

Searches string arrays with explicit comparison rules and parses long-form command-line options into a case-insensitive dictionary.

## Installation

```bash
dotnet add package Soenneker.Extensions.Arrays.Strings
```

## Search array elements

```csharp
using Soenneker.Extensions.Arrays.Strings;

string[] values = ["Alpha", "Beta", "Gamma"];

bool contains = values.ContainsAPart("PH", StringComparison.OrdinalIgnoreCase);
// true, because "Alpha" contains "PH" with the selected comparison
```

`ContainsAPart(part, comparison)` checks each non-null element with `IndexOf`. It returns `false` for an empty array or an array containing only nulls. An empty `part` matches the first non-null element. Choose `Ordinal` or `OrdinalIgnoreCase` for protocol and identifier comparisons; culture-sensitive modes use the corresponding .NET string-comparison behavior.

## Parse command-line options

```csharp
string[] args =
[
    "--port=8080",
    "--name", "worker-a",
    "--verbose",
    "ignored"
];

Dictionary<string, string> options = args.ParseArguments();

string port = options["--port"];       // "8080"
string name = options["--name"];       // "worker-a"
string verbose = options["--verbose"]; // ""
```

Supported forms are `--key=value`, `--key value`, and a standalone `--flag`, which receives an empty value. Keys retain their leading `--` and use `StringComparer.OrdinalIgnoreCase`. When the same key appears more than once, the last value wins.

Tokens that do not begin with `--` are ignored unless consumed as the preceding option's value. A following `--...` token starts a new option rather than becoming a value; use `--key=--value` when a value itself begins with two dashes. The parser does not support short `-k` options, combined flags, a `--` end-of-options marker, schema validation, required options, or automatic conversion to numbers and booleans.

The process host or shell has already performed quoting and tokenization before `string[] args` reaches this method. The parser does not execute commands, expand environment variables, or remove quotes embedded in a token.
