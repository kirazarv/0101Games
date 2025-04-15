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
using System.Windows.Shapes;

namespace OOOPlayerok.View
{
    /// <summary>
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        public Catalog()
        {
            InitializeComponent();
            try
            {
                //установка связи с бд 
                App.DB = new Model.gamesEntities();
                MessageBox.Show("успешно подключились к БД", "Проверка подключения", MessageBoxButton.OK, MessageBoxImage.Information);


            }
            catch (Exception)//перехватывает все типы исключений
            {
                MessageBox.Show("успешно подключиться к БД не удалось", "Проверка подключения", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            if (this.Owner != null)
            {
                this.Owner.Show();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<Model.Game> games = App.DB.Game.ToList();
            int gamesCount = games.Count();
            string gamesCountText = $"{gamesCount} Из {gamesCount}";
            tbCount.Text = gamesCountText;
            foreach (Model.Game game in games)
            {
                game.Image = GetImage(game.GameId);
                game.DiscountPercent = Math.Round(100 * game.GameDiscount);
               
            }
            lbGames.ItemsSource = games;

            // Заполнение ComboBox для фильтрации по скидке
            List<DiscountRange> discountRanges = new List<DiscountRange>
            {
            new DiscountRange { DisplayName = "Все диапазоны", MinDiscount = 0, MaxDiscount = 100 },
            new DiscountRange { DisplayName = "от 0 до 25%", MinDiscount = 0, MaxDiscount = 25 },
            new DiscountRange { DisplayName = "от 25 до 50%", MinDiscount = 25, MaxDiscount = 50 },
            new DiscountRange { DisplayName = "от 50 до 100%", MinDiscount = 50, MaxDiscount = 100 }
            };

            cbFilterDiscount.ItemsSource = discountRanges;
            cbFilterDiscount.SelectedItem = discountRanges[0]; // "Все диапазоны" по умолчанию

            // Заполнение ComboBox для жанров
            List<GenreOptions> genreOptions = new List<GenreOptions>
            {
            new GenreOptions { GenreId = null, GenreName = "Все жанры" } // Опция "Все жанры"
            };

            List<Model.Genre> genres = App.DB.Genre.ToList();
            foreach (var genre in genres)
            {
                genreOptions.Add(new GenreOptions { GenreId = genre.GenreId, GenreName = genre.GenreName });
            }

            cbFilterGenre.ItemsSource = genreOptions;
            cbFilterGenre.DisplayMemberPath = "GenreName";
            cbFilterGenre.SelectedValuePath = "GenreId";

            // Установка "Все жанры" по умолчанию
            cbFilterGenre.SelectedIndex = 0;

            UpdateList();

        }
        public BitmapImage GetImage(int gameId)
        {
            try
            {
                //подгрузка изображения из bin/Debug/Resources
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Resources/{gameId}.jpg");
                return new BitmapImage(new Uri(imagePath));
                //Uri resourceUri = new Uri($"/Resources/{gameId}.jpg", UriKind.Relative);
                //return new BitmapImage(resourceUri);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                return null;
            }
        }
        private void UpdateList(object sender = null, EventArgs e = null)
        {
            List<Model.Game> games = App.DB.Game.ToList();
            foreach (Model.Game game in games)
            {
                game.Image = GetImage(game.GameId);
                game.DiscountPercent = Math.Round(100 * game.GameDiscount);
            }
            // Фильтрация по скидке
            if (cbFilterDiscount.SelectedItem is DiscountRange selectedDiscount)
            {
                games = games.Where(g => g.DiscountPercent >= selectedDiscount.MinDiscount && g.DiscountPercent <= selectedDiscount.MaxDiscount).ToList();
            }

            // Фильтрация по жанру
            if (cbFilterGenre.SelectedItem is GenreOptions selectedGenre)
            {
                if (selectedGenre.GenreId != null)
                {
                    games = games.Where(g => g.GenreId == selectedGenre.GenreId).ToList();
                }
            }

            // Поиск по названию
            string searchText = tbSearch.Text;
            if (!string.IsNullOrEmpty(searchText))
            {
                games = games.Where(g => g.GameTitle.ToLower().Contains(searchText.ToLower())).ToList();
            }

            // Сортировка
            if (rbSortAscending.IsChecked == true)
            {
                games = games.OrderBy(g => g.GamePrice).ToList();
            }
            else if (rbSortDescending.IsChecked == true)
            {
                games = games.OrderByDescending(g => g.GamePrice).ToList();
            }

            lbGames.ItemsSource = games;

            // Обновление количества
            int gamesCount = games.Count();
            string gamesCountText = $"{gamesCount} Из {App.DB.Game.Count()}";
            tbCount.Text = gamesCountText;

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //открытие окна добавления
            View.AddWindow addWindow = new View.AddWindow();
            //метод addWindow.ShowDialog() Модально показывает окно добавления
            //и код за этим вызовом будет ждать закрытия окна AddWindow, прежде чем продолжится выполнение.
            addWindow.ShowDialog();
            UpdateList(); // Обновляем список после закрытия окна добавления
        }
    }
}
