﻿using Microsoft.Languages.Core.Diagnostics;
using Microsoft.Languages.Core.Test.Utility;
using Microsoft.Languages.Core.Text;
using Microsoft.Languages.Core.Tokens;

namespace Microsoft.Languages.Core.Test.Tokens
{
    public class TokenizeTestBase<TTokenClass, TTokenType> : UnitTestBase where TTokenClass: IToken<TTokenType>
    {
        protected string TokenizeToString(string text, ITokenizer<TTokenClass> tokenizer)
        {
            var tokens = this.Tokenize(text, tokenizer);
            string result = DebugWriter.WriteTokens<TTokenClass, TTokenType>(tokens);

            return result;
        }

        protected IReadOnlyTextRangeCollection<TTokenClass> Tokenize(string text, ITokenizer<TTokenClass> tokenizer)
        {
            ITextProvider textProvider = new TextStream(text);
            return tokenizer.Tokenize(textProvider, 0, textProvider.Length);
        }
    }
}