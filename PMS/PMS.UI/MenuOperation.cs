using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.UI
{
    public class MenuOperation
    {
        public static void executeQueryMenu() {
        
        }

        public static string executeOperationMenu(int menuNumber) {
            string message = "";
            switch (menuNumber)
            {
                case 1:
                    message = QueryService.AddPerson();
                    break;
                case 2:
                    message = QueryService.UpdatePerson();
                    break;
                default:
                    break;
            }
            return message;
        }

    }
}
