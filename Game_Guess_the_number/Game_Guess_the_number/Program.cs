﻿using System;


static void Main()
{
    bool exit = false;

    while (!exit)
    {
        Console.WriteLine("Добро пожаловать в игру \"Угадай число\".");
        Console.WriteLine("Меню:");
        Console.WriteLine("1. Начать");
        Console.WriteLine("2. Правила");
        Console.WriteLine("3. Выход");
        Console.Write("Введите номер пункта чтобы продолжить: ");
        int actionMenu = 0;

        try
        {
            actionMenu = Convert.ToInt32(Console.ReadLine());
        }
        catch
        {
            Console.WriteLine("Введите коректное значение");
        }

        int dificulty = 0;

        Random rnd = new Random();

        switch (actionMenu)
        {
            case 1:

                Console.WriteLine("Выберите сложность:");
                Console.WriteLine("1. Легкая (числа от 1 до 100)");
                Console.WriteLine("2. Средняя (числа от 1 до 1000)");
                Console.WriteLine("3. Сложная (числа от 1 до 10000)");

                while (dificulty != 1 && dificulty != 2 && dificulty != 3)
                {
                    try
                    {
                        Console.WriteLine("Введите 1, 2 или 3 для выбора сложности.");
                        dificulty = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Пожалуйста введите допустимое значение (от 1 до 3)");
                    }

                }

                switch (dificulty)
                {
                    case 1:
                        Console.WriteLine("Выбраный режим: Легкий (числа от 1 до 100) ");
                        PlayGame(rnd, 100);
                        break;

                    case 2:
                        Console.WriteLine("Выбраный режим: Средний (числа от 1 до 1000) ");
                        PlayGame(rnd, 1000);
                        break;

                    case 3:
                        Console.WriteLine("Выбраный режим: Сложный (числа от 1 до 10000) ");
                        PlayGame(rnd, 10000);
                        break;
                }
                break;

            case 2:
                Console.WriteLine("Правила игры:");
                Console.WriteLine("1. Программа загадывает число в выбранном диапазоне");
                Console.WriteLine("2. Ваша задача - угадать число за наименьшее кол-во попыток.");
                Console.WriteLine("3. После каждого хода программа будет давать подсказку  - больше или меньше загаднное число.");
                Console.WriteLine("Возврат в меню...");
                break;

            case 3:
                Console.WriteLine("Программа закрывается. Спасибо за игру!");
                exit = true;
                break;

            default:
                Console.WriteLine("Недопустимое значение. (Автоматически выбран 1 пункт)");
                PlayGame(rnd, 100);
                break;

        }
    }
}

static void PlayGame(Random rnd, int maxRange) {
    int value = rnd.Next(1, maxRange + 1);
    Console.WriteLine($"Я загадал число от 1 до {maxRange}. Можешь начинать угадывать. Удачи!!! (Число не может быть 0 и отрицательным)");
    int result = 0;
    int attempts = 0;
    while (result != value)
    {
        attempts++;
        try
        {
            result = Convert.ToInt32(Console.ReadLine());
            if (result <= 0)
            {
                Console.WriteLine("Число не может быть 0 или отрицательным. Попробуйте снова.");
                continue;
            }
            if (result < value) Console.WriteLine("Загаданное число больше твоего!");
            else if (result > value) Console.WriteLine("Загаданное число меньше твоего!");
        }
        catch (FormatException)
        {
            Console.WriteLine("Пожалуйста введите коректное число.");
        }
    }
    Console.WriteLine($"Молодец, ты справился за {attempts} попыток. Загаданным числом было число {result}");

    Console.WriteLine("Хотите сыграть еще раз? (да/нет)");
    string replay = Console.ReadLine()?.ToLower();
    while (replay != "да" && replay != "нет")
    {
        Console.WriteLine("Введите корректное значение: 'да' или 'нет'.");
        replay = Console.ReadLine()?.ToLower();
    }
    if (replay == "нет")
    {
        Console.WriteLine("Спасибо за игру! До встречи!");
    }
     


}

Main();