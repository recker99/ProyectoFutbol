using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Input;

public class AES
{
    // Clave de 16 bytes (128 bits) para AES
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("1234567890123456"); // Debe ser de 16 bytes
                                                                                     // IV de 16 bytes (128 bits) para AES
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("1234567890123456");  // Debe ser de 16 bytes

    public static string EncryptString(string plainText)
    {
        if (plainText == null) throw new ArgumentNullException(nameof(plainText));

        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }

    // Método para descifrar texto
    public static string DecryptString(string cipherText)
    {
        if (cipherText == null) throw new ArgumentNullException(nameof(cipherText));

        byte[] cipherBytes = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.IV = IV;

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherBytes))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }
    }
}



