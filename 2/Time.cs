using System;

namespace _1labasharpcoderev2 {
    public class Time {
        private byte _hours;
        private byte _minutes;

        public byte Hours {
            get => hours;
            set {
                if (value >= 24) {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "Часы должны быть в диапазоне 0-23");
                }
                hours = value;
            }
        }

        public byte Minutes {
            get => minutes;
            set {
                if (value >= 60) {
                    throw new ArgumentOutOfRangeException(
                        nameof(value), "Минуты должны быть в диапазоне 0-59");
                }
                minutes = value;
            }
        }

        public Time(byte hours, byte minutes) {
            Hours = hours;
            Minutes = minutes;
        }

        public override string ToString() {
            return $"{hours:D2}:{minutes:D2}";
        }

        public Time AddMinutes(uint minutesToAdd) {
            int totalMinutes = hours * 60 + minutes + (int)minutesToAdd;
            byte newHours = (byte)(totalMinutes / 60 % 24);
            byte newMinutes = (byte)(totalMinutes % 60);
            return new Time(newHours, newMinutes);
        }

        public Time SubtractMinutes(uint minutesToSubtract) {
            int totalMinutes = (hours * 60 + minutes) - (int)minutesToSubtract;

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
        public static explicit operator byte(Time time) => time.hours;
        public static implicit operator bool(Time time) => time.hours != 0 || time.minutes != 0;
        public static Time operator +(Time time, uint minutesToAdd) => time.AddMinutes(minutesToAdd);
        public static Time operator -(Time time, uint minutesToSubtract) => time.SubtractMinutes(minutesToSubtract);
    }
}
