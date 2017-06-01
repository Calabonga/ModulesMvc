namespace ModulesContracts
{
    public interface ICalculatorOperation
    {
        int Calculate(int x, int y);
        string Name{ get; }
    }
}