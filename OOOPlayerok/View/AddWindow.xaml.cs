using Microsoft.Win32;
using OOOPlayerok.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;

namespace OOOPlayerok.View
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        private string _imagePath;
        public AddWindow()
        {
            InitializeComponent();

        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //настройка комбобокса для жанра 
            List<Model.Genre> genres = App.DB.Genre.ToList();
            cbGenre.ItemsSource = genres;
            cbGenre.DisplayMemberPath = "GenreName";
            cbGenre.SelectedValuePath = "GenreId";
            cbGenre.SelectedIndex = 0;

            //настройка комбобокса для разработчика 
            List<Model.Developer> developers = App.DB.Developer.ToList();
            cbDeveloper.ItemsSource = developers;
            cbDeveloper.DisplayMemberPath = "DeveloperName";
            cbDeveloper.SelectedValuePath = "DeveloperId";
            cbDeveloper.SelectedIndex = 0;
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Model.Game game = new Game(); //выделить память под новую игру
            game.GameTitle = tbTitle.Text;
            //selected val-это object приводит к типу int
            game.GenreId = (int)cbGenre.SelectedValue;
            game.DeveloperId = (int)cbDeveloper.SelectedValue;
            game.GameDescription= tbDescription.Text;
            double price;
            if (!double.TryParse(tbPrice.Text, out price))
            {
                MessageBox.Show("Цена должна быть числом");
                return;
            }
            game.GamePrice = price;

            double disc;
            if (!double.TryParse(tbDiscount.Text, out disc))
            {
                MessageBox.Show("Скидка должна быть числом с плавающей запятой");
                return;
            }
            game.GameDiscount = disc;

            try
            {
                App.DB.Game.Add(game);
                App.DB.SaveChanges();

                // Проверяем, было ли загружено изображение 
                if (!string.IsNullOrEmpty(_imagePath))
                {
                    string fileName = $"{game.GameId}.jpg";
                    string destinationPath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", fileName);

                    try
                    {
                        File.Copy(_imagePath, destinationPath, true);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка копирования файла: " + ex.Message);
                    }
                    // Сохраняем изображение в папку Resources
                    //SaveImageToResources(_imagePath);

                }

                MessageBox.Show(" Игра успешно добавлена" ,"Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка при добавлении", "Рез-т добавления", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            this.Close();//возврат в главное окно
        }

        private void btnLoadImage_Click(object sender, RoutedEventArgs e)
        {
           
            // Создаёт новый экземпляр класса OpenFileDialog для открытия диалогового окна выбора файлов.
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Image files (*.jpg)|*.jpg"; // Фильтр только для JPG

            //ShowDialog() — метод, который показывает диалоговое окно и возвращает true,
            //если пользователь вырал файл и нажал ок, и false, если нажал "Отмена"
            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    //Сохраняет путь к выбранному файлу в переменную _imagePath
                    //Свойство FileName класса OpenFileDialog возвращает путь к выбранному пользователем файлу.
                    _imagePath = openFileDialog.FileName;
                    //Создаёт объект BitmapImage для отображения загруженного изображения.
                    BitmapImage bitmap = new BitmapImage(new Uri(_imagePath));
                    // Присваивает загруженное изображение свойству Source элемента Image (imgGame).
                    imgGame.Source = bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка загрузки изображения: " + ex.Message);
                }
            }
        }
       
    }
}
