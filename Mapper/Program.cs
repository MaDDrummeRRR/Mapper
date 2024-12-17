using Mapper;

var product = new Product(Guid.NewGuid(), "Motor", 157, 3);

SimpleMapper mapper = new();

var productDto = mapper.MapBetween<Product, ProductDto>(product);

Console.WriteLine("----------MODEL-------------");
Console.WriteLine(product);
Console.WriteLine("----------DTO---------------");
Console.WriteLine(productDto);