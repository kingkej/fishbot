// Decompiled with JetBrains decompiler
// Type: gta_rp.EncryptClass
// Assembly: gta_rp, Version=2.0.1.0, Culture=neutral, PublicKeyToken=null
// MVID: ECA622CB-C917-4D95-A704-C8C915433E14
// Assembly location: C:\Users\Kej\Desktop\bot\gta_rp.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace gta_rp
{
  public static class EncryptClass
  {
    public static string pass = "Antony41";
    public static string EncryptDelimiter = "nYp=pCa";

    public static string Encrypt(
      string plainText,
      string password,
      string salt = "Zakonqwe",
      string hashAlgorithm = "SHA512",
      int passwordIterations = 2,
      string initialVector = "Pms2cn43Qk*c9nxI",
      int keySize = 256)
    {
      if (string.IsNullOrEmpty(plainText))
        return "";
      byte[] bytes1 = Encoding.ASCII.GetBytes(initialVector);
      byte[] bytes2 = Encoding.ASCII.GetBytes(salt);
      byte[] bytes3 = Encoding.UTF8.GetBytes(plainText);
      byte[] bytes4 = new PasswordDeriveBytes(password, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      byte[] inArray = (byte[]) null;
      using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(bytes4, bytes1))
      {
        using (MemoryStream memoryStream = new MemoryStream())
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
          {
            cryptoStream.Write(bytes3, 0, bytes3.Length);
            cryptoStream.FlushFinalBlock();
            inArray = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
          }
        }
      }
      rijndaelManaged.Clear();
      return Convert.ToBase64String(inArray);
    }

    public static string Decrypt(
      string cipherText,
      string password,
      string salt = "Zakonqwe",
      string hashAlgorithm = "SHA512",
      int passwordIterations = 2,
      string initialVector = "Pms2cn43Qk*c9nxI",
      int keySize = 256)
    {
      if (string.IsNullOrEmpty(cipherText))
        return "";
      byte[] bytes1 = Encoding.ASCII.GetBytes(initialVector);
      byte[] bytes2 = Encoding.ASCII.GetBytes(salt);
      byte[] buffer = Convert.FromBase64String(cipherText);
      byte[] bytes3 = new PasswordDeriveBytes(password, bytes2, hashAlgorithm, passwordIterations).GetBytes(keySize / 8);
      RijndaelManaged rijndaelManaged = new RijndaelManaged();
      rijndaelManaged.Mode = CipherMode.CBC;
      byte[] numArray = new byte[buffer.Length];
      int count = 0;
      using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(bytes3, bytes1))
      {
        using (MemoryStream memoryStream = new MemoryStream(buffer))
        {
          using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, decryptor, CryptoStreamMode.Read))
          {
            count = cryptoStream.Read(numArray, 0, numArray.Length);
            memoryStream.Close();
            cryptoStream.Close();
          }
        }
      }
      rijndaelManaged.Clear();
      return Encoding.UTF8.GetString(numArray, 0, count);
    }

    public static string EncryptToASCII(string inputStr)
    {
      string str = "";
      foreach (byte num in Encoding.ASCII.GetBytes(inputStr))
        str = str + "E" + num.ToString();
      return str;
    }

    public static string DecryptFromASCII(string inputStr)
    {
      List<byte> byteList = new List<byte>();
      if (inputStr == string.Empty)
        return "";
      inputStr.Remove(0, 1);
      string str1 = inputStr;
      char[] separator = new char[1]{ 'E' };
      foreach (string str2 in str1.Split(separator, StringSplitOptions.RemoveEmptyEntries))
        byteList.Add(Convert.ToByte(str2));
      return Encoding.ASCII.GetString(byteList.ToArray());
    }

    public static string GenerateSendingCode(string code)
    {
      string serialNum = Engine.GetSerialNum();
      return EncryptClass.EncryptToASCII(code + EncryptClass.EncryptDelimiter + serialNum);
    }
  }
}
