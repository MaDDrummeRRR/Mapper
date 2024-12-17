using Mapper;
using System.Runtime.CompilerServices;

var product = new Product(Guid.NewGuid(), "Motor", 157, 3);


var type = typeof(Product);

var properties = type.GetProperties();

Dictionary<string, (Type, object?)> typeProperties = new();

foreach (var property in properties)
    typeProperties.Add(property.Name, (property.PropertyType, property.GetValue(product)));


var typeDto = typeof(ProductDto);

var propertiesDto = typeDto.GetProperties();

var dto = (ProductDto)RuntimeHelpers.GetUninitializedObject(typeof(ProductDto));

foreach (var property in propertiesDto)
{
    if (typeProperties.TryGetValue(property.Name, out var value))
    {
        object valWithRealType = default;
        if (property.PropertyType == value.Item1)
        {

            if (property.PropertyType == typeof(Guid))
                valWithRealType = Guid.Parse(value.Item2.ToString());
            else
                valWithRealType = Convert.ChangeType(value.Item2, value.Item1);
        }

        property.SetValue(dto, valWithRealType, null);
    }
    else
    {
        property.SetValue(dto, default, null);
    }
}