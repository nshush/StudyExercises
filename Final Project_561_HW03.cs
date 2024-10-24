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
        Console.Write("������� ���: ");
        string firstName = Console.ReadLine();

        Console.Write("������� �������: ");
        string lastName = Console.ReadLine();

        int age = GetPositiveInt("������� �������: \n (����� ������ 0) ");

        bool hasPet = GetYesNoAnswer("� ��� ���� �������? \n (��/���) ");

        string[] petNames = null;
        if (hasPet)
        {
            int petCount = GetPositiveInt("������� � ��� ��������? ");
            petNames = GetPetNames(petCount);
        }

        int colorCount = GetPositiveInt("������� � ��� ������� ������? ");
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
            Console.WriteLine("������������ ����! ���������� ������ ����� ������ 0.");
        }
    }

    static bool GetYesNoAnswer(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string answer = Console.ReadLine().ToLower();
            if (answer == "��")
            {
                return true;
            }
            else if (answer == "���")
            {
                return false;
            }
            Console.WriteLine("������������ ����! ���������� ������ '��' ��� '���'.");
        }
    }

    static string[] GetPetNames(int petCount)
    {
        string[] petNames = new string[petCount];
        for (int i = 0; i < petCount; i++)
        {
            Console.Write($"������� ������ ������� {i + 1}: ");
            petNames[i] = Console.ReadLine();
        }
        return petNames;
    }

    static string[] GetFavoriteColors(int colorCount)
    {
        string[] favoriteColors = new string[colorCount];
        for (int i = 0; i < colorCount; i++)
        {
            Console.Write($"������� ������� ���� #{i + 1}: ");
            favoriteColors[i] = Console.ReadLine();
        }
        return favoriteColors;
    }

    static void ShowUserData((string firstName, string lastName, int age, bool hasPet, string[] petNames, string[] favoriteColors) userData)
    {
        Console.WriteLine("��������� ������������:");
        Console.WriteLine($"���: {userData.firstName}");
        Console.WriteLine($"�������: {userData.lastName}");
        Console.WriteLine($"�������: {userData.age}");
        Console.WriteLine($"���� �������: {(userData.hasPet ? "��" : "���")}");

        if (userData.hasPet && userData.petNames != null)
        {
            Console.WriteLine("������ ��������:");
            foreach (var pet in userData.petNames)
            {
                Console.WriteLine($"- {pet}");
            }
        }

        Console.WriteLine("������� �����:");
        foreach (var color in userData.favoriteColors)
        {
            Console.WriteLine($"- {color}");
        }
    }
}