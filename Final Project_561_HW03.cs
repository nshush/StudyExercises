using System;

class MainClass
{
    static void Main(string[] args)
    {
        var userData = GetUserData();
        ShowUserData(userData);
    }

    static (string firstName, string lastName, int age, bool hasPet, string[] petNames, string[] favoriteColors) GetUserData()
    {
        Console.Write("Введите имя: ");
        string firstName = Console.ReadLine();

        Console.Write("Введите фамилию: ");
        string lastName = Console.ReadLine();

        int age = GetPositiveInt("Введите возраст: \n (число больше 0) ");

        bool hasPet = GetYesNoAnswer("У Вас есть питомец? \n (да/нет) ");

        string[] petNames = null;
        if (hasPet)
        {
            int petCount = GetPositiveInt("Сколько у Вас питомцев? ");
            petNames = GetPetNames(petCount);
        }

        int colorCount = GetPositiveInt("Сколько у Вас любимых цветов? ");
        string[] favoriteColors = GetFavoriteColors(colorCount);

        return (firstName, lastName, age, hasPet, petNames, favoriteColors);
    }

    static int GetPositiveInt(string prompt)
    {
        int result;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out result) && result > 0)
            {
                return result;
            }
            Console.WriteLine("Некорректный ввод! Необходимо ввести число больше 0.");
        }
    }

    static bool GetYesNoAnswer(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine().ToLower();
            if (answer == "да")
            {
                return true;
            }
            else if (answer == "нет")
            {
                return false;
            }
            Console.WriteLine("Некорректный ввод! Необходимо ввести 'да' или 'нет'.");
        }
    }

    static string[] GetPetNames(int petCount)
    {
        string[] petNames = new string[petCount];
        for (int i = 0; i < petCount; i++)
        {
            Console.Write($"Введите кличку питомца {i + 1}: ");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    static string[] GetFavoriteColors(int colorCount)
    {
        string[] favoriteColors = new string[colorCount];
        for (int i = 0; i < colorCount; i++)
        {
            Console.Write($"Введите любимый цвет #{i + 1}: ");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }

    static void ShowUserData((string firstName, string lastName, int age, bool hasPet, string[] petNames, string[] favoriteColors) userData)
    {
        Console.WriteLine("Полученые пользователя:");
        Console.WriteLine($"Имя: {userData.firstName}");
        Console.WriteLine($"Фамилия: {userData.lastName}");
        Console.WriteLine($"Возраст: {userData.age}");
        Console.WriteLine($"Есть питомец: {(userData.hasPet ? "Да" : "Нет")}");

        if (userData.hasPet && userData.petNames != null)
        {
            Console.WriteLine("Клички питомцев:");
            foreach (var pet in userData.petNames)
            {
                Console.WriteLine($"- {pet}");
            }
        }

        Console.WriteLine("Любимые цвета:");
        foreach (var color in userData.favoriteColors)
        {
            Console.WriteLine($"- {color}");
        }
    }
}