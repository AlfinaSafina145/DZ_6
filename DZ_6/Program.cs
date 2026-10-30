using System;
using System.Collections.Generic;
namespace FitnessApp
{
    public abstract class Workout
    {
        private string name;
        private int duration;
        private double calories;
        private int difficultyLevel;
        public string Name
        {
            get { return name; }
        }
        public int Duration
        {
            get { return duration; }
            set { if (value > 0) duration = value; else Console.WriteLine("Ошибка: время должно быть > 0"); }
        }

        public double Calories
        {
            get { return calories; }
            set { if (value >= 0) calories = value; else Console.WriteLine("Ошибка: калории не могут быть отрицательными"); }
        }

        public int DifficultyLevel
        {
            get { return difficultyLevel; }
            set { if (value >= 1 && value <= 10) difficultyLevel = value; else Console.WriteLine("Ошибка: уровень от 1 до 10"); }
        }
        public Workout(string name, int duration, double calories, int difficultyLevel)
        {
            this.name = name;
            Duration = duration;
            Calories = calories;
            DifficultyLevel = difficultyLevel;
        }
        public abstract void GetRecommendations();
        public virtual void Start()
        {
            Console.WriteLine($"\n[Старт] Начинаем тренировку: {Name}. Длительность: {Duration} мин.");
        }

        public virtual void Finish()
        {
            Console.WriteLine($"[Финиш] Тренировка {Name} завершена. Сожжено {Calories} ккал.");
        }

        public void RecordResult()
        {
            Console.WriteLine($"[Запись] Результат тренировки '{Name}' сохранен в дневник.");
        }

        public void CompareWithLastWeek(double lastWeekCalories)
        {
            if (Calories > lastWeekCalories)
                Console.WriteLine($"[Сравнение] Вы молодец! Потратили на {Calories - lastWeekCalories} ккал больше, чем на прошлой неделе.");
            else if (Calories < lastWeekCalories)
                Console.WriteLine($"[Сравнение] На этой неделе вы потратили на {lastWeekCalories - Calories} ккал меньше. Нужно поднажать!");
            else
                Console.WriteLine("[Сравнение] Результат такой же, как на прошлой неделе. Стабильность - тоже хорошо!");
        }
    }
    public class CardioWorkout : Workout
    {
        public CardioWorkout(string name, int duration, double calories, int difficultyLevel)
            : base(name, duration, calories, difficultyLevel)
        {
        }
        public CardioWorkout(int duration, double calories)
            : base("Бег на дорожке", duration, calories, 5)
        {
        }
        public override void GetRecommendations()
        {
            Console.WriteLine($"[Рекомендация] Для кардио '{Name}' пейте воду каждые 15 минут и следите за пульсом (не выше 150 уд/мин).");
        }
        public override void Finish()
        {
            base.Finish();
            Console.WriteLine("[Особенность кардио] Не забудьте сделать заминку и растяжку ног!");
        }
    }
    public class StrengthWorkout : Workout
    {
        public StrengthWorkout(string name, int duration, double calories, int difficultyLevel)
            : base(name, duration, calories, difficultyLevel)
        {
        }
        public StrengthWorkout(string name, int duration)
            : base(name, duration, 300, 8)
        {
        }

        public override void GetRecommendations()
        {
            Console.WriteLine($"[Рекомендация] Для силовой '{Name}' обязательно делайте разминку суставов и отдыхайте 2 минуты между подходами.");
        }
    }
    public class StretchingWorkout : Workout
    {
        public StretchingWorkout(string name, int duration, double calories, int difficultyLevel)
            : base(name, duration, calories, difficultyLevel)
        {
        }
        public StretchingWorkout()
            : base("Йога для начинающих", 30, 100, 2)
        {
        }

        public override void GetRecommendations()
        {
            Console.WriteLine($"[Рекомендация] В растяжке '{Name}' главное - плавность. Не делайте резких движений и дышите глубоко.");
        }
        public override void Start()
        {
            Console.WriteLine($"\n[Старт] Расстилаем коврик. Начинаем плавную тренировку: {Name}.");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Добро пожаловать в фитнес-приложение! ===\n");
            CardioWorkout cardio = new CardioWorkout("Интервальный бег", 40, 450.5, 7);
            StrengthWorkout strength = new StrengthWorkout("Жим штанги", 60);
            StretchingWorkout stretching = new StretchingWorkout();

            cardio.Start();
            cardio.GetRecommendations();
            cardio.Finish();
            cardio.RecordResult();
            cardio.CompareWithLastWeek(400);

            Console.WriteLine();

            strength.Start();
            strength.GetRecommendations();
            strength.Finish();
            strength.RecordResult();
            strength.CompareWithLastWeek(350);

            Console.WriteLine();

            stretching.Start();
            stretching.GetRecommendations();
            stretching.Finish();
            stretching.RecordResult();
            stretching.CompareWithLastWeek(100);

            Console.WriteLine("\n=== Демонстрация полиморфизма (массив тренировок) ===");
            Workout[] myWeek = { cardio, strength, stretching };

            foreach (var workout in myWeek)
            {
                workout.GetRecommendations();
            }
        }
    }
}