namespace Mapper
{
    public static class Helpers
    {
        private static T Cast<T>(object obj)
        {
            return (T)Convert.ChangeType(obj, typeof(T));
        }
    }
}
