using System.Runtime.CompilerServices;

namespace Mapper
{
    public class SimpleMapper
    {
        public TOut MapBetween<TIn, TOut>(TIn inputClass)
        {
            #region IN section

            var typeIn = typeof(TIn);

            var propertiesIn = typeIn.GetProperties();

            Dictionary<string, (Type, object?)> typeInProperties = new();

            foreach (var property in propertiesIn)
                typeInProperties.Add(property.Name, (property.PropertyType, property.GetValue(inputClass)));

            #endregion

            #region OUT section

            var typeOut = typeof(ProductDto);

            var propertiesOut = typeOut.GetProperties();

            var outClass = (TOut)RuntimeHelpers.GetUninitializedObject(typeof(TOut));

            foreach (var property in propertiesOut)
            {
                if (typeInProperties.TryGetValue(property.Name, out var value))
                {
                    object? valWithRealType = default;

                    if (property.PropertyType == value.Item1)
                    {
                        if (property.PropertyType == typeof(Guid))
                            valWithRealType = Guid.Parse(value.Item2.ToString());
                        else
                            valWithRealType = Convert.ChangeType(value.Item2, value.Item1);
                    }

                    property.SetValue(outClass, valWithRealType, null);
                }
                else
                {
                    property.SetValue(outClass, default, null);
                }
            }

            return outClass;

            #endregion
        }
    }
}
