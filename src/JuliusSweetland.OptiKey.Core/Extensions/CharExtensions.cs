// Copyright (c) 2020 OPTIKEY LTD (UK company number 11854839) - All Rights Reserved
using System.Collections.Generic;
using System.Globalization;
using WindowsInput.Native;
using JuliusSweetland.OptiKey.Enums;
using JuliusSweetland.OptiKey.Models;

namespace JuliusSweetland.OptiKey.Extensions
{
    public static class CharExtensions
    {
        private static readonly Map<char, char> ChineseBopomofo = new Map<char, char>();
        private static readonly Map<char, char> ChineseCangjie = new Map<char, char>();
        private static readonly Map<char, char> HangulIntialToFinalConsonents = new Map<char, char>();
        private static readonly Map<char, char> HiraganaUpperToLowerCase = new Map<char, char>();
        private static readonly Map<char, char> KatakanaUpperToLowerCase = new Map<char, char>();
        
        static CharExtensions()
        {
            //Chinese Bopomofo mappings
            ChineseBopomofo.Add('\u3105', '1'); //ㄅ
            ChineseBopomofo.Add('\u3106', 'q'); //ㄆ
            ChineseBopomofo.Add('\u3107', 'a'); //ㄇ
            ChineseBopomofo.Add('\u3108', 'z'); //ㄈ
            ChineseBopomofo.Add('\u3109', '2'); //ㄉ
            ChineseBopomofo.Add('\u310A', 'w'); //ㄊ
            ChineseBopomofo.Add('\u310B', 's'); //ㄋ
            ChineseBopomofo.Add('\u310C', 'x'); //ㄌ
            ChineseBopomofo.Add('\u310D', 'e'); //ㄍ
            ChineseBopomofo.Add('\u310E', 'd'); //ㄎ
            ChineseBopomofo.Add('\u310F', 'c'); //ㄏ
            ChineseBopomofo.Add('\u3110', 'r'); //ㄐ
            ChineseBopomofo.Add('\u3111', 'f'); //ㄑ
            ChineseBopomofo.Add('\u3112', 'v'); //ㄒ
            ChineseBopomofo.Add('\u3113', '5'); //ㄓ
            ChineseBopomofo.Add('\u3114', 't'); //ㄔ
            ChineseBopomofo.Add('\u3115', 'g'); //ㄕ
            ChineseBopomofo.Add('\u3116', 'b'); //ㄖ
            ChineseBopomofo.Add('\u3117', 'y'); //ㄗ
            ChineseBopomofo.Add('\u3118', 'h'); //ㄘ
            ChineseBopomofo.Add('\u3119', 'n'); //ㄙ
            ChineseBopomofo.Add('\u311A', '8'); //ㄚ
            ChineseBopomofo.Add('\u311B', 'i'); //ㄛ
            ChineseBopomofo.Add('\u311C', 'k'); //ㄜ
            ChineseBopomofo.Add('\u311D', ','); //ㄝ
            ChineseBopomofo.Add('\u311E', '9'); //ㄞ
            ChineseBopomofo.Add('\u311F', 'o'); //ㄟ
            ChineseBopomofo.Add('\u3120', 'l'); //ㄠ
            ChineseBopomofo.Add('\u3121', '.'); //ㄡ
            ChineseBopomofo.Add('\u3122', '0'); //ㄢ
            ChineseBopomofo.Add('\u3123', 'p'); //ㄣ
            ChineseBopomofo.Add('\u3124', ';'); //ㄤ
            ChineseBopomofo.Add('\u3125', '/'); //ㄥ
            ChineseBopomofo.Add('\u3126', '-'); //ㄦ
            ChineseBopomofo.Add('\u3127', 'u'); //ㄧ
            ChineseBopomofo.Add('\u3128', 'j'); //ㄨ
            ChineseBopomofo.Add('\u3129', 'm'); //ㄩ
            ChineseBopomofo.Add('\u02CA', '6'); //ˊ tone 2
            ChineseBopomofo.Add('\u02C7', '3'); //ˇ tone 3
            ChineseBopomofo.Add('\u02CB', '4'); //ˋ tone 4
            ChineseBopomofo.Add('\u02D9', '7'); //˙ tone light

            //Chinese Cangjie mapping
            ChineseCangjie.Add('\u65e5', 'a'); //日
            ChineseCangjie.Add('\u6708', 'b'); //月
            ChineseCangjie.Add('\u91d1', 'c'); //金
            ChineseCangjie.Add('\u6728', 'd'); //木
            ChineseCangjie.Add('\u6c34', 'e'); //水
            ChineseCangjie.Add('\u706b', 'f'); //火
            ChineseCangjie.Add('\u571f', 'g'); //土
            ChineseCangjie.Add('\u7af9', 'h'); //竹
            ChineseCangjie.Add('\u6208', 'i'); //戈
            ChineseCangjie.Add('\u5341', 'j'); //十
            ChineseCangjie.Add('\u5927', 'k'); //大
            ChineseCangjie.Add('\u4e2d', 'l'); //中
            ChineseCangjie.Add('\u4e00', 'm'); //一
            ChineseCangjie.Add('\u5f13', 'n'); //弓
            ChineseCangjie.Add('\u4eba', 'o'); //人
            ChineseCangjie.Add('\u5fc3', 'p'); //心
            ChineseCangjie.Add('\u624b', 'q'); //手
            ChineseCangjie.Add('\u53e3', 'r'); //口
            ChineseCangjie.Add('\u5c38', 's'); //尸
            ChineseCangjie.Add('\u5eff', 't'); //廿
            ChineseCangjie.Add('\u5c71', 'u'); //山
            ChineseCangjie.Add('\u5973', 'v'); //女
            ChineseCangjie.Add('\u7530', 'w'); //田
            ChineseCangjie.Add('\u96e3', 'x'); //難
            ChineseCangjie.Add('\u535c', 'y'); //卜
            ChineseCangjie.Add('\u91cd', 'z'); //重

            //Korean mappings
            HangulIntialToFinalConsonents.Add('\u1100', '\u11A8'); //ㄱ
            HangulIntialToFinalConsonents.Add('\u1101', '\u11A9'); //ㄲ
            HangulIntialToFinalConsonents.Add('\u1102', '\u11AB'); //ㄴ
            HangulIntialToFinalConsonents.Add('\u1103', '\u11AE'); //ㄷ
            HangulIntialToFinalConsonents.Add('\u1105', '\u11AF'); //ㄹ
            HangulIntialToFinalConsonents.Add('\u1106', '\u11B7'); //ㅁ
            HangulIntialToFinalConsonents.Add('\u1107', '\u11B8'); //ㅂ
            HangulIntialToFinalConsonents.Add('\u1109', '\u11BA'); //ㅅ
            HangulIntialToFinalConsonents.Add('\u110A', '\u11BB'); //ㅆ
            HangulIntialToFinalConsonents.Add('\u110B', '\u11BC'); //ㅇ
            HangulIntialToFinalConsonents.Add('\u110C', '\u11BD'); //ㅈ
            HangulIntialToFinalConsonents.Add('\u110E', '\u11BE'); //ㅊ
            HangulIntialToFinalConsonents.Add('\u110F', '\u11BF'); //ㅋ
            HangulIntialToFinalConsonents.Add('\u1110', '\u11C0'); //ㅌ
            HangulIntialToFinalConsonents.Add('\u1111', '\u11C1'); //ㅍ
            HangulIntialToFinalConsonents.Add('\u1112', '\u11C2'); //ㅎ

            //Japanese Hiragan mappings
            HiraganaUpperToLowerCase.Add('あ', 'ぁ'); //あ
            HiraganaUpperToLowerCase.Add('い', 'ぃ'); //い
            HiraganaUpperToLowerCase.Add('う', 'ぅ'); //う
            HiraganaUpperToLowerCase.Add('え', 'ぇ'); //え
            HiraganaUpperToLowerCase.Add('お', 'ぉ'); //お
            HiraganaUpperToLowerCase.Add('つ', 'っ'); //つ
            HiraganaUpperToLowerCase.Add('や', 'ゃ'); //や
            HiraganaUpperToLowerCase.Add('ゆ', 'ゅ'); //ゆ
            HiraganaUpperToLowerCase.Add('よ', 'ょ'); //よ
            HiraganaUpperToLowerCase.Add('わ', 'ゎ'); //わ

            //Japanese Katakana mappings
            KatakanaUpperToLowerCase.Add('ア', 'ァ'); //ア
            KatakanaUpperToLowerCase.Add('イ', 'ィ'); //イ
            KatakanaUpperToLowerCase.Add('ウ', 'ゥ'); //ウ
            KatakanaUpperToLowerCase.Add('エ', 'ェ'); //エ
            KatakanaUpperToLowerCase.Add('オ', 'ォ'); //オ
            KatakanaUpperToLowerCase.Add('カ', 'ヵ'); //カ
            KatakanaUpperToLowerCase.Add('ク', 'ㇰ'); //ク
            KatakanaUpperToLowerCase.Add('ケ', 'ヶ'); //ケ
            KatakanaUpperToLowerCase.Add('シ', 'ㇱ'); //シ
            KatakanaUpperToLowerCase.Add('ス', 'ㇲ'); //ス
            KatakanaUpperToLowerCase.Add('ツ', 'ッ'); //ツ
            KatakanaUpperToLowerCase.Add('ト', 'ㇳ'); //ト
            KatakanaUpperToLowerCase.Add('ヌ', 'ㇴ'); //ヌ
            KatakanaUpperToLowerCase.Add('ハ', 'ㇵ'); //ハ
            KatakanaUpperToLowerCase.Add('ヒ', 'ㇶ'); //ヒ
            KatakanaUpperToLowerCase.Add('フ', 'ㇷ'); //フ
            KatakanaUpperToLowerCase.Add('ヘ', 'ㇸ'); //ヘ
            KatakanaUpperToLowerCase.Add('ホ', 'ㇹ'); //ホ
            KatakanaUpperToLowerCase.Add('ム', 'ㇺ'); //ム
            KatakanaUpperToLowerCase.Add('ヤ', 'ャ'); //ヤ
            KatakanaUpperToLowerCase.Add('ユ', 'ュ'); //ユ
            KatakanaUpperToLowerCase.Add('ヨ', 'ョ'); //ヨ
            KatakanaUpperToLowerCase.Add('ラ', 'ㇻ'); //ラ
            KatakanaUpperToLowerCase.Add('リ', 'ㇼ'); //リ
            KatakanaUpperToLowerCase.Add('ル', 'ㇽ'); //ル
            KatakanaUpperToLowerCase.Add('レ', 'ㇾ'); //レ
            KatakanaUpperToLowerCase.Add('ロ', 'ㇿ'); //ロ
            KatakanaUpperToLowerCase.Add('ワ', 'ヮ'); //ワ
        }
        
        public static CharCategories ToCharCategory(this char c)
        {
            if (c == '\n')
            {
                return CharCategories.NewLine;
            }

            if (c == ' ')
            {
                return CharCategories.Space;
            }

            if (c == '\t')
            {
                return CharCategories.Tab;
            }

            if (char.IsLetterOrDigit(c) || char.IsSymbol(c) || char.IsPunctuation(c) 
                || CharUnicodeInfo.GetUnicodeCategory(c) == UnicodeCategory.NonSpacingMark)
            {
                return CharCategories.LetterOrDigitOrSymbolOrPunctuation;
            }

            return CharCategories.SomethingElse;
        }

        public static UnicodeCodePointRanges UnicodeCodePointRange(this char c)
        {
            var codePoint = (int)c;

            if (codePoint >= 0xAC00 && codePoint <= 0xD7A3)
            {
                return UnicodeCodePointRanges.HangulSyllable;
            }

            if (codePoint >= 0x1100 && codePoint <= 0x1112)
            {
                return UnicodeCodePointRanges.HangulInitialConsonant;
            }

            if (codePoint >= 0x1161 && codePoint <= 0x1175)
            {
                return UnicodeCodePointRanges.HangulVowel;
            }

            if (codePoint >= 0x11A8 && codePoint <= 0x11C2)
            {
                return UnicodeCodePointRanges.HangulFinalConsonant;
            }

            if ((codePoint >= 0x3105 && codePoint <= 0x3129)
                || codePoint == 0x02CA
                || codePoint == 0x02C7
                || codePoint == 0x02CB
                || codePoint == 0x02D9)
            {
                return UnicodeCodePointRanges.ChineseBopomofo;
            }

            return UnicodeCodePointRanges.Other;
        }

        #region Hangul (Korean Character) Extension Methods

        public static bool CanBeInitialOrFinalHangulConsonant(this char c)
        {
            return HangulIntialToFinalConsonents.Forward.ContainsKey(c)
                   || HangulIntialToFinalConsonents.Reverse.ContainsKey(c);
        }

        public static char ConvertToInitialHangulConsonant(this char c)
        {
            if(c.UnicodeCodePointRange() == UnicodeCodePointRanges.HangulFinalConsonant
                && HangulIntialToFinalConsonents.Reverse.ContainsKey(c))
            {
                return HangulIntialToFinalConsonents.Reverse[c];
            }
            return c;
        }

        public static char ConvertToFinalHangulConsonant(this char c)
        {
            if (c.UnicodeCodePointRange() == UnicodeCodePointRanges.HangulInitialConsonant
                && HangulIntialToFinalConsonents.Forward.ContainsKey(c))
            {
                return HangulIntialToFinalConsonents.Forward[c];
            }
            return c;
        }

        #endregion

        #region (Chinese Bopomofo) Extension Methods

        public static char BopomofoToQwerty(this char c)
        {
            if (ChineseBopomofo.Forward.ContainsKey(c))
            {
                return ChineseBopomofo.Forward[c];
            }
            return c;
        }
        #endregion

        public static char ToggleCase(this char c)
        {
            //Upper to lower conversions:

            if (HiraganaUpperToLowerCase.Forward.ContainsKey(c))
            {
                return HiraganaUpperToLowerCase.Forward[c];
            }

            if (KatakanaUpperToLowerCase.Forward.ContainsKey(c))
            {
                return KatakanaUpperToLowerCase.Forward[c];
            }

            if (char.IsUpper(c))
            {
                return char.ToLowerInvariant(c);
            }

            //Lower to upper conversions

            if (HiraganaUpperToLowerCase.Reverse.ContainsKey(c))
            {
                return HiraganaUpperToLowerCase.Reverse[c];
            }

            if (KatakanaUpperToLowerCase.Reverse.ContainsKey(c))
            {
                return KatakanaUpperToLowerCase.Reverse[c];
            }

            if (char.IsLower(c))
            {
                return char.ToUpperInvariant(c);
            }

            //Neither - just return the char
            return c;
        }

        public static string ToPrintableString(this char c)
        {
            var escapedLiteralString = c.ToString(CultureInfo.InvariantCulture)
                    .Replace("\0", @"\0")
                    .Replace("\a", @"\a")
                    .Replace("\b", @"\b")
                    .Replace("\t", @"\t")
                    .Replace("\f", @"\f")
                    .Replace("\n", @"\n")
                    .Replace("\r", @"\r");

            return string.Format(@"[Char:{0}|Unicode:U+{1:x4}]", escapedLiteralString, (int)c);
        }

        public static bool IsCombiningCharacter(this char c)
        {
            var category = CharUnicodeInfo.GetUnicodeCategory(c);
            return category == UnicodeCategory.NonSpacingMark //(All combining diacritic characters are non-spacing marks). Nonspacing character that indicates modifications of a base character. Signified by the Unicode designation "Mn"(mark, nonspacing).The value is 5.
                || category == UnicodeCategory.SpacingCombiningMark //Spacing character that indicates modifications of a base character and affects the width of the glyph for that base character. Signified by the Unicode designation "Mc" (mark, spacing combining). The value is 6.
                || category == UnicodeCategory.EnclosingMark; //Enclosing mark character, which is a nonspacing combining character that surrounds all previous characters up to and including a base character. Signified by the Unicode designation "Me" (mark, enclosing). The value is 7.
        }

        //http://inputsimulator.codeplex.com/SourceControl/latest#WindowsInput/Native/VirtualKeyCode.cs
        //http://msdn.microsoft.com/en-gb/library/windows/desktop/dd375731(v=vs.85).aspx
        public static VirtualKeyCode? ToVirtualKeyCode(this char character)
        {
            switch (character)
            {
                case ' ':
                    return VirtualKeyCode.SPACE;

                case '\t':
                    return VirtualKeyCode.TAB;

                case '\n':
                    return VirtualKeyCode.RETURN;

                default:
                    return null;
            }
        }
    }
}
