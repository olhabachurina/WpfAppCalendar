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

namespace WpfAppCalendar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {
            private DateTime displayedMonth;
            public MainWindow()
            {
                InitializeComponent();
                displayedMonth = DateTime.Now;
                DisplayCalendar(DateTime.Now);
            }

            private void DisplayCalendar(DateTime date)
            {
                calendarGrid.Children.Clear();
                Title = date.ToString("MMMM yyyy");
                DateTime firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
                int daysInMonth = DateTime.DaysInMonth(date.Year, date.Month);
                for (int i = 1; i <= daysInMonth; i++)
                {
                    Button dayButton = new Button
                    {
                        Content = i.ToString(),
                        Tag = new DateTime(date.Year, date.Month, i),
                    };

                    Style dayButtonStyle = TryFindResource("DayButtonStyle") as Style;
                    if (dayButtonStyle != null)
                    {
                        dayButton.Style = dayButtonStyle;
                    }

                    dayButton.Click += DayButton_Click;
                    calendarGrid.Children.Add(dayButton);
                }

                for (int i = 1; i < (int)firstDayOfMonth.DayOfWeek; i++)
                {
                    calendarGrid.Children.Insert(0, new TextBlock());
                }
            }
            private void DayButton_Click(object sender, RoutedEventArgs e)
            {
                Button clickedButton = (Button)sender;
                DateTime selectedDate = (DateTime)clickedButton.Tag;
                MessageBox.Show($"Выбран день: {selectedDate.ToShortDateString()} ({selectedDate.ToString("dddd")})");

            }
            private void PrevMonth_Click(object sender, RoutedEventArgs e)
            {
                displayedMonth = displayedMonth.AddMonths(-1);
                DisplayCalendar(displayedMonth);
            }
            private void NextMonth_Click(object sender, RoutedEventArgs e)
            {
                displayedMonth = displayedMonth.AddMonths(1);
                DisplayCalendar(displayedMonth);
            }
        }
    }
