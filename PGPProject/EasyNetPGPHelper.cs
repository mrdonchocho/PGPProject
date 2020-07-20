using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EasyNetPGP;

namespace PGPProject
{
    class EasyNetPGPHelper
    {
        //This should be set in webconfig??
        private static string PlainDirPath = @"C:\PGPPlainTesting\";
        private static string EncDirPath = @"C:\PGPEncryptedTesting\";
        private static string DecDirPath = @"C:\PGPDecryptedTesting\";
        private static string privateKeyPath = @"C:\PGPPrivateKeyTesting\";
        private static string password = "password";
        private static string username = "donchocho@example.com";
        private static  string keyStorePath = @"C:\PGPStore\";
        private static readonly string privateKeyName = "private.asc";
        private static readonly string publicKeyName = "public.asc";

        public bool EncrptWithPGP(string encryptedFile, string plainFile, string PGPKey, bool armor =true, bool withIntegrityCheck = true)
        {
            bool result = false;
            PlainDirPath = !string.IsNullOrEmpty(PlainDirPath) ? PlainDirPath : @"C:\PGPPlainFiles\";
            EncDirPath = !string.IsNullOrEmpty(EncDirPath) ? EncDirPath : @"C:\PGPEncryptedFiles\";
            keyStorePath = !string.IsNullOrEmpty(keyStorePath) ? keyStorePath : @"C:\PGPStore\";
            string plainFilePath = PlainDirPath + plainFile;
            string encryptedFilePath = EncDirPath + encryptedFile;
            string PGPKeyPath = keyStorePath + PGPKey;
            if (!Directory.Exists(PlainDirPath))
            {
                DirectoryInfo PlainDirectory = Directory.CreateDirectory(PlainDirPath);
            }
            if (!Directory.Exists(EncDirPath))
            {
                DirectoryInfo EncDirectory = Directory.CreateDirectory(EncDirPath);
            }
            if (!Directory.Exists(keyStorePath))
            {
                DirectoryInfo KeyDirectory = Directory.CreateDirectory(keyStorePath);
            }
            if (!string.IsNullOrEmpty(encryptedFilePath) && !string.IsNullOrEmpty(plainFilePath) && !string.IsNullOrEmpty(PGPKey))
                {
                    PgpEncryptorDecryptor.EncryptFile(encryptedFilePath, plainFilePath, PGPKeyPath, armor, withIntegrityCheck);

                    if (File.Exists(encryptedFilePath))
                {
                    FileInfo encFile = new FileInfo(encryptedFilePath);
                    if (encFile.Length > 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool DecrptWithPGP(string encryptedFile, string decryptedFile, string privateKey)
        {
            bool result = false;
            EncDirPath = !string.IsNullOrEmpty(EncDirPath) ? EncDirPath : @"C:\PGPEncryptedFiles\";
            DecDirPath = !string.IsNullOrEmpty(DecDirPath) ? DecDirPath : @"C:\PGPDecryptedFiles\";
            keyStorePath = !string.IsNullOrEmpty(keyStorePath) ? keyStorePath : @"C:\PGPStore\";
            string PGPKeyPath = keyStorePath + privateKey;
            string encryptedFilePath = EncDirPath + encryptedFile;
            string decryptedFilePath = DecDirPath + decryptedFile;
            if (!Directory.Exists(EncDirPath))
            {
                DirectoryInfo EncDirectory = Directory.CreateDirectory(EncDirPath);
            }
            if (!Directory.Exists(DecDirPath))
            {
                DirectoryInfo DecDirectory = Directory.CreateDirectory(DecDirPath);
            }
            if (!Directory.Exists(keyStorePath))
            {
                DirectoryInfo KeyDirectory = Directory.CreateDirectory(keyStorePath);
            }
            if (!string.IsNullOrEmpty(encryptedFilePath) && !string.IsNullOrEmpty(PGPKeyPath) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(decryptedFilePath))
            {
                PgpEncryptorDecryptor.DecryptFile(encryptedFilePath, PGPKeyPath, password, decryptedFilePath);               
                
                if (File.Exists(decryptedFilePath))
                {
                    FileInfo decFile = new FileInfo(decryptedFilePath);
                    if (decFile.Length > 1)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
                else
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            return result;
        }

        public bool GenerateKeyPairWithPGP()
        {
            bool result = false;
            privateKeyPath = !string.IsNullOrEmpty(privateKeyPath) ? privateKeyPath : @"C:\PGPEncryptedFiles\";
            if (!Directory.Exists(privateKeyPath))
            {
                DirectoryInfo privateKeyPathDirectory = Directory.CreateDirectory(privateKeyPath);
            }
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(keyStorePath) && !string.IsNullOrEmpty(privateKeyName) && !string.IsNullOrEmpty(publicKeyName))
            {
                KeyGenerator.GenerateKeyPair(username, password, keyStorePath, privateKeyName, publicKeyName);
                result = true;
            }
                return result;
        }
    }
}
