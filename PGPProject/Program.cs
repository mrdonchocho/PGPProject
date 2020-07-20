using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetPGP;

namespace PGPProject
{
    class Program
    {
        static void Main(string[] args)
        {
            EasyNetPGPHelper pg = new EasyNetPGPHelper();
            //  pg.GenerateKeyPairWithPGP();
            string encryptedFile = @"SecretText.pgp";
            string plainFile = @"PlainText.txt";
            string publicKey = @"public.asc";
          pg.EncrptWithPGP(encryptedFile, plainFile, publicKey);
            string decryptedFile = @"decryptedFile.txt";
            string privateKey = @"private.asc";
            pg.DecrptWithPGP(encryptedFile, decryptedFile, privateKey);
        }
    }
}
