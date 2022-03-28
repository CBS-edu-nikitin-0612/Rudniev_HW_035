using System;

namespace Task2
{
    public class Temperature
    {
        private double current;
        private TemperatureUnit unit;

        public double Current 
        { 
            get => current;
            set
            {
                switch (unit)
                {
                    case TemperatureUnit.celsius:
                        if (value >= -273.15)
                            current = value;
                        else
                            current = 0;
                        break;
                    case TemperatureUnit.fahrenheit:
                        if (value >= -459.67)
                            current = value;
                        else
                            current = 0;
                        break;
                    case TemperatureUnit.kelvin:
                        if (value >= 0)
                            current = value;
                        else
                            current = 0;
                        break;
                }
            }
        }
        public TemperatureUnit Unit { get => unit; }

        public Temperature() : this(0, TemperatureUnit.celsius) { }
        public Temperature(double current) : this(current, TemperatureUnit.celsius) { }
        public Temperature(double current, TemperatureUnit unit)
        {
            this.unit = unit;
            Current = current;
            Console.WriteLine("Temperature obj created!");
        }

        public override string ToString()
        {
            return $"t = {current} {unit}";
        }
        public bool ConvertToFahrenheit()
        {
            switch (unit)
            {
                case TemperatureUnit.celsius:
                    current = current * 1.8 + 32;
                    unit = TemperatureUnit.fahrenheit;
                    return true;
                    break;
                case TemperatureUnit.fahrenheit:
                    return false;
                    break;
                case TemperatureUnit.kelvin:
                    current = (current + 459.67) * 5 / 9;
                    unit = TemperatureUnit.fahrenheit;
                    return true;
                    break;
            }
            return false;
        }
        public bool ConvertToCelsius()
        {
            switch (unit)
            {
                case TemperatureUnit.celsius:
                    return false;
                    break;
                case TemperatureUnit.fahrenheit:
                    current = (current - 32) / 1.8;
                    unit = TemperatureUnit.celsius;
                    return true;
                    break;
                case TemperatureUnit.kelvin:
                    current = current - 273.15;
                    unit = TemperatureUnit.celsius;
                    return true;
                    break;
            }
            return false;
        }
        public bool ConvertToKelvin()
        {
            switch (unit)
            {
                case TemperatureUnit.celsius:
                    current = current + 273.15;
                    unit = TemperatureUnit.kelvin;
                    return true;
                    break;
                case TemperatureUnit.fahrenheit:
                    current = current * 1.8 - 459.67;
                    unit = TemperatureUnit.kelvin;
                    return true;
                    break;
                case TemperatureUnit.kelvin:
                    return false;
                    break;
            }
            return false;
        }
    }
}
