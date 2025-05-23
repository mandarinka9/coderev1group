using System;

namespace _1labasharpcoderev {
  public partial class FirstClass {
    public string Text { get; set; }

    // Конструктор с проверкой на пустую строку
    public FirstClass(string text) {
      Text = text ?? string.Empty;
    }

    // Конструктор копирования
    public FirstClass(FirstClass other) {
      if (other == null) {
        throw new ArgumentNullException(nameof(other));
      }

      Text = other.Text;
    }

    // Создает строку из первого и последнего символа
    public string FirstAndLast() {
      if (string.IsNullOrWhiteSpace(Text)) {
        return string.Empty;
      }

      return $"{Text[0]}{Text[Text.Length - 1]}";
    }

    public override string ToString() {
      return $"Text: {Text}";
    }
  }
}
