using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;

namespace Soenneker.Extensions.Arrays.Strings;

/// <summary>
/// A collection of helpful string array extension methods
/// </summary>
public static class StringArrayExtension
{
    /// <summary>
    /// Determines whether any element in the specified array contains the given substring, using the specified string
    /// comparison option.
    /// </summary>
    /// <remarks>If the array is empty, or if all elements are null, the method returns false. The search uses
    /// the specified StringComparison option for each element.</remarks>
    /// <param name="arr">The array of strings to search. Elements may be null.</param>
    /// <param name="part">The substring to seek within each array element. Cannot be null.</param>
    /// <param name="comparison">One of the enumeration values that specifies the rules for the search, such as case sensitivity and culture.</param>
    /// <returns>true if at least one non-null element in the array contains the specified substring; otherwise, false.</returns>
    [Pure, MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool ContainsAPart(string[] arr, string part, StringComparison comparison)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            string? current = arr[i];

            if (current is not null && current.IndexOf(part, comparison) >= 0)
                return true;
        }

        return false;
    }

    /// <summary>
    /// Parses an array of command-line arguments into a dictionary of key-value pairs.
    /// </summary>
    /// <remarks>Arguments that do not start with '--' are ignored. If an argument is provided without a
    /// value, it will be stored with an empty string as its value. Keys are compared using case-insensitive ordinal
    /// comparison.</remarks>
    /// <param name="args">An array of command-line arguments to parse. Each argument should be in the format '--key=value' or '--key
    /// value'.</param>
    /// <returns>A dictionary containing the parsed key-value pairs, where each key is the argument name (including the leading
    /// dashes) and each value is the corresponding argument value. Arguments without a value are assigned an empty
    /// string.</returns>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="args"/> is null.</exception>
    [Pure]
    public static Dictionary<string, string> ParseArguments(this string[] args)
    {
        if (args is null)
            throw new ArgumentNullException(nameof(args));

        int capacity = args.Length >> 1;
        var map = new Dictionary<string, string>(capacity, StringComparer.OrdinalIgnoreCase);

        for (int i = 0; i < args.Length; i++)
        {
            string token = args[i];

            // Fast "--" check
            if (token.Length < 3 || token[0] != '-' || token[1] != '-')
                continue;

            // --key=value
            int eq = token.IndexOf('=');
            if (eq > 2)
            {
                // Key is entire token before '=' (includes "--")
                string key = token.Substring(0, eq);
                string value = (eq + 1 < token.Length) ? token.Substring(eq + 1) : string.Empty;
                map[key] = value;
                continue;
            }

            // --key value
            if (i + 1 < args.Length)
            {
                string next = args[i + 1];

                // If next token is another flag, treat as empty value
                if (next.Length >= 2 && next[0] == '-' && next[1] == '-')
                {
                    map[token] = string.Empty;
                    continue;
                }

                map[token] = next;
                i++; // consume value
            }
            else
            {
                // Trailing flag with no value
                map[token] = string.Empty;
            }
        }

        return map;
    }
}
