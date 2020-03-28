using System;

namespace SmartEnum
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = Bank.Garanti;
            switch (value)
            {
                case var _ when value == Bank.Garanti:
                    break;
                case var _ when value == Bank.Isbank:
                    break;
                case var _ when value == Bank.Ziraat:
                    break;
                case var _ when value == Bank.YapiKredi:
                    break;
            }

            Console.WriteLine(nameof(value.EftCode) + ":" + value.EftCode);
            Console.WriteLine(nameof(value.Name) + ":" + value.Name);
            Console.WriteLine(nameof(value.Description) + ":" + value.Description);
            Console.WriteLine(nameof(value.ProcessingTime) + ":" + value.ProcessingTime);

            var all = Bank.GetValues();
        }
    }
}