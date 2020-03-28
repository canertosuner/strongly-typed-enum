using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public sealed class Bank
{
    public static Bank Ziraat { get; } = new Bank(10, "Ziraat", "Ziraat Bankası", "08:30 – 17:00");
    public static Bank Garanti { get; } = new Bank(62, "Garanti", "Garanti Bankası", "09:00 – 17:15");
    public static Bank Isbank { get; } = new Bank(64, "Isbank", "İş Bankası", "09:00 – 17:00");
    public static Bank YapiKredi { get; } = new Bank(67, "YapiKredi", "Yapı Kredi Bankası", "09:00 – 16:45");



    private Bank(int eftCode, string name, string description, string processingTime)
    {
        EftCode = eftCode;
        Name = name;
        Description = description;
        ProcessingTime = processingTime;
    }

    public int EftCode { get; }
    public string Name { get; }
    public string Description { get; }
    public string ProcessingTime { get; }



    #region helper functions
    public override string ToString() => Name;
    public static IEnumerable<string> GetNames() => GetValues().Select(role => role.Name);
    public static Bank GetValue(int code) => GetValues().First(role => role.EftCode == code);
    public static Bank GetValue(string name) => GetValues().First(role => role.Name == name);

    public static IReadOnlyList<Bank> GetValues()
    {
        return typeof(Bank).GetProperties(BindingFlags.Public | BindingFlags.Static)
            .Select(property => (Bank)property.GetValue(null))
            .ToList();
    }

    public static explicit operator int(Bank role) => role.EftCode;
    public static explicit operator Bank(int code) => GetValue(code);
    #endregion
}