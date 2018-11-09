using System;
using System.Collections;

namespace Solution.Core.Extensions
{
    public static class TypeExtensions
    {
        public static IDictionary ToDictionary(this Type type)
        {
            return type?.GetProperties().ToDictionary();
        }
    }
}
