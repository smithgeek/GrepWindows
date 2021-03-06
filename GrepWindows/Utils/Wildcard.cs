﻿// Source based from http://www.codeproject.com/KB/recipes/wildcardtoregex.aspx

namespace Smithgeek.Text.RegularExpressions
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Represents a wildcard running on the
    /// <see cref="System.Text.RegularExpressions"/> engine.
    /// </summary>

    public class Wildcard : Regex
    {
        /// <summary>
        /// Initializes a wildcard with the given search pattern.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to match.</param>
        public Wildcard(string pattern)
            : base(WildcardToRegex(pattern))
        {
        }

        /// <summary>
        /// Initializes a wildcard with the given search pattern and options.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to match.</param>
        /// <param name="options">A combination of one or more
        /// <see cref="System.Text.RegexOptions"/>.</param>
        public Wildcard(string pattern, RegexOptions options)
            : base(WildcardToRegex(pattern), options)
        {
        }

        /// <summary>
        /// Converts a wildcard to a regex.
        /// </summary>
        /// <param name="pattern">The wildcard pattern to convert.</param>
        /// <returns>A regex equivalent of the given wildcard.</returns>
        public static string WildcardToRegex(string pattern)
        {
            return "^" + Regex.Escape(pattern).
             Replace("\\*", ".*").
             Replace("\\?", ".") + "$";
        }

        public static new Match Match(string input, string pattern)
        {
            Wildcard wildcard = new Wildcard(pattern);
            return wildcard.Match(input);
        }

        public static new Match Match(string input, string pattern, RegexOptions options)
        {
            Wildcard wildcard = new Wildcard(pattern, options);
            return wildcard.Match(input);
        }

        public static new MatchCollection Matches(string input, string pattern)
        {
            Wildcard wildcard = new Wildcard(pattern);
            return wildcard.Matches(input);
        }

        public static new MatchCollection Matches(string input, string pattern, RegexOptions options)
        {
            Wildcard wildcard = new Wildcard(pattern, options);
            return wildcard.Matches(input);
        }

        public static new string Escape(string str)
        {
            throw new NotImplementedException();
        }

        public static new string Unescape(string str)
        {
            throw new NotImplementedException();
        }
    }
}
