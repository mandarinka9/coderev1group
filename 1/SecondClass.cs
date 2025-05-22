using System;
using System.Linq;

namespace _1labasharpcoderev {
    public class SecondClass : FirstClass {
        public DateTime CreatedAt { get; }

        public SecondClass(string text) : base(text) {
            CreatedAt = DateTime.Now;
        }

        public int Length => Text.Length;

        public string Vverh() {
            return Text.ToUpper();
        }

        public int CountGlas() {
            const string vowels = "aeiouyаеёиоуыэюя";
            return Text.ToLower()
                      .Where(c => char.IsLetter(c) && vowels.Contains(c))
                      .Count();
        }

        public override string ToString() {
            return $"{base.ToString()}, Дата создания: {CreatedAt}";
        }
    }
}
