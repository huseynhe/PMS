using System;
using System.Collections.Generic;
using System.Text;

namespace PMS.UI
{
   public class Menu
    {
        public static char  ShowMenu() {
            string selectedOperation = "";
            do
            {
                Console.WriteLine("Please selected correct porgram:");
                Console.WriteLine("Sorgulama Programı (A)");
                Console.WriteLine("Yeniləmə Proqramı (B)");
                Console.WriteLine("Exit Proqramı (F)");
                selectedOperation =Console.ReadLine();
                selectedOperation = selectedOperation.ToUpper();

            } while (selectedOperation!="A"&& selectedOperation != "B" &&  selectedOperation != "F");
            return char.Parse(selectedOperation);
        }

        public static int showQueryMenu() {

            int selectedOperation = 0;
            do
            {
                Console.WriteLine("Please selected correct porgram:");
                Console.WriteLine("1.Bir işçinin məlumatlarının göstərilməsi");
                Console.WriteLine("2.Bir işçinin məlumatlarının göstərilməsi və həmin ay üzrə iş məlumatların göstərilməsi)");
                Console.WriteLine("3.Müəyyən bir ünvana görə işçilərin siyahısının görüntülənməsi");
                Console.WriteLine("4.İşə qəbul olunan işçilərin sayının illər üzrə bölgüsünün görüntülənməsi.");
                Console.WriteLine("5.İşə gec gələn işçilərin siyahısı");
                Console.WriteLine("6.Müəyyən bir günün əlavə iş qeydlərinin sadalanması");
                Console.WriteLine("7.Exit");

                selectedOperation = int.Parse(Console.ReadLine());

            } while (selectedOperation <0 ||selectedOperation>7 );
            return selectedOperation;
        }

        public static int showOperationMenu()
        {

            int selectedOperation = 0;
            do
            {
                Console.WriteLine("Please selected correct porgram:");
                Console.WriteLine("1.Yeni işçinin əlavə edilməsi");
                Console.WriteLine("2.İşçi məlumatlarının yenilənməsi");
                Console.WriteLine("3.Müəyyən bir günün iş qeydlərinin əlavə edilməsi");
                Console.WriteLine("4.İşçi məlumatlarının dosyalardan silinməsi.");
                Console.WriteLine("5.İşçilər faylının ehtiyat nüsxəsinin çıxarılması");
                Console.WriteLine("6.Exit");

                selectedOperation = int.Parse(Console.ReadLine());

            } while (selectedOperation < 0 || selectedOperation > 6);
            return selectedOperation;
        }
    }
}
