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

namespace Task_01
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class TextForm //класс отвечающий за оформление текста
        {
            public FontWeight font { get; set; }
            public FontStyle style { get; set; }
            public TextDecorationCollection decoration { get; set; }
            public double size { get; set; }
            public Brush brush { get; set; }

            public TextForm(FontWeight _font, FontStyle _style, TextDecorationCollection _decoration, double _size, Brush _brush)
            {
                font = _font;
                style = _style;
                decoration = _decoration;
                size = _size;
                brush = _brush;
            }
        }
        //создаем объект класса с установками форматирования по-умолчанию
        TextForm tf = new TextForm(FontWeights.Normal, FontStyles.Normal, null, 18, Brushes.Black);
        //весь наш текст
        public string all_text = @"Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequuntur quod explicabo, possimus reprehenderit,
            eveniet sunt asperiores dicta eligendi ducimus quae doloremque magnam necessitatibus nobis ipsa minus, assumenda ratione.
            Voluptas earum ratione omnis blanditiis delectus.Amet cupiditate ex eum quasi porro pariatur! Facilis laboriosam porro eum
            nemo odit, molestias, quae perspiciatis in soluta qui maiores esse error officia doloribus necessitatibus dolorum perferendis
            nisi minima. Voluptatibus, ipsum eum! Vel vero ratione illum autem saepe ducimus voluptatem ipsam cum eius magnam eos, adipisci
            ut earum soluta nesciunt esse repudiandae maxime repellat mollitia ex.Eaque nesciunt, aspernatur excepturi deserunt a, rerum
            vero sapiente neque dolores error in! Iusto quidem obcaecati corporis id, impedit quo dignissimos et ipsum dolorum laborum
            repellendus consectetur autem veritatis? Aperiam, nemo quos! Sunt, illo facere magni pariatur aspernatur ipsa quisquam?
            Ipsa, nostrum provident dolorem id soluta iusto eaque assumenda fuga nihil laborum quos illum itaque alias saepe necessitatibus
            repellendus libero nam.";
        public MainWindow()
        {
            InitializeComponent();
            Title = "Home Task 04 Diakonov K.V.";
            start.Text = "0";
            end.Text = "0";
        }
        private void Bold_Click(object sender, RoutedEventArgs e)//жирность
        {
            all_text = text.Text;
            string t1, t2, t3;//весть текст разбиваем на три части относительно введенных start и end
            t1 = all_text.Substring(0, Convert.ToInt32(start.Text));
            t2 = all_text.Substring(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text)); ;
            t3 = all_text.Substring(Convert.ToInt32(end.Text), text.Text.Length - Convert.ToInt32(end.Text));
            text.Text = "";//старый текст очищаем
            text.Inlines.Add(t1);//первую часть добавляем без изменений
            Span partText = new Span(new Run(t2))//средняя часть текста меняем жирность, остальное берем из класса по умолчанию
            {
                FontWeight = FontWeights.Bold,
                FontStyle = tf.style,
                TextDecorations = tf.decoration,
                FontSize = tf.size,
                Foreground = tf.brush
            };
            tf.font = FontWeights.Bold;//меняем у объекта класса жирность по умолчанию с Normal на Bold
            text.Inlines.Add(partText);//добавляем измененную среднюю часть
            text.Inlines.Add(t3);//добавляем концовку без изменений
            //освобождаем контент и замещаем его новым содержимым
            var contentControl = main as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == text)
                {
                    contentControl.Content = null;
                }
                return;
            }
            this.Content = text;
        }

        private void Italic_Click(object sender, RoutedEventArgs e)//курсив
        {
            all_text = text.Text;
            string t1, t2, t3;
            t1 = all_text.Substring(0, Convert.ToInt32(start.Text));
            t2 = all_text.Substring(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text)); ;
            t3 = all_text.Substring(Convert.ToInt32(end.Text), text.Text.Length - Convert.ToInt32(end.Text));
            text.Text = "";
            text.Inlines.Add(t1);
            Span partText = new Span(new Run(t2))
            {
                FontWeight = tf.font,
                FontStyle = FontStyles.Italic,
                TextDecorations = tf.decoration,
                FontSize = tf.size,
                Foreground = tf.brush
            };
            tf.style = FontStyles.Italic;
            text.Inlines.Add(partText);
            text.Inlines.Add(t3);
            var contentControl = main as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == text)
                {
                    contentControl.Content = null;
                }
                return;
            }
            this.Content = text;
        }

        private void Underline_Click(object sender, RoutedEventArgs e)//подчеркивание
        {
            all_text = text.Text;
            string t1, t2, t3;
            t1 = all_text.Substring(0, Convert.ToInt32(start.Text));
            t2 = all_text.Substring(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text)); ;
            t3 = all_text.Substring(Convert.ToInt32(end.Text), text.Text.Length - Convert.ToInt32(end.Text));
            text.Text = "";
            text.Inlines.Add(t1);
            Span partText = new Span(new Run(t2))
            {
                FontWeight = tf.font,
                FontStyle = tf.style,
                TextDecorations = TextDecorations.Underline,
                FontSize = tf.size,
                Foreground = tf.brush
            };
            tf.decoration = TextDecorations.Underline;
            text.Inlines.Add(partText);
            text.Inlines.Add(t3);
            var contentControl = main as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == text)
                {
                    contentControl.Content = null;
                }
                return;
            }
            this.Content = text;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)//кнопка очищение, start и end в ноль, и возвращаем объекту класса настроййки по-умолчанию
        {
            start.Text = "0";
            end.Text = "0";
            text.Text = all_text;
            tf.font = FontWeights.Normal;
            tf.style = FontStyles.Normal;
            tf.decoration = null;
            tf.size = 18;
            tf.brush = Brushes.Black;
        }

        private void fontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)//размер шрифта 
        {
            all_text = text.Text;
            string t1, t2, t3;
            t1 = all_text.Substring(0, Convert.ToInt32(start.Text));
            t2 = all_text.Substring(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text)); ;
            t3 = all_text.Substring(Convert.ToInt32(end.Text), text.Text.Length - Convert.ToInt32(end.Text));
            text.Text = "";
            text.Inlines.Add(t1);
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            switch (selectedItem.Content.ToString())
            {
                case "8":
                    Span partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 8,
                        Foreground = tf.brush
                    };
                    tf.size = 8;
                    text.Inlines.Add(partText);
                    break;
                case "9":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 9,
                        Foreground = tf.brush
                    };
                    tf.size = 9;
                    text.Inlines.Add(partText);
                    break;
                case "10":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 10,
                        Foreground = tf.brush
                    };
                    tf.size = 10;
                    text.Inlines.Add(partText);
                    break;
                case "11":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 11,
                        Foreground = tf.brush
                    };
                    tf.size = 11;
                    text.Inlines.Add(partText);
                    break;
                case "12":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 12,
                        Foreground = tf.brush
                    };
                    tf.size = 12;
                    text.Inlines.Add(partText);
                    break;
                case "14":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 14,
                        Foreground = tf.brush
                    };
                    tf.size = 14;
                    text.Inlines.Add(partText);
                    break;
                case "16":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 16,
                        Foreground = tf.brush
                    };
                    tf.size = 16;
                    text.Inlines.Add(partText);
                    break;
                case "18":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 18,
                        Foreground = tf.brush
                    };
                    tf.size = 18;
                    text.Inlines.Add(partText);
                    break;
                case "20":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 20,
                        Foreground = tf.brush
                    };
                    tf.size = 20;
                    text.Inlines.Add(partText);
                    break;
                case "22":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 22,
                        Foreground = tf.brush
                    };
                    tf.size = 22;
                    text.Inlines.Add(partText);
                    break;
                case "24":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 24,
                        Foreground = tf.brush
                    };
                    tf.size = 24;
                    text.Inlines.Add(partText);
                    break;
                case "26":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 26,
                        Foreground = tf.brush
                    };
                    tf.size = 26;
                    text.Inlines.Add(partText);
                    break;
                case "28":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 28,
                        Foreground = tf.brush
                    };
                    tf.size = 28;
                    text.Inlines.Add(partText);
                    break;
                case "36":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 36,
                        Foreground = tf.brush
                    };
                    tf.size = 36;
                    text.Inlines.Add(partText);
                    break;
                case "48":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = 48,
                        Foreground = tf.brush
                    };
                    tf.size = 48;
                    text.Inlines.Add(partText);
                    break;
            }
            text.Inlines.Add(t3);
            var contentControl = main as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == text)
                {
                    contentControl.Content = null;
                }
                return;
            }
            this.Content = text;
        }

        private void fontColor_SelectionChanged(object sender, SelectionChangedEventArgs e)//цвет текста
        {
            all_text = text.Text;
            string t1, t2, t3;
            t1 = all_text.Substring(0, Convert.ToInt32(start.Text));
            t2 = all_text.Substring(Convert.ToInt32(start.Text), Convert.ToInt32(end.Text) - Convert.ToInt32(start.Text)); ;
            t3 = all_text.Substring(Convert.ToInt32(end.Text), text.Text.Length - Convert.ToInt32(end.Text));
            text.Text = "";
            text.Inlines.Add(t1);
            ComboBox comboBox = (ComboBox)sender;
            ComboBoxItem selectedItem = (ComboBoxItem)comboBox.SelectedItem;
            switch (selectedItem.Name)
            {
                case "black":
                    Span partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Black
                    };
                    tf.brush = Brushes.Black;
                    text.Inlines.Add(partText);
                    break;
                case "blue":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Blue
                    };
                    tf.brush = Brushes.Blue;
                    text.Inlines.Add(partText);
                    break;
                case "green":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Green
                    };
                    tf.brush = Brushes.Green;
                    text.Inlines.Add(partText);
                    break;
                case "orange":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Orange
                    };
                    tf.brush = Brushes.Orange;
                    text.Inlines.Add(partText);
                    break;
                case "purple":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Purple
                    };
                    tf.brush = Brushes.Purple;
                    text.Inlines.Add(partText);
                    break;
                case "red":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Red
                    };
                    tf.brush = Brushes.Red;
                    text.Inlines.Add(partText);
                    break;
                case "yellow":
                    partText = new Span(new Run(t2))
                    {
                        FontWeight = tf.font,
                        FontStyle = tf.style,
                        TextDecorations = tf.decoration,
                        FontSize = tf.size,
                        Foreground = Brushes.Yellow
                    };
                    tf.brush = Brushes.Yellow;
                    text.Inlines.Add(partText);
                    break;
            }
            text.Inlines.Add(t3);
            var contentControl = main as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == text)
                {
                    contentControl.Content = null;
                }
                return;
            }
            this.Content = text;
        }

        private void end_TextChanged(object sender, TextChangedEventArgs e)//изменеие текста в окошке end
        {
            try
            {
                if (String.IsNullOrEmpty(end.Text) || Convert.ToInt32(end.Text) < 0 ||
                    Convert.ToInt32(end.Text) <= Convert.ToInt32(start.Text) || Convert.ToInt32(end.Text) > 1131)
                {
                    Bold.IsEnabled = false;
                    Italic.IsEnabled = false;
                    Underline.IsEnabled = false;
                    fontSize.IsEnabled = false;
                    fontColor.IsEnabled = false;
                }
                else if (end.Text.StartsWith("0") && end.Text.Length > 1)
                {
                    end.Text = end.Text.Substring(1);
                    end.CaretIndex = 1;
                }
                else
                {
                    Bold.IsEnabled = true;
                    Italic.IsEnabled = true;
                    Underline.IsEnabled = true;
                    fontSize.IsEnabled = true;
                    fontColor.IsEnabled = true;
                    end.Focus();
                }
            }
            catch (Exception ex)
            {
                Bold.IsEnabled = false;
                Italic.IsEnabled = false;
                Underline.IsEnabled = false;
                fontSize.IsEnabled = false;
                fontColor.IsEnabled = false;
            }

        }

        private void start_TextChanged(object sender, TextChangedEventArgs e)//изменеие текста в окошке start
        {
            try
            {
                if (start.Text.StartsWith("0") && start.Text.Length > 1)
                {
                    start.Text = start.Text.Substring(1);
                    start.CaretIndex = 1;
                }
                else if (Convert.ToInt32(start.Text) < 0 && !String.IsNullOrEmpty(start.Text))
                    start.Text = "0";                    
            }
            catch (Exception ex)
            {
                start.Text = "0";
            }

        }
    }
}
