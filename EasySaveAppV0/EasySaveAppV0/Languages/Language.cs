using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace EasySaveAppV0.Languages
{
    class Language
    {          
        
        public class French
        {
            string welcome = "oui";
        }
        class English
        {


        }
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
            French language = new French();
            

        }
        public void LanguageEN() 
        {
            English language= new English();

        }
       
    }
}
