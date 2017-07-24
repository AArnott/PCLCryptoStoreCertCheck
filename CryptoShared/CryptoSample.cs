using System;
using System.Linq;
using System.Text;
using PCLCrypto;

namespace CryptShared
{
    public static class CryptoSample
    {
        public static string GetPlaintext()
        {
            var aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(SymmetricAlgorithm.AesCbcPkcs7);
            var keyMaterial = WinRTCrypto.CryptographicBuffer.GenerateRandom(aes.LegalKeySizes.First().First());
            var key = aes.CreateSymmetricKey(keyMaterial);
            var iv = WinRTCrypto.CryptographicBuffer.GenerateRandom(aes.BlockLength);
            byte[] plainText = Encoding.UTF8.GetBytes("Hello world");
            byte[] cipherBytes = WinRTCrypto.CryptographicEngine.Encrypt(key, plainText, iv);
            string cipherText = Convert.ToBase64String(cipherBytes);
            return cipherText;
        }
    }
}
