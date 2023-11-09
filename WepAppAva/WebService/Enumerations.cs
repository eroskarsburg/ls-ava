using System.ComponentModel;
using System.Reflection;
using WebApp.Shared.Enum;

namespace WebApp.WebService
{
    public class Enumerations
    {
        public string ReturnDescriptionModulo(int key)
        {
            switch (key)
            {
                case 1:
                    return GetEnumDescription(EnumModulos.Modulo1);
                case 2:
                    return GetEnumDescription(EnumModulos.Modulo2);
                case 3:
                    return GetEnumDescription(EnumModulos.Modulo3);
                case 4:
                    return GetEnumDescription(EnumModulos.Modulo4);
                case 5:
                    return GetEnumDescription(EnumModulos.Modulo5);
                case 6:
                    return GetEnumDescription(EnumModulos.Modulo6);
                case 7:
                    return GetEnumDescription(EnumModulos.Modulo7);
                case 8:
                    return GetEnumDescription(EnumModulos.Modulo8);
                default: return "";
            }
        }

        public string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (attributes != null && attributes.Any())
            {
                return attributes.First().Description;
            }

            return value.ToString();
        }
    }
}
