using System;

namespace PMS.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            char selectedOperation = 'F';
            do
            {
                selectedOperation = Menu.ShowMenu();
                int operationNumber = 0;
                string message = String.Empty;
                switch (selectedOperation)
                {

                    case 'A':
                        operationNumber = Menu.showQueryMenu();
                        break;
                    case 'B':
                       
                        do
                        {
                            operationNumber = Menu.showOperationMenu();
                            message = MenuOperation.executeOperationMenu(operationNumber);
                            Console.WriteLine(message);
                            Console.WriteLine("----------------------------------------------------------------");
                        } while (operationNumber != 6);

                        break;
                    default:
                        break;
                }
            } while (selectedOperation!='F');
       
        }
    }
}
