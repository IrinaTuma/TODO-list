using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TODO_list
{

    //New class
    public static class CustomColor
    {

        //dataGridImportantUrgent
        public static System.Drawing.Color ColorIU = System.Drawing.Color.FromArgb(230, 172, 172);
        public static System.Drawing.Color ColorIUDefault = SystemColors.Control;

        //dataGridImportantNotUrgent
        public static System.Drawing.Color ColorINU = System.Drawing.Color.FromArgb(117, 206, 206);
        public static System.Drawing.Color ColorINUDefault = SystemColors.Control;

        //dataGridNotImportantUrgent
        public static System.Drawing.Color ColorNIU = System.Drawing.Color.FromArgb(247, 218, 183);
        public static System.Drawing.Color ColorNIUDefault = SystemColors.Control;

        //dataGridNotImportantNotUrgent
        public static System.Drawing.Color ColorNINU = System.Drawing.Color.FromArgb(184, 177, 230);
        public static System.Drawing.Color ColorNINUDefault = SystemColors.Control;


    }
}
