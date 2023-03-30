namespace Core.Cryptography;

public interface IHashStringWithSha512Service
{
    string HashString(string text);
}