namespace Mapper
{
    internal record ProductDto(Guid Id, string Name, decimal Price, int Quantity)
    {
        public override string ToString()
        {
            return $"ID: {Id}, {Environment.NewLine} Name: {Name}, {Environment.NewLine} Price: {Price}, Quantity: {Quantity}";
        }
    };
}
