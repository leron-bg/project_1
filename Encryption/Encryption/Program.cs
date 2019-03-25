using System;
using System.Security.Cryptography;

namespace Encryption
{
	class Program
	{
		static void Main(string[] args)
		{
			var assymetric = new Assymetric();
			var data = new byte[] { 1, 2, 3, 4, 5 };

			using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
			{
				var encrypted = assymetric.Encrypt(data, rsa.ExportParameters(false));
				Console.WriteLine("Encrypted data:");
				var output = string.Join(",", encrypted);
				Console.WriteLine(output);

				Console.WriteLine("Decrypted data:");
				Console.WriteLine(string.Join(",", assymetric.Decrypt(encrypted, rsa.ExportParameters(true))));
			}
		}
	}
}
