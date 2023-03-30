using System.Security.Cryptography;
using System.Text;
using Core.Cryptography;

namespace Application.Cryptography;

public class HashStringWithSha512Service : IHashStringWithSha512Service
{
    private readonly byte[] _saltBytes = { 2, 1, 7, 3, 6, 4, 8, 5 };
    private const int Iterations = 1000;
    private const int KeySize = 300;
    
    public string HashString(string text)
    {
        var textBytes = Encoding.UTF8.GetBytes(text);
        var derivedKeyBytes = Rfc2898DeriveBytes
            .Pbkdf2(textBytes, _saltBytes, Iterations, HashAlgorithmName.SHA512, KeySize);

        return Convert.ToHexString(derivedKeyBytes);
    }
}