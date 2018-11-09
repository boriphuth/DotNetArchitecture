namespace Solution.Core.Security
{
    public interface IHash
    {
        string Create(string value);
    }
}
