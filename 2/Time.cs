using System;

namespace _1labasharpcoderev2 {
  public class Time {
    private byte _hours;
    private byte _minutes;

    public byte Hours {
      get => _hours;
      set {
        if (value >= 24) {
          throw new ArgumentOutOfRangeException(
            nameof(value), "Часы должны быть в диапазоне 0-23");
        }
        _hours = value;
      }
    }

    public byte Minutes {
      get => _minutes;
      set {
        if (value >= 60) {
          throw new ArgumentOutOfRangeException(
            nameof(value), "Минуты должны быть в диапазоне 0-59");
        }
        _minutes = value;
      }
    }

    public Time(byte hours, byte minutes) {
      Hours = hours;
      Minutes = minutes;
    }

    public override string ToString() {
      return $"{_hours:D2}:{_minutes:D2}";
    }

    public Time AddMinutes(uint minutesToAdd) {
      int totalMinutes = _hours * 60 + _minutes + (int)minutesToAdd;
      byte newHours = (byte)(totalMinutes / 60 % 24);
      byte newMinutes = (byte)(totalMinutes % 60);
      return new Time(newHours, newMinutes);
    }

    public Time SubtractMinutes(uint minutesToSubtract) {
      int totalMinutes = (_hours * 60 + _minutes) - (int)minutesToSubtract;

      // Корректировка отрицательного времени
      while (totalMinutes < 0) {
        totalMinutes += 1440; // Добавляем сутки
      }

      byte newHours = (byte)(totalMinutes / 60 % 24);
      byte newMinutes = (byte)(totalMinutes % 60);
      return new Time(newHours, newMinutes);
    }

    public static Time operator ++(Time time) => time.AddMinutes(1);
    public static Time operator --(Time time) => time.SubtractMinutes(1);
    public static explicit operator byte(Time time) => time._hours;
    public static implicit operator bool(Time time) => time._hours != 0 || time._minutes != 0;
    public static Time operator +(Time time, uint minutesToAdd) => time.AddMinutes(minutesToAdd);
    public static Time operator -(Time time, uint minutesToSubtract) => time.SubtractMinutes(minutesToSubtract);
  }
}
