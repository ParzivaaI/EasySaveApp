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
            Console.WriteLine("en : English");
            Console.WriteLine("fr : Français");
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
                    ChoiceLanguage();
                    
                    
                    break;

            
            
            }
            
        }     
        public void LanguageFR() 
        {
            string optinchoice = "Easysave - Faites votre choix";




        }
        public void LanguageEN() 
        {
            string optinchoice = "Easysave - make your choice";

        }
       
    }
}
