namespace Solution.Core.Security
{
    public interface ICriptography
    {
        string Decrypt(string value);

        string Encrypt(string value);
    }
}
