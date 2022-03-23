using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Enigma
{
    /// <summary>
    /// The class Enigma provides basic static methods to encode and decode a message with a set of
    /// encryption keys or rotors using a simple substitution cipher along with method to preform 
    /// a Caesarshift. 
    /// 
    /// DO NOT MODIFY THE SIGNATURES OF THE METHODS PROVIDED. You can add new methods to support
    /// the skeleton methods below. 
    /// 
    /// </summary>
    public static class EnigmaMachine
    {
        /// <summary>
        /// Encodes the supplied string message by formatting the input message first, then
        /// applying an initial CaesarShift then applying the keys within the List rotors. 
        /// All text should be uppercase, spaces replaced by the '?' character and all full
        /// stops '.' with a '€'. All other characters that are not [A..Z] or [a..z] should be 
        /// removed from the message.
        /// </summary>
        /// 
        /// Example input: "Deine Zauber binden wieder. Was die Mode streng geteilt.", 12, "HFPMRIBTJWYDXQLGUKOVSNAZEC"
        /// Expected output: "GKAPS?UOQNCQ?EBXMIG?CXWWDC€?IYM?GNO?FRSA?DQXHYR?IRSBDGE€"
        /// 
        /// <param name="message">The message to be encoded.</param>
        /// <param name="incrementNumber">The number of characters to shift when applying the
        /// Caesarshift.</param>
        /// <param name="rotors">A list of strings, each string is used for character substitution.</param>
        ///  
        /// <returns>An encoded string.</returns>
        /// 
        public static string Encode(string message, int incrementNumber, List<string> rotors)   
        {
            // TO DO - add your implementation
            //throw new NotImplementedException();
            String FirstString = message;            
            String rotor = rotors[0];
            String SecondString = FormatInputMessage(FirstString);
            Console.WriteLine($"Formatted String {SecondString}");
            String ThirdString = CaesarShift(SecondString,incrementNumber,true);
            Console.WriteLine($"CaeserSifted String {ThirdString}");
            String FourthString = ApplyRotor(ThirdString.ToString(), rotor);
            Console.WriteLine($"Rotor Added String {FourthString}");
            return FourthString.ToString();

        }

        /// <summary>
        /// The Decode method should decode the supplied message by reversing the steps in the encode.
        /// The returned message should be in upper case with the character '?' replaced with spaces 
        /// and the '€' replaced with a full stop '.'. Remember to format the decoded message 
        /// correctly as specified in the FormatOutputMessage method.
        /// </summary>
        /// 
        /// Example input: "LQUKH?KTKUYXPQ?OV?UTH?GTR?OSTKBB€", 24, "YPSQFIUAGKZCXEMDBVRHNTJWLO"
        /// Expected output: "Aegir greatest of the sea giants."
        ///         
        /// <param name="message">The encoded message to be decoded</param>
        /// <param name="incrementNumber">The number of decrements to shift when applying 
        /// the Caesarshift.</param>
        /// <param name="rotors">A list of strings, each string is used for character substitution.</param>
        /// <returns>A decoded string.</returns>
        public static string Decode(string message, int incrementNumber, List<string> rotors)
        {
            // TO DO - add your implementation
            throw new NotImplementedException();

        }

        /// <summary>
        /// The method FormatInputMessage should be used when encoding a message. It should
        /// make all characters in the string message uppercase. Remove all non alphabetic 
        /// characters from the string except for spaces ' '  and full stops '.'. Then 
        /// replace all spaces with a '?' and all full stops '.' with a '€'.
        /// </summary>
        /// 
        /// Example input:  "Test message. Working.
        /// Example output: "TEST?MESSAGE€?WORKING€"
        /// 
        /// <param name="message">The string to be formatted for encoding.</param>
        /// <returns>An uppercase string with only characters A-Z and spaces replaced by '?'
        /// and full stops replaced by a '€'</returns>
        public static string FormatInputMessage(string message)
        {
            // TO DO - add your implementation
            //throw new NotImplementedException();
            StringBuilder msg = new StringBuilder(message.Trim());

            for (int i = 0; i < msg.Length; i++)
            {
                if (msg[i] != '.' && msg[i] != ' ' && !Char.IsLetter(msg[i]))
                {
                    
                    msg.Remove(i, 1);
                    Console.WriteLine(msg.ToString());
                }
            }
            msg.Replace('.', '€');
            msg.Replace(' ', '?'); 
            return msg.ToString().ToUpper();
        }

        /// <summary>
        /// The method FormatOuputMessage should be used when decoding a message. It should replace
        /// all '?' characters with a single space ' ' and all '€' with a '.' full stop. All 
        /// characters should be lower case except for the first character in the input string 
        /// and every character after a full stop. 
        /// 
        /// Example input:  "TEST?MESSAGE€?WORKING€"
        /// Example output: "Test message. Working.
        /// 
        /// </summary>
        /// <param name="message">The string to be formatted after encryption.</param>
        /// <returns>A string with characters in lower case, with the exception of the start of 
        /// sentences and all question marks '?' replaced by spaces. All '€' replaced
        /// with full stops '.'</returns>
        public static string FormatOutputMessage(string message)
        {
            // TO DO - add your implementation
            throw new NotImplementedException();
        }

        /// <summary>
        /// The CaesarShift method should take a message and shift each character [A-Z] by the 
        /// value shift, incrementing or decrementing the value of shift by 1 or -1 with each 
        /// character shifted if given a positive shift value if encode = true otherwise shifted
        /// by a negative value if encode = false.
        /// 
        /// Example input:  "HELLO", -7, true 
        /// initial shift value = -7 for 'H' then -8 for 'E' and so forth results in:
        /// Example output: "AWCBD"
        /// 
        /// 
        /// </summary>
        /// <param name="message">The string message to be shifted</param>
        /// <param name="shift">The number of characters = or - to be shifted</param>
        /// <param name="encode">true if we are encoding otherwise false</param>
        /// <returns>A string with characters shifted in the appropriate direction by the 
        /// specified shift number.</returns>
        public static string CaesarShift(string message, int shift, bool encode)
        {
            // TO DO - add your implementation
            //throw new NotImplementedException();
            StringBuilder _message = new StringBuilder(message);
            StringBuilder _newMessage = new StringBuilder();
            
        if(encode)
            {
                for (int i = 0; i < _message.Length; i++)
                {
                    if (_message[i] == '?' || _message[i] == '€')
                    {
                        _newMessage.Append(_message[i]);
                        shift--;
                    }
                    else if (shift < 0)
                    {
                        int _newLetter = _message[i] + (shift - i);
                        if (_newLetter < 65)
                        {
                            _newLetter = _newLetter + 26;
                        }
                        _newMessage.Append((char)_newLetter);
                    }
                    else
                    {
                        int _newLetter = _message[i] + (shift + i );
                        if (_newLetter > 90)
                        {
                            _newLetter = _newLetter - 26;
                            if (_newLetter > 90)
                            {
                                _newLetter = _newLetter - 26;
                            }
                        }
                        _newMessage.Append((char)_newLetter);
                    }

                }
                
                return _newMessage.ToString();
            }
            return _newMessage.ToString();
        }


        /// <summary>
        /// The ApplyRotor method should substitue each [A..Z] character in the input string
        /// with the corresponding character in the rotor. 
        ///                                         
        /// Example input message: "Apples", rotor: HFPMRIBTJWYDXQLGUKOVSNAZEC
        /// Example outout: "HGGDRO"
        /// </summary>
        /// Apply the rotor to the input message and return the scrambled message
        /// <param name="message"></param>
        /// <param name="rotor"></param>
        /// <returns>A string with each [A..Z] character in the input string replaced
        /// with the corresponding character in the rotor. </returns>
        private static string ApplyRotor(string message, string rotor)
        {
            // TO DO - add your implementation
            //throw new NotImplementedException();
            StringBuilder _message = new StringBuilder(message);
            StringBuilder _newMessage = new StringBuilder();
            String applyrotor = rotor;
            Console.WriteLine(applyrotor);
     
            for (int i = 0; i < _message.Length; i ++)
            {
                if (_message[i] == '?' || _message[i] == '€')
                {
                    if(_message[i] == '?')
                    {
                        _newMessage.Append("?");
                    }
                    else
                    {
                        _newMessage.Append("€");
                    }
                }
                else
                {
                    int _newLetter = _message[i] - 65;
                    _newMessage.Append(applyrotor[_newLetter]);
                }
            }
            return _newMessage.ToString();
        }
        


        /// <summary>
        /// The ReverseRotor method should substitue each [A..Z] character in the input string
        /// with the corresponding character in the rotor as above. 
        /// </summary>
        /// Apply the rotor in reverse
        /// <param name="message"></param>
        /// <param name="rotor"></param>
        /// <returns>A string with each [A..Z] character in the input string replaced
        /// with the corresponding character in the rotor. </returns>
        private static string ReverseRotor(string message, string rotor)
        {
            // TO DO - add your implementation
            throw new NotImplementedException();
        }
    }
}
