using System.Security.Cryptography;

namespace Encryption
{
	public class Assymetric
	{
		public byte[] Encrypt(byte[] data, RSAParameters RSAKeyInfo)
		{
			byte[] encrypted;
			using (var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(RSAKeyInfo);
				encrypted = rsa.Encrypt(data, true);
			}

			return encrypted;
		}

		public byte[] Decrypt(byte[] data, RSAParameters RSAKeyInfo)
		{
			byte[] decrypted;
			using (var rsa = new RSACryptoServiceProvider())
			{
				rsa.ImportParameters(RSAKeyInfo);
				decrypted = rsa.Decrypt(data, true);
			}

			return decrypted;
		}
	}
}
