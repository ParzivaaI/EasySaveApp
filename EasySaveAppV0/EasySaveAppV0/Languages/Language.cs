using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EasySaveAppV0.Languages
{
    class Language
    {
        int choix;
        
        public  Language() { }

        public void ChoiceLanguage()
        {
           // int numLanguage;
            string langChoice = Console.ReadLine();
            switch (langChoice)
            {
                case "en":
                    LanguageEN();
                   // numLanguage = 0;
                    break;
                case "fr":
                    LanguageFR();
                    //numLanguage = 1;
                    break;
                default:
                    Console.WriteLine("Please enter a valid choice");
                    Console.WriteLine("en : English");
                    Console.WriteLine("fr : Français");
                    ChoiceLanguage();
                    break;

            
            
            }
            /*if(numLanguage== 0) {
                LanguageFR();
            }*/
        }     
        public void LanguageFR() {


            
        }
        public void LanguageEN() {
            
        }
       
    }
}
