using Newtonsoft.Json;
using System;

namespace XamarinGram.Helpers
{
    public class Clonner
    {
        public static T Clone<T>(object source)
        {
            try
            {
                var serialized = JsonConvert.SerializeObject(source);
                return JsonConvert.DeserializeObject<T>(serialized);
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }
}
