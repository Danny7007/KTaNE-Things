using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class Ciphers {
	public const string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

	public string EncryptCaesarCipher(string message, int key, string alphabet = alphabet)
    {
        return message.Select(ch => EncryptCaesarCipher(ch, key, alphabet)).Join("");   
    }
    public string DecryptCaesarCipher(string message, int key, string alphabet = alphabet)
    {
        return EncryptCaesarCipher(message, -key, alphabet);
    }
    private char EncryptCaesarCipher(char letter, int key, string alphabet)
    {
        int ix = alphabet.IndexOf(letter);
        return alphabet[(ix + key + 26) % 26];
    }
}
