using KanaTrainer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanaTrainer.Stores
{
    internal class KanaSystemsStore
    {
        private readonly ObservableCollection<KanaSystem> _kanaSystems;
        public ObservableCollection<KanaSystem> KanaSystems
        {
            get { return _kanaSystems; }
        }
        public KanaSystemsStore()
        {
            _kanaSystems = new ObservableCollection<KanaSystem>();

            _kanaSystems.Add(CreateHiragana());
            _kanaSystems.Add(CreateKatakana());
        }

        private KanaSystem CreateHiragana()
        {
            return new KanaSystem("Hiragana", new List<KanaGroup>
            {
                new KanaGroup("-", new List<Kana>
                {
                    new Kana("あ", "a"),
                    new Kana("い", "i"),
                    new Kana("う", "u"),
                    new Kana("え", "e"),
                    new Kana("お", "o"),
                }),

                new KanaGroup("k", new List<Kana>
                {
                    new Kana("か", "ka",
                        new Kana("が", "ga")),
                    new Kana("き", "ki",
                        new Kana("ぎ", "gi")),
                    new Kana("く", "ku",
                        new Kana("ぐ", "gu")),
                    new Kana("け", "ke",
                        new Kana("げ", "ge")),
                    new Kana("こ", "ko",
                        new Kana("ご", "go")),
                }, "g"),

                new KanaGroup("s", new List<Kana>
                {
                    new Kana("さ", "sa",
                        new Kana("ざ", "za")),
                    new Kana("し", "shi",
                        new Kana("じ", "ji")),
                    new Kana("す", "su",
                        new Kana("ず", "zu")),
                    new Kana("せ", "se",
                        new Kana("ぜ", "ze")),
                    new Kana("そ", "so",
                        new Kana("ぞ", "zo")),
                }, "z"),

                new KanaGroup("t", new List<Kana>
                {
                    new Kana("た", "ta",
                        new Kana("だ", "da")),
                    new Kana("ち", "chi",
                        new Kana("ぢ", "ji")),
                    new Kana("つ", "tsu",
                        new Kana("づ", "dzu")),
                    new Kana("て", "te",
                        new Kana("で", "de")),
                    new Kana("と", "to",
                        new Kana("ど", "do")),
                }, "d"),

                new KanaGroup("n", new List<Kana>
                {
                    new Kana("な", "na"),
                    new Kana("に", "ni"),
                    new Kana("ぬ", "nu"),
                    new Kana("ね", "ne"),
                    new Kana("の", "no"),
                }),

                new KanaGroup("h", new List<Kana>
                {
                    new Kana("は", "ha",
                        new Kana("ば", "ba"),
                        new Kana("ぱ", "pa")),
                    new Kana("ひ", "hi",
                        new Kana("び", "bi"),
                        new Kana("ぴ", "pi")),
                    new Kana("ふ", "fu",
                        new Kana("ぶ", "bu"),
                        new Kana("ぷ", "pu")),
                    new Kana("へ", "he",
                        new Kana("べ", "be"),
                        new Kana("ぺ", "pe")),
                    new Kana("ほ", "ho",
                        new Kana("ぼ", "bo"),
                        new Kana("ぽ", "po")),
                }, "b", "p"),

                new KanaGroup("m", new List<Kana>
                {
                    new Kana("ま", "ma"),
                    new Kana("み", "mi"),
                    new Kana("む", "mu"),
                    new Kana("め", "me"),
                    new Kana("も", "mo"),
                }),

                new KanaGroup("y", new List<Kana>
                {
                    new Kana("た", "ya"),
                    new Kana("ゆ", "yu"),
                    new Kana("よ", "yo"),
                }),

                new KanaGroup("r", new List<Kana>
                {
                    new Kana("ら", "ra"),
                    new Kana("り", "ri"),
                    new Kana("る", "ru"),
                    new Kana("れ", "re"),
                    new Kana("ろ", "ro"),
                }),

                new KanaGroup("w", new List<Kana>
                {
                    new Kana("わ", "wa"),
                    new Kana("を", "wo"),
                }),
            });
        }

        private KanaSystem CreateKatakana()
        {
            return new KanaSystem("Katakana", new List<KanaGroup>
            {
                new KanaGroup("-", new List<Kana>
                {
                    new Kana("ア", "a"),
                    new Kana("イ", "i"),
                    new Kana("ウ", "u"),
                    new Kana("エ", "e"),
                    new Kana("オ", "o"),
                }),

                new KanaGroup("k", new List<Kana>
                {
                    new Kana("カ", "ka",
                        new Kana("ガ", "ga")),
                    new Kana("キ", "ki",
                        new Kana("ギ", "gi")),
                    new Kana("ク", "ku",
                        new Kana("グ", "gu")),
                    new Kana("ケ", "ke",
                        new Kana("ゲ", "ge")),
                    new Kana("コ", "ko",
                        new Kana("ゴ", "go")),
                }, "g"),

                new KanaGroup("s", new List<Kana>
                {
                    new Kana("サ", "sa",
                        new Kana("ザ", "za")),
                    new Kana("シ", "shi",
                        new Kana("ジ", "ji")),
                    new Kana("ス", "su",
                        new Kana("ズ", "zu")),
                    new Kana("セ", "se",
                        new Kana("ゼ", "ze")),
                    new Kana("ソ", "so",
                        new Kana("ゾ", "zo")),
                }, "z"),

                new KanaGroup("t", new List<Kana>
                {
                    new Kana("タ", "ta",
                        new Kana("ダ", "da")),
                    new Kana("チ", "chi",
                        new Kana("ヂ", "ji")),
                    new Kana("ツ", "tsu",
                        new Kana("ヅ", "dzu")),
                    new Kana("テ", "te",
                        new Kana("デ", "de")),
                    new Kana("ト", "to",
                        new Kana("ド", "do")),
                }, "d"),

                new KanaGroup("n", new List<Kana>
                {
                    new Kana("ナ", "na"),
                    new Kana("ニ", "ni"),
                    new Kana("ヌ", "nu"),
                    new Kana("ネ", "ne"),
                    new Kana("ノ", "no"),
                }),

                new KanaGroup("h", new List<Kana>
                {
                    new Kana("ハ", "ha",
                        new Kana("バ", "ba"),
                        new Kana("パ", "pa")),
                    new Kana("ヒ", "hi",
                        new Kana("ビ", "bi"),
                        new Kana("ピ", "pi")),
                    new Kana("フ", "fu",
                        new Kana("ブ", "bu"),
                        new Kana("プ", "pu")),
                    new Kana("ヘ", "he",
                        new Kana("ベ", "be"),
                        new Kana("ペ", "pe")),
                    new Kana("ホ", "ho",
                        new Kana("ボ", "bo"),
                        new Kana("ポ", "po")),
                }, "b", "p"),

                new KanaGroup("m", new List<Kana>
                {
                    new Kana("マ", "ma"),
                    new Kana("ミ", "mi"),
                    new Kana("ム", "mu"),
                    new Kana("メ", "me"),
                    new Kana("モ", "mo"),
                }),

                new KanaGroup("y", new List<Kana>
                {
                    new Kana("ヤ", "ya"),
                    new Kana("ユ", "yu"),
                    new Kana("ヨ", "yo"),
                }),

                new KanaGroup("r", new List<Kana>
                {
                    new Kana("ラ", "ra"),
                    new Kana("リ", "ri"),
                    new Kana("ル", "ru"),
                    new Kana("レ", "re"),
                    new Kana("ロ", "ro"),
                }),

                new KanaGroup("w", new List<Kana>
                {
                    new Kana("ワ", "wa"),
                    new Kana("ヲ", "wo"),
                }),
            });
        }
    }
}
