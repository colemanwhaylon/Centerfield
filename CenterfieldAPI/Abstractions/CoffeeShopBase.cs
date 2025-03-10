namespace CenterfieldAPI.Abstractions
{
    public abstract class CoffeeShopBase
    {
        public abstract string Name { get; set; }
        public abstract TimeOnly OpeningTime { get; set; }
        public abstract TimeOnly ClosingTime { get; set; }

    }

    public class B : CoffeeShopBase
    {
        public override string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override TimeOnly OpeningTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public override TimeOnly ClosingTime { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
