using System;

namespace _1labasharpcoderev2 {
  public class Program {
    public static void Main() {
      try {
        Console.WriteLine("Введите часы (0-23):");
        byte hours = Convert.ToByte(Console.ReadLine());

        Console.WriteLine("Введите минуты (0-59):");
        byte minutes = Convert.ToByte(Console.ReadLine());

        Time time = new Time(hours, minutes);
        Console.WriteLine($"Исходное время: {time}");

        // Тестирование добавления минут
        Console.WriteLine("Введите количество минут для добавления:");
        uint minutesToAdd = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine($"Время после добавления {minutesToAdd} минут: {time + minutesToAdd}");

        // Тестирование инкремента/декремента
        Console.WriteLine($"Время после инкремента: {++time}");
        Console.WriteLine($"Время после декремента: {--time}");

        // Тестирование преобразований
        Console.WriteLine($"Только часы: {(byte)time}");
        Console.WriteLine($"Является ли время ненулевым: {(bool)time}");

        // Тестирование вычитания минут
        Console.WriteLine("Введите количество минут для вычитания:");
        uint minutesToSubtract = Convert.ToUInt32(Console.ReadLine());
        Console.WriteLine($"Время после вычитания {minutesToSubtract} минут: {time - minutesToSubtract}");
      }
      catch (FormatException) {
        Console.WriteLine("Ошибка: введено некорректное число");
      }
      catch (OverflowException) {
        Console.WriteLine("Ошибка: число вне допустимого диапазона");
      }
      catch (ArgumentOutOfRangeException ex) {
        Console.WriteLine($"Ошибка: {ex.Message}");
      }
      catch (Exception ex) {
        Console.WriteLine($"Неожиданная ошибка: {ex.Message}");
      }

      Console.WriteLine("\nНажмите любую клавишу для выхода...");
      Console.ReadKey();
    }
  }
}
