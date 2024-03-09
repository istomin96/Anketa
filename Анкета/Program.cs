
using System;
using System.Xml.Linq;

namespace Анкета
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserAnketa();
        }

        static bool CheckNum(string number, out int cornumber)
        {
            if (int.TryParse(number, out int intnum))
            {
                if (intnum > 0)
                {
                    cornumber = intnum;
                    return false;
                }
            }
            {
                cornumber = 0;
                return true;
            }
        }

        static bool ChekSymbol(string symbol)
        {
           
            if (string.IsNullOrEmpty(symbol))
                return true;
            else
                return false;
        }

        static bool yesNo(string yesno)
        {
            if (yesno.ToLower() == "да" || yesno.ToLower() == "нет")
                return false;
            else
                return true;
        }

        static (string Name, string LastName, int Age, int Pet, int Collors) UserAnketa()
        {

            (string Name, string LastName, int Age, int Pet, int Collors) User;

            //Юзер
            do 
            { 
                Console.Write("Введите имя: ");
                User.Name = Console.ReadLine();
            }
            while (ChekSymbol(User.Name));

            do
            {
            Console.Write("Введите фамилию: ");
            User.LastName = Console.ReadLine();
            }
            while (ChekSymbol(User.LastName));

            string age;

            int intage;

            do
            {
                Console.Write("Введите возраст цифрами: ");

                age = Console.ReadLine();
            }
            while (CheckNum(age, out intage));

            User.Age = intage;

            //Питомцы

            int intPet = new int(); //Количество питомцев в int переменной

            string howPet; //количество питомцев

            string petText = ""; //дополнительный текст 

            string yesno; //проверка на да/нет

            do
            {
                Console.Write("Есть ли у Вас домашине питомцы? (Да/Нет) ");

                yesno = Console.ReadLine();

                if (yesno.ToLower() == "да")

                {
                    do
                    {
                        Console.WriteLine("Сколько питомцев у Вас? ");
                        howPet = Console.ReadLine();
                    }
                    while (CheckNum(howPet, out intPet));

                }

                else if (yesno.ToLower() == "нет")
                {
                    petText = "питомцев";
                }
            }
            while (yesNo(yesno));
           

            if (Convert.ToInt32(intPet) == 1)
            {
                Console.WriteLine("Как его/ее зовут? ");
                petText = "питомец, его/ее зовут";
            }

            else if (Convert.ToInt32(intPet) > 1)
            {
                Console.WriteLine("Как их зовут? ");
                petText = "питомца, их зовут";
            }

            string[] namePets = new string[intPet];

            for (int i = 0; i < namePets.Length; i++)
            {
                namePets[i] = Console.ReadLine();
            }

            string namePett = string.Join(", ", namePets); //преобразование массива в одну переменную

            User.Pet = intPet;

            //Цвета

            string color; //количество цветов

            int intColor; //количество цветов в int переменной

            string colorText; //дополнительный текст

            do
            {
                Console.WriteLine("Введите количество любимых цветов");

                color = Console.ReadLine();
            }
            while (CheckNum(color, out intColor));


            if (intColor == 1)
            {
                Console.WriteLine("Назовите цвет:");
                colorText = "любимый цвет, это ";
            }

            else
            {
                Console.WriteLine("Назоватие цвета");
                colorText = "любимых цветов, это ";
            }

            string[] nameColors = new string[intColor];

            for (int i = 0; i < nameColors.Length; i++)
            {
                nameColors[i] = Console.ReadLine();
            }

            User.Collors = intColor;

            string nameColor = string.Join (", ", nameColors); //преобразование массива в одну переменную

            Console.Write($"Ваше имя {User.Name}, Ваша фамилия {User.LastName}, Вам {User.Age} года/лет\nу вас {User.Pet} {petText} {namePett}\nу вас {User.Collors} {colorText} {nameColor}");
            
            return User;
        }


    }
}
