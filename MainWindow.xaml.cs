using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace second_pr
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary> Данные игрока </summary>
        public Classes.PersonInfo Player = new Classes.PersonInfo("Student", 100, 10, 1, 0, 0, 5);
        /// <summary> Коллекция противников </summary>
        public List<Classes.PersonInfo> Enemys = new List<Classes.PersonInfo>();
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public Classes.PersonInfo Enemy;

        public MainWindow()
        {
            InitializeComponent();

            // Повышаем уровень персонажа и обновляем данные на UI
            UserInfoPlayer();

            // Добавляем данные о противниках в коллекцию
            Enemys.Add(new Classes.PersonInfo("Название врага №1", 100, 20, 1, 15, 5, 20));
            Enemys.Add(new Classes.PersonInfo("Название врага №2", 20, 5, 1, 5, 2, 5));
            Enemys.Add(new Classes.PersonInfo("Название врага №3", 50, 3, 1, 10, 10, 15));

            // Задаём настройки для таймера
            dispatcherTimer.Tick += AttackPlayer;
            // Задаём интервал с которым выполняется таймер
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
            // Запускаем таймер
            dispatcherTimer.Start();
            dispatcherTimer.Interval = new System.TimeSpan(0, 0, 10);
        // Запускаем таймер
        dispatcherTimer.Start();

            // Вызываем метод выбора случайного противника
            SelectEnemy();
        }

        /// <summary>
        /// Метод, который наносит периодический урон игроку
        /// </summary>
        private void AttackPlayer(object sender, System.EventArgs e)
        {
            // Наносим урон в процентном соотношении с учётом брони игрока
            Player.Health = Convert.ToInt32(Enemy.Damage * 100f / (100f - Player.Armor));

            // Обновляем характеристики персонажа на интерфейсе
            UserInfoPlayer();
        }
        /// <summary> Повышение уровня и обновление данных на UI </summary>
        public void UserInfoPlayer()
        {
            // Если уровень персонажа больше чем 100 * уровень персонажа
            if (Player.Glasses > 100 * Player.Level)
            {
                // Увеличиваем уровень на 1
                Player.Level++;
                // Обновляем очки уровня
                Player.Glasses = 0;
                // Увеличиваем здоровье на 100
                Player.Health += 100;
                // Увеличиваем урон на 1
                Player.Damage++;
                // Увеличиваем броню на 1
                Player.Armor++;
            }
            // выводим данные на экран
            playerHealth.Content = "Жизненные показатели: " + Player.Health;
            playerArmor.Content = "Броня: " + Player.Armor;
            playerLevel.Content = "Уровень: " + Player.Level;
            playerGlasses.Content = "Опыт: " + Player.Glasses;
            playerMoney.Content = "Монеты: " + Player.Money;

        }
        /// <summary>
        /// Выбор случайного противника из списка врагов
        /// </summary>
        public void SelectEnemy()
        {
            if (Enemys == null || Enemys.Count == 0)
            {
                MessageBox.Show("Список врагов пуст!");
                return;
            }

            Random random = new Random();
            int index = random.Next(Enemys.Count);

            Enemy = new Classes.PersonInfo(
                Enemys[index].Name,
                Enemys[index].Health,
                Enemys[index].Armor,
                Enemys[index].Level,
                Enemys[index].Glasses,
                Enemys[index].Money,
                Enemys[index].Damage);
        }
        /// <summary>
        /// Метод, который наносит урон врагу при клике по нему
        /// </summary>
        private void AttackEnemy(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //// Наносим урон в процентном соотношении с учётом брони врага
            //Enemy.Health -= Convert.ToInt32(Player.Damage * 100f / (100f - Enemy.Armor));

            //// Если жизненные показатели врага меньше или равны 0
            //if (Enemy.Health <= 0)
            //{
            //    // Увеличиваем очки опыта игрока
            //    Player.Glasses += Enemy.Glasses;
            //    // Увеличиваем монеты игрока
            //    Player.Money += Enemy.Money;
            //    // Обновляем информацию на интерфейсе
            //    UserInfoPlayer();
            //    // Выбираем нового противника для следующего боя
            //    SelectEnemy();
            //}
            //else
            //{
            //    emptyHealth.Content = "Жизненные показатели: " + Enemy.Health;
            //    emptyArmor.Content = "Броня: " + Enemy.Armor;
            //}
           
                // Наносим урон врагу с учётом его брони
                int damage = Convert.ToInt32(Player.Damage * 100f / (100 - Enemy.Armor));
                Enemy.Health -= damage;

                // Обновляем отображение HP врага
                emptyHealth.Content = "Жизненные показатели: " + Math.Max(0, Enemy.Health);
                emptyArmor.Content = "Броня: " + Enemy.Armor;

                // Если враг повержен
                if (Enemy.Health <= 0)
                {
                    // Получаем опыт с учётом множителя (до +30%)
                    int earnedExp = (int)(Enemy.Glasses * (1 + Player.chtoto));
                    Player.Glasses += earnedExp;

                    // Получаем деньги
                    Player.Money += Enemy.Money;

                    // Обновляем интерфейс
                    UserInfoPlayer();

                    // Выбираем нового врага
                    SelectEnemy();
            }
        }

    }
}
