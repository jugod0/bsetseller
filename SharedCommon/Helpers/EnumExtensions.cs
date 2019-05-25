using System;
using System.Diagnostics;

namespace SharedCommon.Helpers
{
    public static class EnumExtensions
    {
        public static T ConvertTo<T>(this Enum value)
            where T : Enum
        {
            try
            {
                return (T)Enum.Parse(typeof(T), value.ToString());
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return default(T);
            }
            
        }
    }
}
