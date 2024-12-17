namespace Mapper
{
    internal record Product(Guid Id, string Name, decimal Price, int Quantity)
    {
        public override string ToString()
        {
            return $"ID: {Id}, {Environment.NewLine} Name: {Name}, {Environment.NewLine} Price: {Price}, Quantity: {Quantity}";
        }
    };
}