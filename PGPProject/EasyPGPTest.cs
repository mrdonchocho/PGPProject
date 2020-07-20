using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetPGP;

namespace PGPProject
{
    class EasyPGPTest
    {
        string username = "test@gmail.com";
        string password = "password1";
        string keyStorePath = @"C:\Temp";

        // Uses the default Private / Public key file names
        EasyNetPGP.KeyGenerator.
        KeyGenerator.GenerateKeyPair(username, password, keyStorePath);

        string privateKeyName = "private.asc";
        string publicKeyName = "public.asc";

        // Uses the provided Private / Public key file names
        KeyGenerator.GenerateKeyPair(username, password, keyStorePath, privateKeyName, publicKeyName);


        //Encrypt a File
        string ENCoutFilePath = @"C:\Temp\SecretText.txt";
        string ENCinFilePath = @"C:\Temp\PlainText.txt";
        string publicKeyFilePath = @"C:\Temp\public.asc";

        PgpEncryptorDecryptor.EncryptFile(ENCoutFilePath, ENCinFilePath, publicKeyFilePath);

        //Decrypt a File
        string inFilePath = @"C:\Temp\SecretText.txt";
        string privateKeyFilePath = @"C:\Temp\private.asc";
        string password = "password1";
        string outFilePath = @"C:\Temp\PlainText.txt";

        PgpEncryptorDecryptor.DecryptFile(inFilePath, privateKeyFilePath, password, outFilePath);
    }
}
