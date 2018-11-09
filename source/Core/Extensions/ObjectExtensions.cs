using Newtonsoft.Json;
using System.Text;

namespace Solution.Core.Extensions
{
    public static class ObjectExtensions
    {
        public static byte[] ToBytes(this object obj)
        {
            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(obj));
        }
    }
}
