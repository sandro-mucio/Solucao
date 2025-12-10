using Persistencia;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public static class Crypto
    {
        public enum EncMode
        {
            ASCII,
            UNICODE,
            UTF7,
            UTF8
        }
        public enum HashMode
        {
            MD5,
            SHA1,
            SHA256,
            SHA384,
            SHA512
        }
        public enum AlgList
        {
            RINJNDAEL,
            DES,
            TRIPLEDES,
            RC2
        }
        //public Crypto() { }
        //byte[] EncodedArray = EncString("QualquerString",MyCryptoLib.EncMode.UTF8);
        public static byte[] EncString(string strIn, EncMode mMode)
        {
            switch (mMode)
            {
                case EncMode.UNICODE:
                    return System.Text.Encoding.Unicode.GetBytes(strIn);
                case EncMode.UTF7:
                    return System.Text.Encoding.UTF7.GetBytes(strIn);
                case EncMode.UTF8:
                    return System.Text.Encoding.UTF8.GetBytes(strIn);
                default:
                    return System.Text.Encoding.ASCII.GetBytes(strIn);
            }
        }
        public static byte[] EncString(string strIn)
        {
            return EncString(strIn, EncMode.ASCII);
        }
        public static byte[] CalcHashByteArray(byte[] Dados, HashMode hMode)
        {
            HashAlgorithm hash;
            switch (hMode)
            {
                case HashMode.SHA1:
                    hash = new SHA1CryptoServiceProvider();
                    break;
                case HashMode.SHA256:
                    hash = new SHA256Managed();
                    break;
                case HashMode.SHA384:
                    hash = new SHA384Managed();
                    break;
                case HashMode.SHA512:
                    hash = new SHA512Managed();
                    break;
                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }
            hash.Initialize();
            return hash.ComputeHash(Dados);
        }
        public static byte[] CalcHashByteArray(byte[] Dados)
        {
            return CalcHashByteArray(Dados, HashMode.MD5);
        }
        public static string CalcHashHex(string strIn, EncMode mMode, HashMode hMode)
        {
            byte[] arrEnc = EncString(strIn, mMode);
            byte[] bArrhAlg = CalcHashByteArray(arrEnc, hMode);
            StringBuilder sbHash = new StringBuilder();
            for (int i = 0; i < bArrhAlg.Length; i++)
            { sbHash.Append(bArrhAlg[i].ToString("X2")); }
            return sbHash.ToString();
        }
        public static string CalcHashHex(string strIn, EncMode mMode)
        {
            return CalcHashHex(strIn, mMode, HashMode.MD5);
        }
        public static string CalcHashHex(string strIn, HashMode hMode)
        {
            return CalcHashHex(strIn, EncMode.UTF8, hMode);
        }
        public static string CalcHashHex(string strIn)
        {
            return CalcHashHex(strIn, EncMode.UTF8, HashMode.MD5);
        }
        public static string CalcHashBase64(string strIn, EncMode mMode, HashMode hMode)
        {
            byte[] arrEnc = EncString(strIn, mMode);
            return Convert.ToBase64String(CalcHashByteArray(arrEnc, hMode));
        }
        public static string CalcHashBase64(string strIn, EncMode mMode)
        {
            return CalcHashBase64(strIn, mMode, HashMode.MD5);
        }
        public static string CalcHashBase64(string strIn, HashMode hMode)
        {
            return CalcHashBase64(strIn, EncMode.UTF8, hMode);
        }
        public static string CalcHashBase64(string strIn)
        {
            return CalcHashBase64(strIn, EncMode.UTF8, HashMode.MD5);
        }
        public static byte[] Encryptar(byte[] naoEncriptado, string Pwd, AlgList alg)
        {
            return CryptoMagic(naoEncriptado, Pwd, alg, true);
        }
        public static byte[] Encryptar(byte[] naoEncriptado, string Pwd)
        {
            return Encryptar(naoEncriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static byte[] Encryptar(string strNaoEncriptado, string Pwd, AlgList alg)
        {
            byte[] naoEncriptado = System.Text.Encoding.Unicode.GetBytes(strNaoEncriptado);
            return Encryptar(naoEncriptado, Pwd, alg);
        }
        public static byte[] Encryptar(string strNaoEncriptado, string Pwd)
        {
            return Encryptar(strNaoEncriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static byte[] desEncryptar(byte[] Encriptado, string Pwd, AlgList alg)
        {
            return CryptoMagic(Encriptado, Pwd, alg, false);
        }
        public static byte[] desEncryptar(byte[] Encriptado, string Pwd)
        {
            return desEncryptar(Encriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static byte[] desEncryptar(string base64Encriptado, string Pwd, AlgList alg)
        {
            byte[] Encriptado = Convert.FromBase64String(base64Encriptado);
            return desEncryptar(Encriptado, Pwd, alg);
        }
        public static byte[] desEncryptar(string base64Encriptado, string Pwd)
        {
            return desEncryptar(base64Encriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static string EncryptarStrToBase64(string strNaoEncriptado, string Pwd, AlgList alg)
        {
            byte[] Dados = System.Text.Encoding.Unicode.GetBytes(strNaoEncriptado);
            return Convert.ToBase64String(Encryptar(Dados, Pwd, alg));
        }
        public static string EncryptarStrToBase64(string strNaoEncriptado, string Pwd)
        {
            return EncryptarStrToBase64(strNaoEncriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static string desEncryptarBase64ToStr(string strBase64Encriptado, string Pwd, AlgList alg)
        {
            byte[] Dados = desEncryptar(strBase64Encriptado, Pwd, alg);
            return System.Text.Encoding.Unicode.GetString(Dados);
        }
        public static string desEncryptarBase64ToStr(string strBase64Encriptado, string Pwd)
        {
            return desEncryptarBase64ToStr(strBase64Encriptado, Pwd, AlgList.RINJNDAEL);
        }
        public static void EncryptarFile(string fileDecrypted, string fileEncrypted, string Pwd, AlgList alg)
        {
            CryptoMagicFile(fileEncrypted, fileDecrypted, Pwd, alg, true);
        }
        public static void EncryptarFile(string fileDecrypted, string fileEncrypted, string Pwd)
        {
            CryptoMagicFile(fileEncrypted, fileDecrypted, Pwd, AlgList.RINJNDAEL, true);
        }
        public static void desEncryptarFile(string fileEncrypted, string fileDecrypted, string Pwd, AlgList alg)
        {
            CryptoMagicFile(fileEncrypted, fileDecrypted, Pwd, alg, false);
        }
        public static void desEncryptarFile(string fileEncrypted, string fileDecrypted, string Pwd)
        {
            CryptoMagicFile(fileEncrypted, fileDecrypted, Pwd, AlgList.RINJNDAEL, false);
        }
        private static PasswordDeriveBytes MyPDB(string Pwd)
        {
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Pwd, new byte[]
            {   0x40, 0x6e, 0x64, 0x72, 0x33, 0x76, 0x33, 0x31,
                0x31, 0x30, 0x35, 0x30, 0x2e, 0x6e, 0x65, 0x74}, "SHA512", 100);
            return pdb;
        }
        private static CryptoStream MyCStream(MemoryStream msEnc, string Pwd, AlgList alg, bool toEnc)
        {
            CryptoStream cStream;

            PasswordDeriveBytes EncPdb = MyPDB(Pwd);

            switch (alg)
            {
                case AlgList.DES:

                    DES encAlgDES = DES.Create();

                    encAlgDES.Key = EncPdb.GetBytes(8);

                    encAlgDES.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgDES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgDES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                case AlgList.TRIPLEDES:

                    TripleDES encAlg3DES = TripleDES.Create();

                    encAlg3DES.Key = EncPdb.GetBytes(24);

                    encAlg3DES.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlg3DES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlg3DES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                case AlgList.RC2:

                    RC2 encAlgRC2 = RC2.Create();

                    encAlgRC2.Key = EncPdb.GetBytes(16);

                    encAlgRC2.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgRC2.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgRC2.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                default:

                    Rijndael encAlgR = Rijndael.Create();

                    encAlgR.Key = EncPdb.GetBytes(32);

                    encAlgR.IV = EncPdb.GetBytes(16);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgR.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(msEnc,
                            encAlgR.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
            }

            return cStream;
        }
        private static byte[] CryptoMagic(byte[] EncriptadoOuNao, string Pwd, AlgList alg, bool toEnc)
        {
            MemoryStream msEnc = new MemoryStream();

            CryptoStream crypStream = MyCStream(msEnc, Pwd, alg, toEnc);
            crypStream.Write(EncriptadoOuNao, 0, EncriptadoOuNao.Length);
            crypStream.Close();
            byte[] MagicCryptoResult = msEnc.ToArray();
            return MagicCryptoResult;
        }
        private static void CryptoMagicFile(string fileEncrypted, string fileDecrypted, string Pwd, AlgList alg, bool toEnc)
        {
            FileStream fsIn;

            FileStream fsOut;

            if (toEnc)
            {
                fsIn = new FileStream(fileDecrypted,
                    FileMode.Open, FileAccess.Read);
                fsOut = new FileStream(fileEncrypted,
                    FileMode.OpenOrCreate, FileAccess.Write);
            }
            else
            {
                fsIn = new FileStream(fileEncrypted,
                    FileMode.Open, FileAccess.Read);
                fsOut = new FileStream(fileDecrypted,
                    FileMode.OpenOrCreate, FileAccess.Write);
            }

            CryptoStream cStream;

            PasswordDeriveBytes EncPdb = MyPDB(Pwd);

            switch (alg)
            {
                case AlgList.DES:

                    DES encAlgDES = DES.Create();

                    encAlgDES.Key = EncPdb.GetBytes(8);

                    encAlgDES.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgDES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgDES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                case AlgList.TRIPLEDES:

                    TripleDES encAlg3DES = TripleDES.Create();

                    encAlg3DES.Key = EncPdb.GetBytes(24);

                    encAlg3DES.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlg3DES.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlg3DES.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                case AlgList.RC2:

                    RC2 encAlgRC2 = RC2.Create();

                    encAlgRC2.Key = EncPdb.GetBytes(16);

                    encAlgRC2.IV = EncPdb.GetBytes(8);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgRC2.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgRC2.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
                default:

                    Rijndael encAlgR = Rijndael.Create();

                    encAlgR.Key = EncPdb.GetBytes(32);

                    encAlgR.IV = EncPdb.GetBytes(16);
                    if (toEnc)
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgR.CreateEncryptor(), CryptoStreamMode.Write);
                    }
                    else
                    {
                        cStream = new CryptoStream(fsOut,
                            encAlgR.CreateDecryptor(), CryptoStreamMode.Write);
                    }
                    break;
            }

            int bufferLen = 4096;

            byte[] buffer = new byte[bufferLen];

            int bytesRead;
            do
            {
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                cStream.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            cStream.Close();

            fsIn.Close();
        }
    }

    public class BancoDados 
    {
        private string cnn = String.Empty;

        public BancoDados(string conexao) 
        {
            this.cnn = conexao;
        }
        public BancoDados(string DataSource, string Catalog, string User, string Password)
        {
            this.cnn = $"Data Source={DataSource};Initial Catalog={Catalog};Persist Security Info=False;User ID={User};Password={Password};";
        }

        public void Criar() 
        {
            try
            {
                DCBancoDataContext bco = new DCBancoDataContext(cnn);
                if (!bco.DatabaseExists())
                {
                    bco.CreateDatabase();
                    UsuarioBO bo = new UsuarioBO(cnn);
                    bo.inserir("Sandro", "admin", Crypto.EncryptarStrToBase64("123", "solucao"), "email@email.com", "", 0);
                }
                else
                {
                    throw new Exception("Banco de Dados Já Existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }

    public class Aplicacao1 
    {
        private string cnn = String.Empty;

        public Aplicacao1(string conexao)
        {
            this.cnn = conexao;
        }
        public Aplicacao1(string DataSource, string Catalog, string User, string Password)
        {
            this.cnn = $"Data Source={DataSource};Initial Catalog={Catalog};Persist Security Info=False;User ID={User};Password={Password};";
        }

        public void Criar()
        {
            try
            {
                DCAplicacaoDataContext bco = new DCAplicacaoDataContext(cnn);
                if (!bco.DatabaseExists())
                {
                    bco.CreateDatabase();
                }
                else
                {
                    throw new Exception("Banco de Aplicação Já Existe.");
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
