/**
 * This file consists of a number of Unit tests which you can run to check your code. To run the 
 * unit tests open "Test explorer" from the view menu. Click on the run icon to run all tests
 * or right click on an individual test and select "run" to run individual tests.
 * 
 * If you add your own tests, tripple check the test data that you provide. 
 * 
 */

using System;
using Xunit;
using Enigma;
using System.Collections.Generic;

namespace EnigmaTests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("This. Is a test Message.", "THIS€?IS?A?TEST?MESSAGE€")]
        [InlineData("Another test message!", "ANOTHER?TEST?MESSAGE")]
        [InlineData("Quo usque tandem abutere, Catilina, patientia nostra?", "QUO?USQUE?TANDEM?ABUTERE?CATILINA?PATIENTIA?NOSTRA")]
        [InlineData("Hell          oo", "HELL??????????OO")]
        [InlineData("123456789", "")]
        [InlineData("", "")]
        [InlineData("+/:@#!£''$%", "")]
        public void ShouldFormatInputMessage(string inputMessage, string outputMessage)
        {
            //Arrange
            string expectedOutcome = outputMessage;
            string actualOutcome = "";

            //Act
            actualOutcome = Enigma.EnigmaMachine.FormatInputMessage(inputMessage);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);
        }


        [Theory]
        [InlineData("THIS€?IS?A?TEST?MESSAGE€", "This. Is a test message.")]
        [InlineData("ANOTHER?TEST?MESSAGE", "Another test message")]
        [InlineData("HEL?LO", "Hel lo")]
        [InlineData("HE????€????LL?O", "He    .    Ll o")]
        public void ShouldFormatOutputMessage(string inputMessage, string outputMessage)
        {
            //Arrange
            string expectedOutcome = outputMessage;
            string actualOutcome = "";

            //Act
            actualOutcome = Enigma.EnigmaMachine.FormatOutputMessage(inputMessage);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);
        }


        [Theory]
        [InlineData("Deine Zauber binden wieder.", "GKAPS?UOQNCQ?EBXMIG?CXWWDC€", 12, "HFPMRIBTJWYDXQLGUKOVSNAZEC")]
        public void ShouldEncodeMessage(string inputMessage, string encocodedMessage, int incrementNumber, string rotor1)
        {
            //Arrange
            string expectedOutcome = encocodedMessage;
            string actualOutcome = "";
            List<string> rotors = new List<string>();
            rotors.Add(rotor1);

            //Act
            actualOutcome = Enigma.EnigmaMachine.Encode(inputMessage, incrementNumber, rotors);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);

        }


        [Theory]
        [InlineData("Ab", "FI", 0, "BDFHJLCPRTXVZNYEIWGAKMUSQO", "HFPMRIBTJWYDXQLGUKOVSNAZEC")]
        public void ShouldEncodeMessageWithMoreRotors(string inputMessage, string encocodedMessage, int incrementNumber, string rotor1, string rotor2)
        {
            //Arrange
            string expectedOutcome = encocodedMessage;
            string actualOutcome = "";
            List<string> rotors = new List<string>();
            rotors.Add(rotor1);
            rotors.Add(rotor2);

            //Act
            actualOutcome = Enigma.EnigmaMachine.Encode(inputMessage, incrementNumber, rotors);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);

        }


        [Theory]
        [InlineData("GKAPS?UOQNCQ?EBXMIG?CXWWDC€?", "Deine zauber binden wieder.", 12, "HFPMRIBTJWYDXQLGUKOVSNAZEC")]
        [InlineData("GKAPS?UOQNCQ?EBXMIG?CXWWDC€", "Deine zauber binden wieder.", 12, "HFPMRIBTJWYDXQLGUKOVSNAZEC")]
        [InlineData("JCRX", "Abcd", 4, "BDFHJLCPRTXVZNYEIWGAKMUSQO")]
        public void ShouldDecodeMessage(string inputMessage, string decocodedMessage, int incrementNumber, string rotor1)
        {
            //Arrange
            string expectedOutcome = decocodedMessage;
            string actualOutcome = "";
            List<string> rotors = new List<string>();
            rotors.Add(rotor1);

            //Act
            actualOutcome = Enigma.EnigmaMachine.Decode(inputMessage, incrementNumber, rotors);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);

        }


        public void ShouldCaesarShift(string inputMessage, string shiftedMessage, int shiftNum, bool encoding)
        {
            //Arrange
            string expectedOutcome = shiftedMessage;
            string actualOutcome = "";

            //Act
            actualOutcome = Enigma.EnigmaMachine.CaesarShift(inputMessage, shiftNum, encoding);

            //Assert
            Xunit.Assert.Equal(expectedOutcome, actualOutcome);

        }
    }
}


