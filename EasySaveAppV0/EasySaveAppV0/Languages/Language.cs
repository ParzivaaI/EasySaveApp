using System;
using System.Collections.Generic;
using System.Text;

namespace EasySaveAppV0.language
{
    public class Language
    {
        Language(){ }
        public class French:Language
        {
            public string CommandChoice()
            {
                return "Easysave - faites votre choix\r\n 1.Créer une sauvegarde \r\n 2.Read the daily log \r\n 3.Read daily saves states";
            }
        }

        public class English : Language
        {
            string commandchoice = "Easysave - make your choice\r\n 1.  Create a save \r\n 2.  Read the daily log \r\n 3.  Read daily saves states";
        }
    }
}
