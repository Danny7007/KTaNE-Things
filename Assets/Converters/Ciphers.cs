using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public static class Ciphers {
	public const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private class Tuple<T1, T2>
    {
        private T1 _t1;
        private T2 _t2;
        public Tuple(T1 t1, T2 t2)
        {
            _t1 = t1;
            _t2 = t2;
        }
        public object this[int ix]
        {
            get
            {
                if (ix == 0)
                    return _t1;
                else if (ix == 1)
                    return _t2;
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (ix == 0)
                {
                    if (value is T1)
                        _t1 = (T1)value;
                    else throw new InvalidCastException(String.Format("Cannot cast to " + typeof(T1)));
                }
                else if (ix == 1)
                {
                    if (value is T2)
                        _t2 = (T2)value;
                    else throw new InvalidCastException(String.Format("Cannot cast to " + typeof(T2)));
                }
                else throw new IndexOutOfRangeException();
            }
        }
    }
    private class Grid
    {
        public string contents;
        char replacedLetter;
        char replacementLetter;

    }
    public static string CreateAlphabet(string key = "", bool atEnd = false, string alphabet = alphabet)
    {
        key = key.ToUpper();
        alphabet = alphabet.ToUpper();
        if (alphabet.Count() != 26)
            throw new ArgumentOutOfRangeException("Alphabet is not 26 letters long.");
        if (alphabet.Distinct().Count() != 26)
            throw new ArgumentException("Alphabet has duplicate characters.");
        if (key.Any(x => !Char.IsLetter(x)))
            throw new ArgumentException("Key contains non-letter characters.");
        if (alphabet.Any(x => !Char.IsLetter(x)))
            throw new ArgumentException("Key contains non-letter characters.");
        var keyUnique = key.Distinct();
        var alphaUnique = alphabet.Where(ch => !keyUnique.Contains(ch));
        var resultSeq = atEnd ?
                        alphaUnique.Concat(keyUnique) :
                        keyUnique.Concat(alphaUnique);
        return resultSeq.Join("");
    }
    public static string CreateGrid(string key = "", bool atEnd = false, char replacedLetter = 'J', char replacementLetter = 'I', string alphabet = alphabet)
    {

    }

    #region Caesar
    public static string EncryptCaesarCipher(string message, int key, string alphabet = alphabet)
    {
        alphabet = CreateAlphabet("", false, alphabet);
        return message.Select(ch => EncryptCaesarCipher(ch, key, alphabet)).Join("");   
    }
    public static string DecryptCaesarCipher(string message, int key, string alphabet = alphabet)
    {
        return EncryptCaesarCipher(message, -key, alphabet);
    }
    public static string EncryptRot13(string message, string alphabet = alphabet)
    {
        return EncryptCaesarCipher(message, 13, alphabet);
    }
    private static char EncryptCaesarCipher(char letter, int key, string alphabet)
    {
        if (!Char.IsLetter(letter))
            throw new ArgumentException("Non-letter found in message.");
        int ix = alphabet.IndexOf(Char.ToUpper(letter));
        char result = alphabet[(ix + key + 26) % 26];
        return Char.IsLower(letter) ? Char.ToLower(result) : Char.ToUpper(result);
        
    }
    #endregion
    #region Atbash
    public static string EncryptAtbash(string message, string alphabet = alphabet)
    {
        alphabet = CreateAlphabet("", false, alphabet);
        return message.Select(ch => EncryptAtbash(ch, alphabet)).Join("");
    }
    private static char EncryptAtbash(char ch, string alphabet)
    {
        if (!Char.IsLetter(ch))
            throw new ArgumentException("Non-letter found in message.");
        int initIx = alphabet.IndexOf(Char.ToUpper(ch));
        char result = alphabet[27 - initIx];
        return Char.IsLower(ch) ? Char.ToLower(result) : Char.ToUpper(result);
    }
    #endregion
    #region Playfair

    #endregion
}
