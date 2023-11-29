using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TODO_list
{

    //New class
    internal class Todo
    {
        //Fields
        private string text;
        private bool check;

        //Constructor
        public Todo()
        {
            this.text = "";
            this.check = false;
        }

        //get, set properties
        public string TextNow
        {
            get
            {
                return this.text;
            }
            set
            {
                if (value != "")
                {
                    this.text = value;
                }
            }
        }


        public bool CheckNow
        {
            get
            {
                return this.check;
            }
            set
            {
                this.check = value;
            }
        }

    }
}
